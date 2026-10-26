# Báo cáo tích hợp `sang`, `hai`, `nghia`, `duong`

## Phiên bản và cách tích hợp

| Ref | Commit ghi nhận |
|---|---|
| `main` và `origin/main` | `ed938fdb0f2f0e6d5db88d18946acb8241b20896` |
| `origin/sang` | `3c08e14d60d1843747e00da3d0e49202b6284db0` |
| `origin/hai` | `0965510c209dc0e595ade8ce7d623bbe7713ae9d` |
| `origin/nghia` | `675f1e4910565ab795f31084b9719582c3f4ff22` |
| `origin/duong` | `96e5ae92f12b12148c8016ea9a744e86629ddd21` |
| Nhánh tích hợp | `codex/merge-sang-hai-nghia-duong`, tạo từ `main` ghi nhận ở trên |

Các commit tích hợp lần lượt là `sang` (`4fb4b6c`), `hai` (`9cdc42a`), `nghia` (`3bcee53`), `duong` (`fca832e`), tiếp theo là cập nhật báo cáo và sửa phát hiện ở kiểm thử. `sang` đã nằm trong lịch sử `main`, không có commit chức năng mới; đã rà lại và sửa binding cột/nút khóa học, đồng thời ngăn xóa khóa học còn lớp.

## Bảng chức năng

| Chức năng | Nhánh | File chính | Trạng thái ở main | Cách tích hợp | Kiểm tra |
|---|---|---|---|---|---|
| Khóa học: hiển thị/sửa/xóa nhất quán | `sang` | `Forms/frmKhoaHoc.cs` | Đã có phần lớn | Giữ cấu trúc main; sửa cột DataGridView và chặn xóa khóa học đang có lớp | Build Debug/Release; kiểm tra hồi quy form |
| Hồ sơ học viên, phân quyền, phân trang, đăng ký lớp | `hai` | `Data/HocVienData.cs`, `Services/PhanQuyenService.cs`, `Forms/frmHocVien.cs`, `Forms/frmDangKyHoc.cs`, `Program.cs` | Thiếu/không đồng nhất | Ghép ownership check theo phiên, quyền Admin/Học viên, phân trang và đăng ký; loại lớp `PhanQuyenService` trùng ở thư mục gốc | Build Debug/Release; kiểm thử UI học viên, kiểm tra đăng ký trùng và đăng ký mới |
| Cấp tài khoản học viên và quan hệ dữ liệu | `hai` | `SQL/01_ChoPhepHocVienChuaCoTaiKhoan.sql`, `SQL/02_CapTaiKhoanHocVien.sql` | Thiếu luồng nâng cấp đầy đủ | Migration 01 rồi 02, transaction, chỉ tạo cho học viên chưa có tài khoản, xử lý tên đăng nhập trùng, không đổi tài khoản sẵn có | Đã chạy trên LocalDB test; đã kiểm tra tài khoản cũ và đuôi tên đăng nhập khi trùng |
| Học phí, phiếu thu, lịch sử và màn hình học viên | `nghia` | `Data/HocPhiData.cs`, `Services/HocPhiService.cs`, `Services/PhieuThuService.cs`, `Forms/frmHocPhi.cs`, `Forms/frmLapPhieuThu.cs`, `Forms/frmMainHocVien.cs` | Chưa có bộ tính/thu hoàn chỉnh | Ghép vào tab học phí main, giữ quyền/phân trang/đăng ký của `hai`; giao dịch thu dùng Serializable và kiểm tra số dư trong transaction; sửa dòng đăng ký chưa có hóa đơn để tính khoản còn phải thu | UI LocalDB: tổng nợ sau đăng ký, lập phiếu thu 1.000.000đ, mã phiếu và tổng đã thu được cập nhật |
| Cấp tài khoản hàng loạt, xác nhận và thực thi | `duong` | `Forms/frmCapTaiKhoanHangLoat.cs`, `Forms/frmCapTaiKhoanHangLoat.Designer.cs` | Form có sẵn nhưng thao tác chưa hoàn chỉnh | Giữ form riêng; bổ sung xác nhận, commit checkbox, khóa điều khiển khi chạy, tiến độ/kết quả; giữ nguyên Designer main của `frmMainAdmin` | Build Debug/Release và rà event; chưa chạy UI/DB end-to-end |

