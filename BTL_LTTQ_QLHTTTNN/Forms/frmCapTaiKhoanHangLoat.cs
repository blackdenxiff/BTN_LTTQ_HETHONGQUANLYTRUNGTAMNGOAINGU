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
        private readonly Dictionary<string, HoSoTaiKhoanDto> hoSoDaChon = new Dictionary<string, HoSoTaiKhoanDto>();
        public string ThongBaoKetQua { get; private set; }

        public frmCapTaiKhoanHangLoat()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            cboLoaiHoSo.SelectedIndex = 0;
            dgvHoSo.CurrentCellDirtyStateChanged += delegate { if (dgvHoSo.IsCurrentCellDirty) dgvHoSo.CommitEdit(DataGridViewDataErrorContexts.Commit); };
            Load += delegate { TaiHoSo(); };
        }

        private string Khoa(HoSoTaiKhoanDto hoSo)
        { return hoSo.LoaiHoSo + ":" + hoSo.HoSoID; }

        private void GhiNhanLuaChonDong()
        {
            foreach (DataGridViewRow row in dgvHoSo.Rows)
            {
                var hoSo = row.DataBoundItem as HoSoTaiKhoanDto;
                if (hoSo == null) continue;
                hoSo.DaChon = Convert.ToBoolean(row.Cells["colChon"].Value ?? false);
                if (hoSo.DaChon) hoSoDaChon[Khoa(hoSo)] = hoSo;
                else hoSoDaChon.Remove(Khoa(hoSo));
            }
        }

        private void CapNhatSoDaChon()
        { lblSoDaChon.Text = "Đã chọn " + hoSoDaChon.Count + " hồ sơ"; btnCapTaiKhoan.Enabled = hoSoDaChon.Count > 0; }

        private void dgvHoSo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        { GhiNhanLuaChonDong(); CapNhatSoDaChon(); }

        private void TaiHoSo()
        {
            try
            {
                GhiNhanLuaChonDong();
                string role = cboLoaiHoSo.Text;
                int count;
                var page = TaiKhoanService.LayHoSoChuaCoTaiKhoanTheoTrang(role, txtTimKiem.Text.Trim(), trang, out count).ToList();
                tongTrang = Math.Max(1, (int)Math.Ceiling(count / 10.0));
                if (trang > tongTrang) { trang = tongTrang; page = TaiKhoanService.LayHoSoChuaCoTaiKhoanTheoTrang(role, txtTimKiem.Text.Trim(), trang, out count).ToList(); }
                foreach (var hoSo in page) hoSo.DaChon = hoSoDaChon.ContainsKey(Khoa(hoSo));
                dgvHoSo.DataSource = page;
                lblTrang.Text = string.Format("{0}/{1} • {2} hồ sơ phù hợp", trang, tongTrang, count);
                btnTruoc.Enabled = trang > 1; btnSau.Enabled = trang < tongTrang;
                lblTrangThai.Text = count == 0 ? "Không có hồ sơ đủ điều kiện." : "Chọn hồ sơ cần cấp tài khoản.";
            }
            catch (Exception ex) { lblTrangThai.Text = ex.Message; }
            CapNhatSoDaChon();
        }

        private void btnTim_Click(object sender, EventArgs e) { trang = 1; TaiHoSo(); }
        private void btnTruoc_Click(object sender, EventArgs e) { if (trang > 1) { trang--; TaiHoSo(); } }
        private void btnSau_Click(object sender, EventArgs e) { if (trang < tongTrang) { trang++; TaiHoSo(); } }
        private void cboLoaiHoSo_SelectedIndexChanged(object sender, EventArgs e)
        { if (LicenseManager.UsageMode != LicenseUsageMode.Designtime) { trang = 1; TaiHoSo(); } }

        private async void btnCapTaiKhoan_Click(object sender, EventArgs e)
        {
            GhiNhanLuaChonDong();
            if (hoSoDaChon.Count == 0) return;
            if (MessageBox.Show(this, "Cấp tài khoản cho " + hoSoDaChon.Count + " hồ sơ đã chọn?", "Xác nhận cấp hàng loạt", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            var selected = hoSoDaChon.Values.Select(x => new TaiKhoanTaoDto { HoSoID = x.HoSoID, VaiTro = x.LoaiHoSo }).ToList();
            btnCapTaiKhoan.Enabled = cboLoaiHoSo.Enabled = txtTimKiem.Enabled = btnTim.Enabled = false;
            progressCap.Value = 0; progressCap.Maximum = selected.Count; progressCap.Visible = true;
            lblTrangThai.Text = "Đang cấp tài khoản…";
            try
            {
                IProgress<int> progress = new Progress<int>(value => { if (value <= progressCap.Maximum) progressCap.Value = value; lblTrangThai.Text = "Đang xử lý " + value + "/" + selected.Count + "…"; });
                var result = await Task.Run(() => TaiKhoanService.TaoTaiKhoanHangLoat(selected, (done, total) => progress.Report(done)));
                int success = result.Count(x => x.ThanhCong), skipped = result.Count(x => x.BoQua), fail = result.Count - success - skipped;
                for (int i = 0; i < result.Count; i++) if (result[i].ThanhCong) hoSoDaChon.Remove(selected[i].VaiTro + ":" + selected[i].HoSoID);
                var failures = result.Select((item, index) => new { item, index }).Where(x => !x.item.ThanhCong)
                    .Select(x => selected[x.index].VaiTro + " #" + selected[x.index].HoSoID + ": " + x.item.LyDo).ToList();
                ThongBaoKetQua = "Thành công: " + success + "; bỏ qua: " + skipped + "; thất bại: " + fail + "." + (failures.Count == 0 ? "" : Environment.NewLine + string.Join(Environment.NewLine, failures));
                lblTrangThai.Text = ThongBaoKetQua;
                MessageBox.Show(this, ThongBaoKetQua, "Kết quả cấp tài khoản", MessageBoxButtons.OK, fail == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (success > 0) DialogResult = DialogResult.OK;
                TaiHoSo();
            }
            catch (Exception ex) { lblTrangThai.Text = "Không thể cấp tài khoản: " + ex.Message; }
            finally { btnCapTaiKhoan.Enabled = hoSoDaChon.Count > 0; cboLoaiHoSo.Enabled = txtTimKiem.Enabled = btnTim.Enabled = true; progressCap.Visible = false; }
        }
    }
}
