using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmMainAdmin : Form
    {
        public event EventHandler DangXuatYeuCau;
        public event EventHandler DoiMatKhauYeuCau;
        public event EventHandler ChucNangYeuCau;
        public string MaChucNangYeuCau { get; private set; }
        private Control noiDungDangMo;
        public frmMainAdmin() 
        { 
            InitializeComponent(); 
        }
        public void DatTenNguoiDung(string hoTen) 
        { 
            lblNguoiDangNhap.Text = "Xin chào, " + hoTen + "  ▾"; 
        }
        private void lblNguoiDangNhap_Click(object sender, EventArgs e)
        {
            menuTaiKhoan.Show(lblNguoiDangNhap, new Point(lblNguoiDangNhap.Width, lblNguoiDangNhap.Height), ToolStripDropDownDirection.BelowLeft); 
        }
        private void btnThuGonMenu_Click(object sender, EventArgs e) 
        { 
            pnlMenu.Visible = !pnlMenu.Visible; 
        }
        public void MoNoiDung(Control noiDung)
        {
            if (noiDungDangMo != null) {
                pnlNoiDung.Controls.Remove(noiDungDangMo); noiDungDangMo.Dispose(); 
            }
            lblChaoMung.Visible = false; lblHuongDan.Visible = false; lblThongBao.Visible = false;
            Form form = noiDung as Form;
            if (form != null) {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.MinimumSize = Size.Empty;
            }
            noiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Controls.Add(noiDung); noiDungDangMo = noiDung; noiDung.BringToFront(); noiDung.Show();
        }
        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau giaoDien = new frmDoiMatKhau();
            giaoDien.DoiMatKhauYeuCau += delegate (object s, EventArgs args)
            { if (DoiMatKhauYeuCau != null) DoiMatKhauYeuCau(s, args); else giaoDien.HienThongBao("Chưa kết nối chức năng đổi mật khẩu."); };
            MoNoiDung(giaoDien);
        }
        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Bạn muốn thoát tài khoản hiện tại?", "Thoát tài khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (DangXuatYeuCau != null) DangXuatYeuCau(this, EventArgs.Empty); else Close();
        }
        private void MenuChucNang_Click(object sender, EventArgs e)
        {
            MaChucNangYeuCau = Convert.ToString(((Button)sender).Tag);
            if (ChucNangYeuCau != null) { ChucNangYeuCau(this, EventArgs.Empty); return; }
            switch (MaChucNangYeuCau)
            {
                case "frmTaiKhoan": MoNoiDung(new frmTaiKhoan()); return;
                case "frmGiaoVien": MoNoiDung(new frmGiaoVien()); return;
                case "frmDiemDanh": MoNoiDung(new frmDiemDanh()); return;
                case "frmNhapDiem": MoNoiDung(new frmNhapDiem()); return;
            }
            MessageBox.Show(this, "Chức năng này cần được nối với dữ liệu hoặc form của thành viên phụ trách.", "Chức năng chưa kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
