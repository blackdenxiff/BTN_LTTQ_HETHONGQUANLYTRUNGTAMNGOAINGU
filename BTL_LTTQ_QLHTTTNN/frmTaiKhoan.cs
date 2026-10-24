using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmTaiKhoan : Form
    {
        public event EventHandler TimKiemYeuCau;
        public event EventHandler LuuYeuCau;
        public event EventHandler KhoaYeuCau;
        public event EventHandler MoKhoaYeuCau;
        public DataGridView BangTaiKhoan { get { return dgvTaiKhoan; } }
        public string TuKhoa { get { return txtTimKiem.Text.Trim(); } }
        public string TenDangNhapNhap { get { return txtTenDangNhap.Text.Trim(); } }
        public string MatKhauKhoiTao { get { return txtMatKhauKhoiTao.Text; } }
        public ComboBox VaiTroNhap { get { return cboVaiTro; } }
        public ComboBox HoSoLienKet { get { return cboHoSoLienKet; } }
        public ComboBox LocVaiTro { get { return cboLocVaiTro; } }
        public ComboBox LocTrangThai { get { return cboLocTrangThai; } }
        public frmTaiKhoan()
        { InitializeComponent(); cboLocVaiTro.SelectedIndex = 0; cboLocTrangThai.SelectedIndex = 0; }
        public void HienThongBao(string thongBao) { lblTrangThai.Text = thongBao; }
        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        { txtMatKhauKhoiTao.UseSystemPasswordChar = !chkHienMatKhau.Checked; txtXacNhanMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked; }
        private void btnThemMoi_Click(object sender, EventArgs e)
        { txtMaTaiKhoan.Clear(); txtTenDangNhap.Clear(); txtMatKhauKhoiTao.Clear(); txtXacNhanMatKhau.Clear(); cboVaiTro.SelectedIndex = -1; cboHoSoLienKet.SelectedIndex = -1; chkHienMatKhau.Checked = false; txtTenDangNhap.Focus(); }
        private void btnHuy_Click(object sender, EventArgs e) { btnThemMoi_Click(sender, e); }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (TenDangNhapNhap.Length == 0 || MatKhauKhoiTao.Length == 0 || cboVaiTro.SelectedIndex < 0)
            { HienThongBao("Nhập tên đăng nhập, mật khẩu và chọn vai trò."); return; }
            if (MatKhauKhoiTao != txtXacNhanMatKhau.Text)
            { HienThongBao("Mật khẩu xác nhận chưa khớp."); return; }
            if (LuuYeuCau != null) LuuYeuCau(this, EventArgs.Empty);
            else HienThongBao("Chưa kết nối chức năng cấp tài khoản.");
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        { if (TimKiemYeuCau != null) TimKiemYeuCau(this, EventArgs.Empty); else HienThongBao("Chưa kết nối dữ liệu tài khoản."); }
        private void btnLamMoi_Click(object sender, EventArgs e)
        { txtTimKiem.Clear(); cboLocVaiTro.SelectedIndex = 0; cboLocTrangThai.SelectedIndex = 0; btnTimKiem_Click(sender, e); }
        private void btnKhoa_Click(object sender, EventArgs e)
        { if (dgvTaiKhoan.CurrentRow == null) { HienThongBao("Chọn tài khoản cần khóa."); return; } if (KhoaYeuCau != null) KhoaYeuCau(this, EventArgs.Empty); else HienThongBao("Chưa kết nối chức năng khóa tài khoản."); }
        private void btnMoKhoa_Click(object sender, EventArgs e)
        { if (dgvTaiKhoan.CurrentRow == null) { HienThongBao("Chọn tài khoản cần mở khóa."); return; } if (MoKhoaYeuCau != null) MoKhoaYeuCau(this, EventArgs.Empty); else HienThongBao("Chưa kết nối chức năng mở khóa."); }
    }
}
