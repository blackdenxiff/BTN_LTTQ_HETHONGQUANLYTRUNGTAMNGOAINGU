using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;
using BTL_LTTQ_QLHTTTNN.Services.Models;

namespace BTL_LTTQ_QLHTTTNN.Services
{
    public static class XuatThongKeExcelService
    {
        public static Task TaoBaoCaoExcelAsync(ThongKeBoLoc boLoc, string duongDan, CancellationToken huy)
        { return TaoBaoCaoExcelAsync(boLoc, duongDan, "Thống kê tổng hợp", huy); }

        public static Task TaoBaoCaoExcelAsync(ThongKeBoLoc boLoc, string duongDan, string loaiBaoCao, CancellationToken huy)
        {
            if (boLoc == null) throw new ArgumentNullException("boLoc");
            if (string.IsNullOrWhiteSpace(duongDan)) throw new ArgumentException("Chưa chọn đường dẫn lưu.", "duongDan");
            if (loaiBaoCao != "Hóa đơn trong kỳ" && loaiBaoCao != "Thanh toán phát sinh" && loaiBaoCao != "Đăng ký trong kỳ" && loaiBaoCao != "Thống kê tổng hợp") throw new ArgumentException("Loại báo cáo không hợp lệ.", "loaiBaoCao");
            var loc = new ThongKeBoLoc { TuNgay = boLoc.TuNgay.Date, DenNgay = boLoc.DenNgay.Date, CoSoID = boLoc.CoSoID, TenCoSo = boLoc.TenCoSo };
            return Task.Run(() => TaoBaoCao(loc, duongDan, loaiBaoCao, huy), huy);
        }

