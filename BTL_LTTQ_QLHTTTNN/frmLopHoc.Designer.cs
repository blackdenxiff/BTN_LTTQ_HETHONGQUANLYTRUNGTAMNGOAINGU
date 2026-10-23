namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmLopHoc
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
            this.btnMoLopHoc = new System.Windows.Forms.Button();
            this.flpFilterBar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.pnlKhoaHoc = new System.Windows.Forms.Panel();
            this.lblFilterKhoaHoc = new System.Windows.Forms.Label();
            this.cboFilterKhoaHoc = new System.Windows.Forms.ComboBox();
            this.pnlTrangThai = new System.Windows.Forms.Panel();
            this.lblFilterTrangThai = new System.Windows.Forms.Label();
            this.cboFilterTrangThai = new System.Windows.Forms.ComboBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvLopHoc = new System.Windows.Forms.DataGridView();
            this.colLopHocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenLopCustom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhoaHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaoVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThaoTac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblThongKe = new System.Windows.Forms.Label();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.flpFilterBar.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlKhoaHoc.SuspendLayout();
            this.pnlTrangThai.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnMoLopHoc);
            this.pnlHeader.Controls.Add(this.lblSubTieuDe);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(15, 15);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1020, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(247, 37);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Danh mục lớp học";
            // 
            // lblSubTieuDe
            // 
            this.lblSubTieuDe.AutoSize = true;
            this.lblSubTieuDe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSubTieuDe.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTieuDe.Location = new System.Drawing.Point(3, 40);
            this.lblSubTieuDe.Name = "lblSubTieuDe";
            this.lblSubTieuDe.Size = new System.Drawing.Size(252, 20);
            this.lblSubTieuDe.TabIndex = 1;
            this.lblSubTieuDe.Text = "Dữ liệu được tải trực tiếp từ hệ thống.";
            // 
            // btnMoLopHoc
            // 
            this.btnMoLopHoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoLopHoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnMoLopHoc.FlatAppearance.BorderSize = 0;
            this.btnMoLopHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoLopHoc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnMoLopHoc.ForeColor = System.Drawing.Color.White;
            this.btnMoLopHoc.Location = new System.Drawing.Point(880, 10);
            this.btnMoLopHoc.Name = "btnMoLopHoc";
            this.btnMoLopHoc.Size = new System.Drawing.Size(140, 40);
            this.btnMoLopHoc.TabIndex = 2;
            this.btnMoLopHoc.Text = "+ Mở lớp học";
            this.btnMoLopHoc.UseVisualStyleBackColor = false;
            this.btnMoLopHoc.Click += new System.EventHandler(this.btnMoLopHoc_Click);
            // 
            // flpFilterBar
            // 
            this.flpFilterBar.AutoSize = true;
            this.flpFilterBar.Controls.Add(this.pnlSearch);
            this.flpFilterBar.Controls.Add(this.pnlKhoaHoc);
            this.flpFilterBar.Controls.Add(this.pnlTrangThai);
            this.flpFilterBar.Controls.Add(this.pnlButtons);
            this.flpFilterBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpFilterBar.Location = new System.Drawing.Point(15, 85);
            this.flpFilterBar.Name = "flpFilterBar";
            this.flpFilterBar.Padding = new System.Windows.Forms.Padding(0, 5, 0, 10);
            this.flpFilterBar.Size = new System.Drawing.Size(1020, 70);
            this.flpFilterBar.TabIndex = 1;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.lblTimKiem);
            this.pnlSearch.Controls.Add(this.txtTimKiem);
            this.pnlSearch.Location = new System.Drawing.Point(0, 5);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(0, 0, 15, 5);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(280, 55);
            this.pnlSearch.TabIndex = 0;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblTimKiem.Location = new System.Drawing.Point(0, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(74, 20);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(0, 22);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(280, 30);
            this.txtTimKiem.TabIndex = 1;
            // 
            // pnlKhoaHoc
            // 
            this.pnlKhoaHoc.Controls.Add(this.lblFilterKhoaHoc);
            this.pnlKhoaHoc.Controls.Add(this.cboFilterKhoaHoc);
            this.pnlKhoaHoc.Location = new System.Drawing.Point(295, 5);
            this.pnlKhoaHoc.Margin = new System.Windows.Forms.Padding(0, 0, 15, 5);
            this.pnlKhoaHoc.Name = "pnlKhoaHoc";
            this.pnlKhoaHoc.Size = new System.Drawing.Size(220, 55);
            this.pnlKhoaHoc.TabIndex = 1;
            // 
            // lblFilterKhoaHoc
            // 
            this.lblFilterKhoaHoc.AutoSize = true;
            this.lblFilterKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilterKhoaHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblFilterKhoaHoc.Location = new System.Drawing.Point(0, 0);
            this.lblFilterKhoaHoc.Name = "lblFilterKhoaHoc";
            this.lblFilterKhoaHoc.Size = new System.Drawing.Size(74, 20);
            this.lblFilterKhoaHoc.TabIndex = 0;
            this.lblFilterKhoaHoc.Text = "Khóa học";
            // 
            // cboFilterKhoaHoc
            // 
            this.cboFilterKhoaHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboFilterKhoaHoc.FormattingEnabled = true;
            this.cboFilterKhoaHoc.Location = new System.Drawing.Point(0, 22);
            this.cboFilterKhoaHoc.Name = "cboFilterKhoaHoc";
            this.cboFilterKhoaHoc.Size = new System.Drawing.Size(220, 31);
            this.cboFilterKhoaHoc.TabIndex = 1;
            // 
            // pnlTrangThai
            // 
            this.pnlTrangThai.Controls.Add(this.lblFilterTrangThai);
            this.pnlTrangThai.Controls.Add(this.cboFilterTrangThai);
            this.pnlTrangThai.Location = new System.Drawing.Point(530, 5);
            this.pnlTrangThai.Margin = new System.Windows.Forms.Padding(0, 0, 15, 5);
            this.pnlTrangThai.Name = "pnlTrangThai";
            this.pnlTrangThai.Size = new System.Drawing.Size(200, 55);
            this.pnlTrangThai.TabIndex = 2;
            // 
            // lblFilterTrangThai
            // 
            this.lblFilterTrangThai.AutoSize = true;
            this.lblFilterTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilterTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblFilterTrangThai.Location = new System.Drawing.Point(0, 0);
            this.lblFilterTrangThai.Name = "lblFilterTrangThai";
            this.lblFilterTrangThai.Size = new System.Drawing.Size(80, 20);
            this.lblFilterTrangThai.TabIndex = 0;
            this.lblFilterTrangThai.Text = "Trạng thái";
            // 
            // cboFilterTrangThai
            // 
            this.cboFilterTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboFilterTrangThai.FormattingEnabled = true;
            this.cboFilterTrangThai.Location = new System.Drawing.Point(0, 22);
            this.cboFilterTrangThai.Name = "cboFilterTrangThai";
            this.cboFilterTrangThai.Size = new System.Drawing.Size(200, 31);
            this.cboFilterTrangThai.TabIndex = 1;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnReset);
            this.pnlButtons.Controls.Add(this.btnLoc);
            this.pnlButtons.Location = new System.Drawing.Point(745, 5);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(160, 55);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(0, 21);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(95, 32);
            this.btnLoc.TabIndex = 0;
            this.btnLoc.Text = "Y Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnReset.Location = new System.Drawing.Point(103, 21);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(42, 32);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "↺";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvLopHoc
            // 
            this.dgvLopHoc.AllowUserToAddRows = false;
            this.dgvLopHoc.AllowUserToDeleteRows = false;
            this.dgvLopHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLopHoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvLopHoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLopHoc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLopHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLopHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLopHocID,
            this.colMaLop,
            this.colTenLopCustom,
            this.colKhoaHoc,
            this.colCoSo,
            this.colGiaoVien,
            this.colSiSo,
            this.colThoiGian,
            this.colTrangThai,
            this.colThaoTac});
            this.dgvLopHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLopHoc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvLopHoc.Location = new System.Drawing.Point(15, 155);
            this.dgvLopHoc.Name = "dgvLopHoc";
            this.dgvLopHoc.ReadOnly = true;
            this.dgvLopHoc.RowHeadersVisible = false;
            this.dgvLopHoc.RowHeadersWidth = 51;
            this.dgvLopHoc.RowTemplate.Height = 65;
            this.dgvLopHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLopHoc.Size = new System.Drawing.Size(1020, 430);
            this.dgvLopHoc.TabIndex = 2;
            this.dgvLopHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLopHoc_CellClick);
            this.dgvLopHoc.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvLopHoc_CellPainting);
            // 
            // colLopHocID
            // 
            this.colLopHocID.HeaderText = "ID";
            this.colLopHocID.Name = "colLopHocID";
            this.colLopHocID.ReadOnly = true;
            this.colLopHocID.Visible = false;
            // 
            // colMaLop
            // 
            this.colMaLop.FillWeight = 160F;
            this.colMaLop.HeaderText = "MÃ LỚP";
            this.colMaLop.Name = "colMaLop";
            this.colMaLop.ReadOnly = true;
            // 
            // colTenLopCustom
            // 
            this.colTenLopCustom.HeaderText = "TÊN LỚP";
            this.colTenLopCustom.Name = "colTenLopCustom";
            this.colTenLopCustom.ReadOnly = true;
            this.colTenLopCustom.Visible = false;
            // 
            // colKhoaHoc
            // 
            this.colKhoaHoc.FillWeight = 130F;
            this.colKhoaHoc.HeaderText = "KHÓA HỌC";
            this.colKhoaHoc.Name = "colKhoaHoc";
            this.colKhoaHoc.ReadOnly = true;
            // 
            // colCoSo
            // 
            this.colCoSo.FillWeight = 100F;
            this.colCoSo.HeaderText = "CƠ SỞ";
            this.colCoSo.Name = "colCoSo";
            this.colCoSo.ReadOnly = true;
            // 
            // colGiaoVien
            // 
            this.colGiaoVien.FillWeight = 110F;
            this.colGiaoVien.HeaderText = "GIÁO VIÊN";
            this.colGiaoVien.Name = "colGiaoVien";
            this.colGiaoVien.ReadOnly = true;
            // 
            // colSiSo
            // 
            this.colSiSo.FillWeight = 60F;
            this.colSiSo.HeaderText = "SĨ SỐ";
            this.colSiSo.Name = "colSiSo";
            this.colSiSo.ReadOnly = true;
            // 
            // colThoiGian
            // 
            this.colThoiGian.FillWeight = 120F;
            this.colThoiGian.HeaderText = "THỜI GIAN";
            this.colThoiGian.Name = "colThoiGian";
            this.colThoiGian.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.FillWeight = 80F;
            this.colTrangThai.HeaderText = "TRẠNG THÁI";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // colThaoTac
            // 
            this.colThaoTac.FillWeight = 70F;
            this.colThaoTac.HeaderText = "THAO TÁC";
            this.colThaoTac.Name = "colThaoTac";
            this.colThaoTac.ReadOnly = true;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnPage1);
            this.pnlFooter.Controls.Add(this.lblThongKe);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(15, 585);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1020, 40);
            this.pnlFooter.TabIndex = 3;
            // 
            // lblThongKe
            // 
            this.lblThongKe.AutoSize = true;
            this.lblThongKe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblThongKe.ForeColor = System.Drawing.Color.Gray;
            this.lblThongKe.Location = new System.Drawing.Point(0, 10);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(142, 20);
            this.lblThongKe.TabIndex = 0;
            this.lblThongKe.Text = "Hiển thị 3 / 3 lớp học";
            // 
            // btnPage1
            // 
            this.btnPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnPage1.FlatAppearance.BorderSize = 0;
            this.btnPage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPage1.ForeColor = System.Drawing.Color.White;
            this.btnPage1.Location = new System.Drawing.Point(985, 5);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(32, 32);
            this.btnPage1.TabIndex = 1;
            this.btnPage1.Text = "1";
            this.btnPage1.UseVisualStyleBackColor = false;
            // 
            // frmLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1050, 640);
            this.Controls.Add(this.dgvLopHoc);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.flpFilterBar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.Name = "frmLopHoc";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Mục Lớp Học";
            this.Load += new System.EventHandler(this.frmLopHoc_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.flpFilterBar.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlKhoaHoc.ResumeLayout(false);
            this.pnlKhoaHoc.PerformLayout();
            this.pnlTrangThai.ResumeLayout(false);
            this.pnlTrangThai.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblSubTieuDe;
        private System.Windows.Forms.Button btnMoLopHoc;
        private System.Windows.Forms.FlowLayoutPanel flpFilterBar;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Panel pnlKhoaHoc;
        private System.Windows.Forms.Label lblFilterKhoaHoc;
        private System.Windows.Forms.ComboBox cboFilterKhoaHoc;
        private System.Windows.Forms.Panel pnlTrangThai;
        private System.Windows.Forms.Label lblFilterTrangThai;
        private System.Windows.Forms.ComboBox cboFilterTrangThai;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvLopHoc;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.Button btnPage1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLopHocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenLopCustom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKhoaHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaoVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSiSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThaoTac;
    }
}