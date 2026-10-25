# Hướng dẫn phần TV1

## Phạm vi và cấu trúc

- `BTL_LTTQ_QLHTTTNN/Forms/Shared`: đăng nhập và đổi mật khẩu.
- `BTL_LTTQ_QLHTTTNN/Forms/Admin`: màn hình Admin, quản lý tài khoản, thống kê.
- `BTL_LTTQ_QLHTTTNN/Data`: truy vấn SQL và kết nối dùng chung.
- `BTL_LTTQ_QLHTTTNN/Services`: xác thực, mật khẩu, phiên, phân quyền, tài khoản và thống kê.
- `BTL_LTTQ_QLHTTTNN/Services/Models`: DTO, bộ lọc và kết quả phân trang.

Ứng dụng dùng .NET Framework 4.7.2 và SQL Server qua chuỗi `QLTrungTamTiengAnh` trong `App.config`. `DatabaseConnection.TaoKetNoi()` trả về kết nối mới chưa mở; bên gọi phải giải phóng bằng `using`. Các API cũ `Connect`, `Disconnect`, `GetDataToTable`, `GetFieldValues` và `RunSQL` vẫn được giữ để code khác không mất liên kết.

Các câu truy vấn phần này giả định schema đã áp dụng những cột có trong `Tài Nguyên/Database/QLTrungTamNgoaiNgu.sql`, gồm `IsDeleted`, `DeletedAt`, `DoiMatKhauLanDau`, `CreatedAt` và `UpdatedAt`. Không có migration hoặc thay đổi schema trong phần TV1.

## Phiên, đăng nhập và mật khẩu

| Hàm | Vị trí, đầu vào và đầu ra | Quyền, nơi gọi, tác động |
| --- | --- | --- |
| `TaoKetNoi()` | `Data/DatabaseConnection.cs`; không có đầu vào; trả về `SqlConnection` mới chưa mở. | Dùng chung; `using` ở Data; chỉ mở kết nối, không truy vấn. |
| `DangNhap(tenDangNhap, matKhau)` | `Services/TaiKhoanService.cs`; tên đăng nhập và mật khẩu nguyên trạng; trả về `NguoiDungPhien`, ném lỗi thông báo chung nếu xác thực thất bại. | Được gọi từ `Program/VongDoiUngDung`; đọc `NguoiDung`, `VaiTro`, `NhanSu`, `HocVien`. Phiên chỉ được thiết lập sau khi hash, khóa/xóa mềm, vai trò và hồ sơ liên kết đều hợp lệ. |
| `BamMatKhau(matKhau)` | `Services/MatKhauService.cs`; tạo hash ASP.NET Identity V3 với HMAC-SHA512, 100.000 vòng, salt ngẫu nhiên 16 byte và khóa 32 byte. | Được gọi khi tạo/đổi mật khẩu; không ghi log. |
| `KiemTraMatKhau(matKhau, hash)` | `Services/MatKhauService.cs`; đọc hash Identity V3 và xác minh bằng so sánh không phụ thuộc thời gian theo nội dung. Hash sai định dạng/placeholder bị từ chối. | Đăng nhập và đổi mật khẩu; không sửa dữ liệu. Không chuyển đổi hàng loạt hash cũ. |
| `ThietLapPhien(nguoiDung)` | `Services/SessionContext.cs`; nhận DTO đã xác thực. | Nội bộ Service; không công khai setter vai trò. Phiên không chứa mật khẩu hoặc hash. |
| `XoaPhien()` | `Services/SessionContext.cs`; xóa người dùng hiện tại. | Đăng xuất; được gọi qua `TaiKhoanService.DangXuat()`. |
| `DoiMatKhau(matKhauCu, matKhauMoi)` | `Services/TaiKhoanService.cs`; xác minh phiên đang hoạt động, hash hiện tại, độ dài và khác mật khẩu cũ, sau đó cập nhật hash, `DoiMatKhauLanDau=0`, `UpdatedAt`. | Quyền `DoiMatKhau`; Form `frmDoiMatKhau`; ghi một dòng `NguoiDung`. Mật khẩu không bị `Trim()`. |
| `DangXuat()` | `Services/TaiKhoanService.cs`; không có đầu vào. | Xóa phiên; Form chính đóng thì `VongDoiUngDung` hiển thị lại một Form đăng nhập đã có. |
| `KiemTraQuyen(maChucNang)` | `Services/PhanQuyenService.cs`; đọc lại trạng thái tài khoản hiện tại và trả về `bool`. | Quyền mật khẩu cho tài khoản đã xác thực; quản lý tài khoản và `XemThongKe` chỉ dành Admin. Mã chưa biết bị từ chối. |

