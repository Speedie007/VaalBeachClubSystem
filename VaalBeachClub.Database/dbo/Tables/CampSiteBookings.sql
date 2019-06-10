CREATE TABLE [dbo].[CampSiteBookings] (
    [CampSiteBookingID] INT           IDENTITY (1, 1) NOT NULL,
    [StartDateTime]     DATETIME2 (7) NOT NULL,
    [EndDateTime]       DATETIME2 (7) NOT NULL,
    [BeachClubMemberID] INT           NOT NULL,
    [CampSiteID]        INT           NOT NULL,
    CONSTRAINT [PK_CampSiteBookings] PRIMARY KEY CLUSTERED ([CampSiteBookingID] ASC),
    CONSTRAINT [FK_CampSiteBookings_BeachClubMembers_BeachClubMemberID] FOREIGN KEY ([BeachClubMemberID]) REFERENCES [dbo].[BeachClubMembers] ([BeachClubMemberID]) ON DELETE CASCADE,
    CONSTRAINT [FK_CampSiteBookings_CampSite_CampSiteID] FOREIGN KEY ([CampSiteID]) REFERENCES [dbo].[CampSite] ([CampSiteID]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_CampSiteBookings_CampSiteID]
    ON [dbo].[CampSiteBookings]([CampSiteID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CampSiteBookings_BeachClubMemberID]
    ON [dbo].[CampSiteBookings]([BeachClubMemberID] ASC);

