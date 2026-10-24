using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmDoiMatKhau : Form
    {
        public event EventHandler DoiMatKhauYeuCau;
        public string MatKhauCu { get { return txtMatKhauCu.Text; } }
        public string MatKhauMoi { get { return txtMatKhauMoi.Text; } }
        public frmDoiMatKhau() 
        {
            InitializeComponent(); 
        }
        public void HienThongBao(string thongBao) 
        {
            lblThongBao.Text = thongBao; 
        }
        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhauCu.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            txtMatKhauMoi.UseSystemPasswordChar = !chkHienMatKhau.Checked;
            txtXacNhanMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (MatKhauCu.Length == 0 || MatKhauMoi.Length == 0)
            { HienThongBao("Vui lòng nhập đầy đủ mật khẩu."); return; }
            if (MatKhauMoi != txtXacNhanMatKhau.Text)
            { HienThongBao("Mật khẩu xác nhận chưa khớp."); return; }
            if (DoiMatKhauYeuCau != null) DoiMatKhauYeuCau(this, EventArgs.Empty);
            else HienThongBao("Chưa kết nối chức năng đổi mật khẩu.");
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.Clear(); txtMatKhauMoi.Clear(); txtXacNhanMatKhau.Clear();
            chkHienMatKhau.Checked = false; lblThongBao.Text = "";
        }
    }
}
