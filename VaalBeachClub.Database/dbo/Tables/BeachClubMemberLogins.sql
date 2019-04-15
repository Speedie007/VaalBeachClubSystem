CREATE TABLE [dbo].[BeachClubMemberLogins] (
    [LoginProvider]       NVARCHAR (450) NOT NULL,
    [ProviderKey]         NVARCHAR (450) NOT NULL,
    [ProviderDisplayName] NVARCHAR (MAX) NULL,
    [BeachClubMemberID]   INT            NOT NULL,
    CONSTRAINT [PK_BeachClubMemberLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC),
    CONSTRAINT [FK_BeachClubMemberLogins_BeachClubMembers_BeachClubMemberID] FOREIGN KEY ([BeachClubMemberID]) REFERENCES [dbo].[BeachClubMembers] ([BeachClubMemberID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BeachClubMemberLogins_BeachClubMemberID]
    ON [dbo].[BeachClubMemberLogins]([BeachClubMemberID] ASC);

