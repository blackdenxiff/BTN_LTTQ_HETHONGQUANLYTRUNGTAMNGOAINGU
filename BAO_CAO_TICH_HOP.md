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
| Cấp tài khoản hàng loạt, xác nhận và thực thi | `duong` | `Forms/frmCapTaiKhoanHangLoat.cs`, `Forms/frmCapTaiKhoanHangLoat.Designer.cs` | Form có sẵn nhưng thao tác chưa hoàn chỉnh | Giữ form riêng; bổ sung xác nhận, commit checkbox, khóa điều khiển khi chạy, tiến độ/kết quả; giữ nguyên Designer main của `frmMainAdmin` | UI/LocalDB: chọn một hồ sơ test, xác nhận thực thi, nhận kết quả 1 thành công/0 bỏ qua/0 lỗi; tài khoản được liên kết và buộc đổi mật khẩu |

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
- Sau khi khởi động lại LocalDB với quyền truy cập phù hợp, truy vấn độc lập xác nhận hóa đơn `2` cho lớp test có tổng 4.500.000đ, một dòng thanh toán 1.000.000đ và còn nợ 3.500.000đ. Migration 01/02 chạy lại; migration cấp tài khoản không tạo trùng và danh sách liên kết hiện có vẫn hợp lệ.
- Ma trận đăng nhập/quyền qua service: `admin_demo` đăng nhập Admin thành công (hồ sơ được liên kết nhân sự theo dữ liệu seed); `gv_demo`, `hv_demo` và tài khoản test hàng loạt `3` đăng nhập đúng vai trò; học viên thường có quyền hồ sơ/học phí cá nhân nhưng bị chặn quản lý tài khoản; Admin có quyền quản lý tài khoản; giáo viên bị chặn quyền Admin; tài khoản mới bị buộc đổi mật khẩu nên quyền nghiệp vụ bị khóa; đăng xuất xóa session. Tài khoản test `3` dùng mật khẩu mặc định `02012000`.
- Đổi mật khẩu qua service bằng tài khoản `3`: đổi mật khẩu tạm, xác thực lại bằng mật khẩu mới, đổi về mật khẩu mặc định ban đầu, đăng xuất; khôi phục cờ buộc đổi lần đầu trong LocalDB để giữ trạng thái tài khoản test ban đầu. Chưa kiểm tra thao tác nhập liệu/dialog đổi mật khẩu qua UI.
- Phát hiện và sửa lỗi đăng nhập Admin: seed `admin_demo` liên kết với hồ sơ nhân sự (`LoaiNhanSu=Cả hai`), nhưng xác thực cũ yêu cầu Admin không có liên kết nhân sự. Điều chỉnh bất biến hồ sơ để Admin được liên kết nhân sự nhưng vẫn không được liên kết học viên; sau sửa, đăng nhập và màn hình tổng quan/quản lý tài khoản Admin tải thành công.
- Cấp tài khoản hàng loạt đã kiểm tra trên UI: ban đầu không có hồ sơ đủ điều kiện; thêm một học viên test chưa có tài khoản trong LocalDB; tìm kiếm, chọn checkbox, xác nhận; giao diện báo `Thành công: 1; bỏ qua: 0; thất bại: 0`; sau đó hồ sơ biến khỏi danh sách đủ điều kiện. Truy vấn xác nhận tài khoản role Học viên liên kết đúng hồ sơ và `DoiMatKhauLanDau=1`.
- Kiểm tra UI Admin: trang học viên tìm kiếm đúng `Bulk QA 2026`; tạo hồ sơ QA rồi sửa tên thành công; dữ liệu giả đã được dọn khỏi LocalDB bằng truy vấn giới hạn chính xác một hàng. Tạo 12 hồ sơ tạm khác để kiểm tra phân trang: trang 1/2 có 10 dòng, nút “Sau” đưa tới trang 2/2 còn 5 dòng; toàn bộ 12 hàng được dọn bằng giao dịch có điều kiện và xác nhận còn 0.
- Kiểm tra thêm màn hình Admin: tổng quan; báo cáo chi tiết; danh sách hóa đơn/lịch sử thanh toán/đăng ký; khóa học/lớp, lịch học, hồ sơ giáo viên, điểm danh, nhập điểm, học phí và lập phiếu thu đều mở được. Xuất Excel báo cáo chi tiết thành công; các sheet tổng hợp, hóa đơn, thanh toán và đăng ký khớp số liệu LocalDB (phải thu 8.500.000đ, đã thu 3.000.000đ, còn 5.500.000đ). Với phiếu thu chưa chọn học viên, UI từng báo sai “đã thanh toán đủ”; đã sửa thứ tự kiểm tra để yêu cầu chọn học viên/lớp trước và xác nhận UI hiện đúng thông báo yêu cầu chọn học viên.
- Các build Debug/Release sau sửa kiểm tra đầu vào phiếu thu: 0 lỗi; bản QA runner cũng build thành công sau khi đóng tiến trình đang giữ file.
- Kiểm thử service cấp tài khoản theo batch với ba dòng: DTO rỗng (thất bại), học viên test hợp lệ (thành công), rồi cùng hồ sơ đó lần nữa (bỏ qua do đã liên kết). Kết quả `thành công: 1; bỏ qua: 1; thất bại: 1`; callback tiến độ chạy đủ 3/3, batch không dừng tại dòng lỗi. Hồ sơ và tài khoản tạm được dọn bằng giao dịch có kiểm tra đúng ID/tên.
- Kiểm thử service thu quá số dư trên hóa đơn QA: yêu cầu 4.000.000đ trong khi còn nợ 3.500.000đ bị từ chối; truy vấn sau đó vẫn có đúng 1 giao dịch thanh toán, tổng đã thu 1.000.000đ.
- Kiểm tra UI với email `bad-email`: form hiển thị “Email không hợp lệ.” và không lưu hồ sơ.
- Bổ sung xóa mềm học viên qua menu ngữ cảnh của lưới, không đổi bố cục chính; chỉ xóa hồ sơ chưa có tài khoản, đăng ký hoặc hóa đơn, trong transaction Serializable. UI Admin đã mở được menu “Xóa hồ sơ học viên”; service test xác nhận học viên thường bị chặn, hồ sơ có tài khoản được bảo vệ, hồ sơ QA trống chuyển `IsDeleted=1`. Hàng QA được dọn sau khi xác nhận trạng thái.

