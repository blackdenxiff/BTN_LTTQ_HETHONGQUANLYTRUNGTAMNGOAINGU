using System;
using System.Drawing;
using System.Windows.Forms;
using BTL_LTTQ_QLHTTTNN.Services;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmDoiMatKhau : Form
    {
        public event EventHandler DoiMatKhauYeuCau;
        public bool BuocDoiMatKhauBatBuoc { get; set; }
        public bool DoiMatKhauThanhCong { get; private set; }
        public string MatKhauCu { get { return txtMatKhauCu.Text; } }
        public string MatKhauMoi { get { return txtMatKhauMoi.Text; } }
        public frmDoiMatKhau() { InitializeComponent(); FormClosing += KiemTraDongForm; }
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
            try
            {
                TaiKhoanService.DoiMatKhau(MatKhauCu, MatKhauMoi); DoiMatKhauThanhCong = true;
                HienThongBao("Đổi mật khẩu thành công."); if (DoiMatKhauYeuCau != null) DoiMatKhauYeuCau(this, EventArgs.Empty);
                if (BuocDoiMatKhauBatBuoc) { DialogResult = DialogResult.OK; Close(); }
            }
            catch (Exception ex) { HienThongBao(ex.Message); }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.Clear(); txtMatKhauMoi.Clear(); txtXacNhanMatKhau.Clear();
            chkHienMatKhau.Checked = false; lblThongBao.Text = "";
        }
        private void KiemTraDongForm(object sender, FormClosingEventArgs e)
        { if (BuocDoiMatKhauBatBuoc && !DoiMatKhauThanhCong && e.CloseReason == CloseReason.UserClosing) e.Cancel = true; }
    }
}
