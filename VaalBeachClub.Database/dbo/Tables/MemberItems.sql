CREATE TABLE [dbo].[MemberItems] (
    [MemberItemID]      INT IDENTITY (1, 1) NOT NULL,
    [BeachClubMemberID] INT NOT NULL,
    [ItemID]            INT NOT NULL,
    [IsOnSite]          BIT NOT NULL,
    CONSTRAINT [PK_MemberItems] PRIMARY KEY CLUSTERED ([MemberItemID] ASC),
    CONSTRAINT [FK_MemberItems_BeachClubMembers_BeachClubMemberID] FOREIGN KEY ([BeachClubMemberID]) REFERENCES [dbo].[BeachClubMembers] ([BeachClubMemberID]) ON DELETE CASCADE,
    CONSTRAINT [FK_MemberItems_ItemTypes] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[ItemTypes] ([ItemTypeID])
);




GO
CREATE NONCLUSTERED INDEX [IX_MemberItems_BeachClubMemberID]
    ON [dbo].[MemberItems]([BeachClubMemberID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MemberItems_ItemID]
    ON [dbo].[MemberItems]([ItemID] ASC);

