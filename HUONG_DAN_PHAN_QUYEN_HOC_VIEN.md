# Phân quyền học viên – bản bổ sung cho main

Nguồn: https://github.com/blackdenxiff/BTN_LTTQ_HETHONGQUANLYTRUNGTAMNGOAINGU
Commit gốc: 0083f55777539863d9780ebe3fcb92a424630cc2 (đọc ngày 25/10/2026).
Đây là gói các file cần thay, không phải toàn bộ project. Chưa đẩy lên GitHub.

## Áp dụng
1. Sao lưu hoặc commit thay đổi hiện tại. Dùng bản main tương ứng với commit gốc ở trên. Nếu main đã thay đổi, so sánh diff trước khi chép để không mất sửa đổi của nhóm.
2. Chép thư mục BTL_LTTQ_QLHTTTNN trong gói vào thư mục repo, thay 6 file .cs tương ứng. Không cần sửa .csproj vì không thêm lớp C# mới; không thay Designer hoặc App.config.
3. Trong SSMS chạy BTL_LTTQ_QLHTTTNN/SQL/02_CapTaiKhoanHocVien.sql trên CSDL hiện có. Không chạy lại script tạo database 00. Có thể sửa @HocVienID từ NULL thành mã học viên cụ thể.
4. Đọc bảng kết quả đầu: chỉ liệt kê tài khoản vừa tạo. Tên hv_<HocVienID>, nếu trùng thì có hậu tố; mật khẩu tạm HocVien@2026. Chỉ dùng mật khẩu chung này cho dữ liệu thử nghiệm; tài khoản thực nên tạo riêng bằng màn hình Quản lý tài khoản của Admin với mật khẩu riêng.
5. Nếu bảng đầu trống, học viên đã được cấp tài khoản trước đó; xem bảng thứ hai để biết tên đăng nhập. Script không đặt lại mật khẩu tài khoản cũ và không tự gỡ liên kết nhân sự.
6. Rebuild Solution, chạy Program.cs mặc định để mở frmDangNhap. Đăng nhập tài khoản vừa tạo; đổi mật khẩu tối thiểu 8 ký tự rồi ứng dụng tự mở frmMainHocVien.
7. Đóng cửa sổ frmMainHocVien để đăng xuất và trở về frmDangNhap theo vòng đời có sẵn của nhóm.

## Quyền và luồng
- Học viên chỉ xem hồ sơ, lớp, kết quả, học phí của chính mình; tự đăng ký lớp bằng danh tính từ SessionContext.
- Không cho học viên liệt kê/thêm/sửa hồ sơ qua HocVienData. Admin và Nhân viên có hồ sơ hợp lệ được quản lý học viên.
- Kiểm tra lại trạng thái khóa/xóa, vai trò, liên kết hồ sơ và yêu cầu đổi mật khẩu khi thực hiện chức năng.
- Lưu đăng ký kiểm tra quyền sở hữu trong cùng giao dịch SQL với kiểm tra trùng/sĩ số.
- Admin bấm mục đăng ký học sẽ được nhắc đăng ký thuộc luồng học viên, thay vì mở form thiếu danh tính.
- Giữ nguyên giao diện đăng nhập và các form Designer. Dùng tên vai trò chính xác N'Học viên', không thêm vai trò N'Sinh viên'.

## Cấp một tài khoản bằng giao diện sẵn có
Đăng nhập Admin → Quản lý tài khoản → tạo tài khoản → vai trò Học viên → chọn đúng hồ sơ học viên chưa có tài khoản → nhập tên đăng nhập và mật khẩu ít nhất 8 ký tự → lưu.
Hệ thống có sẵn MatKhauService để băm mật khẩu. Không ghi '1', '2', '3' hoặc mật khẩu thuần vào MatKhauHash.

## Kiểm tra trên máy Windows/SQL Server
- Học viên A đăng nhập: chỉ thấy hồ sơ, lớp, học phí của A; đăng xuất rồi B đăng nhập: chỉ thấy B.
- Tạo frmMainHocVien hoặc frmDangKyHoc với NguoiDungID của B trong phiên A: bị từ chối.
- Gọi Students/SaveStudent bằng phiên học viên: bị từ chối; gọi Fees/Enrollments với HocVienID khác: bị từ chối.
- Khóa tài khoản bằng Admin khi học viên đang mở đăng ký, sau đó lưu: bị từ chối.
- Vai trò bị đổi, hồ sơ bị gỡ/xóa hoặc tài khoản bị gắn đồng thời nhân sự: bị từ chối khi kiểm tra lại.
- Đăng ký đúng lớp còn chỗ: thành công. Đăng ký trùng, lớp đầy: bị từ chối.
- Admin/Nhân viên hợp lệ vẫn mở danh sách và lưu hồ sơ; các chức năng quản lý tài khoản của Admin vẫn hoạt động.
- Chạy lại SQL cấp tài khoản: không nhân đôi tài khoản và không đổi mật khẩu hiện tại.

## Phạm vi xác minh và giới hạn
Đã kiểm tra cú pháp 6 file C# bằng tree-sitter, git diff --check, hash Identity V3 với mật khẩu đúng/sai và cấu trúc gói. Chưa build/chạy WinForms hoặc thực thi SQL vì môi trường tạo gói không có .NET Framework/SQL Server.
Đây là phân quyền ở tầng ứng dụng WinForms, không phải SQL GRANT/REVOKE hoặc bảo vệ khỏi người có quyền truy cập SQL trực tiếp. Các module khác ngoài học viên chưa được rà soát toàn diện. Dữ liệu đã hiển thị trên màn hình không tự biến mất ngay khi Admin khóa tài khoản; thao tác tiếp theo sẽ kiểm tra lại.
