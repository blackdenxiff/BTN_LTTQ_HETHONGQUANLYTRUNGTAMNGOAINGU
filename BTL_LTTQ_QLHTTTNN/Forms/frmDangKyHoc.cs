using System;
using System.Data;
using System.Windows.Forms;
namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmDangKyHoc : Form
    {
        private readonly int? nguoiDungID;
        public int? HocVienDuocChon { get; set; }
        private int hocVienID;

        public frmDangKyHoc(int authenticatedNguoiDungID) : this()
        {
            nguoiDungID = authenticatedNguoiDungID;
        }

        // Constructor khong tham so duoc giu de mo WinForms Designer.
        public frmDangKyHoc()
        {
            InitializeComponent(); HocVienData.Grid(dgvLopHoc); txtGhiChu.MaxLength = 500;
            new GridPager(dgvLopHoc, delegate
            {
                BTL_LTTQ_QLHTTTNN.Services.PhanQuyenService.YeuCauQuyen("DangKyLopCaNhan");
            }, pnlPhanTrang, btnTrangTruoc, btnTrangSau, lblTrang, cboSoDong);
            cboHocVien.SelectedIndexChanged += delegate { ShowStudent(); ShowClass(); };
            btnTimHocVien.Click += delegate { HocVienData.Run(delegate { LoadStudent(); ShowClass(); }); };
            txtTimHocVien.KeyDown += delegate(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btnTimHocVien.PerformClick(); }
            };
            lbltxtHocVien.Text = "Chọn học viên (mã - họ tên - số điện thoại)";
            lblIntro.Text = "Chọn học viên và lớp học để đăng ký";
            txtSoDienThoai.ReadOnly = true;
            txtTrinhDo.ReadOnly = true;
            dtpNgayDangKy.Enabled = false;
            btnDangKy.Enabled = false;
            btnKiemTra.Enabled = false;
            Load += delegate
            {
                try { BTL_LTTQ_QLHTTTNN.Services.PhanQuyenService.YeuCauQuyen("DangKyLopCaNhan"); }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Không có quyền"); Close(); return; }
                bool studentMode = nguoiDungID.HasValue;
                txtTimHocVien.Visible = btnTimHocVien.Visible = lblTimHocVien.Visible = cboHocVien.Visible = !studentMode;
                pnlPhanTrang.Visible = true;
                txtHocVien.Visible = studentMode;
                HocVienData.Run(LoadData);
            };
            dgvLopHoc.SelectionChanged += delegate { ShowClass(); };
            btnLocLop.Click += delegate { HocVienData.Run(LoadClasses); };
            btnLamMoi.Click += delegate { HocVienData.Run(LoadData); };
            btnKiemTra.Click += delegate { HocVienData.Run(delegate { Register(false); }); };
            btnDangKy.Click += delegate { HocVienData.Run(delegate { Register(true); }); };
            btnDong.Click += delegate { Close(); };
        }
        private void Bind(ComboBox box, DataTable t, string display, string value, bool all)
        {
            if (all) { var row = t.NewRow(); row[value] = 0; row[display] = "Tất cả"; t.Rows.InsertAt(row, 0); }
            box.DisplayMember = display; box.ValueMember = value; box.DataSource = t;
        }
        private void LoadData()
        {
            LoadStudent();
            dtpNgayDangKy.Value = DateTime.Now;
            Bind(cboCoSo, HocVienData.Query("SELECT CoSoID,TenCoSo FROM CoSo WHERE IsDeleted=0 AND TrangThai=1"), "TenCoSo", "CoSoID", true);
            Bind(cboKhoaHoc, HocVienData.Query("SELECT KhoaHocID,TenKhoaHoc FROM KhoaHoc WHERE IsDeleted=0"), "TenKhoaHoc", "KhoaHocID", true);
            LoadClasses();
        }
        private int Selected(ComboBox box) { return box.SelectedValue is int ? (int)box.SelectedValue : 0; }
        private void LoadClasses()
        {
            dgvLopHoc.DataSource = HocVienData.Classes(Selected(cboCoSo), Selected(cboKhoaHoc)); ShowClass();
        }
        private void LoadStudent()
        {
            BTL_LTTQ_QLHTTTNN.Services.PhanQuyenService.YeuCauQuyen("DangKyLopCaNhan");
            int previous = hocVienID;
            if (!nguoiDungID.HasValue && cboHocVien.SelectedValue is int)
                previous = (int)cboHocVien.SelectedValue;
            hocVienID = 0;
            txtSoDienThoai.Clear(); txtTrinhDo.Clear();
            if (nguoiDungID.HasValue)
            {
                var student = HocVienData.OwnProfile(nguoiDungID);
                hocVienID = Convert.ToInt32(student["HocVienID"]);
                txtHocVien.Text = hocVienID + " - " + Convert.ToString(student["HoTen"]);
                txtSoDienThoai.Text = Convert.ToString(student["SoDienThoai"]);
                txtTrinhDo.Text = Convert.ToString(student["TrinhDoDauVao"]);
                return;
            }
            BTL_LTTQ_QLHTTTNN.Services.PhanQuyenService.YeuCauQuyen("QuanLyHocVien");
            if (previous <= 0) previous = HocVienDuocChon.GetValueOrDefault();
            var students = HocVienData.Query(@"SELECT HocVienID,HoTen,SoDienThoai,TrinhDoDauVao,
CONVERT(nvarchar(20),HocVienID)+N' - '+HoTen+N' - '+ISNULL(SoDienThoai,N'') AS HienThi
FROM HocVien WHERE IsDeleted=0 AND (@q=N'' OR CONVERT(nvarchar(20),HocVienID)=@q
OR CHARINDEX(@q,HoTen)>0 OR CHARINDEX(@q,ISNULL(SoDienThoai,N''))>0
OR CHARINDEX(@q,ISNULL(Email,N''))>0) ORDER BY HoTen,HocVienID",
                HocVienData.P("@q", txtTimHocVien.Text.Trim()));
            Bind(cboHocVien, students, "HienThi", "HocVienID", false);
            cboHocVien.SelectedIndex = -1;
            if (previous > 0) cboHocVien.SelectedValue = previous;
            ShowStudent();
            lblTimHocVien.Text = students.Rows.Count == 0 ? "Không tìm thấy học viên." :
                "Tìm thấy " + students.Rows.Count + " học viên. Chọn trong danh sách bên dưới.";
        }
        private void ShowStudent()
        {
            if (nguoiDungID.HasValue) { LoadStudent(); return; }
            hocVienID = 0;
            txtSoDienThoai.Clear(); txtTrinhDo.Clear();
            var view = cboHocVien.SelectedItem as DataRowView;
            if (view == null) return;
            hocVienID = Convert.ToInt32(view["HocVienID"]);
            txtSoDienThoai.Text = Convert.ToString(view["SoDienThoai"]);
            txtTrinhDo.Text = Convert.ToString(view["TrinhDoDauVao"]);
        }
        private void ShowClass()
        {
            var row = HocVienData.Row(dgvLopHoc);
            txtLopDaChon.Text = row == null ? "" : Convert.ToString(row["TenLop"]);
            txtHocPhiApDung.Text = row == null ? "" : Convert.ToDecimal(row["HocPhi"]).ToString("N0");
            txtChoConLai.Text = row == null ? "" : Convert.ToString(row["ChoConLai"]);
            btnDangKy.Enabled = row != null && hocVienID > 0; btnKiemTra.Enabled = btnDangKy.Enabled;
            lblKiemTra.Text = row == null ? "Không có lớp phù hợp." : "Nhấn Kiểm tra đăng ký để xác nhận học viên chưa đăng ký và lớp còn chỗ.";
        }
        private void Register(bool save)
        {
            BTL_LTTQ_QLHTTTNN.Services.PhanQuyenService.YeuCauQuyen("DangKyLopCaNhan");
            if (nguoiDungID.HasValue) LoadStudent(); else ShowStudent();
            ShowClass();
            int student = hocVienID; var row = HocVienData.Row(dgvLopHoc);
            if (student == 0 || row == null) throw new InvalidOperationException("Vui lòng chọn học viên và lớp học.");
            lblKiemTra.Text = "Đang kiểm tra đăng ký...";
            string studentName = nguoiDungID.HasValue ? txtHocVien.Text : cboHocVien.Text;
            if (save && MessageBox.Show("Đăng ký cho " + studentName + " vào lớp " + row["TenLop"] + " với học phí " + txtHocPhiApDung.Text + "đ?",
                "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) { lblKiemTra.Text = "Chưa đăng ký."; return; }
            try { HocVienData.Register(student, Convert.ToInt32(row["LopHocID"]), DateTime.Now, txtGhiChu.Text, Convert.ToDecimal(row["HocPhi"]), save); }
            catch { lblKiemTra.Text = "Chưa đăng ký. Xem thông báo lỗi và kiểm tra lại thông tin."; throw; }
            if (save) { MessageBox.Show("Đăng ký thành công."); txtGhiChu.Clear(); LoadClasses(); }
            lblKiemTra.Text = save ? "Đã lưu đăng ký." : "Hợp lệ: học viên chưa đăng ký lớp và lớp còn chỗ. Khi lưu sẽ kiểm tra lại.";
        }
    }
}
