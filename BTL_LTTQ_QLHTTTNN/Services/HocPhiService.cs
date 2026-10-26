using System;
using System.Collections.Generic;
using BTL_LTTQ_QLHTTTNN.Data;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN.Services
{
    /// <summary>
    /// Service xử lý nghiệp vụ Học phí và Hóa đơn (Thành viên 5).
    /// </summary>
    public static class HocPhiService
    {
        /// <summary>
        /// Lấy thông tin học phí của một lần đăng ký học.
        /// </summary>
        public static HocPhiDto LayHocPhiTheoDangKy(int maDangKy)
        {
            if (maDangKy <= 0) return null;
            return HocPhiData.LayHocPhiTheoDangKy(maDangKy);
        }

        /// <summary>
        /// Lấy danh sách học phí của các học viên theo lớp học.
        /// </summary>
        public static List<HocPhiDto> LayHocPhiTheoLop(int maLop)
        {
            if (maLop <= 0) return new List<HocPhiDto>();
            return HocPhiData.LayHocPhiTheoLop(maLop);
        }

        /// <summary>
        /// Lấy danh sách toàn bộ học phí có lọc theo từ khóa và trạng thái thanh toán.
        /// </summary>
        public static List<HocPhiDto> LayDanhSachHocPhi(string tuKhoa = "", string trangThai = "")
        {
            return HocPhiData.LayDanhSachHocPhi(tuKhoa, trangThai);
        }

        /// <summary>
        /// Lấy các chỉ số thống kê tổng hợp (KPI) phục vụ hiển thị trên form.
        /// </summary>
        public static ThongKeKPIDto LayThongKeKPI()
        {
            return HocPhiData.LayThongKeKPI();
        }

        /// <summary>
        /// Lấy danh sách đăng ký còn nợ học phí của học viên để chọn lập phiếu thu.
        /// </summary>
        public static List<DangKyChuaThuDto> LayDangKyChuaThuCuaHocVien(int hocVienId)
        {
            if (hocVienId <= 0) return new List<DangKyChuaThuDto>();
            return HocPhiData.LayDangKyChuaThuCuaHocVien(hocVienId);
        }
    }
}
