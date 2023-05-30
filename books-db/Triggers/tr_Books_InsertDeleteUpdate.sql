CREATE TRIGGER [tr_Books_InsertDeleteUpdate]
	ON [dbo].[Books]
	FOR DELETE, INSERT, UPDATE
	AS
	BEGIN
		SET NOCOUNT ON

		IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
		BEGIN
		INSERT INTO AuditTable (ChangeType, ChangedDate, BookId, BookName)
			SELECT 'I', GETDATE(), Id, Name
			FROM inserted
		END;

		IF EXISTS (SELECT * FROM deleted) AND NOT EXISTS (SELECT * FROM inserted)
		BEGIN
			INSERT INTO AuditTable(ChangeType, ChangedDate, BookId, BookName)
			SELECT 'D', GETDATE(), Id, Name
			FROM deleted
		END;
		
		IF EXISTS (SELECT * FROM inserted INNER JOIN deleted ON inserted.Id = deleted.Id)
		BEGIN
			INSERT INTO AuditTable (ChangeType, ChangedDate, BookId, BookName)
			SELECT 'U', GETDATE(), inserted.Id, inserted.Name
			FROM inserted
			INNER JOIN deleted ON inserted.Id = deleted.Id
		END;
	END
