using System;
using System.Data;
using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmHocVien : Form
    {
        private bool editing;
        private int? selectedId;
        public frmHocVien()
        {
            InitializeComponent();
            foreach(var grid in new[]{dgvHocVien,dgvtabLop,dgvtabKetQua,dgvtabHocPhi}) HocVienData.Grid(grid);
            cboLocTrangThai.Items.Clear(); cboLocTrangThai.Items.Add("Tất cả"); cboLocTrangThai.SelectedIndex=0;
            cboGioiTinh.Items.Clear(); cboGioiTinh.Items.AddRange(new object[]{"", "Nam", "Nữ", "Khác"});
            txtHoTen.MaxLength=100; txtSoDienThoai.MaxLength=20;txtEmail.MaxLength=100;
            txtTrinhDoDauVao.MaxLength=50;txtNhanXetDauVao.MaxLength=500;
            cboTrangThai.MaxLength=20;
            Load += delegate { HocVienData.Run(delegate { LoadStatuses(); LoadList(); }); };
            dgvHocVien.SelectionChanged += delegate { if(!editing) HocVienData.Run(ShowStudent); };
            btnTimKiem.Click += delegate { HocVienData.Run(LoadList); };
            btnLamMoi.Click += delegate { HocVienData.Run(delegate { txtTimKiem.Clear(); cboLocTrangThai.SelectedIndex=0; LoadStatuses();LoadList(); }); };
            txtTimKiem.KeyDown += delegate(object s,KeyEventArgs e) { if(e.KeyCode==Keys.Enter) {e.SuppressKeyPress=true;HocVienData.Run(LoadList);} };
            btnThem.Click += delegate { selectedId=null; ClearProfile(); SetEditing(true); txtHoTen.Focus(); };
            btnSua.Click += delegate { if(selectedId.HasValue) {SetEditing(true);txtHoTen.Focus();} };
            btnHuy.Click += delegate { SetEditing(false); HocVienData.Run(ShowStudent); };
            btnLuu.Click += delegate { HocVienData.Run(SaveStudent); };
            btnChiTiet.Click += delegate { HocVienData.Run(ShowStudent);tabHoSo.SelectedTab=tabThongTin; };
            btnDong.Click += delegate { Close(); };
            FormClosing += delegate(object s,FormClosingEventArgs e) { if(editing && MessageBox.Show("Bỏ thông tin chưa lưu và đóng?","Xác nhận",MessageBoxButtons.YesNo)==DialogResult.No)e.Cancel=true; };
            SetEditing(false);
        }
        private void LoadStatuses()
        {
            string current=cboLocTrangThai.Text;
            cboLocTrangThai.Items.Clear();cboLocTrangThai.Items.Add("Tất cả");cboTrangThai.Items.Clear();cboTrangThai.Items.Add("Đang học");
            foreach(DataRow r in HocVienData.Query("SELECT DISTINCT TrangThai FROM HocVien WHERE IsDeleted=0 ORDER BY TrangThai").Rows)
            {
                string s=Convert.ToString(r[0]);cboLocTrangThai.Items.Add(s);
                if(!cboTrangThai.Items.Contains(s))cboTrangThai.Items.Add(s);
            }
            cboLocTrangThai.SelectedItem=cboLocTrangThai.Items.Contains(current)?current:"Tất cả";
        }
        private void LoadList()
        {
            if(editing)return;
            dgvHocVien.DataSource=HocVienData.Students(txtTimKiem.Text.Trim(),cboLocTrangThai.Text);
            ShowStudent();
        }
        private void ClearProfile()
        {
            foreach(var t in new[]{txtHocVienID,txtHoTen,txtSoDienThoai,txtEmail,txtTrinhDoDauVao,txtDiemDauVao,txtNhanXetDauVao,txtTaiKhoan})t.Clear();
            dtpNgaySinh.Value=DateTime.Today;dtpNgaySinh.Checked=false;cboGioiTinh.SelectedIndex=0;cboTrangThai.Text="Đang học";
            dgvtabLop.DataSource=null;dgvtabKetQua.DataSource=null;dgvtabHocPhi.DataSource=null;
        }
        private void ShowStudent()
        {
            ClearProfile();selectedId=null;
            var row=HocVienData.Row(dgvHocVien);
            if(row!=null)
            {
                selectedId=Convert.ToInt32(row["HocVienID"]);txtHocVienID.Text=selectedId.ToString();txtHoTen.Text=Convert.ToString(row["HoTen"]);
                if(!row.IsNull("NgaySinh")){dtpNgaySinh.Value=Convert.ToDateTime(row["NgaySinh"]);dtpNgaySinh.Checked=true;}
                cboGioiTinh.Text=Convert.ToString(row["GioiTinh"]);txtSoDienThoai.Text=Convert.ToString(row["SoDienThoai"]);
                txtEmail.Text=Convert.ToString(row["Email"]);txtTrinhDoDauVao.Text=Convert.ToString(row["TrinhDoDauVao"]);
                txtDiemDauVao.Text=Convert.ToString(row["DiemDauVao"]);txtNhanXetDauVao.Text=Convert.ToString(row["NhanXetDauVao"]);
                txtTaiKhoan.Text=Convert.ToString(row["TenDangNhap"]);cboTrangThai.Text=Convert.ToString(row["TrangThai"]);
                var classes=HocVienData.Enrollments(selectedId.Value);
                dgvtabLop.DataSource=classes;dgvtabKetQua.DataSource=classes.Copy();dgvtabHocPhi.DataSource=HocVienData.Fees(selectedId.Value);
            }
            SetEditing(false);
        }
        private void SetEditing(bool value)
        {
            editing=value;
            foreach(var t in new[]{txtHoTen,txtSoDienThoai,txtEmail,txtTrinhDoDauVao,txtDiemDauVao,txtNhanXetDauVao})t.ReadOnly=!value;
            dtpNgaySinh.Enabled=value;cboGioiTinh.Enabled=value;cboTrangThai.Enabled=value;
            txtHocVienID.ReadOnly=true;txtTaiKhoan.ReadOnly=true;
            btnLuu.Enabled=value;btnHuy.Enabled=value;btnThem.Enabled=!value;
            btnSua.Enabled=!value && selectedId.HasValue;btnChiTiet.Enabled=btnSua.Enabled;
            dgvHocVien.Enabled=!value;btnTimKiem.Enabled=!value;btnLamMoi.Enabled=!value;cboLocTrangThai.Enabled=!value;txtTimKiem.Enabled=!value;
            if(value)tabHoSo.SelectedTab=tabThongTin;
        }
        private void SaveStudent()
        {
            if(string.IsNullOrWhiteSpace(txtHoTen.Text))throw new InvalidOperationException("Nhập họ tên học viên.");
            if(dtpNgaySinh.Checked && dtpNgaySinh.Value.Date>DateTime.Today)throw new InvalidOperationException("Ngày sinh không được ở tương lai.");
            string phone=txtSoDienThoai.Text.Trim(),email=txtEmail.Text.Trim();
            if(phone!="" && !Regex.IsMatch(phone,@"^\+?[0-9 ()\-]{7,20}$"))throw new InvalidOperationException("Số điện thoại không hợp lệ.");
            if(email!="") { try { if(new MailAddress(email).Address!=email)throw new FormatException(); }catch {throw new InvalidOperationException("Email không hợp lệ.");} }
            decimal? score=null;decimal parsed;
            if(txtDiemDauVao.Text.Trim()!="")
            {
                if(!decimal.TryParse(txtDiemDauVao.Text.Trim(),NumberStyles.AllowDecimalPoint,CultureInfo.CurrentCulture,out parsed) || parsed<0 || parsed>100 || decimal.Round(parsed,2)!=parsed)
                    throw new InvalidOperationException("Điểm đầu vào phải từ 0 đến 100, tối đa 2 chữ số thập phân.");
                score=parsed;
            }
            if(string.IsNullOrWhiteSpace(cboTrangThai.Text))throw new InvalidOperationException("Nhập trạng thái học viên.");
            int id=HocVienData.SaveStudent(selectedId,txtHoTen.Text.Trim(),dtpNgaySinh.Checked?(DateTime?)dtpNgaySinh.Value.Date:null,
                cboGioiTinh.Text,phone,email,txtTrinhDoDauVao.Text,score,txtNhanXetDauVao.Text,cboTrangThai.Text.Trim());
            SetEditing(false);
            MessageBox.Show("Đã lưu học viên.");
            txtTimKiem.Clear();cboLocTrangThai.SelectedItem="Tất cả";LoadStatuses();LoadList();
            foreach(DataGridViewRow r in dgvHocVien.Rows)
            {
                var v=r.DataBoundItem as DataRowView;
                if(v!=null && Convert.ToInt32(v["HocVienID"])==id){dgvHocVien.CurrentCell=r.Cells[0];break;}
            }
        }
    }
}
