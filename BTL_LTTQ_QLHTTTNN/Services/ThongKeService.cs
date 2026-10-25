using System;
using System.Collections.Generic;
using BTL_LTTQ_QLHTTTNN.Data;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN.Services
{
    public static class ThongKeService
    {
        public static ThongKeTongQuanDto LayThongKeTongQuan(ThongKeBoLoc boLoc)
        { PhanQuyenService.YeuCauQuyen("XemThongKe"); return ThongKeData.LayThongKeTongQuan(DateTime.Today); }
        public static IList<NhomThongKeDto> LayThucThuTheoThang(ThongKeBoLoc boLoc)
        { PhanQuyenService.YeuCauQuyen("XemThongKe"); return ThongKeData.LayThucThuTheoThang(KiemTra(boLoc)); }
        public static IList<NhomThongKeDto> LayDangKyTheoThang(ThongKeBoLoc boLoc)
        { PhanQuyenService.YeuCauQuyen("XemThongKe"); return ThongKeData.LayDangKyTheoThang(KiemTra(boLoc)); }
        public static IList<NhomThongKeDto> LaySoLopTheoTrangThai(ThongKeBoLoc boLoc)
        { PhanQuyenService.YeuCauQuyen("XemThongKe"); return ThongKeData.LaySoLopTheoTrangThai(KiemTra(boLoc)); }
        public static KetQuaPhanTrang<TinhHinhHoaDonDto> LayTinhHinhThuTheoTrang(ThongKeBoLoc boLoc, int soTrang)
        { PhanQuyenService.YeuCauQuyen("XemThongKe"); return ThongKeData.LayTinhHinhThuTheoTrang(KiemTra(boLoc), soTrang); }
        public static TongHopThongKeDto LayTongHopHoaDon(ThongKeBoLoc boLoc)
        { PhanQuyenService.YeuCauQuyen("XemThongKe"); return ThongKeData.LayTongHopHoaDon(KiemTra(boLoc)); }
        public static TongHopThongKeDto LayTongHopThanhToan(ThongKeBoLoc boLoc)
        { PhanQuyenService.YeuCauQuyen("XemThongKe"); return ThongKeData.LayTongHopThanhToan(KiemTra(boLoc)); }
        public static TongHopThongKeDto LayTongHopDangKy(ThongKeBoLoc boLoc)
        { PhanQuyenService.YeuCauQuyen("XemThongKe"); return ThongKeData.LayTongHopDangKy(KiemTra(boLoc)); }
        public static KetQuaPhanTrang<ChiTietThanhToanDto> LayChiTietThanhToanTheoTrang(ThongKeBoLoc boLoc, int soTrang)
        { PhanQuyenService.YeuCauQuyen("XemThongKe"); return ThongKeData.LayChiTietThanhToanTheoTrang(KiemTra(boLoc), soTrang); }
        public static KetQuaPhanTrang<ChiTietDangKyDto> LayChiTietDangKyTheoTrang(ThongKeBoLoc boLoc, int soTrang)
        { PhanQuyenService.YeuCauQuyen("XemThongKe"); return ThongKeData.LayChiTietDangKyTheoTrang(KiemTra(boLoc), soTrang); }
        public static IList<KeyValuePair<int, string>> LayCoSo()
        { PhanQuyenService.YeuCauQuyen("XemThongKe"); return ThongKeData.LayCoSo(); }
        private static ThongKeBoLoc KiemTra(ThongKeBoLoc f)
        {
            if (f == null || f.TuNgay.Date > f.DenNgay.Date) throw new ArgumentException("Khoảng ngày không hợp lệ.");
            DateTime first = new DateTime(f.TuNgay.Year, f.TuNgay.Month, 1), last = new DateTime(f.DenNgay.Year, f.DenNgay.Month, 1);
            int months = (last.Year - first.Year) * 12 + last.Month - first.Month + 1;
            if (months > 12) throw new ArgumentException("Mỗi lần xem tối đa 12 tháng."); return f;
        }
    }
}
