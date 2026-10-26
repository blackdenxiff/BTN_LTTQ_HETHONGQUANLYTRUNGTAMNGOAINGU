namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmDangKyHoc
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblIntro = new System.Windows.Forms.Label();
            this.lbltxtHocVien = new System.Windows.Forms.Label();
            this.txtHocVien = new System.Windows.Forms.TextBox();
            this.lbltxtSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lbltxtTrinhDo = new System.Windows.Forms.Label();
            this.txtTrinhDo = new System.Windows.Forms.TextBox();
            this.lblcboCoSo = new System.Windows.Forms.Label();
            this.cboCoSo = new System.Windows.Forms.ComboBox();
            this.lblcboKhoaHoc = new System.Windows.Forms.Label();
            this.cboKhoaHoc = new System.Windows.Forms.ComboBox();
            this.btnLocLop = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvLopHoc = new System.Windows.Forms.DataGridView();
            this.dgvLopHocCol0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLopHocCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLopHocCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLopHocCol3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLopHocCol4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLopHocCol5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLopHocCol6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLopHocCol7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLopHocCol8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbltxtLopDaChon = new System.Windows.Forms.Label();
            this.txtLopDaChon = new System.Windows.Forms.TextBox();
            this.lbldtpNgayDangKy = new System.Windows.Forms.Label();
            this.dtpNgayDangKy = new System.Windows.Forms.DateTimePicker();
            this.lbltxtHocPhiApDung = new System.Windows.Forms.Label();
            this.txtHocPhiApDung = new System.Windows.Forms.TextBox();
            this.lbltxtChoConLai = new System.Windows.Forms.Label();
            this.txtChoConLai = new System.Windows.Forms.TextBox();
            this.lbltxtGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblKiemTra = new System.Windows.Forms.Label();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.txtTimHocVien = new System.Windows.Forms.TextBox();
            this.btnTimHocVien = new System.Windows.Forms.Button();
            this.lblTimHocVien = new System.Windows.Forms.Label();
            this.cboHocVien = new System.Windows.Forms.ComboBox();
            this.pnlPhanTrang = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTrangTruoc = new System.Windows.Forms.Button();
            this.lblTrang = new System.Windows.Forms.Label();
            this.btnTrangSau = new System.Windows.Forms.Button();
            this.cboSoDong = new System.Windows.Forms.ComboBox();
            this.lblSoDong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).BeginInit();
            this.pnlPhanTrang.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(63)))), ((int)(((byte)(110)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1000, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG KÝ HỌC";
            // 
            // lblIntro
            // 
            this.lblIntro.Location = new System.Drawing.Point(26, 62);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(1000, 24);
            this.lblIntro.TabIndex = 1;
            this.lblIntro.Text = "Admin tìm học viên, chọn lớp và xác nhận đăng ký";
            // 
            // lbltxtHocVien
            // 
            this.lbltxtHocVien.Location = new System.Drawing.Point(24, 165);
            this.lbltxtHocVien.Name = "lbltxtHocVien";
            this.lbltxtHocVien.Size = new System.Drawing.Size(530, 24);
            this.lbltxtHocVien.TabIndex = 2;
            this.lbltxtHocVien.Text = "Chọn học viên (mã - tên - số điện thoại)";
            // 
            // txtHocVien
            // 
            this.txtHocVien.Location = new System.Drawing.Point(30, 191);
            this.txtHocVien.Name = "txtHocVien";
            this.txtHocVien.ReadOnly = true;
            this.txtHocVien.Size = new System.Drawing.Size(530, 30);
            this.txtHocVien.TabIndex = 3;
            this.txtHocVien.Visible = false;
            // 
            // lbltxtSoDienThoai
            // 
            this.lbltxtSoDienThoai.Location = new System.Drawing.Point(578, 165);
            this.lbltxtSoDienThoai.Name = "lbltxtSoDienThoai";
            this.lbltxtSoDienThoai.Size = new System.Drawing.Size(275, 24);
            this.lbltxtSoDienThoai.TabIndex = 4;
            this.lbltxtSoDienThoai.Text = "Số điện thoại";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(578, 191);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.ReadOnly = true;
            this.txtSoDienThoai.Size = new System.Drawing.Size(275, 30);
            this.txtSoDienThoai.TabIndex = 5;
            // 
            // lbltxtTrinhDo
            // 
            this.lbltxtTrinhDo.Location = new System.Drawing.Point(877, 165);
            this.lbltxtTrinhDo.Name = "lbltxtTrinhDo";
            this.lbltxtTrinhDo.Size = new System.Drawing.Size(279, 24);
            this.lbltxtTrinhDo.TabIndex = 6;
            this.lbltxtTrinhDo.Text = "Trình độ đầu vào";
            // 
            // txtTrinhDo
            // 
            this.txtTrinhDo.Location = new System.Drawing.Point(877, 191);
            this.txtTrinhDo.Name = "txtTrinhDo";
            this.txtTrinhDo.ReadOnly = true;
            this.txtTrinhDo.Size = new System.Drawing.Size(279, 30);
            this.txtTrinhDo.TabIndex = 7;
            // 
            // lblcboCoSo
            // 
            this.lblcboCoSo.Location = new System.Drawing.Point(24, 245);
            this.lblcboCoSo.Name = "lblcboCoSo";
            this.lblcboCoSo.Size = new System.Drawing.Size(300, 24);
            this.lblcboCoSo.TabIndex = 8;
            this.lblcboCoSo.Text = "Cơ sở";
            // 
            // cboCoSo
            // 
            this.cboCoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoSo.Location = new System.Drawing.Point(24, 271);
            this.cboCoSo.Name = "cboCoSo";
            this.cboCoSo.Size = new System.Drawing.Size(300, 31);
            this.cboCoSo.TabIndex = 9;
            // 
            // lblcboKhoaHoc
            // 
            this.lblcboKhoaHoc.Location = new System.Drawing.Point(344, 245);
            this.lblcboKhoaHoc.Name = "lblcboKhoaHoc";
            this.lblcboKhoaHoc.Size = new System.Drawing.Size(430, 24);
            this.lblcboKhoaHoc.TabIndex = 10;
            this.lblcboKhoaHoc.Text = "Khóa học";
            // 
            // cboKhoaHoc
            // 
            this.cboKhoaHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaHoc.Location = new System.Drawing.Point(344, 271);
            this.cboKhoaHoc.Name = "cboKhoaHoc";
            this.cboKhoaHoc.Size = new System.Drawing.Size(430, 31);
            this.cboKhoaHoc.TabIndex = 11;
            // 
            // btnLocLop
            // 
            this.btnLocLop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.btnLocLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocLop.Location = new System.Drawing.Point(796, 269);
            this.btnLocLop.Name = "btnLocLop";
            this.btnLocLop.Size = new System.Drawing.Size(160, 36);
            this.btnLocLop.TabIndex = 12;
            this.btnLocLop.Text = "Lọc lớp";
            this.btnLocLop.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Location = new System.Drawing.Point(976, 269);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(180, 36);
            this.btnLamMoi.TabIndex = 13;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // dgvLopHoc
            // 
            this.dgvLopHoc.AllowUserToAddRows = false;
            this.dgvLopHoc.AllowUserToDeleteRows = false;
            this.dgvLopHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLopHoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvLopHoc.ColumnHeadersHeight = 29;
            this.dgvLopHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvLopHocCol0,
            this.dgvLopHocCol1,
            this.dgvLopHocCol2,
            this.dgvLopHocCol3,
            this.dgvLopHocCol4,
            this.dgvLopHocCol5,
            this.dgvLopHocCol6,
            this.dgvLopHocCol7,
            this.dgvLopHocCol8});
            this.dgvLopHoc.Location = new System.Drawing.Point(24, 325);
            this.dgvLopHoc.MultiSelect = false;
            this.dgvLopHoc.Name = "dgvLopHoc";
            this.dgvLopHoc.ReadOnly = true;
            this.dgvLopHoc.RowHeadersVisible = false;
            this.dgvLopHoc.RowHeadersWidth = 51;
            this.dgvLopHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLopHoc.Size = new System.Drawing.Size(1132, 172);
            this.dgvLopHoc.TabIndex = 14;
            // 
            // dgvLopHocCol0
            // 
            this.dgvLopHocCol0.DataPropertyName = "TenLop";
            this.dgvLopHocCol0.HeaderText = "Lớp";
            this.dgvLopHocCol0.MinimumWidth = 6;
            this.dgvLopHocCol0.Name = "dgvLopHocCol0";
            this.dgvLopHocCol0.ReadOnly = true;
            // 
            // dgvLopHocCol1
            // 
            this.dgvLopHocCol1.DataPropertyName = "TenKhoaHoc";
            this.dgvLopHocCol1.HeaderText = "Khóa học";
            this.dgvLopHocCol1.MinimumWidth = 6;
            this.dgvLopHocCol1.Name = "dgvLopHocCol1";
            this.dgvLopHocCol1.ReadOnly = true;
            // 
            // dgvLopHocCol2
            // 
            this.dgvLopHocCol2.DataPropertyName = "TenCoSo";
            this.dgvLopHocCol2.HeaderText = "Cơ sở";
            this.dgvLopHocCol2.MinimumWidth = 6;
            this.dgvLopHocCol2.Name = "dgvLopHocCol2";
            this.dgvLopHocCol2.ReadOnly = true;
            // 
            // dgvLopHocCol3
            // 
            this.dgvLopHocCol3.DataPropertyName = "NgayBatDau";
            this.dgvLopHocCol3.HeaderText = "Bắt đầu";
            this.dgvLopHocCol3.MinimumWidth = 6;
            this.dgvLopHocCol3.Name = "dgvLopHocCol3";
            this.dgvLopHocCol3.ReadOnly = true;
            // 
            // dgvLopHocCol4
            // 
            this.dgvLopHocCol4.DataPropertyName = "NgayKetThuc";
            this.dgvLopHocCol4.HeaderText = "Kết thúc";
            this.dgvLopHocCol4.MinimumWidth = 6;
            this.dgvLopHocCol4.Name = "dgvLopHocCol4";
            this.dgvLopHocCol4.ReadOnly = true;
            // 
            // dgvLopHocCol5
            // 
            this.dgvLopHocCol5.DataPropertyName = "SiSoHienTai";
            this.dgvLopHocCol5.HeaderText = "Sĩ số";
            this.dgvLopHocCol5.MinimumWidth = 6;
            this.dgvLopHocCol5.Name = "dgvLopHocCol5";
            this.dgvLopHocCol5.ReadOnly = true;
            // 
            // dgvLopHocCol6
            // 
            this.dgvLopHocCol6.DataPropertyName = "SiSoToiDa";
            this.dgvLopHocCol6.HeaderText = "Tối đa";
            this.dgvLopHocCol6.MinimumWidth = 6;
            this.dgvLopHocCol6.Name = "dgvLopHocCol6";
            this.dgvLopHocCol6.ReadOnly = true;
            // 
            // dgvLopHocCol7
            // 
            this.dgvLopHocCol7.DataPropertyName = "ChoConLai";
            this.dgvLopHocCol7.HeaderText = "Còn chỗ";
            this.dgvLopHocCol7.MinimumWidth = 6;
            this.dgvLopHocCol7.Name = "dgvLopHocCol7";
            this.dgvLopHocCol7.ReadOnly = true;
            // 
            // dgvLopHocCol8
            // 
            this.dgvLopHocCol8.DataPropertyName = "TrangThai";
            this.dgvLopHocCol8.HeaderText = "Trạng thái";
            this.dgvLopHocCol8.MinimumWidth = 6;
            this.dgvLopHocCol8.Name = "dgvLopHocCol8";
            this.dgvLopHocCol8.ReadOnly = true;
            // 
            // lbltxtLopDaChon
            // 
            this.lbltxtLopDaChon.Location = new System.Drawing.Point(24, 559);
            this.lbltxtLopDaChon.Name = "lbltxtLopDaChon";
            this.lbltxtLopDaChon.Size = new System.Drawing.Size(345, 24);
            this.lbltxtLopDaChon.TabIndex = 15;
            this.lbltxtLopDaChon.Text = "Lớp đã chọn";
            // 
            // txtLopDaChon
            // 
            this.txtLopDaChon.Location = new System.Drawing.Point(24, 585);
            this.txtLopDaChon.Name = "txtLopDaChon";
            this.txtLopDaChon.ReadOnly = true;
            this.txtLopDaChon.Size = new System.Drawing.Size(345, 30);
            this.txtLopDaChon.TabIndex = 16;
            // 
            // lbldtpNgayDangKy
            // 
            this.lbldtpNgayDangKy.Location = new System.Drawing.Point(393, 559);
            this.lbldtpNgayDangKy.Name = "lbldtpNgayDangKy";
            this.lbldtpNgayDangKy.Size = new System.Drawing.Size(220, 24);
            this.lbldtpNgayDangKy.TabIndex = 17;
            this.lbldtpNgayDangKy.Text = "Ngày đăng ký";
            // 
            // dtpNgayDangKy
            // 
            this.dtpNgayDangKy.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayDangKy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayDangKy.Location = new System.Drawing.Point(393, 585);
            this.dtpNgayDangKy.Name = "dtpNgayDangKy";
            this.dtpNgayDangKy.Size = new System.Drawing.Size(220, 30);
            this.dtpNgayDangKy.TabIndex = 18;
            // 
            // lbltxtHocPhiApDung
            // 
            this.lbltxtHocPhiApDung.Location = new System.Drawing.Point(637, 559);
            this.lbltxtHocPhiApDung.Name = "lbltxtHocPhiApDung";
            this.lbltxtHocPhiApDung.Size = new System.Drawing.Size(275, 24);
            this.lbltxtHocPhiApDung.TabIndex = 19;
            this.lbltxtHocPhiApDung.Text = "Học phí áp dụng (VNĐ)";
            // 
            // txtHocPhiApDung
            // 
            this.txtHocPhiApDung.Location = new System.Drawing.Point(637, 585);
            this.txtHocPhiApDung.Name = "txtHocPhiApDung";
            this.txtHocPhiApDung.ReadOnly = true;
            this.txtHocPhiApDung.Size = new System.Drawing.Size(275, 30);
            this.txtHocPhiApDung.TabIndex = 20;
            // 
            // lbltxtChoConLai
            // 
            this.lbltxtChoConLai.Location = new System.Drawing.Point(936, 559);
            this.lbltxtChoConLai.Name = "lbltxtChoConLai";
            this.lbltxtChoConLai.Size = new System.Drawing.Size(220, 24);
            this.lbltxtChoConLai.TabIndex = 21;
            this.lbltxtChoConLai.Text = "Chỗ còn lại";
            // 
            // txtChoConLai
            // 
            this.txtChoConLai.Location = new System.Drawing.Point(936, 585);
            this.txtChoConLai.Name = "txtChoConLai";
            this.txtChoConLai.ReadOnly = true;
            this.txtChoConLai.Size = new System.Drawing.Size(220, 30);
            this.txtChoConLai.TabIndex = 22;
            // 
            // lbltxtGhiChu
            // 
            this.lbltxtGhiChu.Location = new System.Drawing.Point(24, 635);
            this.lbltxtGhiChu.Name = "lbltxtGhiChu";
            this.lbltxtGhiChu.Size = new System.Drawing.Size(1132, 24);
            this.lbltxtGhiChu.TabIndex = 23;
            this.lbltxtGhiChu.Text = "Ghi chú đăng ký";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(24, 661);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(1132, 30);
            this.txtGhiChu.TabIndex = 24;
            // 
            // lblKiemTra
            // 
            this.lblKiemTra.Location = new System.Drawing.Point(24, 713);
            this.lblKiemTra.Name = "lblKiemTra";
            this.lblKiemTra.Size = new System.Drawing.Size(1132, 24);
            this.lblKiemTra.TabIndex = 25;
            this.lblKiemTra.Text = "Chưa chọn lớp. Chọn lớp để kiểm tra đăng ký trùng và chỗ còn lại.";
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.btnKiemTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKiemTra.Location = new System.Drawing.Point(596, 769);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(180, 36);
            this.btnKiemTra.TabIndex = 26;
            this.btnKiemTra.Text = "Kiểm tra đăng ký";
            this.btnKiemTra.UseVisualStyleBackColor = false;
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Location = new System.Drawing.Point(796, 769);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(180, 36);
            this.btnDangKy.TabIndex = 27;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Location = new System.Drawing.Point(996, 769);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(160, 36);
            this.btnDong.TabIndex = 28;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // txtTimHocVien
            // 
            this.txtTimHocVien.Location = new System.Drawing.Point(30, 98);
            this.txtTimHocVien.Name = "txtTimHocVien";
            this.txtTimHocVien.Size = new System.Drawing.Size(530, 30);
            this.txtTimHocVien.TabIndex = 29;
            // 
            // btnTimHocVien
            // 
            this.btnTimHocVien.Location = new System.Drawing.Point(578, 96);
            this.btnTimHocVien.Name = "btnTimHocVien";
            this.btnTimHocVien.Size = new System.Drawing.Size(140, 30);
            this.btnTimHocVien.TabIndex = 30;
            this.btnTimHocVien.Text = "Tìm học viên";
            // 
            // lblTimHocVien
            // 
            this.lblTimHocVien.Location = new System.Drawing.Point(30, 130);
            this.lblTimHocVien.Name = "lblTimHocVien";
            this.lblTimHocVien.Size = new System.Drawing.Size(1100, 24);
            this.lblTimHocVien.TabIndex = 31;
            this.lblTimHocVien.Text = "Nhập mã, họ tên, số điện thoại hoặc email rồi nhấn Tìm học viên.";
            // 
            // cboHocVien
            // 
            this.cboHocVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocVien.Location = new System.Drawing.Point(30, 191);
            this.cboHocVien.Name = "cboHocVien";
            this.cboHocVien.Size = new System.Drawing.Size(530, 31);
            this.cboHocVien.TabIndex = 32;
            // 
            // pnlPhanTrang
            // 
            this.pnlPhanTrang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(248)))));
            this.pnlPhanTrang.Controls.Add(this.btnTrangTruoc);
            this.pnlPhanTrang.Controls.Add(this.lblTrang);
            this.pnlPhanTrang.Controls.Add(this.btnTrangSau);
            this.pnlPhanTrang.Controls.Add(this.cboSoDong);
            this.pnlPhanTrang.Controls.Add(this.lblSoDong);
            this.pnlPhanTrang.Location = new System.Drawing.Point(24, 497);
            this.pnlPhanTrang.Name = "pnlPhanTrang";
            this.pnlPhanTrang.Padding = new System.Windows.Forms.Padding(4);
            this.pnlPhanTrang.Size = new System.Drawing.Size(1132, 42);
            this.pnlPhanTrang.TabIndex = 33;
            this.pnlPhanTrang.WrapContents = false;
            // 
            // btnTrangTruoc
            // 
            this.btnTrangTruoc.Location = new System.Drawing.Point(7, 7);
            this.btnTrangTruoc.Name = "btnTrangTruoc";
            this.btnTrangTruoc.Size = new System.Drawing.Size(80, 30);
            this.btnTrangTruoc.TabIndex = 0;
            this.btnTrangTruoc.Text = "‹ Trước";
            // 
            // lblTrang
            // 
            this.lblTrang.Location = new System.Drawing.Point(93, 4);
            this.lblTrang.Name = "lblTrang";
            this.lblTrang.Size = new System.Drawing.Size(190, 30);
            this.lblTrang.TabIndex = 1;
            this.lblTrang.Text = "Trang 0/0 • 0 dòng";
            // 
            // btnTrangSau
            // 
            this.btnTrangSau.Location = new System.Drawing.Point(289, 7);
            this.btnTrangSau.Name = "btnTrangSau";
            this.btnTrangSau.Size = new System.Drawing.Size(80, 30);
            this.btnTrangSau.TabIndex = 2;
            this.btnTrangSau.Text = "Sau ›";
            // 
            // cboSoDong
            // 
            this.cboSoDong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSoDong.Items.AddRange(new object[] {
            10,
            20,
            50});
            this.cboSoDong.Location = new System.Drawing.Point(375, 7);
            this.cboSoDong.Name = "cboSoDong";
            this.cboSoDong.Size = new System.Drawing.Size(60, 31);
            this.cboSoDong.TabIndex = 3;
            // 
            // lblSoDong
            // 
            this.lblSoDong.Location = new System.Drawing.Point(441, 4);
            this.lblSoDong.Name = "lblSoDong";
            this.lblSoDong.Size = new System.Drawing.Size(90, 30);
            this.lblSoDong.TabIndex = 4;
            this.lblSoDong.Text = "dòng/trang";
            // 
            // frmDangKyHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1180, 825);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.lbltxtHocVien);
            this.Controls.Add(this.txtHocVien);
            this.Controls.Add(this.lbltxtSoDienThoai);
            this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.lbltxtTrinhDo);
            this.Controls.Add(this.txtTrinhDo);
            this.Controls.Add(this.lblcboCoSo);
            this.Controls.Add(this.cboCoSo);
            this.Controls.Add(this.lblcboKhoaHoc);
            this.Controls.Add(this.cboKhoaHoc);
            this.Controls.Add(this.btnLocLop);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.dgvLopHoc);
            this.Controls.Add(this.lbltxtLopDaChon);
            this.Controls.Add(this.txtLopDaChon);
            this.Controls.Add(this.lbldtpNgayDangKy);
            this.Controls.Add(this.dtpNgayDangKy);
            this.Controls.Add(this.lbltxtHocPhiApDung);
            this.Controls.Add(this.txtHocPhiApDung);
            this.Controls.Add(this.lbltxtChoConLai);
            this.Controls.Add(this.txtChoConLai);
            this.Controls.Add(this.lbltxtGhiChu);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblKiemTra);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.txtTimHocVien);
            this.Controls.Add(this.btnTimHocVien);
            this.Controls.Add(this.lblTimHocVien);
            this.Controls.Add(this.cboHocVien);
            this.Controls.Add(this.pnlPhanTrang);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1196, 864);
            this.Name = "frmDangKyHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký học";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).EndInit();
            this.pnlPhanTrang.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lbltxtHocVien;
        private System.Windows.Forms.TextBox txtHocVien;
        private System.Windows.Forms.Label lbltxtSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lbltxtTrinhDo;
        private System.Windows.Forms.TextBox txtTrinhDo;
        private System.Windows.Forms.Label lblcboCoSo;
        private System.Windows.Forms.ComboBox cboCoSo;
        private System.Windows.Forms.Label lblcboKhoaHoc;
        private System.Windows.Forms.ComboBox cboKhoaHoc;
        private System.Windows.Forms.Button btnLocLop;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvLopHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocCol0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocCol4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocCol5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocCol6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocCol7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocCol8;
        private System.Windows.Forms.Label lbltxtLopDaChon;
        private System.Windows.Forms.TextBox txtLopDaChon;
        private System.Windows.Forms.Label lbldtpNgayDangKy;
        private System.Windows.Forms.DateTimePicker dtpNgayDangKy;
        private System.Windows.Forms.Label lbltxtHocPhiApDung;
        private System.Windows.Forms.TextBox txtHocPhiApDung;
        private System.Windows.Forms.Label lbltxtChoConLai;
        private System.Windows.Forms.TextBox txtChoConLai;
        private System.Windows.Forms.Label lbltxtGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblKiemTra;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TextBox txtTimHocVien;
        private System.Windows.Forms.Button btnTimHocVien;
        private System.Windows.Forms.Label lblTimHocVien;
        private System.Windows.Forms.ComboBox cboHocVien;
        private System.Windows.Forms.FlowLayoutPanel pnlPhanTrang;
        private System.Windows.Forms.Button btnTrangTruoc;
        private System.Windows.Forms.Button btnTrangSau;
        private System.Windows.Forms.Label lblTrang;
        private System.Windows.Forms.ComboBox cboSoDong;
        private System.Windows.Forms.Label lblSoDong;
    }
}
