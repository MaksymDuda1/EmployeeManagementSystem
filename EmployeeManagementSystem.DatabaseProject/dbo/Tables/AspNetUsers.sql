﻿CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                     UNIQUEIDENTIFIER   NOT NULL,
    [FirstName]              NVARCHAR (MAX)     NOT NULL,
    [SecondName]             NVARCHAR (MAX)     NOT NULL,
    [RefreshToken]           NVARCHAR (MAX)     NULL,
    [RefreshTokenExpiration] DATETIME2 (7)      NULL,
    [UserName]               NVARCHAR (256)     NULL,
    [NormalizedUserName]     NVARCHAR (256)     NULL,
    [Email]                  NVARCHAR (256)     NULL,
    [NormalizedEmail]        NVARCHAR (256)     NULL,
    [EmailConfirmed]         BIT                NOT NULL,
    [PasswordHash]           NVARCHAR (MAX)     NULL,
    [SecurityStamp]          NVARCHAR (MAX)     NULL,
    [ConcurrencyStamp]       NVARCHAR (MAX)     NULL,
    [PhoneNumber]            NVARCHAR (MAX)     NULL,
    [PhoneNumberConfirmed]   BIT                NOT NULL,
    [TwoFactorEnabled]       BIT                NOT NULL,
    [LockoutEnd]             DATETIMEOFFSET (7) NULL,
    [LockoutEnabled]         BIT                NOT NULL,
    [AccessFailedCount]      INT                NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [EmailIndex]
    ON [dbo].[AspNetUsers]([NormalizedEmail] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([NormalizedUserName] ASC) WHERE ([NormalizedUserName] IS NOT NULL);

