using System;
using System.Data;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmChiTietLopHoc : Form
    {
        private int _lopHocID = 0; // 0: Thêm mới | >0: Chỉnh sửa

        public frmChiTietLopHoc(int lopHocID = 0)
        {
            InitializeComponent();
            _lopHocID = lopHocID;
        }

        private void frmChiTietLopHoc_Load(object sender, EventArgs e)
        {
            DatabaseConnection.Connect();

            // 1. Nạp danh sách Khóa học từ CSDL SQL Server
            DataTable dtKhoa = DatabaseConnection.GetDataToTable("SELECT KhoaHocID, TenKhoaHoc FROM KhoaHoc WHERE IsDeleted = 0");
            DataRow drKhoa = dtKhoa.NewRow();
            drKhoa["KhoaHocID"] = 0;
            drKhoa["TenKhoaHoc"] = "-- Chọn khóa học --";
            dtKhoa.Rows.InsertAt(drKhoa, 0);
            cboKhoaHoc.DataSource = dtKhoa;
            cboKhoaHoc.DisplayMember = "TenKhoaHoc";
            cboKhoaHoc.ValueMember = "KhoaHocID";

            // 2. Nạp danh sách Cơ sở
            DataTable dtCoSo = DatabaseConnection.GetDataToTable("SELECT CoSoID, TenCoSo FROM CoSo");
            DataRow drCoSo = dtCoSo.NewRow();
            drCoSo["CoSoID"] = 0;
            drCoSo["TenCoSo"] = "-- Chọn cơ sở --";
            dtCoSo.Rows.InsertAt(drCoSo, 0);
            cboCoSo.DataSource = dtCoSo;
            cboCoSo.DisplayMember = "TenCoSo";
            cboCoSo.ValueMember = "CoSoID";

            // 3. Nạp danh sách Giáo viên từ bảng NhanSu
            string sqlGV = "SELECT NhanSuID AS GiaoVienID, HoTen AS TenGiaoVien FROM NhanSu " +
                           "WHERE LoaiNhanSu = N'Giáo viên' OR LoaiNhanSu = N'Cả hai'";
            DataTable dtGiaoVien = DatabaseConnection.GetDataToTable(sqlGV);

            DataRow drGV = dtGiaoVien.NewRow();
            drGV["GiaoVienID"] = 0;
            drGV["TenGiaoVien"] = "-- Chọn giáo viên --";
            dtGiaoVien.Rows.InsertAt(drGV, 0);

            cboGiaoVien.DataSource = dtGiaoVien;
            cboGiaoVien.DisplayMember = "TenGiaoVien";
            cboGiaoVien.ValueMember = "GiaoVienID";

            // 4. Trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Sắp mở", "Đang mở", "Đã kết thúc" });
            cboTrangThai.SelectedIndex = 0;

            // 5. Phân nhánh Thêm mới hay Chỉnh sửa
            if (_lopHocID > 0)
            {
                this.Text = "Chỉnh Sửa Thông Tin Lớp Học";
                lblTieuDe.Text = "Chỉnh sửa thông tin lớp học";
                btnLuu.Text = "💾 Cập nhật";
                LoadDataToEdit();
            }
            else
            {
                this.Text = "Mở Lớp Học Mới";
                lblTieuDe.Text = "Mở lớp học mới";
                btnLuu.Text = "💾 Lưu";
                dtpNgayBatDau.Value = DateTime.Now;
                dtpNgayKetThuc.Value = DateTime.Now.AddMonths(2);
            }
        }

        // TẢI DỮ LIỆU CŨ LÊN FORM KHI BẤM SỬA
        private void LoadDataToEdit()
        {
            string sql = $"SELECT TenLop, KhoaHocID, CoSoID, GiaoVienPhuTrachID, SiSoToiDa, NgayBatDau, NgayKetThuc, TrangThai " +
                         $"FROM LopHoc WHERE LopHocID = {_lopHocID}";
            DataTable dt = DatabaseConnection.GetDataToTable(sql);

            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                txtTenLop.Text = r["TenLop"].ToString();
                cboKhoaHoc.SelectedValue = Convert.ToInt32(r["KhoaHocID"] != DBNull.Value ? r["KhoaHocID"] : 0);
                cboCoSo.SelectedValue = Convert.ToInt32(r["CoSoID"] != DBNull.Value ? r["CoSoID"] : 0);
                cboGiaoVien.SelectedValue = Convert.ToInt32(r["GiaoVienPhuTrachID"] != DBNull.Value ? r["GiaoVienPhuTrachID"] : 0);
                numSiSoToiDa.Value = Convert.ToDecimal(r["SiSoToiDa"] != DBNull.Value ? r["SiSoToiDa"] : 20);

                if (r["NgayBatDau"] != DBNull.Value) dtpNgayBatDau.Value = Convert.ToDateTime(r["NgayBatDau"]);
                if (r["NgayKetThuc"] != DBNull.Value) dtpNgayKetThuc.Value = Convert.ToDateTime(r["NgayKetThuc"]);

                if (r["TrangThai"] != DBNull.Value)
                    cboTrangThai.SelectedItem = r["TrangThai"].ToString();
            }
        }

        // THỰC THI LƯU DỮ LIỆU VÀO SQL SERVER
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return;
            }

            if (cboKhoaHoc.SelectedValue == null || Convert.ToInt32(cboKhoaHoc.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn Khóa học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoaHoc.Focus();
                return;
            }

            if (dtpNgayKetThuc.Value < dtpNgayBatDau.Value)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng Ngày bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenLop = txtTenLop.Text.Trim();
            int khoaHocID = Convert.ToInt32(cboKhoaHoc.SelectedValue);
            int coSoID = cboCoSo.SelectedValue != null ? Convert.ToInt32(cboCoSo.SelectedValue) : 1;
            int giaoVienID = cboGiaoVien.SelectedValue != null ? Convert.ToInt32(cboGiaoVien.SelectedValue) : 1;
            int siSoToiDa = (int)numSiSoToiDa.Value;
            string ngayBatDau = dtpNgayBatDau.Value.ToString("yyyy-MM-dd");
            string ngayKetThuc = dtpNgayKetThuc.Value.ToString("yyyy-MM-dd");
            string trangThai = cboTrangThai.SelectedItem?.ToString() ?? "Sắp mở";

            if (_lopHocID == 0)
            {
                // Thêm mới Lớp học
                string sqlInsert = $"INSERT INTO LopHoc (TenLop, KhoaHocID, CoSoID, GiaoVienPhuTrachID, SiSoToiDa, NgayBatDau, NgayKetThuc, TrangThai, IsDeleted) " +
                                   $"VALUES (N'{tenLop}', {khoaHocID}, {coSoID}, {giaoVienID}, {siSoToiDa}, '{ngayBatDau}', '{ngayKetThuc}', N'{trangThai}', 0)";
                DatabaseConnection.RunSQL(sqlInsert);
                MessageBox.Show("Mở lớp học mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Cập nhật Lớp học
                string sqlUpdate = $"UPDATE LopHoc SET TenLop = N'{tenLop}', KhoaHocID = {khoaHocID}, CoSoID = {coSoID}, " +
                                   $"GiaoVienPhuTrachID = {giaoVienID}, SiSoToiDa = {siSoToiDa}, NgayBatDau = '{ngayBatDau}', " +
                                   $"NgayKetThuc = '{ngayKetThuc}', TrangThai = N'{trangThai}' " +
                                   $"WHERE LopHocID = {_lopHocID}";
                DatabaseConnection.RunSQL(sqlUpdate);
                MessageBox.Show("Cập nhật thông tin lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}