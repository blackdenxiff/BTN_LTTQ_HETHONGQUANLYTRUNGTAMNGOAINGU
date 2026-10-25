using System;
namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmThongKe
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
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
            this.pnlTieuDe = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.btnTongQuan = new System.Windows.Forms.Button();
            this.flpBoLoc = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblCoSo = new System.Windows.Forms.Label();
            this.cboCoSo = new System.Windows.Forms.ComboBox();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnDatLai = new System.Windows.Forms.Button();
            this.lblLoaiBaoCao = new System.Windows.Forms.Label();
            this.cboLoaiBaoCao = new System.Windows.Forms.ComboBox();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.lblTongHop = new System.Windows.Forms.Label();
            this.lblGiaiThich = new System.Windows.Forms.Label();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabHoaDon = new System.Windows.Forms.TabPage();
            this.tlpHoaDon = new System.Windows.Forms.TableLayoutPanel();
            this.lblHoaDonTong = new System.Windows.Forms.Label();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.colHoaDonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoaDonHocVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongPhaiTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDaThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConPhaiThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThuVuot = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.flpHoaDonTrang = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHoaDonTruoc = new System.Windows.Forms.Button();
            this.lblHoaDonTrang = new System.Windows.Forms.Label();
            this.btnHoaDonSau = new System.Windows.Forms.Button();
            this.tabThanhToan = new System.Windows.Forms.TabPage();
            this.tlpThanhToan = new System.Windows.Forms.TableLayoutPanel();
            this.lblThanhToanTong = new System.Windows.Forms.Label();
            this.dgvThanhToan = new System.Windows.Forms.DataGridView();
            this.colThanhToanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhToanHoaDonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhToanHocVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpThanhToanTrang = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThanhToanTruoc = new System.Windows.Forms.Button();
            this.lblThanhToanTrang = new System.Windows.Forms.Label();
            this.btnThanhToanSau = new System.Windows.Forms.Button();
            this.tabDangKy = new System.Windows.Forms.TabPage();
            this.tlpDangKy = new System.Windows.Forms.TableLayoutPanel();
            this.lblDangKyTong = new System.Windows.Forms.Label();
            this.dgvDangKy = new System.Windows.Forms.DataGridView();
            this.colDangKyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayDangKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDangKyHocVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLopHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThaiDangKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpDangKyTrang = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDangKyTruoc = new System.Windows.Forms.Button();
            this.lblDangKyTrang = new System.Windows.Forms.Label();
            this.btnDangKySau = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.tlpChinh.SuspendLayout();
            this.pnlTieuDe.SuspendLayout();
            this.flpBoLoc.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabHoaDon.SuspendLayout();
            this.tabThanhToan.SuspendLayout();
            this.tabDangKy.SuspendLayout();
            this.tlpHoaDon.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit(); this.flpHoaDonTrang.SuspendLayout();
            this.tlpThanhToan.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).BeginInit(); this.flpThanhToanTrang.SuspendLayout();
            this.tlpDangKy.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).BeginInit(); this.flpDangKyTrang.SuspendLayout();
            this.SuspendLayout();

            // tlpChinh

            this.tlpChinh.ColumnCount = 1; this.tlpChinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChinh.Controls.Add(this.pnlTieuDe, 0, 0); this.tlpChinh.Controls.Add(this.flpBoLoc, 0, 1); this.tlpChinh.Controls.Add(this.lblTongHop, 0, 2); this.tlpChinh.Controls.Add(this.lblGiaiThich, 0, 3); this.tlpChinh.Controls.Add(this.tabs, 0, 4); this.tlpChinh.Controls.Add(this.lblTrangThai, 0, 5);
            this.tlpChinh.Dock = System.Windows.Forms.DockStyle.Fill; this.tlpChinh.Padding = new System.Windows.Forms.Padding(18); this.tlpChinh.Name = "tlpChinh"; this.tlpChinh.RowCount = 6;
            this.tlpChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F)); this.tlpChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F)); this.tlpChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); this.tlpChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); this.tlpChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); this.tlpChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));

            // pnlTieuDe

            this.pnlTieuDe.Controls.Add(this.lblTieuDe); this.pnlTieuDe.Controls.Add(this.btnTongQuan); this.pnlTieuDe.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlTieuDe.Name = "pnlTieuDe";
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Fill; this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold); this.lblTieuDe.Name = "lblTieuDe"; this.lblTieuDe.Text = "Thống kê"; this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTongQuan.Dock = System.Windows.Forms.DockStyle.Right; this.btnTongQuan.Name = "btnTongQuan"; this.btnTongQuan.Size = new System.Drawing.Size(110, 38); this.btnTongQuan.Text = "Tổng quan"; this.btnTongQuan.Click += new System.EventHandler(this.btnTongQuan_Click);

            // flpBoLoc

            this.flpBoLoc.Dock = System.Windows.Forms.DockStyle.Fill; this.flpBoLoc.WrapContents = false; this.flpBoLoc.AutoScroll = true; this.flpBoLoc.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0); this.flpBoLoc.Name = "flpBoLoc";
            this.flpBoLoc.Controls.Add(this.lblTuNgay); this.flpBoLoc.Controls.Add(this.dtpTuNgay); this.flpBoLoc.Controls.Add(this.lblDenNgay); this.flpBoLoc.Controls.Add(this.dtpDenNgay); this.flpBoLoc.Controls.Add(this.lblCoSo); this.flpBoLoc.Controls.Add(this.cboCoSo); this.flpBoLoc.Controls.Add(this.btnXem); this.flpBoLoc.Controls.Add(this.btnDatLai); this.flpBoLoc.Controls.Add(this.lblLoaiBaoCao); this.flpBoLoc.Controls.Add(this.cboLoaiBaoCao); this.flpBoLoc.Controls.Add(this.btnXuatExcel);
            this.lblTuNgay.AutoSize = true; this.lblTuNgay.Margin = new System.Windows.Forms.Padding(0, 8, 4, 0); this.lblTuNgay.Text = "Từ ngày";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0); this.dtpTuNgay.Width = 120;
            this.lblDenNgay.AutoSize = true; this.lblDenNgay.Margin = new System.Windows.Forms.Padding(0, 8, 4, 0); this.lblDenNgay.Text = "Đến ngày";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short; this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0); this.dtpDenNgay.Width = 120;
            this.lblCoSo.AutoSize = true; this.lblCoSo.Margin = new System.Windows.Forms.Padding(0, 8, 4, 0); this.lblCoSo.Text = "Cơ sở";
            this.cboCoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboCoSo.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0); this.cboCoSo.Width = 150;
            this.btnXem.Name = "btnXem"; this.btnXem.Size = new System.Drawing.Size(120, 32); this.btnXem.Text = "Xem thống kê"; this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            this.btnDatLai.Name = "btnDatLai"; this.btnDatLai.Size = new System.Drawing.Size(82, 32); this.btnDatLai.Text = "Đặt lại"; this.btnDatLai.Click += new System.EventHandler(this.btnDatLai_Click);
            this.lblLoaiBaoCao.AutoSize = true; this.lblLoaiBaoCao.Margin = new System.Windows.Forms.Padding(8, 8, 4, 0); this.lblLoaiBaoCao.Text = "Loại báo cáo";
            this.cboLoaiBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboLoaiBaoCao.Width = 170; this.cboLoaiBaoCao.Items.AddRange(new object[] { "Hóa đơn trong kỳ", "Thanh toán phát sinh", "Đăng ký trong kỳ", "Thống kê tổng hợp" }); this.cboLoaiBaoCao.SelectedIndex = 3;
            this.btnXuatExcel.Name = "btnXuatExcel"; this.btnXuatExcel.Size = new System.Drawing.Size(112, 32); this.btnXuatExcel.Text = "Xuất Excel"; this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);

            // lblTongHop

            this.lblTongHop.Dock = System.Windows.Forms.DockStyle.Fill; this.lblTongHop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); this.lblTongHop.Name = "lblTongHop"; this.lblTongHop.Text = "Chọn khoảng ngày rồi xem thống kê."; this.lblTongHop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblGiaiThich

            this.lblGiaiThich.Dock = System.Windows.Forms.DockStyle.Fill; this.lblGiaiThich.Name = "lblGiaiThich"; this.lblGiaiThich.Text = "Hóa đơn theo ngày lập; thanh toán theo ngày phát sinh; đăng ký theo ngày đăng ký. Lớp hiện tại là chỉ số hiện tại."; this.lblGiaiThich.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // tabs

            this.tabs.Controls.Add(this.tabHoaDon); this.tabs.Controls.Add(this.tabThanhToan); this.tabs.Controls.Add(this.tabDangKy); this.tabs.Dock = System.Windows.Forms.DockStyle.Fill; this.tabs.Name = "tabs"; this.tabs.SelectedIndex = 0;

            // tabHoaDon

            this.tabHoaDon.Controls.Add(this.tlpHoaDon); this.tabHoaDon.Name = "tabHoaDon"; this.tabHoaDon.Padding = new System.Windows.Forms.Padding(8); this.tabHoaDon.Text = "Hóa đơn";
            this.tlpHoaDon.ColumnCount = 1; this.tlpHoaDon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); this.tlpHoaDon.RowCount = 3; this.tlpHoaDon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F)); this.tlpHoaDon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); this.tlpHoaDon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F)); this.tlpHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHoaDon.Controls.Add(this.lblHoaDonTong, 0, 0); this.tlpHoaDon.Controls.Add(this.dgvHoaDon, 0, 1); this.tlpHoaDon.Controls.Add(this.flpHoaDonTrang, 0, 2);
            this.lblHoaDonTong.Dock = System.Windows.Forms.DockStyle.Fill; this.lblHoaDonTong.Name = "lblHoaDonTong"; this.lblHoaDonTong.Text = "Tổng hóa đơn"; this.lblHoaDonTong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dgvHoaDon.AutoGenerateColumns = false; this.dgvHoaDon.AllowUserToAddRows = false; this.dgvHoaDon.AllowUserToDeleteRows = false; this.dgvHoaDon.ReadOnly = true; this.dgvHoaDon.MultiSelect = false; this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; this.dgvHoaDon.RowHeadersVisible = false; this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White; this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvHoaDon.Name = "dgvHoaDon";
            this.colHoaDonID.DataPropertyName = "HoaDonID"; this.colHoaDonID.HeaderText = "Mã hóa đơn"; this.colHoaDonID.Name = "colHoaDonID"; this.colHoaDonID.ReadOnly = true; this.colHoaDonID.FillWeight = 55F;
            this.colNgayLap.DataPropertyName = "NgayLap"; this.colNgayLap.HeaderText = "Ngày lập"; this.colNgayLap.Name = "colNgayLap"; this.colNgayLap.ReadOnly = true; this.colNgayLap.DefaultCellStyle.Format = "dd/MM/yyyy"; this.colNgayLap.FillWeight = 70F;
            this.colHoaDonHocVien.DataPropertyName = "HocVien"; this.colHoaDonHocVien.HeaderText = "Học viên"; this.colHoaDonHocVien.Name = "colHoaDonHocVien"; this.colHoaDonHocVien.ReadOnly = true; this.colHoaDonHocVien.FillWeight = 120F;
            this.colTenLop.DataPropertyName = "TenLop"; this.colTenLop.HeaderText = "Lớp"; this.colTenLop.Name = "colTenLop"; this.colTenLop.ReadOnly = true; this.colTenLop.FillWeight = 100F;
            this.colCoSo.DataPropertyName = "CoSo"; this.colCoSo.HeaderText = "Cơ sở"; this.colCoSo.Name = "colCoSo"; this.colCoSo.ReadOnly = true; this.colCoSo.FillWeight = 95F;
            this.colTongPhaiTra.DataPropertyName = "TongPhaiTra"; this.colTongPhaiTra.HeaderText = "Phải trả (đ)"; this.colTongPhaiTra.Name = "colTongPhaiTra"; this.colTongPhaiTra.ReadOnly = true; this.colTongPhaiTra.DefaultCellStyle.Format = "N0"; this.colTongPhaiTra.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; this.colTongPhaiTra.FillWeight = 80F;
            this.colDaThanhToan.DataPropertyName = "DaThanhToan"; this.colDaThanhToan.HeaderText = "Đã thanh toán đến cuối kỳ (đ)"; this.colDaThanhToan.Name = "colDaThanhToan"; this.colDaThanhToan.ReadOnly = true; this.colDaThanhToan.DefaultCellStyle.Format = "N0"; this.colDaThanhToan.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; this.colDaThanhToan.FillWeight = 100F;
            this.colConPhaiThu.DataPropertyName = "ConPhaiThu"; this.colConPhaiThu.HeaderText = "Còn phải thu (đ)"; this.colConPhaiThu.Name = "colConPhaiThu"; this.colConPhaiThu.ReadOnly = true; this.colConPhaiThu.DefaultCellStyle.Format = "N0"; this.colConPhaiThu.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; this.colConPhaiThu.FillWeight = 85F;
            this.colThuVuot.DataPropertyName = "ThuVuot"; this.colThuVuot.HeaderText = "Thu vượt"; this.colThuVuot.Name = "colThuVuot"; this.colThuVuot.ReadOnly = true; this.colThuVuot.FillWeight = 50F;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colHoaDonID, this.colNgayLap, this.colHoaDonHocVien, this.colTenLop, this.colCoSo, this.colTongPhaiTra, this.colDaThanhToan, this.colConPhaiThu, this.colThuVuot });
            this.flpHoaDonTrang.Dock = System.Windows.Forms.DockStyle.Fill; this.flpHoaDonTrang.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight; this.flpHoaDonTrang.WrapContents = false; this.flpHoaDonTrang.Controls.Add(this.btnHoaDonTruoc); this.flpHoaDonTrang.Controls.Add(this.lblHoaDonTrang); this.flpHoaDonTrang.Controls.Add(this.btnHoaDonSau);
            this.btnHoaDonTruoc.Name = "btnHoaDonTruoc"; this.btnHoaDonTruoc.Size = new System.Drawing.Size(90, 30); this.btnHoaDonTruoc.Text = "Trước";
            this.lblHoaDonTrang.Name = "lblHoaDonTrang"; this.lblHoaDonTrang.Size = new System.Drawing.Size(190, 30); this.lblHoaDonTrang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHoaDonSau.Name = "btnHoaDonSau"; this.btnHoaDonSau.Size = new System.Drawing.Size(90, 30); this.btnHoaDonSau.Text = "Sau";

            // tabThanhToan

            this.tabThanhToan.Controls.Add(this.tlpThanhToan); this.tabThanhToan.Name = "tabThanhToan"; this.tabThanhToan.Padding = new System.Windows.Forms.Padding(8); this.tabThanhToan.Text = "Thanh toán";
            this.tlpThanhToan.ColumnCount = 1; this.tlpThanhToan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); this.tlpThanhToan.RowCount = 3; this.tlpThanhToan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F)); this.tlpThanhToan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); this.tlpThanhToan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F)); this.tlpThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThanhToan.Controls.Add(this.lblThanhToanTong, 0, 0); this.tlpThanhToan.Controls.Add(this.dgvThanhToan, 0, 1); this.tlpThanhToan.Controls.Add(this.flpThanhToanTrang, 0, 2);
            this.lblThanhToanTong.Dock = System.Windows.Forms.DockStyle.Fill; this.lblThanhToanTong.Name = "lblThanhToanTong"; this.lblThanhToanTong.Text = "Tổng thanh toán"; this.lblThanhToanTong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dgvThanhToan.AutoGenerateColumns = false; this.dgvThanhToan.AllowUserToAddRows = false; this.dgvThanhToan.AllowUserToDeleteRows = false; this.dgvThanhToan.ReadOnly = true; this.dgvThanhToan.MultiSelect = false; this.dgvThanhToan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; this.dgvThanhToan.RowHeadersVisible = false; this.dgvThanhToan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvThanhToan.BackgroundColor = System.Drawing.Color.White; this.dgvThanhToan.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvThanhToan.Name = "dgvThanhToan";
            this.colThanhToanID.DataPropertyName = "ThanhToanID"; this.colThanhToanID.HeaderText = "Mã thanh toán"; this.colThanhToanID.Name = "colThanhToanID"; this.colThanhToanID.ReadOnly = true;
            this.colNgayThanhToan.DataPropertyName = "NgayThanhToan"; this.colNgayThanhToan.HeaderText = "Ngày thanh toán"; this.colNgayThanhToan.Name = "colNgayThanhToan"; this.colNgayThanhToan.ReadOnly = true; this.colNgayThanhToan.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            this.colThanhToanHoaDonID.DataPropertyName = "HoaDonID"; this.colThanhToanHoaDonID.HeaderText = "Mã hóa đơn"; this.colThanhToanHoaDonID.Name = "colThanhToanHoaDonID"; this.colThanhToanHoaDonID.ReadOnly = true;
            this.colThanhToanHocVien.DataPropertyName = "HocVien"; this.colThanhToanHocVien.HeaderText = "Học viên"; this.colThanhToanHocVien.Name = "colThanhToanHocVien"; this.colThanhToanHocVien.ReadOnly = true;
            this.colSoTien.DataPropertyName = "SoTien"; this.colSoTien.HeaderText = "Số tiền (đ)"; this.colSoTien.Name = "colSoTien"; this.colSoTien.ReadOnly = true; this.colSoTien.DefaultCellStyle.Format = "N0"; this.colSoTien.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvThanhToan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colThanhToanID, this.colNgayThanhToan, this.colThanhToanHoaDonID, this.colThanhToanHocVien, this.colSoTien });
            this.flpThanhToanTrang.Dock = System.Windows.Forms.DockStyle.Fill; this.flpThanhToanTrang.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight; this.flpThanhToanTrang.WrapContents = false; this.flpThanhToanTrang.Controls.Add(this.btnThanhToanTruoc); this.flpThanhToanTrang.Controls.Add(this.lblThanhToanTrang); this.flpThanhToanTrang.Controls.Add(this.btnThanhToanSau);
            this.btnThanhToanTruoc.Name = "btnThanhToanTruoc"; this.btnThanhToanTruoc.Size = new System.Drawing.Size(90, 30); this.btnThanhToanTruoc.Text = "Trước";
            this.lblThanhToanTrang.Name = "lblThanhToanTrang"; this.lblThanhToanTrang.Size = new System.Drawing.Size(190, 30); this.lblThanhToanTrang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnThanhToanSau.Name = "btnThanhToanSau"; this.btnThanhToanSau.Size = new System.Drawing.Size(90, 30); this.btnThanhToanSau.Text = "Sau";

            // tabDangKy

            this.tabDangKy.Controls.Add(this.tlpDangKy); this.tabDangKy.Name = "tabDangKy"; this.tabDangKy.Padding = new System.Windows.Forms.Padding(8); this.tabDangKy.Text = "Đăng ký";
            this.tlpDangKy.ColumnCount = 1; this.tlpDangKy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); this.tlpDangKy.RowCount = 3; this.tlpDangKy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F)); this.tlpDangKy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); this.tlpDangKy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F)); this.tlpDangKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDangKy.Controls.Add(this.lblDangKyTong, 0, 0); this.tlpDangKy.Controls.Add(this.dgvDangKy, 0, 1); this.tlpDangKy.Controls.Add(this.flpDangKyTrang, 0, 2);
            this.lblDangKyTong.Dock = System.Windows.Forms.DockStyle.Fill; this.lblDangKyTong.Name = "lblDangKyTong"; this.lblDangKyTong.Text = "Tổng đăng ký"; this.lblDangKyTong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dgvDangKy.AutoGenerateColumns = false; this.dgvDangKy.AllowUserToAddRows = false; this.dgvDangKy.AllowUserToDeleteRows = false; this.dgvDangKy.ReadOnly = true; this.dgvDangKy.MultiSelect = false; this.dgvDangKy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; this.dgvDangKy.RowHeadersVisible = false; this.dgvDangKy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvDangKy.BackgroundColor = System.Drawing.Color.White; this.dgvDangKy.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvDangKy.Name = "dgvDangKy";
            this.colDangKyID.DataPropertyName = "DangKyID"; this.colDangKyID.HeaderText = "Mã đăng ký"; this.colDangKyID.Name = "colDangKyID"; this.colDangKyID.ReadOnly = true;
            this.colNgayDangKy.DataPropertyName = "NgayDangKy"; this.colNgayDangKy.HeaderText = "Ngày đăng ký"; this.colNgayDangKy.Name = "colNgayDangKy"; this.colNgayDangKy.ReadOnly = true; this.colNgayDangKy.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.colDangKyHocVien.DataPropertyName = "HocVien"; this.colDangKyHocVien.HeaderText = "Học viên"; this.colDangKyHocVien.Name = "colDangKyHocVien"; this.colDangKyHocVien.ReadOnly = true;
            this.colLopHoc.DataPropertyName = "LopHoc"; this.colLopHoc.HeaderText = "Lớp"; this.colLopHoc.Name = "colLopHoc"; this.colLopHoc.ReadOnly = true;
            this.colTrangThaiDangKy.DataPropertyName = "TrangThai"; this.colTrangThaiDangKy.HeaderText = "Trạng thái"; this.colTrangThaiDangKy.Name = "colTrangThaiDangKy"; this.colTrangThaiDangKy.ReadOnly = true;
            this.dgvDangKy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colDangKyID, this.colNgayDangKy, this.colDangKyHocVien, this.colLopHoc, this.colTrangThaiDangKy });
            this.flpDangKyTrang.Dock = System.Windows.Forms.DockStyle.Fill; this.flpDangKyTrang.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight; this.flpDangKyTrang.WrapContents = false; this.flpDangKyTrang.Controls.Add(this.btnDangKyTruoc); this.flpDangKyTrang.Controls.Add(this.lblDangKyTrang); this.flpDangKyTrang.Controls.Add(this.btnDangKySau);
            this.btnDangKyTruoc.Name = "btnDangKyTruoc"; this.btnDangKyTruoc.Size = new System.Drawing.Size(90, 30); this.btnDangKyTruoc.Text = "Trước";
            this.lblDangKyTrang.Name = "lblDangKyTrang"; this.lblDangKyTrang.Size = new System.Drawing.Size(190, 30); this.lblDangKyTrang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDangKySau.Name = "btnDangKySau"; this.btnDangKySau.Size = new System.Drawing.Size(90, 30); this.btnDangKySau.Text = "Sau";

            // lblTrangThai

            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill; this.lblTrangThai.Name = "lblTrangThai"; this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // frmThongKe

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252); this.ClientSize = new System.Drawing.Size(1280, 820); this.Controls.Add(this.tlpChinh); this.MinimumSize = new System.Drawing.Size(980, 650); this.Name = "frmThongKe"; this.Text = "Thống kê";
            this.tlpChinh.ResumeLayout(false); this.pnlTieuDe.ResumeLayout(false); this.flpBoLoc.ResumeLayout(false); this.flpBoLoc.PerformLayout(); this.tabs.ResumeLayout(false);
            this.tabHoaDon.ResumeLayout(false); this.tlpHoaDon.ResumeLayout(false); ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit(); this.flpHoaDonTrang.ResumeLayout(false);
            this.tabThanhToan.ResumeLayout(false); this.tlpThanhToan.ResumeLayout(false); ((System.ComponentModel.ISupportInitialize)(this.dgvThanhToan)).EndInit(); this.flpThanhToanTrang.ResumeLayout(false);
            this.tabDangKy.ResumeLayout(false); this.tlpDangKy.ResumeLayout(false); ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).EndInit(); this.flpDangKyTrang.ResumeLayout(false); this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpChinh, tlpHoaDon, tlpThanhToan, tlpDangKy;
        private System.Windows.Forms.Panel pnlTieuDe;
        private System.Windows.Forms.FlowLayoutPanel flpBoLoc, flpHoaDonTrang, flpThanhToanTrang, flpDangKyTrang;
        private System.Windows.Forms.Label lblTieuDe, lblTuNgay, lblDenNgay, lblCoSo, lblLoaiBaoCao, lblTongHop, lblGiaiThich, lblTrangThai;
        private System.Windows.Forms.Label lblHoaDonTong, lblThanhToanTong, lblDangKyTong, lblHoaDonTrang, lblThanhToanTrang, lblDangKyTrang;
        private System.Windows.Forms.DateTimePicker dtpTuNgay, dtpDenNgay;
        private System.Windows.Forms.ComboBox cboCoSo, cboLoaiBaoCao;
        private System.Windows.Forms.Button btnXem, btnDatLai, btnXuatExcel, btnTongQuan, btnHoaDonTruoc, btnHoaDonSau, btnThanhToanTruoc, btnThanhToanSau, btnDangKyTruoc, btnDangKySau;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabHoaDon, tabThanhToan, tabDangKy;
        private System.Windows.Forms.DataGridView dgvHoaDon, dgvThanhToan, dgvDangKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoaDonID, colNgayLap, colHoaDonHocVien, colTenLop, colCoSo, colTongPhaiTra, colDaThanhToan, colConPhaiThu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colThuVuot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhToanID, colNgayThanhToan, colThanhToanHoaDonID, colThanhToanHocVien, colSoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDangKyID, colNgayDangKy, colDangKyHocVien, colLopHoc, colTrangThaiDangKy;
    }
}
