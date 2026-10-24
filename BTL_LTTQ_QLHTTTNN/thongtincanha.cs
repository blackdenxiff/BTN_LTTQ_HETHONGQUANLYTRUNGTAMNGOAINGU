using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class thongtincanha : Form
    {
        private int currentNhanSuID = 2; // Mock ID mặc định tương ứng với giáo viên trong CSDL

        public thongtincanha()
        {
            InitializeComponent();
        }

        public thongtincanha(int nhanSuId) : this()
        {
            if (nhanSuId > 0)
            {
                SessionContext.NhanSuID = nhanSuId;
            }
        }

        private void thongtincanha_Load(object sender, EventArgs e)
        {
            TaiThongTinGiaoVien();
        }

        /// <summary>
        /// Tự động căn giữa thẻ hồ sơ khi kích thước form thay đổi
        /// </summary>
        private void thongtincanha_Resize(object sender, EventArgs e)
        {
            if (pnlTheHoSo != null)
            {
                int left = Math.Max(25, (this.ClientSize.Width - pnlTheHoSo.Width) / 2);
                pnlTheHoSo.Location = new Point(left, 20);
            }
        }

        /// <summary>
        /// Vẽ viền nhẹ bo quanh thẻ hồ sơ cho giao diện hiện đại
        /// </summary>
        private void pnlTheHoSo_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(
                e.Graphics,
                pnlTheHoSo.ClientRectangle,
                Color.FromArgb(226, 232, 240),
                ButtonBorderStyle.Solid
            );
        }

        /// <summary>
        /// Lấy dữ liệu giáo viên hiện tại từ CSDL và hiển thị lên giao diện
        /// </summary>
        private void TaiThongTinGiaoVien()
        {
            try
            {
                // Ưu tiên lấy NhanSuID từ SessionContext, nếu chưa có thì dùng mock ID = 2
                if (SessionContext.NhanSuID > 0)
                {
                    currentNhanSuID = SessionContext.NhanSuID;
                }
                else
                {
                    currentNhanSuID = 2;
                }

                string sql = "SELECT * FROM NhanSu WHERE NhanSuID = " + currentNhanSuID;
                DataTable dt = DatabaseConnection.GetDataToTable(sql);

                // Nếu không tìm thấy dòng nào với ID chỉ định, tự động lấy giáo viên đầu tiên trong bảng
                if (dt == null || dt.Rows.Count == 0)
                {
                    string sqlFallback = "SELECT TOP 1 * FROM NhanSu WHERE LoaiNhanSu IN (N'Giáo viên', N'Cả hai')";
                    dt = DatabaseConnection.GetDataToTable(sqlFallback);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        currentNhanSuID = Convert.ToInt32(dt.Rows[0]["NhanSuID"]);
                        SessionContext.NhanSuID = currentNhanSuID;
                    }
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // 1. Họ và tên
                    txtHoTen.Text = row["HoTen"] != DBNull.Value ? row["HoTen"].ToString() : "";

                    // Cập nhật chữ cái đại diện trên Avatar
                    if (!string.IsNullOrWhiteSpace(txtHoTen.Text))
                    {
                        string[] parts = txtHoTen.Text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length >= 2)
                        {
                            lblAvatar.Text = (parts[parts.Length - 2][0].ToString() + parts[parts.Length - 1][0].ToString()).ToUpper();
                        }
                        else if (parts.Length == 1)
                        {
                            lblAvatar.Text = parts[0].Substring(0, Math.Min(2, parts[0].Length)).ToUpper();
                        }
                    }

                    // 2. Ngày sinh (định dạng dd/MM/yyyy)
                    if (row["NgaySinh"] != DBNull.Value && DateTime.TryParse(row["NgaySinh"].ToString(), out DateTime ns))
                    {
                        txtNgaySinh.Text = ns.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txtNgaySinh.Text = row["NgaySinh"] != DBNull.Value ? row["NgaySinh"].ToString() : "";
                    }

                    // 3. Giới tính
                    string gt = row["GioiTinh"] != DBNull.Value ? row["GioiTinh"].ToString().Trim() : "Nam";
                    if (!cboGioiTinh.Items.Contains(gt))
                    {
                        cboGioiTinh.Items.Add(gt);
                    }
                    cboGioiTinh.SelectedItem = gt;

                    // 4. Số điện thoại
                    txtSoDienThoai.Text = row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : "";

                    // 5. Email
                    txtEmail.Text = row["Email"] != DBNull.Value ? row["Email"].ToString() : "";

                    // 6. Chuyên môn / Trình độ
                    if (dt.Columns.Contains("ChuyenMon") && row["ChuyenMon"] != DBNull.Value)
                    {
                        txtChuyenMon.Text = row["ChuyenMon"].ToString();
                    }
                    else if (dt.Columns.Contains("TrinhDo") && row["TrinhDo"] != DBNull.Value)
                    {
                        txtChuyenMon.Text = row["TrinhDo"].ToString();
                    }
                    else
                    {
                        txtChuyenMon.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu giáo viên trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin cá nhân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý cập nhật thông tin liên hệ (Số điện thoại, Email)
        /// </summary>
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string sdt = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Ràng buộc kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            string sdtAnToan = sdt.Replace("'", "''");
            string emailAnToan = email.Replace("'", "''");

            // Chỉ cập nhật thông tin liên hệ theo yêu cầu
            string sqlUpdate = string.Format(
                "UPDATE NhanSu SET SoDienThoai = '{0}', Email = '{1}' WHERE NhanSuID = {2}",
                sdtAnToan, emailAnToan, currentNhanSuID);

            try
            {
                DatabaseConnection.RunSQL(sqlUpdate);
                MessageBox.Show("Cập nhật thông tin cá nhân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiThongTinGiaoVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút Tải lại dữ liệu từ CSDL
        /// </summary>
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            TaiThongTinGiaoVien();
        }
    }
}
