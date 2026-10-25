using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmMainNhanVien : Form
    {
        private Form formConDangMo;

        public frmMainNhanVien()
        {
            InitializeComponent();
        }

        public void DatTenNguoiDung(string hoTen)
        {
            lblNguoiDangNhap.Text = hoTen + " ▾";
        }

        public void MoFormCon(Form formCon)
        {
            if (formConDangMo != null)
            {
                formConDangMo.Close();
                formConDangMo.Dispose();
            }

            formConDangMo = formCon;
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;

            pnlNoiDung.Controls.Add(formCon);
            pnlNoiDung.Tag = formCon;
            formCon.BringToFront();
            formCon.Show();
        }

        private void btnHoSoHocVien_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmHocVien());
        }
        private void lblDoiMatKhauNhanh_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmDoiMatKhau());
        }

        private void btnKhaoThiXepLop_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmDangKyHoc());
        }

        private void btnDanhSachLopHoc_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmLopHoc());
        }

        private void btnLichHocPhongHoc_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmLichHoc());
        }

        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmHocPhi());
        }

        private void btnPhieuThuThanhToan_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmLapPhieuThu());
        }

        private void btnThuGonMenu_Click(object sender, EventArgs e)
        {
            pnlMenu.Visible = !pnlMenu.Visible;
        }

        private void lblNguoiDangNhap_Click(object sender, EventArgs e)
        {
            menuTaiKhoan.Show(lblNguoiDangNhap, new Point(lblNguoiDangNhap.Width - menuTaiKhoan.Width, lblNguoiDangNhap.Height));
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmDoiMatKhau());
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Bạn có muốn đăng xuất khỏi hệ thống?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}