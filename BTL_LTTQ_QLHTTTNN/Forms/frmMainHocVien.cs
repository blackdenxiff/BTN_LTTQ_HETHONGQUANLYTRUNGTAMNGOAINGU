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
        private readonly Dictionary<TabPage, Panel> pages = new Dictionary<TabPage, Panel>();
        private Button accountButton;
        private Button btnClasses;
        private Button btnSchedule;
        private TabPage schedulePage;
        private DataGridView scheduleGrid;
        private DateTimePicker scheduleFrom, scheduleTo;
        private Label scheduleStatus;
        private Button activeButton;
        private readonly Color navy = Color.FromArgb(32, 65, 105);
        private static readonly Color green = Color.FromArgb(22, 128, 61);
        private static readonly Color red = Color.FromArgb(200, 45, 45);
        private static readonly Color orange = Color.FromArgb(205, 120, 0);
        private static readonly CultureInfo vi = new CultureInfo("vi-VN");
        private Label lblTongPhaiTra, lblDaThanhToan, lblConPhaiTra;
        private Button btnThanhToan;

        private void SetupAppearance()
        {
            // Keep main's tab strip and its existing dimensions; menus remain shortcuts to those tabs.
            tabHoSo.Visible = true;
            foreach (TabPage tab in tabHoSo.TabPages)
            {
                var panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White,
                    Padding = Padding.Empty, AutoScroll = true, Visible = true };
                while (tab.Controls.Count > 0) panel.Controls.Add(tab.Controls[0]);
                pages.Add(tab, panel);
                tab.Controls.Add(panel);
                panel.BringToFront();
            }
            btnClasses = new Button { Text = "Lớp đã đăng ký", Dock = DockStyle.Top, Height = btnThongTin.Height,
                FlatStyle = btnThongTin.FlatStyle, BackColor = btnThongTin.BackColor,
                ForeColor = btnThongTin.ForeColor, TextAlign = btnThongTin.TextAlign, Padding = btnThongTin.Padding };
            btnClasses.Click += btnLopHoc_Click;
            pnlMenu.Controls.Add(btnClasses);
            SetupSchedule();
            var exitButton = new Button { Text = "Thoát", Dock = DockStyle.Bottom, Height = 48,
                BackColor = btnThongTin.BackColor, ForeColor = btnThongTin.ForeColor, FlatStyle = btnThongTin.FlatStyle, Font = btnThongTin.Font, TextAlign = btnThongTin.TextAlign, Padding = btnThongTin.Padding, Cursor = Cursors.Hand };
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.Click += delegate
            {
                using (var dialog = new Form { Text = "Xác nhận thoát", ClientSize = new Size(370, 145),
                    FormBorderStyle = FormBorderStyle.FixedDialog, StartPosition = FormStartPosition.CenterParent,
                    MinimizeBox = false, MaximizeBox = false, ShowInTaskbar = false, Font = Font })
                {
                    var message = new Label { Text = "Bạn có muốn thoát ứng dụng không?", AutoSize = true, Location = new Point(24, 25) };
                    var yes = new Button { Text = "Có", DialogResult = DialogResult.Yes, Location = new Point(155, 88), Size = new Size(90, 34) };
                    var no = new Button { Text = "Không", DialogResult = DialogResult.No, Location = new Point(255, 88), Size = new Size(90, 34) };
                    dialog.Controls.AddRange(new Control[] { message, yes, no });
                    dialog.AcceptButton = no; dialog.CancelButton = no;
                    if (dialog.ShowDialog(this) == DialogResult.Yes) Application.Exit();
                }
            };
            pnlMenu.Controls.Add(exitButton);
            ConfigureGrid(dgvLopHoc, new[] { "TenLop", "TenKhoaHoc", "TenCoSo", "NgayBatDau", "NgayKetThuc" },
                new[] { "Lớp học", "Khóa học", "Cơ sở", "Ngày bắt đầu", "Ngày kết thúc" });
            ConfigureGrid(dgvKetQua, new[] { "TenLop", "TenKhoaHoc", "DiemCuoiKhoa", "KetQua" },
                new[] { "Lớp học", "Khóa học", "Điểm cuối khóa", "Kết quả" });
            ConfigureGrid(dgvHocPhi, new[] { "TenLop", "TongPhaiTra", "DaThanhToan", "ConPhaiTra", "TrangThai" },
                new[] { "Lớp học", "Học phí phải đóng", "Đã thanh toán", "Còn phải đóng", "Tình trạng" });
            Navigate(tabThongTin, btnThongTin, "THÔNG TIN CÁ NHÂN");
        }
        private void SetupAccountMenu()
        {
            var parent = lblNguoiDangNhap.Parent;
            int index = parent.Controls.GetChildIndex(lblNguoiDangNhap);
            accountButton = new Button
            {
                Text = lblNguoiDangNhap.Text + "  ▾",
                Dock = lblNguoiDangNhap.Dock,
                Size = lblNguoiDangNhap.Size,
                ForeColor = Color.White,
                BackColor = parent.BackColor,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(8, 0, 16, 0),
                Cursor = Cursors.Hand,
                AccessibleName = "Menu tài khoản học viên",
                AutoEllipsis = true,
                UseVisualStyleBackColor = false
            };
            accountButton.FlatAppearance.BorderSize = 0;
            accountButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 83, 130);
            lblNguoiDangNhap.Visible = false;
            parent.Controls.Add(accountButton);
            parent.Controls.SetChildIndex(accountButton, index);
            var menu = new ContextMenuStrip { Font = new Font("Segoe UI", 10F) };
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

        private void SetupSchedule()
        {
            schedulePage = new TabPage("Lịch học");
            tabHoSo.TabPages.Add(schedulePage);
            var panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = Padding.Empty, Visible = true };
            pages.Add(schedulePage, panel); schedulePage.Controls.Add(panel); panel.BringToFront();
            btnSchedule = new Button { Text = "Lịch học", Dock = DockStyle.Top, Height = btnThongTin.Height,
                FlatStyle = btnThongTin.FlatStyle, BackColor = btnThongTin.BackColor,
                ForeColor = btnThongTin.ForeColor, TextAlign = btnThongTin.TextAlign, Padding = btnThongTin.Padding };
            pnlMenu.Controls.Add(btnSchedule);
            btnSchedule.Click += delegate
            {
                Navigate(schedulePage, btnSchedule, "LỊCH HỌC");
                RefreshSchedule();
            };
            scheduleFrom = new DateTimePicker { Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy", Width = 125 };
            scheduleTo = new DateTimePicker { Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy", Width = 125 };
            DateTime monday = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek + 6) % 7);
            scheduleFrom.Value = monday; scheduleTo.Value = monday.AddDays(6);
            var filter = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 90, WrapContents = true, Padding = new Padding(0, 4, 0, 6) };
            var view = new Button { Text = "Xem lịch", AutoSize = true };
            var thisWeek = new Button { Text = "Tuần này", AutoSize = true };
            var previous = new Button { Text = "Tuần trước", AutoSize = true };
            var next = new Button { Text = "Tuần sau", AutoSize = true };
            filter.Controls.AddRange(new Control[] {
                new Label { Text = "Từ ngày", AutoSize = true, Margin = new Padding(0, 7, 6, 0) }, scheduleFrom,
                new Label { Text = "Đến ngày", AutoSize = true, Margin = new Padding(8, 7, 6, 0) }, scheduleTo,
                view, previous, thisWeek, next });
            view.Click += delegate { RefreshSchedule(); };
            thisWeek.Click += delegate {
                DateTime start = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek + 6) % 7);
                scheduleFrom.Value = start; scheduleTo.Value = start.AddDays(6); RefreshSchedule(); };
            previous.Click += delegate { ShiftSchedule(-7); };
            next.Click += delegate { ShiftSchedule(7); };
            scheduleStatus = new Label { Dock = DockStyle.Bottom, Height = 52, ForeColor = Color.FromArgb(90, 105, 125), TextAlign = ContentAlignment.MiddleLeft };
            scheduleGrid = new DataGridView { Dock = DockStyle.Fill, BackgroundColor = Color.White };
            ConfigureGrid(scheduleGrid,
                new[] { "NgayHoc", "GioBatDau", "GioKetThuc", "TenLop", "TenKhoaHoc", "TenPhong", "TenCoSo", "TrangThai", "GhiChu" },
                new[] { "Ngày học", "Bắt đầu", "Kết thúc", "Lớp học", "Khóa học", "Phòng học", "Cơ sở", "Trạng thái", "Ghi chú" });
            // Các cột có độ rộng tối thiểu; cuộn ngang khi cửa sổ nhỏ.
            scheduleGrid.Columns["TenLop"].MinimumWidth = 140;
            scheduleGrid.Columns["TenKhoaHoc"].MinimumWidth = 160;
            scheduleGrid.Columns["GhiChu"].MinimumWidth = 180;
            panel.Controls.Add(scheduleGrid); panel.Controls.Add(filter); panel.Controls.Add(scheduleStatus);
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
            foreach (var item in pages) item.Value.Visible = item.Key == page;
            pages[page].BringToFront();
            lblTieuDeTrang.Text = title;
            SelectMenu(button);
        }
        private void SelectMenu(Button button)
        {
            activeButton = button;
        }

        // TV1 passes the authenticated NguoiDungID after a successful login.
        public frmMainHocVien(int authenticatedNguoiDungID) : this()
        {
            nguoiDungID = authenticatedNguoiDungID;
        }

        public frmMainHocVien()
        {
            InitializeComponent();
            tabHoSo.SelectedIndexChanged += delegate
            {
                var page = tabHoSo.SelectedTab;
                if (page == tabThongTin) Navigate(page, btnThongTin, "THÔNG TIN CÁ NHÂN");
                else if (page == tabLopHoc) Navigate(page, btnClasses, "LỚP ĐÃ ĐĂNG KÝ");
                else if (page == tabKetQua) Navigate(page, btnKetQua, "KẾT QUẢ HỌC TẬP");
                else if (page == tabHocPhi) Navigate(page, btnHocPhi, "TÌNH TRẠNG HỌC PHÍ");
                else if (page == schedulePage) Navigate(page, btnSchedule, "LỊCH HỌC");
            };
            foreach (var grid in new[] { dgvLopHoc, dgvKetQua, dgvHocPhi }) HocVienData.Grid(grid);
            // Tự tạo cột theo dữ liệu truy vấn.
            dgvHocPhi.AutoGenerateColumns = true;
            dgvHocPhi.ColumnHeadersVisible = true;

            dgvLopHoc.AutoGenerateColumns = true;
            dgvKetQua.AutoGenerateColumns = true;
            Load += delegate { HocVienData.Run(LoadProfile); };
            btnThongTin.Click += btnThongTin_Click;

            btnKetQua.Click += btnKetQua_Click;
            btnHocPhi.Click += btnHocPhi_Click;
            btnDangKyLop.Click += btnDangKyLop_Click;
            SetupAppearance();
            BuildFeeSummary();
            tabHoSo.SelectedIndexChanged += delegate
            {
                TabPage page = tabHoSo.SelectedTab;
                foreach (var item in pages) item.Value.Visible = item.Key == page;
                if (pages.ContainsKey(page)) pages[page].BringToFront();
            };
            SetupAccountMenu();
            foreach (var grid in new[] { dgvLopHoc, dgvKetQua, dgvHocPhi, scheduleGrid })
                new GridPager(grid, delegate { BTL_LTTQ_QLHTTTNN.Services.PhanQuyenService.YeuCauQuyen("XemHoSoCaNhan"); });
        }

        private void BuildFeeSummary()
        {
            var summary = new TableLayoutPanel { Dock = DockStyle.Top, Height = 82, ColumnCount = 3, RowCount = 1, BackColor = Color.White, Padding = new Padding(8) };
            for (int i = 0; i < 3; i++) summary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            lblTongPhaiTra = AddFeeCard(summary, 0, "TỔNG PHẢI TRẢ", navy);
            lblDaThanhToan = AddFeeCard(summary, 1, "ĐÃ THANH TOÁN", green);
            lblConPhaiTra = AddFeeCard(summary, 2, "CÒN PHẢI TRẢ", orange);
            tabHocPhi.Controls.Add(summary);
            btnThanhToan = new Button { Text = "Lập phiếu thu", Dock = DockStyle.Bottom, Height = 44, FlatStyle = btnThongTin.FlatStyle, BackColor = btnThongTin.BackColor, ForeColor = btnThongTin.ForeColor, Font = btnThongTin.Font, Cursor = Cursors.Hand };
            btnThanhToan.Click += btnThanhToan_Click;
            tabHocPhi.Controls.Add(btnThanhToan);
            btnThanhToan.BringToFront(); summary.BringToFront();
        }
        private Label AddFeeCard(TableLayoutPanel panel, int column, string title, Color accent)
        {
            var card = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(246, 248, 252), Margin = new Padding(3) };
            card.Controls.Add(new Label { Text = title, Dock = DockStyle.Top, Height = 22, ForeColor = Color.FromArgb(90, 102, 120), Font = new Font(Font, FontStyle.Bold) });
            var value = new Label { Text = "0 đ", Dock = DockStyle.Fill, ForeColor = accent, Font = new Font(Font.FontFamily, 13F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleLeft };
            card.Controls.Add(value); panel.Controls.Add(card, column, 0); return value;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (!nguoiDungID.HasValue || nguoiDungID.Value <= 0) return;
            DataRow profile = HocVienData.OwnProfile(nguoiDungID);
            int id = Convert.ToInt32(profile["HocVienID"]);
            using (var form = new frmLapPhieuThu(id, true))
                if (form.ShowDialog(this) == DialogResult.OK) HocVienData.Run(LoadProfile);
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
            lblTongPhaiTra.Text = total.ToString("#,##0", vi) + " đ"; lblDaThanhToan.Text = paid.ToString("#,##0", vi) + " đ"; lblConPhaiTra.Text = due.ToString("#,##0", vi) + " đ";
            lblConPhaiTra.ForeColor = due > 0 ? red : green; btnThanhToan.Enabled = due > 0;
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

