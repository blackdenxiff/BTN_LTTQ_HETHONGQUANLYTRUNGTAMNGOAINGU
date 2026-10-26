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
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.btnTaoKhoaHocMoi);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1262, 150);
            this.pnlHeader.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(487, 37);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Danh Mục Chương Trình & Khóa Học";
            this.lblTitle.UseMnemonic = false;
            //
            // lblSubTitle
            //
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTitle.Location = new System.Drawing.Point(16, 75);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(547, 18);
            this.lblSubTitle.TabIndex = 2;
            this.lblSubTitle.Text = "Quản lý các chương trình đào tạo chuẩn quốc tế, cấu trúc học phí và lộ trình đầu ra";
            //
            // btnTaoKhoaHocMoi
            //
            this.btnTaoKhoaHocMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoKhoaHocMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnTaoKhoaHocMoi.ForeColor = System.Drawing.Color.White;
            this.btnTaoKhoaHocMoi.Location = new System.Drawing.Point(1089, 45);
            this.btnTaoKhoaHocMoi.Name = "btnTaoKhoaHocMoi";
            this.btnTaoKhoaHocMoi.Size = new System.Drawing.Size(161, 41);
            this.btnTaoKhoaHocMoi.TabIndex = 3;
            this.btnTaoKhoaHocMoi.Text = "+ Tạo Khóa Học Mới";
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
            this.tblStats.Location = new System.Drawing.Point(0, 150);
            this.tblStats.Name = "tblStats";
            this.tblStats.RowCount = 1;
            this.tblStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblStats.Size = new System.Drawing.Size(1262, 138);
            this.tblStats.TabIndex = 4;
            //
            // pnlCard1
            //
            this.pnlCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard1.Controls.Add(this.lblValTongKH);
            this.pnlCard1.Controls.Add(this.lblTitleTongKH);
            this.pnlCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard1.Location = new System.Drawing.Point(3, 3);
            this.pnlCard1.Name = "pnlCard1";
            this.pnlCard1.Size = new System.Drawing.Size(309, 132);
            this.pnlCard1.TabIndex = 0;
            //
            // lblValTongKH
            //
            this.lblValTongKH.AutoSize = true;
            this.lblValTongKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblValTongKH.Location = new System.Drawing.Point(85, 51);
            this.lblValTongKH.Name = "lblValTongKH";
            this.lblValTongKH.Size = new System.Drawing.Size(33, 36);
            this.lblValTongKH.TabIndex = 1;
            this.lblValTongKH.Text = "6";
            //
            // lblTitleTongKH
            //
            this.lblTitleTongKH.AutoSize = true;
            this.lblTitleTongKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblTitleTongKH.ForeColor = System.Drawing.Color.Black;
            this.lblTitleTongKH.Location = new System.Drawing.Point(50, 17);
            this.lblTitleTongKH.Name = "lblTitleTongKH";
            this.lblTitleTongKH.Size = new System.Drawing.Size(126, 17);
            this.lblTitleTongKH.TabIndex = 0;
            this.lblTitleTongKH.Text = "TỔNG KHÓA HỌC";
            //
            // pnlCard2
            //
            this.pnlCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard2.Controls.Add(this.lblValDangMo);
            this.pnlCard2.Controls.Add(this.lblTitleDangMo);
            this.pnlCard2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard2.Location = new System.Drawing.Point(318, 3);
            this.pnlCard2.Name = "pnlCard2";
            this.pnlCard2.Size = new System.Drawing.Size(309, 132);
            this.pnlCard2.TabIndex = 1;
            //
            // lblValDangMo
            //
            this.lblValDangMo.AutoSize = true;
            this.lblValDangMo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblValDangMo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.lblValDangMo.Location = new System.Drawing.Point(93, 51);
            this.lblValDangMo.Name = "lblValDangMo";
            this.lblValDangMo.Size = new System.Drawing.Size(33, 36);
            this.lblValDangMo.TabIndex = 1;
            this.lblValDangMo.Text = "6";
            //
            // lblTitleDangMo
            //
            this.lblTitleDangMo.AutoSize = true;
            this.lblTitleDangMo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblTitleDangMo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.lblTitleDangMo.Location = new System.Drawing.Point(80, 17);
            this.lblTitleDangMo.Name = "lblTitleDangMo";
            this.lblTitleDangMo.Size = new System.Drawing.Size(65, 17);
            this.lblTitleDangMo.TabIndex = 0;
            this.lblTitleDangMo.Text = "Đang Mở";
            //
            // pnlCard3
            //
            this.pnlCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard3.Controls.Add(this.lblValLopHD);
            this.pnlCard3.Controls.Add(this.lblTitleLopHD);
            this.pnlCard3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard3.Location = new System.Drawing.Point(633, 3);
            this.pnlCard3.Name = "pnlCard3";
            this.pnlCard3.Size = new System.Drawing.Size(309, 132);
            this.pnlCard3.TabIndex = 2;
            //
            // lblValLopHD
            //
            this.lblValLopHD.AutoSize = true;
            this.lblValLopHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblValLopHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.lblValLopHD.Location = new System.Drawing.Point(115, 51);
            this.lblValLopHD.Name = "lblValLopHD";
            this.lblValLopHD.Size = new System.Drawing.Size(33, 36);
            this.lblValLopHD.TabIndex = 1;
            this.lblValLopHD.Text = "3";
            //
            // lblTitleLopHD
            //
            this.lblTitleLopHD.AutoSize = true;
            this.lblTitleLopHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblTitleLopHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.lblTitleLopHD.Location = new System.Drawing.Point(50, 17);
            this.lblTitleLopHD.Name = "lblTitleLopHD";
            this.lblTitleLopHD.Size = new System.Drawing.Size(169, 17);
            this.lblTitleLopHD.TabIndex = 0;
            this.lblTitleLopHD.Text = "LỚP ĐANG HOẠT ĐỘNG";
            //
            // pnlCard4
            //
            this.pnlCard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard4.Controls.Add(this.lblValTongBuoi);
            this.pnlCard4.Controls.Add(this.lblTitleTongBuoi);
            this.pnlCard4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard4.Location = new System.Drawing.Point(948, 3);
            this.pnlCard4.Name = "pnlCard4";
            this.pnlCard4.Size = new System.Drawing.Size(311, 132);
            this.pnlCard4.TabIndex = 3;
            //
            // lblValTongBuoi
            //
            this.lblValTongBuoi.AutoSize = true;
            this.lblValTongBuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblValTongBuoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(202)))), ((int)(((byte)(240)))));
            this.lblValTongBuoi.Location = new System.Drawing.Point(120, 51);
            this.lblValTongBuoi.Name = "lblValTongBuoi";
            this.lblValTongBuoi.Size = new System.Drawing.Size(51, 36);
            this.lblValTongBuoi.TabIndex = 1;
            this.lblValTongBuoi.Text = "22";
            //
            // lblTitleTongBuoi
            //
            this.lblTitleTongBuoi.AutoSize = true;
            this.lblTitleTongBuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblTitleTongBuoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(202)))), ((int)(((byte)(240)))));
            this.lblTitleTongBuoi.Location = new System.Drawing.Point(74, 17);
            this.lblTitleTongBuoi.Name = "lblTitleTongBuoi";
            this.lblTitleTongBuoi.Size = new System.Drawing.Size(153, 17);
            this.lblTitleTongBuoi.TabIndex = 0;
            this.lblTitleTongBuoi.Text = "TỔNG BUỔI ĐÀO TẠO";
            //
            // pnlFilter
            //
            this.pnlFilter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilter.Controls.Add(this.btnReset);
            this.pnlFilter.Controls.Add(this.btnLoc);
            this.pnlFilter.Controls.Add(this.cboTrangThai);
            this.pnlFilter.Controls.Add(this.cboTrinhDo);
            this.pnlFilter.Controls.Add(this.txtTimKiem);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 288);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1262, 60);
            this.pnlFilter.TabIndex = 5;
            //
            // txtTimKiem
            //
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(12, 15);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(396, 30);
            this.txtTimKiem.TabIndex = 0;
            //
            // cboTrinhDo
            //
            this.cboTrinhDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrinhDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboTrinhDo.FormattingEnabled = true;
            this.cboTrinhDo.Location = new System.Drawing.Point(425, 17);
            this.cboTrinhDo.Name = "cboTrinhDo";
            this.cboTrinhDo.Size = new System.Drawing.Size(180, 28);
            this.cboTrinhDo.TabIndex = 1;
            //
            // cboTrangThai
            //
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(620, 17);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(180, 28);
            this.cboTrangThai.TabIndex = 2;
            //
            // btnLoc
            //
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(815, 15);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(90, 32);
            this.btnLoc.TabIndex = 3;
            this.btnLoc.Text = "🔍 Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            //
            // btnReset
            //
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(915, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(45, 32);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "🔄";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            //
            // dgvKhoaHoc
            //
            this.dgvKhoaHoc.AutoGenerateColumns = false;
            this.dgvKhoaHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoaHoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhoaHoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKhoaHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            this.dgvKhoaHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhoaHoc.Location = new System.Drawing.Point(0, 348);
            this.dgvKhoaHoc.Name = "dgvKhoaHoc";
            this.dgvKhoaHoc.RowHeadersVisible = false;
            this.dgvKhoaHoc.RowHeadersWidth = 51;
            this.dgvKhoaHoc.RowTemplate.Height = 40;
            this.dgvKhoaHoc.Size = new System.Drawing.Size(1262, 393);
            this.dgvKhoaHoc.TabIndex = 6;
            this.dgvKhoaHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhoaHoc_CellClick);
            //
            // colMaKhoa
            //
            this.colMaKhoa.HeaderText = "MÃ KHÓA";
            this.colMaKhoa.Name = "colMaKhoa";
            this.colMaKhoa.DataPropertyName = "MaKhoaHoc";
            this.colMaKhoa.FillWeight = 50F;
            this.colMaKhoa.ReadOnly = true;
            //
            // colTenChuongTrinh
            //
            this.colTenChuongTrinh.HeaderText = "TÊN CHƯƠNG TRÌNH ĐÀO TẠO";
            this.colTenChuongTrinh.Name = "colTenChuongTrinh";
            this.colTenChuongTrinh.DataPropertyName = "TenKhoaHoc";
            this.colTenChuongTrinh.FillWeight = 160F;
            this.colTenChuongTrinh.ReadOnly = true;
            //
            // colChuanDauRa
            //
            this.colChuanDauRa.HeaderText = "CHUẨN ĐẦU RA";
            this.colChuanDauRa.Name = "colChuanDauRa";
            this.colChuanDauRa.DataPropertyName = "ChuanDauRa";
            this.colChuanDauRa.FillWeight = 80F;
            this.colChuanDauRa.ReadOnly = true;
            //
            // colThoiLuong
            //
            this.colThoiLuong.HeaderText = "THỜI LƯỢNG";
            this.colThoiLuong.Name = "colThoiLuong";
            this.colThoiLuong.DataPropertyName = "ThoiLuong";
            this.colThoiLuong.FillWeight = 60F;
            this.colThoiLuong.ReadOnly = true;
            //
            // colHocPhi
            //
            this.colHocPhi.HeaderText = "HỌC PHÍ NIÊM YẾT";
            this.colHocPhi.Name = "colHocPhi";
            this.colHocPhi.DataPropertyName = "HocPhi";
            this.colHocPhi.FillWeight = 90F;
            this.colHocPhi.ReadOnly = true;
            //
            // colLoTrinh
            //
            this.colLoTrinh.HeaderText = "LỘ TRÌNH TÓM TẮT";
            this.colLoTrinh.Name = "colLoTrinh";
            this.colLoTrinh.DataPropertyName = "LoTrinh";
            this.colLoTrinh.FillWeight = 160F;
            this.colLoTrinh.ReadOnly = true;
            //
            // colTrangThai
            //
            this.colTrangThai.HeaderText = "TRẠNG THÁI";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.DataPropertyName = "TrangThai";
            this.colTrangThai.FillWeight = 80F;
            this.colTrangThai.ReadOnly = true;
            //
            // colThaoTac
            //
            this.colThaoTac.HeaderText = "THAO TÁC";
            this.colThaoTac.Name = "colThaoTac";
            this.colThaoTac.FillWeight = 60F;
            this.colThaoTac.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colThaoTac.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colThaoTac.Text = "Sửa";
            this.colThaoTac.UseColumnTextForButtonValue = true;
            //
            // colXoa
            //
            this.colXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colXoa.HeaderText = "XÓA";
            this.colXoa.Name = "colXoa";
            this.colXoa.ReadOnly = true;
            this.colXoa.Text = "Xóa";
            this.colXoa.UseColumnTextForButtonValue = true;
            //
            // frmKhoaHoc
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
