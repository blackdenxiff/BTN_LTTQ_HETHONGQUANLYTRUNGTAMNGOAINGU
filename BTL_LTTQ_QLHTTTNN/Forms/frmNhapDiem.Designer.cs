namespace BTL_LTTQ_QLHTTTNN
{
    partial class frmNhapDiem
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
            this.components = new System.ComponentModel.Container();
            this.pnlDanhSach = new System.Windows.Forms.Panel();
            this.pnlChan = new System.Windows.Forms.Panel();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.pnlBoLoc = new System.Windows.Forms.Panel();
            this.pnlTieuDe = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblLoaiDiem = new System.Windows.Forms.Label();
            this.cboLoaiDiem = new System.Windows.Forms.ComboBox();
            this.btnTaiDanhSach = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dgvBangDiem = new System.Windows.Forms.DataGridView();
            this.colMaHocVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).BeginInit();
            this.pnlDanhSach.SuspendLayout();
            this.pnlChan.SuspendLayout();
            this.pnlBoLoc.SuspendLayout();
            this.pnlTieuDe.SuspendLayout();
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.Name = "frmNhapDiem";
            this.ClientSize = new System.Drawing.Size(1040, 720);
            this.Text = "Kết quả học tập";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MinimumSize = new System.Drawing.Size(980, 650);
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1040, 650);
            this.pnlDanhSach.Name = "pnlDanhSach";
            this.pnlDanhSach.Location = new System.Drawing.Point(0, 0);
            this.pnlDanhSach.Size = new System.Drawing.Size(100, 30);
            this.pnlDanhSach.TabIndex = 1;
            this.pnlDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDanhSach.Padding = new System.Windows.Forms.Padding(24, 8, 24, 8);
            this.pnlChan.Name = "pnlChan";
            this.pnlChan.Location = new System.Drawing.Point(0, 0);
            this.pnlChan.Size = new System.Drawing.Size(100, 54);
            this.pnlChan.TabIndex = 2;
            this.pnlChan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChan.BackColor = System.Drawing.Color.White;
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Location = new System.Drawing.Point(24, 12);
            this.lblTrangThai.Size = new System.Drawing.Size(590, 28);
            this.lblTrangThai.TabIndex = 3;
            this.lblTrangThai.Text = "Chưa có dữ liệu.";
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pnlBoLoc.Name = "pnlBoLoc";
            this.pnlBoLoc.Location = new System.Drawing.Point(0, 0);
            this.pnlBoLoc.Size = new System.Drawing.Size(100, 88);
            this.pnlBoLoc.TabIndex = 4;
            this.pnlBoLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTieuDe.Name = "pnlTieuDe";
            this.pnlTieuDe.Location = new System.Drawing.Point(0, 0);
            this.pnlTieuDe.Size = new System.Drawing.Size(100, 82);
            this.pnlTieuDe.TabIndex = 5;
            this.pnlTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Location = new System.Drawing.Point(24, 14);
            this.lblTieuDe.Size = new System.Drawing.Size(800, 32);
            this.lblTieuDe.TabIndex = 6;
            this.lblTieuDe.Text = "Kết quả học tập";
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Location = new System.Drawing.Point(24, 49);
            this.lblMoTa.Size = new System.Drawing.Size(900, 24);
            this.lblMoTa.TabIndex = 7;
            this.lblMoTa.Text = "Chọn lớp được phân công để nhập điểm.";
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblMoTa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pnlDanhSach.Size = new System.Drawing.Size(1040, 496);
            this.pnlChan.Size = new System.Drawing.Size(1040, 54);
            this.pnlBoLoc.Size = new System.Drawing.Size(1040, 88);
            this.pnlTieuDe.Size = new System.Drawing.Size(1040, 82);
            this.lblLop.Name = "lblLop";
            this.lblLop.Location = new System.Drawing.Point(24, 2);
            this.lblLop.Size = new System.Drawing.Size(310, 22);
            this.lblLop.TabIndex = 8;
            this.lblLop.Text = "Lớp học";
            this.lblLop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblLop.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblLop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cboLop.Name = "cboLop";
            this.cboLop.Location = new System.Drawing.Point(24, 29);
            this.cboLop.Size = new System.Drawing.Size(310, 28);
            this.cboLop.TabIndex = 9;
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lblLoaiDiem.Name = "lblLoaiDiem";
            this.lblLoaiDiem.Location = new System.Drawing.Point(354, 2);
            this.lblLoaiDiem.Size = new System.Drawing.Size(310, 22);
            this.lblLoaiDiem.TabIndex = 10;
            this.lblLoaiDiem.Text = "Loại điểm";
            this.lblLoaiDiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblLoaiDiem.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblLoaiDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cboLoaiDiem.Name = "cboLoaiDiem";
            this.cboLoaiDiem.Location = new System.Drawing.Point(354, 29);
            this.cboLoaiDiem.Size = new System.Drawing.Size(310, 28);
            this.cboLoaiDiem.TabIndex = 11;
            this.cboLoaiDiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.btnTaiDanhSach.Name = "btnTaiDanhSach";
            this.btnTaiDanhSach.Location = new System.Drawing.Point(684, 25);
            this.btnTaiDanhSach.Size = new System.Drawing.Size(150, 36);
            this.btnTaiDanhSach.TabIndex = 12;
            this.btnTaiDanhSach.Text = "Tải danh sách";
            this.btnTaiDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiDanhSach.FlatAppearance.BorderSize = 0;
            this.btnTaiDanhSach.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnTaiDanhSach.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnTaiDanhSach.ForeColor = System.Drawing.Color.White;
            this.btnTaiDanhSach.UseVisualStyleBackColor = false;
            this.btnTaiDanhSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Location = new System.Drawing.Point(850, 25);
            this.btnLamMoi.Size = new System.Drawing.Size(130, 36);
            this.btnLamMoi.TabIndex = 13;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.FlatAppearance.BorderSize = 1;
            this.btnLamMoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnLamMoi.BackColor = System.Drawing.Color.White;
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Location = new System.Drawing.Point(810, 9);
            this.btnLuu.Size = new System.Drawing.Size(170, 36);
            this.btnLuu.TabIndex = 14;
            this.btnLuu.Text = "Lưu điểm";
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.dgvBangDiem.Name = "dgvBangDiem";
            this.dgvBangDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBangDiem.BackgroundColor = System.Drawing.Color.White;
            this.dgvBangDiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBangDiem.AutoGenerateColumns = false;
            this.dgvBangDiem.ReadOnly = false;
            this.dgvBangDiem.AllowUserToAddRows = false;
            this.dgvBangDiem.AllowUserToDeleteRows = false;
            this.dgvBangDiem.RowHeadersVisible = false;
            this.dgvBangDiem.MultiSelect = false;
            this.dgvBangDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBangDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBangDiem.ColumnHeadersHeight = 42;
            this.dgvBangDiem.EnableHeadersVisualStyles = false;
            this.dgvBangDiem.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            this.dgvBangDiem.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.dgvBangDiem.RowTemplate.Height = 34;
            this.colMaHocVien.Name = "colMaHocVien";
            this.colMaHocVien.HeaderText = "Mã HV";
            this.colMaHocVien.DataPropertyName = "MaHocVien";
            this.colMaHocVien.ReadOnly = true;
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.HeaderText = "Họ và tên";
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.ReadOnly = true;
            this.colDiem.Name = "colDiem";
            this.colDiem.HeaderText = "Điểm (0–10)";
            this.colDiem.DataPropertyName = "Diem";
            this.colDiem.ReadOnly = false;
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.DataPropertyName = "GhiChu";
            this.colGhiChu.ReadOnly = false;
            this.dgvBangDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colMaHocVien, this.colHoTen, this.colDiem, this.colGhiChu });
            this.Controls.Add(this.pnlDanhSach);
            this.Controls.Add(this.pnlChan);
            this.Controls.Add(this.pnlBoLoc);
            this.Controls.Add(this.pnlTieuDe);
            this.pnlChan.Controls.Add(this.lblTrangThai);
            this.pnlChan.Controls.Add(this.btnLuu);
            this.pnlTieuDe.Controls.Add(this.lblTieuDe);
            this.pnlTieuDe.Controls.Add(this.lblMoTa);
            this.pnlBoLoc.Controls.Add(this.lblLop);
            this.pnlBoLoc.Controls.Add(this.cboLop);
            this.pnlBoLoc.Controls.Add(this.lblLoaiDiem);
            this.pnlBoLoc.Controls.Add(this.cboLoaiDiem);
            this.pnlBoLoc.Controls.Add(this.btnTaiDanhSach);
            this.pnlBoLoc.Controls.Add(this.btnLamMoi);
            this.pnlDanhSach.Controls.Add(this.dgvBangDiem);
            this.btnTaiDanhSach.Click += new System.EventHandler(this.btnTaiDanhSach_Click);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.cboLop.SelectedIndexChanged += new System.EventHandler(this.cboLop_SelectedIndexChanged);
            this.dgvBangDiem.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvBangDiem_CellValidating);
            this.dgvBangDiem.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBangDiem_CellEndEdit);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).EndInit();
            this.pnlDanhSach.ResumeLayout(false);
            this.pnlDanhSach.PerformLayout();
            this.pnlChan.ResumeLayout(false);
            this.pnlChan.PerformLayout();
            this.pnlBoLoc.ResumeLayout(false);
            this.pnlBoLoc.PerformLayout();
            this.pnlTieuDe.ResumeLayout(false);
            this.pnlTieuDe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlDanhSach;
        private System.Windows.Forms.Panel pnlChan;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Panel pnlBoLoc;
        private System.Windows.Forms.Panel pnlTieuDe;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblLoaiDiem;
        private System.Windows.Forms.ComboBox cboLoaiDiem;
        private System.Windows.Forms.Button btnTaiDanhSach;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridView dgvBangDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHocVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
    }
}
