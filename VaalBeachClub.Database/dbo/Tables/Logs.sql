CREATE TABLE [dbo].[Logs] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [LogLevelId]   INT            NOT NULL,
    [ShortMessage] NVARCHAR (MAX) NULL,
    [FullMessage]  NVARCHAR (MAX) NULL,
    [IpAddress]    NVARCHAR (MAX) NULL,
    [PageUrl]      NVARCHAR (MAX) NULL,
    [ReferrerUrl]  NVARCHAR (MAX) NULL,
    [CreatedOnUtc] DATETIME2 (7)  NOT NULL,
    [LogLevel]     INT            NOT NULL,
    [MemberId]     INT            NULL,
    CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Logs_BeachClubMembers_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[BeachClubMembers] ([BeachClubMemberID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Logs_MemberId]
    ON [dbo].[Logs]([MemberId] ASC);

