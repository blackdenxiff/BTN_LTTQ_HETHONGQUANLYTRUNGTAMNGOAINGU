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
        private Button menuChoMo;
        private readonly Color mauMenuThuong = Color.FromArgb(30, 41, 59);
        private readonly Color mauMenuChon = Color.FromArgb(37, 99, 235);
        private readonly Color mauMenuHover = Color.FromArgb(51, 65, 85);
        public frmMainAdmin()
        {
            InitializeComponent();
            var btnThongKe = new Button { Name = "btnThongKe", Text = "Thống kê", Tag = "frmThongKe", Location = new Point(14, 712), Size = new Size(232, 40), FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(30, 41, 59), ForeColor = Color.White, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(10, 0, 0, 0), Cursor = Cursors.Hand };
            btnThongKe.FlatAppearance.BorderSize = 0; btnThongKe.Click += MenuChucNang_Click; pnlMenuNoiDung.Controls.Add(btnThongKe);
            foreach (Control control in pnlMenuNoiDung.Controls)
            {
                Button button = control as Button;
                if (button == null) continue;
                button.MouseEnter += (s, e) => ApDungMauMenu((Button)s, true);
                button.MouseLeave += (s, e) => ApDungMauMenu((Button)s, false);
                ApDungMauMenu(button, false);
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
            Form form = noiDung as Form;
            if (form != null) {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.MinimumSize = Size.Empty;
            }
            Control noiDungCu = noiDungDangMo;
            try
            {
                noiDung.Dock = DockStyle.Fill;
                pnlNoiDung.Controls.Add(noiDung);
                noiDung.BringToFront();
                noiDung.Show();
            }
            catch
            {
                pnlNoiDung.Controls.Remove(noiDung);
                noiDung.Dispose();
                menuChoMo = null;
                throw;
            }
            if (noiDungCu != null) { pnlNoiDung.Controls.Remove(noiDungCu); noiDungCu.Dispose(); }
            noiDungDangMo = noiDung;
            lblChaoMung.Visible = false; lblHuongDan.Visible = false; lblThongBao.Visible = false;
            DatMenuTheoNoiDung(noiDung);
        }
        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            using (frmDoiMatKhau giaoDien = new frmDoiMatKhau()) giaoDien.ShowDialog(this);
        }
        public void MoFormThongKe()
        {
            try { PhanQuyenService.YeuCauQuyen("XemThongKe"); MoNoiDung(new frmThongKe(QuayVeTongQuan)); }
            catch (Exception ex) { menuChoMo = null; MessageBox.Show(this, ex.Message, "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        public void QuayVeTongQuan()
        {
            DatMenuDangChon(null); menuChoMo = null;
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
            menuChoMo = clicked;
            if (MaChucNangYeuCau == "frmThongKe") { MoFormThongKe(); return; }
            if (ChucNangYeuCau != null)
            {
                try { ChucNangYeuCau(this, EventArgs.Empty); }
                catch (Exception ex) { menuChoMo = null; MessageBox.Show(this, ex.Message, "Không thể mở chức năng", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                finally { menuChoMo = null; }
                return;
            }
            switch (MaChucNangYeuCau)
            {
                case "frmTaiKhoan": MoNoiDung(new frmTaiKhoan()); return;
                case "frmGiaoVien": MoNoiDung(new frmGiaoVien()); return;
                case "frmDiemDanh": MoNoiDung(new frmDiemDanh()); return;
                case "frmNhapDiem": MoNoiDung(new frmNhapDiem()); return;
            }
            menuChoMo = null;
            MessageBox.Show(this, "Chức năng này cần được nối với dữ liệu hoặc form của thành viên phụ trách.", "Chức năng chưa kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DatMenuTheoNoiDung(Control noiDung)
        {
            Button nut = menuChoMo;
            if (nut == null)
            {
                string tag = LayMaChucNang(noiDung);
                if (tag != null) nut = TimNutMenu(pnlMenuNoiDung, tag);
            }
            if (nut != null) DatMenuDangChon(nut);
            menuChoMo = null;
        }

        private static string LayMaChucNang(Control noiDung)
        {
            if (noiDung is frmThongKe) return "frmThongKe";
            if (noiDung is frmTaiKhoan) return "frmTaiKhoan";
            if (noiDung is frmHocVien) return "frmHocVien";
            if (noiDung is frmDangKyHoc) return "frmDangKyHoc";
            if (noiDung is frmKhoaHoc) return "frmKhoaHoc";
            if (noiDung is frmLopHoc) return "frmLopHoc";
            if (noiDung is frmLichHoc) return "frmLichHoc";
            if (noiDung is frmGiaoVien) return "frmGiaoVien";
            if (noiDung is frmDiemDanh) return "frmDiemDanh";
            if (noiDung is frmNhapDiem) return "frmNhapDiem";
            if (noiDung is frmHocPhi) return "frmHocPhi";
            if (noiDung is frmLapPhieuThu) return "frmPhieuThu";
            return null;
        }

        private static Button TimNutMenu(Control cha, string maChucNang)
        {
            foreach (Control control in cha.Controls)
            {
                Button button = control as Button;
                if (button != null && Convert.ToString(button.Tag) == maChucNang) return button;
                Button child = TimNutMenu(control, maChucNang);
                if (child != null) return child;
            }
            return null;
        }

        private void DatMenuDangChon(Button nutMoi)
        {
            if (menuDangChon == nutMoi) { ApDungMauMenu(menuDangChon, false); return; }
            Button nutCu = menuDangChon;
            menuDangChon = null;
            ApDungMauMenu(nutCu, false);
            menuDangChon = nutMoi;
            ApDungMauMenu(menuDangChon, false);
        }

        private void ApDungMauMenu(Button nut, bool hover)
        {
            if (nut == null) return;
            bool dangChon = nut == menuDangChon;
            nut.BackColor = dangChon ? mauMenuChon : hover ? mauMenuHover : mauMenuThuong;
            nut.ForeColor = Color.White;
            nut.FlatAppearance.MouseOverBackColor = dangChon ? mauMenuChon : mauMenuHover;
        }
    }
}
