using System;

namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmThongKe
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.cboCoSo = new System.Windows.Forms.ComboBox();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnDatLai = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnTongQuan = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTongHop = new System.Windows.Forms.Label();
            this.lblHoaDonTong = new System.Windows.Forms.Label();
            this.lblThanhToanTong = new System.Windows.Forms.Label();
            this.lblDangKyTong = new System.Windows.Forms.Label();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabHoaDon = new System.Windows.Forms.TabPage();
            this.tabThanhToan = new System.Windows.Forms.TabPage();
            this.tabDangKy = new System.Windows.Forms.TabPage();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.dgvThanhToan = new System.Windows.Forms.DataGridView();
            this.dgvDangKy = new System.Windows.Forms.DataGridView();
            this.lblHoaDonTrang = new System.Windows.Forms.Label();
            this.lblThanhToanTrang = new System.Windows.Forms.Label();
            this.lblDangKyTrang = new System.Windows.Forms.Label();
            this.btnHoaDonTruoc = new System.Windows.Forms.Button();
            this.btnHoaDonSau = new System.Windows.Forms.Button();
            this.btnThanhToanTruoc = new System.Windows.Forms.Button();
            this.btnThanhToanSau = new System.Windows.Forms.Button();
            this.btnDangKyTruoc = new System.Windows.Forms.Button();
            this.btnDangKySau = new System.Windows.Forms.Button();
            this.lblGiaiThich = new System.Windows.Forms.Label();
            this.tabs.SuspendLayout();
            this.tabHoaDon.SuspendLayout();
            this.tabThanhToan.SuspendLayout();
            this.tabDangKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Location = new System.Drawing.Point(20, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(400, 36);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Thống kê chi tiết";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(24, 64);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(220, 22);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(260, 64);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(220, 22);
            this.dtpDenNgay.TabIndex = 2;
            // 
            // cboCoSo
            // 
            this.cboCoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCoSo.Location = new System.Drawing.Point(496, 64);
            this.cboCoSo.Name = "cboCoSo";
            this.cboCoSo.Size = new System.Drawing.Size(230, 24);
            this.cboCoSo.TabIndex = 3;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(744, 60);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(140, 34);
            this.btnXem.TabIndex = 4;
            this.btnXem.Text = "Xem thống kê";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnDatLai
            // 
            this.btnDatLai.Location = new System.Drawing.Point(896, 60);
            this.btnDatLai.Name = "btnDatLai";
            this.btnDatLai.Size = new System.Drawing.Size(100, 34);
            this.btnDatLai.TabIndex = 5;
            this.btnDatLai.Text = "Đặt lại";
            this.btnDatLai.Click += new System.EventHandler(this.btnDatLai_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatExcel.Location = new System.Drawing.Point(1010, 60);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(140, 34);
            this.btnXuatExcel.TabIndex = 6;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnTongQuan
            // 
            this.btnTongQuan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTongQuan.Location = new System.Drawing.Point(1060, 15);
            this.btnTongQuan.Name = "btnTongQuan";
            this.btnTongQuan.Size = new System.Drawing.Size(100, 34);
            this.btnTongQuan.TabIndex = 12;
            this.btnTongQuan.Text = "Tổng quan";
            this.btnTongQuan.Click += new System.EventHandler(this.btnTongQuan_Click);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTrangThai.Location = new System.Drawing.Point(24, 635);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(800, 24);
            this.lblTrangThai.TabIndex = 11;
            // 
            // lblTongHop
            // 
            this.lblTongHop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongHop.Location = new System.Drawing.Point(24, 108);
            this.lblTongHop.Name = "lblTongHop";
            this.lblTongHop.Size = new System.Drawing.Size(1060, 34);
            this.lblTongHop.TabIndex = 7;
            this.lblTongHop.Text = "Chọn khoảng ngày rồi xem thống kê.";
            // 
            // lblHoaDonTong
            // 
            this.lblHoaDonTong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblHoaDonTong.Location = new System.Drawing.Point(0, 373);
            this.lblHoaDonTong.Name = "lblHoaDonTong";
            this.lblHoaDonTong.Padding = new System.Windows.Forms.Padding(8);
            this.lblHoaDonTong.Size = new System.Drawing.Size(1140, 38);
            this.lblHoaDonTong.TabIndex = 0;
            this.lblHoaDonTong.Text = "Tổng hợp hóa đơn";
            this.lblHoaDonTong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblThanhToanTong
            // 
            this.lblThanhToanTong.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblThanhToanTong.Location = new System.Drawing.Point(0, 0);
            this.lblThanhToanTong.Name = "lblThanhToanTong";
            this.lblThanhToanTong.Padding = new System.Windows.Forms.Padding(8);
            this.lblThanhToanTong.Size = new System.Drawing.Size(1140, 38);
            this.lblThanhToanTong.TabIndex = 0;
            this.lblThanhToanTong.Text = "Tổng hợp thanh toán";
            this.lblThanhToanTong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDangKyTong
            // 
            this.lblDangKyTong.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDangKyTong.Location = new System.Drawing.Point(0, 0);
            this.lblDangKyTong.Name = "lblDangKyTong";
            this.lblDangKyTong.Padding = new System.Windows.Forms.Padding(8);
            this.lblDangKyTong.Size = new System.Drawing.Size(1140, 38);
            this.lblDangKyTong.TabIndex = 0;
            this.lblDangKyTong.Text = "Tổng hợp đăng ký";
            this.lblDangKyTong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabHoaDon);
            this.tabs.Controls.Add(this.tabThanhToan);
            this.tabs.Controls.Add(this.tabDangKy);
            this.tabs.Location = new System.Drawing.Point(24, 176);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1148, 440);
            this.tabs.TabIndex = 10;
            // 
            // tabHoaDon
            // 
            this.tabHoaDon.Controls.Add(this.lblHoaDonTong);
            this.tabHoaDon.Location = new System.Drawing.Point(4, 25);
            this.tabHoaDon.Name = "tabHoaDon";
            this.tabHoaDon.Size = new System.Drawing.Size(1140, 411);
            this.tabHoaDon.TabIndex = 0;
            this.tabHoaDon.Text = "Hóa đơn trong kỳ";
            // 
            // tabThanhToan
            // 
            this.tabThanhToan.Controls.Add(this.lblThanhToanTong);
            this.tabThanhToan.Location = new System.Drawing.Point(4, 25);
            this.tabThanhToan.Name = "tabThanhToan";
            this.tabThanhToan.Size = new System.Drawing.Size(1140, 411);
            this.tabThanhToan.TabIndex = 1;
            this.tabThanhToan.Text = "Thanh toán phát sinh";
            // 
            // tabDangKy
            // 
            this.tabDangKy.Controls.Add(this.lblDangKyTong);
            this.tabDangKy.Location = new System.Drawing.Point(4, 25);
            this.tabDangKy.Name = "tabDangKy";
            this.tabDangKy.Size = new System.Drawing.Size(1140, 411);
            this.tabDangKy.TabIndex = 2;
            this.tabDangKy.Text = "Đăng ký trong kỳ";
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeight = 29;
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 0);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.Size = new System.Drawing.Size(240, 150);
            this.dgvHoaDon.TabIndex = 0;
            // 
            // dgvThanhToan
            // 
            this.dgvThanhToan.ColumnHeadersHeight = 29;
            this.dgvThanhToan.Location = new System.Drawing.Point(0, 0);
            this.dgvThanhToan.Name = "dgvThanhToan";
            this.dgvThanhToan.RowHeadersWidth = 51;
            this.dgvThanhToan.Size = new System.Drawing.Size(240, 150);
            this.dgvThanhToan.TabIndex = 0;
            // 
            // dgvDangKy
            // 
            this.dgvDangKy.ColumnHeadersHeight = 29;
            this.dgvDangKy.Location = new System.Drawing.Point(0, 0);
            this.dgvDangKy.Name = "dgvDangKy";
            this.dgvDangKy.RowHeadersWidth = 51;
            this.dgvDangKy.Size = new System.Drawing.Size(240, 150);
            this.dgvDangKy.TabIndex = 0;
            // 
            // lblHoaDonTrang
            // 
            this.lblHoaDonTrang.Location = new System.Drawing.Point(0, 0);
            this.lblHoaDonTrang.Name = "lblHoaDonTrang";
            this.lblHoaDonTrang.Size = new System.Drawing.Size(100, 23);
            this.lblHoaDonTrang.TabIndex = 0;
            // 
            // lblThanhToanTrang
            // 
            this.lblThanhToanTrang.Location = new System.Drawing.Point(0, 0);
            this.lblThanhToanTrang.Name = "lblThanhToanTrang";
            this.lblThanhToanTrang.Size = new System.Drawing.Size(100, 23);
            this.lblThanhToanTrang.TabIndex = 0;
            // 
            // lblDangKyTrang
            // 
            this.lblDangKyTrang.Location = new System.Drawing.Point(0, 0);
            this.lblDangKyTrang.Name = "lblDangKyTrang";
            this.lblDangKyTrang.Size = new System.Drawing.Size(100, 23);
            this.lblDangKyTrang.TabIndex = 0;
            // 
            // btnHoaDonTruoc
            // 
            this.btnHoaDonTruoc.Location = new System.Drawing.Point(0, 0);
            this.btnHoaDonTruoc.Name = "btnHoaDonTruoc";
            this.btnHoaDonTruoc.Size = new System.Drawing.Size(75, 23);
            this.btnHoaDonTruoc.TabIndex = 0;
            // 
            // btnHoaDonSau
            // 
            this.btnHoaDonSau.Location = new System.Drawing.Point(0, 0);
            this.btnHoaDonSau.Name = "btnHoaDonSau";
            this.btnHoaDonSau.Size = new System.Drawing.Size(75, 23);
            this.btnHoaDonSau.TabIndex = 0;
            // 
            // btnThanhToanTruoc
            // 
            this.btnThanhToanTruoc.Location = new System.Drawing.Point(0, 0);
            this.btnThanhToanTruoc.Name = "btnThanhToanTruoc";
            this.btnThanhToanTruoc.Size = new System.Drawing.Size(75, 23);
            this.btnThanhToanTruoc.TabIndex = 0;
            // 
            // btnThanhToanSau
            // 
            this.btnThanhToanSau.Location = new System.Drawing.Point(0, 0);
            this.btnThanhToanSau.Name = "btnThanhToanSau";
            this.btnThanhToanSau.Size = new System.Drawing.Size(75, 23);
            this.btnThanhToanSau.TabIndex = 0;
            // 
            // btnDangKyTruoc
            // 
            this.btnDangKyTruoc.Location = new System.Drawing.Point(0, 0);
            this.btnDangKyTruoc.Name = "btnDangKyTruoc";
            this.btnDangKyTruoc.Size = new System.Drawing.Size(75, 23);
            this.btnDangKyTruoc.TabIndex = 0;
            // 
            // btnDangKySau
            // 
            this.btnDangKySau.Location = new System.Drawing.Point(0, 0);
            this.btnDangKySau.Name = "btnDangKySau";
            this.btnDangKySau.Size = new System.Drawing.Size(75, 23);
            this.btnDangKySau.TabIndex = 0;
            // 
            // lblGiaiThich
            // 
            this.lblGiaiThich.Location = new System.Drawing.Point(28, 142);
            this.lblGiaiThich.Name = "lblGiaiThich";
            this.lblGiaiThich.Size = new System.Drawing.Size(573, 20);
            this.lblGiaiThich.TabIndex = 9;
            this.lblGiaiThich.Text = "Thực thu theo ngày thanh toán; hóa đơn theo ngày lập, số phải thu được tính tới h" +
    "ết ngày cuối kỳ.";
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1184, 676);
            this.Controls.Add(this.lblGiaiThich);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.cboCoSo);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnDatLai);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnTongQuan);
            this.Controls.Add(this.lblTongHop);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.lblTrangThai);
            this.Name = "frmThongKe";
            this.Text = "Thống kê chi tiết";
            this.tabs.ResumeLayout(false);
            this.tabHoaDon.ResumeLayout(false);
            this.tabThanhToan.ResumeLayout(false);
            this.tabDangKy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Label lblTieuDe, lblTongHop, lblGiaiThich, lblTrangThai, lblHoaDonTrang, lblThanhToanTrang, lblDangKyTrang;
        private System.Windows.Forms.DateTimePicker dtpTuNgay, dtpDenNgay;
        private System.Windows.Forms.ComboBox cboCoSo;
        private System.Windows.Forms.Button btnXem, btnDatLai, btnXuatExcel, btnTongQuan, btnHoaDonTruoc, btnHoaDonSau, btnThanhToanTruoc, btnThanhToanSau, btnDangKyTruoc, btnDangKySau;
        private System.Windows.Forms.Label lblHoaDonTong, lblThanhToanTong, lblDangKyTong;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabHoaDon, tabThanhToan, tabDangKy;
        private System.Windows.Forms.DataGridView dgvHoaDon, dgvThanhToan, dgvDangKy;
    }
}
