# Báo cáo tích hợp `sang`, `hai`, `nghia`, `duong`

## Phiên bản

| Ref | Commit ghi nhận |
|---|---|
| `main` và `origin/main` | `ed938fdb0f2f0e6d5db88d18946acb8241b20896` |
| `origin/sang` | `3c08e14d60d1843747e00da3d0e49202b6284db0` |
| `origin/hai` | `0965510c209dc0e595ade8ce7d623bbe7713ae9d` |
| `origin/nghia` | `675f1e4910565ab795f31084b9719582c3f4ff22` |
| `origin/duong` | `96e5ae92f12b12148c8016ea9a744e86629ddd21` |
| Nhánh tích hợp | `codex/merge-sang-hai-nghia-duong`, HEAD `fca832ee56e26b0a994138b7d06e27fe7ab3518b` |

Nhánh `sang` không mang thêm thay đổi chức năng cần áp dụng ngoài phần đã có; đã kiểm tra hồi quy và sửa liên kết cột/nút cùng chặn xóa khóa học còn lớp. Các thay đổi commit trên nhánh tích hợp theo thứ tự: `sang` (`4fb4b6c`), `hai` (`9cdc42a`), `nghia` (`3bcee53`), `duong` (`fca832e`).

## Bảng chức năng

| Chức năng | Nhánh | File chính | Trạng thái ở main | Cách tích hợp | Kiểm tra |
|---|---|---|---|---|---|
| Khóa học: hiển thị/sửa/xóa nhất quán | `sang` | `Forms/frmKhoaHoc.cs` | Đã có phần lớn | Giữ cấu trúc main; sửa cột DataGridView và chặn xóa khóa học đang có lớp | Debug build; rà logic màn hình |
| Học viên, phân trang, quyền và đăng ký học | `hai` | `Data/HocVienData.cs`, `Services/PhanQuyenService.cs`, `Forms/frmHocVien.cs`, `Forms/frmDangKyHoc.cs`, `Program.cs` | Thiếu/không đồng nhất | Kết hợp ownership check theo phiên, quyền Admin/Học viên, phân trang và giữ luồng đăng ký; xóa bản `PhanQuyenService.cs` trùng ở thư mục gốc | Debug/Release build; rà event và kiểm tra quyền tại Data/Service |
| Cấp tài khoản học viên | `hai` | `SQL/02_CapTaiKhoanHocVien.sql`, `SQL/01_ChoPhepHocVienChuaCoTaiKhoan.sql` | Chưa có luồng nâng cấp đầy đủ | Dùng migration theo thứ tự 01 rồi 02; cấp cho hồ sơ chưa liên kết và tránh ghi đè tài khoản hiện có | Đối chiếu truy vấn/schema bằng đọc mã; chưa chạy DB thử |
| Học phí, phiếu thu, lịch sử và màn hình học viên | `nghia` | `Data/HocPhiData.cs`, `Services/HocPhiService.cs`, `Services/PhieuThuService.cs`, `Forms/frmHocPhi.cs`, `Forms/frmLapPhieuThu.cs`, `Forms/frmMainHocVien.cs` | Chưa có bộ tính/thu hoàn chỉnh | Thêm data/service/model và màn hình; ghép vào tab học phí main, giữ menu, phân trang, quyền và đăng ký từ `hai`; thu tiền dùng transaction Serializable, khóa đăng ký/hóa đơn và kiểm tra số dư trong transaction | Debug/Release build; rà transaction và truy vấn; chưa chạy DB/UI |
| Cấp tài khoản hàng loạt, xác nhận và thực thi | `duong` | `Forms/frmCapTaiKhoanHangLoat.cs`, `Forms/frmCapTaiKhoanHangLoat.Designer.cs` | Form có sẵn nhưng thao tác chưa hoàn chỉnh | Giữ form riêng, bổ sung xác nhận, commit checkbox trước khi chạy, khóa điều khiển trong lúc xử lý, tiến độ và kết quả từng hồ sơ; giữ `frmMainAdmin.Designer.cs` của main | Debug/Release build; kiểm tra event/nút; chưa chạy DB/UI |

## Giải quyết xung đột và rà soát

- `frmMainHocVien.cs` được ghép thủ công: giữ tab/menu, đăng ký, quyền/phân trang của `hai`; thêm lịch học trong tab main và phần học phí/phiếu thu của `nghia`.
- `.csproj` khai báo mỗi lớp mới một lần; file `PhanQuyenService` trùng ở thư mục gốc bị loại khỏi project. Các file `.cs`, `.Designer.cs` và resource đi kèm của phiếu thu được giữ đồng bộ.
- `frmMainAdmin.Designer.cs` được giữ nguyên theo main vì bản ghép tự động làm tọa độ điều khiển vượt khỏi vùng nội dung. Gitlink `_integration_duong_sang` và file `.vs`, `bin`, `obj` từ nhánh nguồn không nằm trong commit tích hợp; thư mục worktree lồng không bị xóa.
- Không còn conflict marker hoặc mục unmerged; `git diff --check HEAD` sạch và worktree tích hợp sạch.

## Kiểm tra và giới hạn

- Baseline main: Debug build thành công, 0 lỗi, 21 cảnh báo có sẵn.
- Sau tích hợp cuối: Debug build thành công, 0 lỗi; Release build thành công, 0 lỗi. Cả hai có 21 cảnh báo về event/field chưa dùng, cùng nhóm với baseline.
- Chưa kiểm thử tương tác UI, đăng nhập theo từng vai trò, luồng liên thông, báo cáo/Excel, dữ liệu biên, mất kết nối, hoặc cạnh tranh phiếu thu bằng ứng dụng đang chạy.
- Có `sqlcmd` nhưng chưa xác nhận được SQL Server/database thử nghiệm; migration 01/02 và các nghiệp vụ tài khoản/học phí chưa được chạy trên bản sao dữ liệu. Không chạy script trên dữ liệu thật.
- Do database/runtime test chưa sẵn sàng, chưa thể tuyên bố toàn bộ checklist chức năng đã đạt.
- `main`/`origin/main` đang ở commit đã ghi nhận khi chuẩn bị tích hợp. Worktree `main` được Git ghi nhận tại `C:\Users\admin\Desktop\BTN_LTTQ_HETHONGQUANLYTRUNGTAMNGU` hiện không tồn tại. Vì vậy kết quả được giữ trên nhánh tích hợp; không cập nhật `main` và không push. Worktree `duong` cùng các thay đổi cá nhân của người dùng không bị sửa.
