IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [events] (
    [Id] int NOT NULL IDENTITY,
    [EventName] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [UrlAvatar] nvarchar(max) NOT NULL,
    [EventStartDate] datetime2 NOT NULL,
    [EventEndDate] datetime2 NOT NULL,
    [EventLocation] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_events] PRIMARY KEY ([Id])
);

CREATE TABLE [roles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_roles] PRIMARY KEY ([Id])
);

CREATE TABLE [users] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [MaSV] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [IsActive] bit NOT NULL,
    [RoleId] int NOT NULL,
    CONSTRAINT [PK_users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_users_roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [roles] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [documents] (
    [Id] int NOT NULL IDENTITY,
    [DocumentTitle] nvarchar(max) NOT NULL,
    [DocumentContent] nvarchar(max) NOT NULL,
    [UrlAvatar] nvarchar(max) NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_documents] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_documents_users_UserId] FOREIGN KEY ([UserId]) REFERENCES [users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [emailConfirms] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [Code] nvarchar(max) NOT NULL,
    [CreateTime] datetime2 NOT NULL,
    [Exprired] datetime2 NOT NULL,
    [IsConfirmed] bit NOT NULL,
    [IsActiveAccount] bit NOT NULL,
    CONSTRAINT [PK_emailConfirms] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_emailConfirms_users_UserId] FOREIGN KEY ([UserId]) REFERENCES [users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [eventJoins] (
    [Id] int NOT NULL IDENTITY,
    [EventId] int NOT NULL,
    [UserId] int NOT NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_eventJoins] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_eventJoins_events_EventId] FOREIGN KEY ([EventId]) REFERENCES [events] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_eventJoins_users_UserId] FOREIGN KEY ([UserId]) REFERENCES [users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [memberInfos] (
    [Id] int NOT NULL IDENTITY,
    [Class] nvarchar(max) NULL,
    [Birthdate] datetime2 NOT NULL,
    [FullName] nvarchar(max) NULL,
    [Nation] nvarchar(max) NULL,
    [religion] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [UrlAvatar] nvarchar(max) NOT NULL,
    [PoliticalTheory] nvarchar(max) NULL,
    [DateOfJoining] datetime2 NOT NULL,
    [PlaceOfJoining] nvarchar(max) NULL,
    [IsOutstandingMember] bit NOT NULL,
    [Status] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_memberInfos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_memberInfos_users_UserId] FOREIGN KEY ([UserId]) REFERENCES [users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [refreshTokens] (
    [Id] int NOT NULL IDENTITY,
    [Token] nvarchar(max) NOT NULL,
    [UserId] int NOT NULL,
    [Exprited] datetime2 NOT NULL,
    CONSTRAINT [PK_refreshTokens] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_refreshTokens_users_UserId] FOREIGN KEY ([UserId]) REFERENCES [users] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [rewardDisciplines] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    [CreateDate] datetime2 NOT NULL,
    [RewardOrDiscipline] bit NOT NULL,
    [Status] int NOT NULL,
    [RejectReason] nvarchar(max) NULL,
    [RecipientId] int NOT NULL,
    [ProposerId] int NOT NULL,
    CONSTRAINT [PK_rewardDisciplines] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_rewardDisciplines_users_ProposerId] FOREIGN KEY ([ProposerId]) REFERENCES [users] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_rewardDisciplines_users_RecipientId] FOREIGN KEY ([RecipientId]) REFERENCES [users] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [requestToBeOutStandingMembers] (
    [Id] int NOT NULL IDENTITY,
    [MemberInfoId] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [RejectReason] nvarchar(max) NULL,
    CONSTRAINT [PK_requestToBeOutStandingMembers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_requestToBeOutStandingMembers_memberInfos_MemberInfoId] FOREIGN KEY ([MemberInfoId]) REFERENCES [memberInfos] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [approvalHistories] (
    [Id] int NOT NULL IDENTITY,
    [RequestToBeOutstandingMemberId] int NULL,
    [RewardDisciplineId] int NULL,
    [ApprovedById] int NOT NULL,
    [ApprovedDate] datetime2 NOT NULL,
    [HistoryType] nvarchar(max) NOT NULL,
    [IsAccept] bit NOT NULL,
    CONSTRAINT [PK_approvalHistories] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_approvalHistories_requestToBeOutStandingMembers_RequestToBeOutstandingMemberId] FOREIGN KEY ([RequestToBeOutstandingMemberId]) REFERENCES [requestToBeOutStandingMembers] ([Id]),
    CONSTRAINT [FK_approvalHistories_rewardDisciplines_RewardDisciplineId] FOREIGN KEY ([RewardDisciplineId]) REFERENCES [rewardDisciplines] ([Id]),
    CONSTRAINT [FK_approvalHistories_users_ApprovedById] FOREIGN KEY ([ApprovedById]) REFERENCES [users] ([Id]) ON DELETE CASCADE
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[roles]'))
    SET IDENTITY_INSERT [roles] ON;
INSERT INTO [roles] ([Id], [Name])
VALUES (1, N'Đoàn viên'),
(2, N'Bí thư đoàn viên'),
(3, N'Liên chi đoàn khoa');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[roles]'))
    SET IDENTITY_INSERT [roles] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'IsActive', N'MaSV', N'Password', N'RoleId', N'Username') AND [object_id] = OBJECT_ID(N'[users]'))
    SET IDENTITY_INSERT [users] ON;
