using System;
using System.Data;
using System.Windows.Forms;
namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmDangKyHoc : Form
    {
        public frmDangKyHoc()
        {
            InitializeComponent();HocVienData.Grid(dgvLopHoc);txtGhiChu.MaxLength=500;
            cboHocVien.DropDownStyle=ComboBoxStyle.DropDownList;
            Load+=delegate {HocVienData.Run(LoadData);};
            cboHocVien.SelectedIndexChanged+=delegate {ShowStudent();lblKiemTra.Text="Nhấn Kiểm tra đăng ký để kiểm tra học viên đang chọn.";};
            dgvLopHoc.SelectionChanged+=delegate {ShowClass();};
            btnLocLop.Click+=delegate {HocVienData.Run(LoadClasses);};
            btnLamMoi.Click+=delegate {HocVienData.Run(LoadData);};
            btnKiemTra.Click+=delegate {HocVienData.Run(delegate {Register(false);});};
            btnDangKy.Click+=delegate {HocVienData.Run(delegate {Register(true);});};
            btnDong.Click+=delegate {Close();};
        }
        private void Bind(ComboBox box,DataTable t,string display,string value,bool all)
        {
            if(all){var row=t.NewRow();row[value]=0;row[display]="Tất cả";t.Rows.InsertAt(row,0);}
            box.DisplayMember=display;box.ValueMember=value;box.DataSource=t;
        }
        private void LoadData()
        {
            var students=HocVienData.Students("","Tất cả");students.Columns.Add("TenHienThi",typeof(string));
            foreach(DataRow row in students.Rows)row["TenHienThi"]=row["HocVienID"]+" - "+row["HoTen"];
            Bind(cboHocVien,students,"TenHienThi","HocVienID",false);
            Bind(cboCoSo,HocVienData.Query("SELECT CoSoID,TenCoSo FROM CoSo WHERE IsDeleted=0 AND TrangThai=1"),"TenCoSo","CoSoID",true);
            Bind(cboKhoaHoc,HocVienData.Query("SELECT KhoaHocID,TenKhoaHoc FROM KhoaHoc WHERE IsDeleted=0"),"TenKhoaHoc","KhoaHocID",true);
            ShowStudent();LoadClasses();
        }
        private int Selected(ComboBox box){return box.SelectedValue is int?(int)box.SelectedValue:0;}
        private void LoadClasses()
        {
            dgvLopHoc.DataSource=HocVienData.Classes(Selected(cboCoSo),Selected(cboKhoaHoc));ShowClass();
        }
        private void ShowStudent()
        {
            var row=cboHocVien.SelectedItem as DataRowView;
            txtSoDienThoai.Text=row==null?"":Convert.ToString(row["SoDienThoai"]);
            txtTrinhDo.Text=row==null?"":Convert.ToString(row["TrinhDoDauVao"]);
        }
        private void ShowClass()
        {
            var row=HocVienData.Row(dgvLopHoc);
            txtLopDaChon.Text=row==null?"":Convert.ToString(row["TenLop"]);
            txtHocPhiApDung.Text=row==null?"":Convert.ToDecimal(row["HocPhi"]).ToString("N0");
            txtChoConLai.Text=row==null?"":Convert.ToString(row["ChoConLai"]);
            btnDangKy.Enabled=row!=null;btnKiemTra.Enabled=row!=null;
            lblKiemTra.Text=row==null?"Không có lớp phù hợp.":"Nhấn Kiểm tra đăng ký để xem lớp còn chỗ và học viên có đăng ký trùng không.";
        }
        private void Register(bool save)
        {
            int student=Selected(cboHocVien);var row=HocVienData.Row(dgvLopHoc);
            if(student==0 || row==null)throw new InvalidOperationException("Chọn học viên và lớp học.");
            lblKiemTra.Text="Đang kiểm tra đăng ký...";
            if(save && MessageBox.Show("Đăng ký học viên vào lớp "+row["TenLop"]+" với học phí "+txtHocPhiApDung.Text+"đ?",
                "Xác nhận",MessageBoxButtons.YesNo)!=DialogResult.Yes){lblKiemTra.Text="Chưa đăng ký.";return;}
            try {HocVienData.Register(student,Convert.ToInt32(row["LopHocID"]),dtpNgayDangKy.Value,txtGhiChu.Text,Convert.ToDecimal(row["HocPhi"]),save);}
            catch {lblKiemTra.Text="Chưa đăng ký. Xem thông báo lỗi và kiểm tra lại thông tin.";throw;}
            if(save){MessageBox.Show("Đăng ký thành công.");txtGhiChu.Clear();LoadClasses();}
            lblKiemTra.Text=save?"Đã lưu đăng ký.":"Hợp lệ: học viên chưa đăng ký lớp và lớp còn chỗ. Khi lưu sẽ kiểm tra lại.";
        }
    }
}
