namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlDanhSach = new System.Windows.Forms.Panel();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.colMaTaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVaiTro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlNhapLieu = new System.Windows.Forms.Panel();
            this.lblMaTaiKhoan = new System.Windows.Forms.Label();
            this.txtMaTaiKhoan = new System.Windows.Forms.TextBox();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.lblHoSoLienKet = new System.Windows.Forms.Label();
            this.cboHoSoLienKet = new System.Windows.Forms.ComboBox();
            this.lblMatKhauKhoiTao = new System.Windows.Forms.Label();
            this.txtMatKhauKhoiTao = new System.Windows.Forms.TextBox();
            this.lblXacNhanMatKhau = new System.Windows.Forms.Label();
            this.txtXacNhanMatKhau = new System.Windows.Forms.TextBox();
            this.chkHienMatKhau = new System.Windows.Forms.CheckBox();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnKhoa = new System.Windows.Forms.Button();
            this.btnMoKhoa = new System.Windows.Forms.Button();
            this.pnlChan = new System.Windows.Forms.Panel();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.pnlBoLoc = new System.Windows.Forms.Panel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocVaiTro = new System.Windows.Forms.Label();
            this.cboLocVaiTro = new System.Windows.Forms.ComboBox();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlTieuDe = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.pnlDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.pnlNhapLieu.SuspendLayout();
            this.pnlChan.SuspendLayout();
            this.pnlBoLoc.SuspendLayout();
            this.pnlTieuDe.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDanhSach
            // 
            this.pnlDanhSach.Controls.Add(this.dgvTaiKhoan);
            this.pnlDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDanhSach.Location = new System.Drawing.Point(0, 189);
            this.pnlDanhSach.Name = "pnlDanhSach";
            this.pnlDanhSach.Padding = new System.Windows.Forms.Padding(24, 8, 24, 8);
            this.pnlDanhSach.Size = new System.Drawing.Size(1040, 461);
            this.pnlDanhSach.TabIndex = 1;
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.AllowUserToAddRows = false;
            this.dgvTaiKhoan.AllowUserToDeleteRows = false;
            this.dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaiKhoan.BackgroundColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTaiKhoan.ColumnHeadersHeight = 42;
            this.dgvTaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaTaiKhoan,
            this.colTenDangNhap,
            this.colHoTen,
            this.colVaiTro,
            this.colTrangThai});
            this.dgvTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaiKhoan.EnableHeadersVisualStyles = false;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(24, 8);
            this.dgvTaiKhoan.MultiSelect = false;
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.ReadOnly = true;
            this.dgvTaiKhoan.RowHeadersVisible = false;
            this.dgvTaiKhoan.RowHeadersWidth = 51;
            this.dgvTaiKhoan.RowTemplate.Height = 34;
            this.dgvTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(992, 445);
            this.dgvTaiKhoan.TabIndex = 0;
            // 
            // colMaTaiKhoan
            // 
            this.colMaTaiKhoan.DataPropertyName = "NguoiDungID";
            this.colMaTaiKhoan.HeaderText = "Mã TK";
            this.colMaTaiKhoan.MinimumWidth = 6;
            this.colMaTaiKhoan.Name = "colMaTaiKhoan";
            this.colMaTaiKhoan.ReadOnly = true;
            // 
            // colTenDangNhap
            // 
            this.colTenDangNhap.DataPropertyName = "TenDangNhap";
            this.colTenDangNhap.HeaderText = "Tên đăng nhập";
            this.colTenDangNhap.MinimumWidth = 6;
            this.colTenDangNhap.Name = "colTenDangNhap";
            this.colTenDangNhap.ReadOnly = true;
            // 
            // colHoTen
            // 
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.HeaderText = "Họ tên";
            this.colHoTen.MinimumWidth = 6;
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            // 
            // colVaiTro
            // 
            this.colVaiTro.DataPropertyName = "VaiTro";
            this.colVaiTro.HeaderText = "Vai trò";
            this.colVaiTro.MinimumWidth = 6;
            this.colVaiTro.Name = "colVaiTro";
            this.colVaiTro.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.DataPropertyName = "TrangThai";
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.MinimumWidth = 6;
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // pnlNhapLieu
            // 
            this.pnlNhapLieu.BackColor = System.Drawing.Color.White;
            this.pnlNhapLieu.Controls.Add(this.lblMaTaiKhoan);
            this.pnlNhapLieu.Controls.Add(this.txtMaTaiKhoan);
            this.pnlNhapLieu.Controls.Add(this.lblTenDangNhap);
            this.pnlNhapLieu.Controls.Add(this.txtTenDangNhap);
            this.pnlNhapLieu.Controls.Add(this.lblVaiTro);
            this.pnlNhapLieu.Controls.Add(this.cboVaiTro);
            this.pnlNhapLieu.Controls.Add(this.lblHoSoLienKet);
            this.pnlNhapLieu.Controls.Add(this.cboHoSoLienKet);
            this.pnlNhapLieu.Controls.Add(this.lblMatKhauKhoiTao);
            this.pnlNhapLieu.Controls.Add(this.txtMatKhauKhoiTao);
            this.pnlNhapLieu.Controls.Add(this.lblXacNhanMatKhau);
            this.pnlNhapLieu.Controls.Add(this.txtXacNhanMatKhau);
            this.pnlNhapLieu.Controls.Add(this.chkHienMatKhau);
            this.pnlNhapLieu.Controls.Add(this.btnThemMoi);
            this.pnlNhapLieu.Controls.Add(this.btnLuu);
            this.pnlNhapLieu.Controls.Add(this.btnHuy);
            this.pnlNhapLieu.Controls.Add(this.btnKhoa);
            this.pnlNhapLieu.Controls.Add(this.btnMoKhoa);
            this.pnlNhapLieu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNhapLieu.Location = new System.Drawing.Point(0, 650);
            this.pnlNhapLieu.Name = "pnlNhapLieu";
            this.pnlNhapLieu.Size = new System.Drawing.Size(1040, 220);
            this.pnlNhapLieu.TabIndex = 2;
            // 
            // lblMaTaiKhoan
            // 
            this.lblMaTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblMaTaiKhoan.Location = new System.Drawing.Point(24, 12);
            this.lblMaTaiKhoan.Name = "lblMaTaiKhoan";
            this.lblMaTaiKhoan.Size = new System.Drawing.Size(140, 22);
            this.lblMaTaiKhoan.TabIndex = 23;
            this.lblMaTaiKhoan.Text = "Mã tài khoản";
            this.lblMaTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaTaiKhoan
            // 
            this.txtMaTaiKhoan.Location = new System.Drawing.Point(24, 37);
            this.txtMaTaiKhoan.MaxLength = 100;
            this.txtMaTaiKhoan.Name = "txtMaTaiKhoan";
            this.txtMaTaiKhoan.ReadOnly = true;
            this.txtMaTaiKhoan.Size = new System.Drawing.Size(140, 30);
            this.txtMaTaiKhoan.TabIndex = 24;
            this.txtMaTaiKhoan.TabStop = false;
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTenDangNhap.Location = new System.Drawing.Point(184, 12);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(230, 22);
            this.lblTenDangNhap.TabIndex = 25;
            this.lblTenDangNhap.Text = "Tên đăng nhập";
            this.lblTenDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(184, 37);
            this.txtTenDangNhap.MaxLength = 100;
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(230, 30);
            this.txtTenDangNhap.TabIndex = 26;
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblVaiTro.Location = new System.Drawing.Point(434, 12);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(220, 22);
            this.lblVaiTro.TabIndex = 27;
            this.lblVaiTro.Text = "Vai trò";
            this.lblVaiTro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboVaiTro
            // 
            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.Items.AddRange(new object[] {
            "Admin",
            "Nhân viên",
            "Giáo viên",
            "Học viên"});
            this.cboVaiTro.Location = new System.Drawing.Point(434, 37);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(220, 31);
            this.cboVaiTro.TabIndex = 28;
            // 
            // lblHoSoLienKet
            // 
            this.lblHoSoLienKet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHoSoLienKet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblHoSoLienKet.Location = new System.Drawing.Point(674, 12);
            this.lblHoSoLienKet.Name = "lblHoSoLienKet";
            this.lblHoSoLienKet.Size = new System.Drawing.Size(300, 22);
            this.lblHoSoLienKet.TabIndex = 29;
            this.lblHoSoLienKet.Text = "Hồ sơ liên kết";
            this.lblHoSoLienKet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboHoSoLienKet
            // 
            this.cboHoSoLienKet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHoSoLienKet.Location = new System.Drawing.Point(674, 37);
            this.cboHoSoLienKet.Name = "cboHoSoLienKet";
            this.cboHoSoLienKet.Size = new System.Drawing.Size(300, 31);
            this.cboHoSoLienKet.TabIndex = 30;
            // 
            // lblMatKhauKhoiTao
            // 
            this.lblMatKhauKhoiTao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMatKhauKhoiTao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblMatKhauKhoiTao.Location = new System.Drawing.Point(24, 82);
            this.lblMatKhauKhoiTao.Name = "lblMatKhauKhoiTao";
            this.lblMatKhauKhoiTao.Size = new System.Drawing.Size(270, 22);
            this.lblMatKhauKhoiTao.TabIndex = 31;
            this.lblMatKhauKhoiTao.Text = "Mật khẩu khởi tạo";
            this.lblMatKhauKhoiTao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMatKhauKhoiTao
            // 
            this.txtMatKhauKhoiTao.Location = new System.Drawing.Point(24, 107);
            this.txtMatKhauKhoiTao.MaxLength = 128;
            this.txtMatKhauKhoiTao.Name = "txtMatKhauKhoiTao";
            this.txtMatKhauKhoiTao.Size = new System.Drawing.Size(270, 30);
            this.txtMatKhauKhoiTao.TabIndex = 32;
            this.txtMatKhauKhoiTao.UseSystemPasswordChar = true;
            // 
            // lblXacNhanMatKhau
            // 
            this.lblXacNhanMatKhau.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblXacNhanMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblXacNhanMatKhau.Location = new System.Drawing.Point(314, 82);
            this.lblXacNhanMatKhau.Name = "lblXacNhanMatKhau";
            this.lblXacNhanMatKhau.Size = new System.Drawing.Size(270, 22);
            this.lblXacNhanMatKhau.TabIndex = 33;
            this.lblXacNhanMatKhau.Text = "Nhập lại mật khẩu";
            this.lblXacNhanMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtXacNhanMatKhau
            // 
            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(314, 107);
            this.txtXacNhanMatKhau.MaxLength = 128;
            this.txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(270, 30);
            this.txtXacNhanMatKhau.TabIndex = 34;
            this.txtXacNhanMatKhau.UseSystemPasswordChar = true;
            // 
            // chkHienMatKhau
            // 
            this.chkHienMatKhau.Location = new System.Drawing.Point(605, 106);
            this.chkHienMatKhau.Name = "chkHienMatKhau";
            this.chkHienMatKhau.Size = new System.Drawing.Size(210, 28);
            this.chkHienMatKhau.TabIndex = 35;
            this.chkHienMatKhau.Text = "Hiện mật khẩu";
            this.chkHienMatKhau.CheckedChanged += new System.EventHandler(this.chkHienMatKhau_CheckedChanged);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.BackColor = System.Drawing.Color.White;
            this.btnThemMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemMoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnThemMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnThemMoi.Location = new System.Drawing.Point(24, 163);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(122, 36);
            this.btnThemMoi.TabIndex = 36;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = false;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(160, 163);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(122, 36);
            this.btnLuu.TabIndex = 37;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.White;
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnHuy.Location = new System.Drawing.Point(296, 163);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(122, 36);
            this.btnHuy.TabIndex = 38;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnKhoa
            // 
            this.btnKhoa.BackColor = System.Drawing.Color.White;
            this.btnKhoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKhoa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnKhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnKhoa.Location = new System.Drawing.Point(580, 163);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Size = new System.Drawing.Size(122, 36);
            this.btnKhoa.TabIndex = 39;
            this.btnKhoa.Text = "Khóa";
            this.btnKhoa.UseVisualStyleBackColor = false;
            this.btnKhoa.Click += new System.EventHandler(this.btnKhoa_Click);
            // 
            // btnMoKhoa
            // 
            this.btnMoKhoa.BackColor = System.Drawing.Color.White;
            this.btnMoKhoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoKhoa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnMoKhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnMoKhoa.Location = new System.Drawing.Point(716, 163);
            this.btnMoKhoa.Name = "btnMoKhoa";
            this.btnMoKhoa.Size = new System.Drawing.Size(122, 36);
            this.btnMoKhoa.TabIndex = 40;
            this.btnMoKhoa.Text = "Mở khóa";
            this.btnMoKhoa.UseVisualStyleBackColor = false;
            this.btnMoKhoa.Click += new System.EventHandler(this.btnMoKhoa_Click);
            // 
            // pnlChan
            // 
            this.pnlChan.BackColor = System.Drawing.Color.White;
            this.pnlChan.Controls.Add(this.lblTrangThai);
            this.pnlChan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChan.Location = new System.Drawing.Point(0, 870);
            this.pnlChan.Name = "pnlChan";
            this.pnlChan.Size = new System.Drawing.Size(1040, 54);
            this.pnlChan.TabIndex = 3;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTrangThai.Location = new System.Drawing.Point(24, 12);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(590, 28);
            this.lblTrangThai.TabIndex = 4;
            this.lblTrangThai.Text = "Chưa có dữ liệu.";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBoLoc
            // 
            this.pnlBoLoc.Controls.Add(this.lblTimKiem);
            this.pnlBoLoc.Controls.Add(this.txtTimKiem);
            this.pnlBoLoc.Controls.Add(this.lblLocVaiTro);
            this.pnlBoLoc.Controls.Add(this.cboLocVaiTro);
            this.pnlBoLoc.Controls.Add(this.lblLocTrangThai);
            this.pnlBoLoc.Controls.Add(this.cboLocTrangThai);
            this.pnlBoLoc.Controls.Add(this.btnTimKiem);
            this.pnlBoLoc.Controls.Add(this.btnLamMoi);
            this.pnlBoLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBoLoc.Location = new System.Drawing.Point(0, 101);
            this.pnlBoLoc.Name = "pnlBoLoc";
            this.pnlBoLoc.Size = new System.Drawing.Size(1040, 88);
            this.pnlBoLoc.TabIndex = 5;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTimKiem.Location = new System.Drawing.Point(24, 2);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(240, 22);
            this.lblTimKiem.TabIndex = 9;
            this.lblTimKiem.Text = "Tìm tài khoản";
            this.lblTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(24, 29);
            this.txtTimKiem.MaxLength = 100;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(280, 30);
            this.txtTimKiem.TabIndex = 10;
            // 
            // lblLocVaiTro
            // 
            this.lblLocVaiTro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLocVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblLocVaiTro.Location = new System.Drawing.Point(322, 2);
            this.lblLocVaiTro.Name = "lblLocVaiTro";
            this.lblLocVaiTro.Size = new System.Drawing.Size(180, 22);
            this.lblLocVaiTro.TabIndex = 11;
            this.lblLocVaiTro.Text = "Vai trò";
            this.lblLocVaiTro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLocVaiTro
            // 
            this.cboLocVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocVaiTro.Items.AddRange(new object[] {
            "Tất cả",
            "Admin",
            "Nhân viên",
            "Giáo viên",
            "Học viên"});
            this.cboLocVaiTro.Location = new System.Drawing.Point(322, 29);
            this.cboLocVaiTro.Name = "cboLocVaiTro";
            this.cboLocVaiTro.Size = new System.Drawing.Size(185, 31);
            this.cboLocVaiTro.TabIndex = 12;
            // 
            // lblLocTrangThai
            // 
            this.lblLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLocTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblLocTrangThai.Location = new System.Drawing.Point(524, 2);
            this.lblLocTrangThai.Name = "lblLocTrangThai";
            this.lblLocTrangThai.Size = new System.Drawing.Size(180, 22);
            this.lblLocTrangThai.TabIndex = 13;
            this.lblLocTrangThai.Text = "Trạng thái";
            this.lblLocTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Hoạt động",
            "Bị khóa"});
            this.cboLocTrangThai.Location = new System.Drawing.Point(524, 29);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(185, 31);
            this.cboLocTrangThai.TabIndex = 14;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(728, 25);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(120, 36);
            this.btnTimKiem.TabIndex = 15;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.White;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnLamMoi.Location = new System.Drawing.Point(860, 25);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 36);
            this.btnLamMoi.TabIndex = 16;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // pnlTieuDe
            // 
            this.pnlTieuDe.Controls.Add(this.lblTieuDe);
            this.pnlTieuDe.Controls.Add(this.lblMoTa);
            this.pnlTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTieuDe.Location = new System.Drawing.Point(0, 0);
            this.pnlTieuDe.Name = "pnlTieuDe";
            this.pnlTieuDe.Size = new System.Drawing.Size(1040, 101);
            this.pnlTieuDe.TabIndex = 6;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTieuDe.Location = new System.Drawing.Point(24, 14);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(800, 32);
            this.lblTieuDe.TabIndex = 7;
            this.lblTieuDe.Text = "Tài khoản & phân quyền";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMoTa
            // 
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMoTa.Location = new System.Drawing.Point(27, 63);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(900, 24);
            this.lblMoTa.TabIndex = 8;
            this.lblMoTa.Text = "Tìm tài khoản, cấp tài khoản và quản lý trạng thái truy cập.";
            this.lblMoTa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1040, 650);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1040, 720);
            this.Controls.Add(this.pnlDanhSach);
            this.Controls.Add(this.pnlNhapLieu);
            this.Controls.Add(this.pnlChan);
            this.Controls.Add(this.pnlBoLoc);
            this.Controls.Add(this.pnlTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(980, 650);
            this.Name = "frmTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tài khoản & phân quyền";
            this.pnlDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.pnlNhapLieu.ResumeLayout(false);
            this.pnlNhapLieu.PerformLayout();
            this.pnlChan.ResumeLayout(false);
            this.pnlBoLoc.ResumeLayout(false);
            this.pnlBoLoc.PerformLayout();
            this.pnlTieuDe.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDanhSach;
        private System.Windows.Forms.Panel pnlNhapLieu;
        private System.Windows.Forms.Panel pnlChan;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Panel pnlBoLoc;
        private System.Windows.Forms.Panel pnlTieuDe;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblLocVaiTro;
        private System.Windows.Forms.ComboBox cboLocVaiTro;
        private System.Windows.Forms.Label lblLocTrangThai;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVaiTro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.Label lblMaTaiKhoan;
        private System.Windows.Forms.TextBox txtMaTaiKhoan;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Label lblHoSoLienKet;
        private System.Windows.Forms.ComboBox cboHoSoLienKet;
        private System.Windows.Forms.Label lblMatKhauKhoiTao;
        private System.Windows.Forms.TextBox txtMatKhauKhoiTao;
        private System.Windows.Forms.Label lblXacNhanMatKhau;
        private System.Windows.Forms.TextBox txtXacNhanMatKhau;
        private System.Windows.Forms.CheckBox chkHienMatKhau;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnKhoa;
        private System.Windows.Forms.Button btnMoKhoa;
    }
}
