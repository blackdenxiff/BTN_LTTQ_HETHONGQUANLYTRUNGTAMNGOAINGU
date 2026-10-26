using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmMainHocVien : Form
    {
        private int? nguoiDungID;
        private Button accountButton;
        private Button btnClasses;
        private Button btnSchedule;
        private Button activeButton;
        private readonly Color navy = Color.FromArgb(32, 65, 105);
        private static readonly Color green = Color.FromArgb(22, 128, 61);
        private static readonly Color red = Color.FromArgb(200, 45, 45);
        private static readonly Color orange = Color.FromArgb(205, 120, 0);
        private static readonly CultureInfo vi = new CultureInfo("vi-VN");
        private void BindScheduleControls()
        {
            btnClasses = btnLopHoc;
            btnSchedule = btnLichHoc;
            DateTime monday = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek + 6) % 7);
            scheduleFrom.Value = monday;
            scheduleTo.Value = monday.AddDays(6);
            btnSchedule.Click += delegate { Navigate(tabLichHoc, btnSchedule, "LỊCH HỌC"); RefreshSchedule(); };
            btnScheduleView.Click += delegate { RefreshSchedule(); };
            btnScheduleThisWeek.Click += delegate
            {
                DateTime start = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek + 6) % 7);
                scheduleFrom.Value = start; scheduleTo.Value = start.AddDays(6); RefreshSchedule();
            };
            btnSchedulePrevious.Click += delegate { ShiftSchedule(-7); };
            btnScheduleNext.Click += delegate { ShiftSchedule(7); };
        }

        private void ExitApplication()
        {
            if (MessageBox.Show(this, "Bạn có muốn thoát ứng dụng không?", "Xác nhận thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Application.Exit();
        }
        private void SetupAccountMenu()
        {
            accountButton = btnTaiKhoan;
            var menu = new ContextMenuStrip { Font = new Font("Segoe UI", 10F) };
            var changePassword = new ToolStripMenuItem("Đổi mật khẩu");
            changePassword.Click += delegate
            {
                menu.Close();
                using (var form = new frmDoiMatKhau()) form.ShowDialog(this);
            };
            menu.Items.Add(changePassword);
            var logout = new ToolStripMenuItem("Đăng xuất") { ForeColor = Color.FromArgb(196, 48, 61) };
            logout.Click += delegate
            {
                menu.Close();
                BTL_LTTQ_QLHTTTNN.Services.TaiKhoanService.DangXuat();
                // Program.VongDoiUngDung xử lý FormClosed để hiện lại màn hình đăng nhập.
                Close();
            };
            menu.Items.Add(logout);
            accountButton.Click += delegate
            {
                if (menu.Visible) { menu.Close(); return; }
                menu.Show(accountButton, new Point(accountButton.Width, accountButton.Height),
                    ToolStripDropDownDirection.BelowLeft);
            };
            FormClosed += delegate { menu.Dispose(); };
        }

        private void ShiftSchedule(int days)
        {
            DateTime start = scheduleFrom.Value.Date.AddDays(days), end = scheduleTo.Value.Date.AddDays(days);
            if (start < scheduleFrom.MinDate || start > scheduleFrom.MaxDate || end < scheduleTo.MinDate || end > scheduleTo.MaxDate) return;
            scheduleFrom.Value = start; scheduleTo.Value = end; RefreshSchedule();
        }
        private void RefreshSchedule()
        {
            scheduleGrid.DataSource = null;
            scheduleStatus.Text = "Chưa tải được lịch học.";
            HocVienData.Run(delegate
            {
                DateTime start = scheduleFrom.Value.Date, end = scheduleTo.Value.Date;
                if (end < start) throw new InvalidOperationException("Ngày kết thúc phải từ ngày bắt đầu trở đi.");
                var data = HocVienData.ScheduleForCurrentUser(nguoiDungID, start, end);
                scheduleGrid.DataSource = data;
                scheduleStatus.Text = data.Rows.Count == 0
                    ? "Không có lịch học trong khoảng ngày đã chọn. Bạn có thể đổi khoảng ngày để xem lịch khác."
                    : string.Format("{0} buổi trong khoảng {1:dd/MM/yyyy} – {2:dd/MM/yyyy}. Trạng thái buổi học do trung tâm cập nhật.", data.Rows.Count, start, end);
            });
        }
        private void ConfigureGrid(DataGridView grid, string[] fields, string[] titles)
        {
            grid.AutoGenerateColumns = false; grid.Columns.Clear(); grid.ReadOnly = true;
            grid.AllowUserToAddRows = false; grid.AllowUserToDeleteRows = false;
            grid.RowHeadersVisible = false; grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BorderStyle = BorderStyle.None; grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(230, 236, 243); grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = navy;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grid.ColumnHeadersHeight = 48; grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.RowTemplate.Height = 44;
            grid.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(216, 231, 248);
            grid.DefaultCellStyle.SelectionForeColor = navy;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(246, 249, 253);
            for (int i = 0; i < fields.Length; i++)
            {
                var col = new DataGridViewTextBoxColumn { Name = fields[i], DataPropertyName = fields[i], HeaderText = titles[i], MinimumWidth = 100 };
                if (fields[i].StartsWith("Ngay")) col.DefaultCellStyle.Format = "dd/MM/yyyy";
                if (fields[i] == "DiemCuoiKhoa") { col.DefaultCellStyle.Format = "0.##"; col.DefaultCellStyle.NullValue = "Chưa có điểm"; }
                if (fields[i] == "KetQua") col.DefaultCellStyle.NullValue = "Chưa có kết quả";
                if (fields[i] == "TongPhaiTra" || fields[i] == "DaThanhToan" || fields[i] == "ConPhaiTra")
                { col.DefaultCellStyle.Format = "N0"; col.DefaultCellStyle.NullValue = "—"; }
                grid.Columns.Add(col);
            }
        }
        private void Navigate(TabPage page, Button button, string title)
        {
            tabHoSo.SelectedTab = page;
            lblTieuDeTrang.Text = title;
            SelectMenu(button);
        }
        private void SelectMenu(Button button)
        {
            activeButton = button;
            foreach (var item in new[] { btnThongTin, btnKetQua, btnHocPhi, btnDangKyLop, btnClasses, btnSchedule })
            {
                if (item == null) continue;
                item.BackColor = item == button ? Color.FromArgb(37, 99, 235) : Color.FromArgb(30, 41, 59);
                item.ForeColor = item == button ? Color.White : Color.FromArgb(203, 213, 225);
            }
        }

        // TV1 passes the authenticated NguoiDungID after a successful login.
        public frmMainHocVien(int authenticatedNguoiDungID) : this()
        {
            nguoiDungID = authenticatedNguoiDungID;
        }

        public frmMainHocVien()
        {
            InitializeComponent();
            foreach (var grid in new[] { dgvLopHoc, dgvKetQua, dgvHocPhi }) HocVienData.Grid(grid);
            // Tự tạo cột theo dữ liệu truy vấn.
            dgvHocPhi.AutoGenerateColumns = true;
            dgvHocPhi.ColumnHeadersVisible = true;

            dgvLopHoc.AutoGenerateColumns = true;
            dgvKetQua.AutoGenerateColumns = true;
            Load += delegate { HocVienData.Run(LoadProfile); };
            btnThongTin.Click += btnThongTin_Click;
            btnLopHoc.Click += btnLopHoc_Click;
            btnKetQua.Click += btnKetQua_Click;
            btnHocPhi.Click += btnHocPhi_Click;
            btnDangKyLop.Click += btnDangKyLop_Click;
            btnThuGonMenu.Click += delegate { pnlMenu.Visible = !pnlMenu.Visible; };
            btnThoat.Click += delegate { ExitApplication(); };
            BindScheduleControls();
            ConfigureGrid(dgvLopHoc, new[] { "TenLop", "TenKhoaHoc", "TenCoSo", "NgayBatDau", "NgayKetThuc" },
                new[] { "Lớp học", "Khóa học", "Cơ sở", "Ngày bắt đầu", "Ngày kết thúc" });
            ConfigureGrid(dgvKetQua, new[] { "TenLop", "TenKhoaHoc", "DiemCuoiKhoa", "KetQua" },
                new[] { "Lớp học", "Khóa học", "Điểm cuối khóa", "Kết quả" });
            ConfigureGrid(dgvHocPhi, new[] { "TenLop", "TongPhaiTra", "DaThanhToan", "ConPhaiTra", "TrangThai" },
                new[] { "Lớp học", "Học phí phải đóng", "Đã thanh toán", "Còn phải đóng", "Tình trạng" });
            ConfigureGrid(scheduleGrid,
                new[] { "NgayHoc", "GioBatDau", "GioKetThuc", "TenLop", "TenKhoaHoc", "TenPhong", "TenCoSo", "TrangThai", "GhiChu" },
                new[] { "Ngày học", "Bắt đầu", "Kết thúc", "Lớp học", "Khóa học", "Phòng học", "Cơ sở", "Trạng thái", "Ghi chú" });
            tabHoSo.SelectedIndexChanged += delegate
            {
                var page = tabHoSo.SelectedTab;
                if (page == tabThongTin) Navigate(page, btnThongTin, "THÔNG TIN CÁ NHÂN");
                else if (page == tabLopHoc) Navigate(page, btnClasses, "LỚP ĐÃ ĐĂNG KÝ");
                else if (page == tabKetQua) Navigate(page, btnKetQua, "KẾT QUẢ HỌC TẬP");
                else if (page == tabHocPhi) Navigate(page, btnHocPhi, "TÌNH TRẠNG HỌC PHÍ");
                else if (page == tabLichHoc) Navigate(page, btnSchedule, "LỊCH HỌC");
            };
            SetupAccountMenu();
            Navigate(tabThongTin, btnThongTin, "THÔNG TIN CÁ NHÂN");
        }

        private static decimal SumColumn(DataTable table, string name)
        {
            decimal result = 0;
            if (table != null && table.Columns.Contains(name)) foreach (DataRow row in table.Rows) if (!row.IsNull(name)) result += Convert.ToDecimal(row[name]);
            return result;
        }
        private void UpdateFeeSummary(DataTable fees)
        {
            decimal total = SumColumn(fees, "TongPhaiTra"), paid = SumColumn(fees, "DaThanhToan"), due = SumColumn(fees, "ConPhaiTra");
            lblTongPhaiTra.Text = "Tổng phải trả: " + total.ToString("#,##0", vi) + " đ";
            lblDaThanhToan.Text = "Đã thanh toán: " + paid.ToString("#,##0", vi) + " đ";
            lblConPhaiTra.Text = "Còn phải trả: " + due.ToString("#,##0", vi) + " đ";
            lblConPhaiTra.ForeColor = due > 0 ? red : green;
        }
        private void LoadProfile()
        {
            DataRow row = HocVienData.OwnProfile(nguoiDungID);
            int id = Convert.ToInt32(row["HocVienID"]);
            txtHocVienID.Text = id.ToString(); txtHoTen.Text = Convert.ToString(row["HoTen"]);
            txtNgaySinh.Text = row.IsNull("NgaySinh") ? "" : Convert.ToDateTime(row["NgaySinh"]).ToString("dd/MM/yyyy");
            txtGioiTinh.Text = Convert.ToString(row["GioiTinh"]); txtSoDienThoai.Text = Convert.ToString(row["SoDienThoai"]);
            txtEmail.Text = Convert.ToString(row["Email"]); txtTrinhDoDauVao.Text = Convert.ToString(row["TrinhDoDauVao"]);
            txtDiemDauVao.Text = Convert.ToString(row["DiemDauVao"]); txtNhanXetDauVao.Text = Convert.ToString(row["NhanXetDauVao"]);
            txtTrangThai.Text = Convert.ToString(row["TrangThai"]); txtTaiKhoan.Text = Convert.ToString(row["TenDangNhap"]);
            lblNguoiDangNhap.Text = "Học viên: " + txtHoTen.Text;
            accountButton.Text = lblNguoiDangNhap.Text + "  ▾";
            var classes = HocVienData.Enrollments(id); dgvLopHoc.DataSource = classes; dgvKetQua.DataSource = classes.Copy();
            var fees = HocVienData.Fees(id);
            dgvHocPhi.DataSource = fees;
            UpdateFeeSummary(fees);
        }

        private void btnDangKyLop_Click(object sender, EventArgs e)
        {
            if (!nguoiDungID.HasValue || nguoiDungID.Value <= 0)
            {
                MessageBox.Show("Vui lòng đăng nhập bằng tài khoản học viên.");
                return;
            }
            HocVienData.Run(delegate
            {
                HocVienData.OwnProfile(nguoiDungID);
                string previousTitle = lblTieuDeTrang.Text;
                Button previousButton = activeButton;
                lblTieuDeTrang.Text = "ĐĂNG KÝ LỚP";
                SelectMenu(btnDangKyLop);
                try
                {
                    using (var form = new frmDangKyHoc(nguoiDungID.Value)) form.ShowDialog(this);
                }
                finally { lblTieuDeTrang.Text = previousTitle; SelectMenu(previousButton); }
                LoadProfile();
            });
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            Navigate(tabThongTin, btnThongTin, "THÔNG TIN CÁ NHÂN");
        }

        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            Navigate(tabLopHoc, btnClasses, "LỚP ĐÃ ĐĂNG KÝ");
        }

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            Navigate(tabKetQua, btnKetQua, "KẾT QUẢ HỌC TẬP");
        }

        private void btnHocPhi_Click(object sender, EventArgs e)
        {
            Navigate(tabHocPhi, btnHocPhi, "TÌNH TRẠNG HỌC PHÍ");
        }
    }
}
