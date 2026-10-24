using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmGiaoVien : Form
    {
        public event EventHandler TimKiemYeuCau;
        public event EventHandler LuuYeuCau;
        public event EventHandler XemLopYeuCau;

        public DataGridView BangGiaoVien { get { return dgvGiaoVien; } }
        public string TuKhoa { get { return txtTimKiem.Text.Trim(); } }
        public string MaGiaoVien { get { return txtMaGiaoVien.Text; } set { txtMaGiaoVien.Text = value; } }
        public string HoTen { get { return txtHoTen.Text.Trim(); } set { txtHoTen.Text = value; } }
        public DateTime NgaySinh { get { return dtpNgaySinh.Value.Date; } set { dtpNgaySinh.Value = value; } }
        public string SoDienThoai { get { return txtSoDienThoai.Text.Trim(); } set { txtSoDienThoai.Text = value; } }
        public string Email { get { return txtEmail.Text.Trim(); } set { txtEmail.Text = value; } }
        public string ChuyenMon { get { return txtChuyenMon.Text.Trim(); } set { txtChuyenMon.Text = value; } }
        public ComboBox GioiTinh { get { return cboGioiTinh; } }
        public ComboBox TrangThai { get { return cboTrangThai; } }
        public ComboBox LocTrangThai { get { return cboLocTrangThai; } }

        public frmGiaoVien()
        {
            InitializeComponent();
            if (cboLocTrangThai.Items.Count > 0)
                cboLocTrangThai.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;

            this.dgvGiaoVien.CellClick += dgvGiaoVien_CellClick;

            // Khởi tạo Presenter lắng nghe và xử lý các sự kiện CSDL theo kiến trúc MVP
            new GiaoVienPresenter(this);
        }

        public void HienThongBao(string thongBao)
        {
            lblTrangThai.Text = thongBao;
        }

        private void dgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvGiaoVien.Rows.Count) return;

            DataGridViewRow row = dgvGiaoVien.Rows[e.RowIndex];
            txtMaGiaoVien.Text = Convert.ToString(row.Cells["colMaGiaoVien"].Value);
            txtHoTen.Text = Convert.ToString(row.Cells["colHoTen"].Value);
            txtSoDienThoai.Text = Convert.ToString(row.Cells["colSoDienThoai"].Value);
            txtEmail.Text = Convert.ToString(row.Cells["colEmail"].Value);
            txtChuyenMon.Text = Convert.ToString(row.Cells["colChuyenMon"].Value);

            string tt = Convert.ToString(row.Cells["colTrangThai"].Value);
            if (tt == "Đang làm" || tt == "Đang làm việc")
                cboTrangThai.SelectedItem = "Đang làm việc";
            else if (tt == "Nghỉ việc" || tt == "Ngừng làm việc")
                cboTrangThai.SelectedItem = "Ngừng làm việc";
            else
                cboTrangThai.Text = tt;

            DataRowView drv = row.DataBoundItem as DataRowView;
            if (drv != null)
            {
                if (drv["NgaySinh"] != DBNull.Value)
                {
                    DateTime ns;
                    if (DateTime.TryParse(drv["NgaySinh"].ToString(), out ns))
                        dtpNgaySinh.Value = ns;
                }
                string gt = Convert.ToString(drv["GioiTinh"]);
                if (!string.IsNullOrEmpty(gt))
                    cboGioiTinh.Text = gt;
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaGiaoVien.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtChuyenMon.Clear();
            cboGioiTinh.SelectedIndex = -1;
            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Today;
            txtHoTen.Focus();
            HienThongBao("Đã sẵn sàng thêm giáo viên mới. Vui lòng nhập thông tin rồi bấm Lưu.");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThemMoi_Click(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (LuuYeuCau != null)
            {
                LuuYeuCau(this, EventArgs.Empty);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (TimKiemYeuCau != null)
            {
                TimKiemYeuCau(this, EventArgs.Empty);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            if (cboLocTrangThai.Items.Count > 0)
                cboLocTrangThai.SelectedIndex = 0;

            if (TimKiemYeuCau != null)
            {
                TimKiemYeuCau(this, EventArgs.Empty);
            }
        }

        private void btnXemLop_Click(object sender, EventArgs e)
        {
            if (XemLopYeuCau != null)
            {
                XemLopYeuCau(this, EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// Presenter phụ trách toàn bộ xử lý nghiệp vụ CSDL cho frmGiaoVien theo mô hình MVP.
    /// Không viết trực tiếp câu lệnh SQL trong Form.
    /// </summary>
    public class GiaoVienPresenter
    {
        private readonly frmGiaoVien _view;

        public GiaoVienPresenter(frmGiaoVien view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));

            _view.Load += View_Load;
            _view.TimKiemYeuCau += View_TimKiemYeuCau;
            _view.LuuYeuCau += View_LuuYeuCau;
            _view.XemLopYeuCau += View_XemLopYeuCau;
        }

        private void View_Load(object sender, EventArgs e)
        {
            TaiDanhSachGiaoVien();
        }

        private void View_TimKiemYeuCau(object sender, EventArgs e)
        {
            TaiDanhSachGiaoVien();
        }

        public void TaiDanhSachGiaoVien()
        {
            try
            {
                string sql = "SELECT NhanSuID AS MaGiaoVien, TrinhDo AS ChuyenMon, * FROM NhanSu WHERE LoaiNhanSu IN (N'Giáo viên', N'Cả hai')";

                string tuKhoa = _view.TuKhoa.Replace("'", "''");
                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    sql += string.Format(" AND (HoTen LIKE N'%{0}%' OR SoDienThoai LIKE '%{0}%' OR Email LIKE '%{0}%')", tuKhoa);
                }

                if (_view.LocTrangThai.SelectedIndex > 0)
                {
                    string loc = _view.LocTrangThai.SelectedItem.ToString();
                    if (loc == "Đang làm việc")
                        sql += " AND (TrangThai = N'Đang làm việc' OR TrangThai = N'Đang làm')";
                    else if (loc == "Ngừng làm việc")
                        sql += " AND (TrangThai = N'Ngừng làm việc' OR TrangThai = N'Nghỉ việc')";
                }

                sql += " ORDER BY NhanSuID DESC";

                DataTable dt = DatabaseConnection.GetDataToTable(sql);
                _view.BangGiaoVien.DataSource = dt;

                if (dt != null && dt.Rows.Count > 0)
                    _view.HienThongBao(string.Format("Đã tải {0} hồ sơ giáo viên.", dt.Rows.Count));
                else
                    _view.HienThongBao("Không tìm thấy giáo viên nào phù hợp.");
            }
            catch (Exception ex)
            {
                _view.HienThongBao("Lỗi tải danh sách giáo viên: " + ex.Message);
            }
        }

        private void View_LuuYeuCau(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_view.HoTen))
                {
                    _view.HienThongBao("Vui lòng nhập họ tên giáo viên.");
                    return;
                }

                string hoTen = _view.HoTen.Replace("'", "''");
                string ngaySinh = _view.NgaySinh.ToString("yyyy-MM-dd");
                string gioiTinh = _view.GioiTinh.Text.Trim().Replace("'", "''");
                string sdt = _view.SoDienThoai.Replace("'", "''");
                string email = _view.Email.Replace("'", "''");
                string chuyenMon = _view.ChuyenMon.Replace("'", "''");
                string trangThai = string.IsNullOrWhiteSpace(_view.TrangThai.Text)
                    ? "Đang làm"
                    : _view.TrangThai.Text.Trim().Replace("'", "''");

                if (string.IsNullOrWhiteSpace(_view.MaGiaoVien))
                {
                    // Thêm mới (INSERT)
                    string sql = string.Format(
                        @"INSERT INTO NhanSu(CoSoID, HoTen, NgaySinh, GioiTinh, SoDienThoai, Email, LoaiNhanSu, TrinhDo, NgayVaoLam, TrangThai)
                          VALUES(ISNULL((SELECT TOP 1 CoSoID FROM CoSo WHERE TrangThai = 1), 1),
                                 N'{0}', '{1}', N'{2}', '{3}', '{4}', N'Giáo viên', N'{5}', GETDATE(), N'{6}')",
                        hoTen, ngaySinh, gioiTinh, sdt, email, chuyenMon, trangThai);

                    DatabaseConnection.RunSQL(sql);
                    _view.HienThongBao("Thêm mới hồ sơ giáo viên thành công!");
                    TaiDanhSachGiaoVien();
                }
                else
                {
                    // Sửa (UPDATE)
                    int maGV;
                    if (!int.TryParse(_view.MaGiaoVien.Trim(), out maGV))
                    {
                        _view.HienThongBao("Mã giáo viên không hợp lệ.");
                        return;
                    }

                    string sql = string.Format(
                        @"UPDATE NhanSu SET 
                            HoTen = N'{0}', 
                            NgaySinh = '{1}', 
                            GioiTinh = N'{2}', 
                            SoDienThoai = '{3}', 
                            Email = '{4}', 
                            TrinhDo = N'{5}', 
                            TrangThai = N'{6}'
                          WHERE NhanSuID = {7}",
                        hoTen, ngaySinh, gioiTinh, sdt, email, chuyenMon, trangThai, maGV);

                    DatabaseConnection.RunSQL(sql);
                    _view.HienThongBao("Cập nhật thông tin giáo viên thành công!");
                    TaiDanhSachGiaoVien();
                }
            }
            catch (Exception ex)
            {
                _view.HienThongBao("Lỗi lưu hồ sơ giáo viên: " + ex.Message);
            }
        }

        private void View_XemLopYeuCau(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_view.MaGiaoVien))
                {
                    _view.HienThongBao("Vui lòng chọn giáo viên từ danh sách để xem lớp.");
                    return;
                }

                int maGV;
                if (int.TryParse(_view.MaGiaoVien.Trim(), out maGV))
                {
                    string sql = string.Format(
                        @"SELECT l.TenLop, ISNULL(k.TenKhoaHoc, N'') AS TenKhoaHoc, l.TrangThai 
                          FROM LopHoc l 
                          LEFT JOIN KhoaHoc k ON l.KhoaHocID = k.KhoaHocID 
                          WHERE l.GiaoVienPhuTrachID = {0}", maGV);

                    DataTable dt = DatabaseConnection.GetDataToTable(sql);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string thongTin = "Danh sách lớp giáo viên '" + _view.HoTen + "' đang phụ trách:\n\n";
                        foreach (DataRow r in dt.Rows)
                        {
                            thongTin += string.Format("• {0} ({1}) - Trạng thái: {2}\n", r["TenLop"], r["TenKhoaHoc"], r["TrangThai"]);
                        }
                        MessageBox.Show(_view, thongTin, "Lớp phụ trách của " + _view.HoTen, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _view.HienThongBao(string.Format("Giáo viên {0} phụ trách {1} lớp.", _view.HoTen, dt.Rows.Count));
                    }
                    else
                    {
                        MessageBox.Show(_view, "Giáo viên '" + _view.HoTen + "' hiện chưa được phân công lớp nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _view.HienThongBao("Chưa có lớp nào được phân công.");
                    }
                }
            }
            catch (Exception ex)
            {
                _view.HienThongBao("Lỗi xem lớp phụ trách: " + ex.Message);
            }
        }
    }
}
