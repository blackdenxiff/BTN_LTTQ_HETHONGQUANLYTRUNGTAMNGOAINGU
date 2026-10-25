using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using BTL_LTTQ_QLHTTTNN.Services;

namespace BTL_LTTQ_QLHTTTNN.Forms
{
    public partial class frmThongBao : Form
    {
        // CẤU HÌNH GMAIL NGUỜI GỬI
        private static string GMAIL_ADMIN { get { return Environment.GetEnvironmentVariable("QLTT_EMAIL_ADMIN"); } }
        private static string GMAIL_APP_PASSWORD { get { return Environment.GetEnvironmentVariable("QLTT_EMAIL_APP_PASSWORD"); } }

        public frmThongBao()
        {
            InitializeComponent();
        }

        private void frmThongBao_Load(object sender, EventArgs e)
        {
            DatabaseConnection.Connect();

            // 1. Nạp danh sách Loại thông báo
            cboLoaiThongBao.Items.Clear();
            cboLoaiThongBao.Items.AddRange(new object[] {
                "Lịch học",
                "Lịch nghỉ",
                "Nhắc nhở (Học phí / Lịch thi)",
                "Thông báo chung"
            });
            cboLoaiThongBao.SelectedIndex = 0;

            // 2. Nạp danh sách Phạm vi / Đối tượng gửi
            cboPhamVi.Items.Clear();
            cboPhamVi.Items.AddRange(new object[] {
                "Cá nhân (Nhập Email / Chọn HV)",
                "Theo Lớp học",
                "Toàn trung tâm"
            });
            cboPhamVi.SelectedIndex = 0;

            // Gán sự kiện chọn Lớp học
            cboLopHoc.SelectedIndexChanged -= cboLopHoc_SelectedIndexChanged;
            cboLopHoc.SelectedIndexChanged += cboLopHoc_SelectedIndexChanged;

            // 3. Nạp dữ liệu vào các ComboBox
            LoadDropdownLopHoc();
            LoadDropdownHocVien();
            CapNhatGiaoDienPhamVi();
        }

        private void LoadDropdownLopHoc()
        {
            DataTable dtLop = DatabaseConnection.GetDataToTable("SELECT LopHocID, TenLop FROM LopHoc WHERE IsDeleted = 0");
            DataRow dr = dtLop.NewRow();
            dr["LopHocID"] = 0;
            dr["TenLop"] = "-- Chọn lớp học --";
            dtLop.Rows.InsertAt(dr, 0);

            cboLopHoc.DataSource = dtLop;
            cboLopHoc.DisplayMember = "TenLop";
            cboLopHoc.ValueMember = "LopHocID";
        }

        private void LoadDropdownHocVien(int lopHocID = 0)
        {
            string sqlHV = "SELECT HocVienID, HoTen + ' - ' + ISNULL(Email, N'Chưa có Email') AS TenHienThi, Email " +
                           "FROM HocVien WHERE IsDeleted = 0";

            if (lopHocID > 0)
            {
                // Sửa JOIN sang bảng DangKy
                sqlHV = $"SELECT hv.HocVienID, hv.HoTen + ' - ' + ISNULL(hv.Email, N'Chưa có Email') AS TenHienThi, hv.Email " +
                        $"FROM HocVien hv " +
                        $"JOIN DangKy ct ON hv.HocVienID = ct.HocVienID " +
                        $"WHERE hv.IsDeleted = 0 AND ct.LopHocID = {lopHocID}";
            }

            DataTable dtHV = DatabaseConnection.GetDataToTable(sqlHV);

            string idColumn = dtHV.Columns.Contains("HocVienID") ? "HocVienID" :
                             (dtHV.Columns.Contains("MaHocVien") ? "MaHocVien" : dtHV.Columns[0].ColumnName);

            DataRow dr = dtHV.NewRow();
            dr[idColumn] = 0;
            dr["TenHienThi"] = "-- Chọn học viên --";
            dtHV.Rows.InsertAt(dr, 0);

            cboHocVien.DataSource = dtHV;
            cboHocVien.DisplayMember = "TenHienThi";
            cboHocVien.ValueMember = idColumn;
        }

        private void cboPhamVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatGiaoDienPhamVi();
        }

        private void CapNhatGiaoDienPhamVi()
        {
            int index = cboPhamVi.SelectedIndex;

            if (index == 0) // Cá nhân
            {
                cboLopHoc.Enabled = true;
                cboHocVien.Enabled = true;
                txtEmailHocVien.Enabled = true;
            }
            else if (index == 1) // Theo Lớp học
            {
                cboLopHoc.Enabled = true;
                cboHocVien.Enabled = false;
                txtEmailHocVien.Enabled = false;
                txtEmailHocVien.Clear();
            }
            else if (index == 2) // Toàn trung tâm
            {
                cboLopHoc.Enabled = false;
                cboHocVien.Enabled = false;
                txtEmailHocVien.Enabled = false;
                txtEmailHocVien.Clear();
            }
        }

