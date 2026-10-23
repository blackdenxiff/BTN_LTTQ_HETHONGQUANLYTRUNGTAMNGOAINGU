using System;
using System.Data;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmMainHocVien : Form
    {
        private int? nguoiDungID;

        // TV1 passes the authenticated NguoiDungID after a successful login.
        public frmMainHocVien(int authenticatedNguoiDungID) : this()
        {
            nguoiDungID = authenticatedNguoiDungID;
        }

        public frmMainHocVien()
        {
            InitializeComponent();
            foreach (var grid in new[] { dgvLopHoc, dgvKetQua, dgvHocPhi }) HocVienData.Grid(grid);
            Load += delegate { HocVienData.Run(LoadProfile); };
            btnThongTin.Click += btnThongTin_Click;
            btnLopHoc.Click += btnLopHoc_Click;
            btnKetQua.Click += btnKetQua_Click;
            btnHocPhi.Click += btnHocPhi_Click;
        }

        private void LoadProfile()
        {
            if (!nguoiDungID.HasValue)
            {
                lblNguoiDangNhap.Text = "Chưa nhận tài khoản đăng nhập";
                MessageBox.Show("TV1 cần mở frmMainHocVien bằng NguoiDungID đã đăng nhập.");
                return;
            }
            var table = HocVienData.Query(@"SELECT h.*,n.TenDangNhap FROM HocVien h
JOIN NguoiDung n ON n.NguoiDungID=h.NguoiDungID
JOIN VaiTro v ON v.VaiTroID=n.VaiTroID
WHERE h.NguoiDungID=@id AND h.IsDeleted=0 AND n.IsDeleted=0 AND n.TrangThai=1
AND v.IsDeleted=0 AND v.TenVaiTro=N'Học viên'", HocVienData.P("@id",nguoiDungID.Value));
            if(table.Rows.Count!=1) throw new InvalidOperationException("Tài khoản chưa gắn học viên hoặc không còn được phép truy cập.");
            DataRow row=table.Rows[0];
            int id=Convert.ToInt32(row["HocVienID"]);
            txtHocVienID.Text=id.ToString(); txtHoTen.Text=Convert.ToString(row["HoTen"]);
            txtNgaySinh.Text=row.IsNull("NgaySinh")?"":Convert.ToDateTime(row["NgaySinh"]).ToString("dd/MM/yyyy");
            txtGioiTinh.Text=Convert.ToString(row["GioiTinh"]);txtSoDienThoai.Text=Convert.ToString(row["SoDienThoai"]);
            txtEmail.Text=Convert.ToString(row["Email"]);txtTrinhDoDauVao.Text=Convert.ToString(row["TrinhDoDauVao"]);
            txtDiemDauVao.Text=Convert.ToString(row["DiemDauVao"]);txtNhanXetDauVao.Text=Convert.ToString(row["NhanXetDauVao"]);
            txtTrangThai.Text=Convert.ToString(row["TrangThai"]);txtTaiKhoan.Text=Convert.ToString(row["TenDangNhap"]);
            lblNguoiDangNhap.Text="Học viên: "+txtHoTen.Text;
            var classes=HocVienData.Enrollments(id);dgvLopHoc.DataSource=classes;dgvKetQua.DataSource=classes.Copy();
            dgvHocPhi.DataSource=HocVienData.Fees(id);
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            tabHoSo.SelectedTab = tabThongTin;
        }

        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            tabHoSo.SelectedTab = tabLopHoc;
        }

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            tabHoSo.SelectedTab = tabKetQua;
        }

        private void btnHocPhi_Click(object sender, EventArgs e)
        {
            tabHoSo.SelectedTab = tabHocPhi;
        }
    }
}
