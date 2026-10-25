using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_LTTQ_QLHTTTNN.Services;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmThongKe : Form
    {
        private sealed class CoSoLuaChon { public int? Id; public string Ten; public override string ToString() { return Ten; } }
        private readonly Action quayVe;
        private ThongKeBoLoc boLoc;
        private int trangHoaDon = 1, trangThanhToan = 1, trangDangKy = 1, requestId;
        public frmThongKe(Action quayVeTongQuan = null)
        {
            InitializeComponent(); TaoCacTab(); quayVe = quayVeTongQuan; DateTime today = DateTime.Today;
            btnXuatExcel.Enabled = false;
            dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1); dtpDenNgay.Value = today;
            btnHoaDonTruoc.Click += delegate { if (trangHoaDon > 1) { trangHoaDon--; TaiHoaDon(); } };
            btnHoaDonSau.Click += delegate { trangHoaDon++; TaiHoaDon(); };
            btnThanhToanTruoc.Click += delegate { if (trangThanhToan > 1) { trangThanhToan--; TaiThanhToan(); } };
            btnThanhToanSau.Click += delegate { trangThanhToan++; TaiThanhToan(); };
            btnDangKyTruoc.Click += delegate { if (trangDangKy > 1) { trangDangKy--; TaiDangKy(); } };
            btnDangKySau.Click += delegate { trangDangKy++; TaiDangKy(); };
            Load += async delegate { await NapCoSo(); cboCoSo.SelectedIndex = 0; await XemThongKe(); };
        }
        private void TaoCacTab()
        {
            CauHinhTab(tabHoaDon, "Hóa đơn trong kỳ", dgvHoaDon, btnHoaDonTruoc, lblHoaDonTrang, btnHoaDonSau);
            CauHinhTab(tabThanhToan, "Thanh toán phát sinh", dgvThanhToan, btnThanhToanTruoc, lblThanhToanTrang, btnThanhToanSau);
            CauHinhTab(tabDangKy, "Đăng ký trong kỳ", dgvDangKy, btnDangKyTruoc, lblDangKyTrang, btnDangKySau);
        }

        private void CauHinhTab(TabPage tab, string tieuDe, DataGridView bang, Button truoc, Label trang, Button sau)
        {
            tab.Text = tieuDe;
            bang.Dock = DockStyle.Fill;
            bang.ReadOnly = true;
            bang.AllowUserToAddRows = false;
            bang.AllowUserToDeleteRows = false;
            bang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bang.BackgroundColor = Color.White;
            bang.RowHeadersVisible = false;

            truoc.Text = "Trước";
            truoc.Dock = DockStyle.Left;
            truoc.Width = 90;
            sau.Text = "Sau";
            sau.Dock = DockStyle.Right;
            sau.Width = 90;
            trang.Dock = DockStyle.Fill;
            trang.TextAlign = ContentAlignment.MiddleCenter;

            Panel thanhTrang = new Panel { Dock = DockStyle.Bottom, Height = 34 };
            thanhTrang.Controls.Add(trang);
            thanhTrang.Controls.Add(truoc);
            thanhTrang.Controls.Add(sau);
            tab.Controls.Add(bang);
            tab.Controls.Add(thanhTrang);
        }

        private async Task NapCoSo()
        {
            try { var sites = await Task.Run(() => ThongKeService.LayCoSo()); cboCoSo.Items.Clear(); cboCoSo.Items.Add(new CoSoLuaChon { Id = null, Ten = "Tất cả cơ sở" }); foreach (var x in sites) cboCoSo.Items.Add(new CoSoLuaChon { Id = x.Key, Ten = x.Value }); }
            catch (Exception ex) { lblTrangThai.Text = ex.Message; }
        }
        private async void btnXem_Click(object sender, EventArgs e) { await XemThongKe(); }
        private async void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (boLoc == null) { lblTrangThai.Text = "Hãy xem thống kê thành công trước khi xuất."; return; }
            using (var dialog = new SaveFileDialog { Filter = "Tệp Excel (*.xlsx)|*.xlsx", DefaultExt = "xlsx", AddExtension = true, FileName = "ThongKe.xlsx", OverwritePrompt = true })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                btnXuatExcel.Enabled = false; lblTrangThai.Text = "Đang xuất Excel…";
                try { await XuatThongKeExcelService.TaoBaoCaoExcelAsync(boLoc, dialog.FileName, System.Threading.CancellationToken.None); lblTrangThai.Text = "Đã xuất báo cáo: " + dialog.FileName; }
                catch (Exception ex) { lblTrangThai.Text = "Không xuất được: " + ex.Message; }
                finally { if (!IsDisposed) btnXuatExcel.Enabled = true; }
            }
        }
        private async void btnDatLai_Click(object sender, EventArgs e) { DateTime today = DateTime.Today; dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1); dtpDenNgay.Value = today; cboCoSo.SelectedIndex = cboCoSo.Items.Count > 0 ? 0 : -1; await XemThongKe(); }
        private void btnTongQuan_Click(object sender, EventArgs e) { if (quayVe != null) quayVe(); }
        private async Task XemThongKe()
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date) { lblTrangThai.Text = "Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc."; return; }
            var coSo = cboCoSo.SelectedItem as CoSoLuaChon; var locChot = new ThongKeBoLoc { TuNgay = dtpTuNgay.Value.Date, DenNgay = dtpDenNgay.Value.Date, CoSoID = coSo == null ? (int?)null : coSo.Id };
            int request = ++requestId; btnXem.Enabled = btnDatLai.Enabled = false; lblTrangThai.Text = "Đang tải số liệu…"; trangHoaDon = trangThanhToan = trangDangKy = 1;
            try
            {
                var result = await Task.Run(() => new { TongHoaDon = ThongKeService.LayTongHopHoaDon(locChot), TongThanhToan = ThongKeService.LayTongHopThanhToan(locChot), TongDangKy = ThongKeService.LayTongHopDangKy(locChot), Lop = ThongKeService.LaySoLopTheoTrangThai(locChot), HoaDon = ThongKeService.LayTinhHinhThuTheoTrang(locChot, 1), ThanhToan = ThongKeService.LayChiTietThanhToanTheoTrang(locChot, 1), DangKyRows = ThongKeService.LayChiTietDangKyTheoTrang(locChot, 1) });
                if (IsDisposed || request != requestId) return;
                boLoc = new ThongKeBoLoc { TuNgay = locChot.TuNgay, DenNgay = locChot.DenNgay, CoSoID = locChot.CoSoID };
                btnXuatExcel.Enabled = true;
                dgvHoaDon.DataSource = result.HoaDon.DanhSach; dgvThanhToan.DataSource = result.ThanhToan.DanhSach; dgvDangKy.DataSource = result.DangKyRows.DanhSach;
                DatTieuDeCot(dgvHoaDon, new System.Collections.Generic.Dictionary<string, string> { { "HoaDonID", "Mã hóa đơn" }, { "NgayLap", "Ngày lập" }, { "HocVien", "Học viên" }, { "TenLop", "Lớp" }, { "CoSo", "Cơ sở" }, { "TongPhaiTra", "Phải trả" }, { "DaThanhToan", "Đã thanh toán đến cuối kỳ" }, { "ConPhaiThu", "Còn phải thu" }, { "ThuVuot", "Thu vượt phải trả" } });
                DatTieuDeCot(dgvThanhToan, new System.Collections.Generic.Dictionary<string, string> { { "ThanhToanID", "Mã thanh toán" }, { "NgayThanhToan", "Ngày thanh toán" }, { "HoaDonID", "Mã hóa đơn" }, { "HocVien", "Học viên" }, { "SoTien", "Số tiền" } });
                DatTieuDeCot(dgvDangKy, new System.Collections.Generic.Dictionary<string, string> { { "DangKyID", "Mã đăng ký" }, { "NgayDangKy", "Ngày đăng ký" }, { "HocVien", "Học viên" }, { "LopHoc", "Lớp" }, { "TrangThai", "Trạng thái" } });
                TrangHoaDon(result.HoaDon); TrangThanhToan(result.ThanhToan); TrangDangKy(result.DangKyRows);
                lblTongHop.Text = string.Format("Tiền thực thu: {0:N0} đ     •     Số đăng ký: {1:N0}     •     Số lớp hiện tại: {2:N0}", result.TongThanhToan.TongThucThuTrongKy, result.TongDangKy.TongSoLuong, result.Lop.Sum(x => x.SoLuong));
                lblHoaDonTong.Text = string.Format("Tổng hóa đơn: {0:N0}   •   Phải trả: {1:N0} đ   •   Đã thanh toán đến cuối kỳ: {2:N0} đ   •   Còn phải thu: {3:N0} đ", result.TongHoaDon.TongSoLuong, result.TongHoaDon.TongPhaiTra, result.TongHoaDon.TongDaThanhToanCuoiKy, result.TongHoaDon.TongConPhaiThu);
                lblThanhToanTong.Text = string.Format("Tổng lượt thanh toán: {0:N0}   •   Thực thu trong kỳ: {1:N0} đ", result.TongThanhToan.TongSoLuong, result.TongThanhToan.TongThucThuTrongKy);
                lblDangKyTong.Text = string.Format("Tổng đăng ký trong kỳ: {0:N0}   •   Học viên khác nhau: {1:N0}", result.TongDangKy.TongSoLuong, result.TongDangKy.TongHocVienKhacNhau);
                lblGiaiThich.Text = "Hóa đơn tính theo ngày lập; thanh toán và thực thu theo ngày thanh toán; đăng ký theo ngày đăng ký. Đã thanh toán cộng các khoản đến hết ngày cuối kỳ; số âm là thu vượt. Lớp hiện tại là số lớp đang hoạt động, không phải lớp lịch sử.";
                lblTrangThai.Text = "Cập nhật lúc " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + (coSo == null || !coSo.Id.HasValue ? " • Tất cả cơ sở" : " • " + coSo.Ten);
            }
            catch (Exception ex) { if (request == requestId) lblTrangThai.Text = "Không tải được: " + ex.Message; }
            finally { if (request == requestId) btnXem.Enabled = btnDatLai.Enabled = true; }
        }
        private void TaiHoaDon() { try { var r = ThongKeService.LayTinhHinhThuTheoTrang(boLoc, trangHoaDon); dgvHoaDon.DataSource = r.DanhSach; DatTieuDeCot(dgvHoaDon, new System.Collections.Generic.Dictionary<string, string> { { "HoaDonID", "Mã hóa đơn" }, { "NgayLap", "Ngày lập" }, { "HocVien", "Học viên" }, { "TenLop", "Lớp" }, { "CoSo", "Cơ sở" }, { "TongPhaiTra", "Phải trả" }, { "DaThanhToan", "Đã thanh toán đến cuối kỳ" }, { "ConPhaiThu", "Còn phải thu" }, { "ThuVuot", "Thu vượt phải trả" } }); TrangHoaDon(r); } catch (Exception ex) { lblTrangThai.Text = ex.Message; } }
        private void TaiThanhToan() { try { var r = ThongKeService.LayChiTietThanhToanTheoTrang(boLoc, trangThanhToan); dgvThanhToan.DataSource = r.DanhSach; DatTieuDeCot(dgvThanhToan, new System.Collections.Generic.Dictionary<string, string> { { "ThanhToanID", "Mã thanh toán" }, { "NgayThanhToan", "Ngày thanh toán" }, { "HoaDonID", "Mã hóa đơn" }, { "HocVien", "Học viên" }, { "SoTien", "Số tiền" } }); TrangThanhToan(r); } catch (Exception ex) { lblTrangThai.Text = ex.Message; } }
        private void TaiDangKy() { try { var r = ThongKeService.LayChiTietDangKyTheoTrang(boLoc, trangDangKy); dgvDangKy.DataSource = r.DanhSach; DatTieuDeCot(dgvDangKy, new System.Collections.Generic.Dictionary<string, string> { { "DangKyID", "Mã đăng ký" }, { "NgayDangKy", "Ngày đăng ký" }, { "HocVien", "Học viên" }, { "LopHoc", "Lớp" }, { "TrangThai", "Trạng thái" } }); TrangDangKy(r); } catch (Exception ex) { lblTrangThai.Text = ex.Message; } }

        private void TrangHoaDon(KetQuaPhanTrang<TinhHinhHoaDonDto> r) { trangHoaDon = r.SoTrang; lblHoaDonTrang.Text = string.Format("{0}/{1} • {2} hóa đơn", r.SoTrang, r.TongSoTrang, r.TongBanGhi); btnHoaDonSau.Enabled = r.SoTrang < r.TongSoTrang; btnHoaDonTruoc.Enabled = r.SoTrang > 1; }
        private void TrangThanhToan(KetQuaPhanTrang<ChiTietThanhToanDto> r) { trangThanhToan = r.SoTrang; lblThanhToanTrang.Text = string.Format("{0}/{1} • {2} thanh toán", r.SoTrang, r.TongSoTrang, r.TongBanGhi); btnThanhToanSau.Enabled = r.SoTrang < r.TongSoTrang; btnThanhToanTruoc.Enabled = r.SoTrang > 1; }
        private void TrangDangKy(KetQuaPhanTrang<ChiTietDangKyDto> r) { trangDangKy = r.SoTrang; lblDangKyTrang.Text = string.Format("{0}/{1} • {2} đăng ký", r.SoTrang, r.TongSoTrang, r.TongBanGhi); btnDangKySau.Enabled = r.SoTrang < r.TongSoTrang; btnDangKyTruoc.Enabled = r.SoTrang > 1; }
        private static void DatTieuDeCot(DataGridView grid, System.Collections.Generic.IDictionary<string, string> titles)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                string title; if (titles.TryGetValue(column.DataPropertyName, out title)) column.HeaderText = title;
                if (column.DataPropertyName.StartsWith("Ngay")) column.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                if (column.DataPropertyName == "TongPhaiTra" || column.DataPropertyName == "DaThanhToan" || column.DataPropertyName == "ConPhaiThu" || column.DataPropertyName == "SoTien") column.DefaultCellStyle.Format = "N0";
            }
        }
    }
}
