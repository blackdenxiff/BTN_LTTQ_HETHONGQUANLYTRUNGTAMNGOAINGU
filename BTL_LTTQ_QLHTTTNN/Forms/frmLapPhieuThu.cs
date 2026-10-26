using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using BTL_LTTQ_QLHTTTNN.Services;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN
{
    public partial class frmLapPhieuThu : Form
    {
        // THÔNG TIN TÀI KHOẢN NGÂN HÀNG TRUNG TÂM (BIDV)
        private const string BANK_BIN = "970418"; // Mã BIN ngân hàng BIDV
        private const string ACCOUNT_NO = "8893141886";
        private const string ACCOUNT_NAME = "NGUYEN VAN NGHIA";

        private decimal _hocPhiGoc = 0;
        private decimal _conPhaiDong = 0;
        private int? _maDangKyKhoiTao = null;
        private int? _hocVienKhoa = null;   // != null: chế độ học viên tự thanh toán, chỉ được thao tác cho HocVienID này

        public frmLapPhieuThu()
        {
            InitializeComponent();
        }

        public frmLapPhieuThu(int maDangKy) : this()
        {
            _maDangKyKhoiTao = maDangKy;
        }

        /// <summary>
        /// Chế độ học viên tự thanh toán: khóa cứng vào đúng học viên đang đăng nhập.
        /// </summary>
        public frmLapPhieuThu(int hocVienID, bool khoaTheoHocVien) : this()
        {
            if (khoaTheoHocVien) _hocVienKhoa = hocVienID;
        }

        private void frmLapPhieuThu_Load(object sender, EventArgs e)
        {
            // 1. Sửa lỗi "Lậ p Phiế u" bằng cách đổi sang Font Tahoma
            this.Text = "Lập Phiếu Thu Học Phí";
            if (lblTieuDe != null)
            {
                lblTieuDe.Text = "💳 Lập Phiếu Thu Học Phí";
                lblTieuDe.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            }

            // 2. Ép các Form cha sửa font chữ và dòng text
            CapNhatTieuDeFormCha();

            try
            {
                DatabaseConnection.Connect();
                cboPhuongThuc.Items.Clear();
                cboPhuongThuc.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản ngân hàng", "Thẻ ATM / VNPAY" });
                cboPhuongThuc.SelectedIndex = 0;
                NapDanhSachHocVien();

                if (_maDangKyKhoiTao.HasValue && _maDangKyKhoiTao.Value > 0)
                {
                    ChonDangKyKhoiTao(_maDangKyKhoiTao.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp dữ liệu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapNhatTieuDeFormCha()
        {
            try
            {
                Control parent = this.Parent;
                while (parent != null)
                {
                    if (parent is Form mainForm)
                    {
                        foreach (Control ctrl in mainForm.Controls)
                        {
                            TimVaSuaLabelTieuDe(ctrl);
                        }
                        break;
                    }
                    parent = parent.Parent;
                }
            }
            catch { }
        }

        private void TimVaSuaLabelTieuDe(Control ctrl)
        {
            if (ctrl is Label lbl && (lbl.Text.Contains("Lậ") || lbl.Text.Contains("Phiế") || lbl.Name.ToLower().Contains("tieude") || lbl.Name.ToLower().Contains("header")))
            {
                lbl.Text = "💳 Lập Phiếu Thu Học Phí";
                lbl.Font = new Font("Tahoma", 12F, FontStyle.Bold);
                return;
            }

            foreach (Control child in ctrl.Controls)
            {
                TimVaSuaLabelTieuDe(child);
            }
        }

        private void NapDanhSachHocVien()
        {
            bool khoa = _hocVienKhoa.HasValue;
            // _hocVienKhoa là int nên ghép chuỗi an toàn, không có nguy cơ SQL injection.
            string sqlHV = @"SELECT HocVienID,
                                    HoTen + ' (HV-' + CAST(HocVienID AS NVARCHAR) + ' • ' + ISNULL(SoDienThoai, '') + ')' AS TenHV
                             FROM HocVien
                             WHERE ISNULL(IsDeleted, 0) = 0"
                           + (khoa ? " AND HocVienID = " + _hocVienKhoa.Value : "")
                           + " ORDER BY HoTen ASC";

            DataTable dtHV = DatabaseConnection.GetDataToTable(sqlHV);

            if (khoa && dtHV.Rows.Count == 0)
                throw new InvalidOperationException("Không tìm thấy hồ sơ học viên đang đăng nhập.");

            if (!khoa)
            {
                DataRow drHV = dtHV.NewRow();
                drHV["HocVienID"] = 0;
                drHV["TenHV"] = "-- Chọn học viên --";
                dtHV.Rows.InsertAt(drHV, 0);
            }

            cboHocVien.SelectedIndexChanged -= cboHocVien_SelectedIndexChanged;
            cboHocVien.DataSource = dtHV;
            cboHocVien.DisplayMember = "TenHV";
            cboHocVien.ValueMember = "HocVienID";
            cboHocVien.SelectedIndex = 0;
            cboHocVien.SelectedIndexChanged += cboHocVien_SelectedIndexChanged;

            if (khoa)
            {
                cboHocVien.Enabled = false;                       // không cho đổi sang học viên khác
                cboHocVien_SelectedIndexChanged(cboHocVien, EventArgs.Empty); // nạp sẵn danh sách lớp của chính mình
            }
        }

        private void cboHocVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHocVien.SelectedValue == null) return;
            if (int.TryParse(cboHocVien.SelectedValue.ToString(), out int hvId) && hvId <= 0)
            {
                ResetPhieuThu();
                return;
            }
            var danhSachLop = HocPhiService.LayDangKyChuaThuCuaHocVien(hvId);
            if (danhSachLop.Count == 0)
            {
                ResetPhieuThu();
                return;
            }

            cboLopHoc.SelectedIndexChanged -= cboLopHoc_SelectedIndexChanged;
            cboLopHoc.DataSource = danhSachLop;
            cboLopHoc.DisplayMember = "HienThiCombobox";
            cboLopHoc.ValueMember = "DangKyID";
            cboLopHoc.SelectedIndexChanged += cboLopHoc_SelectedIndexChanged;
            cboLopHoc_SelectedIndexChanged(cboLopHoc, EventArgs.Empty);
        }

        private void ResetPhieuThu()
        {
            cboLopHoc.DataSource = null;
            txtTongTien.Clear();
            txtSoTienNop.Clear();
            _hocPhiGoc = 0;
            _conPhaiDong = 0;
            CapNhatHienThiQR();
        }

        private void cboLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLopHoc.SelectedItem is DangKyChuaThuDto item)
            {
                _hocPhiGoc = item.TongPhaiTra;
                _conPhaiDong = item.ConPhaiDong;
                txtTongTien.Text = $"{item.TongPhaiTra:N0} đ (Đã nộp: {item.DaThanhToan:N0} đ • Còn thiếu: {item.ConPhaiDong:N0} đ)";
                txtSoTienNop.Text = item.ConPhaiDong.ToString("0");
            }
            else
            {
                txtTongTien.Clear();
                txtSoTienNop.Clear();
            }
            CapNhatHienThiQR();
        }

        private void cboPhuongThuc_SelectedIndexChanged(object sender, EventArgs e) => CapNhatHienThiQR();
        private void txtSoTienNop_TextChanged(object sender, EventArgs e)
        {
            if (cboPhuongThuc.SelectedItem?.ToString() == "Chuyển khoản ngân hàng") CapNhatHienThiQR();
        }

        /// <summary>
        /// Thuật toán tạo chuỗi VietQR chuẩn EMVCo (Đánh dấu Mã Động 010212 để khóa cứng số tiền)
        /// </summary>
        private string TaoChuoiVietQR(decimal soTien, string noiDung)
        {
            string accInfo = $"0006{BANK_BIN}01{ACCOUNT_NO.Length:D2}{ACCOUNT_NO}";
            string merchantInfo = $"0010A00000072701{accInfo.Length:D2}{accInfo}0208QRIBFTTA";
            string amountStr = ((long)soTien).ToString();
            string tag62 = $"62{noiDung.Length + 4:D2}08{noiDung.Length:D2}{noiDung}";
            string nameSafe = ACCOUNT_NAME.Length > 25 ? ACCOUNT_NAME.Substring(0, 25) : ACCOUNT_NAME;

            // 010212 chính là lệnh ép App Ngân hàng KHÔNG CHO PHÉP sửa số tiền
            string payload = $"00020101021238{merchantInfo.Length:D2}{merchantInfo}530370454{amountStr.Length:D2}{amountStr}5802VN59{nameSafe.Length:D2}{nameSafe}6005HANOI{tag62}6304";

            // Tính mã kiểm tra CRC16-CCITT bắt buộc của Ngân hàng
            int crc = 0xFFFF;
            byte[] bytes = Encoding.ASCII.GetBytes(payload);
            foreach (byte b in bytes)
            {
                crc ^= b << 8;
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x8000) != 0) crc = (crc << 1) ^ 0x1021;
                    else crc <<= 1;
                }
            }
            return payload + (crc & 0xFFFF).ToString("X4");
        }

        private async void CapNhatHienThiQR()
        {
            if (cboPhuongThuc.SelectedItem?.ToString() == "Chuyển khoản ngân hàng")
            {
                pnlQRRight.Visible = true;
                int hvId = Convert.ToInt32(cboHocVien.SelectedValue ?? 0);
                var itemDangKy = cboLopHoc.SelectedItem as DangKyChuaThuDto;

                // 1. Chặn: Chưa chọn học viên / lớp
                if (hvId <= 0 || itemDangKy == null)
                {
                    picQR.Image = null;
                    lblBankInfo.ForeColor = Color.FromArgb(51, 65, 85);
                    lblBankInfo.Text = $"🏦 Ngân hàng: BIDV\n💳 Số tài khoản: {ACCOUNT_NO}\n👤 Chủ tài khoản: {ACCOUNT_NAME}\n\n(Vui lòng chọn Học viên và Lớp học để tạo mã QR)";
                    return;
                }

                // 2. Chặn: Đã nộp đủ tiền (Công nợ <= 0)
                if (_conPhaiDong <= 0)
                {
                    picQR.Image = null;
                    lblBankInfo.ForeColor = Color.Green;
                    lblBankInfo.Text = "✅ HỌC VIÊN ĐÃ NỘP ĐỦ HỌC PHÍ\nKhông cần thanh toán thêm cho lớp này.";
                    return;
                }

                // 3. Chặn: Nhập số tiền sai định dạng
                if (!decimal.TryParse(txtSoTienNop.Text.Trim(), out decimal soTien) || soTien <= 0)
                {
                    picQR.Image = null;
                    lblBankInfo.ForeColor = Color.FromArgb(51, 65, 85);
                    lblBankInfo.Text = $"🏦 Ngân hàng: BIDV\n💳 Số tài khoản: {ACCOUNT_NO}\n👤 Chủ tài khoản: {ACCOUNT_NAME}\n\n(Vui lòng nhập Số tiền hợp lệ để tạo mã QR)";
                    return;
                }

                // 4. Chặn: Số tiền nhập lớn hơn số tiền còn nợ
                if (soTien > _conPhaiDong)
                {
                    picQR.Image = null;
                    lblBankInfo.ForeColor = Color.Red;
                    lblBankInfo.Text = $"⚠️ LỖI VƯỢT QUÁ CÔNG NỢ\nSố tiền nhập: {soTien:N0} đ\nCòn thiếu thực tế: {_conPhaiDong:N0} đ\n\n(Mã QR bị khóa. Vui lòng nhập đúng số tiền!)";
                    return;
                }

                // Nếu mọi thứ hợp lệ, trả lại màu chữ đen và hiển thị QR
                lblBankInfo.ForeColor = Color.FromArgb(51, 65, 85);
                string noiDungCK = $"HP HV{hvId} DK{itemDangKy.DangKyID}";
                lblBankInfo.Text = $"🏦 Ngân hàng: BIDV (Ngân hàng TMCP Đầu tư & Phát triển)\n💳 Số tài khoản: {ACCOUNT_NO}\n👤 Chủ tài khoản: {ACCOUNT_NAME}\n💰 Số tiền: {soTien:N0} đ\n📝 Nội dung: {noiDungCK}";

                try
                {
                    string chuoiQRChuan = TaoChuoiVietQR(soTien, noiDungCK);
                    string urlImage = $"https://quickchart.io/qr?text={Uri.EscapeDataString(chuoiQRChuan)}&size=300&margin=1";

                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                    using (var httpClient = new HttpClient())
                    {
                        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                        byte[] bytes = await httpClient.GetByteArrayAsync(urlImage);
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            picQR.Image = Image.FromStream(ms);
                        }
                    }
                }
                catch
                {
                    picQR.Image = null;
                }
            }
            else
            {
                pnlQRRight.Visible = false;
            }
        }

        private void btnKiemTraChuyenKhoan_Click(object sender, EventArgs e)
        {
            if (_conPhaiDong <= 0)
            {
                // Đã sửa lại câu thông báo theo yêu cầu
                MessageBox.Show("Học viên đã thanh toán đủ học phí cho lớp học này. Không thể lập thêm phiếu thu!", "Cảnh báo dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (decimal.TryParse(txtSoTienNop.Text.Trim(), out decimal soTien) && soTien > 0)
            {
                if (soTien > _conPhaiDong)
                {
                    MessageBox.Show($"Số tiền nộp ({soTien:N0} đ) vượt quá số tiền còn thiếu ({_conPhaiDong:N0} đ)!", "Cảnh báo dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTienNop.Focus();
                    return;
                }

                var dr = MessageBox.Show($"Xác nhận hệ thống đã nhận đủ {soTien:N0} đ chuyển khoản qua tài khoản BIDV?", "Xác nhận đối soát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    txtGhiChu.Text = $"Thanh toán thành công qua chuyển khoản BIDV ({ACCOUNT_NO})";
                    btnLuu_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số tiền thanh toán hợp lệ trước khi xác nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ChonDangKyKhoiTao(int maDangKy)
        {
            var hp = HocPhiService.LayHocPhiTheoDangKy(maDangKy);
            if (hp != null)
            {
                cboHocVien.SelectedValue = hp.HocVienID;
                if (cboLopHoc.DataSource is List<DangKyChuaThuDto> list)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].DangKyID == maDangKy)
                        {
                            cboLopHoc.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboHocVien.SelectedValue == null || Convert.ToInt32(cboHocVien.SelectedValue) <= 0)
                {
                    MessageBox.Show("Vui lòng chọn học viên nộp tiền.", "Kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboHocVien.Focus();
                    return;
                }

                var itemDangKy = cboLopHoc.SelectedItem as DangKyChuaThuDto;
                if (itemDangKy == null)
                {
                    MessageBox.Show("Vui lòng chọn lớp học cần thanh toán.", "Kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboLopHoc.Focus();
                    return;
                }

                if (_conPhaiDong <= 0)
                {
                    MessageBox.Show("Học viên đã thanh toán đủ học phí cho lớp học này. Không thể lập thêm phiếu thu!", "Cảnh báo dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Học viên chỉ được nộp cho chính mình
                if (_hocVienKhoa.HasValue && itemDangKy.HocVienID != _hocVienKhoa.Value)
                {
                    MessageBox.Show("Bạn chỉ được thanh toán học phí cho chính mình.", "Không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtSoTienNop.Text.Trim(), out decimal soTienNop) || soTienNop <= 0)
                {
                    MessageBox.Show("Số tiền thanh toán không hợp lệ! Vui lòng nhập số tiền lớn hơn 0 đ.", "Kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTienNop.Focus();
                    return;
                }

                if (soTienNop > _conPhaiDong)
                {
                    MessageBox.Show($"Số tiền nộp ({soTienNop:N0} đ) vượt quá số tiền còn thiếu ({_conPhaiDong:N0} đ)!", "Cảnh báo dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTienNop.Focus();
                    return;
                }

                var dto = new TaoPhieuThuDto
                {
                    DangKyID = itemDangKy.DangKyID,
                    HocVienID = itemDangKy.HocVienID,
                    LopHocID = itemDangKy.LopHocID,
                    SoTien = soTienNop,
                    PhuongThuc = cboPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt",
                    NhanSuID = SessionContext.NguoiDungHienTai?.NhanSuID ?? 1,
                    GhiChu = txtGhiChu.Text.Trim()
                };

                // Chế độ học viên: service kiểm tra lại quyền sở hữu đăng ký học ở tầng nghiệp vụ
                var ketQua = _hocVienKhoa.HasValue
                    ? PhieuThuService.LapPhieuThuChoHocVien(dto, _hocVienKhoa.Value)
                    : PhieuThuService.LapPhieuThu(dto);
                if (ketQua.ThanhCong)
                {
                    MessageBox.Show(ketQua.ThongBao, "Thông báo thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(ketQua.ThongBao, "Không lập được phiếu thu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu thu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) => this.Close();


    }
}
