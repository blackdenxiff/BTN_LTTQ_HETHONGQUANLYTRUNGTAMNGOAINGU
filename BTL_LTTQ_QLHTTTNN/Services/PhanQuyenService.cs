using System;
using BTL_LTTQ_QLHTTTNN.Data;

namespace BTL_LTTQ_QLHTTTNN.Services
{
    public static class PhanQuyenService
    {
        public static bool KiemTraQuyen(string maChucNang)
        {
            var session = SessionContext.NguoiDungHienTai;
            if (session == null || string.IsNullOrWhiteSpace(maChucNang)) return false;
            var account = TaiKhoanData.LayTheoTen(session.TenDangNhap);
            if (account == null || account.Id != session.NguoiDungID || account.BiKhoa || account.DaXoa || !account.HoSoHopLe
                || account.VaiTro != session.VaiTro || account.HocVienId != session.HocVienID || account.NhanSuId != session.NhanSuID) return false;
            if (maChucNang != "DoiMatKhau" && (account.DoiMatKhauLanDau || session.DoiMatKhauLanDau)) return false;
            string role = account.VaiTro;
            switch (maChucNang)
            {
                case "DoiMatKhau": return true;
                case "XemHoSoCaNhan": case "XemLopCaNhan": case "XemKetQuaCaNhan":
                case "XemHocPhiCaNhan": return role == "Học viên";
                case "DangKyLopCaNhan": return role == "Admin" || role == "Nhân viên" || role == "Học viên";
                case "QuanLyHocVien": return role == "Admin" || role == "Nhân viên";
                case "QuanLyTaiKhoan": case "TaoTaiKhoan": case "SuaTaiKhoan": case "KhoaTaiKhoan": case "XoaTaiKhoan": case "DatLaiMatKhau": case "XemThongKe": return role == "Admin";
                default: return false;
            }
        }
        internal static void YeuCauQuyen(string maChucNang)
        { if (!KiemTraQuyen(maChucNang)) throw new UnauthorizedAccessException("Bạn không có quyền thực hiện chức năng này hoặc phiên đã hết hạn."); }
    }
}