Vai trò được tra theo `VaiTro.TenVaiTro`, không gán ID cứng. Admin không cần hồ sơ nhân sự/học viên; nhân viên, giáo viên và học viên phải khớp hồ sơ đang hoạt động và loại hồ sơ tương ứng. `DoiMatKhauLanDau=1` yêu cầu đổi mật khẩu trước khi mở giao diện chính.

## Quản lý tài khoản

Các hàm nằm ở `Services/TaiKhoanService.cs`; truy vấn và transaction nằm trong `Data/TaiKhoanData.cs`. Tất cả hàm quản trị kiểm tra quyền Service trước khi truy vấn.

| Hàm | Đầu vào và đầu ra | Quy tắc |
| --- | --- | --- |
| `LayTaiKhoanTheoTrang(boLoc, soTrang)` | Từ khóa, vai trò, trạng thái và số trang; trả về `KetQuaPhanTrang<TaiKhoanDto>`. | Tối đa 10 tài khoản, đếm tổng ở SQL, sắp theo ID duy nhất. Không chọn cột mật khẩu/hash. |
| `LayChiTietTaiKhoan(maTaiKhoan)` | ID; trả về DTO không có bí mật hoặc `null`. | Đọc một tài khoản. |
| `LayHoSoChuaCoTaiKhoanTheoTrang(loaiHoSo, tuKhoa, soTrang, out tongBanGhi)` | Vai trò/hồ sơ, từ khóa, trang; trả tối đa 10 hồ sơ chưa liên kết. | SQL lọc hồ sơ xóa mềm, loại nhân sự và hồ sơ đã gắn tài khoản. |
| `TaoTaiKhoan(duLieu)` | Tên đăng nhập, mật khẩu, vai trò và ID hồ sơ; trả ID mới. | Tạo hash mới; transaction `Serializable`; kiểm tra trùng tên và khóa hồ sơ trước khi insert/liên kết. Chỉ cập nhật `NguoiDungID` của hồ sơ. |
| `SuaTaiKhoan(duLieu)` | ID, tên đăng nhập, vai trò. | Không cập nhật mật khẩu; không đổi hồ sơ; vai trò phải còn phù hợp với hồ sơ; không tự tước quyền Admin hoặc vô hiệu hóa Admin hoạt động cuối. |
| `DoiTrangThaiTaiKhoan(maTaiKhoan, biKhoa)` | ID và cờ khóa. | Chặn tự khóa; chặn khóa Admin hoạt động cuối; khóa/mở lại một dòng. |
| `XoaMemTaiKhoan(maTaiKhoan)` | ID. | Không xóa cứng; chặn tự xóa và xóa Admin hoạt động cuối; ghi cờ và thời gian xóa mềm. Hồ sơ vẫn giữ liên kết để tránh cấp tài khoản trùng. |

Các transaction nhạy cảm đọc lại tài khoản/vai trò. Lỗi trùng khóa từ constraint SQL vẫn được giữ lại để bắt tranh chấp xảy ra đồng thời.

## Thống kê

`Data/ThongKeData.cs` chỉ chạy `SELECT`; `Services/ThongKeService.cs` kiểm tra quyền, ngày và giới hạn kỳ; Form `frmMainAdmin` và `frmThongKe` chỉ hiển thị kết quả. Tất cả tiền dùng `decimal`; kết quả tổng rỗng được xem là 0.

