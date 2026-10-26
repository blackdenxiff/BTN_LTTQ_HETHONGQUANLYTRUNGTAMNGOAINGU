SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;
-- Chạy trong SSMS trên database đang dùng. Không chạy lại 00_TaoDatabase_BanGoc.sql.
-- Chỉ tạo cho học viên chưa có tài khoản; không đổi mật khẩu hay quyền tài khoản cũ.
-- Tài khoản mới: hv_<HocVienID>; mật khẩu tạm: HocVien@2026.
-- Bắt buộc đổi mật khẩu ở lần đăng nhập đầu bằng form sẵn có của nhóm.
USE QLTrungTamTiengAnh;
GO
SET NOCOUNT ON;
SET XACT_ABORT ON;
-- NULL: tất cả học viên chưa có tài khoản. Điền một HocVienID để chỉ cấp cho người đó.
DECLARE @HocVienID INT = NULL;
DECLARE @Created TABLE(HocVienID INT, HoTen NVARCHAR(100), TenDangNhap VARCHAR(50));
BEGIN TRY
    BEGIN TRANSACTION;
    DECLARE @Role INT;
    SELECT @Role=VaiTroID FROM dbo.VaiTro WITH(UPDLOCK,HOLDLOCK)
    WHERE TenVaiTro=N'Học viên' AND IsDeleted=0;
    IF @Role IS NULL THROW 50001,N'Không có vai trò Học viên đang hoạt động. Kiểm tra dữ liệu VaiTro.',1;
    IF @HocVienID IS NOT NULL AND NOT EXISTS(SELECT 1 FROM dbo.HocVien WHERE HocVienID=@HocVienID AND IsDeleted=0)
        THROW 50002,N'Không tìm thấy học viên được chọn.',1;
    DECLARE @Pending TABLE(HocVienID INT PRIMARY KEY, HoTen NVARCHAR(100));
    INSERT @Pending SELECT HocVienID,HoTen FROM dbo.HocVien WITH(UPDLOCK,HOLDLOCK)
    WHERE IsDeleted=0 AND NguoiDungID IS NULL AND (@HocVienID IS NULL OR HocVienID=@HocVienID);
    DECLARE @Id INT, @Name NVARCHAR(100), @Login VARCHAR(50), @NewUser INT, @Suffix INT;
    WHILE EXISTS(SELECT 1 FROM @Pending)
    BEGIN
        SELECT TOP(1) @Id=HocVienID,@Name=HoTen FROM @Pending ORDER BY HocVienID;
        SET @Login='hv_'+CONVERT(VARCHAR(11),@Id);
        SET @Suffix=0;
        WHILE EXISTS(SELECT 1 FROM dbo.NguoiDung WITH(UPDLOCK,HOLDLOCK) WHERE TenDangNhap=@Login)
        BEGIN
            SET @Suffix=@Suffix+1;
            SET @Login='hv_'+CONVERT(VARCHAR(11),@Id)+'_'+CONVERT(VARCHAR(11),@Suffix);
        END;
        INSERT dbo.NguoiDung(TenDangNhap,MatKhauHash,VaiTroID,TrangThai,IsDeleted,DoiMatKhauLanDau)
        VALUES(@Login,N'AQAAAAIAAYagAAAAEHDsNvlLmhdnuFCK8bkGYoTXQzsSkhjf+jdULMJTSTybVBf10I6dd9GzqLbv1EP5hg==',@Role,1,0,1);
        SET @NewUser=CONVERT(INT,SCOPE_IDENTITY());
        UPDATE dbo.HocVien SET NguoiDungID=@NewUser,UpdatedAt=GETDATE()
        WHERE HocVienID=@Id AND NguoiDungID IS NULL AND IsDeleted=0;
        IF @@ROWCOUNT<>1 THROW 50003,N'Hồ sơ vừa thay đổi. Đã hủy cấp tài khoản.',1;
        INSERT @Created VALUES(@Id,@Name,@Login);
        DELETE @Pending WHERE HocVienID=@Id;
    END;
    COMMIT;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT>0 ROLLBACK;
    THROW;
END CATCH;
SELECT *,N'HocVien@2026' AS MatKhauTam,N'Đổi mật khẩu ngay lần đăng nhập đầu' AS GhiChu FROM @Created;
-- Danh sách liên kết hiện tại; không tiết lộ mật khẩu tài khoản cũ.
SELECT h.HocVienID,h.HoTen,n.TenDangNhap,v.TenVaiTro,n.TrangThai,n.DoiMatKhauLanDau,
CASE WHEN n.IsDeleted=0 AND n.TrangThai=1 AND v.IsDeleted=0 AND v.TenVaiTro=N'Học viên'
AND NOT EXISTS(SELECT 1 FROM dbo.NhanSu ns WHERE ns.NguoiDungID=n.NguoiDungID AND ns.IsDeleted=0)
THEN N'Liên kết hợp lệ' ELSE N'Cần quản trị viên kiểm tra liên kết/quyền' END AS KiemTra
FROM dbo.HocVien h LEFT JOIN dbo.NguoiDung n ON n.NguoiDungID=h.NguoiDungID
LEFT JOIN dbo.VaiTro v ON v.VaiTroID=n.VaiTroID
WHERE h.IsDeleted=0 AND (@HocVienID IS NULL OR h.HocVienID=@HocVienID)
ORDER BY h.HocVienID;
