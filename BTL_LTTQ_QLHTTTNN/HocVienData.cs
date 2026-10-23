using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    internal static class HocVienData
    {
        public static SqlConnection Open()
        {
            var setting = ConfigurationManager.ConnectionStrings["QLTrungTamTiengAnh"];
            if (setting == null) throw new InvalidOperationException("Thiếu connectionStrings QLTrungTamTiengAnh trong App.config.");
            var c = new SqlConnection(setting.ConnectionString);
            try { c.Open(); return c; } catch { c.Dispose(); throw; }
        }
        public static SqlParameter P(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }
        public static DataTable Query(string sql, params SqlParameter[] ps)
        {
            using (var c = Open()) return Query(c, null, sql, ps);
        }
        private static DataTable Query(SqlConnection c, SqlTransaction tx, string sql, params SqlParameter[] ps)
        {
            using (var cmd = new SqlCommand(sql, c, tx))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(ps);
                var t = new DataTable(); da.Fill(t); return t;
            }
        }
        public static void Run(Action action)
        {
            try { action(); }
            catch (SqlException ex)
            {
                string message = ex.Number == 2601 || ex.Number == 2627
                    ? "Dữ liệu bị trùng. Nếu thêm học viên chưa có tài khoản, hãy chạy SQL/01_ChoPhepHocVienChuaCoTaiKhoan.sql một lần."
                    : "Không thực hiện được thao tác SQL. Kiểm tra Server name trong App.config và database QLTrungTamTiengAnh.\n\n" + ex.Message;
                MessageBox.Show(message, "SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        public static void Grid(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.DataPropertyName.StartsWith("Ngay")) col.DefaultCellStyle.Format = "dd/MM/yyyy";
                if (col.DataPropertyName == "DiemCuoiKhoa") col.DefaultCellStyle.NullValue = "Chưa có điểm";
                if (col.DataPropertyName == "KetQua") col.DefaultCellStyle.NullValue = "Chưa có kết quả";
                if (col.DataPropertyName.Contains("Phi") || col.DataPropertyName.Contains("PhaiTra") || col.DataPropertyName == "DaThanhToan")
                    col.DefaultCellStyle.Format = "N0";
            }
        }
        public static DataRow Row(DataGridView g)
        {
            var view = g.CurrentRow == null ? null : g.CurrentRow.DataBoundItem as DataRowView;
            return view == null ? null : view.Row;
        }
        public static DataTable Students(string keyword, string status)
        {
            // CHARINDEX searches a literal substring; %, _ and [ are not wildcard characters.
            return Query(@"SELECT h.*, n.TenDangNhap FROM HocVien h
LEFT JOIN NguoiDung n ON n.NguoiDungID=h.NguoiDungID AND n.IsDeleted=0
WHERE h.IsDeleted=0 AND (@s=N'Tất cả' OR h.TrangThai=@s)
AND (@q=N'' OR CHARINDEX(@q,h.HoTen)>0 OR CHARINDEX(@q,ISNULL(h.SoDienThoai,''))>0
OR CONVERT(varchar(20),h.HocVienID)=@q) ORDER BY h.HocVienID DESC", P("@s",status),P("@q",keyword));
        }
        public static int SaveStudent(int? id, string name, DateTime? birth, string gender, string phone,
            string email, string level, decimal? score, string note, string status)
        {
            string sql = id.HasValue
                ? @"UPDATE HocVien SET HoTen=@name,NgaySinh=@birth,GioiTinh=@gender,SoDienThoai=@phone,
Email=@email,TrinhDoDauVao=@level,DiemDauVao=@score,NhanXetDauVao=@note,TrangThai=@status,UpdatedAt=GETDATE()
WHERE HocVienID=@id AND IsDeleted=0; IF @@ROWCOUNT=0 THROW 50001,N'Học viên đã bị xóa. Hãy tải lại danh sách.',1; SELECT @id;"
                : @"INSERT HocVien(HoTen,NgaySinh,GioiTinh,SoDienThoai,Email,TrinhDoDauVao,DiemDauVao,NhanXetDauVao,TrangThai)
OUTPUT INSERTED.HocVienID VALUES(@name,@birth,@gender,@phone,@email,@level,@score,@note,@status);";
            using (var c=Open()) using (var cmd=new SqlCommand(sql,c))
            {
                cmd.Parameters.AddRange(new[] { P("@id",id),P("@name",name),P("@birth",birth),P("@gender",Empty(gender)),P("@phone",Empty(phone)),
                    P("@email",Empty(email)),P("@level",Empty(level)),P("@note",Empty(note)),P("@status",status) });
                var sp=cmd.Parameters.Add("@score",SqlDbType.Decimal); sp.Precision=5; sp.Scale=2; sp.Value=(object)score ?? DBNull.Value;
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        private static object Empty(string value) { return string.IsNullOrWhiteSpace(value) ? (object)DBNull.Value : value.Trim(); }
        public static DataTable Enrollments(int id)
        {
            return Query(@"SELECT d.*,l.TenLop,k.TenKhoaHoc,c.TenCoSo,l.NgayBatDau,l.NgayKetThuc
FROM DangKy d JOIN LopHoc l ON l.LopHocID=d.LopHocID
JOIN KhoaHoc k ON k.KhoaHocID=l.KhoaHocID JOIN CoSo c ON c.CoSoID=l.CoSoID
WHERE d.HocVienID=@id AND d.IsDeleted=0 ORDER BY d.NgayDangKy DESC",P("@id",id));
        }
        public static DataTable Fees(int id)
        {
            // Aggregate payments per invoice before joining to avoid multiplying amounts.
            return Query(@"SELECT l.TenLop,h.HoaDonID,h.TongPhaiTra,ISNULL(t.DaThanhToan,0) DaThanhToan,
CASE WHEN h.TongPhaiTra>ISNULL(t.DaThanhToan,0) THEN h.TongPhaiTra-ISNULL(t.DaThanhToan,0) ELSE 0 END ConPhaiTra,
CASE WHEN ISNULL(t.DaThanhToan,0)>h.TongPhaiTra THEN N'Đóng dư'
WHEN ISNULL(t.DaThanhToan,0)=h.TongPhaiTra THEN N'Đã đủ' ELSE N'Chưa đủ' END TrangThai
FROM HoaDon h LEFT JOIN DangKy d ON d.DangKyID=h.DangKyID LEFT JOIN LopHoc l ON l.LopHocID=d.LopHocID
LEFT JOIN (SELECT HoaDonID,SUM(SoTien) DaThanhToan FROM ThanhToan WHERE IsDeleted=0 GROUP BY HoaDonID) t ON t.HoaDonID=h.HoaDonID
WHERE h.HocVienID=@id AND h.IsDeleted=0
UNION ALL
SELECT l.TenLop,NULL,NULL,NULL,NULL,N'Chưa lập hóa đơn'
FROM DangKy d JOIN LopHoc l ON l.LopHocID=d.LopHocID WHERE d.HocVienID=@id AND d.IsDeleted=0
AND NOT EXISTS(SELECT 1 FROM HoaDon h WHERE h.DangKyID=d.DangKyID AND h.HocVienID=@id AND h.IsDeleted=0)",P("@id",id));
        }
        public static DataTable Classes(int site, int course)
        {
            return Query(@"SELECT l.*,k.TenKhoaHoc,k.HocPhi,c.TenCoSo,ISNULL(d.SoLuong,0) SiSoHienTai,
l.SiSoToiDa-ISNULL(d.SoLuong,0) ChoConLai FROM LopHoc l
JOIN KhoaHoc k ON k.KhoaHocID=l.KhoaHocID JOIN CoSo c ON c.CoSoID=l.CoSoID
LEFT JOIN (SELECT LopHocID,COUNT(*) SoLuong FROM DangKy WHERE IsDeleted=0 GROUP BY LopHocID) d ON d.LopHocID=l.LopHocID
WHERE l.IsDeleted=0 AND k.IsDeleted=0 AND c.IsDeleted=0 AND c.TrangThai=1
AND l.TrangThai IN(N'Dự kiến',N'Đang học') AND l.NgayKetThuc>=CONVERT(date,GETDATE())
AND (@site=0 OR l.CoSoID=@site) AND (@course=0 OR l.KhoaHocID=@course)
ORDER BY l.NgayBatDau,l.TenLop",P("@site",site),P("@course",course));
        }
        public static void Register(int student, int classroom, DateTime date, string note, decimal expectedFee, bool save)
        {
            using(var c=Open()) using(var tx=c.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    var cl=Query(c,tx,@"SELECT l.*,k.HocPhi FROM LopHoc l WITH(UPDLOCK,HOLDLOCK)
JOIN KhoaHoc k ON k.KhoaHocID=l.KhoaHocID JOIN CoSo cs ON cs.CoSoID=l.CoSoID
WHERE l.LopHocID=@id AND l.IsDeleted=0 AND k.IsDeleted=0 AND cs.IsDeleted=0 AND cs.TrangThai=1
AND l.TrangThai IN(N'Dự kiến',N'Đang học') AND l.NgayKetThuc>=CONVERT(date,GETDATE())",P("@id",classroom));
                    if(cl.Rows.Count==0) throw new InvalidOperationException("Lớp không còn nhận đăng ký. Hãy lọc lại danh sách lớp.");
                    if(Query(c,tx,"SELECT HocVienID FROM HocVien WHERE HocVienID=@id AND IsDeleted=0",P("@id",student)).Rows.Count==0)
                        throw new InvalidOperationException("Học viên không còn tồn tại.");
                    var old=Query(c,tx,"SELECT IsDeleted FROM DangKy WITH(UPDLOCK,HOLDLOCK) WHERE HocVienID=@h AND LopHocID=@l",P("@h",student),P("@l",classroom));
                    if(old.Rows.Count>0) throw new InvalidOperationException(Convert.ToBoolean(old.Rows[0][0])
                        ? "Đăng ký này đã bị xóa mềm. Cần quản trị viên xử lý khôi phục; không thể đăng ký trùng."
                        : "Học viên đã đăng ký lớp này.");
                    int count=Convert.ToInt32(Query(c,tx,"SELECT COUNT(*) FROM DangKy WITH(UPDLOCK,HOLDLOCK) WHERE LopHocID=@id AND IsDeleted=0",P("@id",classroom)).Rows[0][0]);
                    if(count>=Convert.ToInt32(cl.Rows[0]["SiSoToiDa"])) throw new InvalidOperationException("Lớp đã đủ sĩ số.");
                    decimal fee=Convert.ToDecimal(cl.Rows[0]["HocPhi"]);
                    if(fee!=expectedFee) throw new InvalidOperationException("Học phí vừa thay đổi. Hãy lọc lại lớp để xem học phí mới.");
                    if(date.Date>DateTime.Today) throw new InvalidOperationException("Ngày đăng ký không được ở tương lai.");
                    if(save)
                    using(var cmd=new SqlCommand(@"INSERT DangKy(HocVienID,LopHocID,NgayDangKy,HocPhiApDung,GhiChu)
VALUES(@h,@l,@date,@fee,@note)",c,tx))
                    {
                        cmd.Parameters.AddRange(new[]{P("@h",student),P("@l",classroom),P("@date",date.Date),P("@note",Empty(note))});
                        var fp=cmd.Parameters.Add("@fee",SqlDbType.Decimal);fp.Precision=12;fp.Scale=2;fp.Value=fee;
                        cmd.ExecuteNonQuery();
                    }
                    tx.Commit();
                }
                catch { tx.Rollback(); throw; }
            }
        }
    }
}
