using System;
using System.Data;
using System.Globalization;
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
            try
            {
                Functions.Connect();

                // 1. Nạp danh sách học viên
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp dữ liệu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                    // Để mặc định là 0 đ để nhân viên nhập số tiền nộp thực tế
                    txtSoTienNop.Text = "0";
                }
            }
        }

        private void cboHocVien_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // XỬ LÝ LƯU PHIẾU THU VÀO CSDL
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
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

                // Kiểm tra số tiền nộp
                if (!decimal.TryParse(txtSoTienNop.Text.Trim(), out decimal soTienNop) || soTienNop < 0)
                {
                    MessageBox.Show("Số tiền thanh toán không hợp lệ! Vui lòng nhập số tiền lớn hơn hoặc bằng 0.", "Kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string tenLop = cboLopHoc.Text;

                // Tính trạng thái dựa theo số tiền nộp
                string trangThai = "Chưa thanh toán";
                if (soTienNop >= _hocPhiGoc && _hocPhiGoc > 0)
                {
                    trangThai = "Đã thu đủ";
                }
                else if (soTienNop > 0)
                {
                    trangThai = "Thanh toán 1 phần";
                }

                string ghiChuUser = txtGhiChu.Text.Trim();
                string ghiChuNoiDung = $"Lớp: {tenLop} - Đã nộp: {soTienNop:N0} đ" + (string.IsNullOrEmpty(ghiChuUser) ? "" : $" ({ghiChuUser})");

                // Định dạng số chuẩn SQL
                string strHocPhiGoc = _hocPhiGoc.ToString(CultureInfo.InvariantCulture);

                // Loại bỏ LopHocID và DaThu khớp đúng với cấu trúc bảng HoaDon
                string sqlInsert = $@"INSERT INTO HoaDon (HocVienID, NhanSuLapID, NgayLap, TongTien, GiamGia, TongPhaiTra, TrangThai, GhiChu, IsDeleted, CreatedAt)
                              VALUES ({hvID}, 1, GETDATE(), {strHocPhiGoc}, 0, {strHocPhiGoc}, N'{trangThai}', N'{ghiChuNoiDung}', 0, GETDATE())";

                Functions.RunSQL(sqlInsert);
                MessageBox.Show("Lập phiếu thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu thu: " + ex.Message, "Lỗi SQL / CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}