namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmChiTietKhoaHoc
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
            this.lblMaKhoaHoc = new System.Windows.Forms.Label();
            this.txtMaKhoaHoc = new System.Windows.Forms.TextBox();
            this.lblTenKhoaHoc = new System.Windows.Forms.Label();
            this.txtTenKhoaHoc = new System.Windows.Forms.TextBox();
            this.lblTrinhDo = new System.Windows.Forms.Label();
            this.cboTrinhDo = new System.Windows.Forms.ComboBox();
            this.lblSoBuoi = new System.Windows.Forms.Label();
            this.numSoBuoi = new System.Windows.Forms.NumericUpDown();
            this.lblHocPhi = new System.Windows.Forms.Label();
            this.numHocPhi = new System.Windows.Forms.NumericUpDown();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSoBuoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHocPhi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaKhoaHoc
            // 
            this.lblMaKhoaHoc.AutoSize = true;
            this.lblMaKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaKhoaHoc.Location = new System.Drawing.Point(30, 25);
            this.lblMaKhoaHoc.Name = "lblMaKhoaHoc";
            this.lblMaKhoaHoc.Size = new System.Drawing.Size(111, 20);
            this.lblMaKhoaHoc.TabIndex = 0;
            this.lblMaKhoaHoc.Text = "Mã Khóa Học *";
            // 
            // txtMaKhoaHoc
            // 
            this.txtMaKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaKhoaHoc.Location = new System.Drawing.Point(34, 50);
            this.txtMaKhoaHoc.Name = "txtMaKhoaHoc";
            this.txtMaKhoaHoc.Size = new System.Drawing.Size(250, 30);
            this.txtMaKhoaHoc.TabIndex = 1;
            // 
            // lblTenKhoaHoc
            // 
            this.lblTenKhoaHoc.AutoSize = true;
            this.lblTenKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTenKhoaHoc.Location = new System.Drawing.Point(310, 25);
            this.lblTenKhoaHoc.Name = "lblTenKhoaHoc";
            this.lblTenKhoaHoc.Size = new System.Drawing.Size(114, 20);
            this.lblTenKhoaHoc.TabIndex = 2;
            this.lblTenKhoaHoc.Text = "Tên Khóa Học *";
            // 
            // txtTenKhoaHoc
            // 
            this.txtTenKhoaHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenKhoaHoc.Location = new System.Drawing.Point(314, 50);
            this.txtTenKhoaHoc.Name = "txtTenKhoaHoc";
            this.txtTenKhoaHoc.Size = new System.Drawing.Size(350, 30);
            this.txtTenKhoaHoc.TabIndex = 3;
            // 
            // lblTrinhDo
            // 
            this.lblTrinhDo.AutoSize = true;
            this.lblTrinhDo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrinhDo.Location = new System.Drawing.Point(30, 95);
            this.lblTrinhDo.Name = "lblTrinhDo";
            this.lblTrinhDo.Size = new System.Drawing.Size(183, 20);
            this.lblTrinhDo.TabIndex = 4;
            this.lblTrinhDo.Text = "Chuẩn Đầu Ra / Cấp Độ *";
            // 
            // cboTrinhDo
            // 
            this.cboTrinhDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrinhDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrinhDo.FormattingEnabled = true;
            this.cboTrinhDo.Location = new System.Drawing.Point(34, 120);
            this.cboTrinhDo.Name = "cboTrinhDo";
            this.cboTrinhDo.Size = new System.Drawing.Size(200, 31);
            this.cboTrinhDo.TabIndex = 5;
            // 
            // lblSoBuoi
            // 
            this.lblSoBuoi.AutoSize = true;
            this.lblSoBuoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoBuoi.Location = new System.Drawing.Point(250, 95);
            this.lblSoBuoi.Name = "lblSoBuoi";
            this.lblSoBuoi.Size = new System.Drawing.Size(193, 20);
            this.lblSoBuoi.TabIndex = 6;
            this.lblSoBuoi.Text = "Số Buổi Học (1 - 120 buổi) *";
            // 
            // numSoBuoi
            // 
            this.numSoBuoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numSoBuoi.Location = new System.Drawing.Point(254, 120);
            this.numSoBuoi.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            this.numSoBuoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoBuoi.Name = "numSoBuoi";
            this.numSoBuoi.Size = new System.Drawing.Size(190, 30);
            this.numSoBuoi.TabIndex = 7;
            this.numSoBuoi.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblHocPhi
            // 
            this.lblHocPhi.AutoSize = true;
            this.lblHocPhi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHocPhi.Location = new System.Drawing.Point(460, 95);
            this.lblHocPhi.Name = "lblHocPhi";
            this.lblHocPhi.Size = new System.Drawing.Size(183, 20);
            this.lblHocPhi.TabIndex = 8;
            this.lblHocPhi.Text = "Học Phí Niêm Yết (VNĐ) *";
            // 
            // numHocPhi
            // 
            this.numHocPhi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numHocPhi.Location = new System.Drawing.Point(464, 120);
            this.numHocPhi.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numHocPhi.Name = "numHocPhi";
            this.numHocPhi.Size = new System.Drawing.Size(200, 30);
            this.numHocPhi.TabIndex = 9;
            this.numHocPhi.ThousandsSeparator = true;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMoTa.Location = new System.Drawing.Point(30, 165);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(263, 20);
            this.lblMoTa.TabIndex = 10;
            this.lblMoTa.Text = "Tóm Tắt Lộ Trình & Mục Tiêu Đào Tạo";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMoTa.Location = new System.Drawing.Point(34, 190);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTa.Size = new System.Drawing.Size(630, 90);
            this.txtMoTa.TabIndex = 11;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.Location = new System.Drawing.Point(30, 295);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(157, 20);
            this.lblTrangThai.TabIndex = 12;
            this.lblTrangThai.Text = "Trạng Thái Tuyển Sinh";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(34, 320);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(250, 31);
            this.cboTrangThai.TabIndex = 13;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(440, 370);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(90, 38);
            this.btnDong.TabIndex = 14;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(544, 370);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(120, 38);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "Lưu Khóa Học";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmChiTietKhoaHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(698, 430);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.numHocPhi);
            this.Controls.Add(this.lblHocPhi);
            this.Controls.Add(this.numSoBuoi);
            this.Controls.Add(this.lblSoBuoi);
            this.Controls.Add(this.cboTrinhDo);
            this.Controls.Add(this.lblTrinhDo);
            this.Controls.Add(this.txtTenKhoaHoc);
            this.Controls.Add(this.lblTenKhoaHoc);
            this.Controls.Add(this.txtMaKhoaHoc);
            this.Controls.Add(this.lblMaKhoaHoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmChiTietKhoaHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi Tiết Khóa Học";
            this.Load += new System.EventHandler(this.frmChiTietKhoaHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSoBuoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHocPhi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaKhoaHoc;
        private System.Windows.Forms.TextBox txtMaKhoaHoc;
        private System.Windows.Forms.Label lblTenKhoaHoc;
        private System.Windows.Forms.TextBox txtTenKhoaHoc;
        private System.Windows.Forms.Label lblTrinhDo;
        private System.Windows.Forms.ComboBox cboTrinhDo;
        private System.Windows.Forms.Label lblSoBuoi;
        private System.Windows.Forms.NumericUpDown numSoBuoi;
        private System.Windows.Forms.Label lblHocPhi;
        private System.Windows.Forms.NumericUpDown numHocPhi;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLuu;
    }
}