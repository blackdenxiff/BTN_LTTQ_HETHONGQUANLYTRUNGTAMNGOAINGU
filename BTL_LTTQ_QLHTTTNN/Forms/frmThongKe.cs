using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
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
        private CancellationTokenSource tokenHuyXuat;
        private int trangHoaDon = 1, trangThanhToan = 1, trangDangKy = 1, requestId;
        public frmThongKe() : this(null) { }

        public frmThongKe(Action quayVeTongQuan)
        {
            InitializeComponent(); quayVe = quayVeTongQuan; DateTime today = DateTime.Today;
            btnXuatExcel.Enabled = false;
            dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1); dtpDenNgay.Value = today;
            btnHoaDonTruoc.Click += delegate { if (trangHoaDon > 1) { trangHoaDon--; TaiHoaDon(); } };
            btnHoaDonSau.Click += delegate { if (trangHoaDon < TongSoTrangHoaDon) { trangHoaDon++; TaiHoaDon(); } };
            btnThanhToanTruoc.Click += delegate { if (trangThanhToan > 1) { trangThanhToan--; TaiThanhToan(); } };
            btnThanhToanSau.Click += delegate { if (trangThanhToan < TongSoTrangThanhToan) { trangThanhToan++; TaiThanhToan(); } };
            btnDangKyTruoc.Click += delegate { if (trangDangKy > 1) { trangDangKy--; TaiDangKy(); } };
            btnDangKySau.Click += delegate { if (trangDangKy < TongSoTrangDangKy) { trangDangKy++; TaiDangKy(); } };
            dtpTuNgay.ValueChanged += delegate { KiemTraBoLocThayDoi(); };
            dtpDenNgay.ValueChanged += delegate { KiemTraBoLocThayDoi(); };
            cboCoSo.SelectedIndexChanged += delegate { KiemTraBoLocThayDoi(); };
            dgvHoaDon.CellToolTipTextNeeded += HienTooltipOQuaDai;
            dgvThanhToan.CellToolTipTextNeeded += HienTooltipOQuaDai;
            dgvDangKy.CellToolTipTextNeeded += HienTooltipOQuaDai;
            Load += async delegate { await NapCoSo(); if (cboCoSo.Items.Count > 0) cboCoSo.SelectedIndex = 0; await XemThongKe(); };
        }
        private int TongSoTrangHoaDon { get; set; } = 1;
        private int TongSoTrangThanhToan { get; set; } = 1;
        private int TongSoTrangDangKy { get; set; } = 1;

        private async Task NapCoSo()
        {
            cboCoSo.Items.Clear(); cboCoSo.Items.Add(new CoSoLuaChon { Id = null, Ten = "Tất cả cơ sở" });
            try { var sites = await Task.Run(() => ThongKeService.LayCoSo()); foreach (var x in sites) cboCoSo.Items.Add(new CoSoLuaChon { Id = x.Key, Ten = x.Value }); }
            catch (Exception ex) { lblTrangThai.Text = ex.Message; }
        }
        private async void btnXem_Click(object sender, EventArgs e) { await XemThongKe(); }
        private async void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (boLoc == null || !BoLocDangApDung()) { lblTrangThai.Text = "Bộ lọc đã thay đổi. Hãy bấm Xem thống kê trước khi xuất."; return; }
            string loai = cboLoaiBaoCao.Text;
            string ten = loai == "Hóa đơn trong kỳ" ? "HoaDon" : loai == "Thanh toán phát sinh" ? "ThanhToan" : loai == "Đăng ký trong kỳ" ? "DangKy" : "ThongKeTongHop";
            string fileName = ten + "_" + boLoc.TuNgay.ToString("ddMMyyyy") + "_" + boLoc.DenNgay.ToString("ddMMyyyy") + ".xlsx";
            using (var dialog = new SaveFileDialog { Filter = "Tệp Excel (*.xlsx)|*.xlsx", DefaultExt = "xlsx", AddExtension = true, FileName = fileName, OverwritePrompt = true })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                using (var huy = new CancellationTokenSource())
                {
                    tokenHuyXuat = huy; btnXuatExcel.Enabled = false; btnHuyXuat.Visible = true; btnHuyXuat.Enabled = true; lblTrangThai.Text = "Đang xuất Excel…";
                    try { await XuatThongKeExcelService.TaoBaoCaoExcelAsync(boLoc, dialog.FileName, loai, huy.Token); lblTrangThai.Text = "Đã xuất báo cáo: " + dialog.FileName; }
                    catch (OperationCanceledException) { lblTrangThai.Text = "Đã hủy xuất báo cáo."; }
                    catch (Exception ex) { lblTrangThai.Text = "Không xuất được: " + ex.Message; }
                    finally { tokenHuyXuat = null; if (!IsDisposed) { btnHuyXuat.Visible = false; btnXuatExcel.Enabled = BoLocDangApDung(); } }
                }
            }
        }
        private void btnHuyXuat_Click(object sender, EventArgs e) { if (tokenHuyXuat != null) { btnHuyXuat.Enabled = false; tokenHuyXuat.Cancel(); lblTrangThai.Text = "Đang hủy xuất báo cáo…"; } }
        private async void btnDatLai_Click(object sender, EventArgs e) { DateTime today = DateTime.Today; dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1); dtpDenNgay.Value = today; cboCoSo.SelectedIndex = cboCoSo.Items.Count > 0 ? 0 : -1; await XemThongKe(); }
        private void btnTongQuan_Click(object sender, EventArgs e) { if (quayVe != null) quayVe(); }
        private async Task XemThongKe()
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date) { lblTrangThai.Text = "Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc."; return; }
            var coSo = cboCoSo.SelectedItem as CoSoLuaChon; var locChot = new ThongKeBoLoc { TuNgay = dtpTuNgay.Value.Date, DenNgay = dtpDenNgay.Value.Date, CoSoID = coSo == null ? (int?)null : coSo.Id, TenCoSo = coSo == null ? "Tất cả cơ sở" : coSo.Ten };
            int request = ++requestId; btnXem.Enabled = btnDatLai.Enabled = false; lblTrangThai.Text = "Đang tải số liệu…"; trangHoaDon = trangThanhToan = trangDangKy = 1;
            try
            {
                var result = await Task.Run(() => new { TongHoaDon = ThongKeService.LayTongHopHoaDon(locChot), TongThanhToan = ThongKeService.LayTongHopThanhToan(locChot), TongDangKy = ThongKeService.LayTongHopDangKy(locChot), Lop = ThongKeService.LaySoLopTheoTrangThai(locChot), HoaDon = ThongKeService.LayTinhHinhThuTheoTrang(locChot, 1), ThanhToan = ThongKeService.LayChiTietThanhToanTheoTrang(locChot, 1), DangKyRows = ThongKeService.LayChiTietDangKyTheoTrang(locChot, 1) });
                if (IsDisposed || request != requestId) return;
                boLoc = new ThongKeBoLoc { TuNgay = locChot.TuNgay, DenNgay = locChot.DenNgay, CoSoID = locChot.CoSoID, TenCoSo = locChot.TenCoSo };
                btnXuatExcel.Enabled = BoLocDangApDung();
                dgvHoaDon.DataSource = result.HoaDon.DanhSach; dgvThanhToan.DataSource = result.ThanhToan.DanhSach; dgvDangKy.DataSource = result.DangKyRows.DanhSach;
                TrangHoaDon(result.HoaDon); TrangThanhToan(result.ThanhToan); TrangDangKy(result.DangKyRows);
                lblTongHop.Text = string.Format("Tiền thực thu: {0:N0} đ     •     Số đăng ký: {1:N0}     •     Số lớp hiện tại: {2:N0}", result.TongThanhToan.TongThucThuTrongKy, result.TongDangKy.TongSoLuong, result.Lop.Sum(x => x.SoLuong));
                lblHoaDonTong.Text = string.Format("{0}Tổng hóa đơn: {1:N0}   •   Phải trả: {2:N0} đ   •   Đã thanh toán đến cuối kỳ: {3:N0} đ   •   Còn phải thu: {4:N0} đ", result.HoaDon.TongBanGhi == 0 ? "Không có dữ liệu phù hợp.  " : "", result.TongHoaDon.TongSoLuong, result.TongHoaDon.TongPhaiTra, result.TongHoaDon.TongDaThanhToanCuoiKy, result.TongHoaDon.TongConPhaiThu);
                lblThanhToanTong.Text = string.Format("{0}Tổng lượt thanh toán: {1:N0}   •   Thực thu trong kỳ: {2:N0} đ", result.ThanhToan.TongBanGhi == 0 ? "Không có dữ liệu phù hợp.  " : "", result.TongThanhToan.TongSoLuong, result.TongThanhToan.TongThucThuTrongKy);
                lblDangKyTong.Text = string.Format("{0}Tổng đăng ký trong kỳ: {1:N0}   •   Học viên khác nhau: {2:N0}", result.DangKyRows.TongBanGhi == 0 ? "Không có dữ liệu phù hợp.  " : "", result.TongDangKy.TongSoLuong, result.TongDangKy.TongHocVienKhacNhau);
                lblGiaiThich.Text = "Hóa đơn tính theo ngày lập; thanh toán và thực thu theo ngày thanh toán; đăng ký theo ngày đăng ký. Đã thanh toán cộng các khoản đến hết ngày cuối kỳ; số âm là thu vượt. Lớp hiện tại là số lớp đang hoạt động, không phải lớp lịch sử.";
                lblTrangThai.Text = "Cập nhật lúc " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + (coSo == null || !coSo.Id.HasValue ? " • Tất cả cơ sở" : " • " + coSo.Ten);
            }
            catch (Exception ex) { if (request == requestId) lblTrangThai.Text = "Không tải được: " + ex.Message; }
            finally { if (request == requestId) btnXem.Enabled = btnDatLai.Enabled = true; }
        }
        private void TaiHoaDon() { try { var r = ThongKeService.LayTinhHinhThuTheoTrang(boLoc, trangHoaDon); dgvHoaDon.DataSource = r.DanhSach; if (r.TongBanGhi == 0) lblHoaDonTong.Text = "Không có dữ liệu phù hợp."; TrangHoaDon(r); } catch (Exception ex) { lblTrangThai.Text = ex.Message; } }
        private void TaiThanhToan() { try { var r = ThongKeService.LayChiTietThanhToanTheoTrang(boLoc, trangThanhToan); dgvThanhToan.DataSource = r.DanhSach; if (r.TongBanGhi == 0) lblThanhToanTong.Text = "Không có dữ liệu phù hợp."; TrangThanhToan(r); } catch (Exception ex) { lblTrangThai.Text = ex.Message; } }
        private void TaiDangKy() { try { var r = ThongKeService.LayChiTietDangKyTheoTrang(boLoc, trangDangKy); dgvDangKy.DataSource = r.DanhSach; if (r.TongBanGhi == 0) lblDangKyTong.Text = "Không có dữ liệu phù hợp."; TrangDangKy(r); } catch (Exception ex) { lblTrangThai.Text = ex.Message; } }

        private void TrangHoaDon(KetQuaPhanTrang<TinhHinhHoaDonDto> r) { trangHoaDon = r.SoTrang; TongSoTrangHoaDon = r.TongSoTrang; lblHoaDonTrang.Text = string.Format("{0}/{1} • {2} hóa đơn", r.SoTrang, r.TongSoTrang, r.TongBanGhi); btnHoaDonSau.Enabled = r.SoTrang < r.TongSoTrang; btnHoaDonTruoc.Enabled = r.SoTrang > 1; }
        private void TrangThanhToan(KetQuaPhanTrang<ChiTietThanhToanDto> r) { trangThanhToan = r.SoTrang; TongSoTrangThanhToan = r.TongSoTrang; lblThanhToanTrang.Text = string.Format("{0}/{1} • {2} thanh toán", r.SoTrang, r.TongSoTrang, r.TongBanGhi); btnThanhToanSau.Enabled = r.SoTrang < r.TongSoTrang; btnThanhToanTruoc.Enabled = r.SoTrang > 1; }
        private void TrangDangKy(KetQuaPhanTrang<ChiTietDangKyDto> r) { trangDangKy = r.SoTrang; TongSoTrangDangKy = r.TongSoTrang; lblDangKyTrang.Text = string.Format("{0}/{1} • {2} đăng ký", r.SoTrang, r.TongSoTrang, r.TongBanGhi); btnDangKySau.Enabled = r.SoTrang < r.TongSoTrang; btnDangKyTruoc.Enabled = r.SoTrang > 1; }
        private void KiemTraBoLocThayDoi()
        {
            bool hopLe = BoLocDangApDung(); btnXuatExcel.Enabled = hopLe;
            if (boLoc != null && !hopLe) lblTrangThai.Text = "Bộ lọc thay đổi. Hãy bấm Xem thống kê để cập nhật số liệu trước khi xuất.";
        }

        private bool BoLocDangApDung()
        {
            if (boLoc == null) return false;
            var coSo = cboCoSo.SelectedItem as CoSoLuaChon;
            int? id = coSo == null ? (int?)null : coSo.Id;
            return boLoc.TuNgay.Date == dtpTuNgay.Value.Date && boLoc.DenNgay.Date == dtpDenNgay.Value.Date && boLoc.CoSoID == id;
        }

        private static void HienTooltipOQuaDai(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid == null || e.RowIndex < 0 || e.ColumnIndex < 0) return;
            object value = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            string text = value == null ? "" : Convert.ToString(value);
            if (text.Length > 24) e.ToolTipText = text;
        }
    }
}
