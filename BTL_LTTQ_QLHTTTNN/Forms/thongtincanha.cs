using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using BTL_LTTQ_QLHTTTNN.Services;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class thongtincanha : Form
    {
        private int currentNhanSuID = 2; // Mock ID mặc định tương ứng với giáo viên trong CSDL

        // Các control cho phần Dashboard (Lịch dạy & Thống kê) được tạo bằng code
        private Panel pnlDashboard;
        private Label lblTieuDeDashboard;
        private Label lblPhuDeDashboard;
        private Panel pnlNganCachDashboard;
        private Panel pnlCardLopHoc;
        private Label lblTitleCardLop;
        public Label lblTongSoLop;
        private Label lblMoTaTongSoLop;
        private Panel pnlCardCaDay;
        private Label lblTitleCardCaDay;
        public Label lblSoCaDay;
        private Label lblMoTaNgayHoc;
        private Label lblTieuDeBang;
        public DataGridView dgvLichHomNay;
        private Label lblKhongCoLich;

        public thongtincanha()
        {
            InitializeComponent();
            KhoiTaoDashboard();
        }

        public thongtincanha(int nhanSuId) : this()
        {
            if (nhanSuId > 0)
            {
                currentNhanSuID = nhanSuId;
            }
        }

        /// <summary>
        /// Khởi tạo giao diện Dashboard thống kê và lịch dạy hôm nay
        /// </summary>
        private void KhoiTaoDashboard()
        {
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(910, 960);

            // Container Panel Dashboard
            pnlDashboard = new Panel();
            pnlDashboard.BackColor = Color.White;
            pnlDashboard.Size = new Size(860, 430);
            pnlDashboard.Location = new Point(pnlTheHoSo != null ? pnlTheHoSo.Left : 30, 505);
            pnlDashboard.Paint += pnlDashboard_Paint;

            // 1. Tiêu đề Dashboard
            lblTieuDeDashboard = new Label();
            lblTieuDeDashboard.AutoSize = true;
            lblTieuDeDashboard.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTieuDeDashboard.ForeColor = Color.FromArgb(15, 23, 42);
            lblTieuDeDashboard.Location = new Point(35, 20);
            lblTieuDeDashboard.Text = "LỊCH DẠY VÀ HOẠT ĐỘNG HÔM NAY";

            // Phụ đề Dashboard
            lblPhuDeDashboard = new Label();
            lblPhuDeDashboard.AutoSize = true;
            lblPhuDeDashboard.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblPhuDeDashboard.ForeColor = Color.FromArgb(100, 116, 139);
            lblPhuDeDashboard.Location = new Point(35, 52);
            lblPhuDeDashboard.Text = "Theo dõi các ca giảng dạy trong ngày và các lớp học đang phụ trách";

            // Đường phân cách
            pnlNganCachDashboard = new Panel();
            pnlNganCachDashboard.BackColor = Color.FromArgb(226, 232, 240);
            pnlNganCachDashboard.Location = new Point(35, 80);
            pnlNganCachDashboard.Size = new Size(790, 1);

            // 2. Thẻ Thống kê 1: Tổng số lớp đang phụ trách
            pnlCardLopHoc = new Panel();
            pnlCardLopHoc.BackColor = Color.FromArgb(240, 249, 255);
            pnlCardLopHoc.Location = new Point(35, 95);
            pnlCardLopHoc.Size = new Size(385, 75);
            pnlCardLopHoc.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, pnlCardLopHoc.ClientRectangle, Color.FromArgb(186, 230, 253), ButtonBorderStyle.Solid);
            };

            lblTitleCardLop = new Label();
            lblTitleCardLop.AutoSize = true;
            lblTitleCardLop.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTitleCardLop.ForeColor = Color.FromArgb(3, 105, 161);
            lblTitleCardLop.Location = new Point(14, 12);
            lblTitleCardLop.Text = "LỚP HỌC ĐANG PHỤ TRÁCH";

            lblTongSoLop = new Label();
            lblTongSoLop.AutoSize = true;
            lblTongSoLop.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTongSoLop.ForeColor = Color.FromArgb(2, 132, 199);
            lblTongSoLop.Location = new Point(12, 32);
            lblTongSoLop.Text = "0 lớp";

            lblMoTaTongSoLop = new Label();
            lblMoTaTongSoLop.AutoSize = true;
            lblMoTaTongSoLop.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            lblMoTaTongSoLop.ForeColor = Color.FromArgb(100, 116, 139);
            lblMoTaTongSoLop.Location = new Point(120, 42);
            lblMoTaTongSoLop.Text = "Tổng số lớp đang giảng dạy";

            pnlCardLopHoc.Controls.Add(lblTitleCardLop);
            pnlCardLopHoc.Controls.Add(lblTongSoLop);
            pnlCardLopHoc.Controls.Add(lblMoTaTongSoLop);

            // 3. Thẻ Thống kê 2: Ca dạy trong ngày
            pnlCardCaDay = new Panel();
            pnlCardCaDay.BackColor = Color.FromArgb(240, 253, 244);
            pnlCardCaDay.Location = new Point(440, 95);
            pnlCardCaDay.Size = new Size(385, 75);
            pnlCardCaDay.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, pnlCardCaDay.ClientRectangle, Color.FromArgb(187, 247, 208), ButtonBorderStyle.Solid);
            };

            lblTitleCardCaDay = new Label();
            lblTitleCardCaDay.AutoSize = true;
            lblTitleCardCaDay.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTitleCardCaDay.ForeColor = Color.FromArgb(21, 128, 61);
            lblTitleCardCaDay.Location = new Point(14, 12);
            lblTitleCardCaDay.Text = "CA DẠY TRONG NGÀY";

            lblSoCaDay = new Label();
            lblSoCaDay.AutoSize = true;
            lblSoCaDay.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblSoCaDay.ForeColor = Color.FromArgb(22, 163, 74);
            lblSoCaDay.Location = new Point(12, 32);
            lblSoCaDay.Text = "0 ca";

            lblMoTaNgayHoc = new Label();
            lblMoTaNgayHoc.AutoSize = true;
            lblMoTaNgayHoc.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            lblMoTaNgayHoc.ForeColor = Color.FromArgb(100, 116, 139);
            lblMoTaNgayHoc.Location = new Point(120, 42);
            lblMoTaNgayHoc.Text = "Hôm nay: " + DateTime.Today.ToString("dd/MM/yyyy");

            pnlCardCaDay.Controls.Add(lblTitleCardCaDay);
            pnlCardCaDay.Controls.Add(lblSoCaDay);
            pnlCardCaDay.Controls.Add(lblMoTaNgayHoc);

            // 4. Tiêu đề bảng lịch học
            lblTieuDeBang = new Label();
            lblTieuDeBang.AutoSize = true;
            lblTieuDeBang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTieuDeBang.ForeColor = Color.FromArgb(30, 41, 59);
            lblTieuDeBang.Location = new Point(35, 185);
            lblTieuDeBang.Text = "Chi tiết lịch dạy hôm nay:";

            // 5. DataGridView dgvLichHomNay
            dgvLichHomNay = new DataGridView();
            dgvLichHomNay.AutoGenerateColumns = false;
            dgvLichHomNay.AllowUserToAddRows = false;
            dgvLichHomNay.AllowUserToDeleteRows = false;
            dgvLichHomNay.AllowUserToResizeRows = false;
            dgvLichHomNay.ReadOnly = true;
            dgvLichHomNay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLichHomNay.MultiSelect = false;
            dgvLichHomNay.RowHeadersVisible = false;
            dgvLichHomNay.BackgroundColor = Color.White;
            dgvLichHomNay.BorderStyle = BorderStyle.FixedSingle;
            dgvLichHomNay.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLichHomNay.GridColor = Color.FromArgb(226, 232, 240);
            dgvLichHomNay.EnableHeadersVisualStyles = false;
            dgvLichHomNay.ColumnHeadersHeight = 34;
            dgvLichHomNay.RowTemplate.Height = 32;
            dgvLichHomNay.Location = new Point(35, 212);
            dgvLichHomNay.Size = new Size(790, 175);
            dgvLichHomNay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvLichHomNay.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvLichHomNay.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgvLichHomNay.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            dgvLichHomNay.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvLichHomNay.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvLichHomNay.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 231, 255);
            dgvLichHomNay.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);

            dgvLichHomNay.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            // Thêm các cột cho dgvLichHomNay
            var colTenLop = new DataGridViewTextBoxColumn
            {
                Name = "colTenLop",
                HeaderText = "Tên Lớp",
                DataPropertyName = "TenLop",
                FillWeight = 38
            };
            var colPhongHoc = new DataGridViewTextBoxColumn
            {
                Name = "colPhongHoc",
                HeaderText = "Phòng Học",
                DataPropertyName = "PhongHoc",
                FillWeight = 24
            };
            var colGioBatDau = new DataGridViewTextBoxColumn
            {
                Name = "colGioBatDau",
                HeaderText = "Giờ Bắt Đầu",
                DataPropertyName = "GioBatDau",
                FillWeight = 19
            };
            colGioBatDau.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var colGioKetThuc = new DataGridViewTextBoxColumn
            {
                Name = "colGioKetThuc",
                HeaderText = "Giờ Kết Thúc",
                DataPropertyName = "GioKetThuc",
                FillWeight = 19
            };
            colGioKetThuc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvLichHomNay.Columns.AddRange(new DataGridViewColumn[] {
                colTenLop,
                colPhongHoc,
                colGioBatDau,
                colGioKetThuc
            });

            // 6. Label thông báo khi không có lịch
            lblKhongCoLich = new Label();
            lblKhongCoLich.AutoSize = false;
            lblKhongCoLich.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblKhongCoLich.ForeColor = Color.FromArgb(100, 116, 139);
            lblKhongCoLich.Location = new Point(35, 392);
            lblKhongCoLich.Size = new Size(790, 25);
            lblKhongCoLich.TextAlign = ContentAlignment.MiddleLeft;
            lblKhongCoLich.Text = "✨ Hôm nay không có ca dạy nào được xếp lịch. Chúc bạn một ngày làm việc hiệu quả!";
            lblKhongCoLich.Visible = false;

            // Thêm tất cả vào pnlDashboard
            pnlDashboard.Controls.Add(lblTieuDeDashboard);
            pnlDashboard.Controls.Add(lblPhuDeDashboard);
            pnlDashboard.Controls.Add(pnlNganCachDashboard);
            pnlDashboard.Controls.Add(pnlCardLopHoc);
            pnlDashboard.Controls.Add(pnlCardCaDay);
            pnlDashboard.Controls.Add(lblTieuDeBang);
            pnlDashboard.Controls.Add(dgvLichHomNay);
            pnlDashboard.Controls.Add(lblKhongCoLich);

            // Thêm pnlDashboard vào Form
            this.Controls.Add(pnlDashboard);
        }

        private void thongtincanha_Load(object sender, EventArgs e)
        {
            TaiThongTinGiaoVien();
            TaiThongKeVaLichDay();
        }

        /// <summary>
        /// Tự động căn giữa thẻ hồ sơ và bảng dashboard khi kích thước form thay đổi
        /// </summary>
        private void thongtincanha_Resize(object sender, EventArgs e)
        {
            if (pnlTheHoSo != null)
            {
                int left = Math.Max(25, (this.ClientSize.Width - pnlTheHoSo.Width) / 2);
                pnlTheHoSo.Location = new Point(left, 20);
                if (pnlDashboard != null)
                {
                    pnlDashboard.Location = new Point(left, pnlTheHoSo.Bottom + 20);
                }
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
        /// Vẽ viền thẻ Dashboard
        /// </summary>
        private void pnlDashboard_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(
                e.Graphics,
                pnlDashboard.ClientRectangle,
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
                if (SessionContext.NguoiDungHienTai != null && SessionContext.NguoiDungHienTai.NhanSuID.HasValue && SessionContext.NguoiDungHienTai.NhanSuID.Value > 0)
                {
                    currentNhanSuID = SessionContext.NguoiDungHienTai.NhanSuID.Value;
                }
                else if (currentNhanSuID <= 0)
                {
                    currentNhanSuID = 2;
                }

                DataTable dt = new DataTable();
                using (SqlConnection con = DatabaseConnection.TaoKetNoi())
                {
                    con.Open();
                    string sql = "SELECT * FROM NhanSu WHERE NhanSuID = @NhanSuID";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@NhanSuID", currentNhanSuID);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }

                    // Nếu không tìm thấy dòng nào với ID chỉ định, tự động lấy giáo viên đầu tiên trong bảng
                    if (dt.Rows.Count == 0)
                    {
                        string sqlFallback = "SELECT TOP 1 * FROM NhanSu WHERE LoaiNhanSu IN (N'Giáo viên', N'Cả hai')";
                        using (SqlCommand cmdFallback = new SqlCommand(sqlFallback, con))
                        {
                            using (SqlDataAdapter daFallback = new SqlDataAdapter(cmdFallback))
                            {
                                daFallback.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    currentNhanSuID = Convert.ToInt32(dt.Rows[0]["NhanSuID"]);
                                }
                            }
                        }
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
        /// Tải số liệu thống kê lớp phụ trách và danh sách lịch dạy hôm nay từ CSDL
        /// </summary>
        private void TaiThongKeVaLichDay()
        {
            try
            {
                int nhanSuId = currentNhanSuID;
                if (SessionContext.NguoiDungHienTai != null && SessionContext.NguoiDungHienTai.NhanSuID.HasValue && SessionContext.NguoiDungHienTai.NhanSuID.Value > 0)
                {
                    nhanSuId = SessionContext.NguoiDungHienTai.NhanSuID.Value;
                }

                // Truy vấn 1: Đếm tổng số lớp mà giáo viên này đang phụ trách từ bảng LopHoc (COUNT)
                int tongSoLop = 0;
                using (SqlConnection con = DatabaseConnection.TaoKetNoi())
                {
                    con.Open();
                    string sqlCount = "SELECT COUNT(*) FROM LopHoc WHERE GiaoVienPhuTrachID = @NhanSuID";
                    using (SqlCommand cmd = new SqlCommand(sqlCount, con))
                    {
                        cmd.Parameters.AddWithValue("@NhanSuID", nhanSuId);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            tongSoLop = Convert.ToInt32(result);
                        }
                    }
                }
                if (lblTongSoLop != null)
                {
                    lblTongSoLop.Text = tongSoLop.ToString() + " lớp";
                }
                if (lblMoTaTongSoLop != null)
                {
                    lblMoTaTongSoLop.Text = "Tổng số lớp đang phụ trách: " + tongSoLop;
                }

                // Truy vấn 2: Lấy danh sách lịch học TRONG NGÀY HÔM NAY từ bảng LichHoc JOIN LopHoc
                // Điều kiện: GiaoVienPhuTrachID = @NhanSuID VÀ CONVERT(date, NgayHoc) = CONVERT(date, GETDATE())
                DataTable dtLich = new DataTable();
                using (SqlConnection con = DatabaseConnection.TaoKetNoi())
                {
                    con.Open();
                    string sqlLich = @"
                        SELECT 
                            lh.TenLop,
                            ISNULL(ph.TenPhong, N'Phòng ' + CAST(lic.PhongHocID AS nvarchar(10))) AS PhongHoc,
                            CONVERT(varchar(5), lic.GioBatDau) AS GioBatDau,
                            CONVERT(varchar(5), lic.GioKetThuc) AS GioKetThuc
                        FROM LichHoc lic
                        JOIN LopHoc lh ON lic.LopHocID = lh.LopHocID
                        LEFT JOIN PhongHoc ph ON lic.PhongHocID = ph.PhongHocID
                        WHERE lh.GiaoVienPhuTrachID = @NhanSuID
                          AND CONVERT(date, lic.NgayHoc) = CONVERT(date, GETDATE())
                        ORDER BY lic.GioBatDau ASC";

                    using (SqlCommand cmd = new SqlCommand(sqlLich, con))
                    {
                        cmd.Parameters.AddWithValue("@NhanSuID", nhanSuId);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtLich);
                        }
                    }
                }

                if (lblSoCaDay != null)
                {
                    lblSoCaDay.Text = dtLich.Rows.Count.ToString() + " ca";
                }

                if (dgvLichHomNay != null)
                {
                    dgvLichHomNay.DataSource = dtLich;
                }

                if (lblKhongCoLich != null)
                {
                    lblKhongCoLich.Visible = (dtLich.Rows.Count == 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu lịch dạy hôm nay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            try
            {
                using (SqlConnection con = DatabaseConnection.TaoKetNoi())
                {
                    con.Open();
                    string sqlUpdate = "UPDATE NhanSu SET SoDienThoai = @SoDienThoai, Email = @Email WHERE NhanSuID = @NhanSuID";
                    using (SqlCommand cmd = new SqlCommand(sqlUpdate, con))
                    {
                        cmd.Parameters.AddWithValue("@SoDienThoai", sdt);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@NhanSuID", currentNhanSuID);
                        cmd.ExecuteNonQuery();
                    }
                }

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
            TaiThongKeVaLichDay();
        }
    }
}
