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
        private IList<NhomThongKeDto> thucThu = new List<NhomThongKeDto>(), dangKy = new List<NhomThongKeDto>(), lop = new List<NhomThongKeDto>();
        private int trangHoaDon = 1, trangThanhToan = 1, trangDangKy = 1, requestId;
        public frmThongKe(Action quayVeTongQuan = null)
        {
            InitializeComponent(); quayVe = quayVeTongQuan; DateTime today = DateTime.Today;
            dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1); dtpDenNgay.Value = today;
            btnHoaDonTruoc.Click += delegate { if (trangHoaDon > 1) { trangHoaDon--; TaiHoaDon(); } };
            btnHoaDonSau.Click += delegate { trangHoaDon++; TaiHoaDon(); };
            btnThanhToanTruoc.Click += delegate { if (trangThanhToan > 1) { trangThanhToan--; TaiThanhToan(); } };
            btnThanhToanSau.Click += delegate { trangThanhToan++; TaiThanhToan(); };
            btnDangKyTruoc.Click += delegate { if (trangDangKy > 1) { trangDangKy--; TaiDangKy(); } };
            btnDangKySau.Click += delegate { trangDangKy++; TaiDangKy(); };
            Load += async delegate { await NapCoSo(); cboCoSo.SelectedIndex = 0; await XemThongKe(); };
        }
        private async Task NapCoSo()
        {
            try { var sites = await Task.Run(() => ThongKeService.LayCoSo()); cboCoSo.Items.Clear(); cboCoSo.Items.Add(new CoSoLuaChon { Id = null, Ten = "Tất cả cơ sở" }); foreach (var x in sites) cboCoSo.Items.Add(new CoSoLuaChon { Id = x.Key, Ten = x.Value }); }
            catch (Exception ex) { lblTrangThai.Text = ex.Message; }
        }
        private async void btnXem_Click(object sender, EventArgs e) { await XemThongKe(); }
        private async void btnDatLai_Click(object sender, EventArgs e) { DateTime today = DateTime.Today; dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1); dtpDenNgay.Value = today; cboCoSo.SelectedIndex = cboCoSo.Items.Count > 0 ? 0 : -1; await XemThongKe(); }
        private void btnTongQuan_Click(object sender, EventArgs e) { if (quayVe != null) quayVe(); }
        private async Task XemThongKe()
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date) { lblTrangThai.Text = "Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc."; return; }
            var coSo = cboCoSo.SelectedItem as CoSoLuaChon; boLoc = new ThongKeBoLoc { TuNgay = dtpTuNgay.Value.Date, DenNgay = dtpDenNgay.Value.Date, CoSoID = coSo == null ? (int?)null : coSo.Id };
            int request = ++requestId; btnXem.Enabled = btnDatLai.Enabled = false; lblTrangThai.Text = "Đang tải số liệu…"; trangHoaDon = trangThanhToan = trangDangKy = 1;
            try
            {
                var result = await Task.Run(() => new { ThucThu = ThongKeService.LayThucThuTheoThang(boLoc), DangKy = ThongKeService.LayDangKyTheoThang(boLoc), Lop = ThongKeService.LaySoLopTheoTrangThai(boLoc), HoaDon = ThongKeService.LayTinhHinhThuTheoTrang(boLoc, 1), ThanhToan = ThongKeService.LayChiTietThanhToanTheoTrang(boLoc, 1), DangKyRows = ThongKeService.LayChiTietDangKyTheoTrang(boLoc, 1) });
                if (IsDisposed || request != requestId) return;
                thucThu = result.ThucThu; dangKy = result.DangKy; lop = result.Lop; dgvHoaDon.DataSource = result.HoaDon.DanhSach; dgvThanhToan.DataSource = result.ThanhToan.DanhSach; dgvDangKy.DataSource = result.DangKyRows.DanhSach;
                DatTieuDeCot(dgvHoaDon, new System.Collections.Generic.Dictionary<string, string> { { "HoaDonID", "Mã hóa đơn" }, { "NgayLap", "Ngày lập" }, { "HocVien", "Học viên" }, { "TenLop", "Lớp" }, { "CoSo", "Cơ sở" }, { "TongPhaiTra", "Phải trả" }, { "DaThanhToan", "Đã thanh toán đến cuối kỳ" }, { "ConPhaiThu", "Còn phải thu" }, { "ThuVuot", "Thu vượt phải trả" } });
                DatTieuDeCot(dgvThanhToan, new System.Collections.Generic.Dictionary<string, string> { { "ThanhToanID", "Mã thanh toán" }, { "NgayThanhToan", "Ngày thanh toán" }, { "HoaDonID", "Mã hóa đơn" }, { "HocVien", "Học viên" }, { "SoTien", "Số tiền" } });
                DatTieuDeCot(dgvDangKy, new System.Collections.Generic.Dictionary<string, string> { { "DangKyID", "Mã đăng ký" }, { "NgayDangKy", "Ngày đăng ký" }, { "HocVien", "Học viên" }, { "LopHoc", "Lớp" }, { "TrangThai", "Trạng thái" } });
                TrangHoaDon(result.HoaDon); TrangThanhToan(result.ThanhToan); TrangDangKy(result.DangKyRows);
                decimal sum = thucThu.Sum(x => x.SoTien); int enroll = dangKy.Sum(x => x.SoLuong);
                lblTongHop.Text = string.Format("Thực thu trong kỳ: {0:N0} đ     •     Đăng ký trong kỳ: {1:N0}     •     Lớp hiện tại: {2:N0}", sum, enroll, lop.Sum(x => x.SoLuong));
                lblGiaiThich.Text = "Thực thu dùng NgayThanhToan; đăng ký dùng NgayDangKy; hóa đơn dùng NgayLap. Còn phải thu = TổngPhảiTrả − thanh toán hợp lệ đến hết ngày " + boLoc.DenNgay.ToString("dd/MM/yyyy") + ". Cơ sở lấy từ lớp qua đăng ký; hóa đơn không có đăng ký hiển thị Chưa xác định.";
                lblTrangThai.Text = "Cập nhật lúc " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + (coSo == null || !coSo.Id.HasValue ? " • Tất cả cơ sở" : " • " + coSo.Ten);
                pnlBieuDo.Invalidate();
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
        private void pnlBieuDo_Paint(object sender, PaintEventArgs e)
        {
            if (thucThu.Count == 0 && dangKy.Count == 0 && lop.Count == 0) { e.Graphics.DrawString("Không có dữ liệu trong khoảng đã chọn.", Font, Brushes.Gray, 14, 16); return; }
            var totals = thucThu.Select(x => x.SoTien).ToArray(); decimal max = totals.Length == 0 ? 0 : totals.Max(); int slot = Math.Max(1, (pnlBieuDo.Width - 30) / Math.Max(1, thucThu.Count));
            for (int i = 0; i < thucThu.Count; i++) { int h = max <= 0 ? 0 : (int)((double)thucThu[i].SoTien / (double)max * 78); int x = 18 + i * slot; e.Graphics.FillRectangle(Brushes.SteelBlue, x, 96 - h, Math.Max(8, slot - 10), h); e.Graphics.DrawString(thucThu[i].Nhan, Font, Brushes.DimGray, x, 100); }
            e.Graphics.DrawString("Thực thu theo tháng (đ)", Font, Brushes.DimGray, 18, 8);
            int count = dangKy.Sum(x => x.SoLuong); e.Graphics.DrawString("Đăng ký trong kỳ: " + count.ToString("N0") + "     •     Lớp theo trạng thái hiện tại: " + string.Join(", ", lop.Select(x => x.Nhan + " " + x.SoLuong)), Font, Brushes.DimGray, Math.Min(560, pnlBieuDo.Width / 2), 20);
        }
    }
}
