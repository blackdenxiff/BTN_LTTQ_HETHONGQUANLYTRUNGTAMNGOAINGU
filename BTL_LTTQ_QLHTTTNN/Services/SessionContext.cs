using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN.Services
{
    public static class SessionContext
    {
        public static NguoiDungPhien NguoiDungHienTai { get; private set; }
        internal static void ThietLapPhien(NguoiDungPhien nguoiDung) { NguoiDungHienTai = nguoiDung; }
        public static void XoaPhien() { NguoiDungHienTai = null; }
        internal static void DanhDauDaDoiMatKhau() { if (NguoiDungHienTai != null) NguoiDungHienTai.DoiMatKhauLanDau = false; }
    }
}
