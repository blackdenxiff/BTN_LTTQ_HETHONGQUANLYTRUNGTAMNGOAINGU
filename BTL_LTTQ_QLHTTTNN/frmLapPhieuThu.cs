using System;
using System.Data;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmLapPhieuThu : Form
    {
        private decimal _hocPhiGoc = 0;

        public frmLapPhieuThu()
        {
            InitializeComponent();
        }

        private void frmLapPhieuThu_Load(object sender, EventArgs e)
        {
            Functions.Connect();

            // 1. Nạp danh sách học viên (Tạo mã HV dạng HV-ID chuẩn CSDL thực tế)
            string sqlHV = @"SELECT HocVienID, 
                                   HoTen + ' (HV-' + CAST(HocVienID AS NVARCHAR) + ' • ' + ISNULL(SoDienThoai, '') + ')' AS TenHV 
                            FROM HocVien 
                            WHERE ISNULL(IsDeleted, 0) = 0";
            DataTable dtHV = Functions.GetDataToTable(sqlHV);

            DataRow drHV = dtHV.NewRow();
            drHV["HocVienID"] = 0;
            drHV["TenHV"] = "-- Chọn học viên --";
            dtHV.Rows.InsertAt(drHV, 0);

            cboHocVien.DataSource = dtHV;
            cboHocVien.DisplayMember = "TenHV";
            cboHocVien.ValueMember = "HocVienID";

            // 2. Nạp danh sách lớp học
            string sqlLop = @"SELECT l.LopHocID, l.TenLop, ISNULL(k.HocPhi, 0) AS HocPhi
                              FROM LopHoc l
                              LEFT JOIN KhoaHoc k ON l.KhoaHocID = k.KhoaHocID
                              WHERE ISNULL(l.IsDeleted, 0) = 0";
            DataTable dtLop = Functions.GetDataToTable(sqlLop);

            DataRow drLop = dtLop.NewRow();
            drLop["LopHocID"] = 0;
            drLop["TenLop"] = "-- Chọn lớp học --";
            drLop["HocPhi"] = 0;
            dtLop.Rows.InsertAt(drLop, 0);

            cboLopHoc.DataSource = dtLop;
            cboLopHoc.DisplayMember = "TenLop";
            cboLopHoc.ValueMember = "LopHocID";

            // 3. Nạp Phương thức thanh toán
            cboPhuongThuc.Items.Clear();
            cboPhuongThuc.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản ngân hàng", "Thẻ ATM / VNPAY" });
            cboPhuongThuc.SelectedIndex = 0;
        }

        // Tự động nạp mức Học phí khi chọn Lớp học
        private void cboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLopHoc.SelectedItem is DataRowView drv)
            {
                if (drv.Row.Table.Columns.Contains("HocPhi") && drv.Row["HocPhi"] != DBNull.Value)
                {
                    _hocPhiGoc = Convert.ToDecimal(drv.Row["HocPhi"]);
                    txtTongTien.Text = $"{_hocPhiGoc:N0} đ";
                    txtSoTienNop.Text = _hocPhiGoc > 0 ? _hocPhiGoc.ToString("G0") : "";
                }
            }
        }

        private void cboHocVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi chọn Học viên nếu cần
        }

        // XỬ LÝ LƯU PHIẾU THU VÀO CSDL
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboHocVien.SelectedValue == null || Convert.ToInt32(cboHocVien.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn Học viên thanh toán!", "Kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboHocVien.Focus();
                return;
            }

            if (cboLopHoc.SelectedValue == null || Convert.ToInt32(cboLopHoc.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn Lớp học thu phí!", "Kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLopHoc.Focus();
                return;
            }

            if (!decimal.TryParse(txtSoTienNop.Text.Trim(), out decimal soTienNop) || soTienNop <= 0)
            {
                MessageBox.Show("Số tiền thanh toán không hợp lệ! Vui lòng nhập số tiền hợp lệ lớn hơn 0.", "Kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTienNop.Focus();
                return;
            }

            if (_hocPhiGoc > 0 && soTienNop > _hocPhiGoc)
            {
                MessageBox.Show($"Số tiền nộp ({soTienNop:N0} đ) vượt quá mức học phí quy định ({_hocPhiGoc:N0} đ)!", "Cảnh báo dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTienNop.Focus();
                return;
            }

            int hvID = Convert.ToInt32(cboHocVien.SelectedValue);
            string trangThai = (soTienNop >= _hocPhiGoc && _hocPhiGoc > 0) ? "Đã thu đủ" : "Thanh toán 1 phần";

            // Ghi nhận thông tin số tiền thực nộp vào Ghi chú để lưu vết
            string ghiChuUser = txtGhiChu.Text.Trim();
            string ghiChuNoiDung = $"Đã nộp: {soTienNop:N0} đ" + (string.IsNullOrEmpty(ghiChuUser) ? "" : $" - {ghiChuUser}");

            // TRUYỀN _hocPhiGoc VÀO TongPhaiTra ĐỂ THỎA MÃN CHECK CONSTRAINT CK_HoaDon_Tien
            string sqlInsert = $@"INSERT INTO HoaDon (HocVienID, NhanSuLapID, NgayLap, TongTien, GiamGia, TongPhaiTra, TrangThai, GhiChu, IsDeleted, CreatedAt)
                          VALUES ({hvID}, 1, GETDATE(), {_hocPhiGoc}, 0, {_hocPhiGoc}, N'{trangThai}', N'{ghiChuNoiDung}', 0, GETDATE())";

            Functions.RunSQL(sqlInsert);
            MessageBox.Show("Lập phiếu thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}