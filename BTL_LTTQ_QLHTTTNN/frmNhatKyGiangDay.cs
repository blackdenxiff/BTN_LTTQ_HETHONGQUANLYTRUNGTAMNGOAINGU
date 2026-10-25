using System;
using System.Drawing;
using System.Windows.Forms;
using BTL_LTTQ_QLHTTTNN.Services;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmNhatKyGiangDay : Form
    {
        public event EventHandler BoLocThayDoi;
        public event EventHandler XuatExcelYeuCau;
        public event EventHandler TaiLaiYeuCau;

        public ComboBox ThangNam => cboThangNam;
        public DataGridView BangDuLieu => dgvNhatKy;
        public int NhanSuID { get; set; } = 2; // Mock ID mặc định

        public frmNhatKyGiangDay()
        {
            InitializeComponent();
            new NhatKyGiangDayPresenter(this);
        }

        public frmNhatKyGiangDay(int nhanSuId) : this()
        {
            if (nhanSuId > 0)
            {
                NhanSuID = nhanSuId;
            }
        }

        public void HienThongBao(string thongBao)
        {
            lblTongQuan.Text = thongBao;
        }

        public void CapNhatTongQuan(int tongSoBuoi)
        {
            lblTongQuan.Text = string.Format("Tổng số: {0} buổi dạy đã hoàn thành", tongSoBuoi);
        }

        private void cboThangNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            BoLocThayDoi?.Invoke(this, EventArgs.Empty);
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            TaiLaiYeuCau?.Invoke(this, EventArgs.Empty);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            XuatExcelYeuCau?.Invoke(this, EventArgs.Empty);
        }

        private void dgvNhatKy_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvNhatKy.Rows.Count) return;

            string colName = dgvNhatKy.Columns[e.ColumnIndex].Name;

            // Đổi màu cột Vắng mặt nếu có học viên vắng
            if (colName == "colVangMat" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int vang) && vang > 0)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38); // Đỏ
                    e.CellStyle.Font = new Font(dgvNhatKy.Font, FontStyle.Bold);
                }
            }
            // Đổi màu cột Có mặt
            else if (colName == "colCoMat" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int comat) && comat > 0)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74); // Xanh lá
                    e.CellStyle.Font = new Font(dgvNhatKy.Font, FontStyle.Bold);
                }
            }
        }
    }
}
