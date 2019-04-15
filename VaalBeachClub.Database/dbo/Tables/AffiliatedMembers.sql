CREATE TABLE [dbo].[AffiliatedMembers] (
    [AffiliatedMemberID] INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]          NVARCHAR (75) NULL,
    [LastName]           NVARCHAR (75) NULL,
    [BeachClubMemberID]  INT           NOT NULL,
    [MemberAffiliation]  INT           NOT NULL,
    [DateOfBirth]        DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_AffiliatedMembers] PRIMARY KEY CLUSTERED ([AffiliatedMemberID] ASC),
    CONSTRAINT [FK_AffiliatedMembers_BeachClubMembers_BeachClubMemberID] FOREIGN KEY ([BeachClubMemberID]) REFERENCES [dbo].[BeachClubMembers] ([BeachClubMemberID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AffiliatedMembers_BeachClubMemberID]
    ON [dbo].[AffiliatedMembers]([BeachClubMemberID] ASC);

