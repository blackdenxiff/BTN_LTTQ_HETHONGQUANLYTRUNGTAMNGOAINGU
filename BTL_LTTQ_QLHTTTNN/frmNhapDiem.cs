using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmNhapDiem : Form
    {
        public event EventHandler TaiDanhSachYeuCau;
        public event EventHandler LuuYeuCau;
        public event EventHandler LopThayDoi;

        public ComboBox LopHoc { get { return cboLop; } }
        public ComboBox LoaiDiem { get { return cboLoaiDiem; } }
        public DataGridView BangDuLieu { get { return dgvBangDiem; } }
        public DataGridViewTextBoxColumn CotDiem { get { return colDiem; } }

        public frmNhapDiem()
        {
            InitializeComponent();

            // Khởi tạo Presenter xử lý nghiệp vụ CSDL theo kiến trúc MVP
            new NhapDiemPresenter(this);
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

        private void dgvBangDiem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != colDiem.Index) return;

            string text = Convert.ToString(e.FormattedValue).Trim();
            if (text.Length == 0) return;

            decimal diem;
            if ((!decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out diem) &&
                 !decimal.TryParse(text, out diem)) || diem < 0 || diem > 100)
            {
                e.Cancel = true;
                dgvBangDiem.Rows[e.RowIndex].ErrorText = "Điểm phải nằm trong khoảng 0 đến 100.";
                HienThongBao("Điểm không hợp lệ. Điểm phải từ 0 đến 100 (để trống nếu chưa có điểm).");
            }
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
                string sql = "SELECT LopHocID, TenLop FROM LopHoc ORDER BY TenLop";
                DataTable dt = DatabaseConnection.GetDataToTable(sql);

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
                string sql = "SELECT BaiTapID, TieuDe FROM BaiTap WHERE LopHocID = " + lopHocID + " ORDER BY BaiTapID";
                DataTable dt = DatabaseConnection.GetDataToTable(sql);

                if (dt == null || dt.Rows.Count == 0)
                {
                    // Tự động tạo bài tập / cột điểm mặc định cho lớp nếu chưa có
                    string sqlTao = string.Format(
                        @"INSERT INTO BaiTap (LopHocID, TieuDe, MoTa, NgayGiao, TrangThai)
                          VALUES ({0}, N'Điểm bài tập / Quá trình', N'Đánh giá kết quả học tập', GETDATE(), N'Đang mở')",
                        lopHocID);
                    DatabaseConnection.RunSQL(sqlTao);
                    dt = DatabaseConnection.GetDataToTable(sql);
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
                string sql = string.Format(
                    @"SELECT 
                        hv.HocVienID AS MaHocVien,
                        hv.HoTen,
                        ct.Diem,
                        ISNULL(ct.NhanXet, N'') AS GhiChu
                      FROM DangKy dk
                      JOIN HocVien hv ON dk.HocVienID = hv.HocVienID
                      LEFT JOIN ChiTietNopBai ct ON ct.HocVienID = hv.HocVienID AND ct.BaiTapID = {0}
                      WHERE dk.LopHocID = {1}
                      ORDER BY hv.HoTen", baiTapID, lopHocID);

                DataTable dt = DatabaseConnection.GetDataToTable(sql);
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

            // 1. Kiểm tra tính hợp lệ của điểm trên toàn bộ bảng (từ 0 đến 100)
            foreach (DataGridViewRow row in _view.BangDuLieu.Rows)
            {
                if (row.IsNewRow) continue;
                object val = row.Cells["colDiem"].Value;
                if (val != null && !string.IsNullOrWhiteSpace(val.ToString()))
                {
                    decimal diem;
                    string text = val.ToString().Trim();
                    if (!decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out diem) &&
                        !decimal.TryParse(text, out diem))
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

            // 2. Tạo câu lệnh SQL batch cập nhật vào ChiTietNopBai
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("BEGIN TRANSACTION;");

                foreach (DataGridViewRow row in _view.BangDuLieu.Rows)
                {
                    if (row.IsNewRow) continue;
                    int hocVienID;
                    if (!int.TryParse(Convert.ToString(row.Cells["colMaHocVien"].Value), out hocVienID))
                        continue;

                    object val = row.Cells["colDiem"].Value;
                    string diemSql = "NULL";
                    if (val != null && !string.IsNullOrWhiteSpace(val.ToString()))
                    {
                        decimal diem;
                        string text = val.ToString().Trim();
                        if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out diem) ||
                            decimal.TryParse(text, out diem))
                        {
                            diemSql = diem.ToString(CultureInfo.InvariantCulture);
                        }
                    }

                    string ghiChu = Convert.ToString(row.Cells["colGhiChu"].Value).Replace("'", "''");

                    sb.AppendLine(string.Format(
                        @"IF EXISTS (SELECT 1 FROM ChiTietNopBai WHERE BaiTapID = {0} AND HocVienID = {1} AND LanNop = 1)
                            UPDATE ChiTietNopBai SET Diem = {2}, NhanXet = N'{3}', NgayCham = GETDATE() WHERE BaiTapID = {0} AND HocVienID = {1} AND LanNop = 1;
                          ELSE
                            INSERT INTO ChiTietNopBai (BaiTapID, HocVienID, LanNop, Diem, NhanXet, ThoiGianNop, NgayCham)
                            VALUES ({0}, {1}, 1, {2}, N'{3}', GETDATE(), GETDATE());",
                        baiTapID, hocVienID, diemSql, ghiChu));
                }

                sb.AppendLine("COMMIT TRANSACTION;");

                DatabaseConnection.RunSQL(sb.ToString());
                _view.HienThongBao(string.Format("Đã lưu điểm thành công cho {0} học viên!", _view.BangDuLieu.Rows.Count));
            }
            catch (Exception ex)
            {
                _view.HienThongBao("Lỗi lưu điểm học viên: " + ex.Message);
            }
        }
    }
}
