using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN.Data
{
    internal static class ThongKeData
    {
        private static SqlParameter P(string name, object value) { return new SqlParameter(name, value ?? DBNull.Value); }
        private static DateTime DenKeTiep(ThongKeBoLoc f) { return f.DenNgay.Date.AddDays(1); }
        private static string CoSoWhere(string alias) { return "(@coSo IS NULL OR " + alias + ".CoSoID=@coSo)"; }

        internal static ThongKeTongQuanDto LayThongKeTongQuan(DateTime thang)
        {
            DateTime tu = new DateTime(thang.Year, thang.Month, 1), den = tu.AddMonths(1);
            const string sql = @"SELECT
(SELECT COUNT(*) FROM HocVien WHERE IsDeleted=0) TongHocVien,
(SELECT COUNT(*) FROM NhanSu WHERE IsDeleted=0 AND LoaiNhanSu IN(N'Giáo viên',N'Cả hai')) TongGiaoVien,
(SELECT COUNT(*) FROM LopHoc WHERE IsDeleted=0 AND TrangThai=N'Đang học') TongLopDangHoc,
(SELECT COUNT(*) FROM DangKy WHERE IsDeleted=0 AND NgayDangKy>=@tu AND NgayDangKy<@den) DangKyTrongThang,
(SELECT ISNULL(SUM(t.SoTien),0) FROM ThanhToan t JOIN HoaDon h ON h.HoaDonID=t.HoaDonID AND h.IsDeleted=0 WHERE t.IsDeleted=0 AND t.NgayThanhToan>=@tu AND t.NgayThanhToan<@den) ThucThuTrongThang";
            using (var c = DatabaseConnection.TaoKetNoi()) using (var cmd = new SqlCommand(sql, c))
            { cmd.Parameters.AddWithValue("@tu", tu); cmd.Parameters.AddWithValue("@den", den); c.Open(); using (var r = cmd.ExecuteReader()) { r.Read(); return new ThongKeTongQuanDto { TongHocVien = Convert.ToInt32(r[0]), TongGiaoVien = Convert.ToInt32(r[1]), TongLopDangHoc = Convert.ToInt32(r[2]), DangKyTrongThang = Convert.ToInt32(r[3]), ThucThuTrongThang = Convert.ToDecimal(r[4]) }; } }
        }

        internal static IList<NhomThongKeDto> LayThucThuTheoThang(ThongKeBoLoc f)
        {
            string sql = @"SELECT YEAR(t.NgayThanhToan) Nam,MONTH(t.NgayThanhToan) Thang,SUM(t.SoTien) Tong
FROM ThanhToan t JOIN HoaDon h ON h.HoaDonID=t.HoaDonID AND h.IsDeleted=0
LEFT JOIN DangKy d ON d.DangKyID=h.DangKyID AND d.IsDeleted=0
LEFT JOIN LopHoc l ON l.LopHocID=d.LopHocID AND l.IsDeleted=0
WHERE t.IsDeleted=0 AND t.NgayThanhToan>=@tu AND t.NgayThanhToan<@den AND " + CoSoWhere("l") + @"
GROUP BY YEAR(t.NgayThanhToan),MONTH(t.NgayThanhToan) ORDER BY Nam,Thang";
            var rows = new List<NhomThongKeDto>(); using (var c = DatabaseConnection.TaoKetNoi()) using (var cmd = new SqlCommand(sql, c))
            { ThemKhoang(cmd, f); c.Open(); using (var r = cmd.ExecuteReader()) while (r.Read()) rows.Add(new NhomThongKeDto { Nhan = new DateTime(Convert.ToInt32(r[0]), Convert.ToInt32(r[1]), 1).ToString("MM/yyyy"), SoTien = Convert.ToDecimal(r[2]) }); } return rows;
        }
        internal static IList<NhomThongKeDto> LayDangKyTheoThang(ThongKeBoLoc f)
        {
            string sql = @"SELECT YEAR(d.NgayDangKy) Nam,MONTH(d.NgayDangKy) Thang,COUNT(*) SoLuong
FROM DangKy d JOIN LopHoc l ON l.LopHocID=d.LopHocID AND l.IsDeleted=0
WHERE d.IsDeleted=0 AND d.NgayDangKy>=@tu AND d.NgayDangKy<@den AND " + CoSoWhere("l") + @"
GROUP BY YEAR(d.NgayDangKy),MONTH(d.NgayDangKy) ORDER BY Nam,Thang";
            var rows = new List<NhomThongKeDto>(); using (var c = DatabaseConnection.TaoKetNoi()) using (var cmd = new SqlCommand(sql, c))
            { ThemKhoang(cmd, f); c.Open(); using (var r = cmd.ExecuteReader()) while (r.Read()) rows.Add(new NhomThongKeDto { Nhan = new DateTime(Convert.ToInt32(r[0]), Convert.ToInt32(r[1]), 1).ToString("MM/yyyy"), SoLuong = Convert.ToInt32(r[2]) }); } return rows;
        }
        internal static IList<NhomThongKeDto> LaySoLopTheoTrangThai(ThongKeBoLoc f)
        {
            var rows = new List<NhomThongKeDto>(); string sql = "SELECT l.TrangThai,COUNT(*) FROM LopHoc l WHERE l.IsDeleted=0 AND " + CoSoWhere("l") + " GROUP BY l.TrangThai ORDER BY l.TrangThai";
            using (var c = DatabaseConnection.TaoKetNoi()) using (var cmd = new SqlCommand(sql, c)) { cmd.Parameters.AddWithValue("@coSo", (object)f.CoSoID ?? DBNull.Value); c.Open(); using (var r = cmd.ExecuteReader()) while (r.Read()) rows.Add(new NhomThongKeDto { Nhan = Convert.ToString(r[0]), SoLuong = Convert.ToInt32(r[1]) }); } return rows;
        }

        internal static KetQuaPhanTrang<TinhHinhHoaDonDto> LayTinhHinhThuTheoTrang(ThongKeBoLoc f, int page)
        {
            const string from = @" FROM HoaDon h LEFT JOIN HocVien hv ON hv.HocVienID=h.HocVienID
LEFT JOIN DangKy d ON d.DangKyID=h.DangKyID LEFT JOIN LopHoc l ON l.LopHocID=d.LopHocID LEFT JOIN CoSo cs ON cs.CoSoID=l.CoSoID
OUTER APPLY(SELECT SUM(t.SoTien) DaThanhToan FROM ThanhToan t WHERE t.HoaDonID=h.HoaDonID AND t.IsDeleted=0 AND t.NgayThanhToan<@den) p ";
            const string where = " WHERE h.IsDeleted=0 AND h.NgayLap>=@tu AND h.NgayLap<@den AND (@coSo IS NULL OR l.CoSoID=@coSo) "; int count; var rows = new List<TinhHinhHoaDonDto>();
            using (var c = DatabaseConnection.TaoKetNoi()) { c.Open(); using (var cmd = new SqlCommand("SELECT COUNT(*)" + from + where, c)) { ThemKhoang(cmd, f); count = Convert.ToInt32(cmd.ExecuteScalar()); }
                using (var cmd = new SqlCommand(@"SELECT h.HoaDonID,h.NgayLap,ISNULL(hv.HoTen,N'(Hồ sơ đã xóa)'),ISNULL(l.TenLop,N'(Không liên kết lớp)'),ISNULL(cs.TenCoSo,N'Chưa xác định'),h.TongPhaiTra,ISNULL(p.DaThanhToan,0),h.TongPhaiTra-ISNULL(p.DaThanhToan,0)" + from + where + " ORDER BY h.NgayLap DESC,h.HoaDonID DESC OFFSET @skip ROWS FETCH NEXT 10 ROWS ONLY", c))
                { ThemKhoang(cmd, f); cmd.Parameters.AddWithValue("@skip", (Math.Max(1, page) - 1) * 10); using (var r = cmd.ExecuteReader()) while (r.Read()) rows.Add(new TinhHinhHoaDonDto { HoaDonID = Convert.ToInt32(r[0]), NgayLap = Convert.ToDateTime(r[1]), HocVien = Convert.ToString(r[2]), TenLop = Convert.ToString(r[3]), CoSo = Convert.ToString(r[4]), TongPhaiTra = Convert.ToDecimal(r[5]), DaThanhToan = Convert.ToDecimal(r[6]), ConPhaiThu = Convert.ToDecimal(r[7]), ThuVuot = Convert.ToDecimal(r[7]) < 0 }); }
            } return new KetQuaPhanTrang<TinhHinhHoaDonDto>(rows, count, page, 10);
        }
        internal static KetQuaPhanTrang<ChiTietThanhToanDto> LayChiTietThanhToanTheoTrang(ThongKeBoLoc f, int page)
        {
            const string from = " FROM ThanhToan t JOIN HoaDon h ON h.HoaDonID=t.HoaDonID LEFT JOIN HocVien hv ON hv.HocVienID=h.HocVienID LEFT JOIN DangKy d ON d.DangKyID=h.DangKyID LEFT JOIN LopHoc l ON l.LopHocID=d.LopHocID ";
            const string where = " WHERE t.IsDeleted=0 AND h.IsDeleted=0 AND t.NgayThanhToan>=@tu AND t.NgayThanhToan<@den AND (@coSo IS NULL OR l.CoSoID=@coSo) "; int count; var rows = new List<ChiTietThanhToanDto>();
            using (var c = DatabaseConnection.TaoKetNoi()) { c.Open(); using (var cmd = new SqlCommand("SELECT COUNT(*)" + from + where, c)) { ThemKhoang(cmd, f); count = Convert.ToInt32(cmd.ExecuteScalar()); }
                using (var cmd = new SqlCommand("SELECT t.ThanhToanID,t.NgayThanhToan,t.HoaDonID,ISNULL(hv.HoTen,N'(Hồ sơ đã xóa)'),t.SoTien" + from + where + " ORDER BY t.NgayThanhToan DESC,t.ThanhToanID DESC OFFSET @skip ROWS FETCH NEXT 10 ROWS ONLY", c))
                { ThemKhoang(cmd, f); cmd.Parameters.AddWithValue("@skip", (Math.Max(1, page) - 1) * 10); using (var r = cmd.ExecuteReader()) while (r.Read()) rows.Add(new ChiTietThanhToanDto { ThanhToanID = Convert.ToInt32(r[0]), NgayThanhToan = Convert.ToDateTime(r[1]), HoaDonID = Convert.ToInt32(r[2]), HocVien = Convert.ToString(r[3]), SoTien = Convert.ToDecimal(r[4]) }); }
            } return new KetQuaPhanTrang<ChiTietThanhToanDto>(rows, count, page, 10);
        }
        internal static KetQuaPhanTrang<ChiTietDangKyDto> LayChiTietDangKyTheoTrang(ThongKeBoLoc f, int page)
        {
            const string from = " FROM DangKy d JOIN HocVien hv ON hv.HocVienID=d.HocVienID JOIN LopHoc l ON l.LopHocID=d.LopHocID ";
            const string where = " WHERE d.IsDeleted=0 AND hv.IsDeleted=0 AND l.IsDeleted=0 AND d.NgayDangKy>=@tu AND d.NgayDangKy<@den AND (@coSo IS NULL OR l.CoSoID=@coSo) "; int count; var rows = new List<ChiTietDangKyDto>();
            using (var c = DatabaseConnection.TaoKetNoi()) { c.Open(); using (var cmd = new SqlCommand("SELECT COUNT(*)" + from + where, c)) { ThemKhoang(cmd, f); count = Convert.ToInt32(cmd.ExecuteScalar()); }
                using (var cmd = new SqlCommand("SELECT d.DangKyID,d.NgayDangKy,hv.HoTen,l.TenLop,d.TrangThai" + from + where + " ORDER BY d.NgayDangKy DESC,d.DangKyID DESC OFFSET @skip ROWS FETCH NEXT 10 ROWS ONLY", c))
                { ThemKhoang(cmd, f); cmd.Parameters.AddWithValue("@skip", (Math.Max(1, page) - 1) * 10); using (var r = cmd.ExecuteReader()) while (r.Read()) rows.Add(new ChiTietDangKyDto { DangKyID = Convert.ToInt32(r[0]), NgayDangKy = Convert.ToDateTime(r[1]), HocVien = Convert.ToString(r[2]), LopHoc = Convert.ToString(r[3]), TrangThai = Convert.ToString(r[4]) }); }
            } return new KetQuaPhanTrang<ChiTietDangKyDto>(rows, count, page, 10);
        }
        internal static IList<string> LayDanhSachCoSo()
        { var names = new List<string>(); using (var c = DatabaseConnection.TaoKetNoi()) using (var cmd = new SqlCommand("SELECT TenCoSo FROM CoSo WHERE IsDeleted=0 AND TrangThai=1 ORDER BY TenCoSo", c)) { c.Open(); using (var r = cmd.ExecuteReader()) while (r.Read()) names.Add(Convert.ToString(r[0])); } return names; }
        internal static IList<KeyValuePair<int, string>> LayCoSo()
        { var rows = new List<KeyValuePair<int, string>>(); using (var c = DatabaseConnection.TaoKetNoi()) using (var cmd = new SqlCommand("SELECT CoSoID,TenCoSo FROM CoSo WHERE IsDeleted=0 AND TrangThai=1 ORDER BY TenCoSo", c)) { c.Open(); using (var r = cmd.ExecuteReader()) while (r.Read()) rows.Add(new KeyValuePair<int, string>(Convert.ToInt32(r[0]), Convert.ToString(r[1]))); } return rows; }
        private static void ThemKhoang(SqlCommand cmd, ThongKeBoLoc f) { cmd.Parameters.AddWithValue("@tu", f.TuNgay.Date); cmd.Parameters.AddWithValue("@den", DenKeTiep(f)); cmd.Parameters.AddWithValue("@coSo", (object)f.CoSoID ?? DBNull.Value); }
    }
}
