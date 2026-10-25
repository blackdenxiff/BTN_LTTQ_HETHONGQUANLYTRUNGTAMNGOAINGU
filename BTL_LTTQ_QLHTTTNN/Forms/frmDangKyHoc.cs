using System;
using System.Data;
using System.Windows.Forms;
namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmDangKyHoc : Form
    {
        private readonly int? nguoiDungID;
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
            });
            txtHocVien.ReadOnly = true;
            txtSoDienThoai.ReadOnly = true;
            txtTrinhDo.ReadOnly = true;
            dtpNgayDangKy.Enabled = false;
            btnDangKy.Enabled = false;
            btnKiemTra.Enabled = false;
            Load += delegate { HocVienData.Run(LoadData); };
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
            hocVienID = 0;
            btnDangKy.Enabled = false;
            btnKiemTra.Enabled = false;
            txtHocVien.Clear();
            txtSoDienThoai.Clear();
            txtTrinhDo.Clear();
            DataRow student = HocVienData.OwnProfile(nguoiDungID);
            hocVienID = Convert.ToInt32(student["HocVienID"]);
            txtHocVien.Text = hocVienID + " - " + Convert.ToString(student["HoTen"]);
            txtSoDienThoai.Text = Convert.ToString(student["SoDienThoai"]);
            txtTrinhDo.Text = Convert.ToString(student["TrinhDoDauVao"]);
        }
        private void ShowClass()
        {
            var row = HocVienData.Row(dgvLopHoc);
            txtLopDaChon.Text = row == null ? "" : Convert.ToString(row["TenLop"]);
            txtHocPhiApDung.Text = row == null ? "" : Convert.ToDecimal(row["HocPhi"]).ToString("N0");
            txtChoConLai.Text = row == null ? "" : Convert.ToString(row["ChoConLai"]);
            btnDangKy.Enabled = row != null && hocVienID > 0; btnKiemTra.Enabled = btnDangKy.Enabled;
            lblKiemTra.Text = row == null ? "Không có lớp phù hợp." : "Nhấn Kiểm tra đăng ký để xem bạn đã đăng ký lớp này chưa và lớp còn chỗ không.";
        }
        private void Register(bool save)
        {
            // Lay lai hoc vien tu tai khoan, khong lay ID tu o nhap tren giao dien.
            LoadStudent();
            ShowClass();
            int student = hocVienID; var row = HocVienData.Row(dgvLopHoc);
            if (student == 0 || row == null) throw new InvalidOperationException("Vui lòng chọn lớp học.");
            lblKiemTra.Text = "Đang kiểm tra đăng ký...";
            if (save && MessageBox.Show("Bạn muốn đăng ký lớp " + row["TenLop"] + " với học phí " + txtHocPhiApDung.Text + "đ?",
                "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes) { lblKiemTra.Text = "Chưa đăng ký."; return; }
            try { HocVienData.Register(student, Convert.ToInt32(row["LopHocID"]), DateTime.Now, txtGhiChu.Text, Convert.ToDecimal(row["HocPhi"]), save); }
            catch { lblKiemTra.Text = "Chưa đăng ký. Xem thông báo lỗi và kiểm tra lại thông tin."; throw; }
            if (save) { MessageBox.Show("Đăng ký thành công."); txtGhiChu.Clear(); LoadClasses(); }
            lblKiemTra.Text = save ? "Đã lưu đăng ký." : "Hợp lệ: bạn chưa đăng ký lớp và lớp còn chỗ. Khi lưu sẽ kiểm tra lại.";
        }
    }
}
