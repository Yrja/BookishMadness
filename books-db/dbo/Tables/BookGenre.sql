﻿CREATE TABLE [dbo].[BookGenre]
(
	[BooksId] UNIQUEIDENTIFIER NOT NULL,
	[GenresId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_BookGenre] PRIMARY KEY ([BooksId], [GenresId]),
	CONSTRAINT [FK_BookGenre_Genres_GenreId] FOREIGN KEY ([GenresId])  REFERENCES [Genres] ([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_BookGenre_Books_BookId] FOREIGN KEY ([BooksId])  REFERENCES [Books] ([Id]) ON DELETE CASCADE
);