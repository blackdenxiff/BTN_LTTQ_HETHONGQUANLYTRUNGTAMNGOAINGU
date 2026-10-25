using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmMainHocVien : Form
    {
        private int? nguoiDungID;
        private readonly Dictionary<TabPage, Panel> pages = new Dictionary<TabPage, Panel>();
        private Button btnClasses;
        private Button btnSchedule;
        private TabPage schedulePage;
        private DataGridView scheduleGrid;
        private DateTimePicker scheduleFrom, scheduleTo;
        private Label scheduleStatus;
        private Button activeButton;
        private readonly Color navy = Color.FromArgb(32, 65, 105);

        private void SetupAppearance()
        {
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1000, 700);
            pnlNoiDung.BackColor = Color.FromArgb(244, 247, 251);
            pnlNoiDung.Padding = new Padding(24);
            pnlMenu.BackColor = Color.FromArgb(235, 241, 248);
            lblTieuDeTrang.Height = 60;
            lblTieuDeTrang.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            // Chuyển nội dung tab vào các panel; chỉ menu chính điều hướng.
            tabHoSo.Visible = false;
            foreach (TabPage tab in tabHoSo.TabPages)
            {
                var panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White,
                    Padding = new Padding(22), AutoScroll = true, Visible = false };
                while (tab.Controls.Count > 0) panel.Controls.Add(tab.Controls[0]);
                pages.Add(tab, panel);
                pnlNoiDung.Controls.Add(panel);
                panel.BringToFront();
            }
            btnClasses = new Button { Text = "Lớp đã đăng ký" };
            btnClasses.Click += btnLopHoc_Click;
            pnlMenu.Controls.Add(btnClasses);
            SetupSchedule();
            var buttons = new[] { btnThongTin, btnClasses, btnSchedule, btnKetQua, btnHocPhi, btnDangKyLop };
            for (int i = 0; i < buttons.Length; i++)
            {
                var b = buttons[i]; b.Dock = DockStyle.None;
                b.SetBounds(12, 24 + i * 62, pnlMenu.ClientSize.Width - 24, 52);
                b.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                b.FlatStyle = FlatStyle.Flat; b.FlatAppearance.BorderSize = 0;
                b.FlatAppearance.MouseOverBackColor = Color.FromArgb(211, 225, 242);
                b.TextAlign = ContentAlignment.MiddleLeft; b.Padding = new Padding(14, 0, 0, 0);
                b.Font = new Font("Segoe UI", 10F); b.Cursor = Cursors.Hand;
                b.BackColor = pnlMenu.BackColor; b.ForeColor = navy;
            }
            var exitButton = new Button { Text = "Thoát", Dock = DockStyle.Bottom, Height = 48,
                BackColor = Color.FromArgb(196, 48, 61), ForeColor = Color.White, FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold), Cursor = Cursors.Hand };
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(166, 32, 44);
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
            foreach (Control c in tblThongTin.Controls)
            {
                var box = c as TextBox;
                if (box != null) { box.BorderStyle = BorderStyle.None; box.BackColor = Color.FromArgb(244, 247, 251);
                    box.ForeColor = navy; box.Font = new Font("Segoe UI", 11F); box.Margin = new Padding(8, 12, 8, 10); }
                var label = c as Label;
                if (label != null) { label.ForeColor = Color.FromArgb(90, 105, 125); label.Font = new Font("Segoe UI", 10F); }
            }
            foreach (RowStyle row in tblThongTin.RowStyles) row.Height = 44;
            tblThongTin.RowStyles[tblThongTin.RowStyles.Count - 1].Height = 90;
            ConfigureGrid(dgvLopHoc, new[] { "TenLop", "TenKhoaHoc", "TenCoSo", "NgayBatDau", "NgayKetThuc" },
                new[] { "Lớp học", "Khóa học", "Cơ sở", "Ngày bắt đầu", "Ngày kết thúc" });
            ConfigureGrid(dgvKetQua, new[] { "TenLop", "TenKhoaHoc", "DiemCuoiKhoa", "KetQua" },
                new[] { "Lớp học", "Khóa học", "Điểm cuối khóa", "Kết quả" });
            ConfigureGrid(dgvHocPhi, new[] { "TenLop", "TongPhaiTra", "DaThanhToan", "ConPhaiTra", "TrangThai" },
                new[] { "Lớp học", "Học phí phải đóng", "Đã thanh toán", "Còn phải đóng", "Tình trạng" });
            Navigate(tabThongTin, btnThongTin, "THÔNG TIN CÁ NHÂN");
        }
        private void SetupSchedule()
        {
            schedulePage = new TabPage("Lịch học");
            tabHoSo.TabPages.Add(schedulePage);
            var panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(18), Visible = false };
            pages.Add(schedulePage, panel); pnlNoiDung.Controls.Add(panel); panel.BringToFront();
            btnSchedule = new Button { Text = "Lịch học" }; pnlMenu.Controls.Add(btnSchedule);
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
            foreach (var item in pages) item.Value.Visible = item.Key == page;
            pages[page].BringToFront();
            lblTieuDeTrang.Text = title;
            SelectMenu(button);
        }
        private void SelectMenu(Button button)
        {
            foreach (var b in new[] { btnThongTin, btnClasses, btnSchedule, btnKetQua, btnHocPhi, btnDangKyLop })
            { b.BackColor = b == button ? navy : pnlMenu.BackColor; b.ForeColor = b == button ? Color.White : navy; }
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
            var classes = HocVienData.Enrollments(id); dgvLopHoc.DataSource = classes; dgvKetQua.DataSource = classes.Copy();
            dgvHocPhi.DataSource = HocVienData.Fees(id);
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
