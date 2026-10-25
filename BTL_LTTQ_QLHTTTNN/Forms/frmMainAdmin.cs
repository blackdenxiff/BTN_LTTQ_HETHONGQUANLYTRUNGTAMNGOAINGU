using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using BTL_LTTQ_QLHTTTNN.Services;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmMainAdmin : Form
    {
        public event EventHandler DangXuatYeuCau;
        public event EventHandler DoiMatKhauYeuCau;
        public event EventHandler ChucNangYeuCau;
        public string MaChucNangYeuCau { get; private set; }
        private Control noiDungDangMo;
        private int maYeuCauThongKe;
        private Button menuDangChon;
        private readonly Color mauMenuThuong = Color.FromArgb(30, 41, 59);
        private readonly Color mauMenuChon = Color.FromArgb(37, 99, 235);
        public frmMainAdmin()
        {
            InitializeComponent();
            var btnThongKe = new Button { Name = "btnThongKe", Text = "Thống kê", Tag = "frmThongKe", Location = new Point(14, 712), Size = new Size(232, 40), FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(30, 41, 59), ForeColor = Color.White, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(10, 0, 0, 0), Cursor = Cursors.Hand };
            btnThongKe.FlatAppearance.BorderSize = 0; btnThongKe.Click += MenuChucNang_Click; pnlMenuNoiDung.Controls.Add(btnThongKe);
            foreach (Control control in pnlMenuNoiDung.Controls)
            {
                Button button = control as Button;
                if (button == null) continue;
                button.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 65, 85);
                button.MouseEnter += delegate { if (button != menuDangChon) button.BackColor = Color.FromArgb(51, 65, 85); };
                button.MouseLeave += delegate { if (button != menuDangChon) button.BackColor = mauMenuThuong; };
            }
            Load += delegate { QuayVeTongQuan(); };
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
            if (noiDung == null) throw new ArgumentNullException("noiDung");
            if (noiDungDangMo != null && noiDungDangMo.GetType() == noiDung.GetType()) { if (!object.ReferenceEquals(noiDungDangMo, noiDung)) noiDung.Dispose(); DatMenuTheoNoiDung(noiDung); return; }
            if (noiDungDangMo != null) {
                pnlNoiDung.Controls.Remove(noiDungDangMo); noiDungDangMo.Dispose(); noiDungDangMo = null;
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
            DatMenuTheoNoiDung(noiDung);
        }
        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            using (frmDoiMatKhau giaoDien = new frmDoiMatKhau()) giaoDien.ShowDialog(this);
        }
        public void MoFormThongKe()
        {
            try { PhanQuyenService.YeuCauQuyen("XemThongKe"); MoNoiDung(new frmThongKe(QuayVeTongQuan)); }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        public void QuayVeTongQuan()
        {
            maYeuCauThongKe++; if (noiDungDangMo != null) { pnlNoiDung.Controls.Remove(noiDungDangMo); noiDungDangMo.Dispose(); noiDungDangMo = null; }
            pnlNoiDung.Controls.Clear(); pnlNoiDung.Controls.Add(lblChaoMung); pnlNoiDung.Controls.Add(lblHuongDan); pnlNoiDung.Controls.Add(lblThongBao);
            lblChaoMung.Visible = true; lblHuongDan.Visible = true; lblThongBao.Visible = true;
            lblChaoMung.Text = "Tổng quan quản trị"; lblHuongDan.Text = "Chỉ số hiện tại và số liệu trong tháng đang xem.";
            TaiThongKeTongQuan();
        }
        public async void TaiThongKeTongQuan()
        {
            int request = ++maYeuCauThongKe; var dangTai = new Label { Name = "lblThongKeDangTai", Text = "Đang tải số liệu…", AutoSize = true, Location = new Point(36, 155), Font = new Font("Segoe UI", 11F) };
            var nutLamMoi = new Button { Name = "btnLamMoiThongKe", Text = "Làm mới", Location = new Point(840, 28), Size = new Size(120, 36), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            var nutThongKeChiTiet = new Button { Name = "btnThongKeChiTiet", Text = "Thống kê chi tiết", Location = new Point(650, 28), Size = new Size(170, 36), Anchor = AnchorStyles.Top | AnchorStyles.Right };
            var thoiDiem = new Label { Name = "lblThoiDiemCapNhat", Text = "", AutoSize = true, Location = new Point(36, 122), ForeColor = Color.DimGray };
            pnlNoiDung.Controls.Clear(); pnlNoiDung.Controls.Add(dangTai); pnlNoiDung.Controls.Add(nutLamMoi); pnlNoiDung.Controls.Add(nutThongKeChiTiet); pnlNoiDung.Controls.Add(thoiDiem);
            nutLamMoi.Click += delegate { TaiThongKeTongQuan(); };
            nutThongKeChiTiet.Click += delegate { MoFormThongKe(); };
            try
            {
                var result = await Task.Run(() => ThongKeService.LayThongKeTongQuan(new ThongKeBoLoc { TuNgay = DateTime.Today, DenNgay = DateTime.Today }));
                if (IsDisposed || request != maYeuCauThongKe) return;
                pnlNoiDung.Controls.Remove(dangTai); dangTai.Dispose();
                ThemThe("Tổng học viên", result.TongHocVien.ToString("N0"), 36, 165, "Hiện tại");
                ThemThe("Tổng giáo viên", result.TongGiaoVien.ToString("N0"), 350, 165, "Hiện tại");
                ThemThe("Lớp đang học", result.TongLopDangHoc.ToString("N0"), 664, 165, "Hiện tại");
                ThemThe("Đăng ký trong tháng", result.DangKyTrongThang.ToString("N0"), 36, 330, DateTime.Today.ToString("MMMM yyyy"));
                ThemThe("Tiền thực thu trong tháng", result.ThucThuTrongThang.ToString("N0") + " đ", 350, 330, DateTime.Today.ToString("MMMM yyyy"));
                thoiDiem.Text = "Cập nhật lúc " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                lblHuongDan.Text = "Ba chỉ số đầu là hiện tại; đăng ký và thực thu tính theo tháng hiện tại.";
            }
            catch (Exception ex) { if (!IsDisposed && request == maYeuCauThongKe) dangTai.Text = "Không tải được dữ liệu: " + ex.Message; }
        }
        private void ThemThe(string tieuDe, string giaTri, int x, int y, string ghiChu)
        {
            var the = new Panel { Location = new Point(x, y), Size = new Size(280, 130), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Anchor = AnchorStyles.Top | AnchorStyles.Left };
            the.Controls.Add(new Label { Text = tieuDe, Location = new Point(16, 14), Size = new Size(245, 26), Font = new Font("Segoe UI", 10F), ForeColor = Color.DimGray });
            the.Controls.Add(new Label { Text = giaTri, Location = new Point(16, 43), Size = new Size(245, 46), Font = new Font("Segoe UI", 22F, FontStyle.Bold), ForeColor = Color.FromArgb(37, 99, 235) });
            the.Controls.Add(new Label { Text = ghiChu, Location = new Point(16, 96), Size = new Size(245, 22), Font = new Font("Segoe UI", 9F), ForeColor = Color.Gray }); pnlNoiDung.Controls.Add(the);
        }
        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Bạn muốn thoát tài khoản hiện tại?", "Thoát tài khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (DangXuatYeuCau != null) DangXuatYeuCau(this, EventArgs.Empty); else Close();
        }
        private void MenuChucNang_Click(object sender, EventArgs e)
        {
            var clicked = sender as Button;
            if (clicked == null) return;
            string maChucNang = Convert.ToString(clicked.Tag);
            if (menuDangChon == clicked && noiDungDangMo != null) return;
            MaChucNangYeuCau = maChucNang;
            if (MaChucNangYeuCau == "frmThongKe") { MoFormThongKe(); return; }
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

        private void DatMenuTheoNoiDung(Control noiDung)
        {
            string tag = noiDung is frmThongKe ? "frmThongKe" : noiDung is frmTaiKhoan ? "frmTaiKhoan" :
                noiDung is frmGiaoVien ? "frmGiaoVien" : noiDung is frmDiemDanh ? "frmDiemDanh" :
                noiDung is frmNhapDiem ? "frmNhapDiem" : null;
            Button nut = null;
            foreach (Control control in pnlMenuNoiDung.Controls)
                if (control is Button && Convert.ToString(control.Tag) == tag) { nut = (Button)control; break; }
            if (nut == null) return;
            if (menuDangChon != null) menuDangChon.BackColor = mauMenuThuong;
            menuDangChon = nut; menuDangChon.BackColor = mauMenuChon; menuDangChon.ForeColor = Color.White;
        }
    }
}
