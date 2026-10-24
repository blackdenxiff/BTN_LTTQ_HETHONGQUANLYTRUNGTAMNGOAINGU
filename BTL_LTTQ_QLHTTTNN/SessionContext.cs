using System;

namespace BTL_LTTQ_QLHTTTNN
{
    /// <summary>
    /// Lưu trữ thông tin phiên đăng nhập của người dùng / giáo viên trong hệ thống
    /// </summary>
    public static class SessionContext
    {
        // ID giáo viên / nhân sự hiện tại (Mặc định mock = 2 tương ứng với giáo viên mẫu trong CSDL)
        public static int NhanSuID { get; set; } = 2;

        // ID tài khoản người dùng
        public static int NguoiDungID { get; set; } = 2;

        // Tên đăng nhập
        public static string TenDangNhap { get; set; } = "gv_tienganh";

        // Họ tên giáo viên
        public static string HoTen { get; set; } = "Trần Thị Giảng Viên";

        // Vai trò
        public static string VaiTro { get; set; } = "Giáo viên";
    }
}
