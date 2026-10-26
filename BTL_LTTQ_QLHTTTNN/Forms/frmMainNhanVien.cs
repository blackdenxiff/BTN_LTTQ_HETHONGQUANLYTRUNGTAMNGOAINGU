using System;
using System.Drawing;
using System.Windows.Forms;
using BTL_LTTQ_QLHTTTNN.Forms;

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
            formCon.AutoScroll = true;

            pnlNoiDung.Controls.Clear();
            pnlNoiDung.Controls.Add(formCon);
            pnlNoiDung.Tag = formCon;

            // TỰ ĐỘNG ÉP TẤT CẢ BẢNG DATAGRIDVIEW CO GIÃN VỪA VẶN MÀN HÌNH
            TuDongToiUuGiaoDien(formCon);

            formCon.BringToFront();
            formCon.Show();
        }

        // Hàm đệ quy tìm DataGridView trong Form con để bật AutoSizeColumnsMode
        private void TuDongToiUuGiaoDien(Control container)
        {
            foreach (Control c in container.Controls)
            {
                if (c is DataGridView dgv)
                {
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                if (c.HasChildren)
                {
                    TuDongToiUuGiaoDien(c);
                }
            }
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

        private void btnKhoaHoc_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmKhoaHoc());
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

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmThongBao());
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