## Giải quyết xung đột và rà soát

- Ghép thủ công `frmMainHocVien.cs`: giữ bố cục main, tab/menu cùng đăng ký, phân quyền và phân trang của `hai`; thêm lịch học trong tab/menu main và chức năng học phí của `nghia`. Thứ tự menu đã được kiểm tra bằng giao diện.
- Đồng bộ các cặp `.cs`, `.Designer.cs`, `.resx`; rà tên control, constructor và event. `.csproj` chỉ khai báo một bản mỗi lớp; file `PhanQuyenService.cs` trùng ở thư mục gốc không được biên dịch.
- Giữ `frmMainAdmin.Designer.cs` của main vì bản nguồn làm control vượt vùng nội dung; sửa cấp tài khoản hàng loạt trong form riêng. Không mang `.vs`, `bin`, `obj` hay worktree lồng từ nhánh nguồn vào commit.
- Nhánh gốc `duong` và các thay đổi cá nhân trong worktree đó được giữ nguyên. Không push.

## Kiểm thử

- Bản main nền: Debug build thành công, 0 lỗi và 21 cảnh báo.
- Bản tích hợp: Debug và Release build đều thành công, 0 lỗi; 21 cảnh báo C# về field/event chưa dùng, cùng nhóm đã thấy ở baseline.
- LocalDB thử nghiệm: chạy schema gốc trên instance riêng; hai migration chạy được và chạy lại; kiểm tra giữ `hv_demo`, xử lý username bị chiếm (`hv_2_1`) và liên kết vai trò/học viên.
- UI học viên trên tài khoản test: thông tin hồ sơ, danh sách lớp, phân trang, lịch học, học phí và menu giữ được; đăng ký trùng bị chặn; đăng ký `QA-ENROLL-01` thành công và sĩ số tăng 0→1.
- Luồng phí trên LocalDB: đăng ký chưa có hóa đơn vẫn hiện phải thu 4.500.000đ; lập phiếu thu thử một phần 1.000.000đ trả mã `PT-2`; màn hình sau đó hiện đã thu 1.000.000đ, còn nợ 3.500.000đ, tổng đã thu 3.000.000đ. Đây là dữ liệu LocalDB thử nghiệm, không phải khoản thu thực.
- Sau khi đóng UI, LocalDB báo lỗi truy cập cấu hình registry nên không kết nối lại để truy vấn kiểm chứng độc lập dữ liệu lịch sử. Giao diện đã xác nhận cập nhật sau khi lưu; kiểm tra truy vấn SQL độc lập còn thiếu.

## Việc chưa đạt và trạng thái main

Chưa chạy đầy đủ các ca đăng nhập cho từng vai trò, quyền ngoài phạm vi, đổi mật khẩu/đăng xuất, xóa/sửa học viên, cấp tài khoản hàng loạt trên UI, dữ liệu thiếu/sai định dạng và lỗi giữa chừng, chống thu trùng/cạnh tranh, báo cáo/Excel, các màn hình đào tạo còn lại, mất kết nối và luồng liên thông trên nhiều vai trò. Vì thế chưa thể kết luận checklist toàn hệ thống đã đạt.

Worktree `main` cũ được Git ghi nhận tại `C:\Users\admin\Desktop\BTN_LTTQ_HETHONGQUANLYTRUNGTAMNGU` không tồn tại. Theo điều kiện hoàn tất, nhánh tích hợp vẫn được giữ riêng; chưa cập nhật `main` khi còn kiểm thử bắt buộc chưa đạt/chưa chạy. Cần chạy tiếp các ca còn thiếu trên môi trường test phù hợp, rồi kiểm tra `main` có commit mới trước fast-forward. Không có thay đổi cá nhân ở worktree gốc bị ghi đè.
