using System;
using System.Data;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmTaoLichHoc : Form
    {
        private int _lichHocID = 0;

        public frmTaoLichHoc(int lichHocID = 0)
        {
            InitializeComponent();
            _lichHocID = lichHocID;
        }

        private void frmTaoLichHoc_Load(object sender, EventArgs e)
        {
            Functions.Connect();

            DataTable dtLop = Functions.GetDataToTable("SELECT LopHocID, TenLop FROM LopHoc WHERE IsDeleted = 0");
            DataRow drLop = dtLop.NewRow();
            drLop["LopHocID"] = 0;
            drLop["TenLop"] = "-- Chọn lớp học --";
            dtLop.Rows.InsertAt(drLop, 0);
            cboLopHoc.DataSource = dtLop;
            cboLopHoc.DisplayMember = "TenLop";
            cboLopHoc.ValueMember = "LopHocID";

            DataTable dtPhong = Functions.GetDataToTable("SELECT PhongHocID, TenPhong FROM PhongHoc");
            DataRow drPhong = dtPhong.NewRow();
            drPhong["PhongHocID"] = 0;
            drPhong["TenPhong"] = "-- Chọn phòng học --";
            dtPhong.Rows.InsertAt(drPhong, 0);
            cboPhongHoc.DataSource = dtPhong;
            cboPhongHoc.DisplayMember = "TenPhong";
            cboPhongHoc.ValueMember = "PhongHocID";

            cboCaHoc.Items.Clear();
            cboCaHoc.Items.AddRange(new object[] {
                "-- Chọn ca học --",
                "Ca Sáng (08:00 - 10:00)",
                "Ca Chiều (14:00 - 16:00)",
                "Ca Tối (18:00 - 20:00)"
            });
            cboCaHoc.SelectedIndex = 0;

            string sqlGV = "SELECT NhanSuID AS GiaoVienID, HoTen AS TenGiaoVien FROM NhanSu " +
                           "WHERE LoaiNhanSu = N'Giáo viên' OR LoaiNhanSu = N'Cả hai'";
            DataTable dtGiaoVien = Functions.GetDataToTable(sqlGV);
            DataRow drGV = dtGiaoVien.NewRow();
            drGV["GiaoVienID"] = 0;
            drGV["TenGiaoVien"] = "-- Chọn giáo viên --";
            dtGiaoVien.Rows.InsertAt(drGV, 0);
            cboGiaoVien.DataSource = dtGiaoVien;
            cboGiaoVien.DisplayMember = "TenGiaoVien";
            cboGiaoVien.ValueMember = "GiaoVienID";

            dtpNgayHoc.Value = DateTime.Now;

            if (_lichHocID > 0)
            {
                lblTieuDe.Text = "✏️ Chi Tiết & Cập Nhật Lịch Học";
                btnXoa.Visible = true;
                LoadChiTietLichHoc();
            }
            else
            {
                lblTieuDe.Text = "📅 Xếp Lịch Học Mới";
                btnXoa.Visible = false;
            }
        }

        private void LoadChiTietLichHoc()
        {
            string sql = $"SELECT lh.LopHocID, lh.PhongHocID, lh.NgayHoc, lh.GioBatDau, l.GiaoVienPhuTrachID " +
                         $"FROM LichHoc lh " +
                         $"LEFT JOIN LopHoc l ON lh.LopHocID = l.LopHocID " +
                         $"WHERE lh.LichHocID = {_lichHocID}";

            DataTable dt = Functions.GetDataToTable(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                cboLopHoc.SelectedValue = Convert.ToInt32(dr["LopHocID"]);
                cboPhongHoc.SelectedValue = Convert.ToInt32(dr["PhongHocID"]);

                if (dr["GiaoVienPhuTrachID"] != DBNull.Value)
                    cboGiaoVien.SelectedValue = Convert.ToInt32(dr["GiaoVienPhuTrachID"]);

                dtpNgayHoc.Value = Convert.ToDateTime(dr["NgayHoc"]);

                TimeSpan gio = (TimeSpan)dr["GioBatDau"];
                if (gio.Hours == 8) cboCaHoc.SelectedIndex = 1;
                else if (gio.Hours == 14) cboCaHoc.SelectedIndex = 2;
                else if (gio.Hours == 18) cboCaHoc.SelectedIndex = 3;
            }
        }

        private void cboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLopHoc.SelectedValue != null && int.TryParse(cboLopHoc.SelectedValue.ToString(), out int lopHocID) && lopHocID > 0)
            {
                string sql = $"SELECT k.TenKhoaHoc, l.GiaoVienPhuTrachID FROM LopHoc l " +
                             $"LEFT JOIN KhoaHoc k ON l.KhoaHocID = k.KhoaHocID " +
                             $"WHERE l.LopHocID = {lopHocID}";
                DataTable dt = Functions.GetDataToTable(sql);
                if (dt.Rows.Count > 0)
                {
                    txtKhoaHoc.Text = dt.Rows[0]["TenKhoaHoc"].ToString();
                    if (_lichHocID == 0 && dt.Rows[0]["GiaoVienPhuTrachID"] != DBNull.Value)
                    {
                        cboGiaoVien.SelectedValue = Convert.ToInt32(dt.Rows[0]["GiaoVienPhuTrachID"]);
                    }
                }
            }
            else
            {
                txtKhoaHoc.Text = "";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboLopHoc.SelectedValue == null || Convert.ToInt32(cboLopHoc.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn Lớp học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLopHoc.Focus();
                return;
            }

            if (cboPhongHoc.SelectedValue == null || Convert.ToInt32(cboPhongHoc.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn Phòng học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPhongHoc.Focus();
                return;
            }

            if (cboCaHoc.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Ca học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCaHoc.Focus();
                return;
            }

            int lopHocID = Convert.ToInt32(cboLopHoc.SelectedValue);
            int phongHocID = Convert.ToInt32(cboPhongHoc.SelectedValue);
            string ngayHoc = dtpNgayHoc.Value.ToString("yyyy-MM-dd");

            string gioBatDau = "08:00:00";
            string gioKetThuc = "10:00:00";
            if (cboCaHoc.SelectedIndex == 2) { gioBatDau = "14:00:00"; gioKetThuc = "16:00:00"; }
            else if (cboCaHoc.SelectedIndex == 3) { gioBatDau = "18:00:00"; gioKetThuc = "20:00:00"; }

            string sqlCheck = $"SELECT COUNT(*) FROM LichHoc WHERE PhongHocID = {phongHocID} AND NgayHoc = '{ngayHoc}' AND GioBatDau = '{gioBatDau}' AND IsDeleted = 0 AND LichHocID != {_lichHocID}";
            DataTable dtCheck = Functions.GetDataToTable(sqlCheck);
            if (dtCheck.Rows.Count > 0 && Convert.ToInt32(dtCheck.Rows[0][0]) > 0)
            {
                MessageBox.Show("Phòng học này đã có lớp sử dụng vào Ca và Ngày đã chọn!", "Cảnh báo trùng lịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboGiaoVien.SelectedValue != null && Convert.ToInt32(cboGiaoVien.SelectedValue) > 0)
            {
                int gvID = Convert.ToInt32(cboGiaoVien.SelectedValue);
                Functions.RunSQL($"UPDATE LopHoc SET GiaoVienPhuTrachID = {gvID} WHERE LopHocID = {lopHocID}");
            }

            if (_lichHocID > 0)
            {
                string sqlUpdate = $"UPDATE LichHoc SET LopHocID = {lopHocID}, PhongHocID = {phongHocID}, " +
                                   $"NgayHoc = '{ngayHoc}', GioBatDau = '{gioBatDau}', GioKetThuc = '{gioKetThuc}', UpdatedAt = GETDATE() " +
                                   $"WHERE LichHocID = {_lichHocID}";
                Functions.RunSQL(sqlUpdate);
                MessageBox.Show("Cập nhật lịch học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sqlInsert = $"INSERT INTO LichHoc (LopHocID, PhongHocID, NgayHoc, GioBatDau, GioKetThuc, TrangThai, IsDeleted, CreatedAt) " +
                                   $"VALUES ({lopHocID}, {phongHocID}, '{ngayHoc}', '{gioBatDau}', '{gioKetThuc}', N'Đã lên lịch', 0, GETDATE())";
                Functions.RunSQL(sqlInsert);
                MessageBox.Show("Xếp lịch học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa lịch học này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Functions.RunSQL($"UPDATE LichHoc SET IsDeleted = 1 WHERE LichHocID = {_lichHocID}");
                MessageBox.Show("Xóa lịch học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}