INSERT INTO [users] ([Id], [Email], [IsActive], [MaSV], [Password], [RoleId], [Username])
VALUES (1, N'admin@gmail.com', CAST(1 AS bit), N'1111111111', N'$2a$12$umDEKg3yORpv174r7kzKxO7Z.BVbw0HDzb44jCsvgjHGGn5rM6/Ky', 3, N'admin'),
(2, N'member@gmail.com', CAST(1 AS bit), N'1111111112', N'$2a$12$umDEKg3yORpv174r7kzKxO7Z.BVbw0HDzb44jCsvgjHGGn5rM6/Ky', 1, N'member'),
(3, N'secretary@gmail.com', CAST(1 AS bit), N'1111111113', N'$2a$12$umDEKg3yORpv174r7kzKxO7Z.BVbw0HDzb44jCsvgjHGGn5rM6/Ky', 2, N'secretary');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'IsActive', N'MaSV', N'Password', N'RoleId', N'Username') AND [object_id] = OBJECT_ID(N'[users]'))
    SET IDENTITY_INSERT [users] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Code', N'CreateTime', N'Exprired', N'IsActiveAccount', N'IsConfirmed', N'UserId') AND [object_id] = OBJECT_ID(N'[emailConfirms]'))
    SET IDENTITY_INSERT [emailConfirms] ON;
INSERT INTO [emailConfirms] ([Id], [Code], [CreateTime], [Exprired], [IsActiveAccount], [IsConfirmed], [UserId])
VALUES (1, N'123456', '2025-01-01T00:00:00.0000000', '2025-01-01T00:00:00.0000000', CAST(1 AS bit), CAST(1 AS bit), 1),
(2, N'123456', '2025-01-01T00:00:00.0000000', '2025-01-01T00:00:00.0000000', CAST(1 AS bit), CAST(1 AS bit), 2),
(3, N'123456', '2025-01-01T00:00:00.0000000', '2025-01-01T00:00:00.0000000', CAST(1 AS bit), CAST(1 AS bit), 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Code', N'CreateTime', N'Exprired', N'IsActiveAccount', N'IsConfirmed', N'UserId') AND [object_id] = OBJECT_ID(N'[emailConfirms]'))
    SET IDENTITY_INSERT [emailConfirms] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Birthdate', N'Class', N'DateOfJoining', N'FullName', N'IsOutstandingMember', N'Nation', N'PhoneNumber', N'PlaceOfJoining', N'PoliticalTheory', N'Status', N'UrlAvatar', N'UserId', N'religion') AND [object_id] = OBJECT_ID(N'[memberInfos]'))
    SET IDENTITY_INSERT [memberInfos] ON;
INSERT INTO [memberInfos] ([Id], [Birthdate], [Class], [DateOfJoining], [FullName], [IsOutstandingMember], [Nation], [PhoneNumber], [PlaceOfJoining], [PoliticalTheory], [Status], [UrlAvatar], [UserId], [religion])
VALUES (1, '2025-01-01T00:00:00.0000000', N'string', '2025-01-01T00:00:00.0000000', N'string', CAST(0 AS bit), N'string', N'string', N'string', N'string', 1, N'string', 1, N'string'),
(2, '2025-01-01T00:00:00.0000000', N'string', '2025-01-01T00:00:00.0000000', N'string', CAST(0 AS bit), N'string', N'string', N'string', N'string', 1, N'string', 2, N'string'),
(3, '2025-01-01T00:00:00.0000000', N'string', '2025-01-01T00:00:00.0000000', N'string', CAST(0 AS bit), N'string', N'string', N'string', N'string', 1, N'string', 3, N'string');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Birthdate', N'Class', N'DateOfJoining', N'FullName', N'IsOutstandingMember', N'Nation', N'PhoneNumber', N'PlaceOfJoining', N'PoliticalTheory', N'Status', N'UrlAvatar', N'UserId', N'religion') AND [object_id] = OBJECT_ID(N'[memberInfos]'))
    SET IDENTITY_INSERT [memberInfos] OFF;

CREATE INDEX [IX_approvalHistories_ApprovedById] ON [approvalHistories] ([ApprovedById]);

CREATE INDEX [IX_approvalHistories_RequestToBeOutstandingMemberId] ON [approvalHistories] ([RequestToBeOutstandingMemberId]);

CREATE INDEX [IX_approvalHistories_RewardDisciplineId] ON [approvalHistories] ([RewardDisciplineId]);

CREATE INDEX [IX_documents_UserId] ON [documents] ([UserId]);

CREATE INDEX [IX_emailConfirms_UserId] ON [emailConfirms] ([UserId]);

CREATE INDEX [IX_eventJoins_EventId] ON [eventJoins] ([EventId]);

CREATE INDEX [IX_eventJoins_UserId] ON [eventJoins] ([UserId]);

CREATE INDEX [IX_memberInfos_UserId] ON [memberInfos] ([UserId]);

CREATE INDEX [IX_refreshTokens_UserId] ON [refreshTokens] ([UserId]);

CREATE INDEX [IX_requestToBeOutStandingMembers_MemberInfoId] ON [requestToBeOutStandingMembers] ([MemberInfoId]);

CREATE INDEX [IX_rewardDisciplines_ProposerId] ON [rewardDisciplines] ([ProposerId]);

CREATE INDEX [IX_rewardDisciplines_RecipientId] ON [rewardDisciplines] ([RecipientId]);

CREATE INDEX [IX_users_RoleId] ON [users] ([RoleId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250312105749_ver1', N'9.0.2');

DECLARE @var sysname;
SELECT @var = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[memberInfos]') AND [c].[name] = N'DateOfJoining');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [memberInfos] DROP CONSTRAINT [' + @var + '];');
ALTER TABLE [memberInfos] ALTER COLUMN [DateOfJoining] datetime2 NULL;

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[memberInfos]') AND [c].[name] = N'Birthdate');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [memberInfos] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [memberInfos] ALTER COLUMN [Birthdate] datetime2 NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250316080133_ver2', N'9.0.2');

COMMIT;
GO

