CREATE TABLE [dbo].[MemberProfileImages] (
    [MemberProfileImageID] INT           IDENTITY (1, 1) NOT NULL,
    [FileID]               INT           NOT NULL,
    [BeachClubMemberID]    INT           NOT NULL,
    [DateLastUpdated]      DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_MemberProfileImages] PRIMARY KEY CLUSTERED ([MemberProfileImageID] ASC),
    CONSTRAINT [FK_MemberProfileImages_BeachClubMembers] FOREIGN KEY ([BeachClubMemberID]) REFERENCES [dbo].[BeachClubMembers] ([BeachClubMemberID]),
    CONSTRAINT [FK_MemberProfileImages_Files] FOREIGN KEY ([FileID]) REFERENCES [dbo].[Files] ([FileID])
);


GO
CREATE NONCLUSTERED INDEX [IX_MemberProfileImages_FileID]
    ON [dbo].[MemberProfileImages]([FileID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MemberProfileImages_BeachClubMemberID]
    ON [dbo].[MemberProfileImages]([BeachClubMemberID] ASC);

