using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BTL_LTTQ_QLHTTTNN.Services;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmLopHoc : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public frmLopHoc()
        {
            InitializeComponent();
        }

        private void frmLopHoc_Load(object sender, EventArgs e)
        {
            DatabaseConnection.Connect();

            // 1. PHÂN QUYỀN NÚT "MỞ LỚP HỌC"
            var user = SessionContext.NguoiDungHienTai;
            bool isQuanLy = (user != null && (user.VaiTro == "Admin" || user.VaiTro == "Nhân viên"));
            btnMoLopHoc.Visible = isQuanLy;

            dgvLopHoc.EnableHeadersVisualStyles = false;
            dgvLopHoc.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 247, 250);
            dgvLopHoc.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 37, 41);

            dgvLopHoc.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvLopHoc.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvLopHoc.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgvLopHoc.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dgvLopHoc.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvLopHoc.ColumnHeadersHeight = 40;
            dgvLopHoc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            SendMessage(txtTimKiem.Handle, EM_SETCUEBANNER, 0, "Tên lớp, khóa học, giáo viên, cơ sở...");

            LoadComboBoxFilter();
            LoadDataLopHoc();
        }

        private void LoadComboBoxFilter()
        {
            cboFilterKhoaHoc.Items.Clear();
            cboFilterKhoaHoc.Items.Add("Tất cả khóa học");
            DataTable dtKhoa = DatabaseConnection.GetDataToTable("SELECT TenKhoaHoc FROM KhoaHoc WHERE IsDeleted = 0");
            foreach (DataRow dr in dtKhoa.Rows)
            {
                cboFilterKhoaHoc.Items.Add(dr["TenKhoaHoc"].ToString());
            }
            cboFilterKhoaHoc.SelectedIndex = 0;

            cboFilterTrangThai.Items.Clear();
            cboFilterTrangThai.Items.Add("Tất cả trạng thái");
            cboFilterTrangThai.Items.Add("Đang mở");
            cboFilterTrangThai.Items.Add("Sắp mở");
            cboFilterTrangThai.Items.Add("Đã kết thúc");
            cboFilterTrangThai.SelectedIndex = 0;
        }

        private void LoadDataLopHoc(string keyword = "", string khoaHoc = "", string trangThai = "")
        {
            string sql = "SELECT l.LopHocID, " +
                         "'LH-' + RIGHT('00' + CAST(l.LopHocID AS VARCHAR), 3) AS MaLop, " +
                         "l.TenLop, " +
                         "ISNULL(k.TenKhoaHoc, N'TOEIC 500 Mục Tiêu') AS TenKhoaHoc, " +
                         "ISNULL(cs.TenCoSo, N'Cơ sở Cầu Giấy') AS TenCoSo, " +
                         "ISNULL(ns.HoTen, N'Chưa phân công') AS TenGiaoVien, " +
                         "'1/' + CAST(l.SiSoToiDa AS NVARCHAR) AS SiSoHienTaiMax, " +
                         "CONVERT(VARCHAR(10), l.NgayBatDau, 103) + ' - ' + CONVERT(VARCHAR(10), l.NgayKetThuc, 103) AS ThoiGianHoc, " +
                         "ISNULL(l.TrangThai, N'Đang mở') AS TrangThai " +
                         "FROM LopHoc l " +
                         "LEFT JOIN KhoaHoc k ON l.KhoaHocID = k.KhoaHocID " +
                         "LEFT JOIN CoSo cs ON l.CoSoID = cs.CoSoID " +
                         "LEFT JOIN NhanSu ns ON l.GiaoVienPhuTrachID = ns.NhanSuID " +
                         "WHERE l.IsDeleted = 0";

            // 2. LỌC DANH SÁCH LỚP THEO VAI TRÒ NGƯỜI DÙNG
            var user = SessionContext.NguoiDungHienTai;
            if (user != null)
            {
                if (user.VaiTro == "Giáo viên" && user.NhanSuID.HasValue)
                {
                    sql += $" AND l.GiaoVienPhuTrachID = {user.NhanSuID.Value}";
                }
                else if ((user.VaiTro == "Học viên" || user.VaiTro == "HocVien") && user.HocVienID.HasValue)
                {
                    sql += $" AND l.LopHocID IN (SELECT LopHocID FROM ChiTietLopHoc WHERE HocVienID = {user.HocVienID.Value})";
                }
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string kw = keyword.Trim();
                sql += $" AND (l.TenLop LIKE N'%{kw}%' OR k.TenKhoaHoc LIKE N'%{kw}%' OR ns.HoTen LIKE N'%{kw}%')";
            }

            if (!string.IsNullOrWhiteSpace(khoaHoc) && khoaHoc != "Tất cả khóa học")
            {
                sql += $" AND k.TenKhoaHoc = N'{khoaHoc}'";
            }

            if (!string.IsNullOrWhiteSpace(trangThai) && trangThai != "Tất cả trạng thái")
            {
                sql += $" AND l.TrangThai = N'{trangThai}'";
            }

            DataTable dt = DatabaseConnection.GetDataToTable(sql);

            dgvLopHoc.AutoGenerateColumns = false;
            colLopHocID.DataPropertyName = "LopHocID";
            colMaLop.DataPropertyName = "MaLop";
            colTenLopCustom.DataPropertyName = "TenLop";
            colKhoaHoc.DataPropertyName = "TenKhoaHoc";
            colCoSo.DataPropertyName = "TenCoSo";
            colGiaoVien.DataPropertyName = "TenGiaoVien";
            colSiSo.DataPropertyName = "SiSoHienTaiMax";
            colThoiGian.DataPropertyName = "ThoiGianHoc";
            colTrangThai.DataPropertyName = "TrangThai";

            dgvLopHoc.DataSource = dt;

            lblThongKe.Text = $"Hiển thị {dt.Rows.Count} / {dt.Rows.Count} lớp học";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text;
            string khoaHoc = cboFilterKhoaHoc.SelectedItem?.ToString() ?? "";
            string trangThai = cboFilterTrangThai.SelectedItem?.ToString() ?? "";

            LoadDataLopHoc(keyword, khoaHoc, trangThai);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            cboFilterKhoaHoc.SelectedIndex = 0;
            cboFilterTrangThai.SelectedIndex = 0;
            LoadDataLopHoc();
        }

        private void btnMoLopHoc_Click(object sender, EventArgs e)
        {
            var user = SessionContext.NguoiDungHienTai;
            if (user != null && user.VaiTro != "Admin" && user.VaiTro != "Nhân viên")
            {
                MessageBox.Show("Bạn không có quyền mở lớp học mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmChiTietLopHoc frm = new frmChiTietLopHoc(0);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDataLopHoc();
            }
        }

        private void dgvLopHoc_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvLopHoc.Columns[e.ColumnIndex].Name;
            bool isSelected = e.State.HasFlag(DataGridViewElementStates.Selected);

            Color cellBgColor = isSelected ? Color.FromArgb(245, 247, 250) : Color.White;

            if (colName != "colMaLop" && colName != "colTrangThai" && colName != "colThaoTac")
            {
                using (SolidBrush bgBrush = new SolidBrush(cellBgColor))
                {
                    e.Graphics.FillRectangle(bgBrush, e.CellBounds);
                }

                e.PaintContent(e.CellBounds);

                using (Pen borderPen = new Pen(Color.FromArgb(238, 238, 238), 1f))
                {
                    e.Graphics.DrawLine(borderPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                e.Handled = true;
                return;
            }

            if (colName == "colMaLop")
            {
                using (SolidBrush bgBrush = new SolidBrush(cellBgColor))
                {
                    e.Graphics.FillRectangle(bgBrush, e.CellBounds);
                }

                string maLop = dgvLopHoc.Rows[e.RowIndex].Cells["colMaLop"].Value?.ToString() ?? "";
                string tenLop = dgvLopHoc.Rows[e.RowIndex].Cells["colTenLopCustom"].Value?.ToString() ?? "";

                int padX = e.CellBounds.X + 10;
                int padY = e.CellBounds.Y + 8;

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                if (!string.IsNullOrEmpty(maLop))
                {
                    SizeF tagSize = e.Graphics.MeasureString(maLop, new Font("Segoe UI", 8f, FontStyle.Bold));
                    Rectangle tagRect = new Rectangle(padX, padY, (int)tagSize.Width + 12, 20);

                    using (GraphicsPath path = GetRoundedPath(tagRect, 10))
                    using (Pen pen = new Pen(Color.FromArgb(13, 110, 253), 1f))
                    using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(13, 110, 253)))
                    using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        e.Graphics.DrawPath(pen, path);
                        e.Graphics.DrawString(maLop, new Font("Segoe UI", 8f, FontStyle.Bold), textBrush, tagRect, sf);
                    }
                }

                if (!string.IsNullOrEmpty(tenLop))
                {
                    Rectangle textRect = new Rectangle(padX, padY + 22, e.CellBounds.Width - 15, 26);
                    using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(33, 37, 41)))
                    using (StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter })
                    {
                        e.Graphics.DrawString(tenLop, new Font("Segoe UI", 9.5f, FontStyle.Bold), textBrush, textRect, sf);
                    }
                }

                using (Pen borderPen = new Pen(Color.FromArgb(238, 238, 238), 1f))
                {
                    e.Graphics.DrawLine(borderPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                e.Handled = true;
            }
            else if (colName == "colTrangThai")
            {
                using (SolidBrush bgBrush = new SolidBrush(cellBgColor))
                {
                    e.Graphics.FillRectangle(bgBrush, e.CellBounds);
                }

                string text = e.Value?.ToString() ?? "Đang mở";

                int badgeWidth = 85;
                int badgeHeight = 24;
                int x = e.CellBounds.X + (e.CellBounds.Width - badgeWidth) / 2;
                int y = e.CellBounds.Y + (e.CellBounds.Height - badgeHeight) / 2;

                Rectangle rect = new Rectangle(x, y, badgeWidth, badgeHeight);

                using (GraphicsPath path = GetRoundedPath(rect, 10))
                using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(233, 236, 239)))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(108, 117, 125)))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(bgBrush, path);
                    e.Graphics.DrawString(text, new Font("Segoe UI", 8.5f, FontStyle.Bold), textBrush, rect, sf);
                }

                using (Pen borderPen = new Pen(Color.FromArgb(238, 238, 238), 1f))
                {
                    e.Graphics.DrawLine(borderPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                e.Handled = true;
            }
            else if (colName == "colThaoTac")
            {
                using (SolidBrush bgBrush = new SolidBrush(cellBgColor))
                {
                    e.Graphics.FillRectangle(bgBrush, e.CellBounds);
                }

                var user = SessionContext.NguoiDungHienTai;
                bool isQuanLy = (user != null && (user.VaiTro == "Admin" || user.VaiTro == "Nhân viên"));

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                int btnSize = 28;

                if (isQuanLy)
                {
                    int gap = 8;
                    int startX = e.CellBounds.X + (e.CellBounds.Width - (btnSize * 2 + gap)) / 2;
                    int startY = e.CellBounds.Y + (e.CellBounds.Height - btnSize) / 2;

                    Rectangle rectEdit = new Rectangle(startX, startY, btnSize, btnSize);
                    Rectangle rectDel = new Rectangle(startX + btnSize + gap, startY, btnSize, btnSize);

                    using (GraphicsPath path = GetRoundedPath(rectEdit, 6))
                    using (Pen pen = new Pen(Color.FromArgb(13, 110, 253), 1.2f))
                    using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(13, 110, 253)))
                    using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        e.Graphics.DrawPath(pen, path);
                        e.Graphics.DrawString("✏", new Font("Segoe UI", 10f, FontStyle.Bold), textBrush, rectEdit, sf);
                    }

                    using (GraphicsPath path = GetRoundedPath(rectDel, 6))
                    using (Pen pen = new Pen(Color.FromArgb(220, 53, 69), 1.2f))
                    using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(220, 53, 69)))
                    using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        e.Graphics.DrawPath(pen, path);
                        e.Graphics.DrawString("🗑", new Font("Segoe UI", 10f, FontStyle.Bold), textBrush, rectDel, sf);
                    }
                }
                else
                {
                    int startX = e.CellBounds.X + (e.CellBounds.Width - btnSize) / 2;
                    int startY = e.CellBounds.Y + (e.CellBounds.Height - btnSize) / 2;
                    Rectangle rectView = new Rectangle(startX, startY, btnSize, btnSize);

                    using (GraphicsPath path = GetRoundedPath(rectView, 6))
                    using (Pen pen = new Pen(Color.FromArgb(13, 110, 253), 1.2f))
                    using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(13, 110, 253)))
                    using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        e.Graphics.DrawPath(pen, path);
                        e.Graphics.DrawString("👁", new Font("Segoe UI", 10f, FontStyle.Bold), textBrush, rectView, sf);
                    }
                }

                using (Pen borderPen = new Pen(Color.FromArgb(238, 238, 238), 1f))
                {
                    e.Graphics.DrawLine(borderPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                e.Handled = true;
            }
        }

        private void dgvLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvLopHoc.Columns[e.ColumnIndex].Name;

            if (colName == "colThaoTac")
            {
                Rectangle cellBounds = dgvLopHoc.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                Point clickPoint = dgvLopHoc.PointToClient(Cursor.Position);
                int relativeX = clickPoint.X - cellBounds.X;

                int lopHocID = Convert.ToInt32(dgvLopHoc.Rows[e.RowIndex].Cells["colLopHocID"].Value ?? 0);
                string tenLop = dgvLopHoc.Rows[e.RowIndex].Cells["colTenLopCustom"].Value?.ToString() ?? "";

                var user = SessionContext.NguoiDungHienTai;
                bool isQuanLy = (user != null && (user.VaiTro == "Admin" || user.VaiTro == "Nhân viên"));

                int btnSize = 28;

                if (isQuanLy)
                {
                    int gap = 8;
                    int startX = (cellBounds.Width - (btnSize * 2 + gap)) / 2;

                    if (relativeX >= startX && relativeX <= startX + btnSize)
                    {
                        frmChiTietLopHoc frm = new frmChiTietLopHoc(lopHocID);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            LoadDataLopHoc();
                        }
                    }
                    else if (relativeX >= startX + btnSize + gap && relativeX <= startX + btnSize * 2 + gap)
                    {
                        if (MessageBox.Show($"Bạn có chắc chắn muốn xóa lớp '{tenLop}' không?", "Xác nhận xóa",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DatabaseConnection.RunSQL($"UPDATE LopHoc SET IsDeleted = 1 WHERE LopHocID = {lopHocID}");
                            LoadDataLopHoc();
                        }
                    }
                }
                else
                {
                    int startX = (cellBounds.Width - btnSize) / 2;
                    if (relativeX >= startX && relativeX <= startX + btnSize)
                    {
                        frmChiTietLopHoc frm = new frmChiTietLopHoc(lopHocID);
                        frm.ShowDialog();
                    }
                }
            }
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