## Việc chưa đạt và trạng thái main

Chưa chạy đổi mật khẩu end-to-end qua UI; chưa bấm xác nhận xóa mềm qua giao diện (service đã được kiểm thử); chưa chạy cấp tài khoản hàng loạt bằng UI với lỗi xen giữa/trùng hồ sơ; chưa mô phỏng mất kết nối database hoặc kiểm tra mọi trường sai định dạng ngoài email; ghi nhận thanh toán lặp/cạnh tranh; xuất Excel mọi loại báo cáo; thao tác tạo/sửa lịch học, điểm danh và nhập điểm; toàn bộ luồng liên thông qua nhiều vai trò. Chưa có vai trò Nhân viên riêng trong dữ liệu test để kiểm tra đăng nhập. Vì thế chưa thể kết luận checklist toàn hệ thống đã đạt.

Worktree `main` cũ được Git ghi nhận tại `C:\Users\admin\Desktop\BTN_LTTQ_HETHONGQUANLYTRUNGTAMNGU` không tồn tại. Theo điều kiện hoàn tất, nhánh tích hợp vẫn được giữ riêng; chưa cập nhật `main` khi còn kiểm thử bắt buộc chưa đạt/chưa chạy. Cần chạy tiếp các ca còn thiếu trên môi trường test phù hợp, rồi kiểm tra `main` có commit mới trước fast-forward. Không có thay đổi cá nhân ở worktree gốc bị ghi đè.
