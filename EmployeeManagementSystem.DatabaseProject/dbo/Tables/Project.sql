CREATE TABLE [dbo].[Project] (
    [Id]        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]      VARCHAR (255)    NOT NULL,
    [Customer]  VARCHAR (255)    NOT NULL,
    [StartDate] DATE             NOT NULL,
    [EndDate]   DATE             NOT NULL,
    CONSTRAINT [PK__Project__3214EC078F8CF647] PRIMARY KEY CLUSTERED ([Id] ASC)
);

