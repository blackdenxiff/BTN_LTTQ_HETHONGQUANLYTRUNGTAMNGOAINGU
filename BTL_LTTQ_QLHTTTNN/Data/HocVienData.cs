using System;
using BTL_LTTQ_QLHTTTNN.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    internal static class HocVienData
    {
        // Luôn lấy chủ sở hữu từ phiên đã xác thực, không tin ID do form truyền vào.
        public static DataRow OwnProfile(int? requestedUserId)
        {
            PhanQuyenService.YeuCauQuyen("XemHoSoCaNhan");
            var session = SessionContext.NguoiDungHienTai;
            if (!requestedUserId.HasValue || requestedUserId.Value != session.NguoiDungID)
                throw new UnauthorizedAccessException("Không được truy cập hồ sơ của tài khoản khác.");
            var table = Query(@"SELECT h.*,n.TenDangNhap FROM HocVien h
JOIN NguoiDung n ON n.NguoiDungID=h.NguoiDungID
JOIN VaiTro v ON v.VaiTroID=n.VaiTroID
WHERE h.HocVienID=@student AND h.NguoiDungID=@user AND h.IsDeleted=0
AND n.IsDeleted=0 AND n.TrangThai=1 AND n.DoiMatKhauLanDau=0
AND v.IsDeleted=0 AND v.TenVaiTro=N'Học viên'
AND NOT EXISTS(SELECT 1 FROM NhanSu ns WHERE ns.NguoiDungID=n.NguoiDungID AND ns.IsDeleted=0)",
                P("@student", session.HocVienID), P("@user", session.NguoiDungID));
            if (table.Rows.Count != 1) throw new UnauthorizedAccessException("Hồ sơ hoặc quyền truy cập đã thay đổi. Vui lòng đăng nhập lại.");
            return table.Rows[0];
        }
        private static void RequireStudentRead(int student, string permission)
        {
            if (PhanQuyenService.KiemTraQuyen("QuanLyHocVien")) return;
            PhanQuyenService.YeuCauQuyen(permission);
            var row = OwnProfile(SessionContext.NguoiDungHienTai.NguoiDungID);
            if (Convert.ToInt32(row["HocVienID"]) != student)
                throw new UnauthorizedAccessException("Chỉ được xem dữ liệu của chính mình.");
        }
        public static DataTable ScheduleForCurrentUser(int? requestedUserId, DateTime from, DateTime to)
        {
            var profile = OwnProfile(requestedUserId);
            if (to.Date < from.Date) throw new InvalidOperationException("Khoảng ngày không hợp lệ.");
            return Query(@"SELECT lh.NgayHoc,
CONVERT(varchar(5),lh.GioBatDau,108) AS GioBatDau,
CONVERT(varchar(5),lh.GioKetThuc,108) AS GioKetThuc,
l.TenLop,k.TenKhoaHoc,p.TenPhong,c.TenCoSo,lh.TrangThai,lh.GhiChu
FROM LichHoc lh
JOIN LopHoc l ON l.LopHocID=lh.LopHocID AND l.IsDeleted=0
JOIN KhoaHoc k ON k.KhoaHocID=l.KhoaHocID AND k.IsDeleted=0
LEFT JOIN PhongHoc p ON p.PhongHocID=lh.PhongHocID AND p.IsDeleted=0
LEFT JOIN CoSo c ON c.CoSoID=p.CoSoID AND c.IsDeleted=0
WHERE lh.IsDeleted=0 AND lh.NgayHoc BETWEEN @from AND @to
AND EXISTS(SELECT 1 FROM DangKy d
JOIN HocVien h ON h.HocVienID=d.HocVienID
JOIN NguoiDung n ON n.NguoiDungID=h.NguoiDungID
JOIN VaiTro v ON v.VaiTroID=n.VaiTroID
WHERE d.LopHocID=lh.LopHocID AND d.HocVienID=@student AND d.IsDeleted=0
AND h.NguoiDungID=@user AND h.IsDeleted=0
AND n.IsDeleted=0 AND n.TrangThai=1 AND n.DoiMatKhauLanDau=0
AND v.IsDeleted=0 AND v.TenVaiTro=N'Học viên'
AND NOT EXISTS(SELECT 1 FROM NhanSu ns WHERE ns.NguoiDungID=n.NguoiDungID AND ns.IsDeleted=0))
ORDER BY lh.NgayHoc,lh.GioBatDau,l.TenLop,lh.LichHocID",
                P("@student", Convert.ToInt32(profile["HocVienID"])), P("@user", requestedUserId.Value),
                P("@from", from.Date), P("@to", to.Date));
        }
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
                    : "Không thực hiện được thao tác SQL. Kiểm tra Server name trong App.config và tên database trong chuỗi kết nối.\n\n" + ex.Message;
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
            PhanQuyenService.YeuCauQuyen("QuanLyHocVien");
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
            PhanQuyenService.YeuCauQuyen("QuanLyHocVien");
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
            RequireStudentRead(id, "XemLopCaNhan");
            return Query(@"SELECT d.*,l.TenLop,k.TenKhoaHoc,c.TenCoSo,l.NgayBatDau,l.NgayKetThuc
FROM DangKy d JOIN LopHoc l ON l.LopHocID=d.LopHocID
JOIN KhoaHoc k ON k.KhoaHocID=l.KhoaHocID JOIN CoSo c ON c.CoSoID=l.CoSoID
WHERE d.HocVienID=@id AND d.IsDeleted=0 ORDER BY d.NgayDangKy DESC",P("@id",id));
        }
        public static DataTable Fees(int id)
        {
            RequireStudentRead(id, "XemHocPhiCaNhan");
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
            PhanQuyenService.YeuCauQuyen("DangKyLopCaNhan");
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
            PhanQuyenService.YeuCauQuyen("DangKyLopCaNhan");
            var session = SessionContext.NguoiDungHienTai;
            if (session.HocVienID != student)
                throw new UnauthorizedAccessException("Chỉ được đăng ký lớp cho chính mình.");
            using(var c=Open()) using(var tx=c.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    // Kiểm tra và giữ khóa quyền sở hữu trong cùng giao dịch ghi đăng ký.
                    var owner = Query(c, tx, @"SELECT h.HocVienID FROM HocVien h WITH(HOLDLOCK)
JOIN NguoiDung n WITH(HOLDLOCK) ON n.NguoiDungID=h.NguoiDungID
JOIN VaiTro v WITH(HOLDLOCK) ON v.VaiTroID=n.VaiTroID
WHERE h.HocVienID=@student AND n.NguoiDungID=@user AND h.IsDeleted=0
AND n.IsDeleted=0 AND n.TrangThai=1 AND n.DoiMatKhauLanDau=0
AND v.IsDeleted=0 AND v.TenVaiTro=N'Học viên'
AND NOT EXISTS(SELECT 1 FROM NhanSu ns WITH(HOLDLOCK) WHERE ns.NguoiDungID=n.NguoiDungID AND ns.IsDeleted=0)",
                        P("@student", student), P("@user", session.NguoiDungID));
                    if (owner.Rows.Count != 1) throw new UnauthorizedAccessException("Tài khoản không còn quyền đăng ký lớp.");
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

// Phân trang dùng chung; đặt trong file đang được project biên dịch để không cần sửa csproj.
namespace BTL_LTTQ_QLHTTTNN
{
    internal sealed class GridPager
    {
        private readonly DataGridView grid;
        private readonly Action authorize;
        private readonly FlowLayoutPanel bar;
        private readonly Label info;
        private readonly Button previous, next;
        private readonly ComboBox size;
        private DataTable allRows;
        private int page;
        private int pageSize = 10;
        private bool binding;

        internal GridPager(DataGridView target, Action checkAccess)
        {
            grid = target; authorize = checkAccess;
            var parent = grid.Parent;
            int index = parent.Controls.GetChildIndex(grid);
            var wrapper = new Panel { Bounds = grid.Bounds, Dock = grid.Dock, Anchor = grid.Anchor,
                Margin = grid.Margin, MinimumSize = grid.MinimumSize };
            parent.Controls.Remove(grid);
            parent.Controls.Add(wrapper);
            parent.Controls.SetChildIndex(wrapper, index);
            grid.Dock = DockStyle.Fill;
            bar = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 42, WrapContents = false,
                AutoScroll = true, BackColor = System.Drawing.Color.FromArgb(235, 241, 248),
                Padding = new Padding(4) };
            previous = new Button { Text = "‹ Trước", Width = 80, Height = 30 };
            next = new Button { Text = "Sau ›", Width = 80, Height = 30 };
            info = new Label { AutoSize = true, Margin = new Padding(8, 8, 8, 0) };
            size = new ComboBox { Width = 60, DropDownStyle = ComboBoxStyle.DropDownList };
            size.Items.AddRange(new object[] { 10, 20, 50 }); size.SelectedIndex = 0;
            bar.Controls.Add(previous); bar.Controls.Add(info); bar.Controls.Add(next); bar.Controls.Add(size);
            bar.Controls.Add(new Label { Text = "dòng/trang", AutoSize = true, Margin = new Padding(2, 8, 0, 0) });
            wrapper.Controls.Add(grid); wrapper.Controls.Add(bar);
            previous.Click += delegate { Navigate(page - 1); };
            next.Click += delegate { Navigate(page + 1); };
            size.SelectedIndexChanged += delegate
            {
                HocVienData.Run(delegate { authorize(); pageSize = (int)size.SelectedItem; page = 0; BindPage(); });
            };
            grid.EnabledChanged += delegate { bar.Enabled = grid.Enabled; };
            grid.DataSourceChanged += delegate
            {
                if (binding) return;
                allRows = grid.DataSource as DataTable;
                page = 0;
                BindPage();
            };
            UpdateButtons();
        }
        private int PageCount { get { return allRows == null ? 0 : (allRows.Rows.Count + pageSize - 1) / pageSize; } }
        private void Navigate(int target)
        {
            HocVienData.Run(delegate
            {
                authorize();
                if (!grid.Enabled || target < 0 || target >= PageCount) return;
                page = target; BindPage();
            });
        }
        private void BindPage()
        {
            binding = true;
            try
            {
                if (allRows == null) grid.DataSource = null;
                else
                {
                    var part = allRows.Clone();
                    for (int i = page * pageSize; i < Math.Min((page + 1) * pageSize, allRows.Rows.Count); i++)
                        part.ImportRow(allRows.Rows[i]);
                    grid.DataSource = part;
                    foreach (DataGridViewColumn column in grid.Columns)
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                UpdateButtons();
            }
            finally { binding = false; }
        }
        private void UpdateButtons()
        {
            info.Text = string.Format("Trang {0}/{1} • {2} dòng", PageCount == 0 ? 0 : page + 1,
                PageCount, allRows == null ? 0 : allRows.Rows.Count);
            previous.Enabled = page > 0; next.Enabled = page + 1 < PageCount;
        }
        internal void GoToRecord(string key, int id)
        {
            if (allRows == null) return;
            for (int i = 0; i < allRows.Rows.Count; i++)
                if (Convert.ToInt32(allRows.Rows[i][key]) == id)
                { page = i / pageSize; BindPage(); return; }
        }
    }
}
