using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BTL_LTTQ_QLHTTTNN.Services;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmChiTietLopHoc : Form
    {
        private int _lopHocID = 0;

        public frmChiTietLopHoc() : this(0) { }

        public frmChiTietLopHoc(int lopHocID)
        {
            InitializeComponent();
            _lopHocID = lopHocID;
        }

        private void frmChiTietLopHoc_Load(object sender, EventArgs e)
        {
            DatabaseConnection.Connect();

            // 1. Nạp danh sách Khóa học
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

            // 3. Nạp danh sách Giáo viên
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

            // 4. Nạp Trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Sắp mở", "Đang mở", "Đã kết thúc" });
            cboTrangThai.SelectedIndex = 0;

            // 5. Kiểm tra chế độ Xem / Thêm / Sửa
            if (_lopHocID > 0)
            {
                this.Text = "Chỉnh Sửa Thông Tin Lớp Học";
                lblTieuDe.Text = "Chỉnh sửa thông tin lớp học";
                btnLuu.Text = "💾 Cập nhật";
                LoadDataToEdit();
                LoadDanhSachHocVien();
            }
            else
            {
                this.Text = "Mở Lớp Học Mới";
                lblTieuDe.Text = "Mở lớp học mới";
                btnLuu.Text = "💾 Lưu";
                dtpNgayBatDau.Value = DateTime.Now;
                dtpNgayKetThuc.Value = DateTime.Now.AddMonths(2);
            }

            // 6. PHÂN QUYỀN CHỈ XEM CHO GIÁO VIÊN VÀ HỌC VIÊN
            var user = SessionContext.NguoiDungHienTai;
            bool isQuanLy = (user != null && (user.VaiTro == "Admin" || user.VaiTro == "Nhân viên"));

            if (!isQuanLy)
            {
                this.Text = "Chi Tiết Thông Tin Lớp Học";
                lblTieuDe.Text = "Chi tiết thông tin lớp học";

                btnLuu.Visible = false;
                btnDong.Text = "✕ Đóng";

                txtTenLop.ReadOnly = true;
                cboKhoaHoc.Enabled = false;
                cboCoSo.Enabled = false;
                cboGiaoVien.Enabled = false;
                numSiSoToiDa.Enabled = false;
                dtpNgayBatDau.Enabled = false;
                dtpNgayKetThuc.Enabled = false;
                cboTrangThai.Enabled = false;
            }
        }

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

        // TẢI DANH SÁCH HỌC VIÊN VÀ Che THÔNG TIN CÁ NHÂN VỚI GV / HV
        private void LoadDanhSachHocVien()
        {
            if (_lopHocID <= 0) return;

            try
            {
                string sql = $@"SELECT hv.HocVienID, 
                                       'HV-' + RIGHT('000' + CAST(hv.HocVienID AS VARCHAR), 4) AS MaHocVien,
                                       hv.HoTen, 
                                       hv.GioiTinh, 
                                       CONVERT(VARCHAR(10), hv.NgaySinh, 103) AS NgaySinh, 
                                       hv.SoDienThoai, 
                                       hv.Email 
                                FROM HocVien hv
                                JOIN DangKy dk ON hv.HocVienID = dk.HocVienID
                                WHERE dk.LopHocID = {_lopHocID} AND (hv.IsDeleted = 0 OR hv.IsDeleted IS NULL)";

                DataTable dt = DatabaseConnection.GetDataToTable(sql);

                if (dt == null || dt.Rows.Count == 0)
                {
                    sql = $@"SELECT hv.HocVienID, 
                                   'HV-' + RIGHT('000' + CAST(hv.HocVienID AS VARCHAR), 4) AS MaHocVien,
                                   hv.HoTen, 
                                   hv.GioiTinh, 
                                   CONVERT(VARCHAR(10), hv.NgaySinh, 103) AS NgaySinh, 
                                   hv.SoDienThoai, 
                                   hv.Email 
                            FROM HocVien hv
                            JOIN ChiTietLopHoc ct ON hv.HocVienID = ct.HocVienID
                            WHERE ct.LopHocID = {_lopHocID} AND (hv.IsDeleted = 0 OR hv.IsDeleted IS NULL)";

                    dt = DatabaseConnection.GetDataToTable(sql);
                }

                if (dgvHocVien != null)
                {
                    dgvHocVien.DataSource = dt;

                    // Đổi tên cột hiển thị
                    if (dgvHocVien.Columns.Contains("HocVienID")) dgvHocVien.Columns["HocVienID"].Visible = false;
                    if (dgvHocVien.Columns.Contains("MaHocVien")) dgvHocVien.Columns["MaHocVien"].HeaderText = "Mã HV";
                    if (dgvHocVien.Columns.Contains("HoTen")) dgvHocVien.Columns["HoTen"].HeaderText = "Họ và Tên";
                    if (dgvHocVien.Columns.Contains("GioiTinh")) dgvHocVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
                    if (dgvHocVien.Columns.Contains("NgaySinh")) dgvHocVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    if (dgvHocVien.Columns.Contains("SoDienThoai")) dgvHocVien.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                    if (dgvHocVien.Columns.Contains("Email")) dgvHocVien.Columns["Email"].HeaderText = "Email";

                    // NẾU LÀ GIÁO VIÊN HOẶC HỌC VIÊN -> CHE (ẨN) CÁC CỘT TỪ NGÀY SINH SANG PHẢI
                    var user = SessionContext.NguoiDungHienTai;
                    bool isQuanLy = (user != null && (user.VaiTro == "Admin" || user.VaiTro == "Nhân viên"));

                    if (!isQuanLy)
                    {
                        if (dgvHocVien.Columns.Contains("NgaySinh")) dgvHocVien.Columns["NgaySinh"].Visible = false;
                        if (dgvHocVien.Columns.Contains("SoDienThoai")) dgvHocVien.Columns["SoDienThoai"].Visible = false;
                        if (dgvHocVien.Columns.Contains("Email")) dgvHocVien.Columns["Email"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy danh sách học viên trong lớp: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra Tên lớp
            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return;
            }

            // 2. Kiểm tra Khóa học (bắt buộc phải chọn, khác giá trị mặc định 0)
            if (cboKhoaHoc.SelectedValue == null || Convert.ToInt32(cboKhoaHoc.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn Khóa học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoaHoc.Focus();
                return;
            }

            // 3. Kiểm tra Cơ sở (bắt buộc phải chọn, khác giá trị mặc định 0)
            if (cboCoSo.SelectedValue == null || Convert.ToInt32(cboCoSo.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn Cơ sở học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCoSo.Focus();
                return;
            }

            // 4. Kiểm tra Giáo viên phụ trách (bắt buộc phải chọn, khác giá trị mặc định 0)
            if (cboGiaoVien.SelectedValue == null || Convert.ToInt32(cboGiaoVien.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn Giáo viên phụ trách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGiaoVien.Focus();
                return;
            }

            // 5. Kiểm tra Sĩ số tối đa (bắt buộc lớn hơn 0)
            if (numSiSoToiDa.Value <= 0)
            {
                MessageBox.Show("Sĩ số tối đa phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSiSoToiDa.Focus();
                return;
            }

            // 6. Kiểm tra Ngày kết thúc so với Ngày bắt đầu
            if (dtpNgayKetThuc.Value < dtpNgayBatDau.Value)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng Ngày bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayKetThuc.Focus();
                return;
            }

            // 7. Kiểm tra Trạng thái lớp học
            if (cboTrangThai.SelectedItem == null || string.IsNullOrWhiteSpace(cboTrangThai.SelectedItem.ToString()))
            {
                MessageBox.Show("Vui lòng chọn Trạng thái lớp học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrangThai.Focus();
                return;
            }

            // --- Lấy dữ liệu khi đã hợp lệ ---
            string tenLop = txtTenLop.Text.Trim();
            int khoaHocID = Convert.ToInt32(cboKhoaHoc.SelectedValue);
            int coSoID = Convert.ToInt32(cboCoSo.SelectedValue);
            int giaoVienID = Convert.ToInt32(cboGiaoVien.SelectedValue);
            int siSoToiDa = (int)numSiSoToiDa.Value;
            string ngayBatDau = dtpNgayBatDau.Value.ToString("yyyy-MM-dd");
            string ngayKetThuc = dtpNgayKetThuc.Value.ToString("yyyy-MM-dd");
            string trangThai = cboTrangThai.SelectedItem.ToString();

            // --- Thực hiện lưu vào Cơ sở dữ liệu ---
            if (_lopHocID == 0)
            {
                string sqlInsert = $"INSERT INTO LopHoc (TenLop, KhoaHocID, CoSoID, GiaoVienPhuTrachID, SiSoToiDa, NgayBatDau, NgayKetThuc, TrangThai, IsDeleted) " +
                                   $"VALUES (N'{tenLop}', {khoaHocID}, {coSoID}, {giaoVienID}, {siSoToiDa}, '{ngayBatDau}', '{ngayKetThuc}', N'{trangThai}', 0)";
                DatabaseConnection.RunSQL(sqlInsert);
                MessageBox.Show("Mở lớp học mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
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