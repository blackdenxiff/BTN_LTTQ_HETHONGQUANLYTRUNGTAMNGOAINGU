using System;
using System.Collections.Generic;

namespace BTL_LTTQ_QLHTTTNN.Services.Models
{
    public sealed class NguoiDungPhien
    {
        internal NguoiDungPhien(int id, string tenDangNhap, string vaiTro, string hoTen, int? nhanSuId, int? hocVienId, bool doiMatKhauLanDau)
        { NguoiDungID = id; TenDangNhap = tenDangNhap; VaiTro = vaiTro; HoTen = hoTen; NhanSuID = nhanSuId; HocVienID = hocVienId; DoiMatKhauLanDau = doiMatKhauLanDau; }
        public int NguoiDungID { get; private set; }
        public string TenDangNhap { get; private set; }
        public string VaiTro { get; private set; }
        public string HoTen { get; private set; }
        public int? NhanSuID { get; private set; }
        public int? HocVienID { get; private set; }
        public bool DoiMatKhauLanDau { get; internal set; }
    }

    public sealed class TaiKhoanBoLoc
    {
        public string TuKhoa { get; set; }
        public string VaiTro { get; set; }
        public string TrangThai { get; set; }
        public bool HienTaiKhoanXoaMem { get; set; }
    }

    public sealed class TaiKhoanDto
    {
        public int NguoiDungID { get; set; }
        public string TenDangNhap { get; set; }
        public string HoTen { get; set; }
        public string VaiTro { get; set; }
        public string TrangThai { get; set; }
        public bool IsDeleted { get; set; }
        public int? NhanSuID { get; set; }
        public int? HocVienID { get; set; }
        public DateTime? DeletedAt { get; set; }
    }

    public sealed class TaiKhoanTaoDto
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
        public int? NhanSuID { get; set; }
        public int? HocVienID { get; set; }
    }

    public sealed class TaiKhoanSuaDto
    {
        public int NguoiDungID { get; set; }
        public string TenDangNhap { get; set; }
        public string VaiTro { get; set; }
    }

    public sealed class HoSoTaiKhoanDto
    {
        public int HoSoID { get; set; }
        public string HoTen { get; set; }
        public string LoaiHoSo { get; set; }
        public override string ToString() { return HoTen + " (#" + HoSoID + ")"; }
    }

    public sealed class KetQuaPhanTrang<T>
    {
        public KetQuaPhanTrang(IList<T> danhSach, int tongBanGhi, int soTrang, int kichThuocTrang)
        { DanhSach = danhSach; TongBanGhi = tongBanGhi; SoTrang = Math.Max(1, soTrang); KichThuocTrang = kichThuocTrang; TongSoTrang = Math.Max(1, (int)Math.Ceiling((double)tongBanGhi / kichThuocTrang)); }
        public IList<T> DanhSach { get; private set; }
        public int TongBanGhi { get; private set; }
        public int SoTrang { get; private set; }
        public int KichThuocTrang { get; private set; }
        public int TongSoTrang { get; private set; }
    }
}
