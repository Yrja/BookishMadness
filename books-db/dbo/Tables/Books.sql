CREATE TABLE [dbo].[Books] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (MAX)   NULL,
    [Description] NVARCHAR (MAX)   NULL,
    [Author]      NVARCHAR (MAX)   NULL,
    [PagesCount]  INT              NOT NULL,
    [Genre]       NVARCHAR (MAX)   NULL,
    [Status]      NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC)
);

