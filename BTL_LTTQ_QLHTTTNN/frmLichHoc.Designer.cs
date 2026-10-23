namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmLichHoc
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
            this.cboFilterLop = new System.Windows.Forms.ComboBox();
            this.btnPrevWeek = new System.Windows.Forms.Button();
            this.btnWeek = new System.Windows.Forms.Button();
            this.btnNextWeek = new System.Windows.Forms.Button();
            this.btnXepLichHocMoi = new System.Windows.Forms.Button();
            this.dgvLichHoc = new System.Windows.Forms.DataGridView();
            this.colKhungGio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnXepLichHocMoi);
            this.pnlHeader.Controls.Add(this.btnNextWeek);
            this.pnlHeader.Controls.Add(this.btnWeek);
            this.pnlHeader.Controls.Add(this.btnPrevWeek);
            this.pnlHeader.Controls.Add(this.cboFilterLop);
            this.pnlHeader.Controls.Add(this.lblSubTieuDe);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(15, 15);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1020, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(433, 37);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Thời Khóa Biểu & Quản Lý Phòng Học";
            // 
            // lblSubTieuDe
            // 
            this.lblSubTieuDe.AutoSize = true;
            this.lblSubTieuDe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSubTieuDe.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTieuDe.Location = new System.Drawing.Point(3, 40);
            this.lblSubTieuDe.Name = "lblSubTieuDe";
            this.lblSubTieuDe.Size = new System.Drawing.Size(273, 20);
            this.lblSubTieuDe.TabIndex = 1;
            this.lblSubTieuDe.Text = "Theo dõi lịch đào tạo theo tuần từ SQL Server";
            // 
            // cboFilterLop
            // 
            this.cboFilterLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilterLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterLop.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFilterLop.FormattingEnabled = true;
            this.cboFilterLop.Location = new System.Drawing.Point(470, 15);
            this.cboFilterLop.Name = "cboFilterLop";
            this.cboFilterLop.Size = new System.Drawing.Size(180, 29);
            this.cboFilterLop.TabIndex = 2;
            this.cboFilterLop.SelectedIndexChanged += new System.EventHandler(this.cboFilterLop_SelectedIndexChanged);
            // 
            // btnPrevWeek
            // 
            this.btnPrevWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevWeek.BackColor = System.Drawing.Color.White;
            this.btnPrevWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevWeek.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrevWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnPrevWeek.Location = new System.Drawing.Point(660, 14);
            this.btnPrevWeek.Name = "btnPrevWeek";
            this.btnPrevWeek.Size = new System.Drawing.Size(32, 32);
            this.btnPrevWeek.TabIndex = 3;
            this.btnPrevWeek.Text = "<";
            this.btnPrevWeek.UseVisualStyleBackColor = true;
            this.btnPrevWeek.Click += new System.EventHandler(this.btnPrevWeek_Click);
            // 
            // btnWeek
            // 
            this.btnWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWeek.BackColor = System.Drawing.Color.White;
            this.btnWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeek.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.btnWeek.Location = new System.Drawing.Point(698, 14);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(130, 32);
            this.btnWeek.TabIndex = 4;
            this.btnWeek.Text = "Tuần (19/10 - 25/10)";
            this.btnWeek.UseVisualStyleBackColor = true;
            // 
            // btnNextWeek
            // 
            this.btnNextWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextWeek.BackColor = System.Drawing.Color.White;
            this.btnNextWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextWeek.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNextWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnNextWeek.Location = new System.Drawing.Point(834, 14);
            this.btnNextWeek.Name = "btnNextWeek";
            this.btnNextWeek.Size = new System.Drawing.Size(32, 32);
            this.btnNextWeek.TabIndex = 5;
            this.btnNextWeek.Text = ">";
            this.btnNextWeek.UseVisualStyleBackColor = true;
            this.btnNextWeek.Click += new System.EventHandler(this.btnNextWeek_Click);
            // 
            // btnXepLichHocMoi
            // 
            this.btnXepLichHocMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXepLichHocMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnXepLichHocMoi.FlatAppearance.BorderSize = 0;
            this.btnXepLichHocMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXepLichHocMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXepLichHocMoi.ForeColor = System.Drawing.Color.White;
            this.btnXepLichHocMoi.Location = new System.Drawing.Point(875, 10);
            this.btnXepLichHocMoi.Name = "btnXepLichHocMoi";
            this.btnXepLichHocMoi.Size = new System.Drawing.Size(145, 40);
            this.btnXepLichHocMoi.TabIndex = 6;
            this.btnXepLichHocMoi.Text = "📅 Xếp Lịch Học Mới";
            this.btnXepLichHocMoi.UseVisualStyleBackColor = false;
            this.btnXepLichHocMoi.Click += new System.EventHandler(this.btnXepLichHocMoi_Click);
            // 
            // dgvLichHoc
            // 
            this.dgvLichHoc.AllowUserToAddRows = false;
            this.dgvLichHoc.AllowUserToDeleteRows = false;
            this.dgvLichHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichHoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichHoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLichHoc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvLichHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKhungGio,
            this.colThu2,
            this.colThu3,
            this.colThu4,
            this.colThu5,
            this.colThu6,
            this.colThu7,
            this.colCN});
            this.dgvLichHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichHoc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dgvLichHoc.Location = new System.Drawing.Point(15, 95);
            this.dgvLichHoc.Name = "dgvLichHoc";
            this.dgvLichHoc.ReadOnly = true;
            this.dgvLichHoc.RowHeadersVisible = false;
            this.dgvLichHoc.RowHeadersWidth = 51;
            this.dgvLichHoc.RowTemplate.Height = 110;
            this.dgvLichHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLichHoc.Size = new System.Drawing.Size(1020, 530);
            this.dgvLichHoc.TabIndex = 1;
            this.dgvLichHoc.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvLichHoc_CellPainting);
            // 
            // colKhungGio
            // 
            this.colKhungGio.FillWeight = 110F;
            this.colKhungGio.HeaderText = "KHUNG GIỜ";
            this.colKhungGio.Name = "colKhungGio";
            this.colKhungGio.ReadOnly = true;
            // 
            // colThu2
            // 
            this.colThu2.HeaderText = "THỨ 2";
            this.colThu2.Name = "colThu2";
            this.colThu2.ReadOnly = true;
            // 
            // colThu3
            // 
            this.colThu3.HeaderText = "THỨ 3";
            this.colThu3.Name = "colThu3";
            this.colThu3.ReadOnly = true;
            // 
            // colThu4
            // 
            this.colThu4.HeaderText = "THỨ 4";
            this.colThu4.Name = "colThu4";
            this.colThu4.ReadOnly = true;
            // 
            // colThu5
            // 
            this.colThu5.HeaderText = "THỨ 5";
            this.colThu5.Name = "colThu5";
            this.colThu5.ReadOnly = true;
            // 
            // colThu6
            // 
            this.colThu6.HeaderText = "THỨ 6";
            this.colThu6.Name = "colThu6";
            this.colThu6.ReadOnly = true;
            // 
            // colThu7
            // 
            this.colThu7.HeaderText = "THỨ 7";
            this.colThu7.Name = "colThu7";
            this.colThu7.ReadOnly = true;
            // 
            // colCN
            // 
            this.colCN.HeaderText = "CHỦ NHẬT";
            this.colCN.Name = "colCN";
            this.colCN.ReadOnly = true;
            // 
            // frmLichHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1050, 640);
            this.Controls.Add(this.dgvLichHoc);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.Name = "frmLichHoc";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thời Khóa Biểu";
            this.Load += new System.EventHandler(this.frmLichHoc_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichHoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblSubTieuDe;
        private System.Windows.Forms.ComboBox cboFilterLop;
        private System.Windows.Forms.Button btnPrevWeek;
        private System.Windows.Forms.Button btnWeek;
        private System.Windows.Forms.Button btnNextWeek;
        private System.Windows.Forms.Button btnXepLichHocMoi;
        private System.Windows.Forms.DataGridView dgvLichHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKhungGio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCN;
    }
}