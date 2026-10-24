using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmMainGiaoVien : Form
    {
        public event EventHandler DangXuatYeuCau;
        public event EventHandler DoiMatKhauYeuCau;
        public event EventHandler ChucNangYeuCau;
        public string MaChucNangYeuCau { get; private set; }
        private Control noiDungDangMo;

        public frmMainGiaoVien()
        {
            InitializeComponent();
        }

        public frmMainGiaoVien(int nhanSuId) : this()
        {
            SessionContext.NhanSuID = nhanSuId;
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
            if (noiDungDangMo != null)
            {
                pnlNoiDung.Controls.Remove(noiDungDangMo);
                noiDungDangMo.Dispose();
            }

            lblChaoMung.Visible = false;
            lblHuongDan.Visible = false;
            lblThongBao.Visible = false;

            Form form = noiDung as Form;
            if (form != null)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.MinimumSize = Size.Empty;
            }

            noiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Controls.Add(noiDung);
            noiDungDangMo = noiDung;
            noiDung.BringToFront();
            noiDung.Show();
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau giaoDien = new frmDoiMatKhau();
            if (DoiMatKhauYeuCau != null)
            {
                giaoDien.DoiMatKhauYeuCau += delegate (object s, EventArgs args)
                {
                    DoiMatKhauYeuCau(s, args);
                };
            }
            MoNoiDung(giaoDien);
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Bạn muốn thoát tài khoản hiện tại?", "Thoát tài khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (DangXuatYeuCau != null)
                DangXuatYeuCau(this, EventArgs.Empty);
            else
                Close();
        }

        public void MenuChucNang_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            MaChucNangYeuCau = Convert.ToString(btn.Tag);
            if (ChucNangYeuCau != null)
            {
                ChucNangYeuCau(this, EventArgs.Empty);
            }

            switch (MaChucNangYeuCau)
            {
                case "HoSo":
                case "frmGiaoVien":
                case "thongtincanha":
                    MoNoiDung(new thongtincanha());
                    break;

                case "frmLopHoc":
                    MoNoiDung(new frmLopHoc());
                    break;

                case "frmLichHoc":
                    MoNoiDung(new frmLichHoc());
                    break;

                case "frmDiemDanh":
                    MoNoiDung(new frmDiemDanh());
                    break;

                case "frmNhapDiem":
                    MoNoiDung(new frmNhapDiem());
                    break;
            }
        }
    }
}
