IF EXISTS(SELECT * FROM sys.columns 
          WHERE Name = N'Author'
          AND Object_ID = Object_ID(N'dbo.Books'))

          BEGIN
             ALTER TABLE [dbo].[Books]
             DROP COLUMN Author
          END
