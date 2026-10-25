using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmNhapDiem : Form
    {
        public event EventHandler TaiDanhSachYeuCau;
        public event EventHandler LuuYeuCau;
        public event EventHandler LopThayDoi;
        public event EventHandler XuatExcelYeuCau;

        private Button btnXuatExcel;

        public ComboBox LopHoc { get { return cboLop; } }
        public ComboBox LoaiDiem { get { return cboLoaiDiem; } }
        public DataGridView BangDuLieu { get { return dgvBangDiem; } }
        public DataGridViewTextBoxColumn CotDiem { get { return colDiem; } }

        public frmNhapDiem()
        {
            InitializeComponent();
            this.dgvBangDiem.DataError += (s, ev) => { ev.ThrowException = false; };
            this.dgvBangDiem.CellFormatting += dgvBangDiem_CellFormatting;

            KhoiTaoNutBoSung();

            // Khởi tạo Presenter xử lý nghiệp vụ CSDL theo kiến trúc MVP
            new NhapDiemPresenter(this);
        }

        /// <summary>
        /// Tạo thêm bằng code nút "Xuất Excel" nằm cạnh các nút thao tác hiện có
        /// </summary>
        private void KhoiTaoNutBoSung()
        {
            btnXuatExcel = new Button();
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.Size = new Size(130, 36);
            btnXuatExcel.FlatStyle = FlatStyle.Flat;
            btnXuatExcel.FlatAppearance.BorderSize = 0;
            btnXuatExcel.BackColor = Color.FromArgb(22, 163, 74);
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXuatExcel.Cursor = Cursors.Hand;
            btnXuatExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatExcel.Location = new Point(btnLuu.Left - 140, btnLuu.Top);
            btnXuatExcel.Click += btnXuatExcel_Click;

            lblTrangThai.Width = Math.Min(lblTrangThai.Width, 540);
            pnlChan.Controls.Add(btnXuatExcel);
        }

        public void HienThongBao(string thongBao)
        {
            lblTrangThai.Text = thongBao;
        }

        public void DatCheDoChiXem(bool chiXem)
        {
            dgvBangDiem.ReadOnly = chiXem;
            btnLuu.Visible = !chiXem;
        }

        /// <summary>
        /// UX: Nếu giá trị điểm < 5 thì đổi màu chữ thành Đỏ, nếu >= 8 thì đổi màu chữ thành Xanh lá
        /// </summary>
        private void dgvBangDiem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvBangDiem.Rows.Count) return;

            if (e.ColumnIndex == colDiem.Index && e.Value != null)
            {
                string text = e.Value.ToString().Trim();
                if (decimal.TryParse(text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal diem) ||
                    decimal.TryParse(text, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out diem))
                {
                    if (diem < 5)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.Font = new Font(dgvBangDiem.Font, FontStyle.Bold);
                    }
                    else if (diem >= 8)
                    {
                        e.CellStyle.ForeColor = Color.ForestGreen;
                        e.CellStyle.Font = new Font(dgvBangDiem.Font, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(31, 41, 55);
                    }
                }
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
            if (cboLop.SelectedIndex < 0 || cboLoaiDiem.SelectedIndex < 0)
            {
                HienThongBao("Vui lòng chọn lớp và loại điểm trước.");
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
            if (cboLop.SelectedIndex < 0 || cboLoaiDiem.SelectedIndex < 0)
            {
                HienThongBao("Vui lòng chọn lớp và loại điểm trước.");
                return;
            }

            if (!dgvBangDiem.EndEdit()) return;

            if (dgvBangDiem.Rows.Count == 0)
            {
                HienThongBao("Chưa có danh sách học viên để lưu.");
                return;
            }

            if (LuuYeuCau != null)
            {
                LuuYeuCau(this, EventArgs.Empty);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedIndex < 0 || cboLoaiDiem.SelectedIndex < 0)
            {
                HienThongBao("Vui lòng chọn lớp và loại điểm trước khi xuất file.");
                return;
            }

            if (dgvBangDiem.Rows.Count == 0)
            {
                HienThongBao("Chưa có danh sách điểm để xuất Excel.");
                return;
            }

            if (XuatExcelYeuCau != null)
            {
                XuatExcelYeuCau(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Bắt lỗi bọc thép: Nếu người dùng nhập chữ cái, ký tự lạ, khoảng trắng hoặc số không nằm trong khoảng 0 - 100,
        /// bắt buộc đặt e.Cancel = true, hiển thị MessageBox cảnh báo và không cho chuyển ô.
        /// </summary>
        private void dgvBangDiem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != colDiem.Index) return;

            string raw = Convert.ToString(e.FormattedValue);
            if (raw == null || raw.Length == 0) return; // Cho phép để trống nếu chưa chấm điểm

            // 1. Kiểm tra khoảng trắng
            if (string.IsNullOrWhiteSpace(raw) || raw.Contains(" "))
            {
                e.Cancel = true;
                dgvBangDiem.Rows[e.RowIndex].ErrorText = "Điểm không được chứa khoảng trắng.";
                MessageBox.Show(this, "Điểm không được chứa khoảng trắng. Vui lòng nhập số hợp lệ từ 0 đến 100.", "Lỗi nhập điểm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HienThongBao("Điểm không hợp lệ: chứa khoảng trắng.");
                return;
            }

            // 2. Kiểm tra chữ cái, ký tự lạ bằng cách parse số
            decimal diem;
            if (!decimal.TryParse(raw, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out diem) &&
                !decimal.TryParse(raw, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out diem))
            {
                e.Cancel = true;
                dgvBangDiem.Rows[e.RowIndex].ErrorText = "Điểm chứa chữ cái hoặc ký tự lạ không hợp lệ.";
                MessageBox.Show(this, "Điểm không hợp lệ! Vui lòng chỉ nhập số từ 0 đến 100 (không chứa chữ cái hoặc ký tự lạ).", "Lỗi nhập điểm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HienThongBao("Điểm không hợp lệ: chứa ký tự lạ hoặc chữ cái.");
                return;
            }

            // 3. Kiểm tra khoảng giá trị từ 0 đến 100
            if (diem < 0 || diem > 100)
            {
                e.Cancel = true;
                dgvBangDiem.Rows[e.RowIndex].ErrorText = "Điểm phải nằm trong khoảng từ 0 đến 100.";
                MessageBox.Show(this, "Điểm phải nằm trong khoảng từ 0 đến 100.", "Lỗi nhập điểm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HienThongBao("Điểm không hợp lệ: điểm phải từ 0 đến 100.");
                return;
            }

            dgvBangDiem.Rows[e.RowIndex].ErrorText = "";
        }

        private void dgvBangDiem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvBangDiem.Rows[e.RowIndex].ErrorText = "";
        }
    }

    /// <summary>
    /// Presenter phụ trách toàn bộ xử lý nghiệp vụ CSDL cho frmNhapDiem theo mô hình MVP.
    /// Không viết trực tiếp câu lệnh SQL trong Form.
    /// </summary>
    public class NhapDiemPresenter
    {
        private readonly frmNhapDiem _view;
        private bool _dangNapDuLieu = false;

        public NhapDiemPresenter(frmNhapDiem view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));

            _view.Load += View_Load;
            _view.LopThayDoi += View_LopThayDoi;
            _view.TaiDanhSachYeuCau += View_TaiDanhSachYeuCau;
            _view.LuuYeuCau += View_LuuYeuCau;
            _view.XuatExcelYeuCau += View_XuatExcelYeuCau;
        }

        private void View_Load(object sender, EventArgs e)
        {
            _view.CotDiem.HeaderText = "Điểm (0–100)";
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
                    NapDanhSachLoaiDiem();
                }
                else
                {
                    _view.LoaiDiem.DataSource = null;
                    _view.HienThongBao("Chưa có dữ liệu lớp học.");
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

        public void NapDanhSachLoaiDiem()
        {
            if (_view.LopHoc.SelectedValue == null) return;

            int lopHocID;
            if (!int.TryParse(_view.LopHoc.SelectedValue.ToString(), out lopHocID)) return;

            try
            {
                DataTable dt = new DataTable();
                using (var con = DatabaseConnection.TaoKetNoi())
                {
                    string sqlSelect = "SELECT BaiTapID, TieuDe FROM BaiTap WHERE LopHocID = @LopHocID ORDER BY BaiTapID";
                    using (var cmd = new SqlCommand(sqlSelect, con))
                    {
                        cmd.Parameters.AddWithValue("@LopHocID", lopHocID);
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }

                    if (dt == null || dt.Rows.Count == 0)
                    {
                        // Tự động tạo bài tập / cột điểm mặc định cho lớp nếu chưa có
                        string sqlTao = @"INSERT INTO BaiTap (LopHocID, TieuDe, MoTa, NgayGiao, TrangThai)
                                          VALUES (@LopHocID, N'Điểm bài tập / Quá trình', N'Đánh giá kết quả học tập', GETDATE(), N'Đang mở')";
                        con.Open();
                        using (var cmdTao = new SqlCommand(sqlTao, con))
                        {
                            cmdTao.Parameters.AddWithValue("@LopHocID", lopHocID);
                            cmdTao.ExecuteNonQuery();
                        }

                        dt = new DataTable();
                        using (var cmdReload = new SqlCommand(sqlSelect, con))
                        {
                            cmdReload.Parameters.AddWithValue("@LopHocID", lopHocID);
                            using (var daReload = new SqlDataAdapter(cmdReload))
                            {
                                daReload.Fill(dt);
                            }
                        }
                    }
                }

                _view.LoaiDiem.DisplayMember = "TieuDe";
                _view.LoaiDiem.ValueMember = "BaiTapID";
                _view.LoaiDiem.DataSource = dt;

                if (dt != null && dt.Rows.Count > 0)
                {
                    _view.LoaiDiem.SelectedIndex = 0;
                    _view.HienThongBao(string.Format("Lớp có {0} loại điểm / bài tập. Bấm 'Tải danh sách' để nhập điểm.", dt.Rows.Count));
                }
                else
                {
                    _view.BangDuLieu.DataSource = null;
                    _view.HienThongBao("Lớp chưa có loại điểm / bài tập.");
                }
            }
            catch (Exception ex)
            {
                _view.HienThongBao("Lỗi tải loại điểm: " + ex.Message);
            }
        }

        private void View_LopThayDoi(object sender, EventArgs e)
        {
            if (_dangNapDuLieu) return;
            if (_view.LopHoc.SelectedValue != null && int.TryParse(_view.LopHoc.SelectedValue.ToString(), out _))
            {
                NapDanhSachLoaiDiem();
            }
        }

        private void View_TaiDanhSachYeuCau(object sender, EventArgs e)
        {
            if (_view.LopHoc.SelectedValue == null || _view.LoaiDiem.SelectedValue == null)
            {
                _view.HienThongBao("Vui lòng chọn lớp và loại điểm trước.");
                return;
            }

            int lopHocID;
            int baiTapID;
            if (!int.TryParse(_view.LopHoc.SelectedValue.ToString(), out lopHocID) ||
                !int.TryParse(_view.LoaiDiem.SelectedValue.ToString(), out baiTapID))
            {
                _view.HienThongBao("Thông tin lớp hoặc loại điểm không hợp lệ.");
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
                                    ct.Diem,
                                    ISNULL(ct.NhanXet, N'') AS GhiChu
                                  FROM DangKy dk
                                  JOIN HocVien hv ON dk.HocVienID = hv.HocVienID
                                  LEFT JOIN ChiTietNopBai ct ON ct.HocVienID = hv.HocVienID AND ct.BaiTapID = @BaiTapID
                                  WHERE dk.LopHocID = @LopHocID
                                  ORDER BY hv.HoTen";
                    using (var cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@BaiTapID", baiTapID);
                        cmd.Parameters.AddWithValue("@LopHocID", lopHocID);
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                _view.BangDuLieu.DataSource = dt;

                if (dt != null && dt.Rows.Count > 0)
                    _view.HienThongBao(string.Format("Đã tải {0} học viên. Nhập điểm từ 0 đến 100 rồi bấm 'Lưu'.", dt.Rows.Count));
                else
                    _view.HienThongBao("Lớp này chưa có học viên nào đăng ký.");
            }
            catch (Exception ex)
            {
                _view.HienThongBao("Lỗi tải danh sách điểm: " + ex.Message);
            }
        }

        private void View_LuuYeuCau(object sender, EventArgs e)
        {
            if (_view.LopHoc.SelectedValue == null || _view.LoaiDiem.SelectedValue == null)
            {
                _view.HienThongBao("Vui lòng chọn lớp và loại điểm trước.");
                return;
            }

            if (!_view.BangDuLieu.EndEdit()) return;

            if (_view.BangDuLieu.Rows.Count == 0)
            {
                _view.HienThongBao("Chưa có danh sách học viên.");
                return;
            }

            int baiTapID;
            if (!int.TryParse(_view.LoaiDiem.SelectedValue.ToString(), out baiTapID))
            {
                _view.HienThongBao("Loại điểm không hợp lệ.");
                return;
            }

            // 1. Kiểm tra tính hợp lệ của điểm trên toàn bộ bảng (từ 0 đến 100, không chứa khoảng trắng hay ký tự lạ)
            foreach (DataGridViewRow row in _view.BangDuLieu.Rows)
            {
                if (row.IsNewRow) continue;
                object val = row.Cells["colDiem"].Value;
                if (val != null && !string.IsNullOrWhiteSpace(val.ToString()))
                {
                    string text = val.ToString().Trim();
                    if (text.Contains(" ") ||
                        (!decimal.TryParse(text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal diem) &&
                         !decimal.TryParse(text, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out diem)))
                    {
                        string hoTen = Convert.ToString(row.Cells["colHoTen"].Value);
                        _view.HienThongBao(string.Format("Điểm của học viên '{0}' không phải là số hợp lệ.", hoTen));
                        row.Cells["colDiem"].Selected = true;
                        return;
                    }

                    if (diem < 0 || diem > 100)
                    {
                        string hoTen = Convert.ToString(row.Cells["colHoTen"].Value);
                        _view.HienThongBao(string.Format("Điểm của học viên '{0}' phải nằm trong khoảng từ 0 đến 100.", hoTen));
                        row.Cells["colDiem"].Selected = true;
                        return;
                    }
                }
            }

            // 2. Thực thi cập nhật hàng loạt bằng kết nối riêng và Transaction
            try
            {
                using (var con = DatabaseConnection.TaoKetNoi())
                {
                    con.Open();
                    using (var tran = con.BeginTransaction())
                    {
                        string sqlUpsert = @"IF EXISTS (SELECT 1 FROM ChiTietNopBai WHERE BaiTapID = @BaiTapID AND HocVienID = @HocVienID AND LanNop = 1)
                                                UPDATE ChiTietNopBai SET Diem = @Diem, NhanXet = @NhanXet, NgayCham = GETDATE() WHERE BaiTapID = @BaiTapID AND HocVienID = @HocVienID AND LanNop = 1;
                                             ELSE
                                                INSERT INTO ChiTietNopBai (BaiTapID, HocVienID, LanNop, Diem, NhanXet, ThoiGianNop, NgayCham)
                                                VALUES (@BaiTapID, @HocVienID, 1, @Diem, @NhanXet, GETDATE(), GETDATE());";

                        foreach (DataGridViewRow row in _view.BangDuLieu.Rows)
                        {
                            if (row.IsNewRow) continue;
                            if (!int.TryParse(Convert.ToString(row.Cells["colMaHocVien"].Value), out int hocVienID))
                                continue;

                            object val = row.Cells["colDiem"].Value;
                            object diemSql = DBNull.Value;
                            if (val != null && !string.IsNullOrWhiteSpace(val.ToString()))
                            {
                                string text = val.ToString().Trim();
                                if (decimal.TryParse(text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal diem) ||
                                    decimal.TryParse(text, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out diem))
                                {
                                    diemSql = diem;
                                }
                            }

                            string ghiChu = Convert.ToString(row.Cells["colGhiChu"].Value) ?? "";

                            using (var cmd = new SqlCommand(sqlUpsert, con, tran))
                            {
                                cmd.Parameters.AddWithValue("@BaiTapID", baiTapID);
                                cmd.Parameters.AddWithValue("@HocVienID", hocVienID);
                                cmd.Parameters.AddWithValue("@Diem", diemSql);
                                cmd.Parameters.AddWithValue("@NhanXet", ghiChu);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                    }
                }

                _view.HienThongBao(string.Format("Đã lưu điểm thành công cho {0} học viên!", _view.BangDuLieu.Rows.Count));
            }
            catch (Exception ex)
            {
                _view.HienThongBao("Lỗi lưu điểm học viên: " + ex.Message);
            }
        }

        /// <summary>
        /// Logic xuất dữ liệu bảng điểm ra file CSV / Excel thông qua SaveFileDialog
        /// </summary>
        private void View_XuatExcelYeuCau(object sender, EventArgs e)
        {
            try
            {
                if (_view.BangDuLieu.Rows.Count == 0)
                {
                    _view.HienThongBao("Chưa có danh sách điểm để xuất Excel.");
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    string tenLop = _view.LopHoc.Text.Replace(" ", "_");
                    string loaiDiem = _view.LoaiDiem.Text.Replace(" ", "_");
                    sfd.FileName = string.Format("BangDiem_{0}_{1}.csv", tenLop, loaiDiem);
                    sfd.Filter = "CSV File (*.csv)|*.csv|All Files (*.*)|*.*";
                    sfd.Title = "Xuất bảng điểm ra file CSV / Excel";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(string.Format("\"BẢNG ĐIỂM LỚP: {0} - BÀI/LOẠI ĐIỂM: {1}\"", _view.LopHoc.Text, _view.LoaiDiem.Text));
                        sb.AppendLine(string.Format("\"Thời điểm xuất: {0}\"", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
                        sb.AppendLine("\"Mã học viên\",\"Họ và tên\",\"Điểm\",\"Ghi chú\"");

                        foreach (DataGridViewRow row in _view.BangDuLieu.Rows)
                        {
                            if (row.IsNewRow) continue;
                            string ma = Convert.ToString(row.Cells["colMaHocVien"].Value);
                            string hoTen = Convert.ToString(row.Cells["colHoTen"].Value);
                            string diem = Convert.ToString(row.Cells["colDiem"].Value);
                            string ghiChu = Convert.ToString(row.Cells["colGhiChu"].Value);

                            sb.AppendLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"",
                                (ma ?? "").Replace("\"", "\"\""),
                                (hoTen ?? "").Replace("\"", "\"\""),
                                (diem ?? "").Replace("\"", "\"\""),
                                (ghiChu ?? "").Replace("\"", "\"\"")));
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
                        _view.HienThongBao("Đã xuất dữ liệu thành công ra file: " + Path.GetFileName(sfd.FileName));
                        MessageBox.Show("Xuất bảng điểm ra file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                _view.HienThongBao("Lỗi xuất file: " + ex.Message);
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
