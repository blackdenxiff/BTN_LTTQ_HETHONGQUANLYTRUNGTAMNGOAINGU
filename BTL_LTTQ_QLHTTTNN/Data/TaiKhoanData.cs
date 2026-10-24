using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BTL_LTTQ_QLHTTTNN.Services;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN.Data
{
    internal static class TaiKhoanData
    {
        internal sealed class BanGhiXacThuc { public int Id; public string Ten; public string Hash; public string VaiTro; public string HoTen; public int? NhanSuId; public int? HocVienId; public bool BiKhoa; public bool DaXoa; public bool DoiMatKhauLanDau; public bool HoSoHopLe; }
        private static SqlParameter P(string name, object value) { return new SqlParameter(name, value ?? DBNull.Value); }
        private static string GiaTri(DataRow row, string column) { return row[column] == DBNull.Value ? null : Convert.ToString(row[column]); }

        internal static BanGhiXacThuc LayTheoTen(string tenDangNhap)
        {
            const string sql = @"SELECT TOP 1 n.NguoiDungID,n.TenDangNhap,n.MatKhauHash,n.TrangThai,n.IsDeleted,n.DoiMatKhauLanDau,
v.TenVaiTro,ns.NhanSuID,h.HocVienID,COALESCE(ns.HoTen,h.HoTen,n.TenDangNhap) HoTen,ns.LoaiNhanSu
FROM NguoiDung n JOIN VaiTro v ON v.VaiTroID=n.VaiTroID AND ISNULL(v.IsDeleted,0)=0
LEFT JOIN NhanSu ns ON ns.NguoiDungID=n.NguoiDungID AND ns.IsDeleted=0
LEFT JOIN HocVien h ON h.NguoiDungID=n.NguoiDungID AND h.IsDeleted=0
WHERE n.TenDangNhap=@ten";
            using (var c = DatabaseConnection.TaoKetNoi()) using (var cmd = new SqlCommand(sql, c))
            {
                cmd.Parameters.Add("@ten", SqlDbType.VarChar, 50).Value = tenDangNhap;
                c.Open(); using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;
                    string role = Convert.ToString(r["TenVaiTro"]); int? ns = r["NhanSuID"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["NhanSuID"]);
                    int? hv = r["HocVienID"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["HocVienID"]);
                    string loai = r["LoaiNhanSu"] == DBNull.Value ? null : Convert.ToString(r["LoaiNhanSu"]);
                    bool lienKetHopLe = role == "Admin" ? !ns.HasValue && !hv.HasValue : role == "Học viên" ? hv.HasValue && !ns.HasValue :
                        role == "Giáo viên" ? ns.HasValue && !hv.HasValue && (loai == "Giáo viên" || loai == "Cả hai") :
                        role == "Nhân viên" && ns.HasValue && !hv.HasValue && (loai == "Nhân viên" || loai == "Cả hai");
                    return new BanGhiXacThuc { Id = Convert.ToInt32(r["NguoiDungID"]), Ten = Convert.ToString(r["TenDangNhap"]), Hash = Convert.ToString(r["MatKhauHash"]),
                        VaiTro = role, HoTen = Convert.ToString(r["HoTen"]), NhanSuId = ns, HocVienId = hv,
                        BiKhoa = !Convert.ToBoolean(r["TrangThai"]), DaXoa = Convert.ToBoolean(r["IsDeleted"]), DoiMatKhauLanDau = Convert.ToBoolean(r["DoiMatKhauLanDau"]), HoSoHopLe = lienKetHopLe };
                }
            }
        }

        internal static bool TaiKhoanConHoatDong(int id, out string vaiTro)
        {
            using (var c = DatabaseConnection.TaoKetNoi()) using (var cmd = new SqlCommand(@"SELECT v.TenVaiTro FROM NguoiDung n JOIN VaiTro v ON v.VaiTroID=n.VaiTroID
WHERE n.NguoiDungID=@id AND n.TrangThai=1 AND n.IsDeleted=0 AND ISNULL(v.IsDeleted,0)=0", c))
            { cmd.Parameters.AddWithValue("@id", id); c.Open(); object value = cmd.ExecuteScalar(); vaiTro = value == null || value == DBNull.Value ? null : Convert.ToString(value); return vaiTro != null; }
        }

        internal static KetQuaPhanTrang<TaiKhoanDto> LayTaiKhoanTheoTrang(TaiKhoanBoLoc f, int trang)
        {
            const string where = @"WHERE ((@deleted=1 AND n.IsDeleted=1) OR (@deleted=0 AND n.IsDeleted=0)) AND (@role=N'' OR v.TenVaiTro=@role)
AND (@state=N'Tất cả' OR (@state=N'Hoạt động' AND n.TrangThai=1 AND n.IsDeleted=0) OR (@state=N'Đã khóa' AND n.TrangThai=0 AND n.IsDeleted=0) OR (@state=N'Đã xóa' AND n.IsDeleted=1))
AND (@q=N'' OR CHARINDEX(@q,n.TenDangNhap)>0 OR CHARINDEX(@q,COALESCE(ns.HoTen,h.HoTen,''))>0 OR CONVERT(varchar(20),n.NguoiDungID)=@q)";
            string from = @" FROM NguoiDung n JOIN VaiTro v ON v.VaiTroID=n.VaiTroID
LEFT JOIN NhanSu ns ON ns.NguoiDungID=n.NguoiDungID LEFT JOIN HocVien h ON h.NguoiDungID=n.NguoiDungID ";
            var items = new List<TaiKhoanDto>(); int count;
            using (var c = DatabaseConnection.TaoKetNoi())
            {
                c.Open(); using (var cmd = new SqlCommand("SELECT COUNT(*)" + from + where, c))
                { ThemLoc(cmd, f); count = Convert.ToInt32(cmd.ExecuteScalar()); }
                using (var cmd = new SqlCommand(@"SELECT n.NguoiDungID,n.TenDangNhap,COALESCE(ns.HoTen,h.HoTen,'') HoTen,v.TenVaiTro,
CASE WHEN n.IsDeleted=1 THEN N'Đã xóa' WHEN n.TrangThai=0 THEN N'Đã khóa' ELSE N'Hoạt động' END TrangThai,n.IsDeleted,ns.NhanSuID,h.HocVienID" + from + where +
" ORDER BY n.NguoiDungID DESC OFFSET @skip ROWS FETCH NEXT 10 ROWS ONLY", c))
                {
                    ThemLoc(cmd, f); cmd.Parameters.Add("@skip", SqlDbType.Int).Value = (Math.Max(1, trang) - 1) * 10;
                    using (var rd = cmd.ExecuteReader()) while (rd.Read()) items.Add(new TaiKhoanDto { NguoiDungID = Convert.ToInt32(rd[0]), TenDangNhap = Convert.ToString(rd[1]), HoTen = Convert.ToString(rd[2]), VaiTro = Convert.ToString(rd[3]), TrangThai = Convert.ToString(rd[4]), IsDeleted = Convert.ToBoolean(rd[5]), NhanSuID = rd[6] == DBNull.Value ? (int?)null : Convert.ToInt32(rd[6]), HocVienID = rd[7] == DBNull.Value ? (int?)null : Convert.ToInt32(rd[7]) });
                }
            }
            return new KetQuaPhanTrang<TaiKhoanDto>(items, count, trang, 10);
        }
        private static void ThemLoc(SqlCommand cmd, TaiKhoanBoLoc f)
        { string state = f == null ? "Tất cả" : f.TrangThai; cmd.Parameters.AddWithValue("@deleted", state == "Đã xóa" ? 1 : 0); cmd.Parameters.AddWithValue("@role", (object)(f == null ? null : f.VaiTro) ?? ""); cmd.Parameters.AddWithValue("@state", (object)state ?? "Tất cả"); cmd.Parameters.AddWithValue("@q", (object)(f == null ? null : f.TuKhoa) ?? ""); }

        internal static TaiKhoanDto LayChiTiet(int id)
        {
            using (var c = DatabaseConnection.TaoKetNoi()) using (var cmd = new SqlCommand(@"SELECT n.NguoiDungID,n.TenDangNhap,COALESCE(ns.HoTen,h.HoTen,''),v.TenVaiTro,
CASE WHEN n.IsDeleted=1 THEN N'Đã xóa' WHEN n.TrangThai=0 THEN N'Đã khóa' ELSE N'Hoạt động' END,n.IsDeleted,ns.NhanSuID,h.HocVienID
FROM NguoiDung n JOIN VaiTro v ON v.VaiTroID=n.VaiTroID LEFT JOIN NhanSu ns ON ns.NguoiDungID=n.NguoiDungID LEFT JOIN HocVien h ON h.NguoiDungID=n.NguoiDungID WHERE n.NguoiDungID=@id", c))
            { cmd.Parameters.AddWithValue("@id", id); c.Open(); using (var r = cmd.ExecuteReader()) { if (!r.Read()) return null; return new TaiKhoanDto { NguoiDungID = id, TenDangNhap = Convert.ToString(r[1]), HoTen = Convert.ToString(r[2]), VaiTro = Convert.ToString(r[3]), TrangThai = Convert.ToString(r[4]), IsDeleted = Convert.ToBoolean(r[5]), NhanSuID = r[6] == DBNull.Value ? (int?)null : Convert.ToInt32(r[6]), HocVienID = r[7] == DBNull.Value ? (int?)null : Convert.ToInt32(r[7]) }; } }
        }

        internal static IList<HoSoTaiKhoanDto> LayHoSo(string role, string keyword, int page, out int count)
        {
            string table = role == "Học viên" ? "HocVien" : "NhanSu", id = role == "Học viên" ? "HocVienID" : "NhanSuID";
            string predicate = role == "Học viên" ? "IsDeleted=0 AND NguoiDungID IS NULL" : "IsDeleted=0 AND NguoiDungID IS NULL AND (@role=N'Giáo viên' AND LoaiNhanSu IN(N'Giáo viên',N'Cả hai') OR @role=N'Nhân viên' AND LoaiNhanSu IN(N'Nhân viên',N'Cả hai'))";
            var rows = new List<HoSoTaiKhoanDto>(); using (var c = DatabaseConnection.TaoKetNoi())
            {
                c.Open(); using (var cmd = new SqlCommand("SELECT COUNT(*) FROM " + table + " WHERE " + predicate + " AND (@q=N'' OR CHARINDEX(@q,HoTen)>0 OR CONVERT(varchar(20)," + id + ")=@q)", c))
                { cmd.Parameters.AddWithValue("@role", role); cmd.Parameters.AddWithValue("@q", keyword ?? ""); count = Convert.ToInt32(cmd.ExecuteScalar()); }
                using (var cmd = new SqlCommand("SELECT " + id + ",HoTen FROM " + table + " WHERE " + predicate + " AND (@q=N'' OR CHARINDEX(@q,HoTen)>0 OR CONVERT(varchar(20)," + id + ")=@q) ORDER BY HoTen," + id + " OFFSET @skip ROWS FETCH NEXT 10 ROWS ONLY", c))
                { cmd.Parameters.AddWithValue("@role", role); cmd.Parameters.AddWithValue("@q", keyword ?? ""); cmd.Parameters.AddWithValue("@skip", (Math.Max(1, page) - 1) * 10); using (var r = cmd.ExecuteReader()) while (r.Read()) rows.Add(new HoSoTaiKhoanDto { HoSoID = Convert.ToInt32(r[0]), HoTen = Convert.ToString(r[1]), LoaiHoSo = role }); }
            }
            return rows;
        }

        internal static int TaoTaiKhoan(TaiKhoanTaoDto dto, string hash)
        {
            using (var c = DatabaseConnection.TaoKetNoi()) { c.Open(); using (var tx = c.BeginTransaction(IsolationLevel.Serializable)) try
            {
                KiemTraAdminHienTai(c, tx);
                using (var lockCmd = new SqlCommand("SELECT COUNT(*) FROM NguoiDung WITH(UPDLOCK,HOLDLOCK) WHERE TenDangNhap=@ten", c, tx)) { lockCmd.Parameters.AddWithValue("@ten", dto.TenDangNhap); if (Convert.ToInt32(lockCmd.ExecuteScalar()) != 0) throw new InvalidOperationException("Tên đăng nhập đã tồn tại."); }
                object roleId; using (var roleCmd = new SqlCommand("SELECT VaiTroID FROM VaiTro WITH(UPDLOCK,HOLDLOCK) WHERE TenVaiTro=@role AND ISNULL(IsDeleted,0)=0", c, tx)) { roleCmd.Parameters.AddWithValue("@role", dto.VaiTro); roleId = roleCmd.ExecuteScalar(); }
                if (roleId == null) throw new InvalidOperationException("Vai trò không tồn tại hoặc đã ngừng sử dụng.");
                KiemTraHoSo(c, tx, dto.VaiTro, dto.NhanSuID, dto.HocVienID);
                int id; using (var cmd = new SqlCommand("INSERT NguoiDung(TenDangNhap,MatKhauHash,VaiTroID,TrangThai,DoiMatKhauLanDau) OUTPUT INSERTED.NguoiDungID VALUES(@ten,@hash,@role,1,1)", c, tx))
                { cmd.Parameters.AddWithValue("@ten", dto.TenDangNhap); cmd.Parameters.AddWithValue("@hash", hash); cmd.Parameters.AddWithValue("@role", roleId); id = Convert.ToInt32(cmd.ExecuteScalar()); }
                LienKetHoSo(c, tx, dto.NhanSuID, dto.HocVienID, id); tx.Commit(); return id;
            } catch { tx.Rollback(); throw; } }
        }
        private static void KiemTraHoSo(SqlConnection c, SqlTransaction tx, string role, int? ns, int? hv)
        {
            if (role == "Admin") { if (ns.HasValue || hv.HasValue) throw new InvalidOperationException("Admin không gắn hồ sơ nhân sự hoặc học viên."); return; }
            if (role == "Học viên") { if (!hv.HasValue || ns.HasValue) throw new InvalidOperationException("Vai trò Học viên cần chọn đúng một hồ sơ học viên."); using (var cmd = new SqlCommand("SELECT COUNT(*) FROM HocVien WITH(UPDLOCK,HOLDLOCK) WHERE HocVienID=@id AND NguoiDungID IS NULL AND IsDeleted=0", c, tx)) { cmd.Parameters.AddWithValue("@id", hv); if (Convert.ToInt32(cmd.ExecuteScalar()) != 1) throw new InvalidOperationException("Hồ sơ học viên đã được cấp tài khoản hoặc không còn hoạt động."); } return; }
            if (!ns.HasValue || hv.HasValue || (role != "Nhân viên" && role != "Giáo viên")) throw new InvalidOperationException("Vai trò nhân sự cần chọn đúng một hồ sơ nhân sự.");
            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM NhanSu WITH(UPDLOCK,HOLDLOCK) WHERE NhanSuID=@id AND NguoiDungID IS NULL AND IsDeleted=0 AND ((@role=N'Giáo viên' AND LoaiNhanSu IN(N'Giáo viên',N'Cả hai')) OR (@role=N'Nhân viên' AND LoaiNhanSu IN(N'Nhân viên',N'Cả hai'))) ", c, tx)) { cmd.Parameters.AddWithValue("@id", ns); cmd.Parameters.AddWithValue("@role", role); if (Convert.ToInt32(cmd.ExecuteScalar()) != 1) throw new InvalidOperationException("Hồ sơ nhân sự không phù hợp hoặc đã được cấp tài khoản."); }
        }
        private static void LienKetHoSo(SqlConnection c, SqlTransaction tx, int? ns, int? hv, int id)
        {
            string sql = ns.HasValue ? "UPDATE NhanSu SET NguoiDungID=@user WHERE NhanSuID=@profile AND NguoiDungID IS NULL AND IsDeleted=0" : hv.HasValue ? "UPDATE HocVien SET NguoiDungID=@user WHERE HocVienID=@profile AND NguoiDungID IS NULL AND IsDeleted=0" : null;
            if (sql == null) return; using (var cmd = new SqlCommand(sql, c, tx)) { cmd.Parameters.AddWithValue("@user", id); cmd.Parameters.AddWithValue("@profile", ns ?? hv); if (cmd.ExecuteNonQuery() != 1) throw new InvalidOperationException("Hồ sơ vừa được một thao tác khác liên kết. Hãy tải lại danh sách."); }
        }

        internal static void SuaTaiKhoan(TaiKhoanSuaDto dto)
        {
            using (var c = DatabaseConnection.TaoKetNoi()) { c.Open(); using (var tx = c.BeginTransaction(IsolationLevel.Serializable)) try
            {
                KiemTraAdminHienTai(c, tx);
                if (dto.NguoiDungID == SessionContext.NguoiDungHienTai.NguoiDungID && dto.VaiTro != "Admin") throw new InvalidOperationException("Không được tự tước vai trò quản trị.");
                string currentRole; int? ns, hv;
                using (var cmd = new SqlCommand("SELECT v.TenVaiTro,ns.NhanSuID,h.HocVienID,ns.LoaiNhanSu FROM NguoiDung n WITH(UPDLOCK,HOLDLOCK) JOIN VaiTro v ON v.VaiTroID=n.VaiTroID LEFT JOIN NhanSu ns ON ns.NguoiDungID=n.NguoiDungID AND ns.IsDeleted=0 LEFT JOIN HocVien h ON h.NguoiDungID=n.NguoiDungID AND h.IsDeleted=0 WHERE n.NguoiDungID=@id AND n.IsDeleted=0", c, tx))
                { cmd.Parameters.AddWithValue("@id", dto.NguoiDungID); using (var r = cmd.ExecuteReader()) { if (!r.Read()) throw new InvalidOperationException("Không tìm thấy tài khoản."); currentRole = Convert.ToString(r[0]); ns = r[1] == DBNull.Value ? (int?)null : Convert.ToInt32(r[1]); hv = r[2] == DBNull.Value ? (int?)null : Convert.ToInt32(r[2]); string loai = r[3] == DBNull.Value ? null : Convert.ToString(r[3]); bool valid = dto.VaiTro == "Admin" ? !ns.HasValue && !hv.HasValue : dto.VaiTro == "Học viên" ? hv.HasValue && !ns.HasValue : dto.VaiTro == "Giáo viên" ? ns.HasValue && !hv.HasValue && (loai == "Giáo viên" || loai == "Cả hai") : dto.VaiTro == "Nhân viên" && ns.HasValue && !hv.HasValue && (loai == "Nhân viên" || loai == "Cả hai"); if (!valid) throw new InvalidOperationException("Vai trò mới không phù hợp với hồ sơ đang liên kết."); } }
                if (currentRole == "Admin" && dto.VaiTro != "Admin") KiemTraAdminCuoi(c, tx, dto.NguoiDungID);
                using (var cmd = new SqlCommand("UPDATE NguoiDung SET TenDangNhap=@name,VaiTroID=(SELECT VaiTroID FROM VaiTro WHERE TenVaiTro=@role AND ISNULL(IsDeleted,0)=0),UpdatedAt=GETDATE() WHERE NguoiDungID=@id AND IsDeleted=0 AND EXISTS(SELECT 1 FROM VaiTro WHERE TenVaiTro=@role AND ISNULL(IsDeleted,0)=0)", c, tx))
                { cmd.Parameters.AddWithValue("@name", dto.TenDangNhap); cmd.Parameters.AddWithValue("@role", dto.VaiTro); cmd.Parameters.AddWithValue("@id", dto.NguoiDungID); if (cmd.ExecuteNonQuery() != 1) throw new InvalidOperationException("Không tìm thấy tài khoản hoặc vai trò."); }
                tx.Commit();
            } catch { tx.Rollback(); throw; } }
        }

        internal static void DoiTrangThai(int id, bool biKhoa, int adminId)
        {
            using (var c = DatabaseConnection.TaoKetNoi()) { c.Open(); using (var tx = c.BeginTransaction(IsolationLevel.Serializable)) try
            {
                KiemTraAdminHienTai(c, tx);
                string role; bool deleted; using (var cmd = new SqlCommand("SELECT v.TenVaiTro,n.IsDeleted FROM NguoiDung n WITH(UPDLOCK,HOLDLOCK) JOIN VaiTro v ON v.VaiTroID=n.VaiTroID WHERE n.NguoiDungID=@id", c, tx)) { cmd.Parameters.AddWithValue("@id", id); using (var r = cmd.ExecuteReader()) { if (!r.Read()) throw new InvalidOperationException("Không tìm thấy tài khoản."); role = Convert.ToString(r[0]); deleted = Convert.ToBoolean(r[1]); } }
                if (deleted) throw new InvalidOperationException("Tài khoản đã xóa mềm."); if (id == adminId && biKhoa) throw new InvalidOperationException("Không thể tự khóa tài khoản.");
                if (role == "Admin" && biKhoa) KiemTraAdminCuoi(c, tx, id);
                using (var cmd = new SqlCommand("UPDATE NguoiDung SET TrangThai=@active,UpdatedAt=GETDATE() WHERE NguoiDungID=@id AND IsDeleted=0", c, tx)) { cmd.Parameters.AddWithValue("@active", !biKhoa); cmd.Parameters.AddWithValue("@id", id); cmd.ExecuteNonQuery(); }
                tx.Commit();
            } catch { tx.Rollback(); throw; } }
        }
        internal static void XoaMem(int id, int adminId)
        {
            using (var c = DatabaseConnection.TaoKetNoi()) { c.Open(); using (var tx = c.BeginTransaction(IsolationLevel.Serializable)) try
            {
                KiemTraAdminHienTai(c, tx);
                if (id == adminId) throw new InvalidOperationException("Không thể tự xóa tài khoản."); string role;
                using (var cmd = new SqlCommand("SELECT v.TenVaiTro FROM NguoiDung n WITH(UPDLOCK,HOLDLOCK) JOIN VaiTro v ON v.VaiTroID=n.VaiTroID WHERE n.NguoiDungID=@id AND n.IsDeleted=0", c, tx)) { cmd.Parameters.AddWithValue("@id", id); role = Convert.ToString(cmd.ExecuteScalar()); }
                if (role == null) throw new InvalidOperationException("Tài khoản không tồn tại hoặc đã xóa."); if (role == "Admin") KiemTraAdminCuoi(c, tx, id);
                using (var cmd = new SqlCommand("UPDATE NguoiDung SET IsDeleted=1,DeletedAt=GETDATE(),UpdatedAt=GETDATE(),TrangThai=0 WHERE NguoiDungID=@id AND IsDeleted=0", c, tx)) { cmd.Parameters.AddWithValue("@id", id); cmd.ExecuteNonQuery(); }
                tx.Commit();
            } catch { tx.Rollback(); throw; } }
        }
        private static void KiemTraAdminCuoi(SqlConnection c, SqlTransaction tx, int id)
        { using (var cmd = new SqlCommand("SELECT COUNT(*) FROM NguoiDung n WITH(UPDLOCK,HOLDLOCK) JOIN VaiTro v ON v.VaiTroID=n.VaiTroID WHERE n.TrangThai=1 AND n.IsDeleted=0 AND v.TenVaiTro=N'Admin' AND n.NguoiDungID<>@id", c, tx)) { cmd.Parameters.AddWithValue("@id", id); if (Convert.ToInt32(cmd.ExecuteScalar()) == 0) throw new InvalidOperationException("Không thể vô hiệu hóa quản trị viên hoạt động cuối cùng."); } }
        private static void KiemTraAdminHienTai(SqlConnection c, SqlTransaction tx)
        {
            var session = SessionContext.NguoiDungHienTai; if (session == null) throw new UnauthorizedAccessException("Phiên đã hết hạn.");
            using (var cmd = new SqlCommand(@"SELECT COUNT(*) FROM NguoiDung n WITH(UPDLOCK,HOLDLOCK) JOIN VaiTro v ON v.VaiTroID=n.VaiTroID
WHERE n.NguoiDungID=@id AND n.TrangThai=1 AND n.IsDeleted=0 AND ISNULL(v.IsDeleted,0)=0 AND v.TenVaiTro=N'Admin'", c, tx))
            { cmd.Parameters.AddWithValue("@id", session.NguoiDungID); if (Convert.ToInt32(cmd.ExecuteScalar()) != 1) throw new UnauthorizedAccessException("Phiên quản trị không còn hoạt động."); }
        }

        internal static void CapNhatMatKhau(int id, string hash)
        { using (var c = DatabaseConnection.TaoKetNoi()) using (var cmd = new SqlCommand("UPDATE NguoiDung SET MatKhauHash=@hash,DoiMatKhauLanDau=0,UpdatedAt=GETDATE() WHERE NguoiDungID=@id AND TrangThai=1 AND IsDeleted=0", c)) { cmd.Parameters.AddWithValue("@hash", hash); cmd.Parameters.AddWithValue("@id", id); c.Open(); if (cmd.ExecuteNonQuery() != 1) throw new InvalidOperationException("Tài khoản không còn hoạt động. Hãy đăng nhập lại."); } }
    }
}
