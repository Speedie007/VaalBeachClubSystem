CREATE TABLE [dbo].[BeachClubMemberRoles] (
    [BeachClubMemberID] INT NOT NULL,
    [BeachClubRoleID]   INT NOT NULL,
    CONSTRAINT [PK_BeachClubMemberRoles] PRIMARY KEY CLUSTERED ([BeachClubMemberID] ASC, [BeachClubRoleID] ASC),
    CONSTRAINT [FK_BeachClubMemberRoles_BeachClubMembers_BeachClubMemberID] FOREIGN KEY ([BeachClubMemberID]) REFERENCES [dbo].[BeachClubMembers] ([BeachClubMemberID]) ON DELETE CASCADE,
    CONSTRAINT [FK_BeachClubMemberRoles_BeachClubRoles_BeachClubRoleID] FOREIGN KEY ([BeachClubRoleID]) REFERENCES [dbo].[BeachClubRoles] ([BeachClubRoleID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BeachClubMemberRoles_BeachClubRoleID]
    ON [dbo].[BeachClubMemberRoles]([BeachClubRoleID] ASC);

