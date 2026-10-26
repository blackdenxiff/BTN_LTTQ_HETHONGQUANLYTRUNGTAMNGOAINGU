using System;
using System.Data;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmKhoaHoc : Form
    {
        public frmKhoaHoc()
        {
            InitializeComponent();
        }

        private void frmKhoaHoc_Load(object sender, EventArgs e)
        {
            DatabaseConnection.Connect();

            // 1. Neo DataGridView co dãn tràn cả 4 hướng (Trên, Dưới, Trái, Phải)
            dgvKhoaHoc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKhoaHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 2. Neo nút '+ Tạo Khóa Học Mới' luôn bám sát góc trên bên phải
            btnTaoKhoaHocMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // 3. Thiết lập tỉ lệ độ rộng các cột trên bảng khi phóng to
            if (dgvKhoaHoc.Columns.Contains("colMaKhoa")) dgvKhoaHoc.Columns["colMaKhoa"].FillWeight = 50;
            if (dgvKhoaHoc.Columns.Contains("colTenChuongTrinh")) dgvKhoaHoc.Columns["colTenChuongTrinh"].FillWeight = 160;
            if (dgvKhoaHoc.Columns.Contains("colChuanDauRa")) dgvKhoaHoc.Columns["colChuanDauRa"].FillWeight = 80;
            if (dgvKhoaHoc.Columns.Contains("colThoiLuong")) dgvKhoaHoc.Columns["colThoiLuong"].FillWeight = 60;
            if (dgvKhoaHoc.Columns.Contains("colHocPhi")) dgvKhoaHoc.Columns["colHocPhi"].FillWeight = 90;
            if (dgvKhoaHoc.Columns.Contains("colLoTrinh")) dgvKhoaHoc.Columns["colLoTrinh"].FillWeight = 160;
            if (dgvKhoaHoc.Columns.Contains("colTrangThai")) dgvKhoaHoc.Columns["colTrangThai"].FillWeight = 80;
            if (dgvKhoaHoc.Columns.Contains("colThaoTac")) dgvKhoaHoc.Columns["colThaoTac"].FillWeight = 60;
            if (dgvKhoaHoc.Columns.Contains("colXoa")) dgvKhoaHoc.Columns["colXoa"].FillWeight = 50;

            // Tải dữ liệu
            LoadThongKe();
            LoadComboBoxFilter();
            LoadDataKhoaHoc();
        }

        // 1. Nạp số liệu 4 thẻ thống kê
        private void LoadThongKe()
        {
            lblValTongKH.Text = DatabaseConnection.GetFieldValues("SELECT COUNT(*) FROM KhoaHoc WHERE IsDeleted = 0");
            lblValDangMo.Text = DatabaseConnection.GetFieldValues("SELECT COUNT(*) FROM KhoaHoc WHERE TrangThai = N'Đang mở' AND IsDeleted = 0");
            lblValLopHD.Text = DatabaseConnection.GetFieldValues("SELECT COUNT(*) FROM LopHoc WHERE TrangThai = N'Đang hoạt động'");
            lblValTongBuoi.Text = DatabaseConnection.GetFieldValues("SELECT ISNULL(SUM(SoBuoi), 0) FROM KhoaHoc WHERE IsDeleted = 0");
        }

        // 2. Nạp dữ liệu danh sách khóa học
        private void LoadDataKhoaHoc(string keyword = "", string trinhDo = "", string trangThai = "")
        {
            string sql = "SELECT KhoaHocID AS MaKhoaHoc, TenKhoaHoc, TrinhDo AS ChuanDauRa, " +
                         "SoBuoi AS ThoiLuong, HocPhi, MoTa AS LoTrinh, TrangThai " +
                         "FROM KhoaHoc WHERE IsDeleted = 0";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim();
                sql += $" AND (CAST(KhoaHocID AS NVARCHAR) LIKE N'%{kw}%' OR TenKhoaHoc LIKE N'%{kw}%')";
            }

            if (!string.IsNullOrWhiteSpace(trinhDo) && trinhDo != "-- Tất cả trình độ --")
            {
                sql += $" AND TrinhDo = N'{trinhDo}'";
            }

            if (!string.IsNullOrWhiteSpace(trangThai) && trangThai != "-- Tất cả trạng thái --")
            {
                sql += $" AND TrangThai = N'{trangThai}'";
            }

            DataTable dt = DatabaseConnection.GetDataToTable(sql);

            dgvKhoaHoc.AutoGenerateColumns = false;
            colMaKhoa.DataPropertyName = "MaKhoaHoc";
            colTenChuongTrinh.DataPropertyName = "TenKhoaHoc";
            colChuanDauRa.DataPropertyName = "ChuanDauRa";
            colThoiLuong.DataPropertyName = "ThoiLuong";
            colHocPhi.DataPropertyName = "HocPhi";
            colLoTrinh.DataPropertyName = "LoTrinh";
            colTrangThai.DataPropertyName = "TrangThai";

            dgvKhoaHoc.DataSource = dt;
        }

        // 3. Nạp danh sách ComboBox bộ lọc
        private void LoadComboBoxFilter()
        {
            cboTrinhDo.Items.Clear();
            cboTrinhDo.Items.Add("-- Tất cả trình độ --");
            DataTable dtTrinhDo = DatabaseConnection.GetDataToTable("SELECT DISTINCT TrinhDo FROM KhoaHoc WHERE TrinhDo IS NOT NULL AND IsDeleted = 0");
            foreach (DataRow r in dtTrinhDo.Rows)
            {
                cboTrinhDo.Items.Add(r["TrinhDo"].ToString());
            }
            cboTrinhDo.SelectedIndex = 0;

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("-- Tất cả trạng thái --");
            DataTable dtTrangThai = DatabaseConnection.GetDataToTable("SELECT DISTINCT TrangThai FROM KhoaHoc WHERE TrangThai IS NOT NULL AND IsDeleted = 0");
            foreach (DataRow r in dtTrangThai.Rows)
            {
                cboTrangThai.Items.Add(r["TrangThai"].ToString());
            }
            cboTrangThai.SelectedIndex = 0;
        }

        // 4. Lọc & Làm mới
        private void btnLoc_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text;
            string trinhDo = cboTrinhDo.SelectedItem?.ToString() ?? "";
            string trangThai = cboTrangThai.SelectedItem?.ToString() ?? "";

            LoadDataKhoaHoc(keyword, trinhDo, trangThai);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            if (cboTrinhDo.Items.Count > 0) cboTrinhDo.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;

            LoadDataKhoaHoc();
        }

        // 5. THÊM MỚI KHÓA HỌC
        private void btnTaoKhoaHocMoi_Click(object sender, EventArgs e)
        {
            frmChiTietKhoaHoc frm = new frmChiTietKhoaHoc(0); // ID = 0: Thêm mới
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadThongKe();
                LoadDataKhoaHoc();
            }
        }

        // 6. XỬ LÝ SỬA VÀ XÓA KHÓA HỌC TRÊN LƯỚI
        private void dgvKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dgvKhoaHoc.Columns[e.ColumnIndex].Name;

            // --- XỬ LÝ SỬA KHÓA HỌC ---
            if (columnName == "colThaoTac")
            {
                string maKhoaStr = dgvKhoaHoc.Rows[e.RowIndex].Cells["colMaKhoa"].Value?.ToString();

                if (int.TryParse(maKhoaStr, out int maKhoaID))
                {
                    frmChiTietKhoaHoc frm = new frmChiTietKhoaHoc(maKhoaID);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadThongKe();
                        LoadDataKhoaHoc();
                    }
                }
            }
            // --- XỬ LÝ XÓA KHÓA HỌC ---
            else if (columnName == "colXoa")
            {
                string maKhoaStr = dgvKhoaHoc.Rows[e.RowIndex].Cells["colMaKhoa"].Value?.ToString();
                string tenKhoa = dgvKhoaHoc.Rows[e.RowIndex].Cells["colTenChuongTrinh"].Value?.ToString();

                if (int.TryParse(maKhoaStr, out int maKhoaID))
                {
                    // 1. Kiểm tra nếu khóa học đã có Lớp học thuộc về nó
                    string checkClassSql = $"SELECT COUNT(*) FROM LopHoc WHERE KhoaHocID = {maKhoaID}";
                    int countLop = Convert.ToInt32(DatabaseConnection.GetFieldValues(checkClassSql));

                    if (countLop > 0)
                    {
                        MessageBox.Show($"Không thể xóa khóa học '{tenKhoa}' vì hiện có {countLop} lớp học đang liên kết!",
                                        "Cảnh báo xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. Xác nhận xóa từ người dùng
                    DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa khóa học '{tenKhoa}' (Mã KH: {maKhoaID}) không?",
                                                      "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        // 3. Thực hiện Xóa mềm (Soft Delete)
                        string sqlDelete = $"UPDATE KhoaHoc SET IsDeleted = 1, DeletedAt = GETDATE() WHERE KhoaHocID = {maKhoaID}";
                        DatabaseConnection.RunSQL(sqlDelete);

                        MessageBox.Show("Đã xóa khóa học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Nạp lại thông kê và lưới dữ liệu
                        LoadThongKe();
                        LoadDataKhoaHoc();
                    }
                }
            }
        }
    }
}