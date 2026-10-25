using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmMainHocVien : Form
    {
        private int? nguoiDungID;
        private int? hocVienID;   // HocVienID của tài khoản đang đăng nhập

        // ====== Bảng màu dùng chung ======
        private static readonly Color Navy = Color.FromArgb(32, 65, 105);
        private static readonly Color NavyHover = Color.FromArgb(220, 230, 245);
        private static readonly Color PageBg = Color.FromArgb(246, 248, 252);
        private static readonly Color RowAlt = Color.FromArgb(247, 249, 253);
        private static readonly Color RowSelect = Color.FromArgb(222, 235, 250);
        private static readonly Color LineColor = Color.FromArgb(228, 233, 241);
        private static readonly Color Green = Color.FromArgb(22, 128, 61);
        private static readonly Color Red = Color.FromArgb(200, 45, 45);
        private static readonly Color Orange = Color.FromArgb(205, 120, 0);
        private static readonly CultureInfo Vi = new CultureInfo("vi-VN");

        // Việt hóa tiêu đề cột (tên cột -> tiêu đề hiển thị)
        private static readonly Dictionary<string, string> HeaderMap = new Dictionary<string, string>
        {
            {"TenLop", "Tên lớp"}, {"TenKhoaHoc", "Khóa học"}, {"TenCoSo", "Cơ sở"},
            {"NgayDangKy", "Ngày đăng ký"}, {"NgayBatDau", "Ngày bắt đầu"}, {"NgayKetThuc", "Ngày kết thúc"},
            {"TrangThai", "Trạng thái"}, {"DiemCuoiKhoa", "Điểm cuối khóa"}, {"KetQua", "Kết quả"},
            {"DuocHocLaiMienPhi", "Học lại miễn phí"}, {"HoaDonID", "Mã hóa đơn"},
            {"TongPhaiTra", "Tổng phải trả"}, {"DaThanhToan", "Đã thanh toán"}, {"ConPhaiTra", "Còn phải trả"}
        };

        private static readonly string[] MoneyColumns = { "TongPhaiTra", "DaThanhToan", "ConPhaiTra" };

        private Label lblTongPhaiTra, lblDaThanhToan, lblConPhaiTra;
        private Button btnThanhToan;

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

            // ====== Làm đẹp giao diện ======
            ApplyTheme();
            foreach (var grid in new[] { dgvLopHoc, dgvKetQua, dgvHocPhi }) StyleGrid(grid);
            BuildFeeSummary();
            dgvLopHoc.DataBindingComplete += delegate { FormatGrid(dgvLopHoc); };
            dgvKetQua.DataBindingComplete += delegate { FormatGrid(dgvKetQua); };
            dgvHocPhi.DataBindingComplete += delegate { FormatGrid(dgvHocPhi); };

            Load += delegate { HocVienData.Run(LoadProfile); };
            btnThongTin.Click += btnThongTin_Click;

            btnKetQua.Click += btnKetQua_Click;
            btnHocPhi.Click += btnHocPhi_Click;
            btnDangKyLop.Click += btnDangKyLop_Click;
        }

        // =====================================================================
        //  GIAO DIỆN
        // =====================================================================

        /// <summary>Menu trái, tab, nền nội dung.</summary>
        private void ApplyTheme()
        {
            pnlNoiDung.BackColor = PageBg;

            // ----- Menu trái -----
            foreach (var btn in new[] { btnThongTin, btnKetQua, btnHocPhi, btnDangKyLop })
            {
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = NavyHover;
                btn.FlatAppearance.MouseDownBackColor = NavyHover;
                btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
                btn.Cursor = Cursors.Hand;
                btn.Height = 48;
                btn.Margin = new Padding(0, 0, 0, 6);
                btn.Padding = new Padding(16, 0, 0, 0);
            }
            tabHoSo.SelectedIndexChanged += delegate { UpdateMenuHighlight(); };
            UpdateMenuHighlight();

            // ----- Tab ngang -----
            tabHoSo.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabHoSo.SizeMode = TabSizeMode.Fixed;
            tabHoSo.ItemSize = new Size(170, 38);
            tabHoSo.Padding = new Point(14, 4);
            tabHoSo.DrawItem += TabHoSo_DrawItem;
            foreach (TabPage p in tabHoSo.TabPages)
            {
                p.UseVisualStyleBackColor = false;
                p.BackColor = Color.White;
                p.Padding = new Padding(20);
            }

            // ----- Ô nhập thông tin cá nhân -----
            foreach (Control c in tblThongTin.Controls)
            {
                var t = c as TextBox;
                if (t != null)
                {
                    t.BackColor = Color.FromArgb(243, 246, 250);
                    t.BorderStyle = BorderStyle.FixedSingle;
                    t.ForeColor = Color.FromArgb(40, 50, 65);
                }
                var l = c as Label;
                if (l != null) l.ForeColor = Color.FromArgb(90, 102, 120);
            }
        }

        /// <summary>Nút menu của mục đang xem được tô đậm.</summary>
        private void UpdateMenuHighlight()
        {
            var map = new Dictionary<Button, TabPage>
            {
                { btnThongTin, tabThongTin }, { btnKetQua, tabKetQua }, { btnHocPhi, tabHocPhi }
            };
            foreach (var btn in new[] { btnThongTin, btnKetQua, btnHocPhi, btnDangKyLop })
            {
                bool active = map.ContainsKey(btn) && tabHoSo.SelectedTab == map[btn];
                btn.BackColor = active ? Navy : Color.FromArgb(237, 242, 248);
                btn.ForeColor = active ? Color.White : Navy;
                btn.Font = new Font("Segoe UI", 10.5F, active ? FontStyle.Bold : FontStyle.Regular);
                btn.FlatAppearance.MouseOverBackColor = active ? Navy : NavyHover;
            }
        }

        private void TabHoSo_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tc = (TabControl)sender;
            bool selected = e.Index == tc.SelectedIndex;
            Rectangle r = e.Bounds;

            using (var back = new SolidBrush(selected ? Navy : Color.FromArgb(232, 238, 246)))
                e.Graphics.FillRectangle(back, r);

            TextRenderer.DrawText(e.Graphics, tc.TabPages[e.Index].Text,
                new Font("Segoe UI", 10F, selected ? FontStyle.Bold : FontStyle.Regular),
                r, selected ? Color.White : Navy,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        /// <summary>Phong cách chung cho các bảng dữ liệu.</summary>
        private void StyleGrid(DataGridView g)
        {
            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = Color.White;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.GridColor = LineColor;
            g.RowHeadersVisible = false;
            g.AllowUserToResizeRows = false;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.ReadOnly = true;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.RowTemplate.Height = 42;

            // Tiêu đề cột
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 44;
            var h = g.ColumnHeadersDefaultCellStyle;
            h.BackColor = Navy;
            h.ForeColor = Color.White;
            h.SelectionBackColor = Navy;
            h.SelectionForeColor = Color.White;
            h.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            h.Alignment = DataGridViewContentAlignment.MiddleLeft;
            h.Padding = new Padding(10, 0, 10, 0);

            // Ô dữ liệu
            var d = g.DefaultCellStyle;
            d.BackColor = Color.White;
            d.ForeColor = Color.FromArgb(40, 50, 65);
            d.SelectionBackColor = RowSelect;
            d.SelectionForeColor = Navy;
            d.Font = new Font("Segoe UI", 10F);
            d.Padding = new Padding(10, 0, 10, 0);
            d.Alignment = DataGridViewContentAlignment.MiddleLeft;

            g.AlternatingRowsDefaultCellStyle.BackColor = RowAlt;
            g.AlternatingRowsDefaultCellStyle.SelectionBackColor = RowSelect;
            g.AlternatingRowsDefaultCellStyle.SelectionForeColor = Navy;
        }

        /// <summary>Việt hóa tiêu đề, định dạng tiền / ngày, tô màu trạng thái.</summary>
        private void FormatGrid(DataGridView g)
        {
            foreach (DataGridViewColumn col in g.Columns)
            {
                string key = col.DataPropertyName.Length > 0 ? col.DataPropertyName : col.Name;
                string title;
                if (HeaderMap.TryGetValue(key, out title)) col.HeaderText = title;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (Array.IndexOf(MoneyColumns, key) >= 0)
                {
                    col.DefaultCellStyle.Format = "#,##0\" đ\"";
                    col.DefaultCellStyle.FormatProvider = Vi;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.FillWeight = 110;
                }
                else if (key.StartsWith("Ngay", StringComparison.Ordinal))
                {
                    col.DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                else if (key == "HoaDonID")
                {
                    col.FillWeight = 70;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (key == "TenLop")
                {
                    col.FillWeight = 130;
                    col.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
            }

            // Tô màu cột trạng thái
            if (g.Columns.Contains("TrangThai"))
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    var cell = row.Cells["TrangThai"];
                    string text = Convert.ToString(cell.Value) ?? "";
                    cell.Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    cell.Style.ForeColor = StatusColor(text);
                }
            }

            // Cột kết quả: Đạt = xanh, Không đạt = đỏ
            if (g.Columns.Contains("KetQua"))
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    var cell = row.Cells["KetQua"];
                    string text = (Convert.ToString(cell.Value) ?? "").ToLowerInvariant();
                    if (text.Length == 0) continue;
                    cell.Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    cell.Style.ForeColor = text.Contains("không") || text.Contains("chưa") || text.Contains("rớt")
                        ? Red : Green;
                }
            }

            g.ClearSelection();
            g.CurrentCell = null;
        }

        private static Color StatusColor(string text)
        {
            string t = text.ToLowerInvariant();
            if (t.Contains("đã đủ") || t.Contains("hoàn thành") || t.Contains("đang học") || t.Contains("đã đăng ký"))
                return Green;
            if (t.Contains("chưa") || t.Contains("nợ") || t.Contains("hủy") || t.Contains("quá hạn"))
                return Red;
            return Orange; // còn thiếu, chờ xử lý, ...
        }

        /// <summary>Ba thẻ tổng quan phía trên bảng học phí.</summary>
        private void BuildFeeSummary()
        {
            var tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 100,
                ColumnCount = 3,
                RowCount = 1,
                Padding = new Padding(0, 0, 0, 16),
                BackColor = Color.White
            };
            for (int i = 0; i < 3; i++) tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            tbl.Controls.Add(MakeCard("TỔNG PHẢI TRẢ", Navy, out lblTongPhaiTra, true), 0, 0);
            tbl.Controls.Add(MakeCard("ĐÃ THANH TOÁN", Green, out lblDaThanhToan, true), 1, 0);
            tbl.Controls.Add(MakeCard("CÒN PHẢI TRẢ", Orange, out lblConPhaiTra, false), 2, 0);

            // Thêm sau cùng => được bố trí trước, nằm phía trên bảng (bảng Dock.Fill).
            tabHocPhi.Controls.Add(tbl);

            // Thanh dưới cùng chứa nút Thanh toán (thêm sau => nằm dưới bảng).
            var bar = new Panel { Dock = DockStyle.Bottom, Height = 64, BackColor = Color.White, Padding = new Padding(0, 14, 0, 0) };
            btnThanhToan = new Button
            {
                Text = "Thanh toán học phí",
                Dock = DockStyle.Right,
                Width = 220,
                FlatStyle = FlatStyle.Flat,
                BackColor = Green,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnThanhToan.FlatAppearance.BorderSize = 0;
            btnThanhToan.Click += btnThanhToan_Click;
            bar.Controls.Add(btnThanhToan);
            tabHocPhi.Controls.Add(bar);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (!hocVienID.HasValue || hocVienID.Value <= 0)
            {
                MessageBox.Show("Vui lòng đăng nhập bằng tài khoản học viên.");
                return;
            }
            // true = khóa cứng vào học viên đang đăng nhập, không được lập phiếu cho người khác
            using (var frm = new frmLapPhieuThu(hocVienID.Value, true))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                    HocVienData.Run(LoadProfile);   // nạp lại để cập nhật học phí
            }
        }

        private Panel MakeCard(string title, Color accent, out Label valueLabel, bool gapRight)
        {
            var card = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = PageBg,
                Margin = new Padding(0, 0, gapRight ? 14 : 0, 0)
            };
            var stripe = new Panel { Dock = DockStyle.Left, Width = 5, BackColor = accent };
            var caption = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 34,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 112, 130),
                Padding = new Padding(16, 12, 0, 0)
            };
            valueLabel = new Label
            {
                Text = "0 đ",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 17F, FontStyle.Bold),
                ForeColor = accent,
                Padding = new Padding(16, 0, 0, 0),
                TextAlign = ContentAlignment.TopLeft
            };
            // Dock.Fill thêm trước, Top/Left thêm sau.
            card.Controls.Add(valueLabel);
            card.Controls.Add(caption);
            card.Controls.Add(stripe);
            return card;
        }

        private static decimal SumColumn(DataTable t, string col)
        {
            decimal sum = 0;
            if (t == null || !t.Columns.Contains(col)) return 0;
            foreach (DataRow r in t.Rows)
                if (!r.IsNull(col)) sum += Convert.ToDecimal(r[col]);
            return sum;
        }

        private static string Money(decimal v)
        {
            return v.ToString("#,##0", Vi) + " đ";
        }

        private void UpdateFeeSummary(DataTable fees)
        {
            decimal tong = SumColumn(fees, "TongPhaiTra");
            decimal da = SumColumn(fees, "DaThanhToan");
            decimal con = SumColumn(fees, "ConPhaiTra");
            lblTongPhaiTra.Text = Money(tong);
            lblDaThanhToan.Text = Money(da);
            lblConPhaiTra.Text = Money(con);
            lblConPhaiTra.ForeColor = con > 0 ? Red : Green;
            btnThanhToan.Enabled = con > 0;                     // đã đóng đủ thì khóa nút
            btnThanhToan.BackColor = con > 0 ? Green : Color.FromArgb(170, 180, 190);
        }

        // =====================================================================
        //  LOGIC (giữ nguyên)
        // =====================================================================

        private void LoadProfile()
        {
            if (!nguoiDungID.HasValue)
            {
                lblNguoiDangNhap.Text = "Chưa nhận tài khoản đăng nhập";
                MessageBox.Show("TV1 cần mở frmMainHocVien bằng NguoiDungID đã đăng nhập.");
                return;
            }
            var table = HocVienData.Query(@"SELECT h.*,n.TenDangNhap FROM HocVien h
JOIN NguoiDung n ON n.NguoiDungID=h.NguoiDungID
JOIN VaiTro v ON v.VaiTroID=n.VaiTroID
WHERE h.NguoiDungID=@id AND h.IsDeleted=0 AND n.IsDeleted=0 AND n.TrangThai=1
AND v.IsDeleted=0 AND v.TenVaiTro=N'Học viên'", HocVienData.P("@id", nguoiDungID.Value));
            if (table.Rows.Count != 1) throw new InvalidOperationException("Tài khoản chưa gắn học viên hoặc không còn được phép truy cập.");
            DataRow row = table.Rows[0];
            int id = Convert.ToInt32(row["HocVienID"]);
            hocVienID = id;
            txtHocVienID.Text = id.ToString(); txtHoTen.Text = Convert.ToString(row["HoTen"]);
            txtNgaySinh.Text = row.IsNull("NgaySinh") ? "" : Convert.ToDateTime(row["NgaySinh"]).ToString("dd/MM/yyyy");
            txtGioiTinh.Text = Convert.ToString(row["GioiTinh"]); txtSoDienThoai.Text = Convert.ToString(row["SoDienThoai"]);
            txtEmail.Text = Convert.ToString(row["Email"]); txtTrinhDoDauVao.Text = Convert.ToString(row["TrinhDoDauVao"]);
            txtDiemDauVao.Text = Convert.ToString(row["DiemDauVao"]); txtNhanXetDauVao.Text = Convert.ToString(row["NhanXetDauVao"]);
            txtTrangThai.Text = Convert.ToString(row["TrangThai"]); txtTaiKhoan.Text = Convert.ToString(row["TenDangNhap"]);
            lblNguoiDangNhap.Text = "Học viên: " + txtHoTen.Text;
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
            using (var form = new frmDangKyHoc(nguoiDungID.Value))
            {
                form.ShowDialog(this);
            }
            HocVienData.Run(LoadProfile);
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            tabHoSo.SelectedTab = tabThongTin;
        }

        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            tabHoSo.SelectedTab = tabLopHoc;
        }

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            tabHoSo.SelectedTab = tabKetQua;
        }

        private void btnHocPhi_Click(object sender, EventArgs e)
        {
            tabHoSo.SelectedTab = tabHocPhi;
        }
    }
}