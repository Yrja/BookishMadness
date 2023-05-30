CREATE TABLE [dbo].[AuditTable]
(
    ChangeType CHAR(1),
    ChangedDate DATETIME,
    BookId UNIQUEIDENTIFIER,
    BookName NVARCHAR(200)
)
