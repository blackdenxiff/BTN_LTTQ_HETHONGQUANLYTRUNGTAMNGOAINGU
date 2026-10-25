using System;
using System.Collections.Generic;
using System.Globalization;
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
        public static KetQuaPhanTrang<TaiKhoanDto> LayTaiKhoanDaXoaTheoTrang(TaiKhoanBoLoc boLoc, int soTrang)
        { PhanQuyenService.YeuCauQuyen("QuanLyTaiKhoan"); return TaiKhoanData.LayTaiKhoanDaXoaTheoTrang(boLoc ?? new TaiKhoanBoLoc(), soTrang); }
        public static void KhoiPhucTaiKhoan(int maTaiKhoan)
        { PhanQuyenService.YeuCauQuyen("QuanLyTaiKhoan"); TaiKhoanData.KhoiPhucTaiKhoan(maTaiKhoan); }
        public static TaiKhoanDto LayChiTietTaiKhoan(int maTaiKhoan)
        { PhanQuyenService.YeuCauQuyen("QuanLyTaiKhoan"); return TaiKhoanData.LayChiTiet(maTaiKhoan); }
        public static IList<HoSoTaiKhoanDto> LayHoSoChuaCoTaiKhoanTheoTrang(string loaiHoSo, string tuKhoa, int soTrang, out int tongBanGhi)
        { PhanQuyenService.YeuCauQuyen("TaoTaiKhoan"); return TaiKhoanData.LayHoSo(loaiHoSo, tuKhoa, soTrang, out tongBanGhi); }
        public static int TaoTaiKhoan(TaiKhoanTaoDto duLieu)
        {
            PhanQuyenService.YeuCauQuyen("TaoTaiKhoan"); if (duLieu == null) throw new ArgumentNullException("duLieu");
            if (duLieu.HoSoID <= 0 || string.IsNullOrWhiteSpace(duLieu.VaiTro) || duLieu.VaiTro == "Admin") throw new InvalidOperationException("Chọn hồ sơ và vai trò phù hợp.");
            var hoSo = TaiKhoanData.LayThongTinHoSoCapTaiKhoan(duLieu.VaiTro, duLieu.HoSoID);
            string matKhau = TaoMatKhauMacDinh(hoSo.NgaySinh);
            return TaiKhoanData.TaoTaiKhoan(duLieu, hoSo.NgaySinh, MatKhauService.BamMatKhau(matKhau));
        }
        public static void SuaTaiKhoan(TaiKhoanSuaDto duLieu)
        { PhanQuyenService.YeuCauQuyen("SuaTaiKhoan"); if (duLieu == null || duLieu.NguoiDungID <= 0 || string.IsNullOrWhiteSpace(duLieu.VaiTro)) throw new InvalidOperationException("Thông tin tài khoản chưa hợp lệ."); TaiKhoanData.SuaTaiKhoan(duLieu); }
        public static void DatLaiMatKhauMacDinh(int maTaiKhoan)
        {
            PhanQuyenService.YeuCauQuyen("DatLaiMatKhau");
            DateTime? ngaySinh = TaiKhoanData.LayNgaySinhLienKetTaiKhoan(maTaiKhoan);
            TaiKhoanData.CapNhatMatKhauMacDinh(maTaiKhoan, ngaySinh, MatKhauService.BamMatKhau(TaoMatKhauMacDinh(ngaySinh)));
        }
        public static IList<KetQuaTaoTaiKhoan> TaoTaiKhoanHangLoat(IList<TaiKhoanTaoDto> hoSo, Action<int, int> tienDo)
        {
            PhanQuyenService.YeuCauQuyen("TaoTaiKhoan");
            if (hoSo == null) throw new ArgumentNullException("hoSo");
            var ketQua = new List<KetQuaTaoTaiKhoan>();
            for (int i = 0; i < hoSo.Count; i++)
            {
                var yeuCau = hoSo[i]; var dong = new KetQuaTaoTaiKhoan { HoSoID = yeuCau == null ? 0 : yeuCau.HoSoID, LoaiHoSo = yeuCau == null ? "" : yeuCau.VaiTro };
                try { TaoTaiKhoan(yeuCau); dong.ThanhCong = true; dong.LyDo = "Đã cấp tài khoản."; }
                catch (InvalidOperationException ex)
                {
                    dong.ThanhCong = false; dong.LyDo = ex.Message;
                    dong.BoQua = ex.Message.IndexOf("đã có tài khoản", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        ex.Message.IndexOf("đã được liên kết", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        ex.Message.IndexOf("đã được cấp tài khoản", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        ex.Message.IndexOf("không còn đủ điều kiện", StringComparison.OrdinalIgnoreCase) >= 0;
                }
                catch (Exception ex) { dong.ThanhCong = false; dong.LyDo = ex.Message; }
                ketQua.Add(dong); if (tienDo != null) tienDo(i + 1, hoSo.Count);
            }
            return ketQua;
        }
        private static string TaoMatKhauMacDinh(DateTime? ngaySinh)
        { return ngaySinh.HasValue ? ngaySinh.Value.ToString("ddMMyyyy", CultureInfo.InvariantCulture) : "12345678"; }
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
