using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using BTL_LTTQ_QLHTTTNN.Services;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmDiemDanh : Form
    {
        public event EventHandler TaiDanhSachYeuCau;
        public event EventHandler LuuYeuCau;
        public event EventHandler LopThayDoi;
        public event EventHandler XuatExcelYeuCau;
        public event EventHandler CanhBaoVangMatYeuCau;

        private Button btnDiemDanhNhanh;
        private Button btnXuatExcel;
        private Button btnCanhBaoVangMat;

        public int NhanSuID { get; set; } = 2;

        public ComboBox LopHoc { get { return cboLop; } }
        public ComboBox BuoiHoc { get { return cboBuoiHoc; } }
        public DataGridView BangDuLieu { get { return dgvDiemDanh; } }
        public DataGridViewComboBoxColumn CotTrangThai { get { return colTrangThai; } }

        public frmDiemDanh()
        {
            InitializeComponent();
            this.dgvDiemDanh.DataError += (s, ev) => { ev.ThrowException = false; };
            this.dgvDiemDanh.CellFormatting += dgvDiemDanh_CellFormatting;

            CauHinhGiaoDienLuoi();
            KhoiTaoNutBoSung();

            // Khởi tạo Presenter xử lý nghiệp vụ CSDL theo kiến trúc MVP
            new DiemDanhPresenter(this);
        }

        public frmDiemDanh(int nhanSuId) : this()
        {
            if (nhanSuId > 0)
            {
                NhanSuID = nhanSuId;
            }
        }

        /// <summary>
        /// Tinh chỉnh giao diện DataGridView dgvDiemDanh: màu chữ đen rõ nét, hàng xen kẽ và header
        /// </summary>
        private void CauHinhGiaoDienLuoi()
        {
            // 1. Chỉnh màu chữ mặc định của toàn bộ DataGridView thành màu Đen (Color.Black)
            dgvDiemDanh.DefaultCellStyle.ForeColor = Color.Black;
            dgvDiemDanh.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDiemDanh.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvDiemDanh.RowsDefaultCellStyle.ForeColor = Color.Black;
            dgvDiemDanh.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            // 2. Tối ưu hiển thị xen kẽ với màu thật nhạt (AliceBlue) để dễ phân biệt các dòng
            dgvDiemDanh.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvDiemDanh.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgvDiemDanh.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvDiemDanh.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;

            // 3. Chỉnh màu chữ Header thành màu Đen dễ đọc trên nền xanh nhạt
            dgvDiemDanh.EnableHeadersVisualStyles = false;
            dgvDiemDanh.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(239, 246, 255);
            dgvDiemDanh.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvDiemDanh.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            // Cấu hình rõ ràng cho từng cột dữ liệu
            if (colMaHocVien != null) colMaHocVien.DefaultCellStyle.ForeColor = Color.Black;
            if (colHoTen != null) colHoTen.DefaultCellStyle.ForeColor = Color.Black;
            if (colTrangThai != null) colTrangThai.DefaultCellStyle.ForeColor = Color.Black;
            if (colGhiChu != null) colGhiChu.DefaultCellStyle.ForeColor = Color.Black;
        }

        /// <summary>
        /// Khởi tạo bằng code 2 nút: "Tất cả Có mặt" và "Xuất Excel" nằm cạnh các nút thao tác hiện có
        /// </summary>
        private void KhoiTaoNutBoSung()
        {
            // Nút "Tất cả Có mặt" (Điểm danh nhanh)
            btnDiemDanhNhanh = new Button();
            btnDiemDanhNhanh.Name = "btnDiemDanhNhanh";
            btnDiemDanhNhanh.Text = "Tất cả Có mặt";
            btnDiemDanhNhanh.Size = new Size(140, 36);
            btnDiemDanhNhanh.FlatStyle = FlatStyle.Flat;
            btnDiemDanhNhanh.FlatAppearance.BorderSize = 0;
            btnDiemDanhNhanh.BackColor = Color.FromArgb(16, 185, 129);
            btnDiemDanhNhanh.ForeColor = Color.White;
            btnDiemDanhNhanh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDiemDanhNhanh.Cursor = Cursors.Hand;
            btnDiemDanhNhanh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDiemDanhNhanh.Location = new Point(btnLuu.Left - 150, btnLuu.Top);
            btnDiemDanhNhanh.Click += btnDiemDanhNhanh_Click;

            // Nút "Xuất Excel"
            btnXuatExcel = new Button();
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.Size = new Size(120, 36);
            btnXuatExcel.FlatStyle = FlatStyle.Flat;
            btnXuatExcel.FlatAppearance.BorderSize = 0;
            btnXuatExcel.BackColor = Color.FromArgb(22, 163, 74);
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXuatExcel.Cursor = Cursors.Hand;
            btnXuatExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatExcel.Location = new Point(btnDiemDanhNhanh.Left - 130, btnLuu.Top);
            btnXuatExcel.Click += btnXuatExcel_Click;

            // Nút "Quét & Gửi Email Cảnh Báo" (Hệ thống Cảnh báo Chuyên cần)
            btnCanhBaoVangMat = new Button();
            btnCanhBaoVangMat.Name = "btnCanhBaoVangMat";
            btnCanhBaoVangMat.Text = "Quét & Gửi Email Cảnh Báo";
            btnCanhBaoVangMat.Size = new Size(210, 36);
            btnCanhBaoVangMat.FlatStyle = FlatStyle.Flat;
            btnCanhBaoVangMat.FlatAppearance.BorderSize = 0;
            btnCanhBaoVangMat.BackColor = Color.FromArgb(220, 38, 38);
            btnCanhBaoVangMat.ForeColor = Color.White;
            btnCanhBaoVangMat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCanhBaoVangMat.Cursor = Cursors.Hand;
            btnCanhBaoVangMat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCanhBaoVangMat.Location = new Point(btnXuatExcel.Left - 220, btnLuu.Top);
            btnCanhBaoVangMat.Click += btnCanhBaoVangMat_Click;

            lblTrangThai.Width = Math.Max(150, btnCanhBaoVangMat.Left - 35);

            pnlChan.Controls.Add(btnDiemDanhNhanh);
            pnlChan.Controls.Add(btnXuatExcel);
            pnlChan.Controls.Add(btnCanhBaoVangMat);
        }

        public void HienThongBao(string thongBao)
        {
            lblTrangThai.Text = thongBao;
        }

        public void DatCheDoChiXem(bool chiXem)
        {
            dgvDiemDanh.ReadOnly = chiXem;
            btnLuu.Visible = !chiXem;
            if (btnDiemDanhNhanh != null)
                btnDiemDanhNhanh.Visible = !chiXem;
        }

        /// <summary>
        /// UX: Bôi màu nền dòng thành màu Đỏ nhạt (LightPink) nếu trạng thái là "Vắng" hoặc "Nghỉ phép"
        /// </summary>
        private void dgvDiemDanh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvDiemDanh.Rows.Count) return;

            DataGridViewRow row = dgvDiemDanh.Rows[e.RowIndex];
            string trangThai = Convert.ToString(row.Cells["colTrangThai"].Value);

            if (trangThai == "Vắng" || trangThai == "Nghỉ phép")
            {
                row.DefaultCellStyle.BackColor = Color.LightPink;
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(244, 114, 182);
                row.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            else
            {
                row.DefaultCellStyle.BackColor = (e.RowIndex % 2 == 0) ? Color.White : Color.AliceBlue;
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
                row.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LopThayDoi != null)
            {
                LopThayDoi(this, EventArgs.Empty);
            }
        }

        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedIndex < 0 || cboBuoiHoc.SelectedIndex < 0)
            {
                HienThongBao("Vui lòng chọn lớp và buổi học trước.");
                return;
            }

            if (TaiDanhSachYeuCau != null)
            {
                TaiDanhSachYeuCau(this, EventArgs.Empty);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            btnTaiDanhSach_Click(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedIndex < 0 || cboBuoiHoc.SelectedIndex < 0)
            {
                HienThongBao("Vui lòng chọn lớp và buổi học trước.");
                return;
            }

            if (!dgvDiemDanh.EndEdit()) return;

            if (dgvDiemDanh.Rows.Count == 0)
            {
                HienThongBao("Chưa có danh sách học viên để lưu.");
                return;
            }

            if (LuuYeuCau != null)
            {
                LuuYeuCau(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Chuyển toàn bộ giá trị cột Trạng thái thành "Có mặt" và phát sự kiện Lưu
        /// </summary>
        private void btnDiemDanhNhanh_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedIndex < 0 || cboBuoiHoc.SelectedIndex < 0)
            {
                HienThongBao("Vui lòng chọn lớp và buổi học trước.");
                return;
            }

            if (dgvDiemDanh.Rows.Count == 0)
            {
                HienThongBao("Chưa có danh sách học viên để điểm danh.");
                return;
            }

            foreach (DataGridViewRow row in dgvDiemDanh.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells["colTrangThai"].Value = "Có mặt";
                }
            }
            dgvDiemDanh.EndEdit();
            dgvDiemDanh.Refresh();

            if (LuuYeuCau != null)
            {
                LuuYeuCau(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Phát sự kiện yêu cầu xuất dữ liệu sang Presenter
        /// </summary>
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedIndex < 0 || cboBuoiHoc.SelectedIndex < 0)
            {
                HienThongBao("Vui lòng chọn lớp và buổi học trước khi xuất file.");
                return;
            }

            if (dgvDiemDanh.Rows.Count == 0)
            {
                HienThongBao("Chưa có danh sách học viên để xuất Excel.");
                return;
            }

            if (XuatExcelYeuCau != null)
            {
                XuatExcelYeuCau(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Phát sự kiện yêu cầu quét học viên vắng >= 5 buổi và gửi email cảnh báo sang Presenter
        /// </summary>
        private void btnCanhBaoVangMat_Click(object sender, EventArgs e)
        {
            if (CanhBaoVangMatYeuCau != null)
            {
                CanhBaoVangMatYeuCau(this, EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// Presenter phụ trách toàn bộ xử lý nghiệp vụ CSDL cho frmDiemDanh theo mô hình MVP.
    /// Không viết trực tiếp câu lệnh SQL trong Form.
    /// </summary>
    public class DiemDanhPresenter
    {
        private readonly frmDiemDanh _view;
        private bool _dangNapDuLieu = false;

        public DiemDanhPresenter(frmDiemDanh view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));

            _view.Load += View_Load;
            _view.LopThayDoi += View_LopThayDoi;
            _view.TaiDanhSachYeuCau += View_TaiDanhSachYeuCau;
            _view.LuuYeuCau += View_LuuYeuCau;
            _view.XuatExcelYeuCau += View_XuatExcelYeuCau;
            _view.CanhBaoVangMatYeuCau += View_CanhBaoVangMatYeuCau;
        }

        private void View_Load(object sender, EventArgs e)
        {
            // Thiết lập đủ 4 giá trị chuẩn theo CSDL vào cột Trạng thái
            _view.CotTrangThai.Items.Clear();
            _view.CotTrangThai.Items.AddRange(new object[] { "Có mặt", "Vắng", "Đi muộn", "Nghỉ phép" });

            NapDanhSachLopHoc();
        }

        public void NapDanhSachLopHoc()
        {
            try
            {
                _dangNapDuLieu = true;
                DataTable dt = new DataTable();
                using (var con = DatabaseConnection.TaoKetNoi())
                {
                    using (var da = new SqlDataAdapter("SELECT LopHocID, TenLop FROM LopHoc ORDER BY TenLop", con))
                    {
                        da.Fill(dt);
                    }
                }

                _view.LopHoc.DisplayMember = "TenLop";
                _view.LopHoc.ValueMember = "LopHocID";
                _view.LopHoc.DataSource = dt;

                _dangNapDuLieu = false;

                if (dt != null && dt.Rows.Count > 0)
                {
                    _view.LopHoc.SelectedIndex = 0;
                    NapDanhSachBuoiHoc();
                }
                else
                {
                    _view.BuoiHoc.DataSource = null;
                    _view.HienThongBao("Chưa có lớp học nào trong hệ thống.");
                }
            }
            catch (Exception ex)
            {
                _view.HienThongBao("Lỗi tải lớp học: " + ex.Message);
            }
            finally
            {
                _dangNapDuLieu = false;
            }
        }

        public void NapDanhSachBuoiHoc()
        {
            if (_view.LopHoc.SelectedValue == null) return;

            int lopHocID;
            if (!int.TryParse(_view.LopHoc.SelectedValue.ToString(), out lopHocID)) return;

            try
            {
                DataTable dt = new DataTable();
                using (var con = DatabaseConnection.TaoKetNoi())
                {
                    string sql = @"SELECT LichHocID, CONVERT(varchar(10), NgayHoc, 103) AS NgayHoc, GioBatDau 
                                  FROM LichHoc 
                                  WHERE LopHocID = @LopHocID 
                                  ORDER BY NgayHoc, GioBatDau";
                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@LopHocID", lopHocID);
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                _view.BuoiHoc.DisplayMember = "NgayHoc";
                _view.BuoiHoc.ValueMember = "LichHocID";
                _view.BuoiHoc.DataSource = dt;

                if (dt != null && dt.Rows.Count > 0)
                {
                    _view.BuoiHoc.SelectedIndex = 0;
                    _view.HienThongBao(string.Format("Lớp có {0} buổi học. Hãy bấm 'Tải danh sách' để điểm danh.", dt.Rows.Count));
                }
                else
                {
                    _view.BangDuLieu.DataSource = null;
                    _view.HienThongBao("Lớp chưa có buổi học nào trong lịch học.");
                }
            }
            catch (Exception ex)
            {
                _view.HienThongBao("Lỗi tải buổi học: " + ex.Message);
            }
        }

        private void View_LopThayDoi(object sender, EventArgs e)
        {
            if (_dangNapDuLieu) return;
            if (_view.LopHoc.SelectedValue != null && int.TryParse(_view.LopHoc.SelectedValue.ToString(), out _))
            {
                NapDanhSachBuoiHoc();
            }
        }

        private void View_TaiDanhSachYeuCau(object sender, EventArgs e)
        {
            if (_view.LopHoc.SelectedValue == null || _view.BuoiHoc.SelectedValue == null)
            {
                _view.HienThongBao("Vui lòng chọn lớp và buổi học trước.");
                return;
            }

            int lopHocID;
            int lichHocID;
            if (!int.TryParse(_view.LopHoc.SelectedValue.ToString(), out lopHocID) ||
                !int.TryParse(_view.BuoiHoc.SelectedValue.ToString(), out lichHocID))
            {
                _view.HienThongBao("Thông tin lớp hoặc buổi học không hợp lệ.");
                return;
            }

            try
            {
                DataTable dt = new DataTable();
                using (var con = DatabaseConnection.TaoKetNoi())
                {
                    string sql = @"SELECT 
                                    hv.HocVienID AS MaHocVien,
                                    hv.HoTen,
                                    ISNULL(dd.TrangThai, N'Có mặt') AS TrangThai,
                                    ISNULL(dd.GhiChu, N'') AS GhiChu
                                  FROM DangKy dk
                                  JOIN HocVien hv ON dk.HocVienID = hv.HocVienID
                                  LEFT JOIN DiemDanh dd ON dd.HocVienID = hv.HocVienID AND dd.LichHocID = @LichHocID
                                  WHERE dk.LopHocID = @LopHocID
                                  ORDER BY hv.HoTen";
                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@LichHocID", lichHocID);
                        cmd.Parameters.AddWithValue("@LopHocID", lopHocID);
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                _view.BangDuLieu.DataSource = dt;

                if (dt != null && dt.Rows.Count > 0)
                    _view.HienThongBao(string.Format("Đã tải {0} học viên của buổi học.", dt.Rows.Count));
                else
                    _view.HienThongBao("Lớp này chưa có học viên nào đăng ký.");
            }
            catch (Exception ex)
            {
                _view.HienThongBao("Lỗi tải danh sách học viên: " + ex.Message);
            }
        }

        private void View_LuuYeuCau(object sender, EventArgs e)
        {
            if (_view.LopHoc.SelectedValue == null || _view.BuoiHoc.SelectedValue == null)
            {
                _view.HienThongBao("Vui lòng chọn lớp và buổi học trước.");
                return;
            }

            if (!_view.BangDuLieu.EndEdit()) return;

            if (_view.BangDuLieu.Rows.Count == 0)
            {
                _view.HienThongBao("Chưa có danh sách học viên để lưu.");
                return;
            }

            int lichHocID;
            if (!int.TryParse(_view.BuoiHoc.SelectedValue.ToString(), out lichHocID))
            {
                _view.HienThongBao("Buổi học không hợp lệ.");
                return;
            }

            string[] trangThaiHopLe = { "Có mặt", "Vắng", "Đi muộn", "Nghỉ phép" };

            // Kiểm tra tính hợp lệ trạng thái của từng dòng
            foreach (DataGridViewRow row in _view.BangDuLieu.Rows)
            {
                if (row.IsNewRow) continue;
                string tt = Convert.ToString(row.Cells["colTrangThai"].Value);
                if (string.IsNullOrWhiteSpace(tt) || Array.IndexOf(trangThaiHopLe, tt) < 0)
                {
                    string hoTen = Convert.ToString(row.Cells["colHoTen"].Value);
                    _view.HienThongBao(string.Format("Trạng thái của học viên '{0}' không hợp lệ. Chỉ chấp nhận: Có mặt, Vắng, Đi muộn, Nghỉ phép.", hoTen));
                    row.Cells["colTrangThai"].Selected = true;
                    return;
                }
            }

            try
            {
                using (var con = DatabaseConnection.TaoKetNoi())
                {
                    con.Open();
                    using (var tran = con.BeginTransaction())
                    {
                        string sqlUpsert = @"IF EXISTS (SELECT 1 FROM DiemDanh WHERE LichHocID = @LichHocID AND HocVienID = @HocVienID)
                                                UPDATE DiemDanh SET TrangThai = @TrangThai, GhiChu = @GhiChu WHERE LichHocID = @LichHocID AND HocVienID = @HocVienID;
                                             ELSE
                                                INSERT INTO DiemDanh (LichHocID, HocVienID, TrangThai, GhiChu) VALUES (@LichHocID, @HocVienID, @TrangThai, @GhiChu);";

                        foreach (DataGridViewRow row in _view.BangDuLieu.Rows)
                        {
                            if (row.IsNewRow) continue;
                            int hocVienID;
                            if (!int.TryParse(Convert.ToString(row.Cells["colMaHocVien"].Value), out hocVienID))
                                continue;

                            string tt = Convert.ToString(row.Cells["colTrangThai"].Value);
                            string ghiChu = Convert.ToString(row.Cells["colGhiChu"].Value) ?? "";

                            using (var cmd = new SqlCommand(sqlUpsert, con, tran))
                            {
                                cmd.Parameters.AddWithValue("@LichHocID", lichHocID);
                                cmd.Parameters.AddWithValue("@HocVienID", hocVienID);
                                cmd.Parameters.AddWithValue("@TrangThai", tt ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                    }
                }

                _view.HienThongBao(string.Format("Đã lưu điểm danh thành công cho {0} học viên!", _view.BangDuLieu.Rows.Count));
            }
            catch (Exception ex)
            {
                _view.HienThongBao("Lỗi lưu điểm danh: " + ex.Message);
            }
        }

        /// <summary>
        /// Logic xuất dữ liệu điểm danh ra file CSV / Excel thông qua SaveFileDialog
        /// </summary>
        private void View_XuatExcelYeuCau(object sender, EventArgs e)
        {
            try
            {
                if (_view.BangDuLieu.Rows.Count == 0)
                {
                    _view.HienThongBao("Chưa có danh sách học viên để xuất Excel.");
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    string tenLop = _view.LopHoc.Text.Replace(" ", "_");
                    string buoi = _view.BuoiHoc.Text.Replace("/", "-").Replace(" ", "_");
                    sfd.FileName = string.Format("DiemDanh_{0}_{1}.csv", tenLop, buoi);
                    sfd.Filter = "CSV File (*.csv)|*.csv|All Files (*.*)|*.*";
                    sfd.Title = "Xuất danh sách điểm danh ra file CSV / Excel";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(string.Format("\"BẢNG ĐIỂM DANH LỚP: {0} - BUỔI HỌC: {1}\"", _view.LopHoc.Text, _view.BuoiHoc.Text));
                        sb.AppendLine(string.Format("\"Thời điểm xuất: {0}\"", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
                        sb.AppendLine("\"Mã học viên\",\"Họ và tên\",\"Trạng thái\",\"Ghi chú\"");

                        foreach (DataGridViewRow row in _view.BangDuLieu.Rows)
                        {
                            if (row.IsNewRow) continue;
                            string ma = Convert.ToString(row.Cells["colMaHocVien"].Value);
                            string hoTen = Convert.ToString(row.Cells["colHoTen"].Value);
                            string trangThai = Convert.ToString(row.Cells["colTrangThai"].Value);
                            string ghiChu = Convert.ToString(row.Cells["colGhiChu"].Value);

                            sb.AppendLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"",
                                (ma ?? "").Replace("\"", "\"\""),
                                (hoTen ?? "").Replace("\"", "\"\""),
                                (trangThai ?? "").Replace("\"", "\"\""),
                                (ghiChu ?? "").Replace("\"", "\"\"")));
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
                        _view.HienThongBao("Đã xuất dữ liệu thành công ra file: " + Path.GetFileName(sfd.FileName));
                        MessageBox.Show("Xuất danh sách điểm danh ra file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                _view.HienThongBao("Lỗi xuất file: " + ex.Message);
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Logic Quét học viên vắng >= 5 buổi và gửi email cảnh báo tự động
        /// </summary>
        private void View_CanhBaoVangMatYeuCau(object sender, EventArgs e)
        {
            try
            {
                int nhanSuId = _view.NhanSuID;
                if (SessionContext.NguoiDungHienTai != null && SessionContext.NguoiDungHienTai.NhanSuID.HasValue && SessionContext.NguoiDungHienTai.NhanSuID.Value > 0)
                {
                    nhanSuId = SessionContext.NguoiDungHienTai.NhanSuID.Value;
                }
                else if (nhanSuId <= 0)
                {
                    nhanSuId = 2;
                }

                var dsHocVien = new List<HocVienCanhBaoDto>();

                using (var con = DatabaseConnection.TaoKetNoi())
                {
                    con.Open();
                    string sql = @"
                        SELECT hv.HoTen, hv.Email, lh.LopHocID, lop.TenLop, COUNT(dd.DiemDanhID) AS SoBuoiVang
                        FROM DiemDanh dd
                        JOIN LichHoc lh ON dd.LichHocID = lh.LichHocID
                        JOIN LopHoc lop ON lh.LopHocID = lop.LopHocID
                        JOIN HocVien hv ON dd.HocVienID = hv.HocVienID
                        WHERE lop.GiaoVienPhuTrachID = @NhanSuID 
                          AND dd.TrangThai = N'Vắng'
                          AND hv.Email IS NOT NULL 
                          AND hv.Email <> ''
                        GROUP BY hv.HoTen, hv.Email, lh.LopHocID, lop.TenLop
                        HAVING COUNT(dd.DiemDanhID) >= 5";

                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@NhanSuID", nhanSuId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dsHocVien.Add(new HocVienCanhBaoDto
                                {
                                    HoTen = reader["HoTen"] != DBNull.Value ? reader["HoTen"].ToString() : "",
                                    Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString().Trim() : "",
                                    LopHocID = reader["LopHocID"] != DBNull.Value ? Convert.ToInt32(reader["LopHocID"]) : 0,
                                    TenLop = reader["TenLop"] != DBNull.Value ? reader["TenLop"].ToString() : "",
                                    SoBuoiVang = reader["SoBuoiVang"] != DBNull.Value ? Convert.ToInt32(reader["SoBuoiVang"]) : 0
                                });
                            }
                        }
                    }
                }

                if (dsHocVien.Count == 0)
                {
                    MessageBox.Show("Hiện không có học viên nào vắng từ 5 buổi trở lên trong các lớp bạn phụ trách.", "Hệ thống Cảnh báo Chuyên cần", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string thongDiepXacNhan = string.Format("Tìm thấy {0} học viên vắng >= 5 buổi. Bạn có muốn gửi email tự động không?", dsHocVien.Count);
                if (MessageBox.Show(thongDiepXacNhan, "Xác nhận gửi email cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                int thanhCong = 0;
                int thatBai = 0;

                foreach (var hv in dsHocVien)
                {
                    if (GuiEmailCanhBao(hv.Email, hv.HoTen, hv.TenLop, hv.SoBuoiVang))
                    {
                        thanhCong++;
                    }
                    else
                    {
                        thatBai++;
                    }
                }

                if (thatBai == 0)
                {
                    MessageBox.Show(string.Format("Đã gửi email cảnh báo chuyên cần thành công cho {0} học viên!", thanhCong), "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _view.HienThongBao(string.Format("Đã gửi email cảnh báo cho {0} học viên.", thanhCong));
                }
                else
                {
                    string thongBao = string.Format("Đã quét xong {0} học viên.\n- Gửi thành công: {1}\n- Thất bại: {2}\n\n(Lưu ý: Nếu chưa cấu hình tài khoản gửi Gmail thực tế, hãy cập nhật email và App Password trong hàm GuiEmailCanhBao).", dsHocVien.Count, thanhCong, thatBai);
                    MessageBox.Show(thongBao, "Thông báo gửi email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _view.HienThongBao(string.Format("Quét {0} học viên ({1} thành công, {2} thất bại).", dsHocVien.Count, thanhCong, thatBai));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi quét và gửi email cảnh báo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hàm gửi Email cảnh báo chuyên cần tự động sử dụng System.Net.Mail
        /// </summary>
        public bool GuiEmailCanhBao(string emailTo, string hoTen, string tenLop, int soBuoiVang)
        {
            try
            {
                // Cấu hình tài khoản gửi Gmail (thay đổi thông tin thực tế tại đây)
                string emailGui = "sang48192@gmail.com";
                string matKhauApp = "";

                string tieuDe = string.Format("[Trung tâm Tiếng Anh] Cảnh báo chuyên cần - Lớp {0}", tenLop);
                string noiDung = string.Format("Chào {0}, hệ thống ghi nhận bạn đã vắng mặt {1} buổi tại lớp {2}. Vui lòng liên hệ giáo viên để được hỗ trợ kịp thời.", hoTen, soBuoiVang, tenLop);

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailGui, "Trung tâm Tiếng Anh");
                    mail.To.Add(emailTo);
                    mail.Subject = tieuDe;
                    mail.Body = noiDung;
                    mail.IsBodyHtml = false;
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.SubjectEncoding = Encoding.UTF8;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(emailGui, matKhauApp);
                        smtp.Timeout = 10000;
                        smtp.Send(mail);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // Chặn crash ứng dụng nếu email lỗi mạng hoặc chưa cấu hình tài khoản gửi
                System.Diagnostics.Debug.WriteLine("Lỗi gửi email: " + ex.Message);
                return false;
            }
        }
    }

    /// <summary>
    /// Lớp DTO tạm lưu trữ thông tin học viên cần cảnh báo chuyên cần
    /// </summary>
    public class HocVienCanhBaoDto
    {
        public string HoTen { get; set; }
        public string Email { get; set; }
        public int LopHocID { get; set; }
        public string TenLop { get; set; }
        public int SoBuoiVang { get; set; }
    }
}
