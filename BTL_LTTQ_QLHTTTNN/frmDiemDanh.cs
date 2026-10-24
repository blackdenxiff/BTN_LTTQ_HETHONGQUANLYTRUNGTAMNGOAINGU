using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmDiemDanh : Form
    {
        public event EventHandler TaiDanhSachYeuCau;
        public event EventHandler LuuYeuCau;
        public event EventHandler LopThayDoi;

        public ComboBox LopHoc { get { return cboLop; } }
        public ComboBox BuoiHoc { get { return cboBuoiHoc; } }
        public DataGridView BangDuLieu { get { return dgvDiemDanh; } }
        public DataGridViewComboBoxColumn CotTrangThai { get { return colTrangThai; } }

        public frmDiemDanh()
        {
            InitializeComponent();
            this.dgvDiemDanh.DataError += (s, ev) => { ev.ThrowException = false; };

            // Khởi tạo Presenter xử lý nghiệp vụ CSDL theo kiến trúc MVP
            new DiemDanhPresenter(this);
        }

        public void HienThongBao(string thongBao)
        {
            lblTrangThai.Text = thongBao;
        }

        public void DatCheDoChiXem(bool chiXem)
        {
            dgvDiemDanh.ReadOnly = chiXem;
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
                string sql = "SELECT LopHocID, TenLop FROM LopHoc ORDER BY TenLop";
                DataTable dt = DatabaseConnection.GetDataToTable(sql);

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
                string sql = string.Format(
                    @"SELECT LichHocID, CONVERT(varchar(10), NgayHoc, 103) AS NgayHoc, GioBatDau 
                      FROM LichHoc 
                      WHERE LopHocID = {0} 
                      ORDER BY NgayHoc, GioBatDau", lopHocID);

                DataTable dt = DatabaseConnection.GetDataToTable(sql);

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
                string sql = string.Format(
                    @"SELECT 
                        hv.HocVienID AS MaHocVien,
                        hv.HoTen,
                        ISNULL(dd.TrangThai, N'Có mặt') AS TrangThai,
                        ISNULL(dd.GhiChu, N'') AS GhiChu
                      FROM DangKy dk
                      JOIN HocVien hv ON dk.HocVienID = hv.HocVienID
                      LEFT JOIN DiemDanh dd ON dd.HocVienID = hv.HocVienID AND dd.LichHocID = {0}
                      WHERE dk.LopHocID = {1}
                      ORDER BY hv.HoTen", lichHocID, lopHocID);

                DataTable dt = DatabaseConnection.GetDataToTable(sql);
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
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("BEGIN TRANSACTION;");

                foreach (DataGridViewRow row in _view.BangDuLieu.Rows)
                {
                    if (row.IsNewRow) continue;
                    int hocVienID;
                    if (!int.TryParse(Convert.ToString(row.Cells["colMaHocVien"].Value), out hocVienID))
                        continue;

                    string tt = Convert.ToString(row.Cells["colTrangThai"].Value).Replace("'", "''");
                    string ghiChu = Convert.ToString(row.Cells["colGhiChu"].Value).Replace("'", "''");

                    sb.AppendLine(string.Format(
                        @"IF EXISTS (SELECT 1 FROM DiemDanh WHERE LichHocID = {0} AND HocVienID = {1})
                            UPDATE DiemDanh SET TrangThai = N'{2}', GhiChu = N'{3}' WHERE LichHocID = {0} AND HocVienID = {1};
                          ELSE
                            INSERT INTO DiemDanh (LichHocID, HocVienID, TrangThai, GhiChu) VALUES ({0}, {1}, N'{2}', N'{3}');",
                        lichHocID, hocVienID, tt, ghiChu));
                }

                sb.AppendLine("COMMIT TRANSACTION;");

                DatabaseConnection.RunSQL(sb.ToString());
                _view.HienThongBao(string.Format("Đã lưu điểm danh thành công cho {0} học viên!", _view.BangDuLieu.Rows.Count));
            }
            catch (Exception ex)
            {
                _view.HienThongBao("Lỗi lưu điểm danh: " + ex.Message);
            }
        }
    }
}
