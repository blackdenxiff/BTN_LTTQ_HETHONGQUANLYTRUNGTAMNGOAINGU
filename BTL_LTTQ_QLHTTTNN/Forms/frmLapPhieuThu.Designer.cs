namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmLapPhieuThu
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblHocVien = new System.Windows.Forms.Label();
            this.cboHocVien = new System.Windows.Forms.ComboBox();
            this.lblLopHoc = new System.Windows.Forms.Label();
            this.cboLopHoc = new System.Windows.Forms.ComboBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblSoTienNop = new System.Windows.Forms.Label();
            this.txtSoTienNop = new System.Windows.Forms.TextBox();
            this.lblPhuongThuc = new System.Windows.Forms.Label();
            this.cboPhuongThuc = new System.Windows.Forms.ComboBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();

            // Cột bên phải dành riêng cho Khung VietQR BIDV
            this.pnlQRRight = new System.Windows.Forms.Panel();
            this.lblQRTitle = new System.Windows.Forms.Label();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.lblBankInfo = new System.Windows.Forms.Label();
            this.btnKiemTraChuyenKhoan = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlQRRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(950, 50);
            this.pnlHeader.TabIndex = 0;
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(252, 28);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "💳 Lập Phiếu Thu Học Phí";
            //
            // pnlLeft
            //
            this.pnlLeft.Controls.Add(this.btnHuy);
            this.pnlLeft.Controls.Add(this.btnLuu);
            this.pnlLeft.Controls.Add(this.txtGhiChu);
            this.pnlLeft.Controls.Add(this.lblGhiChu);
            this.pnlLeft.Controls.Add(this.cboPhuongThuc);
            this.pnlLeft.Controls.Add(this.lblPhuongThuc);
            this.pnlLeft.Controls.Add(this.txtSoTienNop);
            this.pnlLeft.Controls.Add(this.lblSoTienNop);
            this.pnlLeft.Controls.Add(this.txtTongTien);
            this.pnlLeft.Controls.Add(this.lblTongTien);
            this.pnlLeft.Controls.Add(this.cboLopHoc);
            this.pnlLeft.Controls.Add(this.lblLopHoc);
            this.pnlLeft.Controls.Add(this.cboHocVien);
            this.pnlLeft.Controls.Add(this.lblHocVien);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 50);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(480, 550);
            this.pnlLeft.TabIndex = 1;
            //
            // lblHocVien
            //
            this.lblHocVien.AutoSize = true;
            this.lblHocVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHocVien.Location = new System.Drawing.Point(20, 15);
            this.lblHocVien.Name = "lblHocVien";
            this.lblHocVien.Size = new System.Drawing.Size(75, 20);
            this.lblHocVien.TabIndex = 1;
            this.lblHocVien.Text = "Học viên:";
            //
            // cboHocVien
            //
            this.cboHocVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboHocVien.FormattingEnabled = true;
            this.cboHocVien.Location = new System.Drawing.Point(20, 38);
            this.cboHocVien.Name = "cboHocVien";
            this.cboHocVien.Size = new System.Drawing.Size(435, 31);
            this.cboHocVien.TabIndex = 2;
            this.cboHocVien.SelectedIndexChanged += new System.EventHandler(this.cboHocVien_SelectedIndexChanged);
            //
            // lblLopHoc
            //
            this.lblLopHoc.AutoSize = true;
            this.lblLopHoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLopHoc.Location = new System.Drawing.Point(20, 80);
            this.lblLopHoc.Name = "lblLopHoc";
            this.lblLopHoc.Size = new System.Drawing.Size(69, 20);
            this.lblLopHoc.TabIndex = 3;
            this.lblLopHoc.Text = "Lớp học:";
            //
            // cboLopHoc
            //
            this.cboLopHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLopHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLopHoc.FormattingEnabled = true;
            this.cboLopHoc.Location = new System.Drawing.Point(20, 103);
            this.cboLopHoc.Name = "cboLopHoc";
            this.cboLopHoc.Size = new System.Drawing.Size(435, 31);
            this.cboLopHoc.TabIndex = 4;
            this.cboLopHoc.SelectedIndexChanged += new System.EventHandler(this.cboLopHoc_SelectedIndexChanged);
            //
            // lblTongTien
            //
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(20, 145);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(142, 20);
            this.lblTongTien.TabIndex = 5;
            this.lblTongTien.Text = "Học phí học phần:";
            //
            // txtTongTien
            //
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTongTien.Location = new System.Drawing.Point(20, 168);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(435, 30);
            this.txtTongTien.TabIndex = 6;
            //
            // lblSoTienNop
            //
            this.lblSoTienNop.AutoSize = true;
            this.lblSoTienNop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoTienNop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.lblSoTienNop.Location = new System.Drawing.Point(20, 210);
            this.lblSoTienNop.Name = "lblSoTienNop";
            this.lblSoTienNop.Size = new System.Drawing.Size(144, 20);
            this.lblSoTienNop.TabIndex = 7;
            this.lblSoTienNop.Text = "Số tiền thanh toán:";
            //
            // txtSoTienNop
            //
            this.txtSoTienNop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtSoTienNop.Location = new System.Drawing.Point(20, 233);
            this.txtSoTienNop.Name = "txtSoTienNop";
            this.txtSoTienNop.Size = new System.Drawing.Size(435, 30);
            this.txtSoTienNop.TabIndex = 8;
            this.txtSoTienNop.TextChanged += new System.EventHandler(this.txtSoTienNop_TextChanged);
            //
            // lblPhuongThuc
            //
            this.lblPhuongThuc.AutoSize = true;
            this.lblPhuongThuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhuongThuc.Location = new System.Drawing.Point(20, 275);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Size = new System.Drawing.Size(185, 20);
            this.lblPhuongThuc.TabIndex = 9;
            this.lblPhuongThuc.Text = "Phương thức thanh toán:";
            //
            // cboPhuongThuc
            //
            this.cboPhuongThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongThuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPhuongThuc.FormattingEnabled = true;
            this.cboPhuongThuc.Location = new System.Drawing.Point(20, 298);
            this.cboPhuongThuc.Name = "cboPhuongThuc";
            this.cboPhuongThuc.Size = new System.Drawing.Size(435, 31);
            this.cboPhuongThuc.TabIndex = 10;
            this.cboPhuongThuc.SelectedIndexChanged += new System.EventHandler(this.cboPhuongThuc_SelectedIndexChanged);
            //
            // lblGhiChu
            //
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGhiChu.Location = new System.Drawing.Point(20, 340);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(66, 20);
            this.lblGhiChu.TabIndex = 11;
            this.lblGhiChu.Text = "Ghi chú:";
            //
            // txtGhiChu
            //
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGhiChu.Location = new System.Drawing.Point(20, 363);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(435, 30);
            this.txtGhiChu.TabIndex = 12;
            //
            // btnLuu
            //
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(180, 420);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(140, 42);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "💾 Xác nhận";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            //
            // btnHuy
            //
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(335, 420);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 42);
            this.btnHuy.TabIndex = 14;
            this.btnHuy.Text = "❌ Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            //
            // pnlQRRight
            //
            this.pnlQRRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlQRRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQRRight.Controls.Add(this.btnKiemTraChuyenKhoan);
            this.pnlQRRight.Controls.Add(this.lblBankInfo);
            this.pnlQRRight.Controls.Add(this.picQR);
            this.pnlQRRight.Controls.Add(this.lblQRTitle);
            this.pnlQRRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQRRight.Location = new System.Drawing.Point(480, 50);
            this.pnlQRRight.Name = "pnlQRRight";
            this.pnlQRRight.Padding = new System.Windows.Forms.Padding(15);
            this.pnlQRRight.Size = new System.Drawing.Size(470, 550);
            this.pnlQRRight.TabIndex = 2;
            //
            // lblQRTitle
            //
            this.lblQRTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblQRTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblQRTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblQRTitle.Location = new System.Drawing.Point(15, 15);
            this.lblQRTitle.Name = "lblQRTitle";
            this.lblQRTitle.Size = new System.Drawing.Size(438, 30);
            this.lblQRTitle.TabIndex = 0;
            this.lblQRTitle.Text = "📌 Thanh toán qua Mã VietQR BIDV";
            this.lblQRTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // picQR
            //
            this.picQR.BackColor = System.Drawing.Color.White;
            this.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQR.Location = new System.Drawing.Point(110, 50);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(250, 250);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 1;
            this.picQR.TabStop = false;
            //
            // lblBankInfo
            //
            this.lblBankInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBankInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblBankInfo.Location = new System.Drawing.Point(30, 310);
            this.lblBankInfo.Name = "lblBankInfo";
            this.lblBankInfo.Size = new System.Drawing.Size(410, 110);
            this.lblBankInfo.TabIndex = 2;
            this.lblBankInfo.Text = "🏦 Ngân hàng: BIDV (Ngân hàng TMCP Đầu tư & Phát triển)\r\n💳 Số tài khoản: 8893141886\r\n👤 Chủ tài khoản: NGUYEN VAN NGHIA\r\n💰 Số tiền: 0 đ\r\n📝 Nội dung: HP HV...";
            this.lblBankInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // btnKiemTraChuyenKhoan
            //
            this.btnKiemTraChuyenKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnKiemTraChuyenKhoan.FlatAppearance.BorderSize = 0;
            this.btnKiemTraChuyenKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKiemTraChuyenKhoan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKiemTraChuyenKhoan.ForeColor = System.Drawing.Color.White;
            this.btnKiemTraChuyenKhoan.Location = new System.Drawing.Point(110, 430);
            this.btnKiemTraChuyenKhoan.Name = "btnKiemTraChuyenKhoan";
            this.btnKiemTraChuyenKhoan.Size = new System.Drawing.Size(250, 42);
            this.btnKiemTraChuyenKhoan.TabIndex = 3;
            this.btnKiemTraChuyenKhoan.Text = "🔄 Xác nhận đã chuyển khoản";
            this.btnKiemTraChuyenKhoan.UseVisualStyleBackColor = false;
            this.btnKiemTraChuyenKhoan.Click += new System.EventHandler(this.btnKiemTraChuyenKhoan_Click);
            //
            // frmLapPhieuThu
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.pnlQRRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLapPhieuThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lập Phiếu Thu Học Phí";
            this.Load += new System.EventHandler(this.frmLapPhieuThu_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlQRRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblHocVien;
        private System.Windows.Forms.ComboBox cboHocVien;
        private System.Windows.Forms.Label lblLopHoc;
        private System.Windows.Forms.ComboBox cboLopHoc;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label lblSoTienNop;
        private System.Windows.Forms.TextBox txtSoTienNop;
        private System.Windows.Forms.Label lblPhuongThuc;
        private System.Windows.Forms.ComboBox cboPhuongThuc;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;

        private System.Windows.Forms.Panel pnlQRRight;
        private System.Windows.Forms.Label lblQRTitle;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label lblBankInfo;
        private System.Windows.Forms.Button btnKiemTraChuyenKhoan;
    }
}
