CREATE TABLE [dbo].[Books] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (MAX)   NULL,
    [Description] NVARCHAR (MAX)   NULL,
    [PagesCount]  INT              NOT NULL,
    [Genre]       NVARCHAR (MAX)   NULL,
    [Status]      NVARCHAR (MAX)   NOT NULL,
    [AuthorId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id] ),
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE CASCADE
);

