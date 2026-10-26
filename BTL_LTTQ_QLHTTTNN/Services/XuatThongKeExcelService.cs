using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN.Services
{
    public static class XuatThongKeExcelService
    {
        public static Task TaoBaoCaoExcelAsync(ThongKeBoLoc boLoc, string duongDan, CancellationToken huy)
        {
            if (boLoc == null) throw new ArgumentNullException("boLoc");
            if (string.IsNullOrWhiteSpace(duongDan)) throw new ArgumentException("Chưa chọn đường dẫn lưu.", "duongDan");
            var loc = new ThongKeBoLoc { TuNgay = boLoc.TuNgay.Date, DenNgay = boLoc.DenNgay.Date, CoSoID = boLoc.CoSoID };
            return Task.Run(() => TaoBaoCao(loc, duongDan, huy), huy);
        }

        private static void TaoBaoCao(ThongKeBoLoc loc, string duongDan, CancellationToken huy)
        {
            string thuMuc = Path.GetDirectoryName(Path.GetFullPath(duongDan));
            string tam = Path.Combine(thuMuc, "." + Path.GetFileName(duongDan) + "." + Guid.NewGuid().ToString("N") + ".tmp");
            try
            {
                using (var file = new FileStream(tam, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None))
                using (var zip = new ZipArchive(file, ZipArchiveMode.Create, true))
                {
                    TaoPhanWorkbook(zip);
                    var hoaDon = ThongKeService.LayTongHopHoaDon(loc);
                    var thanhToan = ThongKeService.LayTongHopThanhToan(loc);
                    var dangKy = ThongKeService.LayTongHopDangKy(loc);
                    GhiSheet(zip, "TongQuan", 1, w =>
                    {
                        object[,] rows = { { "Báo cáo thống kê", "" }, { "Từ ngày", loc.TuNgay }, { "Đến ngày", loc.DenNgay }, { "Cơ sở", loc.CoSoID.HasValue ? (object)loc.CoSoID.Value : "Tất cả cơ sở" }, { "Thời điểm xuất", DateTime.Now }, { "Tổng số hóa đơn", hoaDon.TongSoLuong }, { "Tổng phải trả", hoaDon.TongPhaiTra }, { "Đã thanh toán đến cuối kỳ", hoaDon.TongDaThanhToanCuoiKy }, { "Còn phải thu", hoaDon.TongConPhaiThu }, { "Tổng lượt thanh toán", thanhToan.TongSoLuong }, { "Thực thu trong kỳ", thanhToan.TongThucThuTrongKy }, { "Tổng đăng ký trong kỳ", dangKy.TongSoLuong }, { "Học viên khác nhau", dangKy.TongHocVienKhacNhau } };
                        for (int i = 0; i < rows.GetLength(0); i++) { huy.ThrowIfCancellationRequested(); GhiDong(w, i + 1, new object[] { rows[i, 0], rows[i, 1] }, new bool[] { false, rows[i, 1] is DateTime }); }
                    }, null);
                    GhiSheet(zip, "HoaDon", 2, w =>
                    {
                        GhiDong(w, 1, new object[] { "Mã hóa đơn", "Ngày lập", "Học viên", "Lớp", "Cơ sở", "Phải trả", "Đã thanh toán đến cuối kỳ", "Còn phải thu", "Thu vượt" }, null);
                        int soDong = DocCacTrang(page => ThongKeService.LayTinhHinhThuTheoTrang(loc, page), huy, (row, index) => GhiDong(w, index + 2, new object[] { row.HoaDonID, row.NgayLap.Date, row.HocVien, row.TenLop, row.CoSo, row.TongPhaiTra, row.DaThanhToan, row.ConPhaiThu, row.ThuVuot ? "Có" : "Không" }, new bool[] { false, true, false, false, false, false, false, false, false }));
                        GhiDong(w, soDong + 2, new object[] { "Tổng cộng", null, null, null, null, hoaDon.TongPhaiTra, hoaDon.TongDaThanhToanCuoiKy, hoaDon.TongConPhaiThu, null }, null);
                    }, null);
                    GhiSheet(zip, "ThanhToan", 2, w =>
                    {
                        GhiDong(w, 1, new object[] { "Mã thanh toán", "Ngày thanh toán", "Mã hóa đơn", "Học viên", "Số tiền" }, null);
                        int soDong = DocCacTrang(page => ThongKeService.LayChiTietThanhToanTheoTrang(loc, page), huy, (row, index) => GhiDong(w, index + 2, new object[] { row.ThanhToanID, row.NgayThanhToan, row.HoaDonID, row.HocVien, row.SoTien }, new bool[] { false, true, false, false, false }));
                        GhiDong(w, soDong + 2, new object[] { "Tổng cộng", null, null, null, thanhToan.TongThucThuTrongKy }, null);
                    }, null);
                    GhiSheet(zip, "DangKy", 2, w =>
                    {
                        GhiDong(w, 1, new object[] { "Mã đăng ký", "Ngày đăng ký", "Học viên", "Lớp", "Trạng thái" }, null);
                        int soDong = DocCacTrang(page => ThongKeService.LayChiTietDangKyTheoTrang(loc, page), huy, (row, index) => GhiDong(w, index + 2, new object[] { row.DangKyID, row.NgayDangKy.Date, row.HocVien, row.LopHoc, row.TrangThai }, new bool[] { false, true, false, false, false }));
                        GhiDong(w, soDong + 2, new object[] { "Tổng số đăng ký", dangKy.TongSoLuong, "Học viên khác nhau", dangKy.TongHocVienKhacNhau, null }, null);
                    }, null);
                }
                huy.ThrowIfCancellationRequested();
                if (File.Exists(duongDan)) File.Replace(tam, duongDan, null); else File.Move(tam, duongDan);
            }
            catch { if (File.Exists(tam)) File.Delete(tam); throw; }
        }

        private static int DocCacTrang<T>(Func<int, KetQuaPhanTrang<T>> layTrang, CancellationToken huy, Action<T, int> ghi)
        {
            int page = 1, index = 0, totalPages;
            do
            {
                huy.ThrowIfCancellationRequested(); var rows = layTrang(page); totalPages = rows.TongSoTrang;
                foreach (var row in rows.DanhSach) { huy.ThrowIfCancellationRequested(); ghi(row, index++); }
                page++;
            } while (page <= totalPages);
            return index;
        }

        private static void TaoPhanWorkbook(ZipArchive zip)
        {
            const string packageNs = "http://schemas.openxmlformats.org/package/2006/content-types";
            GhiXml(zip, "[Content_Types].xml", w =>
            {
                w.WriteStartElement("Types", packageNs);
                AddOverride(w, packageNs, "/xl/workbook.xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml");
                for (int i = 1; i <= 4; i++) AddOverride(w, packageNs, "/xl/worksheets/sheet" + i + ".xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml");
                AddOverride(w, packageNs, "/xl/styles.xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml");
                w.WriteStartElement("Default", packageNs); w.WriteAttributeString("Extension", "rels"); w.WriteAttributeString("ContentType", "application/vnd.openxmlformats-package.relationships+xml"); w.WriteEndElement();
                w.WriteStartElement("Default", packageNs); w.WriteAttributeString("Extension", "xml"); w.WriteAttributeString("ContentType", "application/xml"); w.WriteEndElement(); w.WriteEndElement();
            });
            GhiXml(zip, "_rels/.rels", w => { w.WriteStartElement("Relationships", "http://schemas.openxmlformats.org/package/2006/relationships"); w.WriteStartElement("Relationship"); w.WriteAttributeString("Id", "rId1"); w.WriteAttributeString("Type", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"); w.WriteAttributeString("Target", "xl/workbook.xml"); w.WriteEndElement(); w.WriteEndElement(); });
            GhiXml(zip, "xl/workbook.xml", w => { w.WriteStartElement("workbook", "http://schemas.openxmlformats.org/spreadsheetml/2006/main"); w.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships"); w.WriteStartElement("sheets"); string[] names = { "TongQuan", "HoaDon", "ThanhToan", "DangKy" }; for (int i = 0; i < names.Length; i++) { w.WriteStartElement("sheet"); w.WriteAttributeString("name", names[i]); w.WriteAttributeString("sheetId", (i + 1).ToString()); w.WriteAttributeString("r", "id", "http://schemas.openxmlformats.org/officeDocument/2006/relationships", "rId" + (i + 1)); w.WriteEndElement(); } w.WriteEndElement(); w.WriteEndElement(); });
            GhiXml(zip, "xl/_rels/workbook.xml.rels", w => { w.WriteStartElement("Relationships", "http://schemas.openxmlformats.org/package/2006/relationships"); for (int i = 1; i <= 4; i++) { w.WriteStartElement("Relationship"); w.WriteAttributeString("Id", "rId" + i); w.WriteAttributeString("Type", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet"); w.WriteAttributeString("Target", "worksheets/sheet" + i + ".xml"); w.WriteEndElement(); } w.WriteStartElement("Relationship"); w.WriteAttributeString("Id", "rId5"); w.WriteAttributeString("Type", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles"); w.WriteAttributeString("Target", "styles.xml"); w.WriteEndElement(); w.WriteEndElement(); });
            GhiXml(zip, "xl/styles.xml", w =>
            {
                const string ns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main"; w.WriteStartElement("styleSheet", ns);
                w.WriteStartElement("numFmts"); w.WriteAttributeString("count", "1"); w.WriteStartElement("numFmt"); w.WriteAttributeString("numFmtId", "164"); w.WriteAttributeString("formatCode", "dd/mm/yyyy"); w.WriteEndElement(); w.WriteEndElement();
                w.WriteStartElement("fonts"); w.WriteAttributeString("count", "2"); w.WriteStartElement("font"); w.WriteEndElement(); w.WriteStartElement("font"); w.WriteElementString("b", ""); w.WriteEndElement(); w.WriteEndElement();
                w.WriteStartElement("fills"); w.WriteAttributeString("count", "1"); w.WriteStartElement("fill"); w.WriteStartElement("patternFill"); w.WriteAttributeString("patternType", "none"); w.WriteEndElement(); w.WriteEndElement(); w.WriteEndElement();
                w.WriteStartElement("borders"); w.WriteAttributeString("count", "1"); w.WriteStartElement("border"); w.WriteEndElement(); w.WriteEndElement();
                w.WriteStartElement("cellStyleXfs"); w.WriteAttributeString("count", "1"); w.WriteStartElement("xf"); w.WriteEndElement(); w.WriteEndElement();
                w.WriteStartElement("cellXfs"); w.WriteAttributeString("count", "3");
                for (int i = 0; i < 3; i++) { w.WriteStartElement("xf"); w.WriteAttributeString("numFmtId", i == 2 ? "164" : "0"); w.WriteAttributeString("fontId", i == 1 ? "1" : "0"); w.WriteAttributeString("fillId", "0"); w.WriteAttributeString("borderId", "0"); w.WriteAttributeString("xfId", "0"); if (i == 1) w.WriteAttributeString("applyFont", "1"); if (i == 2) w.WriteAttributeString("applyNumberFormat", "1"); w.WriteEndElement(); }
                w.WriteEndElement(); w.WriteEndElement();
            });
        }

        private static void AddOverride(XmlWriter w, string ns, string partName, string contentType)
        { w.WriteStartElement("Override", ns); w.WriteAttributeString("PartName", partName); w.WriteAttributeString("ContentType", contentType); w.WriteEndElement(); }
        private static void GhiSheet(ZipArchive zip, string ten, int sheetId, Action<XmlWriter> ghiNoiDung, object unused)
        {
            var entry = zip.CreateEntry("xl/worksheets/sheet" + sheetId + ".xml", CompressionLevel.Fastest);
            using (var stream = entry.Open()) using (var w = XmlWriter.Create(stream, new XmlWriterSettings { Encoding = new System.Text.UTF8Encoding(false), CloseOutput = false }))
            {
                w.WriteStartDocument(); w.WriteStartElement("worksheet", "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
                w.WriteStartElement("sheetViews"); w.WriteStartElement("sheetView"); w.WriteAttributeString("workbookViewId", "0"); w.WriteStartElement("pane"); w.WriteAttributeString("ySplit", "1"); w.WriteAttributeString("topLeftCell", "A2"); w.WriteAttributeString("activePane", "bottomLeft"); w.WriteAttributeString("state", "frozen"); w.WriteEndElement(); w.WriteEndElement(); w.WriteEndElement();
                w.WriteStartElement("sheetFormatPr"); w.WriteAttributeString("defaultRowHeight", "18"); w.WriteEndElement();
                w.WriteStartElement("cols"); for (int i = 1; i <= 12; i++) { w.WriteStartElement("col"); w.WriteAttributeString("min", i.ToString()); w.WriteAttributeString("max", i.ToString()); w.WriteAttributeString("width", "22"); w.WriteAttributeString("customWidth", "1"); w.WriteEndElement(); } w.WriteEndElement();
                w.WriteStartElement("sheetData"); ghiNoiDung(w); w.WriteEndElement(); if (sheetId > 1) { w.WriteStartElement("autoFilter"); w.WriteAttributeString("ref", sheetId == 2 ? "A1:I1048576" : "A1:E1048576"); w.WriteEndElement(); } w.WriteEndElement(); w.WriteEndDocument();
            }
        }

        private static void GhiDong(XmlWriter w, int soDong, object[] giaTri, bool[] ngay)
        {
            w.WriteStartElement("row"); w.WriteAttributeString("r", soDong.ToString(CultureInfo.InvariantCulture));
            for (int i = 0; i < giaTri.Length; i++)
            {
                object value = giaTri[i]; if (value == null) continue; string diaChi = CotExcel(i + 1) + soDong.ToString(CultureInfo.InvariantCulture);
                w.WriteStartElement("c"); w.WriteAttributeString("r", diaChi);
                if (soDong == 1) w.WriteAttributeString("s", "1");
                if (value is DateTime) { if (ngay != null && ngay[i]) w.WriteAttributeString("s", "2"); w.WriteElementString("v", Convert.ToDateTime(value).ToOADate().ToString(CultureInfo.InvariantCulture)); }
                else if (value is int || value is long || value is decimal || value is double) w.WriteElementString("v", Convert.ToString(value, CultureInfo.InvariantCulture));
                else { w.WriteAttributeString("t", "inlineStr"); w.WriteStartElement("is"); w.WriteElementString("t", "http://schemas.openxmlformats.org/spreadsheetml/2006/main", Convert.ToString(value, CultureInfo.CurrentCulture)); w.WriteEndElement(); }
                w.WriteEndElement();
            }
            w.WriteEndElement();
        }
        private static string CotExcel(int col) { string s = ""; while (col > 0) { int m = (col - 1) % 26; s = (char)('A' + m) + s; col = (col - 1) / 26; } return s; }
        private static void GhiXml(ZipArchive zip, string ten, Action<XmlWriter> ghi)
        { using (var s = zip.CreateEntry(ten).Open()) using (var w = XmlWriter.Create(s, new XmlWriterSettings { Encoding = new System.Text.UTF8Encoding(false), CloseOutput = false })) ghi(w); }
    }
}
