using System;

namespace BTL_LTTQ_QLHTTTNN.Services.Models
{
    /// <summary>
    /// DTO chứa thông tin học phí của một hóa đơn / đăng ký học.
    /// </summary>
    public sealed class HocPhiDto
    {
        public int? HoaDonID { get; set; }
        public string MaHoaDon { get; set; }
        public int DangKyID { get; set; }
        public int HocVienID { get; set; }
        public string MaHocVien { get; set; }
        public string TenHocVien { get; set; }
        public string SoDienThoai { get; set; }
        public int LopHocID { get; set; }
        public string TenLop { get; set; }
        public string TenKhoaHoc { get; set; }
        public string TenKhoanThu { get; set; }
        public DateTime? NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public decimal GiamGia { get; set; }
        public decimal TongPhaiTra { get; set; }
        public decimal DaThanhToan { get; set; }
        public decimal ConPhaiDong { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
    }

    /// <summary>
    /// DTO chi tiết một phiếu thu (giao dịch thanh toán).
    /// </summary>
    public sealed class PhieuThuDto
    {
        public int ThanhToanID { get; set; }
        public string MaPhieuThu => "PT-" + ThanhToanID;
        public int HoaDonID { get; set; }
        public string MaHoaDon => "HD-" + HoaDonID;
        public int DangKyID { get; set; }
        public int HocVienID { get; set; }
        public string TenHocVien { get; set; }
        public string SoDienThoai { get; set; }
        public string TenLop { get; set; }
        public int NhanSuID { get; set; }
        public string TenNhanVienThu { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public decimal SoTien { get; set; }
        public string PhuongThuc { get; set; }
        public string GhiChu { get; set; }
    }

    /// <summary>
    /// DTO dữ liệu đầu vào để lập một phiếu thu mới.
    /// </summary>
    public sealed class TaoPhieuThuDto
    {
        public int DangKyID { get; set; }
        public int HocVienID { get; set; }
        public int LopHocID { get; set; }
        public decimal SoTien { get; set; }
        public string PhuongThuc { get; set; }
        public int NhanSuID { get; set; }
        public string GhiChu { get; set; }
    }

    /// <summary>
    /// DTO thông tin đăng ký học còn nợ học phí để phục vụ chọn khi lập phiếu thu.
    /// </summary>
    public sealed class DangKyChuaThuDto
    {
        public int DangKyID { get; set; }
        public int HocVienID { get; set; }
        public string TenHocVien { get; set; }
        public int LopHocID { get; set; }
        public string TenLop { get; set; }
        public string TenKhoaHoc { get; set; }
        public decimal HocPhiApDung { get; set; }
        public decimal TongPhaiTra { get; set; }
        public decimal DaThanhToan { get; set; }
        public decimal ConPhaiDong { get; set; }
        public int? HoaDonID { get; set; }
        public string HienThiCombobox => TenLop + " (" + TenKhoaHoc + ") - Còn nợ: " + ConPhaiDong.ToString("N0") + " đ";
    }

    /// <summary>
    /// DTO chứa các chỉ số tổng hợp KPI trên màn hình học phí.
    /// </summary>
    public sealed class ThongKeKPIDto
    {
        public decimal TongPhaiNop { get; set; }
        public decimal TongDaThanhToan { get; set; }
        public decimal TongConPhaiDong { get; set; }
        public int SoChuaThanhToan { get; set; }
    }

    /// <summary>
    /// Kết quả xử lý nghiệp vụ trả về cho Form.
    /// </summary>
    public sealed class KetQuaXuLy
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; }
        public int? MaKetQua { get; set; }

        public static KetQuaXuLy Ok(string thongBao = "Thao tác thành công", int? ma = null)
        {
            return new KetQuaXuLy { ThanhCong = true, ThongBao = thongBao, MaKetQua = ma };
        }

        public static KetQuaXuLy ThatBai(string thongBao)
        {
            return new KetQuaXuLy { ThanhCong = false, ThongBao = thongBao };
        }
    }
}
