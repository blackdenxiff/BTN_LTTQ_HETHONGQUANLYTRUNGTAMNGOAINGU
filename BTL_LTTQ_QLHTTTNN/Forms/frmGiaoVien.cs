using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmGiaoVien : Form
    {
        public event EventHandler TimKiemYeuCau;
        public event EventHandler LuuYeuCau;
        public event EventHandler XemLopYeuCau;
        public DataGridView BangGiaoVien { get { return dgvGiaoVien; } }
        public string TuKhoa { get { return txtTimKiem.Text.Trim(); } }
        public string MaGiaoVien { get { return txtMaGiaoVien.Text; } set { txtMaGiaoVien.Text = value; } }
        public string HoTen { get { return txtHoTen.Text.Trim(); } set { txtHoTen.Text = value; } }
        public DateTime NgaySinh { get { return dtpNgaySinh.Value.Date; } set { dtpNgaySinh.Value = value; } }
        public string SoDienThoai { get { return txtSoDienThoai.Text.Trim(); } set { txtSoDienThoai.Text = value; } }
        public string Email { get { return txtEmail.Text.Trim(); } set { txtEmail.Text = value; } }
        public string ChuyenMon { get { return txtChuyenMon.Text.Trim(); } set { txtChuyenMon.Text = value; } }
        public ComboBox GioiTinh { get { return cboGioiTinh; } }
        public ComboBox TrangThai { get { return cboTrangThai; } }
        public ComboBox LocTrangThai { get { return cboLocTrangThai; } }
        public frmGiaoVien() { InitializeComponent(); cboLocTrangThai.SelectedIndex = 0; }
        public void HienThongBao(string thongBao) { lblTrangThai.Text = thongBao; }
        private void btnThemMoi_Click(object sender, EventArgs e)
        { txtMaGiaoVien.Clear(); txtHoTen.Clear(); txtSoDienThoai.Clear(); txtEmail.Clear(); txtChuyenMon.Clear(); cboGioiTinh.SelectedIndex = -1; cboTrangThai.SelectedIndex = -1; txtHoTen.Focus(); }
        private void btnHuy_Click(object sender, EventArgs e) { btnThemMoi_Click(sender, e); }
        private void btnLuu_Click(object sender, EventArgs e)
        { if (HoTen.Length == 0) { HienThongBao("Vui lòng nhập họ tên giáo viên."); return; } if (LuuYeuCau != null) LuuYeuCau(this, EventArgs.Empty); else HienThongBao("Chưa kết nối chức năng lưu hồ sơ giáo viên."); }
        private void btnTimKiem_Click(object sender, EventArgs e)
        { if (TimKiemYeuCau != null) TimKiemYeuCau(this, EventArgs.Empty); else HienThongBao("Chưa kết nối dữ liệu giáo viên."); }
        private void btnLamMoi_Click(object sender, EventArgs e)
        { txtTimKiem.Clear(); cboLocTrangThai.SelectedIndex = 0; btnTimKiem_Click(sender, e); }
        private void btnXemLop_Click(object sender, EventArgs e)
        { if (dgvGiaoVien.CurrentRow == null) { HienThongBao("Chọn giáo viên cần xem lớp."); return; } if (XemLopYeuCau != null) XemLopYeuCau(this, EventArgs.Empty); else HienThongBao("Chưa kết nối danh sách lớp của giáo viên."); }
    }
}
