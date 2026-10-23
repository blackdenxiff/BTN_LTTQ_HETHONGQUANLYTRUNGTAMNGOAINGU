namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmMainHocVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTenHeThong = new System.Windows.Forms.Label();
            this.lblNguoiDangNhap = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnHocPhi = new System.Windows.Forms.Button();
            this.btnKetQua = new System.Windows.Forms.Button();
            this.btnLopHoc = new System.Windows.Forms.Button();
            this.btnThongTin = new System.Windows.Forms.Button();
            this.pnlNoiDung = new System.Windows.Forms.Panel();
            this.tabHoSo = new System.Windows.Forms.TabControl();
            this.tabThongTin = new System.Windows.Forms.TabPage();
            this.tblThongTin = new System.Windows.Forms.TableLayoutPanel();
            this.lblHocVienID = new System.Windows.Forms.Label();
            this.txtHocVienID = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.txtNgaySinh = new System.Windows.Forms.TextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.txtGioiTinh = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTrinhDoDauVao = new System.Windows.Forms.Label();
            this.txtTrinhDoDauVao = new System.Windows.Forms.TextBox();
            this.lblDiemDauVao = new System.Windows.Forms.Label();
            this.txtDiemDauVao = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.lblNhanXetDauVao = new System.Windows.Forms.Label();
            this.txtNhanXetDauVao = new System.Windows.Forms.TextBox();
            this.tabLopHoc = new System.Windows.Forms.TabPage();
            this.dgvLopHoc = new System.Windows.Forms.DataGridView();
            this.tabKetQua = new System.Windows.Forms.TabPage();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.tabHocPhi = new System.Windows.Forms.TabPage();
            this.dgvHocPhi = new System.Windows.Forms.DataGridView();
            this.lblTieuDeTrang = new System.Windows.Forms.Label();
            this.stsTrangThai = new System.Windows.Forms.StatusStrip();
            this.tslblVaiTro = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlHeader.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlNoiDung.SuspendLayout();
            this.tabHoSo.SuspendLayout();
            this.tabThongTin.SuspendLayout();
            this.tblThongTin.SuspendLayout();
            this.tabLopHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).BeginInit();
            this.tabKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.tabHocPhi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocPhi)).BeginInit();
            this.stsTrangThai.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))));
            this.pnlHeader.Controls.Add(this.lblTenHeThong);
            this.pnlHeader.Controls.Add(this.lblNguoiDangNhap);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 65);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblTenHeThong
            // 
            this.lblTenHeThong.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTenHeThong.ForeColor = System.Drawing.Color.White;
            this.lblTenHeThong.Location = new System.Drawing.Point(20, 18);
            this.lblTenHeThong.Name = "lblTenHeThong";
            this.lblTenHeThong.Size = new System.Drawing.Size(650, 30);
            this.lblTenHeThong.TabIndex = 0;
            this.lblTenHeThong.Text = "QUẢN LÝ TRUNG TÂM NGOẠI NGỮ";
            // 
            // lblNguoiDangNhap
            // 
            this.lblNguoiDangNhap.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblNguoiDangNhap.ForeColor = System.Drawing.Color.White;
            this.lblNguoiDangNhap.Location = new System.Drawing.Point(900, 0);
            this.lblNguoiDangNhap.Name = "lblNguoiDangNhap";
            this.lblNguoiDangNhap.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblNguoiDangNhap.Size = new System.Drawing.Size(300, 65);
            this.lblNguoiDangNhap.TabIndex = 1;
            this.lblNguoiDangNhap.Text = "Học viên: Chưa đăng nhập";
            this.lblNguoiDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.pnlMenu.Controls.Add(this.btnHocPhi);
            this.pnlMenu.Controls.Add(this.btnKetQua);
            this.pnlMenu.Controls.Add(this.btnLopHoc);
            this.pnlMenu.Controls.Add(this.btnThongTin);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 65);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(12, 20, 12, 12);
            this.pnlMenu.Size = new System.Drawing.Size(220, 673);
            this.pnlMenu.TabIndex = 1;
            // 
            // btnHocPhi
            // 
            this.btnHocPhi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.btnHocPhi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHocPhi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocPhi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))));
            this.btnHocPhi.Location = new System.Drawing.Point(12, 176);
            this.btnHocPhi.Name = "btnHocPhi";
            this.btnHocPhi.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnHocPhi.Size = new System.Drawing.Size(196, 52);
            this.btnHocPhi.TabIndex = 0;
            this.btnHocPhi.Text = "Tình trạng học phí";
            this.btnHocPhi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhi.UseVisualStyleBackColor = false;
            // 
            // btnKetQua
            // 
            this.btnKetQua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.btnKetQua.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKetQua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKetQua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))));
            this.btnKetQua.Location = new System.Drawing.Point(12, 124);
            this.btnKetQua.Name = "btnKetQua";
            this.btnKetQua.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnKetQua.Size = new System.Drawing.Size(196, 52);
            this.btnKetQua.TabIndex = 1;
            this.btnKetQua.Text = "Kết quả học tập";
            this.btnKetQua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKetQua.UseVisualStyleBackColor = false;
            // 
            // btnLopHoc
            // 
            this.btnLopHoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.btnLopHoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLopHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLopHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))));
            this.btnLopHoc.Location = new System.Drawing.Point(12, 72);
            this.btnLopHoc.Name = "btnLopHoc";
            this.btnLopHoc.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLopHoc.Size = new System.Drawing.Size(196, 52);
            this.btnLopHoc.TabIndex = 2;
            this.btnLopHoc.Text = "Lớp đã đăng ký";
            this.btnLopHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLopHoc.UseVisualStyleBackColor = false;
            // 
            // btnThongTin
            // 
            this.btnThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.btnThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))));
            this.btnThongTin.Location = new System.Drawing.Point(12, 20);
            this.btnThongTin.Name = "btnThongTin";
            this.btnThongTin.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnThongTin.Size = new System.Drawing.Size(196, 52);
            this.btnThongTin.TabIndex = 3;
            this.btnThongTin.Text = "Thông tin cá nhân";
            this.btnThongTin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongTin.UseVisualStyleBackColor = false;
            // 
            // pnlNoiDung
            // 
            this.pnlNoiDung.BackColor = System.Drawing.Color.White;
            this.pnlNoiDung.Controls.Add(this.tabHoSo);
            this.pnlNoiDung.Controls.Add(this.lblTieuDeTrang);
            this.pnlNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoiDung.Location = new System.Drawing.Point(220, 65);
            this.pnlNoiDung.Name = "pnlNoiDung";
            this.pnlNoiDung.Padding = new System.Windows.Forms.Padding(20);
            this.pnlNoiDung.Size = new System.Drawing.Size(980, 673);
            this.pnlNoiDung.TabIndex = 0;
            // 
            // tabHoSo
            // 
            this.tabHoSo.Controls.Add(this.tabThongTin);
            this.tabHoSo.Controls.Add(this.tabLopHoc);
            this.tabHoSo.Controls.Add(this.tabKetQua);
            this.tabHoSo.Controls.Add(this.tabHocPhi);
            this.tabHoSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHoSo.Location = new System.Drawing.Point(20, 68);
            this.tabHoSo.Name = "tabHoSo";
            this.tabHoSo.SelectedIndex = 0;
            this.tabHoSo.Size = new System.Drawing.Size(940, 585);
            this.tabHoSo.TabIndex = 0;
            // 
            // tabThongTin
            // 
            this.tabThongTin.AutoScroll = true;
            this.tabThongTin.Controls.Add(this.tblThongTin);
            this.tabThongTin.Location = new System.Drawing.Point(4, 26);
            this.tabThongTin.Name = "tabThongTin";
            this.tabThongTin.Padding = new System.Windows.Forms.Padding(16);
            this.tabThongTin.Size = new System.Drawing.Size(932, 555);
            this.tabThongTin.TabIndex = 0;
            this.tabThongTin.Text = "Thông tin cá nhân";
            this.tabThongTin.UseVisualStyleBackColor = true;
            // 
            // tblThongTin
            // 
            this.tblThongTin.AutoSize = true;
            this.tblThongTin.ColumnCount = 2;
            this.tblThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tblThongTin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblThongTin.Controls.Add(this.lblHocVienID, 0, 0);
            this.tblThongTin.Controls.Add(this.txtHocVienID, 1, 0);
            this.tblThongTin.Controls.Add(this.lblHoTen, 0, 1);
            this.tblThongTin.Controls.Add(this.txtHoTen, 1, 1);
            this.tblThongTin.Controls.Add(this.lblNgaySinh, 0, 2);
            this.tblThongTin.Controls.Add(this.txtNgaySinh, 1, 2);
            this.tblThongTin.Controls.Add(this.lblGioiTinh, 0, 3);
            this.tblThongTin.Controls.Add(this.txtGioiTinh, 1, 3);
            this.tblThongTin.Controls.Add(this.lblSoDienThoai, 0, 4);
            this.tblThongTin.Controls.Add(this.txtSoDienThoai, 1, 4);
            this.tblThongTin.Controls.Add(this.lblEmail, 0, 5);
            this.tblThongTin.Controls.Add(this.txtEmail, 1, 5);
            this.tblThongTin.Controls.Add(this.lblTrinhDoDauVao, 0, 6);
            this.tblThongTin.Controls.Add(this.txtTrinhDoDauVao, 1, 6);
            this.tblThongTin.Controls.Add(this.lblDiemDauVao, 0, 7);
            this.tblThongTin.Controls.Add(this.txtDiemDauVao, 1, 7);
            this.tblThongTin.Controls.Add(this.lblTrangThai, 0, 8);
            this.tblThongTin.Controls.Add(this.txtTrangThai, 1, 8);
            this.tblThongTin.Controls.Add(this.lblTaiKhoan, 0, 9);
            this.tblThongTin.Controls.Add(this.txtTaiKhoan, 1, 9);
            this.tblThongTin.Controls.Add(this.lblNhanXetDauVao, 0, 10);
            this.tblThongTin.Controls.Add(this.txtNhanXetDauVao, 1, 10);
            this.tblThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblThongTin.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tblThongTin.Location = new System.Drawing.Point(16, 16);
            this.tblThongTin.Name = "tblThongTin";
            this.tblThongTin.RowCount = 11;
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblThongTin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tblThongTin.Size = new System.Drawing.Size(900, 485);
            this.tblThongTin.TabIndex = 0;
            // 
            // lblHocVienID
            // 
            this.lblHocVienID.AutoSize = true;
            this.lblHocVienID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHocVienID.Location = new System.Drawing.Point(3, 5);
            this.lblHocVienID.Margin = new System.Windows.Forms.Padding(3, 5, 12, 5);
            this.lblHocVienID.Name = "lblHocVienID";
            this.lblHocVienID.Size = new System.Drawing.Size(175, 30);
            this.lblHocVienID.TabIndex = 0;
            this.lblHocVienID.Text = "Mã học viên";
            this.lblHocVienID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHocVienID
            // 
            this.txtHocVienID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHocVienID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHocVienID.Location = new System.Drawing.Point(193, 5);
            this.txtHocVienID.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtHocVienID.Name = "txtHocVienID";
            this.txtHocVienID.ReadOnly = true;
            this.txtHocVienID.Size = new System.Drawing.Size(704, 25);
            this.txtHocVienID.TabIndex = 1;
            this.txtHocVienID.TabStop = false;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHoTen.Location = new System.Drawing.Point(3, 45);
            this.lblHoTen.Margin = new System.Windows.Forms.Padding(3, 5, 12, 5);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(175, 30);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ tên";
            this.lblHoTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHoTen
            // 
            this.txtHoTen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHoTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHoTen.Location = new System.Drawing.Point(193, 45);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(704, 25);
            this.txtHoTen.TabIndex = 3;
            this.txtHoTen.TabStop = false;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgaySinh.Location = new System.Drawing.Point(3, 85);
            this.lblNgaySinh.Margin = new System.Windows.Forms.Padding(3, 5, 12, 5);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(175, 30);
            this.lblNgaySinh.TabIndex = 4;
            this.lblNgaySinh.Text = "Ngày sinh";
            this.lblNgaySinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNgaySinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNgaySinh.Location = new System.Drawing.Point(193, 85);
            this.txtNgaySinh.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.ReadOnly = true;
            this.txtNgaySinh.Size = new System.Drawing.Size(704, 25);
            this.txtNgaySinh.TabIndex = 5;
            this.txtNgaySinh.TabStop = false;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGioiTinh.Location = new System.Drawing.Point(3, 125);
            this.lblGioiTinh.Margin = new System.Windows.Forms.Padding(3, 5, 12, 5);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(175, 30);
            this.lblGioiTinh.TabIndex = 6;
            this.lblGioiTinh.Text = "Giới tính";
            this.lblGioiTinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtGioiTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGioiTinh.Location = new System.Drawing.Point(193, 125);
            this.txtGioiTinh.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.ReadOnly = true;
            this.txtGioiTinh.Size = new System.Drawing.Size(704, 25);
            this.txtGioiTinh.TabIndex = 7;
            this.txtGioiTinh.TabStop = false;
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoDienThoai.Location = new System.Drawing.Point(3, 165);
            this.lblSoDienThoai.Margin = new System.Windows.Forms.Padding(3, 5, 12, 5);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(175, 30);
            this.lblSoDienThoai.TabIndex = 8;
            this.lblSoDienThoai.Text = "Số điện thoại";
            this.lblSoDienThoai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSoDienThoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoDienThoai.Location = new System.Drawing.Point(193, 165);
            this.txtSoDienThoai.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.ReadOnly = true;
            this.txtSoDienThoai.Size = new System.Drawing.Size(704, 25);
            this.txtSoDienThoai.TabIndex = 9;
            this.txtSoDienThoai.TabStop = false;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Location = new System.Drawing.Point(3, 205);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(3, 5, 12, 5);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(175, 30);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Location = new System.Drawing.Point(193, 205);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(704, 25);
            this.txtEmail.TabIndex = 11;
            this.txtEmail.TabStop = false;
            // 
            // lblTrinhDoDauVao
            // 
            this.lblTrinhDoDauVao.AutoSize = true;
            this.lblTrinhDoDauVao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrinhDoDauVao.Location = new System.Drawing.Point(3, 245);
            this.lblTrinhDoDauVao.Margin = new System.Windows.Forms.Padding(3, 5, 12, 5);
            this.lblTrinhDoDauVao.Name = "lblTrinhDoDauVao";
            this.lblTrinhDoDauVao.Size = new System.Drawing.Size(175, 30);
            this.lblTrinhDoDauVao.TabIndex = 12;
            this.lblTrinhDoDauVao.Text = "Trình độ đầu vào";
            this.lblTrinhDoDauVao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTrinhDoDauVao
            // 
            this.txtTrinhDoDauVao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTrinhDoDauVao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTrinhDoDauVao.Location = new System.Drawing.Point(193, 245);
            this.txtTrinhDoDauVao.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTrinhDoDauVao.Name = "txtTrinhDoDauVao";
            this.txtTrinhDoDauVao.ReadOnly = true;
            this.txtTrinhDoDauVao.Size = new System.Drawing.Size(704, 25);
            this.txtTrinhDoDauVao.TabIndex = 13;
            this.txtTrinhDoDauVao.TabStop = false;
            // 
            // lblDiemDauVao
            // 
            this.lblDiemDauVao.AutoSize = true;
            this.lblDiemDauVao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiemDauVao.Location = new System.Drawing.Point(3, 285);
            this.lblDiemDauVao.Margin = new System.Windows.Forms.Padding(3, 5, 12, 5);
            this.lblDiemDauVao.Name = "lblDiemDauVao";
            this.lblDiemDauVao.Size = new System.Drawing.Size(175, 30);
            this.lblDiemDauVao.TabIndex = 14;
            this.lblDiemDauVao.Text = "Điểm đầu vào";
            this.lblDiemDauVao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiemDauVao
            // 
            this.txtDiemDauVao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDiemDauVao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiemDauVao.Location = new System.Drawing.Point(193, 285);
            this.txtDiemDauVao.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDiemDauVao.Name = "txtDiemDauVao";
            this.txtDiemDauVao.ReadOnly = true;
            this.txtDiemDauVao.Size = new System.Drawing.Size(704, 25);
            this.txtDiemDauVao.TabIndex = 15;
            this.txtDiemDauVao.TabStop = false;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThai.Location = new System.Drawing.Point(3, 325);
            this.lblTrangThai.Margin = new System.Windows.Forms.Padding(3, 5, 12, 5);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(175, 30);
            this.lblTrangThai.TabIndex = 16;
            this.lblTrangThai.Text = "Trạng thái";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTrangThai.Location = new System.Drawing.Point(193, 325);
            this.txtTrangThai.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.ReadOnly = true;
            this.txtTrangThai.Size = new System.Drawing.Size(704, 25);
            this.txtTrangThai.TabIndex = 17;
            this.txtTrangThai.TabStop = false;
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTaiKhoan.Location = new System.Drawing.Point(3, 365);
            this.lblTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 5, 12, 5);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(175, 30);
            this.lblTaiKhoan.TabIndex = 18;
            this.lblTaiKhoan.Text = "Tài khoản";
            this.lblTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaiKhoan.Location = new System.Drawing.Point(193, 365);
            this.txtTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.ReadOnly = true;
            this.txtTaiKhoan.Size = new System.Drawing.Size(704, 25);
            this.txtTaiKhoan.TabIndex = 19;
            this.txtTaiKhoan.TabStop = false;
            // 
            // lblNhanXetDauVao
            // 
            this.lblNhanXetDauVao.AutoSize = true;
            this.lblNhanXetDauVao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNhanXetDauVao.Location = new System.Drawing.Point(3, 405);
            this.lblNhanXetDauVao.Margin = new System.Windows.Forms.Padding(3, 5, 12, 5);
            this.lblNhanXetDauVao.Name = "lblNhanXetDauVao";
            this.lblNhanXetDauVao.Size = new System.Drawing.Size(175, 75);
            this.lblNhanXetDauVao.TabIndex = 20;
            this.lblNhanXetDauVao.Text = "Nhận xét đầu vào";
            this.lblNhanXetDauVao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNhanXetDauVao
            // 
            this.txtNhanXetDauVao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNhanXetDauVao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNhanXetDauVao.Location = new System.Drawing.Point(193, 405);
            this.txtNhanXetDauVao.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtNhanXetDauVao.Multiline = true;
            this.txtNhanXetDauVao.Name = "txtNhanXetDauVao";
            this.txtNhanXetDauVao.ReadOnly = true;
            this.txtNhanXetDauVao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNhanXetDauVao.Size = new System.Drawing.Size(704, 75);
            this.txtNhanXetDauVao.TabIndex = 21;
            this.txtNhanXetDauVao.TabStop = false;
            // 
            // tabLopHoc
            // 
            this.tabLopHoc.AutoScroll = true;
            this.tabLopHoc.Controls.Add(this.dgvLopHoc);
            this.tabLopHoc.Location = new System.Drawing.Point(4, 26);
            this.tabLopHoc.Name = "tabLopHoc";
            this.tabLopHoc.Padding = new System.Windows.Forms.Padding(16);
            this.tabLopHoc.Size = new System.Drawing.Size(152, 0);
            this.tabLopHoc.TabIndex = 1;
            this.tabLopHoc.Text = "Lớp đã đăng ký";
            this.tabLopHoc.UseVisualStyleBackColor = true;
            // 
            // dgvLopHoc
            // 
            this.dgvLopHoc.AllowUserToAddRows = false;
            this.dgvLopHoc.AllowUserToDeleteRows = false;
            this.dgvLopHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLopHoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvLopHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLopHoc.Location = new System.Drawing.Point(16, 16);
            this.dgvLopHoc.MultiSelect = false;
            this.dgvLopHoc.Name = "dgvLopHoc";
            this.dgvLopHoc.ReadOnly = true;
            this.dgvLopHoc.RowHeadersVisible = false;
            this.dgvLopHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLopHoc.Size = new System.Drawing.Size(120, 0);
            this.dgvLopHoc.TabIndex = 0;
            // 
            // tabKetQua
            // 
            this.tabKetQua.AutoScroll = true;
            this.tabKetQua.Controls.Add(this.dgvKetQua);
            this.tabKetQua.Location = new System.Drawing.Point(4, 26);
            this.tabKetQua.Name = "tabKetQua";
            this.tabKetQua.Padding = new System.Windows.Forms.Padding(16);
            this.tabKetQua.Size = new System.Drawing.Size(152, 0);
            this.tabKetQua.TabIndex = 2;
            this.tabKetQua.Text = "Kết quả học tập";
            this.tabKetQua.UseVisualStyleBackColor = true;
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQua.BackgroundColor = System.Drawing.Color.White;
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.Location = new System.Drawing.Point(16, 16);
            this.dgvKetQua.MultiSelect = false;
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.RowHeadersVisible = false;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(120, 0);
            this.dgvKetQua.TabIndex = 0;
            // 
            // tabHocPhi
            // 
            this.tabHocPhi.AutoScroll = true;
            this.tabHocPhi.Controls.Add(this.dgvHocPhi);
            this.tabHocPhi.Location = new System.Drawing.Point(4, 26);
            this.tabHocPhi.Name = "tabHocPhi";
            this.tabHocPhi.Padding = new System.Windows.Forms.Padding(16);
            this.tabHocPhi.Size = new System.Drawing.Size(152, 0);
            this.tabHocPhi.TabIndex = 3;
            this.tabHocPhi.Text = "Học phí";
            this.tabHocPhi.UseVisualStyleBackColor = true;
            // 
            // dgvHocPhi
            // 
            this.dgvHocPhi.AllowUserToAddRows = false;
            this.dgvHocPhi.AllowUserToDeleteRows = false;
            this.dgvHocPhi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHocPhi.BackgroundColor = System.Drawing.Color.White;
            this.dgvHocPhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHocPhi.Location = new System.Drawing.Point(16, 16);
            this.dgvHocPhi.MultiSelect = false;
            this.dgvHocPhi.Name = "dgvHocPhi";
            this.dgvHocPhi.ReadOnly = true;
            this.dgvHocPhi.RowHeadersVisible = false;
            this.dgvHocPhi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHocPhi.Size = new System.Drawing.Size(120, 0);
            this.dgvHocPhi.TabIndex = 0;
            // 
            // lblTieuDeTrang
            // 
            this.lblTieuDeTrang.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDeTrang.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeTrang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))));
            this.lblTieuDeTrang.Location = new System.Drawing.Point(20, 20);
            this.lblTieuDeTrang.Name = "lblTieuDeTrang";
            this.lblTieuDeTrang.Size = new System.Drawing.Size(940, 48);
            this.lblTieuDeTrang.TabIndex = 1;
            this.lblTieuDeTrang.Text = "HỒ SƠ HỌC VIÊN";
            // 
            // stsTrangThai
            // 
            this.stsTrangThai.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblVaiTro});
            this.stsTrangThai.Location = new System.Drawing.Point(0, 738);
            this.stsTrangThai.Name = "stsTrangThai";
            this.stsTrangThai.Size = new System.Drawing.Size(1200, 22);
            this.stsTrangThai.SizingGrip = false;
            this.stsTrangThai.TabIndex = 3;
            // 
            // tslblVaiTro
            // 
            this.tslblVaiTro.Name = "tslblVaiTro";
            this.tslblVaiTro.Size = new System.Drawing.Size(93, 17);
            this.tslblVaiTro.Text = "Vai trò: Học viên";
            // 
            // frmMainHocVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 760);
            this.Controls.Add(this.pnlNoiDung);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.stsTrangThai);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1100, 720);
            this.Name = "frmMainHocVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang học viên - Trung tâm ngoại ngữ";
            this.pnlHeader.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlNoiDung.ResumeLayout(false);
            this.tabHoSo.ResumeLayout(false);
            this.tabThongTin.ResumeLayout(false);
            this.tabThongTin.PerformLayout();
            this.tblThongTin.ResumeLayout(false);
            this.tblThongTin.PerformLayout();
            this.tabLopHoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).EndInit();
            this.tabKetQua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.tabHocPhi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocPhi)).EndInit();
            this.stsTrangThai.ResumeLayout(false);
            this.stsTrangThai.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlNoiDung;
        private System.Windows.Forms.Label lblTenHeThong;
        private System.Windows.Forms.Label lblNguoiDangNhap;
        private System.Windows.Forms.StatusStrip stsTrangThai;
        private System.Windows.Forms.ToolStripStatusLabel tslblVaiTro;
        private System.Windows.Forms.Label lblTieuDeTrang;
        private System.Windows.Forms.Button btnThongTin;
        private System.Windows.Forms.Button btnLopHoc;
        private System.Windows.Forms.Button btnKetQua;
        private System.Windows.Forms.Button btnHocPhi;
        private System.Windows.Forms.TabControl tabHoSo;
        private System.Windows.Forms.TabPage tabThongTin;
        private System.Windows.Forms.TabPage tabLopHoc;
        private System.Windows.Forms.TabPage tabKetQua;
        private System.Windows.Forms.TabPage tabHocPhi;
        private System.Windows.Forms.TableLayoutPanel tblThongTin;
        private System.Windows.Forms.Label lblHocVienID;
        private System.Windows.Forms.TextBox txtHocVienID;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.TextBox txtGioiTinh;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTrinhDoDauVao;
        private System.Windows.Forms.TextBox txtTrinhDoDauVao;
        private System.Windows.Forms.Label lblDiemDauVao;
        private System.Windows.Forms.TextBox txtDiemDauVao;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label lblNhanXetDauVao;
        private System.Windows.Forms.TextBox txtNhanXetDauVao;
        private System.Windows.Forms.DataGridView dgvLopHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocTenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocTenKhoaHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocTenCoSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocNgayDangKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocNgayBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocNgayKetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLopHocTrangThai;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvKetQuaTenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvKetQuaDiemCuoiKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvKetQuaKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvKetQuaDuocHocLaiMienPhi;
        private System.Windows.Forms.DataGridView dgvHocPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHocPhiTenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHocPhiHoaDonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHocPhiTongPhaiTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHocPhiDaThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHocPhiConPhaiTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHocPhiTrangThai;
    }
}
