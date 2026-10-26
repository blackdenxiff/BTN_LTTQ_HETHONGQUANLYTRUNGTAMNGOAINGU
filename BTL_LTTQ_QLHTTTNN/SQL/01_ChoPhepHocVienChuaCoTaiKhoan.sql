-- Run once against the EXISTING database. No tables/data are deleted.
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;
USE QLTrungTamTiengAnh;
GO
SET NOCOUNT ON;
SET XACT_ABORT ON;
IF OBJECT_ID(N'dbo.HocVien', N'U') IS NULL OR COL_LENGTH(N'dbo.HocVien', N'NguoiDungID') IS NULL
    THROW 50010, N'dbo.HocVien or NguoiDungID is missing; run the base schema migration first.', 1;
BEGIN TRY
    BEGIN TRANSACTION;
    DECLARE @constraint sysname, @sql nvarchar(max);
    SELECT @constraint=kc.name
    FROM sys.key_constraints kc
    JOIN sys.index_columns ic ON ic.object_id=kc.parent_object_id AND ic.index_id=kc.unique_index_id
    JOIN sys.columns c ON c.object_id=ic.object_id AND c.column_id=ic.column_id
    WHERE kc.parent_object_id=OBJECT_ID(N'dbo.HocVien') AND kc.type='UQ'
    AND c.name=N'NguoiDungID'
    AND (SELECT COUNT(*) FROM sys.index_columns x WHERE x.object_id=kc.parent_object_id
    AND x.index_id=kc.unique_index_id AND x.key_ordinal>0)=1;
    IF @constraint IS NOT NULL
    BEGIN
        SET @sql=N'ALTER TABLE dbo.HocVien DROP CONSTRAINT '+QUOTENAME(@constraint)+N';';
        EXEC sys.sp_executesql @sql;
    END;
    IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE object_id=OBJECT_ID(N'dbo.HocVien') AND name=N'UX_HocVien_NguoiDungID_NotNull')
        CREATE UNIQUE INDEX UX_HocVien_NguoiDungID_NotNull
        ON dbo.HocVien(NguoiDungID) WHERE NguoiDungID IS NOT NULL;
    COMMIT;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT>0 ROLLBACK;
    THROW;
END CATCH;
GO
