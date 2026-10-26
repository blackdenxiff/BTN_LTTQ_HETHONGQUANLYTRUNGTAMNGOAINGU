using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmChiTietKhoaHoc : Form
    {
        private int _khoaHocID = 0; // 0: Thêm mới | >0: Sửa

        // Win32 API hỗ trợ chữ mờ gợi ý (Placeholder)
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public frmChiTietKhoaHoc() : this(0) { }

        public frmChiTietKhoaHoc(int khoaHocID)
        {
            InitializeComponent();
            _khoaHocID = khoaHocID;
        }

        private void frmChiTietKhoaHoc_Load(object sender, EventArgs e)
        {
            DatabaseConnection.Connect();

            // Đặt chữ gợi ý mờ
            SendMessage(txtMaKhoaHoc.Handle, EM_SETCUEBANNER, 0, "Hệ thống tự tạo ID");
            SendMessage(txtTenKhoaHoc.Handle, EM_SETCUEBANNER, 0, "VD: Luyện Thi TOEIC 650+ Bứt Phá");
            SendMessage(txtMoTa.Handle, EM_SETCUEBANNER, 0, "Nhập mô tả tóm tắt nội dung...");

            txtMaKhoaHoc.ReadOnly = true;

            // Nạp danh sách ComboBox Trình độ
            cboTrinhDo.Items.Clear();
            cboTrinhDo.Items.AddRange(new object[] { "Sơ cấp (A1 - A2)", "Trung cấp (B1 - B2)", "Cao cấp (C1 - C2)", "TOEIC 500+", "IELTS 6.5+" });
            cboTrinhDo.SelectedIndex = 0;

            // Nạp danh sách ComboBox Trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Đang mở", "Sắp mở", "Đã đóng" });
            cboTrangThai.SelectedIndex = 0;

            if (_khoaHocID > 0)
            {
                this.Text = "📖 Chỉnh Sửa Khóa Học Đào Tạo";
                btnLuu.Text = "💾 Cập Nhật";
                txtMaKhoaHoc.Text = "KH-" + _khoaHocID.ToString("D3");
                LoadDataToEdit();
            }
            else
            {
                this.Text = "📖 Tạo Khóa Học Đào Tạo Mới";
                btnLuu.Text = "💾 Lưu Khóa Học";
                txtMaKhoaHoc.Text = "Hệ thống tự tạo";
            }
        }

        private void LoadDataToEdit()
        {
            string sql = $"SELECT TenKhoaHoc, TrinhDo, SoBuoi, HocPhi, MoTa, TrangThai FROM KhoaHoc WHERE KhoaHocID = {_khoaHocID}";
            DataTable dt = DatabaseConnection.GetDataToTable(sql);

            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                txtTenKhoaHoc.Text = r["TenKhoaHoc"].ToString();
                cboTrinhDo.SelectedItem = r["TrinhDo"].ToString();
                numSoBuoi.Value = Convert.ToDecimal(r["SoBuoi"]);
                numHocPhi.Value = Convert.ToDecimal(r["HocPhi"]);
                txtMoTa.Text = r["MoTa"].ToString();
                cboTrangThai.SelectedItem = r["TrangThai"].ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra Tên khóa học
            if (string.IsNullOrWhiteSpace(txtTenKhoaHoc.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên khóa học!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhoaHoc.Focus();
                return;
            }

            // 2. Kiểm tra Trình độ đã được chọn chưa
            if (cboTrinhDo.SelectedItem == null || string.IsNullOrWhiteSpace(cboTrinhDo.SelectedItem.ToString()))
            {
                MessageBox.Show("Vui lòng chọn Trình độ khóa học!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrinhDo.Focus();
                return;
            }

            // 3. Kiểm tra Số buổi (bắt buộc > 0)
            if (numSoBuoi.Value <= 0)
            {
                MessageBox.Show("Số buổi học phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSoBuoi.Focus();
                return;
            }

            // 4. Kiểm tra Học phí (bắt buộc > 0)
            if (numHocPhi.Value <= 0)
            {
                MessageBox.Show("Học phí phải lớn hơn 0 VNĐ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numHocPhi.Focus();
                return;
            }

            // 5. Kiểm tra Trạng thái đã được chọn chưa
            if (cboTrangThai.SelectedItem == null || string.IsNullOrWhiteSpace(cboTrangThai.SelectedItem.ToString()))
            {
                MessageBox.Show("Vui lòng chọn Trạng thái khóa học!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrangThai.Focus();
                return;
            }

            // Lấy dữ liệu khi đã hợp lệ
            string tenKhoa = txtTenKhoaHoc.Text.Trim();
            string trinhDo = cboTrinhDo.SelectedItem.ToString();
            int soBuoi = (int)numSoBuoi.Value;
            decimal hocPhi = numHocPhi.Value;
            string moTa = txtMoTa.Text.Trim();
            string trangThai = cboTrangThai.SelectedItem.ToString();

            // Tiến hành Lưu vào Database
            if (_khoaHocID == 0)
            {
                string sqlInsert = $"INSERT INTO KhoaHoc (TenKhoaHoc, TrinhDo, SoBuoi, HocPhi, MoTa, TrangThai, IsDeleted, CreatedAt) " +
                                   $"VALUES (N'{tenKhoa}', N'{trinhDo}', {soBuoi}, {hocPhi}, N'{moTa}', N'{trangThai}', 0, GETDATE())";
                DatabaseConnection.RunSQL(sqlInsert);
                MessageBox.Show("Tạo khóa học mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sqlUpdate = $"UPDATE KhoaHoc SET TenKhoaHoc = N'{tenKhoa}', TrinhDo = N'{trinhDo}', " +
                                   $"SoBuoi = {soBuoi}, HocPhi = {hocPhi}, MoTa = N'{moTa}', " +
                                   $"TrangThai = N'{trangThai}', UpdatedAt = GETDATE() " +
                                   $"WHERE KhoaHocID = {_khoaHocID}";
                DatabaseConnection.RunSQL(sqlUpdate);
                MessageBox.Show("Cập nhật thông tin khóa học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
