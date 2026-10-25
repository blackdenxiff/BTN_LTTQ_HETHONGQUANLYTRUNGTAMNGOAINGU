namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmNhatKyGiangDay
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblPhuDe = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblLocThang = new System.Windows.Forms.Label();
            this.cboThangNam = new System.Windows.Forms.ComboBox();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.lblTongQuan = new System.Windows.Forms.Label();
            this.pnlGridContainer = new System.Windows.Forms.Panel();
            this.dgvNhatKy = new System.Windows.Forms.DataGridView();
            this.colNgayDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCaHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhongHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongSiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVangMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhatKy)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblPhuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(940, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTieuDe.Location = new System.Drawing.Point(25, 14);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(262, 30);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "NHẬT KÝ GIẢNG DẠY";
            // 
            // lblPhuDe
            // 
            this.lblPhuDe.AutoSize = true;
            this.lblPhuDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPhuDe.Location = new System.Drawing.Point(26, 46);
            this.lblPhuDe.Name = "lblPhuDe";
            this.lblPhuDe.Size = new System.Drawing.Size(395, 15);
            this.lblPhuDe.TabIndex = 1;
            this.lblPhuDe.Text = "Lịch sử các buổi học đã hoàn thành và thống kê tình hình điểm danh học viên";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.lblLocThang);
            this.pnlFilter.Controls.Add(this.cboThangNam);
            this.pnlFilter.Controls.Add(this.btnTaiLai);
            this.pnlFilter.Controls.Add(this.btnXuatExcel);
            this.pnlFilter.Controls.Add(this.lblTongQuan);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 75);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(940, 60);
            this.pnlFilter.TabIndex = 1;
            // 
            // lblLocThang
            // 
            this.lblLocThang.AutoSize = true;
            this.lblLocThang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLocThang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblLocThang.Location = new System.Drawing.Point(26, 20);
            this.lblLocThang.Name = "lblLocThang";
            this.lblLocThang.Size = new System.Drawing.Size(129, 17);
            this.lblLocThang.TabIndex = 0;
            this.lblLocThang.Text = "Lọc theo tháng/năm:";
            // 
            // cboThangNam
            // 
            this.cboThangNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThangNam.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboThangNam.FormattingEnabled = true;
            this.cboThangNam.Location = new System.Drawing.Point(165, 17);
            this.cboThangNam.Name = "cboThangNam";
            this.cboThangNam.Size = new System.Drawing.Size(190, 25);
            this.cboThangNam.TabIndex = 1;
            this.cboThangNam.SelectedIndexChanged += new System.EventHandler(this.cboThangNam_SelectedIndexChanged);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTaiLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaiLai.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnTaiLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiLai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTaiLai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnTaiLai.Location = new System.Drawing.Point(365, 15);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(90, 30);
            this.btnTaiLai.TabIndex = 2;
            this.btnTaiLai.Text = "🔄 Tải lại";
            this.btnTaiLai.UseVisualStyleBackColor = false;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(745, 14);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(165, 32);
            this.btnXuatExcel.TabIndex = 3;
            this.btnXuatExcel.Text = "📥 Xuất báo cáo Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // lblTongQuan
            // 
            this.lblTongQuan.AutoSize = true;
            this.lblTongQuan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblTongQuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTongQuan.Location = new System.Drawing.Point(475, 21);
            this.lblTongQuan.Name = "lblTongQuan";
            this.lblTongQuan.Size = new System.Drawing.Size(117, 17);
            this.lblTongQuan.TabIndex = 4;
            this.lblTongQuan.Text = "Tổng số: 0 buổi dạy";
            // 
            // pnlGridContainer
            // 
            this.pnlGridContainer.Controls.Add(this.dgvNhatKy);
            this.pnlGridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridContainer.Location = new System.Drawing.Point(0, 135);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Padding = new System.Windows.Forms.Padding(20, 15, 20, 20);
            this.pnlGridContainer.Size = new System.Drawing.Size(940, 445);
            this.pnlGridContainer.TabIndex = 2;
            // 
            // dgvNhatKy
            // 
            this.dgvNhatKy.AllowUserToAddRows = false;
            this.dgvNhatKy.AllowUserToDeleteRows = false;
            this.dgvNhatKy.AllowUserToResizeRows = false;
            this.dgvNhatKy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhatKy.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhatKy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNhatKy.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNhatKy.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvNhatKy.ColumnHeadersHeight = 38;
            this.dgvNhatKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNhatKy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNgayDay,
            this.colTenLop,
            this.colCaHoc,
            this.colPhongHoc,
            this.colTongSiSo,
            this.colCoMat,
            this.colVangMat});
            this.dgvNhatKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhatKy.EnableHeadersVisualStyles = false;
            this.dgvNhatKy.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvNhatKy.Location = new System.Drawing.Point(20, 15);
            this.dgvNhatKy.MultiSelect = false;
            this.dgvNhatKy.Name = "dgvNhatKy";
            this.dgvNhatKy.ReadOnly = true;
            this.dgvNhatKy.RowHeadersVisible = false;
            this.dgvNhatKy.RowTemplate.Height = 36;
            this.dgvNhatKy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhatKy.Size = new System.Drawing.Size(900, 410);
            this.dgvNhatKy.TabIndex = 0;
            this.dgvNhatKy.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvNhatKy_CellFormatting);
            // 
            // colNgayDay
            // 
            this.colNgayDay.DataPropertyName = "NgayDay";
            this.colNgayDay.FillWeight = 14F;
            this.colNgayDay.HeaderText = "Ngày dạy";
            this.colNgayDay.Name = "colNgayDay";
            this.colNgayDay.ReadOnly = true;
            // 
            // colTenLop
            // 
            this.colTenLop.DataPropertyName = "TenLop";
            this.colTenLop.FillWeight = 24F;
            this.colTenLop.HeaderText = "Tên Lớp";
            this.colTenLop.Name = "colTenLop";
            this.colTenLop.ReadOnly = true;
            // 
            // colCaHoc
            // 
            this.colCaHoc.DataPropertyName = "CaHoc";
            this.colCaHoc.FillWeight = 18F;
            this.colCaHoc.HeaderText = "Ca/Giờ học";
            this.colCaHoc.Name = "colCaHoc";
            this.colCaHoc.ReadOnly = true;
            // 
            // colPhongHoc
            // 
            this.colPhongHoc.DataPropertyName = "PhongHoc";
            this.colPhongHoc.FillWeight = 16F;
            this.colPhongHoc.HeaderText = "Phòng học";
            this.colPhongHoc.Name = "colPhongHoc";
            this.colPhongHoc.ReadOnly = true;
            // 
            // colTongSiSo
            // 
            this.colTongSiSo.DataPropertyName = "TongSiSo";
            this.colTongSiSo.FillWeight = 10F;
            this.colTongSiSo.HeaderText = "Tổng sĩ số";
            this.colTongSiSo.Name = "colTongSiSo";
            this.colTongSiSo.ReadOnly = true;
            // 
            // colCoMat
            // 
            this.colCoMat.DataPropertyName = "CoMat";
            this.colCoMat.FillWeight = 9F;
            this.colCoMat.HeaderText = "Có mặt";
            this.colCoMat.Name = "colCoMat";
            this.colCoMat.ReadOnly = true;
            // 
            // colVangMat
            // 
            this.colVangMat.DataPropertyName = "VangMat";
            this.colVangMat.FillWeight = 9F;
            this.colVangMat.HeaderText = "Vắng mặt";
            this.colVangMat.Name = "colVangMat";
            this.colVangMat.ReadOnly = true;
            // 
            // frmNhatKyGiangDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(940, 580);
            this.Controls.Add(this.pnlGridContainer);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNhatKyGiangDay";
            this.Text = "Nhật ký giảng dạy";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhatKy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblPhuDe;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblLocThang;
        private System.Windows.Forms.ComboBox cboThangNam;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Label lblTongQuan;
        private System.Windows.Forms.Panel pnlGridContainer;
        private System.Windows.Forms.DataGridView dgvNhatKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCaHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhongHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongSiSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoMat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVangMat;
    }
}
