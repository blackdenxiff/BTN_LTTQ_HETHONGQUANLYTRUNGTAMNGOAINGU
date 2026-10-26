using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmNhapDiem : Form
    {
        public event EventHandler TaiDanhSachYeuCau;
        public event EventHandler LuuYeuCau;
        public event EventHandler LopThayDoi;
        public ComboBox LopHoc { get { return cboLop; } }
        public ComboBox LoaiDiem { get { return cboLoaiDiem; } }
        public DataGridView BangDuLieu { get { return dgvBangDiem; } }
        public frmNhapDiem() { InitializeComponent(); }
        public void HienThongBao(string thongBao) { lblTrangThai.Text = thongBao; }
        public void DatCheDoChiXem(bool chiXem)
        { dgvBangDiem.ReadOnly = chiXem; btnLuu.Visible = !chiXem; }
        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        { if (LopThayDoi != null) LopThayDoi(this, EventArgs.Empty); }
        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedIndex < 0 || cboLoaiDiem.SelectedIndex < 0)
            { HienThongBao("Chọn lớp và loại điểm trước."); return; }
            if (TaiDanhSachYeuCau != null) TaiDanhSachYeuCau(this, EventArgs.Empty);
            else HienThongBao("Chưa kết nối dữ liệu học viên theo lớp.");
        }
        private void btnLamMoi_Click(object sender, EventArgs e) { btnTaiDanhSach_Click(sender, e); }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedIndex < 0 || cboLoaiDiem.SelectedIndex < 0)
            { HienThongBao("Chọn lớp và loại điểm trước."); return; }
            if (!dgvBangDiem.EndEdit()) return;
            if (dgvBangDiem.Rows.Count == 0) { HienThongBao("Chưa có danh sách học viên."); return; }
            if (LuuYeuCau != null) LuuYeuCau(this, EventArgs.Empty);
            else HienThongBao("Chưa kết nối chức năng lưu điểm.");
        }
        private void dgvBangDiem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != colDiem.Index) return;
            string text = Convert.ToString(e.FormattedValue).Trim();
            if (text.Length == 0) return;
            decimal diem;
            if (!decimal.TryParse(text, out diem) || diem < 0 || diem > 10)
            {
                e.Cancel = true;
                dgvBangDiem.Rows[e.RowIndex].ErrorText = "Điểm phải nằm trong khoảng 0 đến 10.";
                HienThongBao("Điểm không hợp lệ. Để trống nếu chưa có điểm.");
            }
        }
        private void dgvBangDiem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        { dgvBangDiem.Rows[e.RowIndex].ErrorText = ""; }
    }
}
