-- Authors' ids
DECLARE @SGId UNIQUEIDENTIFIER = NEWID()
DECLARE @RKId UNIQUEIDENTIFIER = NEWID()
DECLARE @BSId UNIQUEIDENTIFIER = NEWID()

--Genres' ids
DECLARE @FantsyId UNIQUEIDENTIFIER = NEWID()
DECLARE @RomanceId UNIQUEIDENTIFIER = NEWID()
DECLARE @YoungAdultId UNIQUEIDENTIFIER = NEWID()
DECLARE @CommedyId UNIQUEIDENTIFIER = NEWID()

--Books' ids
DECLARE @GildId UNIQUEIDENTIFIER = NEWID()
DECLARE @GlintId UNIQUEIDENTIFIER = NEWID()
DECLARE @CaravalId UNIQUEIDENTIFIER = NEWID()
DECLARE @LegendaryId UNIQUEIDENTIFIER = NEWID()
DECLARE @MistbornId UNIQUEIDENTIFIER = NEWID()

--Reactions' ids
DECLARE @Reaction1 UNIQUEIDENTIFIER = NEWID()
DECLARE @Reaction2 UNIQUEIDENTIFIER = NEWID()
DECLARE @Reaction3 UNIQUEIDENTIFIER = NEWID()
DECLARE @Reaction4 UNIQUEIDENTIFIER = NEWID()
DECLARE @Reaction5 UNIQUEIDENTIFIER = NEWID()
DECLARE @Reaction6 UNIQUEIDENTIFIER = NEWID()
DECLARE @Reaction7 UNIQUEIDENTIFIER = NEWID()



IF(NOT EXISTS(SELECT 1 FROM dbo.Authors))

BEGIN
  INSERT INTO Authors(Id, Name, Surname, Description)
	VALUES
		 (@SGId, 'Stephanie', 'Garber', 'Description about Stephanie Garber')
		,(@RKId, 'Raven', 'Kennedy', 'Description about RavenKennedy')
		,(@BSId, 'Brandon', 'Sanderson', 'Description about Brandon Sanderson')
END;

IF(NOT EXISTS(SELECT 1 FROM dbo.Genres))
BEGIN
  INSERT INTO Genres (Id, Name)
	VALUES
		 (@FantsyId,'Fantasy')
		,(@RomanceId,'Romance')
		,(@CommedyId,'Commedy')
		,(@YoungAdultId,'Young adult')
END;

IF(NOT EXISTS(SELECT 1 FROM dbo.Books))
BEGIN
 INSERT INTO Books (Id, Name, Description, Status, PagesCount, AuthorId)
	VALUES
		 (@GildId,'Gild',  'Description for Gild','Read', 432, @RKId)
		,(@GlintId,'Glint', 'Description Glint','Reading', 448, @RKId)
		,(@CaravalId, 'Caraval', 'Caraval description', 'WantToRead', 362, @SGId)
		,(@MistbornId, 'Mistborn', 'Mistborn description', 'WantToRead', 1536, @BSId)
END;

IF(NOT EXISTS(SELECT 1 FROM dbo.BookGenre))
BEGIN
 INSERT INTO BookGenre(BooksId, GenresId)
	VALUES
		 (@GildId,@FantsyId)
		,(@GildId,@RomanceId)
		,(@GlintId,@FantsyId)
		,(@GlintId,@RomanceId)
		,(@CaravalId, @YoungAdultId)
		,(@CaravalId, @RomanceId)
		,(@MistbornId, @FantsyId)
END;

IF(NOT EXISTS(SELECT 1 FROM dbo.Reactions))
BEGIN
 INSERT INTO Reactions(Id, Reaction, BookId, CreatedOn, ModifiedOn)
	VALUES
		 (@Reaction1, 1, @GildId, '2023-01-23 13:45:30.000', NULL)
		,(@Reaction2, 0, @GildId, '2023-02-15 13:45:30.000',NULL)
		,(@Reaction3, 1, @GildId, '2023-02-15 13:45:30.000',NULL)
		,(@Reaction4, 1, @GlintId, '2023-05-16 13:45:30.000',NULL)
		,(@Reaction5, 1, @GildId, '2023-05-15 13:45:30.000',NULL)
		,(@Reaction6, 1, @CaravalId, '2023-02-15 13:45:30.000',NULL)
		,(@Reaction7, 1, @MistbornId, '2023-04-15 13:45:30.000', NULL)
END;