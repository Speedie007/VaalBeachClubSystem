CREATE TABLE [dbo].[MemberItems] (
    [MemberItemID]                 INT            IDENTITY (1, 1) NOT NULL,
    [BeachClubMemberID]            INT            NOT NULL,
    [StorageItemType]              INT            NOT NULL,
    [MemberItemType]               INT            NOT NULL,
    [BoatModel]                    NVARCHAR (MAX) NULL,
    [BoatMake]                     NVARCHAR (MAX) NULL,
    [BoatRegistration]             NVARCHAR (MAX) NULL,
    [JetSkiModel]                  NVARCHAR (MAX) NULL,
    [JetSkiMake]                   NVARCHAR (MAX) NULL,
    [JetSkiRegistration]           NVARCHAR (MAX) NULL,
    [MotorHome_JetSkiModel]        NVARCHAR (MAX) NULL,
    [MotorHome_JetSkiMake]         NVARCHAR (MAX) NULL,
    [MotorHome_JetSkiRegistration] NVARCHAR (MAX) NULL,
    [TrailerRegistration]          NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_MemberItems] PRIMARY KEY CLUSTERED ([MemberItemID] ASC),
    CONSTRAINT [FK_MemberItems_BeachClubMembers_BeachClubMemberID] FOREIGN KEY ([BeachClubMemberID]) REFERENCES [dbo].[BeachClubMembers] ([BeachClubMemberID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_MemberItems_BeachClubMemberID]
    ON [dbo].[MemberItems]([BeachClubMemberID] ASC);

