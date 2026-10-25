namespace BTL_LTTQ_QLHTTTNN.Forms
{
    partial class frmThongBao
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
            this.lblTieuDeForm = new System.Windows.Forms.Label();
            this.pnlCardMain = new System.Windows.Forms.Panel();
            this.lblLoaiThongBao = new System.Windows.Forms.Label();
            this.cboLoaiThongBao = new System.Windows.Forms.ComboBox();
            this.lblPhamVi = new System.Windows.Forms.Label();
            this.cboPhamVi = new System.Windows.Forms.ComboBox();
            this.lblLopHoc = new System.Windows.Forms.Label();
            this.cboLopHoc = new System.Windows.Forms.ComboBox();
            this.lblHocVien = new System.Windows.Forms.Label();
            this.cboHocVien = new System.Windows.Forms.ComboBox();
            this.lblEmailHocVien = new System.Windows.Forms.Label();
            this.txtEmailHocVien = new System.Windows.Forms.TextBox();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.txtTieuDe = new System.Windows.Forms.TextBox();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.btnGuiThongBao = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlCardMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.pnlHeader.Controls.Add(this.lblTieuDeForm);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(980, 65);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTieuDeForm
            // 
            this.lblTieuDeForm.AutoSize = true;
            this.lblTieuDeForm.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeForm.ForeColor = System.Drawing.Color.White;
            this.lblTieuDeForm.Location = new System.Drawing.Point(24, 18);
            this.lblTieuDeForm.Name = "lblTieuDeForm";
            this.lblTieuDeForm.Size = new System.Drawing.Size(341, 30);
            this.lblTieuDeForm.TabIndex = 0;
            this.lblTieuDeForm.Text = "📧 QUẢN LÝ & GỬI THÔNG BÁO";
            // 
            // pnlCardMain
            // 
            this.pnlCardMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCardMain.BackColor = System.Drawing.Color.White;
            this.pnlCardMain.Controls.Add(this.lblLoaiThongBao);
            this.pnlCardMain.Controls.Add(this.cboLoaiThongBao);
            this.pnlCardMain.Controls.Add(this.lblPhamVi);
            this.pnlCardMain.Controls.Add(this.cboPhamVi);
            this.pnlCardMain.Controls.Add(this.lblLopHoc);
            this.pnlCardMain.Controls.Add(this.cboLopHoc);
            this.pnlCardMain.Controls.Add(this.lblHocVien);
            this.pnlCardMain.Controls.Add(this.cboHocVien);
            this.pnlCardMain.Controls.Add(this.lblEmailHocVien);
            this.pnlCardMain.Controls.Add(this.txtEmailHocVien);
            this.pnlCardMain.Controls.Add(this.lblTieuDe);
            this.pnlCardMain.Controls.Add(this.txtTieuDe);
            this.pnlCardMain.Controls.Add(this.lblNoiDung);
            this.pnlCardMain.Controls.Add(this.txtNoiDung);
            this.pnlCardMain.Controls.Add(this.btnLamMoi);
            this.pnlCardMain.Controls.Add(this.btnGuiThongBao);
            this.pnlCardMain.Location = new System.Drawing.Point(20, 80);
            this.pnlCardMain.Name = "pnlCardMain";
            this.pnlCardMain.Size = new System.Drawing.Size(940, 580);
            this.pnlCardMain.TabIndex = 1;
            // 
            // lblLoaiThongBao
            // 
            this.lblLoaiThongBao.AutoSize = true;
            this.lblLoaiThongBao.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLoaiThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblLoaiThongBao.Location = new System.Drawing.Point(24, 20);
            this.lblLoaiThongBao.Name = "lblLoaiThongBao";
            this.lblLoaiThongBao.Size = new System.Drawing.Size(109, 17);
            this.lblLoaiThongBao.TabIndex = 0;
            this.lblLoaiThongBao.Text = "Loại thông báo *";
            // 
            // cboLoaiThongBao
            // 
            this.cboLoaiThongBao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThongBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiThongBao.FormattingEnabled = true;
            this.cboLoaiThongBao.Location = new System.Drawing.Point(24, 42);
            this.cboLoaiThongBao.Name = "cboLoaiThongBao";
            this.cboLoaiThongBao.Size = new System.Drawing.Size(430, 25);
            this.cboLoaiThongBao.TabIndex = 1;
            this.cboLoaiThongBao.SelectedIndexChanged += new System.EventHandler(this.cboLoaiThongBao_SelectedIndexChanged);
            // 
            // lblPhamVi
            // 
            this.lblPhamVi.AutoSize = true;
            this.lblPhamVi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPhamVi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblPhamVi.Location = new System.Drawing.Point(480, 20);
            this.lblPhamVi.Name = "lblPhamVi";
            this.lblPhamVi.Size = new System.Drawing.Size(147, 17);
            this.lblPhamVi.TabIndex = 2;
            this.lblPhamVi.Text = "Phạm vi / Đối tượng *";
            // 
            // cboPhamVi
            // 
            this.cboPhamVi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhamVi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPhamVi.FormattingEnabled = true;
            this.cboPhamVi.Location = new System.Drawing.Point(480, 42);
            this.cboPhamVi.Name = "cboPhamVi";
            this.cboPhamVi.Size = new System.Drawing.Size(430, 25);
            this.cboPhamVi.TabIndex = 3;
            this.cboPhamVi.SelectedIndexChanged += new System.EventHandler(this.cboPhamVi_SelectedIndexChanged);
            // 
            // lblLopHoc
            // 
            this.lblLopHoc.AutoSize = true;
            this.lblLopHoc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLopHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblLopHoc.Location = new System.Drawing.Point(24, 82);
            this.lblLopHoc.Name = "lblLopHoc";
            this.lblLopHoc.Size = new System.Drawing.Size(58, 17);
            this.lblLopHoc.TabIndex = 4;
            this.lblLopHoc.Text = "Lớp học";
            // 
            // cboLopHoc
            // 
            this.cboLopHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLopHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLopHoc.FormattingEnabled = true;
            this.cboLopHoc.Location = new System.Drawing.Point(24, 104);
            this.cboLopHoc.Name = "cboLopHoc";
            this.cboLopHoc.Size = new System.Drawing.Size(430, 25);
            this.cboLopHoc.TabIndex = 5;
            // 
            // lblHocVien
            // 
            this.lblHocVien.AutoSize = true;
            this.lblHocVien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHocVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblHocVien.Location = new System.Drawing.Point(480, 82);
            this.lblHocVien.Name = "lblHocVien";
            this.lblHocVien.Size = new System.Drawing.Size(63, 17);
            this.lblHocVien.TabIndex = 6;
            this.lblHocVien.Text = "Học viên";
            // 
            // cboHocVien
            // 
            this.cboHocVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboHocVien.FormattingEnabled = true;
            this.cboHocVien.Location = new System.Drawing.Point(480, 104);
            this.cboHocVien.Name = "cboHocVien";
            this.cboHocVien.Size = new System.Drawing.Size(430, 25);
            this.cboHocVien.TabIndex = 7;
            this.cboHocVien.SelectedIndexChanged += new System.EventHandler(this.cboHocVien_SelectedIndexChanged);
            // 
            // lblEmailHocVien
            // 
            this.lblEmailHocVien.AutoSize = true;
            this.lblEmailHocVien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEmailHocVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblEmailHocVien.Location = new System.Drawing.Point(24, 144);
            this.lblEmailHocVien.Name = "lblEmailHocVien";
            this.lblEmailHocVien.Size = new System.Drawing.Size(133, 17);
            this.lblEmailHocVien.TabIndex = 8;
            this.lblEmailHocVien.Text = "Email nhận trực tiếp";
            // 
            // txtEmailHocVien
            // 
            this.txtEmailHocVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmailHocVien.Location = new System.Drawing.Point(24, 166);
            this.txtEmailHocVien.Name = "txtEmailHocVien";
            this.txtEmailHocVien.Size = new System.Drawing.Size(886, 25);
            this.txtEmailHocVien.TabIndex = 9;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblTieuDe.Location = new System.Drawing.Point(24, 206);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(126, 17);
            this.lblTieuDe.TabIndex = 10;
            this.lblTieuDe.Text = "Tiêu đề thông báo *";
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTieuDe.Location = new System.Drawing.Point(24, 228);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Size = new System.Drawing.Size(886, 25);
            this.txtTieuDe.TabIndex = 11;
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblNoiDung.Location = new System.Drawing.Point(24, 268);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(137, 17);
            this.lblNoiDung.TabIndex = 12;
            this.lblNoiDung.Text = "Nội dung thông báo *";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNoiDung.Location = new System.Drawing.Point(24, 290);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNoiDung.Size = new System.Drawing.Size(886, 210);
            this.txtNoiDung.TabIndex = 13;
            // 
            // btnGuiThongBao
            // 
            this.btnGuiThongBao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnGuiThongBao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuiThongBao.FlatAppearance.BorderSize = 0;
            this.btnGuiThongBao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuiThongBao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuiThongBao.ForeColor = System.Drawing.Color.White;
            this.btnGuiThongBao.Location = new System.Drawing.Point(760, 520);
            this.btnGuiThongBao.Name = "btnGuiThongBao";
            this.btnGuiThongBao.Size = new System.Drawing.Size(150, 42);
            this.btnGuiThongBao.TabIndex = 15;
            this.btnGuiThongBao.Text = "📤 Gửi Email";
            this.btnGuiThongBao.UseVisualStyleBackColor = false;
            this.btnGuiThongBao.Click += new System.EventHandler(this.btnGuiThongBao_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(620, 520);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(125, 42);
            this.btnLamMoi.TabIndex = 14;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // frmThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(980, 680);
            this.Controls.Add(this.pnlCardMain);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongBao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý & Gửi Thông Báo";
            this.Load += new System.EventHandler(this.frmThongBao_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCardMain.ResumeLayout(false);
            this.pnlCardMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDeForm;
        private System.Windows.Forms.Panel pnlCardMain;
        private System.Windows.Forms.Label lblLoaiThongBao;
        private System.Windows.Forms.ComboBox cboLoaiThongBao;
        private System.Windows.Forms.Label lblPhamVi;
        private System.Windows.Forms.ComboBox cboPhamVi;
        private System.Windows.Forms.Label lblLopHoc;
        private System.Windows.Forms.ComboBox cboLopHoc;
        private System.Windows.Forms.Label lblHocVien;
        private System.Windows.Forms.ComboBox cboHocVien;
        private System.Windows.Forms.Label lblEmailHocVien;
        private System.Windows.Forms.TextBox txtEmailHocVien;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.TextBox txtTieuDe;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Button btnGuiThongBao;
        private System.Windows.Forms.Button btnLamMoi;
    }
}