| Hàm | Nguồn, đầu vào và đầu ra |
| --- | --- |
| `LayThongKeTongQuan(boLoc)` | Hiện tại: `COUNT(HocVien)` chưa xóa mềm; `COUNT(NhanSu)` có `LoaiNhanSu` là Giáo viên/Cả hai; `COUNT(LopHoc)` có trạng thái đúng `Đang học`. Trong tháng hiện tại: `COUNT(DangKy)` theo `NgayDangKy`; `SUM(ThanhToan.SoTien)` theo `NgayThanhToan`. |
| `LayThucThuTheoThang(boLoc)` | Cộng `ThanhToan.SoTien` theo tháng thanh toán; loại thanh toán/hóa đơn xóa mềm; gộp qua hóa đơn và đăng ký để lọc cơ sở. |
| `LayDangKyTheoThang(boLoc)` | Đếm `DangKy` theo `NgayDangKy`, loại đăng ký xóa mềm, nối lớp để áp bộ lọc cơ sở. |
| `LaySoLopTheoTrangThai(boLoc)` | Đếm lớp hiện tại chưa xóa mềm, nhóm theo đúng `LopHoc.TrangThai`; không đặt tên trạng thái mới. |
| `LayTinhHinhThuTheoTrang(boLoc, soTrang)` | Hóa đơn lọc theo `NgayLap`; tổng thanh toán hợp lệ đến hết ngày cuối kỳ được tổng hợp theo hóa đơn trước khi ghép. `Còn phải thu = TongPhaiTra - tổng thanh toán đến hạn báo cáo`; số âm được giữ và đánh dấu thu vượt. |
| `LayChiTietThanhToanTheoTrang(boLoc, soTrang)` | Thanh toán không xóa mềm, hóa đơn không xóa mềm, lọc `NgayThanhToan`; sắp `NgayThanhToan DESC, ThanhToanID DESC`. |
| `LayChiTietDangKyTheoTrang(boLoc, soTrang)` | Đăng ký/lớp/học viên chưa xóa mềm, lọc `NgayDangKy`; sắp ngày và ID duy nhất giảm dần. |

Ngày dùng khoảng nửa mở: `>= @TuNgay AND < @DenNgayKeTiep`, nên giao dịch ở mọi giờ trong ngày cuối được tính. Mỗi biểu đồ tối đa 12 tháng theo tháng bắt đầu/kết thúc. Lọc cơ sở đi từ lớp qua đăng ký; hóa đơn không liên kết đăng ký hiển thị `Chưa xác định` khi xem tất cả cơ sở và không được tự gán vào một cơ sở cụ thể. Hóa đơn trong kỳ, tiền thu trong kỳ và số còn phải thu là ba mốc thời gian riêng, không lấy hóa đơn trừ tiền thu cùng kỳ để suy ra nợ.

Trang chi tiết hóa đơn, thanh toán và đăng ký đều dùng `KetQuaPhanTrang<T>` với 10 dòng/trang, truy vấn đếm và `OFFSET/FETCH` tại SQL. Màn hình thống kê chỉ tải lại khi nhấn xem/đặt lại; thao tác tải chạy nền và Form bỏ kết quả đã cũ.

## Form và điểm tích hợp

- `Program/VongDoiUngDung`: đăng nhập, buộc đổi mật khẩu lần đầu, mở đúng giao diện theo vai trò, quay lại đăng nhập khi Form chính đóng và xóa phiên.
- `Forms/Shared/frmDangNhap`: xác thực đầu vào và gửi yêu cầu; mật khẩu không trim.
- `Forms/Shared/frmDoiMatKhau`: kiểm tra nhập lại, hiện/ẩn, gọi Service và hiển thị kết quả thật.
- `Forms/Admin/frmMainAdmin`: tổng quan mặc định, làm mới và thời điểm cập nhật; nút Thống kê mở Form chi tiết.
- `Forms/Admin/frmTaiKhoan`: lọc, danh sách, tạo, sửa tên/vai trò phù hợp, khóa/mở, xóa mềm.
- `Forms/Admin/frmThongKe`: bộ lọc ngày/cơ sở, biểu đồ thực thu tháng, trạng thái lớp, và ba bảng phân trang.

TV1 chưa thay đổi phần kiểm tra quyền bên trong các Form nghiệp vụ của thành viên khác. Quyền xem thống kê và quản lý tài khoản được khóa ở Service TV1; tích hợp phân quyền cho chức năng nghiệp vụ khác vẫn thuộc chủ sở hữu các Form đó.

## Xác minh

- Build: `dotnet build BTL_LTTQ_QLHTTTNN/BTL_LTTQ_QLHTTTNN.csproj --no-restore /p:GenerateResourceMSBuildArchitecture=CurrentArchitecture` — thành công, 0 lỗi. Có các cảnh báo chưa dùng event tương thích và trường Designer từ Form học viên hiện có. Xác minh offline hash ASP.NET Identity V3 mẫu trong SQL với mật khẩu mẫu `123456` trả về đúng.
- Chưa kết nối/chạy trên CSDL thật; không có thao tác ghi CSDL thật trong quá trình kiểm tra. Chưa chạy được kiểm thử dữ liệu biên 0/1/10/11/21 dòng, giao dịch sát cuối ngày, nhiều khoản thanh toán/hóa đơn hoặc xem trực tiếp WinForms Designer. Cần đối chiếu các ca này trên môi trường test có SQL Server được phép.
