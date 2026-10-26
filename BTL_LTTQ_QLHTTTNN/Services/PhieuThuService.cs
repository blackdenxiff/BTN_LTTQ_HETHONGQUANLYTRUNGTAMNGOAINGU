using System;
using System.Collections.Generic;
using BTL_LTTQ_QLHTTTNN.Data;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN.Services
{
    /// <summary>
    /// Service xử lý nghiệp vụ Lập và Quản lý Phiếu thu học phí (Thành viên 5).
    /// </summary>
    public static class PhieuThuService
    {
        /// <summary>
        /// Lập phiếu thu thanh toán học phí với các kiểm tra hợp lệ chặt chẽ.
        /// </summary>
        public static KetQuaXuLy LapPhieuThu(TaoPhieuThuDto duLieu)
        {
            if (!PhanQuyenService.KiemTraQuyen("LapPhieuThu"))
                return KetQuaXuLy.ThatBai("Chỉ nhân viên trung tâm mới được lập phiếu thu.");
            if (duLieu == null)
            {
                return KetQuaXuLy.ThatBai("Dữ liệu lập phiếu thu không được để trống.");
            }

            if (duLieu.HocVienID <= 0)
            {
                return KetQuaXuLy.ThatBai("Vui lòng chọn học viên nộp tiền.");
            }

            if (duLieu.DangKyID <= 0)
            {
                return KetQuaXuLy.ThatBai("Vui lòng chọn lớp học (đăng ký học) cần nộp tiền.");
            }

            if (duLieu.SoTien <= 0)
            {
                return KetQuaXuLy.ThatBai("Số tiền thanh toán phải lớn hơn 0 đ.");
            }

            if (string.IsNullOrWhiteSpace(duLieu.PhuongThuc))
            {
                duLieu.PhuongThuc = "Tiền mặt";
            }

            // Kiểm tra số tiền nộp so với công nợ còn lại
            var hocPhi = HocPhiData.LayHocPhiTheoDangKy(duLieu.DangKyID);
            if (hocPhi != null)
            {
                if (hocPhi.ConPhaiDong <= 0)
                {
                    return KetQuaXuLy.ThatBai("Đăng ký học này đã hoàn thành toàn bộ học phí, không cần nộp thêm.");
                }

                if (duLieu.SoTien > hocPhi.ConPhaiDong)
                {
                    return KetQuaXuLy.ThatBai(
                        $"Số tiền thanh toán ({duLieu.SoTien:N0} đ) vượt quá số tiền còn thiếu ({hocPhi.ConPhaiDong:N0} đ). Vui lòng kiểm tra lại."
                    );
                }
            }

            // Xác định nhân sự thu tiền: lấy từ phiên đăng nhập nếu có, fallback về 1 (admin quản lý)
            if (duLieu.NhanSuID <= 0)
            {
                duLieu.NhanSuID = SessionContext.NguoiDungHienTai?.NhanSuID ?? 1;
            }

            try
            {
                int thanhToanId = HocPhiData.LuuPhieuThu(duLieu);
                return KetQuaXuLy.Ok("Lập phiếu thu thành công! Mã phiếu: PT-" + thanhToanId, thanhToanId);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.ThatBai("Lỗi lưu cơ sở dữ liệu: " + ex.Message);
            }
        }

        /// <summary>
        /// Học viên tự thanh toán: chỉ cho phép khi đăng ký học thuộc về đúng học viên đang đăng nhập.
        /// </summary>
        public static KetQuaXuLy LapPhieuThuChoHocVien(TaoPhieuThuDto duLieu, int hocVienDangNhapID)
        {
            if (duLieu == null)
                return KetQuaXuLy.ThatBai("Dữ liệu lập phiếu thu không được để trống.");
            if (hocVienDangNhapID <= 0)
                return KetQuaXuLy.ThatBai("Không xác định được học viên đang đăng nhập.");

            var hocPhi = HocPhiData.LayHocPhiTheoDangKy(duLieu.DangKyID);
            if (hocPhi == null || hocPhi.HocVienID != hocVienDangNhapID)
                return KetQuaXuLy.ThatBai("Bạn chỉ được thanh toán học phí cho chính mình.");

            duLieu.HocVienID = hocVienDangNhapID;   // ghi đè, không tin dữ liệu từ giao diện
            return LapPhieuThu(duLieu);
        }

        /// <summary>
        /// Lấy danh sách phiếu thu theo Đăng ký học.
        /// </summary>
        public static List<PhieuThuDto> LayPhieuThuTheoDangKy(int maDangKy)
        {
            if (maDangKy <= 0) return new List<PhieuThuDto>();
            return HocPhiData.LayPhieuThuTheoDangKy(maDangKy);
        }

        /// <summary>
        /// Lấy danh sách phiếu thu trong khoảng thời gian.
        /// </summary>
        public static List<PhieuThuDto> LayPhieuThuTheoThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay > denNgay)
            {
                var temp = tuNgay;
                tuNgay = denNgay;
                denNgay = temp;
            }
            return HocPhiData.LayPhieuThuTheoThoiGian(tuNgay, denNgay);
        }

        /// <summary>
        /// Lấy danh sách các lần thanh toán theo Hóa đơn.
        /// </summary>
        public static List<PhieuThuDto> LayPhieuThuTheoHoaDon(int hoaDonId)
        {
            if (hoaDonId <= 0) return new List<PhieuThuDto>();
            return HocPhiData.LayPhieuThuTheoHoaDon(hoaDonId);
        }
    }
}