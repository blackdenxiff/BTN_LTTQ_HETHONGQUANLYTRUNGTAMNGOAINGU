namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmThongKe
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label(); this.dtpTuNgay = new System.Windows.Forms.DateTimePicker(); this.dtpDenNgay = new System.Windows.Forms.DateTimePicker(); this.cboCoSo = new System.Windows.Forms.ComboBox();
            this.btnXem = new System.Windows.Forms.Button(); this.btnDatLai = new System.Windows.Forms.Button(); this.btnTongQuan = new System.Windows.Forms.Button(); this.lblTrangThai = new System.Windows.Forms.Label(); this.lblTongHop = new System.Windows.Forms.Label(); this.pnlBieuDo = new System.Windows.Forms.Panel();
            this.tabs = new System.Windows.Forms.TabControl(); this.tabHoaDon = new System.Windows.Forms.TabPage(); this.tabThanhToan = new System.Windows.Forms.TabPage(); this.tabDangKy = new System.Windows.Forms.TabPage();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView(); this.dgvThanhToan = new System.Windows.Forms.DataGridView(); this.dgvDangKy = new System.Windows.Forms.DataGridView();
            this.lblHoaDonTrang = new System.Windows.Forms.Label(); this.lblThanhToanTrang = new System.Windows.Forms.Label(); this.lblDangKyTrang = new System.Windows.Forms.Label();
            this.btnHoaDonTruoc = new System.Windows.Forms.Button(); this.btnHoaDonSau = new System.Windows.Forms.Button(); this.btnThanhToanTruoc = new System.Windows.Forms.Button(); this.btnThanhToanSau = new System.Windows.Forms.Button(); this.btnDangKyTruoc = new System.Windows.Forms.Button(); this.btnDangKySau = new System.Windows.Forms.Button();
            this.lblGiaiThich = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252); this.ClientSize = new System.Drawing.Size(1120, 780); this.Dock = System.Windows.Forms.DockStyle.Fill; this.Name = "frmThongKe"; this.Text = "Thống kê chi tiết";
            this.lblTieuDe.Text = "Thống kê chi tiết"; this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold); this.lblTieuDe.Location = new System.Drawing.Point(20, 15); this.lblTieuDe.Size = new System.Drawing.Size(400, 36);
            this.dtpTuNgay.Location = new System.Drawing.Point(24, 64); this.dtpTuNgay.Size = new System.Drawing.Size(220, 27); this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpDenNgay.Location = new System.Drawing.Point(260, 64); this.dtpDenNgay.Size = new System.Drawing.Size(220, 27); this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpDenNgay.Name = "dtpDenNgay";
            this.cboCoSo.Location = new System.Drawing.Point(496, 64); this.cboCoSo.Size = new System.Drawing.Size(230, 27); this.cboCoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboCoSo.Name = "cboCoSo";
            this.btnXem.Text = "Xem thống kê"; this.btnXem.Location = new System.Drawing.Point(744, 60); this.btnXem.Size = new System.Drawing.Size(140, 34); this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            this.btnDatLai.Text = "Đặt lại"; this.btnDatLai.Location = new System.Drawing.Point(896, 60); this.btnDatLai.Size = new System.Drawing.Size(100, 34); this.btnDatLai.Click += new System.EventHandler(this.btnDatLai_Click);
            this.lblTongHop.Location = new System.Drawing.Point(24, 108); this.lblTongHop.Size = new System.Drawing.Size(1060, 34); this.lblTongHop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); this.lblTongHop.Text = "Chọn khoảng ngày rồi xem thống kê.";
            this.pnlBieuDo.Location = new System.Drawing.Point(24, 148); this.pnlBieuDo.Size = new System.Drawing.Size(1060, 134); this.pnlBieuDo.BackColor = System.Drawing.Color.White; this.pnlBieuDo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.pnlBieuDo.Name = "pnlBieuDo"; this.pnlBieuDo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBieuDo_Paint);
            this.lblGiaiThich.Location = new System.Drawing.Point(24, 288); this.lblGiaiThich.Size = new System.Drawing.Size(1060, 42); this.lblGiaiThich.Text = "Thực thu theo ngày thanh toán; hóa đơn theo ngày lập, số phải thu được tính tới hết ngày cuối kỳ.";
            this.btnTongQuan.Text = "Tổng quan"; this.btnTongQuan.Location = new System.Drawing.Point(1000, 60); this.btnTongQuan.Size = new System.Drawing.Size(100, 34); this.btnTongQuan.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right; this.btnTongQuan.Click += new System.EventHandler(this.btnTongQuan_Click);
            this.tabs.Location = new System.Drawing.Point(24, 334); this.tabs.Size = new System.Drawing.Size(1060, 404); this.tabs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right; this.tabs.Controls.Add(this.tabHoaDon); this.tabs.Controls.Add(this.tabThanhToan); this.tabs.Controls.Add(this.tabDangKy);
            TaoTab(this.tabHoaDon, "Hóa đơn trong kỳ", this.dgvHoaDon, this.btnHoaDonTruoc, this.lblHoaDonTrang, this.btnHoaDonSau);
            TaoTab(this.tabThanhToan, "Thanh toán phát sinh", this.dgvThanhToan, this.btnThanhToanTruoc, this.lblThanhToanTrang, this.btnThanhToanSau);
            TaoTab(this.tabDangKy, "Đăng ký trong kỳ", this.dgvDangKy, this.btnDangKyTruoc, this.lblDangKyTrang, this.btnDangKySau);
            this.Controls.Add(this.lblTieuDe); this.Controls.Add(this.dtpTuNgay); this.Controls.Add(this.dtpDenNgay); this.Controls.Add(this.cboCoSo); this.Controls.Add(this.btnXem); this.Controls.Add(this.btnDatLai); this.Controls.Add(this.btnTongQuan); this.Controls.Add(this.lblTongHop); this.Controls.Add(this.pnlBieuDo); this.Controls.Add(this.lblGiaiThich); this.Controls.Add(this.tabs); this.Controls.Add(this.lblTrangThai);
            this.lblTrangThai.Location = new System.Drawing.Point(24, 750); this.lblTrangThai.Size = new System.Drawing.Size(800, 24); this.lblTrangThai.Text = "";
            this.ResumeLayout(false); this.PerformLayout();
        }
        private void TaoTab(System.Windows.Forms.TabPage tab, string title, System.Windows.Forms.DataGridView grid, System.Windows.Forms.Button prev, System.Windows.Forms.Label page, System.Windows.Forms.Button next)
        {
            tab.Text = title; grid.Dock = System.Windows.Forms.DockStyle.Fill; grid.ReadOnly = true; grid.AllowUserToAddRows = false; grid.AllowUserToDeleteRows = false; grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; grid.BackgroundColor = System.Drawing.Color.White; grid.RowHeadersVisible = false;
            prev.Text = "Trước"; prev.Dock = System.Windows.Forms.DockStyle.Left; prev.Width = 90; next.Text = "Sau"; next.Dock = System.Windows.Forms.DockStyle.Right; next.Width = 90; page.Dock = System.Windows.Forms.DockStyle.Fill; page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            var bar = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Bottom, Height = 34 }; bar.Controls.Add(page); bar.Controls.Add(prev); bar.Controls.Add(next); tab.Controls.Add(grid); tab.Controls.Add(bar);
        }
        private System.Windows.Forms.Label lblTieuDe, lblTongHop, lblGiaiThich, lblTrangThai, lblHoaDonTrang, lblThanhToanTrang, lblDangKyTrang;
        private System.Windows.Forms.DateTimePicker dtpTuNgay, dtpDenNgay;
        private System.Windows.Forms.ComboBox cboCoSo;
        private System.Windows.Forms.Button btnXem, btnDatLai, btnTongQuan, btnHoaDonTruoc, btnHoaDonSau, btnThanhToanTruoc, btnThanhToanSau, btnDangKyTruoc, btnDangKySau;
        private System.Windows.Forms.Panel pnlBieuDo;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabHoaDon, tabThanhToan, tabDangKy;
        private System.Windows.Forms.DataGridView dgvHoaDon, dgvThanhToan, dgvDangKy;
    }
}