        private static void TaoBaoCao(ThongKeBoLoc loc, string duongDan, string loaiBaoCao, CancellationToken huy)
        {
            string thuMuc = Path.GetDirectoryName(Path.GetFullPath(duongDan));
            string tam = Path.Combine(thuMuc, "." + Path.GetFileName(duongDan) + "." + Guid.NewGuid().ToString("N") + ".tmp");
            try
            {
                var tuyChonGiaoDich = new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.Serializable, Timeout = TimeSpan.FromMinutes(30) };
                using (var giaoDich = new TransactionScope(TransactionScopeOption.Required, tuyChonGiaoDich))
                {
                using (var file = new FileStream(tam, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None))
                using (var zip = new ZipArchive(file, ZipArchiveMode.Create, true))
                {
                    bool tongHop = loaiBaoCao == "Thống kê tổng hợp";
                    bool coHoaDon = tongHop || loaiBaoCao == "Hóa đơn trong kỳ";
                    bool coThanhToan = tongHop || loaiBaoCao == "Thanh toán phát sinh";
                    bool coDangKy = tongHop || loaiBaoCao == "Đăng ký trong kỳ";
                    var tenSheet = new List<string>();
                    tenSheet.Add("TongQuan");
                    if (coHoaDon) tenSheet.Add("HoaDon");
                    if (coThanhToan) tenSheet.Add("ThanhToan");
                    if (coDangKy) tenSheet.Add("DangKy");
                    TaoPhanWorkbook(zip, tenSheet);
                    var hoaDon = coHoaDon ? ThongKeService.LayTongHopHoaDon(loc) : null;
                    var thanhToan = coThanhToan ? ThongKeService.LayTongHopThanhToan(loc) : null;
                    var dangKy = coDangKy ? ThongKeService.LayTongHopDangKy(loc) : null;
                    int sheet = 1;
                    GhiSheet(zip, sheet++, 2, false, w =>
                    {
                        object[,] rows = { { "Báo cáo thống kê - " + loaiBaoCao, "" }, { "Từ ngày", loc.TuNgay }, { "Đến ngày", loc.DenNgay }, { "Cơ sở", loc.CoSoID.HasValue ? (object)(loc.TenCoSo ?? loc.CoSoID.Value.ToString()) : "Tất cả cơ sở" }, { "Thời điểm xuất", DateTime.Now }, { "Tổng số hóa đơn", coHoaDon ? (object)hoaDon.TongSoLuong : null }, { "Tổng phải trả", coHoaDon ? (object)hoaDon.TongPhaiTra : null }, { "Đã thanh toán đến cuối kỳ", coHoaDon ? (object)hoaDon.TongDaThanhToanCuoiKy : null }, { "Còn phải thu", coHoaDon ? (object)hoaDon.TongConPhaiThu : null }, { "Tổng lượt thanh toán", coThanhToan ? (object)thanhToan.TongSoLuong : null }, { "Thực thu trong kỳ", coThanhToan ? (object)thanhToan.TongThucThuTrongKy : null }, { "Tổng đăng ký trong kỳ", coDangKy ? (object)dangKy.TongSoLuong : null }, { "Học viên khác nhau", coDangKy ? (object)dangKy.TongHocVienKhacNhau : null } };
                        for (int i = 0; i < rows.GetLength(0); i++) { huy.ThrowIfCancellationRequested(); GhiDong(w, i + 1, new object[] { rows[i, 0], rows[i, 1] }, new bool[] { false, rows[i, 1] is DateTime }); }
                    });
                    if (coHoaDon) GhiSheet(zip, sheet++, 9, true, w =>
                    {
                        GhiDong(w, 1, new object[] { "Mã hóa đơn", "Ngày lập", "Học viên", "Lớp", "Cơ sở", "Phải trả (đ)", "Đã thanh toán đến cuối kỳ (đ)", "Còn phải thu (đ)", "Thu vượt" }, null);
                        int soDong = DocCacTrang(page => ThongKeService.LayTinhHinhThuTheoTrang(loc, page), huy, (row, index) => GhiDong(w, index + 2, new object[] { row.HoaDonID, row.NgayLap.Date, row.HocVien, row.TenLop, row.CoSo, row.TongPhaiTra, row.DaThanhToan, row.ConPhaiThu, row.ThuVuot ? "Có" : "Không" }, new bool[] { false, true, false, false, false, false, false, false, false }));
                        if (soDong == 0) GhiDong(w, 2, new object[] { "Không có dữ liệu phù hợp" }, null);
                        GhiDong(w, soDong + (soDong == 0 ? 3 : 2), new object[] { "Tổng cộng", null, null, null, null, hoaDon.TongPhaiTra, hoaDon.TongDaThanhToanCuoiKy, hoaDon.TongConPhaiThu, null }, null);
                    });
                    if (coThanhToan) GhiSheet(zip, sheet++, 5, true, w =>
                    {
                        GhiDong(w, 1, new object[] { "Mã thanh toán", "Ngày thanh toán", "Mã hóa đơn", "Học viên", "Số tiền (đ)" }, null);
                        int soDong = DocCacTrang(page => ThongKeService.LayChiTietThanhToanTheoTrang(loc, page), huy, (row, index) => GhiDong(w, index + 2, new object[] { row.ThanhToanID, row.NgayThanhToan, row.HoaDonID, row.HocVien, row.SoTien }, new bool[] { false, true, false, false, false }));
                        if (soDong == 0) GhiDong(w, 2, new object[] { "Không có dữ liệu phù hợp" }, null);
                        GhiDong(w, soDong + (soDong == 0 ? 3 : 2), new object[] { "Tổng cộng", null, null, null, thanhToan.TongThucThuTrongKy }, null);
                    });
                    if (coDangKy) GhiSheet(zip, sheet++, 5, true, w =>
                    {
                        GhiDong(w, 1, new object[] { "Mã đăng ký", "Ngày đăng ký", "Học viên", "Lớp", "Trạng thái" }, null);
                        int soDong = DocCacTrang(page => ThongKeService.LayChiTietDangKyTheoTrang(loc, page), huy, (row, index) => GhiDong(w, index + 2, new object[] { row.DangKyID, row.NgayDangKy.Date, row.HocVien, row.LopHoc, row.TrangThai }, new bool[] { false, true, false, false, false }));
                        if (soDong == 0) GhiDong(w, 2, new object[] { "Không có dữ liệu phù hợp" }, null);
                        GhiDong(w, soDong + (soDong == 0 ? 3 : 2), new object[] { "Tổng số đăng ký", dangKy.TongSoLuong, "Học viên khác nhau", dangKy.TongHocVienKhacNhau, null }, null);
                    });
                }
                huy.ThrowIfCancellationRequested();
                giaoDich.Complete();
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

        private static void TaoPhanWorkbook(ZipArchive zip, IList<string> names)
        {
            const string packageNs = "http://schemas.openxmlformats.org/package/2006/content-types";
            GhiXml(zip, "[Content_Types].xml", w =>
            {
                w.WriteStartElement("Types", packageNs);
                AddOverride(w, packageNs, "/xl/workbook.xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml");
                for (int i = 1; i <= names.Count; i++) AddOverride(w, packageNs, "/xl/worksheets/sheet" + i + ".xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml");
                AddOverride(w, packageNs, "/xl/styles.xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml");
                w.WriteStartElement("Default", packageNs); w.WriteAttributeString("Extension", "rels"); w.WriteAttributeString("ContentType", "application/vnd.openxmlformats-package.relationships+xml"); w.WriteEndElement();
                w.WriteStartElement("Default", packageNs); w.WriteAttributeString("Extension", "xml"); w.WriteAttributeString("ContentType", "application/xml"); w.WriteEndElement(); w.WriteEndElement();
            });
            GhiXml(zip, "_rels/.rels", w => { const string ns = "http://schemas.openxmlformats.org/package/2006/relationships"; w.WriteStartElement("Relationships", ns); w.WriteStartElement("Relationship", ns); w.WriteAttributeString("Id", "rId1"); w.WriteAttributeString("Type", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"); w.WriteAttributeString("Target", "xl/workbook.xml"); w.WriteEndElement(); w.WriteEndElement(); });
            GhiXml(zip, "xl/workbook.xml", w => { const string ns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main"; w.WriteStartElement("workbook", ns); w.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships"); w.WriteStartElement("sheets", ns); for (int i = 0; i < names.Count; i++) { w.WriteStartElement("sheet", ns); w.WriteAttributeString("name", names[i]); w.WriteAttributeString("sheetId", (i + 1).ToString()); w.WriteAttributeString("r", "id", "http://schemas.openxmlformats.org/officeDocument/2006/relationships", "rId" + (i + 1)); w.WriteEndElement(); } w.WriteEndElement(); w.WriteEndElement(); });
            GhiXml(zip, "xl/_rels/workbook.xml.rels", w => { const string ns = "http://schemas.openxmlformats.org/package/2006/relationships"; w.WriteStartElement("Relationships", ns); for (int i = 1; i <= names.Count; i++) { w.WriteStartElement("Relationship", ns); w.WriteAttributeString("Id", "rId" + i); w.WriteAttributeString("Type", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet"); w.WriteAttributeString("Target", "worksheets/sheet" + i + ".xml"); w.WriteEndElement(); } w.WriteStartElement("Relationship", ns); w.WriteAttributeString("Id", "rId" + (names.Count + 1)); w.WriteAttributeString("Type", "http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles"); w.WriteAttributeString("Target", "styles.xml"); w.WriteEndElement(); w.WriteEndElement(); });
            GhiXml(zip, "xl/styles.xml", w =>
            {
                const string ns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main"; w.WriteStartElement("styleSheet", ns);
                w.WriteStartElement("numFmts", ns); w.WriteAttributeString("count", "3"); w.WriteStartElement("numFmt", ns); w.WriteAttributeString("numFmtId", "164"); w.WriteAttributeString("formatCode", "dd/mm/yyyy"); w.WriteEndElement(); w.WriteStartElement("numFmt", ns); w.WriteAttributeString("numFmtId", "165"); w.WriteAttributeString("formatCode", "#,##0"); w.WriteEndElement(); w.WriteStartElement("numFmt", ns); w.WriteAttributeString("numFmtId", "166"); w.WriteAttributeString("formatCode", "dd/mm/yyyy hh:mm"); w.WriteEndElement(); w.WriteEndElement();
                w.WriteStartElement("fonts", ns); w.WriteAttributeString("count", "2");
                w.WriteStartElement("font", ns); w.WriteStartElement("sz", ns); w.WriteAttributeString("val", "11"); w.WriteEndElement(); w.WriteStartElement("color", ns); w.WriteAttributeString("theme", "1"); w.WriteEndElement(); w.WriteStartElement("name", ns); w.WriteAttributeString("val", "Calibri"); w.WriteEndElement(); w.WriteStartElement("family", ns); w.WriteAttributeString("val", "2"); w.WriteEndElement(); w.WriteEndElement();
                w.WriteStartElement("font", ns); w.WriteElementString("b", ns, ""); w.WriteStartElement("sz", ns); w.WriteAttributeString("val", "11"); w.WriteEndElement(); w.WriteStartElement("color", ns); w.WriteAttributeString("theme", "1"); w.WriteEndElement(); w.WriteStartElement("name", ns); w.WriteAttributeString("val", "Calibri"); w.WriteEndElement(); w.WriteStartElement("family", ns); w.WriteAttributeString("val", "2"); w.WriteEndElement(); w.WriteEndElement(); w.WriteEndElement();
                w.WriteStartElement("fills", ns); w.WriteAttributeString("count", "1"); w.WriteStartElement("fill", ns); w.WriteStartElement("patternFill", ns); w.WriteAttributeString("patternType", "none"); w.WriteEndElement(); w.WriteEndElement(); w.WriteEndElement();
                w.WriteStartElement("borders", ns); w.WriteAttributeString("count", "1"); w.WriteStartElement("border", ns); w.WriteStartElement("left", ns); w.WriteEndElement(); w.WriteStartElement("right", ns); w.WriteEndElement(); w.WriteStartElement("top", ns); w.WriteEndElement(); w.WriteStartElement("bottom", ns); w.WriteEndElement(); w.WriteStartElement("diagonal", ns); w.WriteEndElement(); w.WriteEndElement(); w.WriteEndElement();
                w.WriteStartElement("cellStyleXfs", ns); w.WriteAttributeString("count", "1"); w.WriteStartElement("xf", ns); w.WriteAttributeString("numFmtId", "0"); w.WriteAttributeString("fontId", "0"); w.WriteAttributeString("fillId", "0"); w.WriteAttributeString("borderId", "0"); w.WriteEndElement(); w.WriteEndElement();
                w.WriteStartElement("cellXfs", ns); w.WriteAttributeString("count", "5");
                for (int i = 0; i < 5; i++) { w.WriteStartElement("xf", ns); w.WriteAttributeString("numFmtId", i == 2 ? "164" : i == 3 ? "165" : i == 4 ? "166" : "0"); w.WriteAttributeString("fontId", i == 1 ? "1" : "0"); w.WriteAttributeString("fillId", "0"); w.WriteAttributeString("borderId", "0"); w.WriteAttributeString("xfId", "0"); if (i == 1) w.WriteAttributeString("applyFont", "1"); if (i >= 2) w.WriteAttributeString("applyNumberFormat", "1"); w.WriteEndElement(); }
                w.WriteEndElement();
                w.WriteStartElement("cellStyles", ns); w.WriteAttributeString("count", "1"); w.WriteStartElement("cellStyle", ns); w.WriteAttributeString("name", "Normal"); w.WriteAttributeString("xfId", "0"); w.WriteAttributeString("builtinId", "0"); w.WriteEndElement(); w.WriteEndElement();
                w.WriteEndElement();
            });
        }

        private static void AddOverride(XmlWriter w, string ns, string partName, string contentType)
        { w.WriteStartElement("Override", ns); w.WriteAttributeString("PartName", partName); w.WriteAttributeString("ContentType", contentType); w.WriteEndElement(); }
        private static void GhiSheet(ZipArchive zip, int sheetId, int soCot, bool locBang, Action<XmlWriter> ghiNoiDung)
        {
            var entry = zip.CreateEntry("xl/worksheets/sheet" + sheetId + ".xml", CompressionLevel.Fastest);
            using (var stream = entry.Open()) using (var w = XmlWriter.Create(stream, new XmlWriterSettings { Encoding = new System.Text.UTF8Encoding(false), CloseOutput = false }))
            {
                const string ns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
                w.WriteStartDocument(); w.WriteStartElement("worksheet", ns);
                w.WriteStartElement("sheetViews", ns); w.WriteStartElement("sheetView", ns); w.WriteAttributeString("workbookViewId", "0"); w.WriteStartElement("pane", ns); w.WriteAttributeString("ySplit", "1"); w.WriteAttributeString("topLeftCell", "A2"); w.WriteAttributeString("activePane", "bottomLeft"); w.WriteAttributeString("state", "frozen"); w.WriteEndElement(); w.WriteEndElement(); w.WriteEndElement();
                w.WriteStartElement("sheetFormatPr", ns); w.WriteAttributeString("defaultRowHeight", "18"); w.WriteEndElement();
                w.WriteStartElement("cols", ns); for (int i = 1; i <= 12; i++) { w.WriteStartElement("col", ns); w.WriteAttributeString("min", i.ToString()); w.WriteAttributeString("max", i.ToString()); w.WriteAttributeString("width", "22"); w.WriteAttributeString("customWidth", "1"); w.WriteEndElement(); } w.WriteEndElement();
                w.WriteStartElement("sheetData", ns); ghiNoiDung(w); w.WriteEndElement(); if (locBang) { w.WriteStartElement("autoFilter", ns); w.WriteAttributeString("ref", "A1:" + CotExcel(soCot) + "1048576"); w.WriteEndElement(); } w.WriteEndElement(); w.WriteEndDocument();
            }
        }

        private static void GhiDong(XmlWriter w, int soDong, object[] giaTri, bool[] ngay)
        {
            const string ns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
            w.WriteStartElement("row", ns); w.WriteAttributeString("r", soDong.ToString(CultureInfo.InvariantCulture));
            for (int i = 0; i < giaTri.Length; i++)
            {
                object value = giaTri[i]; if (value == null) continue; string diaChi = CotExcel(i + 1) + soDong.ToString(CultureInfo.InvariantCulture);
                w.WriteStartElement("c", ns); w.WriteAttributeString("r", diaChi);
                if (soDong == 1) w.WriteAttributeString("s", "1");
                if (value is DateTime) { DateTime date = Convert.ToDateTime(value); if (ngay != null && ngay[i]) w.WriteAttributeString("s", date.TimeOfDay == TimeSpan.Zero ? "2" : "4"); w.WriteElementString("v", ns, date.ToOADate().ToString(CultureInfo.InvariantCulture)); }
                else if (value is decimal) { w.WriteAttributeString("s", "3"); w.WriteElementString("v", ns, Convert.ToString(value, CultureInfo.InvariantCulture)); }
                else if (value is int || value is long || value is decimal || value is double) w.WriteElementString("v", ns, Convert.ToString(value, CultureInfo.InvariantCulture));
                else { w.WriteAttributeString("t", "inlineStr"); w.WriteStartElement("is", ns); w.WriteElementString("t", ns, Convert.ToString(value, CultureInfo.CurrentCulture)); w.WriteEndElement(); }
                w.WriteEndElement();
            }
            w.WriteEndElement();
        }
        private static string CotExcel(int col) { string s = ""; while (col > 0) { int m = (col - 1) % 26; s = (char)('A' + m) + s; col = (col - 1) / 26; } return s; }
        private static void GhiXml(ZipArchive zip, string ten, Action<XmlWriter> ghi)
        { using (var s = zip.CreateEntry(ten).Open()) using (var w = XmlWriter.Create(s, new XmlWriterSettings { Encoding = new System.Text.UTF8Encoding(false), CloseOutput = false })) ghi(w); }
    }
}
