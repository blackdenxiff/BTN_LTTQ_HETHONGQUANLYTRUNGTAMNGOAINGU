using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN.Data
{
    /// <summary>
    /// Tầng truy xuất dữ liệu CSDL cho phân hệ Học phí và Phiếu thu (Thành viên 5).
    /// </summary>
    internal static class HocPhiData
    {
        // ==========================================
        // 1. CÁC TRUY VẤN VỀ HỌC PHÍ & HÓA ĐƠN
        // ==========================================

        /// <summary>
        /// Lấy danh sách học phí kèm số tiền thực thu và trạng thái thanh toán.
        /// </summary>
        public static List<HocPhiDto> LayDanhSachHocPhi(string tuKhoa, string trangThai)
        {
            var ketQua = new List<HocPhiDto>();

            string sql = @"
                SELECT
                    hd.HoaDonID,
                    'HD-' + CAST(hd.HoaDonID AS NVARCHAR) AS MaHoaDon,
                    ISNULL(hd.DangKyID, 0) AS DangKyID,
                    hd.HocVienID,
                    'HV-' + CAST(hv.HocVienID AS NVARCHAR) AS MaHocVien,
                    hv.HoTen AS TenHocVien,
                    ISNULL(hv.SoDienThoai, '') AS SoDienThoai,
                    ISNULL(l.LopHocID, 0) AS LopHocID,
                    ISNULL(l.TenLop, N'Chưa xếp lớp') AS TenLop,
                    ISNULL(k.TenKhoaHoc, N'Khóa học ngoại ngữ') AS TenKhoaHoc,
                    hd.NgayLap,
                    ISNULL(hd.TongTien, 0) AS TongTien,
                    ISNULL(hd.GiamGia, 0) AS GiamGia,
                    ISNULL(hd.TongPhaiTra, ISNULL(hd.TongTien, 0) - ISNULL(hd.GiamGia, 0)) AS TongPhaiTra,
                    ISNULL(tt.DaThanhToan, 0) AS DaThanhToan,
                    hd.GhiChu
                FROM HoaDon hd
                JOIN HocVien hv ON hd.HocVienID = hv.HocVienID
                LEFT JOIN DangKy d ON hd.DangKyID = d.DangKyID AND d.IsDeleted = 0
                LEFT JOIN LopHoc l ON d.LopHocID = l.LopHocID
                LEFT JOIN KhoaHoc k ON l.KhoaHocID = k.KhoaHocID
                OUTER APPLY (
                    SELECT ISNULL(SUM(t.SoTien), 0) AS DaThanhToan
                    FROM ThanhToan t
                    WHERE t.HoaDonID = hd.HoaDonID AND t.IsDeleted = 0
                ) tt
                WHERE ISNULL(hd.IsDeleted, 0) = 0";

            var danhSachThamSo = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                sql += @" AND (
                    CAST(hd.HoaDonID AS NVARCHAR) LIKE @kw
                    OR hv.HoTen LIKE @kw
                    OR hv.SoDienThoai LIKE @kw
                    OR l.TenLop LIKE @kw
                )";
                danhSachThamSo.Add(new SqlParameter("@kw", "%" + tuKhoa.Trim() + "%"));
            }

            sql += " ORDER BY hd.NgayLap DESC, hd.HoaDonID DESC";

            using (var conn = DatabaseConnection.TaoKetNoi())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (danhSachThamSo.Count > 0)
                {
                    cmd.Parameters.AddRange(danhSachThamSo.ToArray());
                }

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dto = DocHocPhiDto(reader);

                        // Lọc theo bộ lọc trạng thái nếu có
                        if (!string.IsNullOrEmpty(trangThai) && trangThai != "-- Tất cả trạng thái --")
                        {
                            if (!string.Equals(dto.TrangThai, trangThai, StringComparison.OrdinalIgnoreCase))
                            {
                                continue;
                            }
                        }

                        ketQua.Add(dto);
                    }
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Tính các chỉ số thống kê KPI trên đầu trang frmHocPhi.
        /// </summary>
        public static ThongKeKPIDto LayThongKeKPI()
        {
            var kpi = new ThongKeKPIDto();

            string sql = @"
                SELECT
                    hd.TongPhaiTra,
                    ISNULL(tt.DaThanhToan, 0) AS DaThanhToan
                FROM HoaDon hd
                OUTER APPLY (
                    SELECT ISNULL(SUM(t.SoTien), 0) AS DaThanhToan
                    FROM ThanhToan t
                    WHERE t.HoaDonID = hd.HoaDonID AND t.IsDeleted = 0
                ) tt
                WHERE ISNULL(hd.IsDeleted, 0) = 0";

            using (var conn = DatabaseConnection.TaoKetNoi())
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        decimal phaiTra = reader["TongPhaiTra"] != DBNull.Value ? Convert.ToDecimal(reader["TongPhaiTra"]) : 0;
                        decimal daThu = reader["DaThanhToan"] != DBNull.Value ? Convert.ToDecimal(reader["DaThanhToan"]) : 0;
                        decimal conLai = phaiTra > daThu ? phaiTra - daThu : 0;

                        kpi.TongPhaiNop += phaiTra;
                        kpi.TongDaThanhToan += daThu;
                        kpi.TongConPhaiDong += conLai;

                        if (conLai > 0)
                        {
                            kpi.SoChuaThanhToan++;
                        }
                    }
                }
            }

            return kpi;
        }

        /// <summary>
        /// Lấy thông tin học phí của một lần đăng ký học.
        /// </summary>
        public static HocPhiDto LayHocPhiTheoDangKy(int maDangKy)
        {
            string sql = @"
                SELECT
                    hd.HoaDonID,
                    CASE WHEN hd.HoaDonID IS NOT NULL THEN 'HD-' + CAST(hd.HoaDonID AS NVARCHAR) ELSE N'Chưa lập HĐ' END AS MaHoaDon,
                    d.DangKyID,
                    d.HocVienID,
                    'HV-' + CAST(hv.HocVienID AS NVARCHAR) AS MaHocVien,
                    hv.HoTen AS TenHocVien,
                    ISNULL(hv.SoDienThoai, '') AS SoDienThoai,
                    l.LopHocID,
                    l.TenLop,
                    k.TenKhoaHoc,
                    hd.NgayLap,
                    ISNULL(hd.TongTien, d.HocPhiApDung) AS TongTien,
                    ISNULL(hd.GiamGia, 0) AS GiamGia,
                    ISNULL(hd.TongPhaiTra, d.HocPhiApDung) AS TongPhaiTra,
                    ISNULL(tt.DaThanhToan, 0) AS DaThanhToan,
                    hd.GhiChu
                FROM DangKy d
                JOIN HocVien hv ON d.HocVienID = hv.HocVienID
                JOIN LopHoc l ON d.LopHocID = l.LopHocID
                JOIN KhoaHoc k ON l.KhoaHocID = k.KhoaHocID
                LEFT JOIN HoaDon hd ON hd.DangKyID = d.DangKyID AND hd.IsDeleted = 0
                OUTER APPLY (
                    SELECT ISNULL(SUM(t.SoTien), 0) AS DaThanhToan
                    FROM ThanhToan t
                    WHERE t.HoaDonID = hd.HoaDonID AND t.IsDeleted = 0
                ) tt
                WHERE d.DangKyID = @dangKyId AND d.IsDeleted = 0";

            using (var conn = DatabaseConnection.TaoKetNoi())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@dangKyId", maDangKy));
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return DocHocPhiDto(reader);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Lấy danh sách học phí của các học viên trong một lớp.
        /// </summary>
        public static List<HocPhiDto> LayHocPhiTheoLop(int maLop)
        {
            var ketQua = new List<HocPhiDto>();

            string sql = @"
                SELECT
                    hd.HoaDonID,
                    CASE WHEN hd.HoaDonID IS NOT NULL THEN 'HD-' + CAST(hd.HoaDonID AS NVARCHAR) ELSE N'Chưa lập HĐ' END AS MaHoaDon,
                    d.DangKyID,
                    d.HocVienID,
                    'HV-' + CAST(hv.HocVienID AS NVARCHAR) AS MaHocVien,
                    hv.HoTen AS TenHocVien,
                    ISNULL(hv.SoDienThoai, '') AS SoDienThoai,
                    l.LopHocID,
                    l.TenLop,
                    k.TenKhoaHoc,
                    hd.NgayLap,
                    ISNULL(hd.TongTien, d.HocPhiApDung) AS TongTien,
                    ISNULL(hd.GiamGia, 0) AS GiamGia,
                    ISNULL(hd.TongPhaiTra, d.HocPhiApDung) AS TongPhaiTra,
                    ISNULL(tt.DaThanhToan, 0) AS DaThanhToan,
                    hd.GhiChu
                FROM DangKy d
                JOIN HocVien hv ON d.HocVienID = hv.HocVienID
                JOIN LopHoc l ON d.LopHocID = l.LopHocID
                JOIN KhoaHoc k ON l.KhoaHocID = k.KhoaHocID
                LEFT JOIN HoaDon hd ON hd.DangKyID = d.DangKyID AND hd.IsDeleted = 0
                OUTER APPLY (
                    SELECT ISNULL(SUM(t.SoTien), 0) AS DaThanhToan
                    FROM ThanhToan t
                    WHERE t.HoaDonID = hd.HoaDonID AND t.IsDeleted = 0
                ) tt
                WHERE d.LopHocID = @lopId AND d.IsDeleted = 0
                ORDER BY hv.HoTen ASC";

            using (var conn = DatabaseConnection.TaoKetNoi())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@lopId", maLop));
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ketQua.Add(DocHocPhiDto(reader));
                    }
                }
            }

            return ketQua;
        }

        // ==========================================
        // 2. CÁC HÀM PHỤC VỤ LẬP PHIẾU THU
        // ==========================================

        /// <summary>
        /// Lấy danh sách các lớp học mà học viên đã đăng ký và còn nợ tiền.
        /// </summary>
        public static List<DangKyChuaThuDto> LayDangKyChuaThuCuaHocVien(int hocVienId)
        {
            var ketQua = new List<DangKyChuaThuDto>();

            string sql = @"
                SELECT
                    d.DangKyID,
                    d.HocVienID,
                    hv.HoTen AS TenHocVien,
                    d.LopHocID,
                    l.TenLop,
                    k.TenKhoaHoc,
                    d.HocPhiApDung,
                    hd.HoaDonID,
                    ISNULL(hd.TongPhaiTra, d.HocPhiApDung) AS TongPhaiTra,
                    ISNULL(tt.DaThanhToan, 0) AS DaThanhToan
                FROM DangKy d
                JOIN HocVien hv ON d.HocVienID = hv.HocVienID
                JOIN LopHoc l ON d.LopHocID = l.LopHocID
                JOIN KhoaHoc k ON l.KhoaHocID = k.KhoaHocID
                LEFT JOIN HoaDon hd ON hd.DangKyID = d.DangKyID AND hd.IsDeleted = 0
                OUTER APPLY (
                    SELECT ISNULL(SUM(t.SoTien), 0) AS DaThanhToan
                    FROM ThanhToan t
                    WHERE t.HoaDonID = hd.HoaDonID AND t.IsDeleted = 0
                ) tt
                WHERE d.HocVienID = @hocVienId AND d.IsDeleted = 0";

            using (var conn = DatabaseConnection.TaoKetNoi())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@hocVienId", hocVienId));
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        decimal tongPhaiTra = Convert.ToDecimal(reader["TongPhaiTra"]);
                        decimal daThanhToan = Convert.ToDecimal(reader["DaThanhToan"]);
                        decimal conPhaiDong = tongPhaiTra > daThanhToan ? tongPhaiTra - daThanhToan : 0;

                        ketQua.Add(new DangKyChuaThuDto
                        {
                            DangKyID = Convert.ToInt32(reader["DangKyID"]),
                            HocVienID = Convert.ToInt32(reader["HocVienID"]),
                            TenHocVien = reader["TenHocVien"].ToString(),
                            LopHocID = Convert.ToInt32(reader["LopHocID"]),
                            TenLop = reader["TenLop"].ToString(),
                            TenKhoaHoc = reader["TenKhoaHoc"].ToString(),
                            HocPhiApDung = Convert.ToDecimal(reader["HocPhiApDung"]),
                            TongPhaiTra = tongPhaiTra,
                            DaThanhToan = daThanhToan,
                            ConPhaiDong = conPhaiDong,
                            HoaDonID = reader["HoaDonID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["HoaDonID"]) : null
                        });
                    }
                }
            }

            return ketQua;
        }

        /// <summary>
        /// Lập phiếu thu và ghi nhận thanh toán trong SqlTransaction đảm bảo toàn vẹn dữ liệu.
        /// </summary>
        public static int LuuPhieuThu(TaoPhieuThuDto dto)
        {
            using (var conn = DatabaseConnection.TaoKetNoi())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        using (var cmdRequest = new SqlCommand(@"SELECT tt.ThanhToanID, tt.SoTien, tt.PhuongThuc, tt.IsDeleted, hd.DangKyID, hd.HocVienID
                            FROM ThanhToan tt WITH (UPDLOCK, HOLDLOCK)
                            INNER JOIN HoaDon hd ON hd.HoaDonID = tt.HoaDonID
                            WHERE tt.RequestId = @requestId", conn, tx))
                        {
                            cmdRequest.Parameters.Add(new SqlParameter("@requestId", dto.RequestId));
                            using (var request = cmdRequest.ExecuteReader())
                            {
                                if (request.Read())
                                {
                                    bool sameRequest = !Convert.ToBoolean(request["IsDeleted"])
                                        && Convert.ToInt32(request["DangKyID"]) == dto.DangKyID
                                        && Convert.ToInt32(request["HocVienID"]) == dto.HocVienID
                                        && Convert.ToDecimal(request["SoTien"]) == dto.SoTien
                                        && string.Equals(Convert.ToString(request["PhuongThuc"]), dto.PhuongThuc, StringComparison.Ordinal);
                                    if (!sameRequest)
                                        throw new InvalidOperationException("Mã yêu cầu phiếu thu đã được dùng cho dữ liệu khác.");
                                    int existingId = Convert.ToInt32(request["ThanhToanID"]);
                                    request.Close();
                                    tx.Commit();
                                    return existingId;
                                }
                            }
                        }

                        int hocVienDangKy;
                        using (var cmdDangKy = new SqlCommand(@"SELECT HocVienID FROM DangKy WITH (UPDLOCK, HOLDLOCK) WHERE DangKyID = @dk AND IsDeleted = 0 AND TrangThai <> N'Hủy'", conn, tx))
                        {
                            cmdDangKy.Parameters.Add(new SqlParameter("@dk", dto.DangKyID));
                            object idDangKy = cmdDangKy.ExecuteScalar();
                            if (idDangKy == null || idDangKy == DBNull.Value) throw new InvalidOperationException("Đăng ký học không tồn tại hoặc đã bị hủy.");
                            hocVienDangKy = Convert.ToInt32(idDangKy);
                        }
                        if (hocVienDangKy != dto.HocVienID) throw new InvalidOperationException("Học viên không khớp với đăng ký được chọn.");
                        int hoaDonId = 0;
                        decimal tongPhaiTra = 0;

                        // 1. Kiểm tra xem DangKy này đã có HoaDon chưa
                        string sqlTimHoaDon = @"
                            SELECT HoaDonID, TongPhaiTra
                            FROM HoaDon WITH (UPDLOCK, HOLDLOCK)
                            WHERE DangKyID = @dangKyId AND IsDeleted = 0";

                        using (var cmdTim = new SqlCommand(sqlTimHoaDon, conn, tx))
                        {
                            cmdTim.Parameters.Add(new SqlParameter("@dangKyId", dto.DangKyID));
                            using (var r = cmdTim.ExecuteReader())
                            {
                                if (r.Read())
                                {
                                    hoaDonId = Convert.ToInt32(r["HoaDonID"]);
                                    tongPhaiTra = Convert.ToDecimal(r["TongPhaiTra"]);
                                }
                            }
                        }

                        // Nếu chưa có Hóa đơn, tự động tạo mới Hóa đơn gắn liền với Đăng ký
                        if (hoaDonId == 0)
                        {
                            // Lấy mức học phí áp dụng từ bản ghi DangKy
                            decimal hocPhiApDung = 0;
                            string sqlHocPhi = "SELECT HocPhiApDung FROM DangKy WHERE DangKyID = @dangKyId";
                            using (var cmdHocPhi = new SqlCommand(sqlHocPhi, conn, tx))
                            {
                                cmdHocPhi.Parameters.Add(new SqlParameter("@dangKyId", dto.DangKyID));
                                object val = cmdHocPhi.ExecuteScalar();
                                hocPhiApDung = (val != null && val != DBNull.Value) ? Convert.ToDecimal(val) : dto.SoTien;
                            }

                            tongPhaiTra = hocPhiApDung;

                            string sqlTaoHoaDon = @"
                                INSERT INTO HoaDon (HocVienID, DangKyID, NhanSuLapID, NgayLap, TongTien, GiamGia, TongPhaiTra, TrangThai, GhiChu, IsDeleted, CreatedAt)
                                VALUES (@hv, @dk, @ns, CONVERT(date, GETDATE()), @tongTien, 0, @tongPhaiTra, N'Chưa đủ', @ghiChu, 0, GETDATE());
                                SELECT SCOPE_IDENTITY();";

                            using (var cmdTaoHD = new SqlCommand(sqlTaoHoaDon, conn, tx))
                            {
                                cmdTaoHD.Parameters.Add(new SqlParameter("@hv", dto.HocVienID));
                                cmdTaoHD.Parameters.Add(new SqlParameter("@dk", dto.DangKyID));
                                cmdTaoHD.Parameters.Add(new SqlParameter("@ns", dto.NhanSuID));
                                cmdTaoHD.Parameters.Add(new SqlParameter("@tongTien", hocPhiApDung));
                                cmdTaoHD.Parameters.Add(new SqlParameter("@tongPhaiTra", tongPhaiTra));
                                cmdTaoHD.Parameters.Add(new SqlParameter("@ghiChu", (object)dto.GhiChu ?? DBNull.Value));

                                hoaDonId = Convert.ToInt32(cmdTaoHD.ExecuteScalar());
                            }
                        }

                        decimal daThuTruoc = 0;
                        using (var cmdDaThu = new SqlCommand("SELECT ISNULL(SUM(SoTien), 0) FROM ThanhToan WITH (UPDLOCK, HOLDLOCK) WHERE HoaDonID = @hd AND IsDeleted = 0", conn, tx))
                        {
                            cmdDaThu.Parameters.Add(new SqlParameter("@hd", hoaDonId));
                            daThuTruoc = Convert.ToDecimal(cmdDaThu.ExecuteScalar());
                        }
                        if (dto.SoTien <= 0 || dto.SoTien > tongPhaiTra - daThuTruoc)
                            throw new InvalidOperationException("Số tiền thu vượt quá học phí còn phải đóng. Hãy tải lại dữ liệu và thử lại.");
                        // 2. Thêm bản ghi vào bảng ThanhToan (Phiếu thu)
                        int thanhToanId = 0;
                        string sqlInsertThanhToan = @"
                            INSERT INTO ThanhToan (HoaDonID, NhanSuID, NgayThanhToan, SoTien, PhuongThuc, GhiChu, IsDeleted, CreatedAt, RequestId)
                            VALUES (@hd, @ns, GETDATE(), @soTien, @pt, @ghiChu, 0, GETDATE(), @requestId);
                            SELECT SCOPE_IDENTITY();";

                        using (var cmdTT = new SqlCommand(sqlInsertThanhToan, conn, tx))
                        {
                            cmdTT.Parameters.Add(new SqlParameter("@hd", hoaDonId));
                            cmdTT.Parameters.Add(new SqlParameter("@ns", dto.NhanSuID));
                            cmdTT.Parameters.Add(new SqlParameter("@soTien", dto.SoTien));
                            cmdTT.Parameters.Add(new SqlParameter("@pt", dto.PhuongThuc));
                            cmdTT.Parameters.Add(new SqlParameter("@ghiChu", (object)dto.GhiChu ?? DBNull.Value));
                            cmdTT.Parameters.Add(new SqlParameter("@requestId", dto.RequestId));

                            thanhToanId = Convert.ToInt32(cmdTT.ExecuteScalar());
                        }

                        // 3. Tính lại tổng tiền đã thanh toán và cập nhật trạng thái HoaDon
                        string sqlTongDaNop = "SELECT ISNULL(SUM(SoTien), 0) FROM ThanhToan WHERE HoaDonID = @hd AND IsDeleted = 0";
                        decimal tongDaNop = 0;
                        using (var cmdTong = new SqlCommand(sqlTongDaNop, conn, tx))
                        {
                            cmdTong.Parameters.Add(new SqlParameter("@hd", hoaDonId));
                            tongDaNop = Convert.ToDecimal(cmdTong.ExecuteScalar());
                        }

                        string trangThaiMoi = (tongDaNop >= tongPhaiTra) ? "Đã đủ" : "Chưa đủ";
                        string sqlCapNhatHD = @"
                            UPDATE HoaDon
                            SET TrangThai = @tt, UpdatedAt = GETDATE()
                            WHERE HoaDonID = @hd";

                        using (var cmdUpdate = new SqlCommand(sqlCapNhatHD, conn, tx))
                        {
                            cmdUpdate.Parameters.Add(new SqlParameter("@tt", trangThaiMoi));
                            cmdUpdate.Parameters.Add(new SqlParameter("@hd", hoaDonId));
                            cmdUpdate.ExecuteNonQuery();
                        }

                        tx.Commit();
                        return thanhToanId;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        // ==========================================
        // 3. CÁC HÀM TRA CỨU PHIẾU THU
        // ==========================================

        /// <summary>
        /// Lấy danh sách phiếu thu theo Đăng ký học.
        /// </summary>
        public static List<PhieuThuDto> LayPhieuThuTheoDangKy(int maDangKy)
        {
            string sql = @"
                SELECT
                    t.ThanhToanID,
                    t.HoaDonID,
                    ISNULL(hd.DangKyID, 0) AS DangKyID,
                    hd.HocVienID,
                    hv.HoTen AS TenHocVien,
                    ISNULL(hv.SoDienThoai, '') AS SoDienThoai,
                    ISNULL(l.TenLop, '') AS TenLop,
                    t.NhanSuID,
                    ISNULL(ns.HoTen, N'Hệ thống') AS TenNhanVienThu,
                    t.NgayThanhToan,
                    t.SoTien,
                    t.PhuongThuc,
                    t.GhiChu
                FROM ThanhToan t
                JOIN HoaDon hd ON t.HoaDonID = hd.HoaDonID
                JOIN HocVien hv ON hd.HocVienID = hv.HocVienID
                LEFT JOIN DangKy d ON hd.DangKyID = d.DangKyID
                LEFT JOIN LopHoc l ON d.LopHocID = l.LopHocID
                LEFT JOIN NhanSu ns ON t.NhanSuID = ns.NhanSuID
                WHERE hd.DangKyID = @dangKyId AND t.IsDeleted = 0
                ORDER BY t.NgayThanhToan DESC";

            return TruyVanDanhSachPhieuThu(sql, new[] { new SqlParameter("@dangKyId", maDangKy) });
        }

        /// <summary>
        /// Lấy danh sách phiếu thu trong khoảng thời gian.
        /// </summary>
        public static List<PhieuThuDto> LayPhieuThuTheoThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            DateTime denNgayKetThuc = denNgay.Date.AddDays(1);

            string sql = @"
                SELECT
                    t.ThanhToanID,
                    t.HoaDonID,
                    ISNULL(hd.DangKyID, 0) AS DangKyID,
                    hd.HocVienID,
                    hv.HoTen AS TenHocVien,
                    ISNULL(hv.SoDienThoai, '') AS SoDienThoai,
                    ISNULL(l.TenLop, '') AS TenLop,
                    t.NhanSuID,
                    ISNULL(ns.HoTen, N'Hệ thống') AS TenNhanVienThu,
                    t.NgayThanhToan,
                    t.SoTien,
                    t.PhuongThuc,
                    t.GhiChu
                FROM ThanhToan t
                JOIN HoaDon hd ON t.HoaDonID = hd.HoaDonID
                JOIN HocVien hv ON hd.HocVienID = hv.HocVienID
                LEFT JOIN DangKy d ON hd.DangKyID = d.DangKyID
                LEFT JOIN LopHoc l ON d.LopHocID = l.LopHocID
                LEFT JOIN NhanSu ns ON t.NhanSuID = ns.NhanSuID
                WHERE t.IsDeleted = 0 AND t.NgayThanhToan >= @tu AND t.NgayThanhToan < @den
                ORDER BY t.NgayThanhToan DESC";

            return TruyVanDanhSachPhieuThu(sql, new[] {
                new SqlParameter("@tu", tuNgay.Date),
                new SqlParameter("@den", denNgayKetThuc)
            });
        }

        /// <summary>
        /// Lấy danh sách các lần nộp tiền của một hóa đơn cụ thể.
        /// </summary>
        public static List<PhieuThuDto> LayPhieuThuTheoHoaDon(int hoaDonId)
        {
            string sql = @"
                SELECT
                    t.ThanhToanID,
                    t.HoaDonID,
                    ISNULL(hd.DangKyID, 0) AS DangKyID,
                    hd.HocVienID,
                    hv.HoTen AS TenHocVien,
                    ISNULL(hv.SoDienThoai, '') AS SoDienThoai,
                    ISNULL(l.TenLop, '') AS TenLop,
                    t.NhanSuID,
                    ISNULL(ns.HoTen, N'Hệ thống') AS TenNhanVienThu,
                    t.NgayThanhToan,
                    t.SoTien,
                    t.PhuongThuc,
                    t.GhiChu
                FROM ThanhToan t
                JOIN HoaDon hd ON t.HoaDonID = hd.HoaDonID
                JOIN HocVien hv ON hd.HocVienID = hv.HocVienID
                LEFT JOIN DangKy d ON hd.DangKyID = d.DangKyID
                LEFT JOIN LopHoc l ON d.LopHocID = l.LopHocID
                LEFT JOIN NhanSu ns ON t.NhanSuID = ns.NhanSuID
                WHERE t.HoaDonID = @hdId AND t.IsDeleted = 0
                ORDER BY t.NgayThanhToan ASC";

            return TruyVanDanhSachPhieuThu(sql, new[] { new SqlParameter("@hdId", hoaDonId) });
        }

        // ==========================================
        // 4. HÀM HELPER ĐỌC DỮ LIỆU
        // ==========================================

        private static List<PhieuThuDto> TruyVanDanhSachPhieuThu(string sql, SqlParameter[] parameters)
        {
            var ketQua = new List<PhieuThuDto>();

            using (var conn = DatabaseConnection.TaoKetNoi())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ketQua.Add(new PhieuThuDto
                        {
                            ThanhToanID = Convert.ToInt32(reader["ThanhToanID"]),
                            HoaDonID = Convert.ToInt32(reader["HoaDonID"]),
                            DangKyID = Convert.ToInt32(reader["DangKyID"]),
                            HocVienID = Convert.ToInt32(reader["HocVienID"]),
                            TenHocVien = reader["TenHocVien"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            TenLop = reader["TenLop"].ToString(),
                            NhanSuID = reader["NhanSuID"] != DBNull.Value ? Convert.ToInt32(reader["NhanSuID"]) : 0,
                            TenNhanVienThu = reader["TenNhanVienThu"].ToString(),
                            NgayThanhToan = Convert.ToDateTime(reader["NgayThanhToan"]),
                            SoTien = Convert.ToDecimal(reader["SoTien"]),
                            PhuongThuc = reader["PhuongThuc"].ToString(),
                            GhiChu = reader["GhiChu"] != DBNull.Value ? reader["GhiChu"].ToString() : ""
                        });
                    }
                }
            }

            return ketQua;
        }

        private static HocPhiDto DocHocPhiDto(SqlDataReader reader)
        {
            decimal tongPhaiTra = Convert.ToDecimal(reader["TongPhaiTra"]);
            decimal daThanhToan = Convert.ToDecimal(reader["DaThanhToan"]);
            decimal conPhaiDong = tongPhaiTra > daThanhToan ? tongPhaiTra - daThanhToan : 0;

            string trangThaiText;
            if (daThanhToan >= tongPhaiTra && tongPhaiTra > 0)
            {
                trangThaiText = "Đã thu đủ";
            }
            else if (daThanhToan > 0)
            {
                trangThaiText = "Thanh toán 1 phần";
            }
            else
            {
                trangThaiText = "Chưa thanh toán";
            }

            string tenLop = reader["TenLop"].ToString();
            string tenKhoa = reader["TenKhoaHoc"].ToString();
            string khoanThu = !string.IsNullOrEmpty(tenLop) ? tenKhoa + " (" + tenLop + ")" : tenKhoa;

            return new HocPhiDto
            {
                HoaDonID = reader["HoaDonID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["HoaDonID"]) : null,
                MaHoaDon = reader["MaHoaDon"].ToString(),
                DangKyID = Convert.ToInt32(reader["DangKyID"]),
                HocVienID = Convert.ToInt32(reader["HocVienID"]),
                MaHocVien = reader["MaHocVien"].ToString(),
                TenHocVien = reader["TenHocVien"].ToString(),
                SoDienThoai = reader["SoDienThoai"].ToString(),
                LopHocID = Convert.ToInt32(reader["LopHocID"]),
                TenLop = tenLop,
                TenKhoaHoc = tenKhoa,
                TenKhoanThu = khoanThu,
                NgayLap = reader["NgayLap"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["NgayLap"]) : null,
                TongTien = Convert.ToDecimal(reader["TongTien"]),
                GiamGia = Convert.ToDecimal(reader["GiamGia"]),
                TongPhaiTra = tongPhaiTra,
                DaThanhToan = daThanhToan,
                ConPhaiDong = conPhaiDong,
                TrangThai = trangThaiText,
                GhiChu = reader["GhiChu"] != DBNull.Value ? reader["GhiChu"].ToString() : ""
            };
        }
    }
}
