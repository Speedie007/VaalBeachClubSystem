CREATE TABLE [dbo].[ActivityLogs] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [ActivityLogTypeId] INT            NOT NULL,
    [EntityId]          INT            NULL,
    [EntityName]        NVARCHAR (MAX) NULL,
    [CustomerId]        INT            NOT NULL,
    [Comment]           NVARCHAR (MAX) NULL,
    [CreatedOnUtc]      DATETIME2 (7)  NOT NULL,
    [BeachClubMemberId] INT            NULL,
    [IpAddress]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ActivityLogs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ActivityLogs_ActivityLogTypes_ActivityLogTypeId] FOREIGN KEY ([ActivityLogTypeId]) REFERENCES [dbo].[ActivityLogTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ActivityLogs_BeachClubMembers_BeachClubMemberId] FOREIGN KEY ([BeachClubMemberId]) REFERENCES [dbo].[BeachClubMembers] ([BeachClubMemberID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ActivityLogs_BeachClubMemberId]
    ON [dbo].[ActivityLogs]([BeachClubMemberId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ActivityLogs_ActivityLogTypeId]
    ON [dbo].[ActivityLogs]([ActivityLogTypeId] ASC);

