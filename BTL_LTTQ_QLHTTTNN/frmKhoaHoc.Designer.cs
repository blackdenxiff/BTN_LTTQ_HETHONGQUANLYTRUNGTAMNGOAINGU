namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmKhoaHoc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.btnTaoKhoaHocMoi = new System.Windows.Forms.Button();
            this.tblStats = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblValTongKH = new System.Windows.Forms.Label();
            this.lblTitleTongKH = new System.Windows.Forms.Label();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblValDangMo = new System.Windows.Forms.Label();
            this.lblTitleDangMo = new System.Windows.Forms.Label();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblValLopHD = new System.Windows.Forms.Label();
            this.lblTitleLopHD = new System.Windows.Forms.Label();
            this.pnlCard4 = new System.Windows.Forms.Panel();
            this.lblValTongBuoi = new System.Windows.Forms.Label();
            this.lblTitleTongBuoi = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cboTrinhDo = new System.Windows.Forms.ComboBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvKhoaHoc = new System.Windows.Forms.DataGridView();
            this.colMaKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenChuongTrinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChuanDauRa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThoiLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHocPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoTrinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThaoTac = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colXoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlHeader.SuspendLayout();
            this.tblStats.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoaHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnTaoKhoaHocMoi);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1262, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(519, 41);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Danh Mục Chương Trình & Khóa Học";
            this.lblTitle.UseMnemonic = false;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubTitle.Location = new System.Drawing.Point(22, 60);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(595, 21);
            this.lblSubTitle.TabIndex = 2;
            this.lblSubTitle.Text = "Quản lý các chương trình đào tạo chuẩn quốc tế, cấu trúc học phí và lộ trình đầu" +
    " ra";
            // 
            // btnTaoKhoaHocMoi
            // 
            this.btnTaoKhoaHocMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoKhoaHocMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnTaoKhoaHocMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoKhoaHocMoi.FlatAppearance.BorderSize = 0;
            this.btnTaoKhoaHocMoi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnTaoKhoaHocMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoKhoaHocMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTaoKhoaHocMoi.ForeColor = System.Drawing.Color.White;
            this.btnTaoKhoaHocMoi.Location = new System.Drawing.Point(1052, 28);
            this.btnTaoKhoaHocMoi.Name = "btnTaoKhoaHocMoi";
            this.btnTaoKhoaHocMoi.Size = new System.Drawing.Size(190, 44);
            this.btnTaoKhoaHocMoi.TabIndex = 3;
            this.btnTaoKhoaHocMoi.Text = "➕  Tạo Khóa Học Mới";
            this.btnTaoKhoaHocMoi.UseVisualStyleBackColor = false;
            this.btnTaoKhoaHocMoi.Click += new System.EventHandler(this.btnTaoKhoaHocMoi_Click);
            // 
            // tblStats
            // 
            this.tblStats.ColumnCount = 4;
            this.tblStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblStats.Controls.Add(this.pnlCard1, 0, 0);
            this.tblStats.Controls.Add(this.pnlCard2, 1, 0);
            this.tblStats.Controls.Add(this.pnlCard3, 2, 0);
            this.tblStats.Controls.Add(this.pnlCard4, 3, 0);
            this.tblStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblStats.Location = new System.Drawing.Point(0, 100);
            this.tblStats.Name = "tblStats";
            this.tblStats.Padding = new System.Windows.Forms.Padding(15, 15, 15, 10);
            this.tblStats.RowCount = 1;
            this.tblStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblStats.Size = new System.Drawing.Size(1262, 125);
            this.tblStats.TabIndex = 4;
            // 
            // pnlCard1
            // 
            this.pnlCard1.BackColor = System.Drawing.Color.White;
            this.pnlCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard1.Controls.Add(this.lblValTongKH);
            this.pnlCard1.Controls.Add(this.lblTitleTongKH);
            this.pnlCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard1.Location = new System.Drawing.Point(18, 18);
            this.pnlCard1.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(295, 94);
            this.pnlCard1.TabIndex = 0;
            // 
            // lblValTongKH
            // 
            this.lblValTongKH.AutoSize = true;
            this.lblValTongKH.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblValTongKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblValTongKH.Location = new System.Drawing.Point(20, 38);
            this.lblValTongKH.Name = "lblValTongKH";
            this.lblValTongKH.Size = new System.Drawing.Size(39, 46);
            this.lblValTongKH.TabIndex = 1;
            this.lblValTongKH.Text = "6";
            // 
            // lblTitleTongKH
            // 
            this.lblTitleTongKH.AutoSize = true;
            this.lblTitleTongKH.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleTongKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTitleTongKH.Location = new System.Drawing.Point(20, 14);
            this.lblTitleTongKH.Name = "lblTitleTongKH";
            this.lblTitleTongKH.Size = new System.Drawing.Size(130, 20);
            this.lblTitleTongKH.TabIndex = 0;
            this.lblTitleTongKH.Text = "TỔNG KHÓA HỌC";
            // 
            // pnlCard2
            // 
            this.pnlCard2.BackColor = System.Drawing.Color.White;
            this.pnlCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard2.Controls.Add(this.lblValDangMo);
            this.pnlCard2.Controls.Add(this.lblTitleDangMo);
            this.pnlCard2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard2.Location = new System.Drawing.Point(326, 18);
            this.pnlCard2.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(295, 94);
            this.pnlCard2.TabIndex = 1;
            // 
            // lblValDangMo
            // 
            this.lblValDangMo.AutoSize = true;
            this.lblValDangMo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblValDangMo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblValDangMo.Location = new System.Drawing.Point(20, 38);
            this.lblValDangMo.Name = "lblValDangMo";
            this.lblValDangMo.Size = new System.Drawing.Size(39, 46);
            this.lblValDangMo.TabIndex = 1;
            this.lblValDangMo.Text = "6";
            // 
            // lblTitleDangMo
            // 
            this.lblTitleDangMo.AutoSize = true;
            this.lblTitleDangMo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleDangMo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblTitleDangMo.Location = new System.Drawing.Point(20, 14);
            this.lblTitleDangMo.Name = "lblTitleDangMo";
            this.lblTitleDangMo.Size = new System.Drawing.Size(155, 20);
            this.lblTitleDangMo.TabIndex = 0;
            this.lblTitleDangMo.Text = "KHÓA ĐANG MỞ LỚP";
            // 
            // pnlCard3
            // 
            this.pnlCard3.BackColor = System.Drawing.Color.White;
            this.pnlCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard3.Controls.Add(this.lblValLopHD);
            this.pnlCard3.Controls.Add(this.lblTitleLopHD);
            this.pnlCard3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard3.Location = new System.Drawing.Point(634, 18);
            this.pnlCard3.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Size = new System.Drawing.Size(295, 94);
            this.pnlCard3.TabIndex = 2;
            // 
            // lblValLopHD
            // 
            this.lblValLopHD.AutoSize = true;
            this.lblValLopHD.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblValLopHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblValLopHD.Location = new System.Drawing.Point(20, 38);
            this.lblValLopHD.Name = "lblValLopHD";
            this.lblValLopHD.Size = new System.Drawing.Size(39, 46);
            this.lblValLopHD.TabIndex = 1;
            this.lblValLopHD.Text = "3";
            // 
            // lblTitleLopHD
            // 
            this.lblTitleLopHD.AutoSize = true;
            this.lblTitleLopHD.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleLopHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTitleLopHD.Location = new System.Drawing.Point(20, 14);
            this.lblTitleLopHD.Name = "lblTitleLopHD";
            this.lblTitleLopHD.Size = new System.Drawing.Size(171, 20);
            this.lblTitleLopHD.TabIndex = 0;
            this.lblTitleLopHD.Text = "LỚP ĐANG HOẠT ĐỘNG";
            // 
            // pnlCard4
            // 
            this.pnlCard4.BackColor = System.Drawing.Color.White;
            this.pnlCard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard4.Controls.Add(this.lblValTongBuoi);
            this.pnlCard4.Controls.Add(this.lblTitleTongBuoi);
            this.pnlCard4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard4.Location = new System.Drawing.Point(942, 18);
            this.pnlCard4.Name = "pnlCard4";
            this.pnlCard4.Size = new System.Drawing.Size(305, 94);
            this.pnlCard4.TabIndex = 3;
            // 
            // lblValTongBuoi
            // 
            this.lblValTongBuoi.AutoSize = true;
            this.lblValTongBuoi.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblValTongBuoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.lblValTongBuoi.Location = new System.Drawing.Point(20, 38);
            this.lblValTongBuoi.Name = "lblValTongBuoi";
            this.lblValTongBuoi.Size = new System.Drawing.Size(59, 46);
            this.lblValTongBuoi.TabIndex = 1;
            this.lblValTongBuoi.Text = "22";
            // 
            // lblTitleTongBuoi
            // 
            this.lblTitleTongBuoi.AutoSize = true;
            this.lblTitleTongBuoi.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleTongBuoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.lblTitleTongBuoi.Location = new System.Drawing.Point(20, 14);
            this.lblTitleTongBuoi.Name = "lblTitleTongBuoi";
            this.lblTitleTongBuoi.Size = new System.Drawing.Size(161, 20);
            this.lblTitleTongBuoi.TabIndex = 0;
            this.lblTitleTongBuoi.Text = "TỔNG BUỔI ĐÀO TẠO";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.btnReset);
            this.pnlFilter.Controls.Add(this.btnLoc);
            this.pnlFilter.Controls.Add(this.cboTrangThai);
            this.pnlFilter.Controls.Add(this.cboTrinhDo);
            this.pnlFilter.Controls.Add(this.txtTimKiem);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 225);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1262, 65);
            this.pnlFilter.TabIndex = 5;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.txtTimKiem.Location = new System.Drawing.Point(20, 17);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(380, 30);
            this.txtTimKiem.TabIndex = 0;
            // 
            // cboTrinhDo
            // 
            this.cboTrinhDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrinhDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrinhDo.FormattingEnabled = true;
            this.cboTrinhDo.Location = new System.Drawing.Point(415, 16);
            this.cboTrinhDo.Name = "cboTrinhDo";
            this.cboTrinhDo.Size = new System.Drawing.Size(200, 31);
            this.cboTrinhDo.TabIndex = 1;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(630, 16);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(200, 31);
            this.cboTrangThai.TabIndex = 2;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnLoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(845, 15);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(100, 33);
            this.btnLoc.TabIndex = 3;
            this.btnLoc.Text = "🔍  Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReset.Location = new System.Drawing.Point(955, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(45, 33);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "🔄";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvKhoaHoc
            // 
            this.dgvKhoaHoc.AllowUserToAddRows = false;
            this.dgvKhoaHoc.AllowUserToDeleteRows = false;
            this.dgvKhoaHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoaHoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhoaHoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKhoaHoc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKhoaHoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhoaHoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKhoaHoc.ColumnHeadersHeight = 45;
            this.dgvKhoaHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaKhoa,
            this.colTenChuongTrinh,
            this.colChuanDauRa,
            this.colThoiLuong,
            this.colHocPhi,
            this.colLoTrinh,
            this.colTrangThai,
            this.colThaoTac,
            this.colXoa});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKhoaHoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKhoaHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhoaHoc.EnableHeadersVisualStyles = false;
            this.dgvKhoaHoc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvKhoaHoc.Location = new System.Drawing.Point(0, 290);
            this.dgvKhoaHoc.Name = "dgvKhoaHoc";
            this.dgvKhoaHoc.ReadOnly = true;
            this.dgvKhoaHoc.RowHeadersVisible = false;
            this.dgvKhoaHoc.RowHeadersWidth = 51;
            this.dgvKhoaHoc.RowTemplate.Height = 45;
            this.dgvKhoaHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoaHoc.Size = new System.Drawing.Size(1262, 451);
            this.dgvKhoaHoc.TabIndex = 6;
            this.dgvKhoaHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhoaHoc_CellClick);
            // 
            // colMaKhoa
            // 
            this.colMaKhoa.HeaderText = "MÃ KHÓA";
            this.colMaKhoa.Name = "colMaKhoa";
            this.colMaKhoa.ReadOnly = true;
            // 
            // colTenChuongTrinh
            // 
            this.colTenChuongTrinh.HeaderText = "TÊN CHƯƠNG TRÌNH ĐÀO TẠO";
            this.colTenChuongTrinh.Name = "colTenChuongTrinh";
            this.colTenChuongTrinh.ReadOnly = true;
            // 
            // colChuanDauRa
            // 
            this.colChuanDauRa.HeaderText = "CHUẨN ĐẦU RA";
            this.colChuanDauRa.Name = "colChuanDauRa";
            this.colChuanDauRa.ReadOnly = true;
            // 
            // colThoiLuong
            // 
            this.colThoiLuong.HeaderText = "THỜI LƯỢNG";
            this.colThoiLuong.Name = "colThoiLuong";
            this.colThoiLuong.ReadOnly = true;
            // 
            // colHocPhi
            // 
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.colHocPhi.DefaultCellStyle = dataGridViewCellStyle3;
            this.colHocPhi.HeaderText = "HỌC PHÍ NIÊM YẾT";
            this.colHocPhi.Name = "colHocPhi";
            this.colHocPhi.ReadOnly = true;
            // 
            // colLoTrinh
            // 
            this.colLoTrinh.HeaderText = "LỘ TRÌNH TÓM TẮT";
            this.colLoTrinh.Name = "colLoTrinh";
            this.colLoTrinh.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.HeaderText = "TRẠNG THÁI";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // colThaoTac
            // 
            this.colThaoTac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colThaoTac.HeaderText = "SỬA";
            this.colThaoTac.Name = "colThaoTac";
            this.colThaoTac.ReadOnly = true;
            this.colThaoTac.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colThaoTac.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colThaoTac.Text = "✏️ Sửa";
            this.colThaoTac.UseColumnTextForButtonValue = true;
            // 
            // colXoa
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.colXoa.DefaultCellStyle = dataGridViewCellStyle4;
            this.colXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colXoa.HeaderText = "XÓA";
            this.colXoa.Name = "colXoa";
            this.colXoa.ReadOnly = true;
            this.colXoa.Text = "🗑️ Xóa";
            this.colXoa.UseColumnTextForButtonValue = true;
            // 
            // frmKhoaHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1262, 741);
            this.Controls.Add(this.dgvKhoaHoc);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.tblStats);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmKhoaHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Chương Trình & Khóa Học";
            this.Load += new System.EventHandler(this.frmKhoaHoc_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tblStats.ResumeLayout(false);
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.pnlCard4.ResumeLayout(false);
            this.pnlCard4.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoaHoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Button btnTaoKhoaHocMoi;
        private System.Windows.Forms.TableLayoutPanel tblStats;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblValTongKH;
        private System.Windows.Forms.Label lblTitleTongKH;
        private System.Windows.Forms.Label lblValDangMo;
        private System.Windows.Forms.Label lblTitleDangMo;
        private System.Windows.Forms.Label lblValLopHD;
        private System.Windows.Forms.Label lblTitleLopHD;
        private System.Windows.Forms.Label lblValTongBuoi;
        private System.Windows.Forms.Label lblTitleTongBuoi;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.ComboBox cboTrinhDo;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvKhoaHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenChuongTrinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChuanDauRa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoiLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHocPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoTrinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewButtonColumn colThaoTac;
        private System.Windows.Forms.DataGridViewButtonColumn colXoa;
    }
}