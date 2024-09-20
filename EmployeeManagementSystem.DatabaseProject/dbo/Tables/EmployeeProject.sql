CREATE TABLE [dbo].[EmployeeProject] (
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL,
    [ProjectId]  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_EmployeeProject] PRIMARY KEY CLUSTERED ([EmployeeId] ASC, [ProjectId] ASC),
    CONSTRAINT [FK_EmployeeProject_Employee_EmployeesId] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_EmployeeProject_Project_ProjectsId] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_EmployeeProject_ProjectsId]
    ON [dbo].[EmployeeProject]([ProjectId] ASC);

