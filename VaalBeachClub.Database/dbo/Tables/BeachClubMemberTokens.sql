CREATE TABLE [dbo].[BeachClubMemberTokens] (
    [BeachClubMemberID] INT            NOT NULL,
    [LoginProvider]     NVARCHAR (450) NOT NULL,
    [Name]              NVARCHAR (450) NOT NULL,
    [Value]             NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BeachClubMemberTokens] PRIMARY KEY CLUSTERED ([BeachClubMemberID] ASC, [LoginProvider] ASC, [Name] ASC),
    CONSTRAINT [FK_BeachClubMemberTokens_BeachClubMembers_BeachClubMemberID] FOREIGN KEY ([BeachClubMemberID]) REFERENCES [dbo].[BeachClubMembers] ([BeachClubMemberID]) ON DELETE CASCADE
);

