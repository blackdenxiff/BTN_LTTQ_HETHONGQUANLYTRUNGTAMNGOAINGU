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
            string role; if (!TaiKhoanData.TaiKhoanConHoatDong(session.NguoiDungID, out role)) return false;
            switch (maChucNang)
            {
                case "DoiMatKhau": return true;
                case "QuanLyTaiKhoan": case "TaoTaiKhoan": case "SuaTaiKhoan": case "KhoaTaiKhoan": case "XoaTaiKhoan": case "DatLaiMatKhau": case "XemThongKe": return role == "Admin";
                default: return false;
            }
        }
        internal static void YeuCauQuyen(string maChucNang)
        { if (!KiemTraQuyen(maChucNang)) throw new UnauthorizedAccessException("Bạn không có quyền thực hiện chức năng này hoặc phiên đã hết hạn."); }
    }
}
