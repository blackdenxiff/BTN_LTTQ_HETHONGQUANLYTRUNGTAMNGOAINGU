using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_LTTQ_QLHTTTNN.Services;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmCapTaiKhoanHangLoat : Form
    {
        private int trang = 1, tongTrang = 1;
        private bool dangXuLy;
        private bool dangDongBoLuaChon;
        // The dictionary is the single selection source of truth across pages.
        private readonly Dictionary<string, HoSoTaiKhoanDto> hoSoDaChon = new Dictionary<string, HoSoTaiKhoanDto>();
        public string ThongBaoKetQua { get; private set; }

        public frmCapTaiKhoanHangLoat()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            cboLoaiHoSo.SelectedIndex = 0;
            dgvHoSo.CurrentCellDirtyStateChanged += delegate
            {
                if (dgvHoSo.IsCurrentCellDirty && dgvHoSo.CurrentCell is DataGridViewCheckBoxCell)
                    dgvHoSo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
            Load += delegate { TaiHoSo(); };
        }

        private string Khoa(HoSoTaiKhoanDto hoSo)
        { return hoSo.LoaiHoSo + ":" + hoSo.HoSoID; }

        private void CapNhatTrangThaiDong(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvHoSo.Rows.Count) return;
            var row = dgvHoSo.Rows[rowIndex];
            var hoSo = row.DataBoundItem as HoSoTaiKhoanDto;
            if (hoSo == null) return;
            bool selected = Convert.ToBoolean(row.Cells["colChon"].Value ?? false);
            hoSo.DaChon = selected;
            if (selected) hoSoDaChon[Khoa(hoSo)] = hoSo;
            else hoSoDaChon.Remove(Khoa(hoSo));
        }

        private void CapNhatSoDaChon()
        {
            lblSoDaChon.Text = "Đã chọn " + hoSoDaChon.Count + " hồ sơ";
            btnCapTaiKhoan.Enabled = !dangXuLy && hoSoDaChon.Count > 0;
            bool allPageSelected = dgvHoSo.Rows.Count > 0;
            foreach (DataGridViewRow row in dgvHoSo.Rows)
                if (!Convert.ToBoolean(row.Cells["colChon"].Value ?? false)) { allPageSelected = false; break; }
            btnChonTrang.Text = allPageSelected ? "Bỏ chọn trang" : "Chọn tất cả trang";
            btnChonTrang.Enabled = !dangXuLy && dgvHoSo.Rows.Count > 0;
        }

        private void dgvHoSo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dangDongBoLuaChon || e.RowIndex < 0 || e.ColumnIndex != dgvHoSo.Columns["colChon"].Index) return;
            CapNhatTrangThaiDong(e.RowIndex);
            CapNhatSoDaChon();
        }

        private void ChonHoSoTrangHienTai(object sender, EventArgs e)
        {
            if (dangXuLy) return;
            KetThucSuaCheckbox();
            bool allPageSelected = dgvHoSo.Rows.Count > 0;
            foreach (DataGridViewRow row in dgvHoSo.Rows)
                if (!Convert.ToBoolean(row.Cells["colChon"].Value ?? false)) { allPageSelected = false; break; }
            bool selectPage = !allPageSelected;
            dangDongBoLuaChon = true;
            try
            {
                foreach (DataGridViewRow row in dgvHoSo.Rows)
                {
                    var hoSo = row.DataBoundItem as HoSoTaiKhoanDto;
                    if (hoSo == null) continue;
                    row.Cells["colChon"].Value = selectPage;
                    hoSo.DaChon = selectPage;
                    if (selectPage) hoSoDaChon[Khoa(hoSo)] = hoSo;
                    else hoSoDaChon.Remove(Khoa(hoSo));
                }
            }
            finally { dangDongBoLuaChon = false; }
            CapNhatSoDaChon();
        }

        private void KetThucSuaCheckbox()
        {
            if (dgvHoSo.IsCurrentCellDirty) dgvHoSo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvHoSo.EndEdit();
        }

        private void TaiHoSo()
        {
            try
            {
                KetThucSuaCheckbox();
                string role = cboLoaiHoSo.Text;
                int count;
                var page = TaiKhoanService.LayHoSoChuaCoTaiKhoanTheoTrang(role, txtTimKiem.Text.Trim(), trang, out count).ToList();
                tongTrang = Math.Max(1, (int)Math.Ceiling(count / 10.0));
                if (trang > tongTrang) { trang = tongTrang; page = TaiKhoanService.LayHoSoChuaCoTaiKhoanTheoTrang(role, txtTimKiem.Text.Trim(), trang, out count).ToList(); }
                dangDongBoLuaChon = true;
                try
                {
                    foreach (var hoSo in page) hoSo.DaChon = hoSoDaChon.ContainsKey(Khoa(hoSo));
                    dgvHoSo.DataSource = page;
                }
                finally { dangDongBoLuaChon = false; }
                lblTrang.Text = string.Format("{0}/{1} • {2} hồ sơ phù hợp", trang, tongTrang, count);
                btnTruoc.Enabled = trang > 1; btnSau.Enabled = trang < tongTrang;
                lblTrangThai.Text = count == 0 ? "Không có hồ sơ đủ điều kiện." : "Chọn hồ sơ cần cấp tài khoản.";
            }
            catch (Exception ex) { lblTrangThai.Text = ex.Message; }
            CapNhatSoDaChon();
        }

        private void btnTim_Click(object sender, EventArgs e) { XoaLuaChon(); trang = 1; TaiHoSo(); }
        private void btnTruoc_Click(object sender, EventArgs e) { if (trang > 1) { trang--; TaiHoSo(); } }
        private void btnSau_Click(object sender, EventArgs e) { if (trang < tongTrang) { trang++; TaiHoSo(); } }
        private void cboLoaiHoSo_SelectedIndexChanged(object sender, EventArgs e)
        { if (LicenseManager.UsageMode != LicenseUsageMode.Designtime) { XoaLuaChon(); trang = 1; TaiHoSo(); } }

        private void XoaLuaChon()
        {
            KetThucSuaCheckbox();
            hoSoDaChon.Clear();
            dangDongBoLuaChon = true;
            try
            {
                foreach (DataGridViewRow row in dgvHoSo.Rows)
                {
                    var hoSo = row.DataBoundItem as HoSoTaiKhoanDto;
                    if (hoSo != null) hoSo.DaChon = false;
                    row.Cells["colChon"].Value = false;
                }
            }
            finally { dangDongBoLuaChon = false; }
            CapNhatSoDaChon();
        }

        private async void btnCapTaiKhoan_Click(object sender, EventArgs e)
        {
            if (dangXuLy) return;
            KetThucSuaCheckbox();
            CapNhatSoDaChon();
            if (hoSoDaChon.Count == 0) return;
            int soLuongChon = hoSoDaChon.Count;
            if (MessageBox.Show(this, "Tạo tài khoản cho " + soLuongChon + " hồ sơ đã chọn?", "Xác nhận cấp hàng loạt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            var selected = hoSoDaChon.Values.Select(x => new TaiKhoanTaoDto { HoSoID = x.HoSoID, VaiTro = x.LoaiHoSo }).ToList();
            dangXuLy = true;
            dgvHoSo.Enabled = btnTruoc.Enabled = btnSau.Enabled = cboLoaiHoSo.Enabled = txtTimKiem.Enabled = btnTim.Enabled = btnChonTrang.Enabled = false;
            btnCapTaiKhoan.Enabled = false;
            progressCap.Value = 0; progressCap.Maximum = selected.Count; progressCap.Visible = true;
            lblTrangThai.Text = "Đang cấp tài khoản…";
            bool coThanhCong = false;
            string ketQuaCuoi = null;
            try
            {
                IProgress<int> progress = new Progress<int>(value => { if (value <= progressCap.Maximum) progressCap.Value = value; lblTrangThai.Text = "Đang xử lý " + value + "/" + selected.Count + "…"; });
                var result = await Task.Run(() => TaiKhoanService.TaoTaiKhoanHangLoat(selected, (done, total) => progress.Report(done)));
                int success = result.Count(x => x.ThanhCong), skipped = result.Count(x => x.BoQua), fail = result.Count - success - skipped;
                for (int i = 0; i < result.Count; i++) if (result[i].ThanhCong) hoSoDaChon.Remove(selected[i].VaiTro + ":" + selected[i].HoSoID);
                var details = result.Select((item, index) => new { item, index }).Where(x => !x.item.ThanhCong)
                    .Select(x => selected[x.index].VaiTro + " #" + selected[x.index].HoSoID + ": " + x.item.LyDo).ToList();
                ThongBaoKetQua = "Thành công: " + success + "; bỏ qua: " + skipped + "; thất bại: " + fail + "." + (details.Count == 0 ? "" : Environment.NewLine + string.Join(Environment.NewLine, details));
                ketQuaCuoi = ThongBaoKetQua;
                coThanhCong = success > 0;
            }
            catch (Exception ex)
            {
                ketQuaCuoi = "Không thể cấp tài khoản: " + ex.Message;
                ThongBaoKetQua = ketQuaCuoi;
            }
            finally
            {
                dangXuLy = false;
                dgvHoSo.Enabled = cboLoaiHoSo.Enabled = txtTimKiem.Enabled = btnTim.Enabled = true;
                progressCap.Visible = false;
                TaiHoSo();
            }
            if (!string.IsNullOrEmpty(ketQuaCuoi))
            {
                lblTrangThai.Text = ketQuaCuoi;
                MessageBox.Show(this, ketQuaCuoi, "Kết quả cấp tài khoản", MessageBoxButtons.OK,
                    ketQuaCuoi.StartsWith("Không thể") || ketQuaCuoi.IndexOf("thất bại: 0", StringComparison.Ordinal) < 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
                if (coThanhCong) DialogResult = DialogResult.OK;
            }
        }
    }
}
