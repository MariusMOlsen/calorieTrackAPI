USE SQLEXPRESS02;
GO

DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR

SET @Cursor = CURSOR FAST_FORWARD FOR
SELECT DISTINCT sql = 'DROP TABLE [' + tc2.TABLE_SCHEMA + '].[' +  tc2.TABLE_NAME + ']'
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc1
LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.TABLE_NAME = tc1.TABLE_NAME
WHERE tc1.TABLE_NAME > tc2.TABLE_NAME
UNION 
SELECT DISTINCT sql = 'DROP TABLE [' + TABLE_SCHEMA + '].[' +  TABLE_NAME + ']'
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS

OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql

WHILE (@@FETCH_STATUS = 0)
BEGIN
    Exec sp_executesql @Sql
    FETCH NEXT FROM @Cursor INTO @Sql
END

CLOSE @Cursor DEALLOCATE @Cursor