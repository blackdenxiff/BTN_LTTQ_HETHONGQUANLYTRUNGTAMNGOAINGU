using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmDiemDanh : Form
    {
        public event EventHandler TaiDanhSachYeuCau;
        public event EventHandler LuuYeuCau;
        public event EventHandler LopThayDoi;
        public ComboBox LopHoc { get { return cboLop; } }
        public ComboBox BuoiHoc { get { return cboBuoiHoc; } }
        public DataGridView BangDuLieu { get { return dgvDiemDanh; } }
        public frmDiemDanh() { InitializeComponent(); }
        public void HienThongBao(string thongBao) { lblTrangThai.Text = thongBao; }
        public void DatCheDoChiXem(bool chiXem)
        { dgvDiemDanh.ReadOnly = chiXem; btnLuu.Visible = !chiXem; }
        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        { if (LopThayDoi != null) LopThayDoi(this, EventArgs.Empty); }
        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedIndex < 0 || cboBuoiHoc.SelectedIndex < 0)
            { HienThongBao("Chọn lớp và buổi học trước."); return; }
            if (TaiDanhSachYeuCau != null) TaiDanhSachYeuCau(this, EventArgs.Empty);
            else HienThongBao("Chưa kết nối dữ liệu học viên theo lớp.");
        }
        private void btnLamMoi_Click(object sender, EventArgs e) { btnTaiDanhSach_Click(sender, e); }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedIndex < 0 || cboBuoiHoc.SelectedIndex < 0)
            { HienThongBao("Chọn lớp và buổi học trước."); return; }
            if (!dgvDiemDanh.EndEdit()) return;
            if (dgvDiemDanh.Rows.Count == 0) { HienThongBao("Chưa có danh sách học viên."); return; }
            if (LuuYeuCau != null) LuuYeuCau(this, EventArgs.Empty);
            else HienThongBao("Chưa kết nối chức năng lưu điểm danh.");
        }
    }
}
