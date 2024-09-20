CREATE TABLE [dbo].[Employee] (
    [Id]       UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Position] VARCHAR (255)    NOT NULL,
    [HireDate] DATE             NOT NULL,
    [UserId]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK__Employee__3214EC0772CA2E64] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Employee_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ__Employee__1788CC4D9DB5F725]
    ON [dbo].[Employee]([UserId] ASC);