        private void cboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhamVi.SelectedIndex == 0 && cboLopHoc.SelectedValue != null)
            {
                if (int.TryParse(cboLopHoc.SelectedValue.ToString(), out int lopID))
                {
                    LoadDropdownHocVien(lopID);
                }
            }
        }

        private void cboHocVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHocVien.SelectedItem != null && cboHocVien.SelectedValue != null)
            {
                DataRowView row = cboHocVien.SelectedItem as DataRowView;
                if (row != null && row["Email"] != DBNull.Value)
                {
                    txtEmailHocVien.Text = row["Email"].ToString();
                }
            }
        }

        private void cboLoaiThongBao_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loai = cboLoaiThongBao.SelectedItem?.ToString() ?? "";

            switch (loai)
            {
                case "Lịch học":
                    txtTieuDe.Text = "[ENGLISH CENTER] Thông báo Lịch học mới";
                    txtNoiDung.Text = "Kính gửi quý học viên,\n\nTrung tâm xin thông báo thời khóa biểu chi tiết các buổi học đã được cập nhật trên hệ thống. Quý học viên vui lòng kiểm tra lịch học để tham gia đúng giờ.\n\nTrân trọng!";
                    break;

                case "Lịch nghỉ":
                    txtTieuDe.Text = "[ENGLISH CENTER] Thông báo Lịch nghỉ học tạm thời";
                    txtNoiDung.Text = "Kính gửi quý học viên,\n\nTrung tâm xin thông báo lớp học sẽ tạm thời nghỉ vào ngày [Điền ngày]. Lịch học bù sẽ được trung tâm thông báo sau.\n\nTrân trọng!";
                    break;

                case "Nhắc nhở (Học phí / Lịch thi)":
                    txtTieuDe.Text = "[ENGLISH CENTER] Nhắc nhở Lịch thi / Hoàn tất học phí";
                    txtNoiDung.Text = "Kính gửi quý học viên,\n\nTrung tâm xin nhắc bạn về [Lịch thi kiểm tra / Hạn đóng học phí] sắp tới vào ngày [Điền ngày]. Rất mong bạn chuẩn bị đầy đủ.\n\nTrân trọng!";
                    break;

                default:
                    txtTieuDe.Text = "";
                    txtNoiDung.Text = "";
                    break;
            }
        }

        private void btnGuiThongBao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GMAIL_ADMIN) || string.IsNullOrWhiteSpace(GMAIL_APP_PASSWORD))
            {
                MessageBox.Show("Chưa cấu hình email gửi. Hãy thiết lập biến môi trường QLTT_EMAIL_ADMIN và QLTT_EMAIL_APP_PASSWORD.", "Thiếu cấu hình email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tieuDe = txtTieuDe.Text.Trim();
            string noiDung = txtNoiDung.Text.Trim();

            if (string.IsNullOrWhiteSpace(tieuDe) || string.IsNullOrWhiteSpace(noiDung))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tiêu đề và Nội dung thông báo!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> danhSachEmail = new List<string>();
            int phamViIndex = cboPhamVi.SelectedIndex;

            if (phamViIndex == 0) // Cá nhân
            {
                string email = txtEmailHocVien.Text.Trim();
                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập Email của học viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmailHocVien.Focus();
                    return;
                }
                danhSachEmail.Add(email);
            }
            else if (phamViIndex == 1) // Theo Lớp học
            {
                if (cboLopHoc.SelectedValue == null || Convert.ToInt32(cboLopHoc.SelectedValue) == 0)
                {
                    MessageBox.Show("Vui lòng chọn Lớp học gửi thông báo!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int lopID = Convert.ToInt32(cboLopHoc.SelectedValue);

                // Sửa JOIN sang bảng DangKy
                string sql = $"SELECT hv.Email FROM HocVien hv " +
                             $"JOIN DangKy ct ON hv.HocVienID = ct.HocVienID " +
                             $"WHERE ct.LopHocID = {lopID} AND hv.IsDeleted = 0 AND hv.Email IS NOT NULL AND hv.Email <> ''";

                DataTable dt = DatabaseConnection.GetDataToTable(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    danhSachEmail.Add(dr["Email"].ToString());
                }
            }
            else if (phamViIndex == 2) // Toàn trung tâm
            {
                string sql = "SELECT Email FROM HocVien WHERE IsDeleted = 0 AND Email IS NOT NULL AND Email <> ''";
                DataTable dt = DatabaseConnection.GetDataToTable(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    danhSachEmail.Add(dr["Email"].ToString());
                }
            }

            if (danhSachEmail.Count == 0)
            {
                MessageBox.Show("Không tìm thấy địa chỉ Email hợp lệ nào trong danh sách nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gửi Email qua SMTP Gmail
            try
            {
                Cursor = Cursors.WaitCursor;
                int countSuccess = 0;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(GMAIL_ADMIN, GMAIL_APP_PASSWORD),
                    EnableSsl = true
                };

                foreach (string emailTarget in danhSachEmail)
                {
                    try
                    {
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress(GMAIL_ADMIN, "English Center");
                        mail.To.Add(emailTarget);
                        mail.Subject = tieuDe;
                        mail.Body = noiDung;
                        mail.IsBodyHtml = false;

                        smtp.Send(mail);
                        countSuccess++;
                    }
                    catch
                    {
                        // Bỏ qua email lỗi/không tồn tại
                    }
                }

                Cursor = Cursors.Default;
                MessageBox.Show($"Đã gửi thông báo thành công tới {countSuccess}/{danhSachEmail.Count} Email!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTieuDe.Clear();
                txtNoiDung.Clear();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Lỗi kết nối Gmail: {ex.Message}\n\nLưu ý: Kiểm tra lại Mật khẩu ứng dụng của Gmail {GMAIL_ADMIN}.", "Lỗi gửi mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtEmailHocVien.Clear();
            txtTieuDe.Clear();
            txtNoiDung.Clear();
            cboLoaiThongBao.SelectedIndex = 0;
            cboPhamVi.SelectedIndex = 0;
            cboLopHoc.SelectedIndex = 0;
            LoadDropdownHocVien();
        }
    }
}
