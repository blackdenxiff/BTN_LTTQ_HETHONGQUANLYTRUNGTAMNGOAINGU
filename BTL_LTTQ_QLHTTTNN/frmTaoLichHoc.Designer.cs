namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmTaoLichHoc
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
            this.lblKhoaHoc = new System.Windows.Forms.Label();
            this.txtKhoaHoc = new System.Windows.Forms.TextBox();
            this.lblLopHoc = new System.Windows.Forms.Label();
            this.cboLopHoc = new System.Windows.Forms.ComboBox();
            this.lblPhongHoc = new System.Windows.Forms.Label();
            this.cboPhongHoc = new System.Windows.Forms.ComboBox();
            this.lblCaHoc = new System.Windows.Forms.Label();
            this.cboCaHoc = new System.Windows.Forms.ComboBox();
            this.lblNgayHoc = new System.Windows.Forms.Label();
            this.dtpNgayHoc = new System.Windows.Forms.DateTimePicker();
            this.lblGiaoVien = new System.Windows.Forms.Label();
            this.cboGiaoVien = new System.Windows.Forms.ComboBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(460, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(15, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(206, 28);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "📅 Chi Tiết Lịch Học";
            // 
            // lblLopHoc
            // 
            this.lblLopHoc.AutoSize = true;
            this.lblLopHoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLopHoc.Location = new System.Drawing.Point(25, 65);
            this.lblLopHoc.Name = "lblLopHoc";
            this.lblLopHoc.Size = new System.Drawing.Size(69, 20);
            this.lblLopHoc.TabIndex = 1;
            this.lblLopHoc.Text = "Lớp học:";
            // 
            // cboLopHoc
            // 
            this.cboLopHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLopHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLopHoc.FormattingEnabled = true;
            this.cboLopHoc.Location = new System.Drawing.Point(25, 88);
            this.cboLopHoc.Name = "cboLopHoc";
            this.cboLopHoc.Size = new System.Drawing.Size(410, 31);
            this.cboLopHoc.TabIndex = 2;
            this.cboLopHoc.SelectedIndexChanged += new System.EventHandler(this.cboLopHoc_SelectedIndexChanged);
            // 
            // lblKhoaHoc
            // 
            this.lblKhoaHoc.AutoSize = true;
            this.lblKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKhoaHoc.Location = new System.Drawing.Point(25, 130);
            this.lblKhoaHoc.Name = "lblKhoaHoc";
            this.lblKhoaHoc.Size = new System.Drawing.Size(78, 20);
            this.lblKhoaHoc.TabIndex = 3;
            this.lblKhoaHoc.Text = "Khóa học:";
            // 
            // txtKhoaHoc
            // 
            this.txtKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtKhoaHoc.Location = new System.Drawing.Point(25, 153);
            this.txtKhoaHoc.Name = "txtKhoaHoc";
            this.txtKhoaHoc.ReadOnly = true;
            this.txtKhoaHoc.Size = new System.Drawing.Size(410, 30);
            this.txtKhoaHoc.TabIndex = 4;
            // 
            // lblGiaoVien
            // 
            this.lblGiaoVien.AutoSize = true;
            this.lblGiaoVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGiaoVien.Location = new System.Drawing.Point(25, 195);
            this.lblGiaoVien.Name = "lblGiaoVien";
            this.lblGiaoVien.Size = new System.Drawing.Size(150, 20);
            this.lblGiaoVien.TabIndex = 5;
            this.lblGiaoVien.Text = "Giáo viên phụ trách:";
            // 
            // cboGiaoVien
            // 
            this.cboGiaoVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGiaoVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGiaoVien.FormattingEnabled = true;
            this.cboGiaoVien.Location = new System.Drawing.Point(25, 218);
            this.cboGiaoVien.Name = "cboGiaoVien";
            this.cboGiaoVien.Size = new System.Drawing.Size(410, 31);
            this.cboGiaoVien.TabIndex = 6;
            // 
            // lblPhongHoc
            // 
            this.lblPhongHoc.AutoSize = true;
            this.lblPhongHoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhongHoc.Location = new System.Drawing.Point(25, 260);
            this.lblPhongHoc.Name = "lblPhongHoc";
            this.lblPhongHoc.Size = new System.Drawing.Size(88, 20);
            this.lblPhongHoc.TabIndex = 7;
            this.lblPhongHoc.Text = "Phòng học:";
            // 
            // cboPhongHoc
            // 
            this.cboPhongHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPhongHoc.FormattingEnabled = true;
            this.cboPhongHoc.Location = new System.Drawing.Point(25, 283);
            this.cboPhongHoc.Name = "cboPhongHoc";
            this.cboPhongHoc.Size = new System.Drawing.Size(410, 31);
            this.cboPhongHoc.TabIndex = 8;
            // 
            // lblCaHoc
            // 
            this.lblCaHoc.AutoSize = true;
            this.lblCaHoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCaHoc.Location = new System.Drawing.Point(25, 325);
            this.lblCaHoc.Name = "lblCaHoc";
            this.lblCaHoc.Size = new System.Drawing.Size(60, 20);
            this.lblCaHoc.TabIndex = 9;
            this.lblCaHoc.Text = "Ca học:";
            // 
            // cboCaHoc
            // 
            this.cboCaHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCaHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCaHoc.FormattingEnabled = true;
            this.cboCaHoc.Location = new System.Drawing.Point(25, 348);
            this.cboCaHoc.Name = "cboCaHoc";
            this.cboCaHoc.Size = new System.Drawing.Size(195, 31);
            this.cboCaHoc.TabIndex = 10;
            // 
            // lblNgayHoc
            // 
            this.lblNgayHoc.AutoSize = true;
            this.lblNgayHoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNgayHoc.Location = new System.Drawing.Point(240, 325);
            this.lblNgayHoc.Name = "lblNgayHoc";
            this.lblNgayHoc.Size = new System.Drawing.Size(79, 20);
            this.lblNgayHoc.TabIndex = 11;
            this.lblNgayHoc.Text = "Ngày học:";
            // 
            // dtpNgayHoc
            // 
            this.dtpNgayHoc.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayHoc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayHoc.Location = new System.Drawing.Point(240, 348);
            this.dtpNgayHoc.Name = "dtpNgayHoc";
            this.dtpNgayHoc.Size = new System.Drawing.Size(195, 30);
            this.dtpNgayHoc.TabIndex = 12;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(125, 410);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 38);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "💾 Lưu lịch";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(235, 410);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 38);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "🗑 Xóa lịch";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(345, 410);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(90, 38);
            this.btnHuy.TabIndex = 15;
            this.btnHuy.Text = "❌ Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmTaoLichHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 470);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dtpNgayHoc);
            this.Controls.Add(this.lblNgayHoc);
            this.Controls.Add(this.cboCaHoc);
            this.Controls.Add(this.lblCaHoc);
            this.Controls.Add(this.cboPhongHoc);
            this.Controls.Add(this.lblPhongHoc);
            this.Controls.Add(this.cboGiaoVien);
            this.Controls.Add(this.lblGiaoVien);
            this.Controls.Add(this.txtKhoaHoc);
            this.Controls.Add(this.lblKhoaHoc);
            this.Controls.Add(this.cboLopHoc);
            this.Controls.Add(this.lblLopHoc);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTaoLichHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi Tiết Lịch Học";
            this.Load += new System.EventHandler(this.frmTaoLichHoc_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblLopHoc;
        private System.Windows.Forms.ComboBox cboLopHoc;
        private System.Windows.Forms.Label lblKhoaHoc;
        private System.Windows.Forms.TextBox txtKhoaHoc;
        private System.Windows.Forms.Label lblGiaoVien;
        private System.Windows.Forms.ComboBox cboGiaoVien;
        private System.Windows.Forms.Label lblPhongHoc;
        private System.Windows.Forms.ComboBox cboPhongHoc;
        private System.Windows.Forms.Label lblCaHoc;
        private System.Windows.Forms.ComboBox cboCaHoc;
        private System.Windows.Forms.Label lblNgayHoc;
        private System.Windows.Forms.DateTimePicker dtpNgayHoc;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnHuy;
    }
}