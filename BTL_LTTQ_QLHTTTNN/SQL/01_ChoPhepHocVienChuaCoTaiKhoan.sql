-- Run once against the EXISTING database. No tables/data are deleted.
USE QLTrungTamTiengAnh;
GO
SET XACT_ABORT ON;
BEGIN TRANSACTION;
DECLARE @constraint sysname;
SELECT @constraint=kc.name
FROM sys.key_constraints kc
JOIN sys.index_columns ic ON ic.object_id=kc.parent_object_id AND ic.index_id=kc.unique_index_id
JOIN sys.columns c ON c.object_id=ic.object_id AND c.column_id=ic.column_id
WHERE kc.parent_object_id=OBJECT_ID(N'dbo.HocVien') AND kc.type='UQ'
AND c.name=N'NguoiDungID'
AND (SELECT COUNT(*) FROM sys.index_columns x WHERE x.object_id=kc.parent_object_id
AND x.index_id=kc.unique_index_id AND x.key_ordinal>0)=1;
IF @constraint IS NOT NULL
    EXEC(N'ALTER TABLE dbo.HocVien DROP CONSTRAINT '+QUOTENAME(@constraint));
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE object_id=OBJECT_ID(N'dbo.HocVien') AND name=N'UX_HocVien_NguoiDungID_NotNull')
    CREATE UNIQUE INDEX UX_HocVien_NguoiDungID_NotNull
    ON dbo.HocVien(NguoiDungID) WHERE NguoiDungID IS NOT NULL;
COMMIT;
GO
