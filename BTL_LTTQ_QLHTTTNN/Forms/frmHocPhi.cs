using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmHocPhi : Form
    {
        private const string PLACEHOLDER_SEARCH = "Tìm theo mã HĐ, tên học viên, SĐT...";

        public frmHocPhi()
        {
            InitializeComponent();
        }

        private void frmHocPhi_Load(object sender, EventArgs e)
        {
            DatabaseConnection.Connect();

            // Cấu hình DataGridView
            dgvHocPhi.EnableHeadersVisualStyles = false;
            dgvHocPhi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvHocPhi.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 116, 139);
            dgvHocPhi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvHocPhi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHocPhi.ColumnHeadersHeight = 40;
            dgvHocPhi.DefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 245, 249);
            dgvHocPhi.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            // Nạp ComboBox Trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] {
                "-- Tất cả trạng thái --",
                "Đã thu đủ",
                "Thanh toán 1 phần",
                "Chưa thanh toán"
            });
            cboTrangThai.SelectedIndex = 0;

            LoadDataHocPhi();
        }

        // 1. TÍNH TOÁN KPI & NẠP DỮ LIỆU TỪ SQL SERVER
        private void LoadDataHocPhi()
        {
            dgvHocPhi.Rows.Clear();

            string timKiem = (txtTimKiem.Text.Trim() == PLACEHOLDER_SEARCH) ? "" : txtTimKiem.Text.Trim();
            string trangThai = cboTrangThai.SelectedItem?.ToString() ?? "";

            // Câu truy vấn SQL đã khớp 100% với tên cột thực tế trong bảng HoaDon và HocVien
            string sql = @"SELECT hd.HoaDonID, 
                          'HD-' + CAST(hd.HoaDonID AS NVARCHAR) AS MaHoaDon, 
                          hv.HoTen AS TenHocVien, 
                          'HV-' + CAST(hv.HocVienID AS NVARCHAR) AS MaHocVien, 
                          ISNULL(hv.SoDienThoai, '') AS SoDienThoai,
                          N'Khóa học ngoại ngữ' AS TenKhoanThu,
                          hd.NgayLap, 
                          ISNULL(hd.TongTien, 0) AS TongTien, 
                          ISNULL(hd.GiamGia, 0) AS GiamGia,
                          ISNULL(hd.TongPhaiTra, ISNULL(hd.TongTien, 0) - ISNULL(hd.GiamGia, 0)) AS PhaiThu,
                          hd.TrangThai
                   FROM HoaDon hd
                   LEFT JOIN HocVien hv ON hd.HocVienID = hv.HocVienID
                   WHERE ISNULL(hd.IsDeleted, 0) = 0";

            if (!string.IsNullOrEmpty(timKiem))
            {
                sql += $" AND (CAST(hd.HoaDonID AS NVARCHAR) LIKE N'%{timKiem}%' OR hv.HoTen LIKE N'%{timKiem}%' OR hv.SoDienThoai LIKE N'%{timKiem}%')";
            }

            if (!string.IsNullOrEmpty(trangThai) && trangThai != "-- Tất cả trạng thái --")
            {
                sql += $" AND hd.TrangThai = N'{trangThai}'";
            }

            sql += " ORDER BY hd.NgayLap DESC";

            DataTable dt = DatabaseConnection.GetDataToTable(sql);

            decimal tongPhaiNop = 0;
            decimal tongDaThanhToan = 0;
            decimal tongConPhaiDong = 0;
            int countChuaThanhToan = 0;

            foreach (DataRow dr in dt.Rows)
            {
                int hdID = Convert.ToInt32(dr["HoaDonID"]);
                string maHD = dr["MaHoaDon"].ToString();
                string tenHV = dr["TenHocVien"].ToString();
                string maHV = dr["MaHocVien"].ToString();
                string sdt = dr["SoDienThoai"].ToString();
                string khoảnThu = dr["TenKhoanThu"].ToString();
                DateTime ngayLap = Convert.ToDateTime(dr["NgayLap"]);

                decimal tongTien = Convert.ToDecimal(dr["TongTien"]);
                decimal giamGia = Convert.ToDecimal(dr["GiamGia"]);
                decimal phaiThu = Convert.ToDecimal(dr["PhaiThu"]);
                string status = dr["TrangThai"].ToString();

                // Tính tiền thu thực tế dựa trên cột TrangThai
                decimal daThu = (status == "Đã thu đủ") ? phaiThu : 0;
                decimal conThieu = phaiThu - daThu;
                if (conThieu < 0) conThieu = 0;

                tongPhaiNop += phaiThu;
                tongDaThanhToan += daThu;
                tongConPhaiDong += conThieu;

                if (status == "Chưa thanh toán" || conThieu > 0)
                {
                    countChuaThanhToan++;
                }

                int rowIndex = dgvHocPhi.Rows.Add(
                    maHD,
                    $"{tenHV}|{maHV} • {sdt}",
                    khoảnThu,
                    ngayLap.ToString("dd/MM/yyyy"),
                    $"{tongTien:N0} đ",
                    $"-{giamGia:N0} đ",
                    $"{phaiThu:N0} đ",
                    $"{status}|Đã thu: {daThu:N0} đ",
                    "🖨"
                );

                dgvHocPhi.Rows[rowIndex].Tag = hdID;
            }

            // Cập nhật các ô Thống kê KPI trên cùng
            lblTongPhaiNop.Text = $"{tongPhaiNop:N0} đ";
            lblDaThanhToan.Text = $"{tongDaThanhToan:N0} đ";
            lblConPhaiDong.Text = $"{tongConPhaiDong:N0} đ";
            lblChuaThanhToanCount.Text = countChuaThanhToan.ToString();
        }
        // 2. BỘ LỌC VÀ TÌM KIẾM
        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadDataHocPhi();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = PLACEHOLDER_SEARCH;
            txtTimKiem.ForeColor = Color.Gray;
            cboTrangThai.SelectedIndex = 0;
            LoadDataHocPhi();
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == PLACEHOLDER_SEARCH)
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = PLACEHOLDER_SEARCH;
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        // 3. MỞ FORM LẬP PHIẾU THU MỚI
        private void btnLapPhieuThu_Click(object sender, EventArgs e)
        {
            frmLapPhieuThu frm = new frmLapPhieuThu();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDataHocPhi();
            }
        }

        // 4. CLICK IN PHIẾU THU / XEM CHI TIẾT
        private void dgvHocPhi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvHocPhi.Columns[e.ColumnIndex].Name == "colThaoTac")
            {
                int hdID = Convert.ToInt32(dgvHocPhi.Rows[e.RowIndex].Tag);
                MessageBox.Show($"Đang chuẩn bị in Phiếu Thu / Hóa Đơn mã ID: {hdID}...", "Thông báo In Phiếu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 5. TÙY BIẾN ĐỒ HỌA DATA GRID VIEW
        private void dgvHocPhi_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvHocPhi.Columns[e.ColumnIndex].Name;

            // Cột MÃ HĐ (Khung bo xám)
            if (colName == "colMaHD")
            {
                e.PaintBackground(e.CellBounds, true);
                string maHD = e.Value?.ToString() ?? "";
                Rectangle rect = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + 16, 65, 28);

                using (GraphicsPath path = GetRoundedPath(rect, 6))
                using (SolidBrush bg = new SolidBrush(Color.FromArgb(241, 245, 249)))
                using (Pen border = new Pen(Color.FromArgb(203, 213, 225), 1f))
                using (SolidBrush text = new SolidBrush(Color.FromArgb(30, 41, 59)))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(bg, path);
                    e.Graphics.DrawPath(border, path);
                    e.Graphics.DrawString(maHD, new Font("Segoe UI", 8.5f, FontStyle.Bold), text, rect, sf);
                }
                e.Handled = true;
                return;
            }

            // Cột HỌC VIÊN (Chữ đậm + Mã SĐT màu xám bên dưới)
            if (colName == "colHocVien")
            {
                e.PaintBackground(e.CellBounds, true);
                string raw = e.Value?.ToString() ?? "";
                string[] parts = raw.Split('|');

                if (parts.Length >= 2)
                {
                    using (SolidBrush nameBrush = new SolidBrush(Color.FromArgb(15, 23, 42)))
                    using (SolidBrush subBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                    {
                        e.Graphics.DrawString(parts[0], new Font("Segoe UI", 9f, FontStyle.Bold), nameBrush, e.CellBounds.X + 5, e.CellBounds.Y + 14);
                        e.Graphics.DrawString(parts[1], new Font("Segoe UI", 8f), subBrush, e.CellBounds.X + 5, e.CellBounds.Y + 35);
                    }
                }
                e.Handled = true;
                return;
            }

            // Cột KHOẢN THU (Màu xanh dương)
            if (colName == "colKhoanThu")
            {
                e.PaintBackground(e.CellBounds, true);
                string text = e.Value?.ToString() ?? "";
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(13, 110, 253)))
                {
                    e.Graphics.DrawString(text, new Font("Segoe UI", 9f, FontStyle.Bold), brush, e.CellBounds.X + 5, e.CellBounds.Y + 22);
                }
                e.Handled = true;
                return;
            }

            // Cột GIẢM GIÁ (Màu đỏ)
            if (colName == "colGiamGia")
            {
                e.PaintBackground(e.CellBounds, true);
                string text = e.Value?.ToString() ?? "";
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(220, 53, 69)))
                {
                    e.Graphics.DrawString(text, new Font("Segoe UI", 9f), brush, e.CellBounds.X + 5, e.CellBounds.Y + 22);
                }
                e.Handled = true;
                return;
            }

            // Cột TRẠNG THÁI (Tag Bo Tròn Xanh/Vàng/Đỏ)
            if (colName == "colTrangThai")
            {
                e.PaintBackground(e.CellBounds, true);
                string raw = e.Value?.ToString() ?? "";
                string[] parts = raw.Split('|');

                string status = parts[0];
                string subText = parts.Length > 1 ? parts[1] : "";

                Color bgColor = Color.FromArgb(209, 250, 229);
                Color textColor = Color.FromArgb(6, 95, 70);

                if (status == "Chưa thanh toán")
                {
                    bgColor = Color.FromArgb(254, 226, 226);
                    textColor = Color.FromArgb(153, 27, 27);
                }
                else if (status == "Thanh toán 1 phần")
                {
                    bgColor = Color.FromArgb(254, 243, 199);
                    textColor = Color.FromArgb(146, 64, 14);
                }

                Rectangle tagRect = new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y + 12, 100, 22);
                using (GraphicsPath path = GetRoundedPath(tagRect, 10))
                using (SolidBrush bg = new SolidBrush(bgColor))
                using (SolidBrush text = new SolidBrush(textColor))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(bg, path);
                    e.Graphics.DrawString(status, new Font("Segoe UI", 7.5f, FontStyle.Bold), text, tagRect, sf);
                }

                if (!string.IsNullOrEmpty(subText))
                {
                    using (SolidBrush subBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                    {
                        e.Graphics.DrawString(subText, new Font("Segoe UI", 8f), subBrush, e.CellBounds.X + 5, e.CellBounds.Y + 38);
                    }
                }

                e.Handled = true;
                return;
            }

            // Cột THAO TÁC (Nút in)
            if (colName == "colThaoTac")
            {
                e.PaintBackground(e.CellBounds, true);
                Rectangle btnRect = new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + 18, 30, 30);
                using (GraphicsPath path = GetRoundedPath(btnRect, 6))
                using (SolidBrush bg = new SolidBrush(Color.FromArgb(248, 249, 250)))
                using (Pen border = new Pen(Color.FromArgb(203, 213, 225), 1f))
                using (SolidBrush iconBrush = new SolidBrush(Color.FromArgb(71, 85, 105)))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(bg, path);
                    e.Graphics.DrawPath(border, path);
                    e.Graphics.DrawString("🖨", new Font("Segoe UI", 10f), iconBrush, btnRect, sf);
                }
                e.Handled = true;
                return;
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