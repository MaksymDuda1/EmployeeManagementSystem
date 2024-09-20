CREATE TABLE [dbo].[Task] (
    [Id]           UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]         VARCHAR (255)    NOT NULL,
    [Description]  VARCHAR (2000)   NULL,
    [DeadlineDate] DATE             NOT NULL,
    [Status]       INT              DEFAULT ((1)) NULL,
    [ProjectId]    UNIQUEIDENTIFIER NOT NULL,
    [EmployeeId]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK__TASK__3214EC072A1619DD] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__TASK__EmployeeId__71D1E811] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK__TASK__ProjectId__70DDC3D8] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Task_ProjectId]
    ON [dbo].[Task]([ProjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Task_EmployeeId]
    ON [dbo].[Task]([EmployeeId] ASC);

