using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BTL_LTTQ_QLHTTTNN.Services;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmTaiKhoan : Form
    {
        private int trang = 1, tongTrang = 1, trangHoSo = 1, tongTrangHoSo = 1;
        private int trangDanhSach = 1;
        private int trangLichSuXoa = 1;
        private bool dangXemLichSuXoa;
        private string tuKhoaTruoc = "";
        private string vaiTroTruoc = "Tất cả";
        private string trangThaiTruoc = "Tất cả";
        private readonly Button nutTruoc = new Button(), nutSau = new Button(), nutXoaMem = new Button();
        private readonly Label nhanTrang = new Label();
        private readonly Button hoSoTruoc = new Button(), hoSoSau = new Button();
        private readonly Label nhanTrangHoSo = new Label();
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
        {
            InitializeComponent();
            if (DangOCheDoThietKe()) return;

            colMaTaiKhoan.DataPropertyName = "NguoiDungID"; cboLocVaiTro.SelectedIndex = 0; cboLocTrangThai.SelectedIndex = 0;
            cboVaiTro.SelectedIndexChanged += delegate { TaiHoSo(); };
            dgvTaiKhoan.SelectionChanged += delegate { ChonTaiKhoan(); };
            TaoDieuKhienPhanTrang();
            Load += frmTaiKhoan_Load;
        }
        private static bool DangOCheDoThietKe()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            TaiDanhSach();
        }

        private void TaoDieuKhienPhanTrang()
        {
            nutTruoc.Text = "Trước"; nutTruoc.Width = 80; nutTruoc.Height = 28; nutTruoc.Click += delegate { if (trang > 1) { trang--; TaiDanhSach(); } };
            nutSau.Text = "Sau"; nutSau.Width = 80; nutSau.Height = 28; nutSau.Click += delegate { if (trang < tongTrang) { trang++; TaiDanhSach(); } };
            nhanTrang.AutoSize = true; nhanTrang.TextAlign = ContentAlignment.MiddleCenter;
            nutXoaMem.Text = "Xóa mềm"; nutXoaMem.Width = 100; nutXoaMem.Height = 28; nutXoaMem.Click += delegate { XoaMem(); };
            hoSoTruoc.Text = "‹"; hoSoTruoc.SetBounds(820, 105, 42, 26); hoSoTruoc.Click += delegate { if (trangHoSo > 1) { trangHoSo--; TaiHoSo(); } };
            hoSoSau.Text = "›"; hoSoSau.SetBounds(930, 105, 42, 26); hoSoSau.Click += delegate { if (trangHoSo < tongTrangHoSo) { trangHoSo++; TaiHoSo(); } };
            nhanTrangHoSo.SetBounds(862, 105, 68, 26); nhanTrangHoSo.TextAlign = ContentAlignment.MiddleCenter;
            pnlNhapLieu.Controls.Add(hoSoTruoc); pnlNhapLieu.Controls.Add(nhanTrangHoSo); pnlNhapLieu.Controls.Add(hoSoSau);
            var thanh = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 38, FlowDirection = FlowDirection.RightToLeft, Padding = new Padding(8, 4, 8, 0) };
            thanh.Controls.Add(nutSau); thanh.Controls.Add(nhanTrang); thanh.Controls.Add(nutTruoc); thanh.Controls.Add(nutXoaMem); pnlDanhSach.Controls.Add(thanh);
        }
        public void HienThongBao(string thongBao) { lblTrangThai.Text = thongBao; }
        private void TaiDanhSach()
        {
            try
            {
                var boLoc = new TaiKhoanBoLoc { TuKhoa = TuKhoa, VaiTro = cboLocVaiTro.Text == "Tất cả" ? "" : cboLocVaiTro.Text, TrangThai = dangXemLichSuXoa ? "Tất cả" : cboLocTrangThai.Text };
                var ketQua = dangXemLichSuXoa ? TaiKhoanService.LayTaiKhoanDaXoaTheoTrang(boLoc, trang) : TaiKhoanService.LayTaiKhoanTheoTrang(boLoc, trang);
                tongTrang = Math.Max(1, ketQua.TongSoTrang);
                if (trang > tongTrang) { trang = tongTrang; ketQua = dangXemLichSuXoa ? TaiKhoanService.LayTaiKhoanDaXoaTheoTrang(boLoc, trang) : TaiKhoanService.LayTaiKhoanTheoTrang(boLoc, trang); }
                nhanTrang.Text = string.Format("{0}/{1} • {2} tài khoản", ketQua.SoTrang, ketQua.TongSoTrang, ketQua.TongBanGhi); dgvTaiKhoan.DataSource = ketQua.DanhSach;
                nutTruoc.Enabled = trang > 1; nutSau.Enabled = trang < tongTrang; btnKhoiPhuc.Enabled = dangXemLichSuXoa && dgvTaiKhoan.CurrentRow != null;
                lblTrangThai.Text = ketQua.TongBanGhi == 0 ? "Không có tài khoản phù hợp." : "Đã tải " + ketQua.DanhSach.Count + " tài khoản.";
            }
            catch (Exception ex) { HienThongBao(ex.Message); }
        }
        private void TaiHoSo()
        {
            cboHoSoLienKet.Items.Clear(); string role = cboVaiTro.Text;
            if (string.IsNullOrWhiteSpace(role)) { cboHoSoLienKet.Enabled = false; hoSoTruoc.Visible = hoSoSau.Visible = nhanTrangHoSo.Visible = false; return; }
            if (role == "Admin") { cboHoSoLienKet.Enabled = false; hoSoTruoc.Visible = hoSoSau.Visible = nhanTrangHoSo.Visible = false; return; }
            cboHoSoLienKet.Enabled = true; hoSoTruoc.Visible = hoSoSau.Visible = nhanTrangHoSo.Visible = true;
            try { int count; foreach (var hoSo in TaiKhoanService.LayHoSoChuaCoTaiKhoanTheoTrang(role, TuKhoa, trangHoSo, out count)) cboHoSoLienKet.Items.Add(hoSo); tongTrangHoSo = Math.Max(1, (int)Math.Ceiling(count / 10.0)); nhanTrangHoSo.Text = trangHoSo + "/" + tongTrangHoSo; hoSoTruoc.Enabled = trangHoSo > 1; hoSoSau.Enabled = trangHoSo < tongTrangHoSo; }
            catch (Exception ex) { HienThongBao(ex.Message); }
        }
        private void ChonTaiKhoan()
        {
            var row = dgvTaiKhoan.CurrentRow == null ? null : dgvTaiKhoan.CurrentRow.DataBoundItem as TaiKhoanDto; if (row == null) return;
            if (dangXemLichSuXoa) { btnKhoiPhuc.Enabled = row.IsDeleted; return; }
            txtMaTaiKhoan.Text = row.NguoiDungID.ToString(); txtTenDangNhap.Text = row.TenDangNhap; cboVaiTro.SelectedItem = row.VaiTro;
            hoSoTruoc.Visible = hoSoSau.Visible = nhanTrangHoSo.Visible = false;
            cboHoSoLienKet.Enabled = false; txtMatKhauKhoiTao.Clear(); txtXacNhanMatKhau.Clear(); txtMatKhauKhoiTao.Enabled = false; txtXacNhanMatKhau.Enabled = false;
            nutXoaMem.Enabled = !row.IsDeleted; btnKhoa.Enabled = row.TrangThai == "Hoạt động"; btnMoKhoa.Enabled = row.TrangThai == "Đã khóa";
        }
        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        { txtMatKhauKhoiTao.UseSystemPasswordChar = !chkHienMatKhau.Checked; txtXacNhanMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked; }
        private void btnThemMoi_Click(object sender, EventArgs e)
        { if (dangXemLichSuXoa) return; txtMaTaiKhoan.Clear(); txtTenDangNhap.Clear(); txtMatKhauKhoiTao.Clear(); txtXacNhanMatKhau.Clear(); txtMatKhauKhoiTao.Enabled = txtXacNhanMatKhau.Enabled = true; trangHoSo = 1; cboVaiTro.SelectedIndex = -1; cboHoSoLienKet.Enabled = true; cboHoSoLienKet.SelectedIndex = -1; nutXoaMem.Enabled = false; btnKhoa.Enabled = btnMoKhoa.Enabled = false; chkHienMatKhau.Checked = false; txtTenDangNhap.Focus(); }
        private void btnHuy_Click(object sender, EventArgs e) { btnThemMoi_Click(sender, e); }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dangXemLichSuXoa) return;
            try
            {
                if (TenDangNhapNhap.Length == 0 || cboVaiTro.SelectedIndex < 0) { HienThongBao("Nhập tên đăng nhập và chọn vai trò."); return; }
                if (txtMaTaiKhoan.Text.Length > 0) TaiKhoanService.SuaTaiKhoan(new TaiKhoanSuaDto { NguoiDungID = int.Parse(txtMaTaiKhoan.Text), TenDangNhap = TenDangNhapNhap, VaiTro = cboVaiTro.Text });
                else
                {
                    if (MatKhauKhoiTao.Length == 0) { HienThongBao("Nhập mật khẩu khởi tạo."); return; }
                    if (MatKhauKhoiTao != txtXacNhanMatKhau.Text) { HienThongBao("Mật khẩu xác nhận chưa khớp."); return; }
                    var profile = cboHoSoLienKet.SelectedItem as HoSoTaiKhoanDto; if (cboVaiTro.Text != "Admin" && profile == null) { HienThongBao("Chọn hồ sơ chưa có tài khoản phù hợp."); return; }
                    TaiKhoanService.TaoTaiKhoan(new TaiKhoanTaoDto { TenDangNhap = TenDangNhapNhap, MatKhau = MatKhauKhoiTao, VaiTro = cboVaiTro.Text, NhanSuID = profile != null && profile.LoaiHoSo != "Học viên" ? (int?)profile.HoSoID : null, HocVienID = profile != null && profile.LoaiHoSo == "Học viên" ? (int?)profile.HoSoID : null });
                }
                HienThongBao("Đã lưu tài khoản."); btnThemMoi_Click(sender, e); TaiDanhSach();
            }
            catch (Exception ex) { HienThongBao(ex.Message); }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        { trang = trangHoSo = 1; if (dangXemLichSuXoa) trangLichSuXoa = 1; else trangDanhSach = 1; TaiDanhSach(); if (!dangXemLichSuXoa) TaiHoSo(); if (TimKiemYeuCau != null) TimKiemYeuCau(this, EventArgs.Empty); }
        private void btnLamMoi_Click(object sender, EventArgs e)
        { txtTimKiem.Clear(); cboLocVaiTro.SelectedIndex = 0; cboLocTrangThai.SelectedIndex = 0; trang = 1; TaiDanhSach(); }
        private void btnKhoa_Click(object sender, EventArgs e)
        { if (dangXemLichSuXoa) return; try { TaiKhoanService.DoiTrangThaiTaiKhoan(ChonID(), true); TaiDanhSach(); } catch (Exception ex) { HienThongBao(ex.Message); } }
        private void btnMoKhoa_Click(object sender, EventArgs e)
        { if (dangXemLichSuXoa) return; try { TaiKhoanService.DoiTrangThaiTaiKhoan(ChonID(), false); TaiDanhSach(); } catch (Exception ex) { HienThongBao(ex.Message); } }
        private int ChonID() { var row = dgvTaiKhoan.CurrentRow == null ? null : dgvTaiKhoan.CurrentRow.DataBoundItem as TaiKhoanDto; if (row == null) throw new InvalidOperationException("Chọn tài khoản cần thao tác."); return row.NguoiDungID; }
        private void XoaMem()
        { if (dangXemLichSuXoa) return; try { int id = ChonID(); if (MessageBox.Show(this, "Đánh dấu tài khoản này là đã xóa?", "Xóa mềm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { TaiKhoanService.XoaMemTaiKhoan(id); TaiDanhSach(); } } catch (Exception ex) { HienThongBao(ex.Message); } }

        private void btnLichSuXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || txtMaTaiKhoan.Text.Length == 0 && !string.IsNullOrWhiteSpace(txtMatKhauKhoiTao.Text))
            {
                if (MessageBox.Show(this, "Bỏ nội dung tài khoản đang nhập và mở lịch sử xóa?", "Lịch sử xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            }
            tuKhoaTruoc = txtTimKiem.Text; vaiTroTruoc = cboLocVaiTro.Text; trangThaiTruoc = cboLocTrangThai.Text; trangDanhSach = trang;
            dangXemLichSuXoa = true; trang = trangLichSuXoa = 1; dgvTaiKhoan.ClearSelection(); dgvTaiKhoan.DataSource = null;
            txtMaTaiKhoan.Clear(); txtTenDangNhap.Clear(); txtMatKhauKhoiTao.Clear(); txtXacNhanMatKhau.Clear();
            pnlNhapLieu.Visible = false; cboLocTrangThai.Visible = lblLocTrangThai.Visible = false; btnLichSuXoa.Visible = false; btnKhoiPhuc.Visible = btnThoatLichSu.Visible = true;
            colNgayXoa.Visible = true; colTrangThai.HeaderText = "Trạng thái khóa";
            lblTieuDe.Text = "Lịch sử xóa tài khoản"; lblMoTa.Text = "Tài khoản đã xóa mềm; khôi phục không thay đổi mật khẩu hoặc trạng thái khóa.";
            TaiDanhSach();
        }

        private void btnThoatLichSu_Click(object sender, EventArgs e)
        {
            dangXemLichSuXoa = false; trang = trangDanhSach; trangLichSuXoa = Math.Max(1, trang);
            txtTimKiem.Text = tuKhoaTruoc; cboLocVaiTro.SelectedItem = vaiTroTruoc; cboLocTrangThai.SelectedItem = trangThaiTruoc;
            pnlNhapLieu.Visible = true; cboLocTrangThai.Visible = lblLocTrangThai.Visible = true; btnLichSuXoa.Visible = true; btnKhoiPhuc.Visible = btnThoatLichSu.Visible = false;
            colNgayXoa.Visible = false; colTrangThai.HeaderText = "Trạng thái";
            lblTieuDe.Text = "Tài khoản và phân quyền"; lblMoTa.Text = "Tìm tài khoản, cấp tài khoản và quản lý trạng thái truy cập.";
            btnThemMoi_Click(sender, e); TaiDanhSach();
        }

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            var row = dgvTaiKhoan.CurrentRow == null ? null : dgvTaiKhoan.CurrentRow.DataBoundItem as TaiKhoanDto;
            if (!dangXemLichSuXoa || row == null || !row.IsDeleted) { btnKhoiPhuc.Enabled = false; return; }
            if (MessageBox.Show(this, "Khôi phục tài khoản '" + row.TenDangNhap + "'? Trạng thái khóa hiện tại sẽ được giữ nguyên.", "Xác nhận khôi phục", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                btnKhoiPhuc.Enabled = false; TaiKhoanService.KhoiPhucTaiKhoan(row.NguoiDungID); trangLichSuXoa = trang; TaiDanhSach();
                HienThongBao(row.TrangThai == "Đã khóa" ? "Đã khôi phục tài khoản; tài khoản vẫn đang khóa." : "Đã khôi phục tài khoản.");
            }
            catch (Exception ex) { HienThongBao(ex.Message); TaiDanhSach(); }
        }
    }
}
