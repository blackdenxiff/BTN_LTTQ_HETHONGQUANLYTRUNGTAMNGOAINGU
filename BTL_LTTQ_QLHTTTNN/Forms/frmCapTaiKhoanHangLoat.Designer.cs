namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmCapTaiKhoanHangLoat
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpChinh = new System.Windows.Forms.TableLayoutPanel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlLoc = new System.Windows.Forms.Panel();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboLoaiHoSo = new System.Windows.Forms.ComboBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnChonTrang = new System.Windows.Forms.Button();
            this.dgvHoSo = new System.Windows.Forms.DataGridView();
            this.colChon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMaHoSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpChan = new System.Windows.Forms.TableLayoutPanel();
            this.tlpThaoTac = new System.Windows.Forms.TableLayoutPanel();
            this.btnTruoc = new System.Windows.Forms.Button();
            this.lblTrang = new System.Windows.Forms.Label();
            this.btnSau = new System.Windows.Forms.Button();
            this.lblSoDaChon = new System.Windows.Forms.Label();
            this.progressCap = new System.Windows.Forms.ProgressBar();
            this.btnCapTaiKhoan = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.tlpChinh.SuspendLayout();
            this.pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoSo)).BeginInit();
            this.tlpChan.SuspendLayout();
            this.tlpThaoTac.SuspendLayout();
            this.SuspendLayout();
            //
            // tlpChinh
            //
            this.tlpChinh.ColumnCount = 1;
            this.tlpChinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChinh.Controls.Add(this.lblTieuDe, 0, 0);
            this.tlpChinh.Controls.Add(this.pnlLoc, 0, 1);
            this.tlpChinh.Controls.Add(this.dgvHoSo, 0, 2);
            this.tlpChinh.Controls.Add(this.tlpChan, 0, 3);
            this.tlpChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChinh.RowCount = 4;
            this.tlpChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tlpChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tlpChinh.Padding = new System.Windows.Forms.Padding(18);
            this.tlpChinh.Name = "tlpChinh";
            //
            // lblTieuDe
            //
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Text = "Cấp tài khoản hàng loạt";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlLoc
            //
            this.pnlLoc.Controls.Add(this.lblLoai);
            this.pnlLoc.Controls.Add(this.cboLoaiHoSo);
            this.pnlLoc.Controls.Add(this.lblTimKiem);
            this.pnlLoc.Controls.Add(this.txtTimKiem);
            this.pnlLoc.Controls.Add(this.btnTim);
            this.pnlLoc.Controls.Add(this.btnChonTrang);
            this.pnlLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoc.Name = "pnlLoc";
            //
            // lblLoai
            //
            this.lblLoai.Location = new System.Drawing.Point(0, 0);
            this.lblLoai.Size = new System.Drawing.Size(180, 22);
            this.lblLoai.Text = "Loại hồ sơ / vai trò";
            //
            // cboLoaiHoSo
            //
            this.cboLoaiHoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiHoSo.Items.AddRange(new object[] { "Học viên", "Giáo viên", "Nhân viên" });
            this.cboLoaiHoSo.Location = new System.Drawing.Point(0, 27);
            this.cboLoaiHoSo.Size = new System.Drawing.Size(190, 28);
            this.cboLoaiHoSo.SelectedIndexChanged += new System.EventHandler(this.cboLoaiHoSo_SelectedIndexChanged);
            //
            // lblTimKiem
            //
            this.lblTimKiem.Location = new System.Drawing.Point(208, 0);
            this.lblTimKiem.Size = new System.Drawing.Size(250, 22);
            this.lblTimKiem.Text = "Tìm theo mã hoặc họ tên";
            //
            // txtTimKiem
            //
            this.txtTimKiem.Location = new System.Drawing.Point(208, 27);
            this.txtTimKiem.Size = new System.Drawing.Size(310, 27);
            //
            // btnTim
            //
            this.btnTim.Location = new System.Drawing.Point(528, 24);
            this.btnTim.Size = new System.Drawing.Size(90, 34);
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            //
            // btnChonTrang
            //
            this.btnChonTrang.Location = new System.Drawing.Point(628, 24);
            this.btnChonTrang.Size = new System.Drawing.Size(165, 34);
            this.btnChonTrang.Text = "Chọn tất cả trang";
            this.btnChonTrang.Click += new System.EventHandler(this.ChonHoSoTrangHienTai);
            //
            // dgvHoSo
            //
            this.dgvHoSo.AutoGenerateColumns = false;
            this.dgvHoSo.AllowUserToAddRows = false;
            this.dgvHoSo.AllowUserToDeleteRows = false;
            this.dgvHoSo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoSo.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoSo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colChon, this.colMaHoSo, this.colTenDangNhap, this.colHoTen, this.colLoai });
            this.dgvHoSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoSo.MultiSelect = false;
            this.dgvHoSo.Name = "dgvHoSo";
            this.dgvHoSo.RowHeadersVisible = false;
            this.dgvHoSo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoSo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoSo_CellValueChanged);
            //
            // colChon
            //
            this.colChon.DataPropertyName = "DaChon";
            this.colChon.HeaderText = "Chọn";
            this.colChon.Name = "colChon";
            this.colChon.FillWeight = 45F;
            //
            // colMaHoSo
            //
            this.colMaHoSo.DataPropertyName = "HoSoID";
            this.colMaHoSo.HeaderText = "Mã hồ sơ";
            this.colMaHoSo.Name = "colMaHoSo";
            this.colMaHoSo.ReadOnly = true;
            this.colMaHoSo.FillWeight = 70F;
            //
            // colTenDangNhap
            //
            this.colTenDangNhap.DataPropertyName = "TenDangNhapDuKien";
            this.colTenDangNhap.HeaderText = "Tên đăng nhập dự kiến";
            this.colTenDangNhap.Name = "colTenDangNhap";
            this.colTenDangNhap.ReadOnly = true;
            this.colTenDangNhap.FillWeight = 110F;
            //
            // colHoTen
            //
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.HeaderText = "Họ tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            this.colHoTen.FillWeight = 160F;
            //
            // colLoai
            //
            this.colLoai.DataPropertyName = "LoaiHoSo";
            this.colLoai.HeaderText = "Vai trò dự kiến";
            this.colLoai.Name = "colLoai";
            this.colLoai.ReadOnly = true;
            this.colLoai.FillWeight = 90F;
            //
            // tlpChan
            //
            this.tlpChan.ColumnCount = 3;
            this.tlpChan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpChan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpChan.Controls.Add(this.btnTruoc, 0, 0);
            this.tlpChan.Controls.Add(this.lblTrang, 1, 0);
            this.tlpChan.Controls.Add(this.btnSau, 2, 0);
            this.tlpChan.Controls.Add(this.tlpThaoTac, 0, 1);
            this.tlpChan.SetColumnSpan(this.tlpThaoTac, 3);
            this.tlpChan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChan.Name = "tlpChan";
            this.tlpChan.RowCount = 2;
            this.tlpChan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpChan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // tlpThaoTac
            //
            this.tlpThaoTac.ColumnCount = 4;
            this.tlpThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tlpThaoTac.Controls.Add(this.lblTrangThai, 0, 0);
            this.tlpThaoTac.Controls.Add(this.progressCap, 1, 0);
            this.tlpThaoTac.Controls.Add(this.lblSoDaChon, 2, 0);
            this.tlpThaoTac.Controls.Add(this.btnCapTaiKhoan, 3, 0);
            this.tlpThaoTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThaoTac.Name = "tlpThaoTac";
            this.tlpThaoTac.RowCount = 1;
            this.tlpThaoTac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // btnTruoc
            //
            this.btnTruoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTruoc.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.btnTruoc.Text = "Trước";
            this.btnTruoc.Click += new System.EventHandler(this.btnTruoc_Click);
            //
            // lblTrang
            //
            this.lblTrang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrang.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnSau
            //
            this.btnSau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSau.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnSau.Text = "Sau";
            this.btnSau.Click += new System.EventHandler(this.btnSau_Click);
            //
            // lblSoDaChon
            //
            this.lblSoDaChon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoDaChon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoDaChon.Text = "Đã chọn 0 hồ sơ";
            this.lblSoDaChon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // progressCap
            //
            this.progressCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressCap.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.progressCap.Visible = false;
            //
            // btnCapTaiKhoan
            //
            this.btnCapTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCapTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.btnCapTaiKhoan.Text = "Tạo tài khoản đã chọn";
            this.btnCapTaiKhoan.Enabled = false;
            this.btnCapTaiKhoan.Click += new System.EventHandler(this.btnCapTaiKhoan_Click);
            //
            // lblTrangThai
            //
            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThai.AutoEllipsis = true;
            this.lblTrangThai.Text = "Chọn các hồ sơ đủ điều kiện cần cấp tài khoản.";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // frmCapTaiKhoanHangLoat
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 700);
            this.Controls.Add(this.tlpChinh);
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "frmCapTaiKhoanHangLoat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cấp tài khoản hàng loạt";
            this.tlpChinh.ResumeLayout(false);
            this.pnlLoc.ResumeLayout(false);
            this.pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoSo)).EndInit();
            this.tlpChan.ResumeLayout(false);
            this.tlpThaoTac.ResumeLayout(false);
            this.tlpThaoTac.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpChinh;
        private System.Windows.Forms.Label lblTieuDe, lblLoai, lblTimKiem, lblTrang, lblSoDaChon, lblTrangThai;
        private System.Windows.Forms.Panel pnlLoc;
        private System.Windows.Forms.TableLayoutPanel tlpChan, tlpThaoTac;
        private System.Windows.Forms.ComboBox cboLoaiHoSo;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTim, btnChonTrang, btnTruoc, btnSau, btnCapTaiKhoan;
        private System.Windows.Forms.ProgressBar progressCap;
        private System.Windows.Forms.DataGridView dgvHoSo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHoSo, colTenDangNhap, colHoTen, colLoai;
    }
}
