using System;
using System.Collections.Generic;
using BTL_LTTQ_QLHTTTNN.Data;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN.Services
{
    public static class TaiKhoanService
    {
        public static NguoiDungPhien DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrEmpty(matKhau)) throw new InvalidOperationException("Vui lòng nhập tên đăng nhập và mật khẩu.");
            var row = TaiKhoanData.LayTheoTen(tenDangNhap.Trim());
            if (row == null || !MatKhauService.KiemTraMatKhau(matKhau, row.Hash)) throw new UnauthorizedAccessException("Tên đăng nhập hoặc mật khẩu không đúng.");
            if (row.BiKhoa || row.DaXoa || !row.HoSoHopLe) throw new UnauthorizedAccessException("Tài khoản không hoạt động hoặc hồ sơ liên kết không hợp lệ. Vui lòng liên hệ quản trị viên.");
            var session = new NguoiDungPhien(row.Id, row.Ten, row.VaiTro, row.HoTen, row.NhanSuId, row.HocVienId, row.DoiMatKhauLanDau);
            SessionContext.ThietLapPhien(session); return session;
        }

        public static KetQuaPhanTrang<TaiKhoanDto> LayTaiKhoanTheoTrang(TaiKhoanBoLoc boLoc, int soTrang)
        { PhanQuyenService.YeuCauQuyen("QuanLyTaiKhoan"); return TaiKhoanData.LayTaiKhoanTheoTrang(boLoc ?? new TaiKhoanBoLoc(), soTrang); }
        public static TaiKhoanDto LayChiTietTaiKhoan(int maTaiKhoan)
        { PhanQuyenService.YeuCauQuyen("QuanLyTaiKhoan"); return TaiKhoanData.LayChiTiet(maTaiKhoan); }
        public static IList<HoSoTaiKhoanDto> LayHoSoChuaCoTaiKhoanTheoTrang(string loaiHoSo, string tuKhoa, int soTrang, out int tongBanGhi)
        { PhanQuyenService.YeuCauQuyen("TaoTaiKhoan"); return TaiKhoanData.LayHoSo(loaiHoSo, tuKhoa, soTrang, out tongBanGhi); }
        public static int TaoTaiKhoan(TaiKhoanTaoDto duLieu)
        {
            PhanQuyenService.YeuCauQuyen("TaoTaiKhoan"); if (duLieu == null) throw new ArgumentNullException("duLieu");
            if (string.IsNullOrWhiteSpace(duLieu.TenDangNhap) || string.IsNullOrEmpty(duLieu.MatKhau)) throw new InvalidOperationException("Tên đăng nhập và mật khẩu không được để trống.");
            if (duLieu.TenDangNhap.Trim().Length > 50 || duLieu.MatKhau.Length > 128) throw new InvalidOperationException("Tên đăng nhập hoặc mật khẩu vượt quá độ dài cho phép.");
            if (duLieu.MatKhau.Length < 8) throw new InvalidOperationException("Mật khẩu khởi tạo cần ít nhất 8 ký tự.");
            duLieu.TenDangNhap = duLieu.TenDangNhap.Trim(); return TaiKhoanData.TaoTaiKhoan(duLieu, MatKhauService.BamMatKhau(duLieu.MatKhau));
        }
        public static void SuaTaiKhoan(TaiKhoanSuaDto duLieu)
        { PhanQuyenService.YeuCauQuyen("SuaTaiKhoan"); if (duLieu == null || string.IsNullOrWhiteSpace(duLieu.TenDangNhap) || duLieu.TenDangNhap.Trim().Length > 50) throw new InvalidOperationException("Thông tin tài khoản chưa hợp lệ."); duLieu.TenDangNhap = duLieu.TenDangNhap.Trim(); TaiKhoanData.SuaTaiKhoan(duLieu); }
        public static void DoiTrangThaiTaiKhoan(int maTaiKhoan, bool biKhoa)
        { PhanQuyenService.YeuCauQuyen("KhoaTaiKhoan"); TaiKhoanData.DoiTrangThai(maTaiKhoan, biKhoa, SessionContext.NguoiDungHienTai.NguoiDungID); }
        public static void XoaMemTaiKhoan(int maTaiKhoan)
        { PhanQuyenService.YeuCauQuyen("XoaTaiKhoan"); TaiKhoanData.XoaMem(maTaiKhoan, SessionContext.NguoiDungHienTai.NguoiDungID); }
        public static void DoiMatKhau(string matKhauCu, string matKhauMoi)
        {
            PhanQuyenService.YeuCauQuyen("DoiMatKhau"); if (string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi)) throw new InvalidOperationException("Vui lòng nhập đầy đủ mật khẩu.");
            if (matKhauMoi.Length < 8 || matKhauMoi.Length > 128) throw new InvalidOperationException("Mật khẩu mới cần từ 8 đến 128 ký tự.");
            var session = SessionContext.NguoiDungHienTai; var row = TaiKhoanData.LayTheoTen(session.TenDangNhap);
            if (row == null || row.Id != session.NguoiDungID || row.BiKhoa || row.DaXoa || !row.HoSoHopLe) throw new UnauthorizedAccessException("Phiên đã hết hạn hoặc tài khoản không còn hoạt động.");
            if (!MatKhauService.KiemTraMatKhau(matKhauCu, row.Hash)) throw new UnauthorizedAccessException("Mật khẩu hiện tại không đúng.");
            if (string.Equals(matKhauCu, matKhauMoi, StringComparison.Ordinal)) throw new InvalidOperationException("Mật khẩu mới phải khác mật khẩu hiện tại.");
            TaiKhoanData.CapNhatMatKhau(session.NguoiDungID, MatKhauService.BamMatKhau(matKhauMoi)); SessionContext.DanhDauDaDoiMatKhau();
        }
        public static void DangXuat() { SessionContext.XoaPhien(); }
    }
}
