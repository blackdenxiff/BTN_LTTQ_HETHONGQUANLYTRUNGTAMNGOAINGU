using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmLichHoc : Form
    {
        private DateTime _currentMonday;

        public frmLichHoc()
        {
            InitializeComponent();
        }

        private void frmLichHoc_Load(object sender, EventArgs e)
        {
            Functions.Connect();

            // Gán sự kiện CellClick trực tiếp trong Load để đảm bảo không bị sót
            dgvLichHoc.CellClick -= dgvLichHoc_CellClick;
            dgvLichHoc.CellClick += dgvLichHoc_CellClick;

            dgvLichHoc.ShowCellToolTips = false;
            dgvLichHoc.EnableHeadersVisualStyles = false;
            dgvLichHoc.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvLichHoc.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvLichHoc.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvLichHoc.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLichHoc.ColumnHeadersHeight = 45;
            dgvLichHoc.RowTemplate.Height = 115;
            dgvLichHoc.DefaultCellStyle.SelectionBackColor = Color.White;

            DateTime today = DateTime.Today;
            int delta = DayOfWeek.Monday - today.DayOfWeek;
            if (delta > 0) delta -= 7;
            _currentMonday = today.AddDays(delta);

            LoadFilterLop();
            UpdateWeekDisplay();
            LoadDataThoiKhoaBieu();
        }

        private void LoadFilterLop()
        {
            cboFilterLop.Items.Clear();
            cboFilterLop.Items.Add("-- Tất cả các lớp --");
            DataTable dtLop = Functions.GetDataToTable("SELECT TenLop FROM LopHoc WHERE IsDeleted = 0");
            foreach (DataRow dr in dtLop.Rows)
            {
                cboFilterLop.Items.Add(dr["TenLop"].ToString());
            }
            cboFilterLop.SelectedIndex = 0;
        }

        private void UpdateWeekDisplay()
        {
            DateTime sunday = _currentMonday.AddDays(6);
            btnWeek.Text = $"Tuần ({_currentMonday:dd/MM} - {sunday:dd/MM})";

            dgvLichHoc.Columns["colThu2"].HeaderText = $"THỨ 2\n{_currentMonday:dd/MM}";
            dgvLichHoc.Columns["colThu3"].HeaderText = $"THỨ 3\n{_currentMonday.AddDays(1):dd/MM}";
            dgvLichHoc.Columns["colThu4"].HeaderText = $"THỨ 4\n{_currentMonday.AddDays(2):dd/MM}";
            dgvLichHoc.Columns["colThu5"].HeaderText = $"THỨ 5\n{_currentMonday.AddDays(3):dd/MM}";
            dgvLichHoc.Columns["colThu6"].HeaderText = $"THỨ 6\n{_currentMonday.AddDays(4):dd/MM}";
            dgvLichHoc.Columns["colThu7"].HeaderText = $"THỨ 7\n{_currentMonday.AddDays(5):dd/MM}";
            dgvLichHoc.Columns["colCN"].HeaderText = $"CHỦ NHẬT\n{sunday:dd/MM}";
        }

        private void LoadDataThoiKhoaBieu()
        {
            dgvLichHoc.Rows.Clear();

            dgvLichHoc.Rows.Add("Ca Sáng\n08:00 - 10:00");
            dgvLichHoc.Rows.Add("Ca Chiều\n14:00 - 16:00");
            dgvLichHoc.Rows.Add("Ca Tối\n18:00 - 20:00");

            DateTime tuNgay = _currentMonday;
            DateTime denNgay = _currentMonday.AddDays(6);

            string filterLop = cboFilterLop.SelectedItem?.ToString() ?? "";

            string sql = $"SELECT lh.LichHocID, lh.NgayHoc, lh.GioBatDau, l.TenLop, p.TenPhong, ISNULL(ns.HoTen, N'Chưa phân công') AS TenGiaoVien " +
                         $"FROM LichHoc lh " +
                         $"LEFT JOIN LopHoc l ON lh.LopHocID = l.LopHocID " +
                         $"LEFT JOIN PhongHoc p ON lh.PhongHocID = p.PhongHocID " +
                         $"LEFT JOIN NhanSu ns ON l.GiaoVienPhuTrachID = ns.NhanSuID " +
                         $"WHERE lh.IsDeleted = 0 AND lh.NgayHoc BETWEEN '{tuNgay:yyyy-MM-dd}' AND '{denNgay:yyyy-MM-dd}'";

            if (!string.IsNullOrEmpty(filterLop) && filterLop != "-- Tất cả các lớp --")
            {
                sql += $" AND l.TenLop = N'{filterLop}'";
            }

            DataTable dtLich = Functions.GetDataToTable(sql);

            foreach (DataRow dr in dtLich.Rows)
            {
                int lichHocID = Convert.ToInt32(dr["LichHocID"]);
                DateTime ngayHoc = Convert.ToDateTime(dr["NgayHoc"]);
                TimeSpan gioBatDau = (TimeSpan)dr["GioBatDau"];
                string tenLop = dr["TenLop"].ToString();
                string tenPhong = dr["TenPhong"].ToString();
                string tenGV = dr["TenGiaoVien"].ToString();

                int colIndex = (int)(ngayHoc.Date - tuNgay.Date).TotalDays + 1;

                int rowIndex = -1;
                if (gioBatDau.Hours == 8) rowIndex = 0;       // Ca Sáng
                else if (gioBatDau.Hours == 14) rowIndex = 1; // Ca Chiều
                else if (gioBatDau.Hours == 18) rowIndex = 2; // Ca Tối

                if (rowIndex >= 0 && colIndex >= 1 && colIndex <= 7)
                {
                    dgvLichHoc.Rows[rowIndex].Cells[colIndex].Value = $"{lichHocID}|{tenLop}|{tenGV}|{tenPhong}";
                }
            }
        }

        private void btnPrevWeek_Click(object sender, EventArgs e)
        {
            _currentMonday = _currentMonday.AddDays(-7);
            UpdateWeekDisplay();
            LoadDataThoiKhoaBieu();
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            _currentMonday = _currentMonday.AddDays(7);
            UpdateWeekDisplay();
            LoadDataThoiKhoaBieu();
        }

        private void cboFilterLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataThoiKhoaBieu();
        }

        private void btnXepLichHocMoi_Click(object sender, EventArgs e)
        {
            frmTaoLichHoc frm = new frmTaoLichHoc(0);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDataThoiKhoaBieu();
            }
        }

        private void dgvLichHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1) return;

            object cellValue = dgvLichHoc.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
            {
                string[] parts = cellValue.ToString().Split('|');
                if (parts.Length > 0 && int.TryParse(parts[0], out int lichHocID))
                {
                    frmTaoLichHoc frm = new frmTaoLichHoc(lichHocID);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadDataThoiKhoaBieu();
                    }
                }
            }
        }

        private void dgvLichHoc_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvLichHoc.Columns[e.ColumnIndex].Name;

            if (colName == "colKhungGio")
            {
                e.PaintBackground(e.CellBounds, true);
                string text = e.Value?.ToString() ?? "";
                string[] lines = text.Split('\n');

                int padY = e.CellBounds.Y + (e.CellBounds.Height - 42) / 2;

                if (lines.Length >= 2)
                {
                    using (SolidBrush titleBrush = new SolidBrush(Color.FromArgb(30, 41, 59)))
                    using (SolidBrush subBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                    using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center })
                    {
                        e.Graphics.DrawString(lines[0], new Font("Segoe UI", 9.5f, FontStyle.Bold), titleBrush, new RectangleF(e.CellBounds.X, padY, e.CellBounds.Width, 22), sf);
                        e.Graphics.DrawString(lines[1], new Font("Segoe UI", 8.5f), subBrush, new RectangleF(e.CellBounds.X, padY + 22, e.CellBounds.Width, 20), sf);
                    }
                }
                e.Handled = true;
                return;
            }

            e.PaintBackground(e.CellBounds, true);
            string cellValue = e.Value?.ToString() ?? "";

            if (!string.IsNullOrEmpty(cellValue))
            {
                string[] parts = cellValue.Split('|');
                string tenLop = parts.Length > 1 ? parts[1] : "";
                string gv = parts.Length > 2 ? parts[2] : "";
                string phong = parts.Length > 3 ? parts[3] : "";

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle cardRect = new Rectangle(e.CellBounds.X + 6, e.CellBounds.Y + 6, e.CellBounds.Width - 12, e.CellBounds.Height - 12);

                using (GraphicsPath path = GetRoundedPath(cardRect, 8))
                using (SolidBrush cardBg = new SolidBrush(Color.FromArgb(235, 243, 255)))
                using (Pen cardBorder = new Pen(Color.FromArgb(147, 197, 253), 1.2f))
                {
                    e.Graphics.FillPath(cardBg, path);
                    e.Graphics.DrawPath(cardBorder, path);
                }

                Rectangle textLopRect = new Rectangle(cardRect.X + 10, cardRect.Y + 10, cardRect.Width - 20, 22);
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(30, 41, 59)))
                using (StringFormat sf = new StringFormat { Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap })
                {
                    e.Graphics.DrawString(tenLop, new Font("Segoe UI", 9f, FontStyle.Bold), textBrush, textLopRect, sf);
                }

                Rectangle textGvRect = new Rectangle(cardRect.X + 10, cardRect.Y + 34, cardRect.Width - 20, 20);
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(71, 85, 105)))
                using (StringFormat sf = new StringFormat { Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap })
                {
                    e.Graphics.DrawString("GV: " + gv, new Font("Segoe UI", 8.25f), textBrush, textGvRect, sf);
                }

                SizeF badgeSize = e.Graphics.MeasureString(phong, new Font("Segoe UI", 8f, FontStyle.Bold));
                int badgeW = Math.Max((int)badgeSize.Width + 16, 48);
                Rectangle badgeRect = new Rectangle(cardRect.X + 10, cardRect.Y + 58, badgeW, 20);

                using (GraphicsPath badgePath = GetRoundedPath(badgeRect, 6))
                using (SolidBrush badgeBg = new SolidBrush(Color.FromArgb(16, 185, 129)))
                using (SolidBrush badgeText = new SolidBrush(Color.White))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.FillPath(badgeBg, badgePath);
                    e.Graphics.DrawString(phong, new Font("Segoe UI", 8f, FontStyle.Bold), badgeText, badgeRect, sf);
                }
            }

            e.Handled = true;
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2f;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}