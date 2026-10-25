using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BTL_LTTQ_QLHTTTNN.Services;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN
{
    /// <summary>
    /// Đối tượng lưu trữ phần tử chọn Tháng/Năm trong ComboBox
    /// </summary>
    public class ThangNamItem
    {
        public string Text { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    /// <summary>
    /// Presenter phụ trách toàn bộ logic nghiệp vụ và truy xuất CSDL cho frmNhatKyGiangDay.
    /// Tuân thủ kiến trúc MVP / 3-tier, sử dụng DatabaseConnection.TaoKetNoi().
    /// </summary>
    public class NhatKyGiangDayPresenter
    {
        private readonly frmNhatKyGiangDay _view;
        private bool _dangNapDuLieu = false;
        private int _currentNhanSuID = 2;

        public NhatKyGiangDayPresenter(frmNhatKyGiangDay view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));

            _view.Load += View_Load;
            _view.BoLocThayDoi += View_BoLocThayDoi;
            _view.TaiLaiYeuCau += View_TaiLaiYeuCau;
            _view.XuatExcelYeuCau += View_XuatExcelYeuCau;
        }

        private void View_Load(object sender, EventArgs e)
        {
            XacDinhNhanSuID();
            NapBoLocThangNam();
            TaiDanhSachNhatKy();
        }

        private void View_BoLocThayDoi(object sender, EventArgs e)
        {
            if (_dangNapDuLieu) return;
            TaiDanhSachNhatKy();
        }

        private void View_TaiLaiYeuCau(object sender, EventArgs e)
        {
            XacDinhNhanSuID();
            NapBoLocThangNam();
            TaiDanhSachNhatKy();
        }

        /// <summary>
        /// Xác định NhanSuID từ SessionContext hoặc Form
        /// </summary>
        private void XacDinhNhanSuID()
        {
            if (SessionContext.NguoiDungHienTai != null && 
                SessionContext.NguoiDungHienTai.NhanSuID.HasValue && 
                SessionContext.NguoiDungHienTai.NhanSuID.Value > 0)
            {
                _currentNhanSuID = SessionContext.NguoiDungHienTai.NhanSuID.Value;
            }
            else if (_view.NhanSuID > 0)
            {
                _currentNhanSuID = _view.NhanSuID;
            }
            else
            {
                _currentNhanSuID = 2;
            }
            _view.NhanSuID = _currentNhanSuID;
        }

        /// <summary>
        /// Nạp danh sách các tháng/năm có ca dạy đã kết thúc vào ComboBox bộ lọc
        /// </summary>
        public void NapBoLocThangNam()
        {
            try
            {
                _dangNapDuLieu = true;
                _view.ThangNam.Items.Clear();
                _view.ThangNam.Items.Add(new ThangNamItem
                {
                    Text = "-- Tất cả các tháng --",
                    Thang = 0,
                    Nam = 0
                });

                DataTable dtThang = new DataTable();
                using (var con = DatabaseConnection.TaoKetNoi())
                {
                    con.Open();
                    string sqlThang = @"
                        SELECT DISTINCT 
                            MONTH(lic.NgayHoc) AS Thang, 
                            YEAR(lic.NgayHoc) AS Nam 
                        FROM LichHoc lic
                        JOIN LopHoc lh ON lic.LopHocID = lh.LopHocID
                        WHERE lh.GiaoVienPhuTrachID = @NhanSuID
                          AND lic.NgayHoc < GETDATE()
                        ORDER BY Nam DESC, Thang DESC";

                    using (var cmd = new SqlCommand(sqlThang, con))
                    {
                        cmd.Parameters.AddWithValue("@NhanSuID", _currentNhanSuID);
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dtThang);
                        }
                    }
                }

                if (dtThang.Rows.Count > 0)
                {
                    foreach (DataRow row in dtThang.Rows)
                    {
                        int thang = Convert.ToInt32(row["Thang"]);
                        int nam = Convert.ToInt32(row["Nam"]);
                        _view.ThangNam.Items.Add(new ThangNamItem
                        {
                            Text = string.Format("Tháng {0:D2}/{1}", thang, nam),
                            Thang = thang,
                            Nam = nam
                        });
                    }
                }
                else
                {
                    // Dự phòng các tháng gần nhất nếu CSDL chưa có buổi học cũ
                    DateTime now = DateTime.Today;
                    for (int i = 0; i < 3; i++)
                    {
                        DateTime d = now.AddMonths(-i);
                        _view.ThangNam.Items.Add(new ThangNamItem
                        {
                            Text = string.Format("Tháng {0:D2}/{1}", d.Month, d.Year),
                            Thang = d.Month,
                            Nam = d.Year
                        });
                    }
                }

                _view.ThangNam.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp danh sách tháng/năm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _dangNapDuLieu = false;
            }
        }

        /// <summary>
        /// Truy vấn danh sách buổi học ĐÃ KẾT THÚC (NgayHoc < GETDATE() VÀ GiaoVienPhuTrachID = @NhanSuID)
        /// Kết hợp JOIN LichHoc, LopHoc, PhongHoc và subquery DiemDanh để đếm: Tổng sĩ số, Có mặt, Vắng mặt.
        /// </summary>
        public void TaiDanhSachNhatKy()
        {
            try
            {
                int filterThang = 0;
                int filterNam = 0;
                if (_view.ThangNam.SelectedItem is ThangNamItem selectedItem)
                {
                    filterThang = selectedItem.Thang;
                    filterNam = selectedItem.Nam;
                }

                DataTable dt = new DataTable();
                using (var con = DatabaseConnection.TaoKetNoi())
                {
                    con.Open();
                    var sb = new StringBuilder();
                    sb.AppendLine(@"
                        SELECT 
                            lic.LichHocID,
                            CONVERT(varchar(10), lic.NgayHoc, 103) AS NgayDay,
                            lic.NgayHoc,
                            lh.TenLop,
                            CONVERT(varchar(5), lic.GioBatDau) + ' - ' + CONVERT(varchar(5), lic.GioKetThuc) AS CaHoc,
                            ISNULL(ph.TenPhong, N'Phòng ' + CAST(lic.PhongHocID AS nvarchar(10))) AS PhongHoc,
                            ISNULL(
                                NULLIF((SELECT COUNT(*) FROM DiemDanh dd WHERE dd.LichHocID = lic.LichHocID), 0),
                                (SELECT COUNT(*) FROM DangKy dk WHERE dk.LopHocID = lh.LopHocID)
                            ) AS TongSiSo,
                            ISNULL((SELECT COUNT(*) FROM DiemDanh dd WHERE dd.LichHocID = lic.LichHocID AND dd.TrangThai = N'Có mặt'), 0) AS CoMat,
                            ISNULL((SELECT COUNT(*) FROM DiemDanh dd WHERE dd.LichHocID = lic.LichHocID AND dd.TrangThai IN (N'Vắng', N'Nghỉ phép')), 0) AS VangMat
                        FROM LichHoc lic
                        JOIN LopHoc lh ON lic.LopHocID = lh.LopHocID
                        LEFT JOIN PhongHoc ph ON lic.PhongHocID = ph.PhongHocID
                        WHERE lh.GiaoVienPhuTrachID = @NhanSuID
                          AND lic.NgayHoc < GETDATE()");

                    if (filterThang > 0 && filterNam > 0)
                    {
                        sb.AppendLine("  AND MONTH(lic.NgayHoc) = @Thang AND YEAR(lic.NgayHoc) = @Nam");
                    }

                    sb.AppendLine("ORDER BY lic.NgayHoc DESC, lic.GioBatDau DESC");

                    using (var cmd = new SqlCommand(sb.ToString(), con))
                    {
                        cmd.Parameters.AddWithValue("@NhanSuID", _currentNhanSuID);
                        if (filterThang > 0 && filterNam > 0)
                        {
                            cmd.Parameters.AddWithValue("@Thang", filterThang);
                            cmd.Parameters.AddWithValue("@Nam", filterNam);
                        }

                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                _view.BangDuLieu.DataSource = dt;
                _view.CapNhatTongQuan(dt.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhật ký giảng dạy: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý xuất báo cáo nhật ký ra file CSV / Excel hỗ trợ đầy đủ tiếng Việt UTF-8 có BOM
        /// </summary>
        private void View_XuatExcelYeuCau(object sender, EventArgs e)
        {
            try
            {
                if (_view.BangDuLieu.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu nhật ký giảng dạy để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    string thoiGian = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    sfd.FileName = string.Format("NhatKyGiangDay_{0}.csv", thoiGian);
                    sfd.Filter = "CSV File (*.csv)|*.csv|All Files (*.*)|*.*";
                    sfd.Title = "Xuất báo cáo nhật ký giảng dạy ra file Excel";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("\"BÁO CÁO NHẬT KÝ GIẢNG DẠY\"");
                        sb.AppendLine(string.Format("\"Thời điểm xuất: {0}\"", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
                        sb.AppendLine(string.Format("\"Bộ lọc: {0}\"", _view.ThangNam.Text));
                        sb.AppendLine(string.Format("\"Tổng số buổi dạy: {0}\"", _view.BangDuLieu.Rows.Count));
                        sb.AppendLine("\"Ngày dạy\",\"Tên Lớp\",\"Ca/Giờ học\",\"Phòng học\",\"Tổng sĩ số\",\"Có mặt\",\"Vắng mặt\"");

                        foreach (DataGridViewRow row in _view.BangDuLieu.Rows)
                        {
                            if (row.IsNewRow) continue;
                            string ngay = Convert.ToString(row.Cells["colNgayDay"].Value);
                            string lop = Convert.ToString(row.Cells["colTenLop"].Value);
                            string ca = Convert.ToString(row.Cells["colCaHoc"].Value);
                            string phong = Convert.ToString(row.Cells["colPhongHoc"].Value);
                            string siso = Convert.ToString(row.Cells["colTongSiSo"].Value);
                            string comat = Convert.ToString(row.Cells["colCoMat"].Value);
                            string vangmat = Convert.ToString(row.Cells["colVangMat"].Value);

                            sb.AppendLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\"",
                                (ngay ?? "").Replace("\"", "\"\""),
                                (lop ?? "").Replace("\"", "\"\""),
                                (ca ?? "").Replace("\"", "\"\""),
                                (phong ?? "").Replace("\"", "\"\""),
                                (siso ?? "").Replace("\"", "\"\""),
                                (comat ?? "").Replace("\"", "\"\""),
                                (vangmat ?? "").Replace("\"", "\"\"")));
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
                        _view.HienThongBao("Đã xuất thành công: " + Path.GetFileName(sfd.FileName));
                        MessageBox.Show("Xuất báo cáo nhật ký giảng dạy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
