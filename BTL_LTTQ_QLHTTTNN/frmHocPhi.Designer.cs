namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmHocPhi
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblSubTieuDe = new System.Windows.Forms.Label();
            this.btnLapPhieuThu = new System.Windows.Forms.Button();
            this.pnlCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblCard1Title = new System.Windows.Forms.Label();
            this.lblTongPhaiNop = new System.Windows.Forms.Label();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblCard2Title = new System.Windows.Forms.Label();
            this.lblDaThanhToan = new System.Windows.Forms.Label();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblCard3Title = new System.Windows.Forms.Label();
            this.lblConPhaiDong = new System.Windows.Forms.Label();
            this.pnlCard4 = new System.Windows.Forms.Panel();
            this.lblCard4Title = new System.Windows.Forms.Label();
            this.lblChuaThanhToanCount = new System.Windows.Forms.Label();
            this.pnlFilterBar = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvHocPhi = new System.Windows.Forms.DataGridView();
            this.colMaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHocVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhoanThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiamGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhaiThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThaoTac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            this.pnlFilterBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocPhi)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnLapPhieuThu);
            this.pnlHeader.Controls.Add(this.lblSubTieuDe);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(15, 15);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1120, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(431, 37);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Thông Tin Hóa Đơn && Học Phí";
            // 
            // lblSubTieuDe
            // 
            this.lblSubTieuDe.AutoSize = true;
            this.lblSubTieuDe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSubTieuDe.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTieuDe.Location = new System.Drawing.Point(3, 40);
            this.lblSubTieuDe.Name = "lblSubTieuDe";
            this.lblSubTieuDe.Size = new System.Drawing.Size(438, 20);
            this.lblSubTieuDe.TabIndex = 1;
            this.lblSubTieuDe.Text = "Theo dõi lịch sử giao dịch thanh toán và số tiền học phí còn phải đóng";
            // 
            // btnLapPhieuThu
            // 
            this.btnLapPhieuThu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLapPhieuThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnLapPhieuThu.FlatAppearance.BorderSize = 0;
            this.btnLapPhieuThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLapPhieuThu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLapPhieuThu.ForeColor = System.Drawing.Color.White;
            this.btnLapPhieuThu.Location = new System.Drawing.Point(965, 10);
            this.btnLapPhieuThu.Name = "btnLapPhieuThu";
            this.btnLapPhieuThu.Size = new System.Drawing.Size(155, 42);
            this.btnLapPhieuThu.TabIndex = 2;
            this.btnLapPhieuThu.Text = "➕ Lập Phiếu Thu";
            this.btnLapPhieuThu.UseVisualStyleBackColor = false;
            this.btnLapPhieuThu.Click += new System.EventHandler(this.btnLapPhieuThu_Click);
            // 
            // pnlCards
            // 
            this.pnlCards.ColumnCount = 4;
            this.pnlCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlCards.Controls.Add(this.pnlCard1, 0, 0);
            this.pnlCards.Controls.Add(this.pnlCard2, 1, 0);
            this.pnlCards.Controls.Add(this.pnlCard3, 2, 0);
            this.pnlCards.Controls.Add(this.pnlCard4, 3, 0);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(15, 85);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.RowCount = 1;
            this.pnlCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlCards.Size = new System.Drawing.Size(1120, 95);
            this.pnlCards.TabIndex = 1;
            // 
            // pnlCard1
            // 
            this.pnlCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard1.Controls.Add(this.lblTongPhaiNop);
            this.pnlCard1.Controls.Add(this.lblCard1Title);
            this.pnlCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard1.Location = new System.Drawing.Point(3, 3);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Padding = new System.Windows.Forms.Padding(12);
            this.pnlCard1.Size = new System.Drawing.Size(274, 89);
            this.pnlCard1.TabIndex = 0;
            // 
            // lblCard1Title
            // 
            this.lblCard1Title.AutoSize = true;
            this.lblCard1Title.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCard1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblCard1Title.Location = new System.Drawing.Point(10, 10);
            this.lblCard1Title.Name = "lblCard1Title";
            this.lblCard1Title.Size = new System.Drawing.Size(161, 19);
            this.lblCard1Title.TabIndex = 0;
            this.lblCard1Title.Text = "TỔNG HỌC PHÍ PHẢI NỘP";
            // 
            // lblTongPhaiNop
            // 
            this.lblTongPhaiNop.AutoSize = true;
            this.lblTongPhaiNop.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongPhaiNop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTongPhaiNop.Location = new System.Drawing.Point(10, 36);
            this.lblTongPhaiNop.Name = "lblTongPhaiNop";
            this.lblTongPhaiNop.Size = new System.Drawing.Size(60, 32);
            this.lblTongPhaiNop.TabIndex = 1;
            this.lblTongPhaiNop.Text = "0 đ";
            // 
            // pnlCard2
            // 
            this.pnlCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard2.Controls.Add(this.lblDaThanhToan);
            this.pnlCard2.Controls.Add(this.lblCard2Title);
            this.pnlCard2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard2.Location = new System.Drawing.Point(283, 3);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Padding = new System.Windows.Forms.Padding(12);
            this.pnlCard2.Size = new System.Drawing.Size(274, 89);
            this.pnlCard2.TabIndex = 1;
            // 
            // lblCard2Title
            // 
            this.lblCard2Title.AutoSize = true;
            this.lblCard2Title.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCard2Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.lblCard2Title.Location = new System.Drawing.Point(10, 10);
            this.lblCard2Title.Name = "lblCard2Title";
            this.lblCard2Title.Size = new System.Drawing.Size(126, 19);
            this.lblCard2Title.TabIndex = 0;
            this.lblCard2Title.Text = "ĐÃ THANH TOÁN";
            // 
            // lblDaThanhToan
            // 
            this.lblDaThanhToan.AutoSize = true;
            this.lblDaThanhToan.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDaThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.lblDaThanhToan.Location = new System.Drawing.Point(10, 36);
            this.lblDaThanhToan.Name = "lblDaThanhToan";
            this.lblDaThanhToan.Size = new System.Drawing.Size(60, 32);
            this.lblDaThanhToan.TabIndex = 1;
            this.lblDaThanhToan.Text = "0 đ";
            // 
            // pnlCard3
            // 
            this.pnlCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard3.Controls.Add(this.lblConPhaiDong);
            this.pnlCard3.Controls.Add(this.lblCard3Title);
            this.pnlCard3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard3.Location = new System.Drawing.Point(563, 3);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Padding = new System.Windows.Forms.Padding(12);
            this.pnlCard3.Size = new System.Drawing.Size(274, 89);
            this.pnlCard3.TabIndex = 2;
            // 
            // lblCard3Title
            // 
            this.lblCard3Title.AutoSize = true;
            this.lblCard3Title.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCard3Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblCard3Title.Location = new System.Drawing.Point(10, 10);
            this.lblCard3Title.Name = "lblCard3Title";
            this.lblCard3Title.Size = new System.Drawing.Size(161, 19);
            this.lblCard3Title.TabIndex = 0;
            this.lblCard3Title.Text = "SỐ TIỀN CÒN PHẢI ĐÓNG";
            // 
            // lblConPhaiDong
            // 
            this.lblConPhaiDong.AutoSize = true;
            this.lblConPhaiDong.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblConPhaiDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblConPhaiDong.Location = new System.Drawing.Point(10, 36);
            this.lblConPhaiDong.Name = "lblConPhaiDong";
            this.lblConPhaiDong.Size = new System.Drawing.Size(60, 32);
            this.lblConPhaiDong.TabIndex = 1;
            this.lblConPhaiDong.Text = "0 đ";
            // 
            // pnlCard4
            // 
            this.pnlCard4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlCard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard4.Controls.Add(this.lblChuaThanhToanCount);
            this.pnlCard4.Controls.Add(this.lblCard4Title);
            this.pnlCard4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard4.Location = new System.Drawing.Point(843, 3);
            this.pnlCard4.Name = "pnlCard4";
            this.pnlCard4.Padding = new System.Windows.Forms.Padding(12);
            this.pnlCard4.Size = new System.Drawing.Size(274, 89);
            this.pnlCard4.TabIndex = 3;
            // 
            // lblCard4Title
            // 
            this.lblCard4Title.AutoSize = true;
            this.lblCard4Title.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCard4Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lblCard4Title.Location = new System.Drawing.Point(10, 10);
            this.lblCard4Title.Name = "lblCard4Title";
            this.lblCard4Title.Size = new System.Drawing.Size(180, 19);
            this.lblCard4Title.TabIndex = 0;
            this.lblCard4Title.Text = "HÓA ĐƠN CHƯA THANH TOÁN";
            // 
            // lblChuaThanhToanCount
            // 
            this.lblChuaThanhToanCount.AutoSize = true;
            this.lblChuaThanhToanCount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblChuaThanhToanCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblChuaThanhToanCount.Location = new System.Drawing.Point(10, 36);
            this.lblChuaThanhToanCount.Name = "lblChuaThanhToanCount";
            this.lblChuaThanhToanCount.Size = new System.Drawing.Size(28, 32);
            this.lblChuaThanhToanCount.TabIndex = 1;
            this.lblChuaThanhToanCount.Text = "0";
            // 
            // pnlFilterBar
            // 
            this.pnlFilterBar.Controls.Add(this.btnReset);
            this.pnlFilterBar.Controls.Add(this.btnLoc);
            this.pnlFilterBar.Controls.Add(this.cboTrangThai);
            this.pnlFilterBar.Controls.Add(this.txtTimKiem);
            this.pnlFilterBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilterBar.Location = new System.Drawing.Point(15, 180);
            this.pnlFilterBar.Name = "pnlFilterBar";
            this.pnlFilterBar.Size = new System.Drawing.Size(1120, 60);
            this.pnlFilterBar.TabIndex = 2;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.Location = new System.Drawing.Point(0, 15);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(420, 30);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.Text = "Tìm theo mã HĐ, tên học viên, SĐT...";
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
            this.txtTimKiem.Leave += new System.EventHandler(this.txtTimKiem_Leave);
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(435, 15);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(230, 31);
            this.cboTrangThai.TabIndex = 1;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(680, 13);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(110, 34);
            this.btnLoc.TabIndex = 2;
            this.btnLoc.Text = "Y Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnReset.Location = new System.Drawing.Point(800, 13);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(40, 34);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "↺";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvHocPhi
            // 
            this.dgvHocPhi.AllowUserToAddRows = false;
            this.dgvHocPhi.AllowUserToDeleteRows = false;
            this.dgvHocPhi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHocPhi.BackgroundColor = System.Drawing.Color.White;
            this.dgvHocPhi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHocPhi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHocPhi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHocPhi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHD,
            this.colHocVien,
            this.colKhoanThu,
            this.colNgayLap,
            this.colTongTien,
            this.colGiamGia,
            this.colPhaiThu,
            this.colTrangThai,
            this.colThaoTac});
            this.dgvHocPhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHocPhi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvHocPhi.Location = new System.Drawing.Point(15, 240);
            this.dgvHocPhi.Name = "dgvHocPhi";
            this.dgvHocPhi.ReadOnly = true;
            this.dgvHocPhi.RowHeadersVisible = false;
            this.dgvHocPhi.RowHeadersWidth = 51;
            this.dgvHocPhi.RowTemplate.Height = 65;
            this.dgvHocPhi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHocPhi.Size = new System.Drawing.Size(1120, 420);
            this.dgvHocPhi.TabIndex = 3;
            this.dgvHocPhi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHocPhi_CellClick);
            this.dgvHocPhi.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvHocPhi_CellPainting);
            // 
            // colMaHD
            // 
            this.colMaHD.FillWeight = 80F;
            this.colMaHD.HeaderText = "MÃ HĐ";
            this.colMaHD.Name = "colMaHD";
            this.colMaHD.ReadOnly = true;
            // 
            // colHocVien
            // 
            this.colHocVien.FillWeight = 160F;
            this.colHocVien.HeaderText = "HỌC VIÊN";
            this.colHocVien.Name = "colHocVien";
            this.colHocVien.ReadOnly = true;
            // 
            // colKhoanThu
            // 
            this.colKhoanThu.FillWeight = 140F;
            this.colKhoanThu.HeaderText = "KHOẢN THU (LỚP HỌC)";
            this.colKhoanThu.Name = "colKhoanThu";
            this.colKhoanThu.ReadOnly = true;
            // 
            // colNgayLap
            // 
            this.colNgayLap.FillWeight = 90F;
            this.colNgayLap.HeaderText = "NGÀY LẬP";
            this.colNgayLap.Name = "colNgayLap";
            this.colNgayLap.ReadOnly = true;
            // 
            // colTongTien
            // 
            this.colTongTien.FillWeight = 100F;
            this.colTongTien.HeaderText = "TỔNG TIỀN";
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.ReadOnly = true;
            // 
            // colGiamGia
            // 
            this.colGiamGia.FillWeight = 80F;
            this.colGiamGia.HeaderText = "GIẢM GIÁ";
            this.colGiamGia.Name = "colGiamGia";
            this.colGiamGia.ReadOnly = true;
            // 
            // colPhaiThu
            // 
            this.colPhaiThu.FillWeight = 100F;
            this.colPhaiThu.HeaderText = "PHẢI THU";
            this.colPhaiThu.Name = "colPhaiThu";
            this.colPhaiThu.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.FillWeight = 130F;
            this.colTrangThai.HeaderText = "TRẠNG THÁI";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // colThaoTac
            // 
            this.colThaoTac.FillWeight = 60F;
            this.colThaoTac.HeaderText = "THAO TÁC";
            this.colThaoTac.Name = "colThaoTac";
            this.colThaoTac.ReadOnly = true;
            // 
            // frmHocPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1150, 675);
            this.Controls.Add(this.dgvHocPhi);
            this.Controls.Add(this.pnlFilterBar);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.Name = "frmHocPhi";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Hóa Đơn & Học Phí";
            this.Load += new System.EventHandler(this.frmHocPhi_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.pnlCard4.ResumeLayout(false);
            this.pnlCard4.PerformLayout();
            this.pnlFilterBar.ResumeLayout(false);
            this.pnlFilterBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocPhi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblSubTieuDe;
        private System.Windows.Forms.Button btnLapPhieuThu;
        private System.Windows.Forms.TableLayoutPanel pnlCards;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblCard1Title;
        private System.Windows.Forms.Label lblTongPhaiNop;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblCard2Title;
        private System.Windows.Forms.Label lblDaThanhToan;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblCard3Title;
        private System.Windows.Forms.Label lblConPhaiDong;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblCard4Title;
        private System.Windows.Forms.Label lblChuaThanhToanCount;
        private System.Windows.Forms.Panel pnlFilterBar;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvHocPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHocVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKhoanThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiamGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhaiThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThaoTac;
    }
}