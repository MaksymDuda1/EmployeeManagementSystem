CREATE TABLE [dbo].[ProjectManager] (
    [ProjectId] UNIQUEIDENTIFIER NOT NULL,
    [ManagerId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK__ProjectM__75A0945E446E4E43] PRIMARY KEY CLUSTERED ([ProjectId] ASC, [ManagerId] ASC),
    CONSTRAINT [FK__ProjectMa__Manag__6C190EBB] FOREIGN KEY ([ManagerId]) REFERENCES [dbo].[Manager] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK__ProjectMa__Proje__6B24EA82] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ProjectManager_ManagerId]
    ON [dbo].[ProjectManager]([ManagerId] ASC);

