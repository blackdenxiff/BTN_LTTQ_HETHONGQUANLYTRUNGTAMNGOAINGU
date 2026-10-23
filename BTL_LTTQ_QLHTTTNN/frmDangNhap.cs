using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmDangNhap : Form
    {
        public event EventHandler DangNhapYeuCau;

        public string TenDangNhap { get { return txtTenDangNhap.Text.Trim(); } }

        public string MatKhau { get { return txtMatKhau.Text; } }

        public frmDangNhap() { InitializeComponent(); }

        public void HienThongBao(string thongBao) { lblThongBao.Text = thongBao; }
        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        { txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked; }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TenDangNhap) || MatKhau.Length == 0)
            { HienThongBao("Vui lòng nhập tên đăng nhập và mật khẩu."); return; }
            if (DangNhapYeuCau != null) DangNhapYeuCau(this, EventArgs.Empty);
            else HienThongBao("Chưa kết nối chức năng xác thực tài khoản.");
        }
        private void btnThoat_Click(object sender, EventArgs e) { Close(); }
    }
}
