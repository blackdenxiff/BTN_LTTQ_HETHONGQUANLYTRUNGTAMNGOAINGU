using System;
using System.ComponentModel;
using System.Windows.Forms;
using BTL_LTTQ_QLHTTTNN.Services;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmTaiKhoan : Form
    {
        private int trang = 1, tongTrang = 1, trangHoSo = 1, tongTrangHoSo = 1;
        private int trangDanhSach = 1;
        private bool dangXemLichSuXoa, dangNapDuLieu;
        private string tuKhoaTruoc = "", vaiTroTruoc = "Tất cả", trangThaiTruoc = "Tất cả";
        public event EventHandler TimKiemYeuCau;
        public event EventHandler LuuYeuCau;
        public event EventHandler KhoaYeuCau;
        public event EventHandler MoKhoaYeuCau;
        public DataGridView BangTaiKhoan { get { return dgvTaiKhoan; } }
        public string TuKhoa { get { return txtTimKiem.Text.Trim(); } }
        public ComboBox LocVaiTro { get { return cboLocVaiTro; } }
        public ComboBox LocTrangThai { get { return cboLocTrangThai; } }

        public frmTaiKhoan()
        {
            InitializeComponent();
            if (DangOCheDoThietKe()) return;
            cboLocVaiTro.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndex = 0;
            dgvTaiKhoan.SelectionChanged += delegate { ChonTaiKhoan(); };
            cboVaiTro.SelectedIndexChanged += delegate { if (!dangNapDuLieu && txtMaTaiKhoan.Text.Length == 0) { trangHoSo = 1; TaiHoSo(); } };
            cboHoSoLienKet.SelectedIndexChanged += delegate { HienThiHoSoDaChon(); };
            Load += frmTaiKhoan_Load;
        }

        private static bool DangOCheDoThietKe()
        { return LicenseManager.UsageMode == LicenseUsageMode.Designtime; }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        { TaiDanhSach(); }

        private void TaiDanhSach()
        {
            try
            {
                var boLoc = new TaiKhoanBoLoc { TuKhoa = TuKhoa, VaiTro = cboLocVaiTro.Text == "Tất cả" ? "" : cboLocVaiTro.Text, TrangThai = dangXemLichSuXoa ? "Tất cả" : cboLocTrangThai.Text };
                var ketQua = dangXemLichSuXoa ? TaiKhoanService.LayTaiKhoanDaXoaTheoTrang(boLoc, trang) : TaiKhoanService.LayTaiKhoanTheoTrang(boLoc, trang);
                tongTrang = Math.Max(1, ketQua.TongSoTrang);
                if (trang > tongTrang) { trang = tongTrang; ketQua = dangXemLichSuXoa ? TaiKhoanService.LayTaiKhoanDaXoaTheoTrang(boLoc, trang) : TaiKhoanService.LayTaiKhoanTheoTrang(boLoc, trang); }
                dgvTaiKhoan.DataSource = ketQua.DanhSach;
                lblPhanTrang.Text = string.Format("{0}/{1} • {2} tài khoản", ketQua.SoTrang, ketQua.TongSoTrang, ketQua.TongBanGhi);
                btnTrangTruoc.Enabled = trang > 1; btnTrangSau.Enabled = trang < tongTrang;
                btnXoaMem.Enabled = !dangXemLichSuXoa && dgvTaiKhoan.CurrentRow != null;
                btnKhoiPhuc.Enabled = dangXemLichSuXoa && dgvTaiKhoan.CurrentRow != null;
                lblTrangThai.Text = ketQua.TongBanGhi == 0 ? "Không có tài khoản phù hợp." : "Đã tải " + ketQua.DanhSach.Count + " tài khoản.";
            }
            catch (Exception ex) { HienThongBao(ex.Message); }
        }

        private void TaiHoSo()
        {
            cboHoSoLienKet.Items.Clear();
            string role = cboVaiTro.Text;
            if (string.IsNullOrWhiteSpace(role)) { cboHoSoLienKet.Enabled = false; CapNhatTrangHoSo(0); return; }
            cboHoSoLienKet.Enabled = true;
            try
            {
                int count;
                foreach (var hoSo in TaiKhoanService.LayHoSoChuaCoTaiKhoanTheoTrang(role, txtTimHoSo.Text.Trim(), trangHoSo, out count)) cboHoSoLienKet.Items.Add(hoSo);
                tongTrangHoSo = Math.Max(1, (int)Math.Ceiling(count / 10.0));
                CapNhatTrangHoSo(count);
            }
            catch (Exception ex) { HienThongBao(ex.Message); }
        }

        private void CapNhatTrangHoSo(int soLuong)
        {
            lblTrangHoSo.Text = soLuong == 0 ? "0/0" : trangHoSo + "/" + tongTrangHoSo;
            btnHoSoTruoc.Enabled = trangHoSo > 1;
            btnHoSoSau.Enabled = trangHoSo < tongTrangHoSo;
        }

        private void HienThiHoSoDaChon()
        {
            var profile = cboHoSoLienKet.SelectedItem as HoSoTaiKhoanDto;
            txtTenDangNhap.Text = profile == null ? "" : profile.TenDangNhapDuKien;
        }

        private void ChonTaiKhoan()
        {
            var row = dgvTaiKhoan.CurrentRow == null ? null : dgvTaiKhoan.CurrentRow.DataBoundItem as TaiKhoanDto;
            btnXoaMem.Enabled = !dangXemLichSuXoa && row != null && !row.IsDeleted;
            btnKhoiPhuc.Enabled = dangXemLichSuXoa && row != null && row.IsDeleted;
            btnDatLaiMatKhau.Enabled = !dangXemLichSuXoa && row != null && !row.IsDeleted;
            btnKhoa.Enabled = !dangXemLichSuXoa && row != null && row.TrangThai == "Hoạt động";
            btnMoKhoa.Enabled = !dangXemLichSuXoa && row != null && row.TrangThai == "Đã khóa";
            if (row == null || dangXemLichSuXoa) return;
            dangNapDuLieu = true;
            try
            {
                txtMaTaiKhoan.Text = row.NguoiDungID.ToString(); txtTenDangNhap.Text = row.TenDangNhap;
                cboVaiTro.SelectedItem = row.VaiTro;
                cboHoSoLienKet.Items.Clear();
                if (row.NhanSuID.HasValue || row.HocVienID.HasValue)
                {
                    int profileId = row.NhanSuID ?? row.HocVienID.Value;
                    string role = row.NhanSuID.HasValue ? row.VaiTro : "Học viên";
                    cboHoSoLienKet.Items.Add(new HoSoTaiKhoanDto { HoSoID = profileId, HoTen = row.HoTen, LoaiHoSo = role, TenDangNhapDuKien = row.TenDangNhap });
                    cboHoSoLienKet.SelectedIndex = 0;
                }
                cboHoSoLienKet.Enabled = false; cboVaiTro.Enabled = true;
                txtTimHoSo.Enabled = btnTimHoSo.Enabled = btnHoSoTruoc.Enabled = btnHoSoSau.Enabled = false;
            }
            finally { dangNapDuLieu = false; }
        }

        public void HienThongBao(string thongBao) { lblTrangThai.Text = thongBao; }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (dangXemLichSuXoa) return;
            dangNapDuLieu = true;
            try
            {
                dgvTaiKhoan.ClearSelection(); txtMaTaiKhoan.Clear(); txtTenDangNhap.Clear(); cboVaiTro.SelectedIndex = -1;
                cboHoSoLienKet.Items.Clear(); cboHoSoLienKet.Enabled = true; txtTimHoSo.Clear(); txtTimHoSo.Enabled = true;
                btnTimHoSo.Enabled = btnHoSoTruoc.Enabled = btnHoSoSau.Enabled = true; trangHoSo = 1;
                btnXoaMem.Enabled = btnKhoa.Enabled = btnMoKhoa.Enabled = btnDatLaiMatKhau.Enabled = false;
            }
            finally { dangNapDuLieu = false; }
            txtTenDangNhap.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e) { btnThemMoi_Click(sender, e); }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dangXemLichSuXoa) return;
            try
            {
                if (cboVaiTro.SelectedIndex < 0) { HienThongBao("Chọn vai trò phù hợp."); return; }
                if (txtMaTaiKhoan.Text.Length > 0)
                    TaiKhoanService.SuaTaiKhoan(new TaiKhoanSuaDto { NguoiDungID = int.Parse(txtMaTaiKhoan.Text), VaiTro = cboVaiTro.Text });
                else
                {
                    if (cboVaiTro.Text == "Admin") { HienThongBao("Tài khoản Admin không cấp qua hồ sơ học viên hoặc nhân sự."); return; }
                    var profile = cboHoSoLienKet.SelectedItem as HoSoTaiKhoanDto;
                    if (profile == null) { HienThongBao("Chọn hồ sơ trước khi cấp tài khoản."); return; }
                    TaiKhoanService.TaoTaiKhoan(new TaiKhoanTaoDto { HoSoID = profile.HoSoID, VaiTro = cboVaiTro.Text });
                }
                HienThongBao("Đã lưu tài khoản. Tài khoản mới yêu cầu đổi mật khẩu ở lần đăng nhập đầu tiên.");
                btnThemMoi_Click(sender, e); trang = 1; TaiDanhSach();
            }
            catch (Exception ex) { HienThongBao(ex.Message); }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        { trang = 1; TaiDanhSach(); if (TimKiemYeuCau != null) TimKiemYeuCau(this, EventArgs.Empty); }

        private void btnLamMoi_Click(object sender, EventArgs e)
        { txtTimKiem.Clear(); cboLocVaiTro.SelectedIndex = 0; cboLocTrangThai.SelectedIndex = 0; trang = 1; TaiDanhSach(); }

        private void btnKhoa_Click(object sender, EventArgs e)
        { if (dangXemLichSuXoa) return; try { TaiKhoanService.DoiTrangThaiTaiKhoan(ChonID(), true); TaiDanhSach(); } catch (Exception ex) { HienThongBao(ex.Message); } }
        private void btnMoKhoa_Click(object sender, EventArgs e)
        { if (dangXemLichSuXoa) return; try { TaiKhoanService.DoiTrangThaiTaiKhoan(ChonID(), false); TaiDanhSach(); } catch (Exception ex) { HienThongBao(ex.Message); } }
        private int ChonID() { var row = dgvTaiKhoan.CurrentRow == null ? null : dgvTaiKhoan.CurrentRow.DataBoundItem as TaiKhoanDto; if (row == null) throw new InvalidOperationException("Chọn tài khoản cần thao tác."); return row.NguoiDungID; }

        private void btnXoaMem_Click(object sender, EventArgs e)
        {
            if (dangXemLichSuXoa) return;
            try { int id = ChonID(); if (MessageBox.Show(this, "Đánh dấu tài khoản này là đã xóa?", "Xóa mềm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { TaiKhoanService.XoaMemTaiKhoan(id); trang = 1; TaiDanhSach(); } }
            catch (Exception ex) { HienThongBao(ex.Message); }
        }

        private void btnDatLaiMatKhau_Click(object sender, EventArgs e)
        {
            if (dangXemLichSuXoa) return;
            try
            {
                int id = ChonID();
                if (MessageBox.Show(this, "Đặt lại mật khẩu cho tài khoản đã chọn? Mật khẩu mặc định theo ngày sinh dạng ddMMyyyy; nếu không có ngày sinh, dùng 12345678. Tài khoản vẫn giữ trạng thái khóa hiện tại.", "Xác nhận đặt lại mật khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
                TaiKhoanService.DatLaiMatKhauMacDinh(id);
                HienThongBao("Đã đặt lại mật khẩu. Người dùng cần đổi mật khẩu ở lần đăng nhập tiếp theo.");
            }
            catch (Exception ex) { HienThongBao(ex.Message); }
        }

        private void btnCapTaiKhoanHangLoat_Click(object sender, EventArgs e)
        {
            if (dangXemLichSuXoa) return;
            using (var form = new frmCapTaiKhoanHangLoat())
                if (form.ShowDialog(this) == DialogResult.OK) { trang = 1; TaiDanhSach(); HienThongBao(form.ThongBaoKetQua); }
        }

        private void btnLichSuXoa_Click(object sender, EventArgs e)
        {
            tuKhoaTruoc = txtTimKiem.Text; vaiTroTruoc = cboLocVaiTro.Text; trangThaiTruoc = cboLocTrangThai.Text; trangDanhSach = trang;
            dangXemLichSuXoa = true; trang = 1; dgvTaiKhoan.ClearSelection(); dgvTaiKhoan.DataSource = null;
            pnlNhapLieu.Visible = false; cboLocTrangThai.Visible = lblLocTrangThai.Visible = false;
            btnCapTaiKhoanHangLoat.Visible = false;
            btnLichSuXoa.Visible = false; btnKhoiPhuc.Visible = btnThoatLichSu.Visible = true; colNgayXoa.Visible = true; colTrangThai.HeaderText = "Trạng thái khóa";
            lblTieuDe.Text = "Lịch sử xóa tài khoản"; lblMoTa.Text = "Khôi phục không đổi mật khẩu và không tự mở khóa tài khoản."; TaiDanhSach();
        }

        private void btnThoatLichSu_Click(object sender, EventArgs e)
        {
            dangXemLichSuXoa = false; trang = trangDanhSach;
            txtTimKiem.Text = tuKhoaTruoc; cboLocVaiTro.SelectedItem = vaiTroTruoc; cboLocTrangThai.SelectedItem = trangThaiTruoc;
            pnlNhapLieu.Visible = true; cboLocTrangThai.Visible = lblLocTrangThai.Visible = true;
            btnCapTaiKhoanHangLoat.Visible = true;
            btnLichSuXoa.Visible = true; btnKhoiPhuc.Visible = btnThoatLichSu.Visible = false; colNgayXoa.Visible = false; colTrangThai.HeaderText = "Trạng thái";
            lblTieuDe.Text = "Tài khoản và phân quyền"; lblMoTa.Text = "Tìm tài khoản, cấp tài khoản và quản lý trạng thái truy cập.";
            btnThemMoi_Click(sender, e); TaiDanhSach();
        }

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            var row = dgvTaiKhoan.CurrentRow == null ? null : dgvTaiKhoan.CurrentRow.DataBoundItem as TaiKhoanDto;
            if (!dangXemLichSuXoa || row == null || !row.IsDeleted) { btnKhoiPhuc.Enabled = false; return; }
            if (MessageBox.Show(this, "Khôi phục tài khoản '" + row.TenDangNhap + "'? Trạng thái khóa sẽ được giữ nguyên.", "Xác nhận khôi phục", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try { TaiKhoanService.KhoiPhucTaiKhoan(row.NguoiDungID); TaiDanhSach(); HienThongBao(row.TrangThai == "Đã khóa" ? "Đã khôi phục; tài khoản vẫn khóa." : "Đã khôi phục tài khoản."); }
            catch (Exception ex) { HienThongBao(ex.Message); TaiDanhSach(); }
        }

        private void btnTrangTruoc_Click(object sender, EventArgs e) { if (trang > 1) { trang--; TaiDanhSach(); } }
        private void btnTrangSau_Click(object sender, EventArgs e) { if (trang < tongTrang) { trang++; TaiDanhSach(); } }
        private void btnTimHoSo_Click(object sender, EventArgs e) { trangHoSo = 1; TaiHoSo(); }
        private void btnHoSoTruoc_Click(object sender, EventArgs e) { if (trangHoSo > 1) { trangHoSo--; TaiHoSo(); } }
        private void btnHoSoSau_Click(object sender, EventArgs e) { if (trangHoSo < tongTrangHoSo) { trangHoSo++; TaiHoSo(); } }
    }
}
