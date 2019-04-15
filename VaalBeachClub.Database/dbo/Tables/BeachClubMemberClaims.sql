CREATE TABLE [dbo].[BeachClubMemberClaims] (
    [BeachClubMemberClaimID] INT            IDENTITY (1, 1) NOT NULL,
    [BeachClubMemberID]      INT            NOT NULL,
    [ClaimType]              NVARCHAR (MAX) NULL,
    [ClaimValue]             NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BeachClubMemberClaims] PRIMARY KEY CLUSTERED ([BeachClubMemberClaimID] ASC),
    CONSTRAINT [FK_BeachClubMemberClaims_BeachClubMembers_BeachClubMemberID] FOREIGN KEY ([BeachClubMemberID]) REFERENCES [dbo].[BeachClubMembers] ([BeachClubMemberID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BeachClubMemberClaims_BeachClubMemberID]
    ON [dbo].[BeachClubMemberClaims]([BeachClubMemberID] ASC);

