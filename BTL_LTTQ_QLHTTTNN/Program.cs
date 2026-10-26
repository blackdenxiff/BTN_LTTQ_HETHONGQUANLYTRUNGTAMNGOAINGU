using System;
using System.Windows.Forms;
using BTL_LTTQ_QLHTTTNN.Services;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VongDoiUngDung());
            //  Application.Run(new frmMainAdmin());
            //Application.Run(new frmThongKe());
        }
    }

    internal sealed class VongDoiUngDung : ApplicationContext
    {
        private frmDangNhap dangNhap;
        private Form manHinhHienTai;
        public VongDoiUngDung() { HienDangNhap(); }
        private void HienDangNhap()
        {
            dangNhap = new frmDangNhap(); MainForm = dangNhap;
            dangNhap.DangNhapYeuCau += XacThuc; dangNhap.FormClosed += (s, e) => ExitThread(); dangNhap.Show();
        }
        private void XacThuc(object sender, EventArgs e)
        {
            try
            {
                NguoiDungPhien user = TaiKhoanService.DangNhap(dangNhap.TenDangNhap, dangNhap.MatKhau);
                if (user.DoiMatKhauLanDau)
                {
                    using (var doi = new frmDoiMatKhau { BuocDoiMatKhauBatBuoc = true })
                    {
                        doi.ShowDialog(dangNhap);
                        if (!doi.DoiMatKhauThanhCong) { TaiKhoanService.DangXuat(); dangNhap.HienThongBao("Bạn cần đổi mật khẩu trước khi sử dụng hệ thống."); return; }
                    }
                }
                Form main = TaoManHinh(user); if (main == null) throw new InvalidOperationException("Vai trò hoặc hồ sơ chưa được hỗ trợ.");
                dangNhap.XoaMatKhau();
                manHinhHienTai = main; dangNhap.Hide(); MainForm = dangNhap;
                main.FormClosed += KetThucPhien; main.Show();
            }
            catch (Exception ex) { TaiKhoanService.DangXuat(); dangNhap.XoaMatKhau(); dangNhap.HienThongBao(ex.GetBaseException().Message); }
        }
        private Form TaoManHinh(NguoiDungPhien user)
        {
            if (user.VaiTro == "Admin")
            {
                var form = new frmMainAdmin(); form.DatTenNguoiDung(user.HoTen);
                form.DangXuatYeuCau += (s, e) => { TaiKhoanService.DangXuat(); form.Close(); };
                form.ChucNangYeuCau += (s, e) =>
                {
                    if (form.MaChucNangYeuCau == "frmTaiKhoan") form.MoNoiDung(new frmTaiKhoan());
                    else if (form.MaChucNangYeuCau == "frmThongKe") form.MoFormThongKe();
                    else MoChucNangAdmin(form, form.MaChucNangYeuCau);
                };
                return form;
            }
            if (user.VaiTro == "Giáo viên")
            {
                var form = new frmMainGiaoVien(); form.DatTenNguoiDung(user.HoTen); form.DangXuatYeuCau += (s, e) => { TaiKhoanService.DangXuat(); form.Close(); }; form.DoiMatKhauYeuCau += (s, e) => { }; return form;
            }
            if (user.VaiTro == "Nhân viên")
            { var form = new frmMainNhanVien(); form.DatTenNguoiDung(user.HoTen); return form; }
            if (user.VaiTro == "Học viên") return new frmMainHocVien(user.NguoiDungID);
            return null;
        }
        private static void MoChucNangAdmin(frmMainAdmin form, string ma)
        {
            switch (ma)
            {
                case "frmHocVien": form.MoNoiDung(new frmHocVien()); break;
                case "frmDangKyHoc":
                    PhanQuyenService.YeuCauQuyen("DangKyLopCaNhan");
                    form.MoNoiDung(new frmDangKyHoc()); break;
                case "frmKhoaHoc": form.MoNoiDung(new frmKhoaHoc()); break;
                case "frmLopHoc": form.MoNoiDung(new frmLopHoc()); break;
                case "frmLichHoc": form.MoNoiDung(new frmLichHoc()); break;
                case "frmGiaoVien": form.MoNoiDung(new frmGiaoVien()); break;
                case "frmDiemDanh": form.MoNoiDung(new frmDiemDanh()); break;
                case "frmNhapDiem": form.MoNoiDung(new frmNhapDiem()); break;
                case "frmHocPhi": form.MoNoiDung(new frmHocPhi()); break;
                case "frmPhieuThu": form.MoNoiDung(new frmLapPhieuThu()); break;
            }
        }
        private void KetThucPhien(object sender, FormClosedEventArgs e)
        {
            TaiKhoanService.DangXuat(); manHinhHienTai = null;
            if (e.CloseReason == CloseReason.ApplicationExitCall || e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.TaskManagerClosing) return;
            if (dangNhap != null && !dangNhap.IsDisposed) { MainForm = dangNhap; dangNhap.HienThongBao("Đã đăng xuất."); dangNhap.Show(); dangNhap.Activate(); }
        }
    }
}
