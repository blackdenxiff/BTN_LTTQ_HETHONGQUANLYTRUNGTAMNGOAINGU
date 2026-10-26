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
            SuspendLayout();
            foreach (var button in new[] { btnThongTin, btnKetQua, btnHocPhi, btnDangKyLop })
                pnlMenu.Controls.Remove(button);
            pnlHeader.Controls.Remove(lblTenHeThong);
            Controls.Remove(pnlNoiDung);
            Controls.Remove(pnlHeader);
            Controls.Remove(pnlMenu);
            Controls.Remove(stsTrangThai);

            var root = new TableLayoutPanel { Name = "tlpVungChinhHocVien", Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 2, BackColor = Color.FromArgb(248, 250, 252), Margin = Padding.Empty };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 270F));
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            Controls.Add(root);

            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.Width = 270;
            pnlMenu.Padding = Padding.Empty;
            pnlMenu.AutoScroll = false;
            pnlMenu.BackColor = Color.FromArgb(15, 23, 42);
            root.Controls.Add(pnlMenu, 0, 0);

            var sidebar = new TableLayoutPanel { Name = "tlpMenuHocVien", Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3, BackColor = pnlMenu.BackColor, Margin = Padding.Empty };
            sidebar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            sidebar.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            sidebar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            sidebar.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            pnlMenu.Controls.Add(sidebar);

            var brand = new Panel { Name = "pnlThuongHieuHocVien", Dock = DockStyle.Fill, BackColor = pnlMenu.BackColor, Margin = Padding.Empty };
            var logo = new Label { Text = "E", Location = new Point(22, 25), Size = new Size(43, 48), ForeColor = Color.FromArgb(59, 130, 246), Font = new Font("Segoe UI", 26F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };
            lblTenHeThong.Text = "ENGLISH CENTER";
            lblTenHeThong.Location = new Point(75, 20);
            lblTenHeThong.Size = new Size(190, 32);
            lblTenHeThong.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTenHeThong.ForeColor = Color.White;
            var tagline = new Label { Text = "Quản lý trung tâm", Location = new Point(76, 55), Size = new Size(185, 24), ForeColor = Color.FromArgb(148, 163, 184), Font = new Font("Segoe UI", 9F) };
            brand.Controls.AddRange(new Control[] { logo, lblTenHeThong, tagline });
            sidebar.Controls.Add(brand, 0, 0);

            var menuBody = new FlowLayoutPanel { Name = "flpMenuHocVien", Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoScroll = true, BackColor = pnlMenu.BackColor, Padding = new Padding(12, 16, 12, 12), Margin = Padding.Empty };
            var menuHeading = new Label { Text = "KHU VỰC HỌC VIÊN", Width = 230, Height = 38, ForeColor = Color.FromArgb(34, 211, 238), Font = new Font("Segoe UI", 9F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleLeft, Margin = new Padding(2, 0, 0, 8) };
            menuBody.Controls.Add(menuHeading);
            sidebar.Controls.Add(menuBody, 0, 1);

            var exitButton = new Button { Text = "Thoát", Dock = DockStyle.Fill, Height = 50,
                BackColor = pnlMenu.BackColor, ForeColor = Color.FromArgb(203, 213, 225), FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F), TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(20, 0, 8, 0), Cursor = Cursors.Hand, Margin = Padding.Empty };
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 65, 85);
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
            sidebar.Controls.Add(exitButton, 0, 2);

            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1280, 800);
            MinimumSize = new Size(980, 650);
            Text = "English Center — Học viên";

            var mainArea = new TableLayoutPanel { Name = "tlpNoiDungHocVien", Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, BackColor = Color.FromArgb(248, 250, 252), Margin = Padding.Empty };
            mainArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainArea.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            mainArea.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.Controls.Add(mainArea, 1, 0);
            mainArea.Controls.Add(pnlHeader, 0, 0);
            mainArea.Controls.Add(pnlNoiDung, 0, 1);
            root.Controls.Add(stsTrangThai, 0, 1);
            root.SetColumnSpan(stsTrangThai, 2);
            stsTrangThai.Dock = DockStyle.Fill;
            stsTrangThai.BackColor = Color.FromArgb(248, 250, 252);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Height = 72;
            pnlHeader.BackColor = Color.White;
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.BackColor = Color.FromArgb(248, 250, 252);
            pnlNoiDung.Padding = new Padding(24, 18, 24, 18);

            var header = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4, RowCount = 1, BackColor = Color.White, Margin = Padding.Empty };
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            pnlHeader.Controls.Clear();
            pnlHeader.Controls.Add(header);
            var menuButton = new Button { Name = "btnThuGonMenu", Text = "☰", Size = new Size(42, 38), FlatStyle = FlatStyle.Flat, BackColor = Color.White, ForeColor = Color.FromArgb(31, 41, 55), Cursor = Cursors.Hand, Margin = new Padding(20, 16, 0, 16) };
            menuButton.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            menuButton.Click += delegate { pnlMenu.Visible = !pnlMenu.Visible; };
            var spacer = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = Padding.Empty };
            var roleBadge = new Label { Text = "Học viên", Dock = DockStyle.Fill, Margin = new Padding(8, 14, 8, 14), BackColor = Color.FromArgb(37, 99, 235), ForeColor = Color.White, Font = new Font("Segoe UI", 9F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };
            header.Controls.Add(menuButton, 0, 0);
            header.Controls.Add(spacer, 1, 0);
            header.Controls.Add(roleBadge, 2, 0);
            header.Controls.Add(lblNguoiDangNhap, 3, 0);
            lblNguoiDangNhap.Dock = DockStyle.Fill;
            lblNguoiDangNhap.ForeColor = Color.FromArgb(31, 41, 55);
            lblNguoiDangNhap.TextAlign = ContentAlignment.MiddleRight;
            lblNguoiDangNhap.Padding = new Padding(8, 0, 18, 0);
            lblNguoiDangNhap.Font = new Font("Segoe UI", 10F);

            // Keep main's tab strip and its existing dimensions; menus remain shortcuts to those tabs.
            tabHoSo.Visible = true;
            tabHoSo.Font = new Font("Segoe UI", 9.5F);
            tabHoSo.BackColor = Color.White;
            tabHoSo.Appearance = TabAppearance.FlatButtons;
            tabHoSo.SizeMode = TabSizeMode.Fixed;
            tabHoSo.ItemSize = new Size(0, 1);
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
            SetupSchedule();
            foreach (var button in new[] { btnThongTin, btnClasses, btnKetQua, btnHocPhi, btnDangKyLop, btnSchedule })
            {
                button.Dock = DockStyle.None;
                button.Width = 230;
                button.Height = 50;
                button.Margin = new Padding(0, 0, 0, 4);
                button.BackColor = Color.FromArgb(30, 41, 59);
                button.ForeColor = Color.FromArgb(203, 213, 225);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 65, 85);
                button.Font = new Font("Segoe UI", 10F);
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.Padding = new Padding(16, 0, 8, 0);
                button.Cursor = Cursors.Hand;
                menuBody.Controls.Add(button);
            }
            lblTieuDeTrang.ForeColor = Color.FromArgb(31, 41, 55);
            ResumeLayout(true);
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
            parent.Controls.Remove(lblNguoiDangNhap);
            accountButton = new Button
            {
                Text = lblNguoiDangNhap.Text + "  ▾",
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                ForeColor = Color.FromArgb(31, 41, 55),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(8, 0, 16, 0),
                Cursor = Cursors.Hand,
                AccessibleName = "Menu tài khoản học viên",
                AutoEllipsis = true,
                UseVisualStyleBackColor = false
            };
            accountButton.FlatAppearance.BorderSize = 0;
            accountButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
            (parent as TableLayoutPanel).Controls.Add(accountButton, 3, 0);
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

        private void SetupSchedule()
        {
            schedulePage = new TabPage("Lịch học");
            tabHoSo.TabPages.Add(schedulePage);
            var panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = Padding.Empty, Visible = true };
            pages.Add(schedulePage, panel); schedulePage.Controls.Add(panel); panel.BringToFront();
            btnSchedule = new Button { Text = "Lịch học", Dock = DockStyle.Top, Height = btnThongTin.Height,
                FlatStyle = btnThongTin.FlatStyle, BackColor = btnThongTin.BackColor,
                ForeColor = btnThongTin.ForeColor, TextAlign = btnThongTin.TextAlign, Padding = btnThongTin.Padding };
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
