using System;
using System.Collections.Generic;

namespace BTL_LTTQ_QLHTTTNN.Services.Models
{
    public sealed class ThongKeBoLoc
    {
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public int? CoSoID { get; set; }
    }
    public sealed class ThongKeTongQuanDto
    {
        public int TongHocVien { get; set; }
        public int TongGiaoVien { get; set; }
        public int TongLopDangHoc { get; set; }
        public int DangKyTrongThang { get; set; }
        public decimal ThucThuTrongThang { get; set; }
    }
    public sealed class NhomThongKeDto
    {
        public string Nhan { get; set; }
        public int SoLuong { get; set; }
        public decimal SoTien { get; set; }
    }
    public sealed class TinhHinhHoaDonDto
    {
        public int HoaDonID { get; set; }
        public DateTime NgayLap { get; set; }
        public string HocVien { get; set; }
        public string TenLop { get; set; }
        public string CoSo { get; set; }
        public decimal TongPhaiTra { get; set; }
        public decimal DaThanhToan { get; set; }
        public decimal ConPhaiThu { get; set; }
        public bool ThuVuot { get; set; }
    }
    public sealed class ChiTietThanhToanDto
    {
        public int ThanhToanID { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public int HoaDonID { get; set; }
        public string HocVien { get; set; }
        public decimal SoTien { get; set; }
    }
    public sealed class ChiTietDangKyDto
    {
        public int DangKyID { get; set; }
        public DateTime NgayDangKy { get; set; }
        public string HocVien { get; set; }
        public string LopHoc { get; set; }
        public string TrangThai { get; set; }
    }

    public sealed class TongHopThongKeDto
    {
        public int TongSoLuong { get; set; }
        public int TongHocVienKhacNhau { get; set; }
        public decimal TongPhaiTra { get; set; }
        public decimal TongDaThanhToanCuoiKy { get; set; }
        public decimal TongConPhaiThu { get; set; }
        public decimal TongThucThuTrongKy { get; set; }
    }
}
