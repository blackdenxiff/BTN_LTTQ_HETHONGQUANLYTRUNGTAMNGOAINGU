-- Run after 01_ChoPhepHocVienChuaCoTaiKhoan.sql and 02_CapTaiKhoanHocVien.sql.
-- Additive and safe for existing payment rows: old rows keep RequestId = NULL.
USE QLTrungTamTiengAnh;
GO
SET NOCOUNT ON;
SET XACT_ABORT ON;
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;

IF OBJECT_ID(N'dbo.ThanhToan', N'U') IS NULL
    THROW 50010, N'Không tìm thấy bảng dbo.ThanhToan. Hãy tạo schema gốc trước.', 1;
GO

BEGIN TRY
    BEGIN TRANSACTION;

    IF COL_LENGTH(N'dbo.ThanhToan', N'RequestId') IS NULL
        ALTER TABLE dbo.ThanhToan ADD RequestId UNIQUEIDENTIFIER NULL;

    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.indexes
        WHERE object_id = OBJECT_ID(N'dbo.ThanhToan')
          AND name = N'UX_ThanhToan_RequestId'
    )
        EXEC(N'CREATE UNIQUE INDEX UX_ThanhToan_RequestId
            ON dbo.ThanhToan(RequestId)
            WHERE RequestId IS NOT NULL;');

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO
