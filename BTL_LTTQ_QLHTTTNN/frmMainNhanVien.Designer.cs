namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmMainNhanVien
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
            this.components = new System.ComponentModel.Container();
            this.pnlVungChinh = new System.Windows.Forms.Panel();
            this.pnlNoiDung = new System.Windows.Forms.Panel();
            this.lblChaoMung = new System.Windows.Forms.Label();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnThuGonMenu = new System.Windows.Forms.Button();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.lblNguoiDangNhap = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlMenuNoiDung = new System.Windows.Forms.Panel();
            this.lblNhom1 = new System.Windows.Forms.Label();
            this.btnHoSoHocVien = new System.Windows.Forms.Button();
            this.btnKhaoThiXepLop = new System.Windows.Forms.Button();
            this.lblNhom2 = new System.Windows.Forms.Label();
            this.btnDanhSachLopHoc = new System.Windows.Forms.Button();
            this.btnLichHocPhongHoc = new System.Windows.Forms.Button();
            this.lblNhom3 = new System.Windows.Forms.Label();
            this.btnQuanLyHoaDon = new System.Windows.Forms.Button();
            this.lblNhom4 = new System.Windows.Forms.Label();
            this.btnThongBao = new System.Windows.Forms.Button();
            this.pnlThuongHieu = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblTenHeThong = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.menuTaiKhoan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlVungChinh.SuspendLayout();
            this.pnlNoiDung.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlMenuNoiDung.SuspendLayout();
            this.pnlThuongHieu.SuspendLayout();
            this.menuTaiKhoan.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlVungChinh
            // 
            this.pnlVungChinh.Controls.Add(this.pnlNoiDung);
            this.pnlVungChinh.Controls.Add(this.pnlHeader);
            this.pnlVungChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVungChinh.Location = new System.Drawing.Point(270, 0);
            this.pnlVungChinh.Name = "pnlVungChinh";
            this.pnlVungChinh.Size = new System.Drawing.Size(1010, 800);
            this.pnlVungChinh.TabIndex = 1;
            // 
            // pnlNoiDung
            // 
            this.pnlNoiDung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlNoiDung.Controls.Add(this.lblChaoMung);
            this.pnlNoiDung.Controls.Add(this.lblHuongDan);
            this.pnlNoiDung.Controls.Add(this.lblThongBao);
            this.pnlNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoiDung.Location = new System.Drawing.Point(0, 72);
            this.pnlNoiDung.Name = "pnlNoiDung";
            this.pnlNoiDung.Size = new System.Drawing.Size(1010, 728);
            this.pnlNoiDung.TabIndex = 8;
            // 
            // lblChaoMung
            // 
            this.lblChaoMung.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblChaoMung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblChaoMung.Location = new System.Drawing.Point(32, 30);
            this.lblChaoMung.Name = "lblChaoMung";
            this.lblChaoMung.Size = new System.Drawing.Size(700, 46);
            this.lblChaoMung.TabIndex = 13;
            this.lblChaoMung.Text = "Không gian Nhân viên";
            this.lblChaoMung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHuongDan
            // 
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHuongDan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblHuongDan.Location = new System.Drawing.Point(34, 84);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(800, 28);
            this.lblHuongDan.TabIndex = 14;
            this.lblHuongDan.Text = "Chọn chức năng trong menu bên trái để bắt đầu quản lý học viên, lớp học và học phí.";
            this.lblHuongDan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblThongBao
            // 
            this.lblThongBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblThongBao.Location = new System.Drawing.Point(34, 140);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(800, 110);
            this.lblThongBao.TabIndex = 15;
            this.lblThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnThuGonMenu);
            this.pnlHeader.Controls.Add(this.lblVaiTro);
            this.pnlHeader.Controls.Add(this.lblNguoiDangNhap);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1010, 72);
            this.pnlHeader.TabIndex = 9;
            // 
            // btnThuGonMenu
            // 
            this.btnThuGonMenu.BackColor = System.Drawing.Color.White;
            this.btnThuGonMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThuGonMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnThuGonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThuGonMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnThuGonMenu.Location = new System.Drawing.Point(24, 17);
            this.btnThuGonMenu.Name = "btnThuGonMenu";
            this.btnThuGonMenu.Size = new System.Drawing.Size(40, 36);
            this.btnThuGonMenu.TabIndex = 10;
            this.btnThuGonMenu.Text = "☰";
            this.btnThuGonMenu.UseVisualStyleBackColor = false;
            this.btnThuGonMenu.Click += new System.EventHandler(this.btnThuGonMenu_Click);
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVaiTro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblVaiTro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVaiTro.ForeColor = System.Drawing.Color.White;
            this.lblVaiTro.Location = new System.Drawing.Point(650, 22);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(90, 28);
            this.lblVaiTro.TabIndex = 11;
            this.lblVaiTro.Text = "Nhân viên";
            this.lblVaiTro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNguoiDangNhap
            // 
            this.lblNguoiDangNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNguoiDangNhap.AutoEllipsis = true;
            this.lblNguoiDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNguoiDangNhap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNguoiDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblNguoiDangNhap.Location = new System.Drawing.Point(752, 18);
            this.lblNguoiDangNhap.Name = "lblNguoiDangNhap";
            this.lblNguoiDangNhap.Size = new System.Drawing.Size(234, 36);
            this.lblNguoiDangNhap.TabIndex = 12;
            this.lblNguoiDangNhap.Text = "Xin chào, Nhân viên  ▾";
            this.lblNguoiDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNguoiDangNhap.Click += new System.EventHandler(this.lblNguoiDangNhap_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlMenu.Controls.Add(this.pnlMenuNoiDung);
            this.pnlMenu.Controls.Add(this.pnlThuongHieu);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(270, 800);
            this.pnlMenu.TabIndex = 2;
            // 
            // pnlMenuNoiDung
            // 
            this.pnlMenuNoiDung.AutoScroll = true;
            this.pnlMenuNoiDung.Controls.Add(this.lblNhom1);
            this.pnlMenuNoiDung.Controls.Add(this.btnHoSoHocVien);
            this.pnlMenuNoiDung.Controls.Add(this.btnKhaoThiXepLop);
            this.pnlMenuNoiDung.Controls.Add(this.lblNhom2);
            this.pnlMenuNoiDung.Controls.Add(this.btnDanhSachLopHoc);
            this.pnlMenuNoiDung.Controls.Add(this.btnLichHocPhongHoc);
            this.pnlMenuNoiDung.Controls.Add(this.lblNhom3);
            this.pnlMenuNoiDung.Controls.Add(this.btnQuanLyHoaDon);
            this.pnlMenuNoiDung.Controls.Add(this.lblNhom4);
            this.pnlMenuNoiDung.Controls.Add(this.btnThongBao);
            this.pnlMenuNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenuNoiDung.Location = new System.Drawing.Point(0, 100);
            this.pnlMenuNoiDung.Name = "pnlMenuNoiDung";
            this.pnlMenuNoiDung.Size = new System.Drawing.Size(270, 700);
            this.pnlMenuNoiDung.TabIndex = 3;
            // 
            // lblNhom1
            // 
            this.lblNhom1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNhom1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblNhom1.Location = new System.Drawing.Point(24, 22);
            this.lblNhom1.Name = "lblNhom1";
            this.lblNhom1.Size = new System.Drawing.Size(230, 28);
            this.lblNhom1.TabIndex = 19;
            this.lblNhom1.Text = "VẬN HÀNH HỌC VIÊN";
            this.lblNhom1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnHoSoHocVien
            // 
            this.btnHoSoHocVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnHoSoHocVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHoSoHocVien.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnHoSoHocVien.FlatAppearance.BorderSize = 0;
            this.btnHoSoHocVien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnHoSoHocVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoSoHocVien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnHoSoHocVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnHoSoHocVien.Location = new System.Drawing.Point(14, 60);
            this.btnHoSoHocVien.Name = "btnHoSoHocVien";
            this.btnHoSoHocVien.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHoSoHocVien.Size = new System.Drawing.Size(232, 40);
            this.btnHoSoHocVien.TabIndex = 20;
            this.btnHoSoHocVien.Text = "🪪  Hồ sơ Học viên";
            this.btnHoSoHocVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoSoHocVien.UseVisualStyleBackColor = false;
            this.btnHoSoHocVien.Click += new System.EventHandler(this.btnHoSoHocVien_Click);
            // 
            // btnKhaoThiXepLop
            // 
            this.btnKhaoThiXepLop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnKhaoThiXepLop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKhaoThiXepLop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnKhaoThiXepLop.FlatAppearance.BorderSize = 0;
            this.btnKhaoThiXepLop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnKhaoThiXepLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhaoThiXepLop.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnKhaoThiXepLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnKhaoThiXepLop.Location = new System.Drawing.Point(14, 104);
            this.btnKhaoThiXepLop.Name = "btnKhaoThiXepLop";
            this.btnKhaoThiXepLop.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnKhaoThiXepLop.Size = new System.Drawing.Size(232, 40);
            this.btnKhaoThiXepLop.TabIndex = 21;
            this.btnKhaoThiXepLop.Text = "📝  Khảo thí đầu vào && Xếp lớp";
            this.btnKhaoThiXepLop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhaoThiXepLop.UseVisualStyleBackColor = false;
            this.btnKhaoThiXepLop.Click += new System.EventHandler(this.btnKhaoThiXepLop_Click);
            // 
            // lblNhom2
            // 
            this.lblNhom2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNhom2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblNhom2.Location = new System.Drawing.Point(24, 162);
            this.lblNhom2.Name = "lblNhom2";
            this.lblNhom2.Size = new System.Drawing.Size(230, 28);
            this.lblNhom2.TabIndex = 22;
            this.lblNhom2.Text = "VẬN HÀNH ĐÀO TẠO";
            this.lblNhom2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDanhSachLopHoc
            // 
            this.btnDanhSachLopHoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnDanhSachLopHoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDanhSachLopHoc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnDanhSachLopHoc.FlatAppearance.BorderSize = 0;
            this.btnDanhSachLopHoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnDanhSachLopHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhSachLopHoc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDanhSachLopHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnDanhSachLopHoc.Location = new System.Drawing.Point(14, 200);
            this.btnDanhSachLopHoc.Name = "btnDanhSachLopHoc";
            this.btnDanhSachLopHoc.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDanhSachLopHoc.Size = new System.Drawing.Size(232, 40);
            this.btnDanhSachLopHoc.TabIndex = 23;
            this.btnDanhSachLopHoc.Text = "🧑‍🏫  Danh sách Lớp học";
            this.btnDanhSachLopHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachLopHoc.UseVisualStyleBackColor = false;
            this.btnDanhSachLopHoc.Click += new System.EventHandler(this.btnDanhSachLopHoc_Click);
            // 
            // btnLichHocPhongHoc
            // 
            this.btnLichHocPhongHoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnLichHocPhongHoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLichHocPhongHoc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnLichHocPhongHoc.FlatAppearance.BorderSize = 0;
            this.btnLichHocPhongHoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnLichHocPhongHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLichHocPhongHoc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLichHocPhongHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnLichHocPhongHoc.Location = new System.Drawing.Point(14, 244);
            this.btnLichHocPhongHoc.Name = "btnLichHocPhongHoc";
            this.btnLichHocPhongHoc.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLichHocPhongHoc.Size = new System.Drawing.Size(232, 40);
            this.btnLichHocPhongHoc.TabIndex = 24;
            this.btnLichHocPhongHoc.Text = "📅  Lịch học && Phòng học";
            this.btnLichHocPhongHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLichHocPhongHoc.UseVisualStyleBackColor = false;
            this.btnLichHocPhongHoc.Click += new System.EventHandler(this.btnLichHocPhongHoc_Click);
            // 
            // lblNhom3
            // 
            this.lblNhom3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNhom3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblNhom3.Location = new System.Drawing.Point(24, 302);
            this.lblNhom3.Name = "lblNhom3";
            this.lblNhom3.Size = new System.Drawing.Size(230, 28);
            this.lblNhom3.TabIndex = 25;
            this.lblNhom3.Text = "TÀI CHÍNH && HỌC PHÍ";
            this.lblNhom3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnQuanLyHoaDon
            // 
            this.btnQuanLyHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnQuanLyHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuanLyHoaDon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnQuanLyHoaDon.FlatAppearance.BorderSize = 0;
            this.btnQuanLyHoaDon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnQuanLyHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnQuanLyHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnQuanLyHoaDon.Location = new System.Drawing.Point(14, 340);
            this.btnQuanLyHoaDon.Name = "btnQuanLyHoaDon";
            this.btnQuanLyHoaDon.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQuanLyHoaDon.Size = new System.Drawing.Size(232, 40);
            this.btnQuanLyHoaDon.TabIndex = 26;
            this.btnQuanLyHoaDon.Text = "🧾  Quản lý Hóa đơn";
            this.btnQuanLyHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyHoaDon.UseVisualStyleBackColor = false;
            this.btnQuanLyHoaDon.Click += new System.EventHandler(this.btnQuanLyHoaDon_Click);
            // 
            // lblNhom4
            // 
            this.lblNhom4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNhom4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblNhom4.Location = new System.Drawing.Point(24, 398);
            this.lblNhom4.Name = "lblNhom4";
            this.lblNhom4.Size = new System.Drawing.Size(230, 28);
            this.lblNhom4.TabIndex = 27;
            this.lblNhom4.Text = "CHĂM SÓC && THÔNG BÁO";
            this.lblNhom4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnThongBao
            // 
            this.btnThongBao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnThongBao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongBao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnThongBao.FlatAppearance.BorderSize = 0;
            this.btnThongBao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnThongBao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongBao.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnThongBao.Location = new System.Drawing.Point(14, 436);
            this.btnThongBao.Name = "btnThongBao";
            this.btnThongBao.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnThongBao.Size = new System.Drawing.Size(232, 40);
            this.btnThongBao.TabIndex = 28;
            this.btnThongBao.Text = "📧  Gửi Email / Thông báo";
            this.btnThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongBao.UseVisualStyleBackColor = false;
            this.btnThongBao.Click += new System.EventHandler(this.btnThongBao_Click);
            // 
            // pnlThuongHieu
            // 
            this.pnlThuongHieu.Controls.Add(this.lblLogo);
            this.pnlThuongHieu.Controls.Add(this.lblTenHeThong);
            this.pnlThuongHieu.Controls.Add(this.lblMoTa);
            this.pnlThuongHieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThuongHieu.Location = new System.Drawing.Point(0, 0);
            this.pnlThuongHieu.Name = "pnlThuongHieu";
            this.pnlThuongHieu.Size = new System.Drawing.Size(270, 100);
            this.pnlThuongHieu.TabIndex = 4;
            // 
            // lblLogo
            // 
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblLogo.Location = new System.Drawing.Point(22, 28);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(43, 42);
            this.lblLogo.TabIndex = 5;
            this.lblLogo.Text = "EC";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenHeThong
            // 
            this.lblTenHeThong.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTenHeThong.ForeColor = System.Drawing.Color.White;
            this.lblTenHeThong.Location = new System.Drawing.Point(75, 22);
            this.lblTenHeThong.Name = "lblTenHeThong";
            this.lblTenHeThong.Size = new System.Drawing.Size(190, 32);
            this.lblTenHeThong.TabIndex = 6;
            this.lblTenHeThong.Text = "ENGLISH CENTER";
            this.lblTenHeThong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMoTa
            // 
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblMoTa.Location = new System.Drawing.Point(76, 55);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(185, 24);
            this.lblMoTa.TabIndex = 7;
            this.lblMoTa.Text = "Quản lý trung tâm";
            this.lblMoTa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuTaiKhoan
            // 
            this.menuTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.menuTaiKhoan.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTaiKhoan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDoiMatKhau,
            this.mnuDangXuat});
            this.menuTaiKhoan.Name = "menuTaiKhoan";
            this.menuTaiKhoan.ShowImageMargin = false;
            this.menuTaiKhoan.Size = new System.Drawing.Size(191, 64);
            // 
            // mnuDoiMatKhau
            // 
            this.mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            this.mnuDoiMatKhau.Size = new System.Drawing.Size(190, 30);
            this.mnuDoiMatKhau.Text = "Đổi mật khẩu";
            this.mnuDoiMatKhau.Click += new System.EventHandler(this.mnuDoiMatKhau_Click);
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(190, 30);
            this.mnuDangXuat.Text = "Thoát tài khoản";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // frmMainNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.pnlVungChinh);
            this.Controls.Add(this.pnlMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(980, 650);
            this.Name = "frmMainNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "English Center — Nhân viên";
            this.pnlVungChinh.ResumeLayout(false);
            this.pnlNoiDung.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenuNoiDung.ResumeLayout(false);
            this.pnlThuongHieu.ResumeLayout(false);
            this.menuTaiKhoan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlVungChinh;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlMenuNoiDung;
        private System.Windows.Forms.Panel pnlThuongHieu;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblTenHeThong;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Panel pnlNoiDung;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnThuGonMenu;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.Label lblNguoiDangNhap;
        private System.Windows.Forms.Label lblChaoMung;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.ContextMenuStrip menuTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem mnuDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.Label lblNhom1;
        private System.Windows.Forms.Button btnHoSoHocVien;
        private System.Windows.Forms.Button btnKhaoThiXepLop;
        private System.Windows.Forms.Label lblNhom2;
        private System.Windows.Forms.Button btnDanhSachLopHoc;
        private System.Windows.Forms.Button btnLichHocPhongHoc;
        private System.Windows.Forms.Label lblNhom3;
        private System.Windows.Forms.Button btnQuanLyHoaDon;
        private System.Windows.Forms.Label lblNhom4;
        private System.Windows.Forms.Button btnThongBao;
    }
}