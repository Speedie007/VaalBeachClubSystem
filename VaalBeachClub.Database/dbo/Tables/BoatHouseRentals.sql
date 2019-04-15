CREATE TABLE [dbo].[BoatHouseRentals] (
    [BoatHouseRentalID] INT           IDENTITY (1, 1) NOT NULL,
    [StartDate]         DATETIME2 (7) NOT NULL,
    [EndDate]           DATETIME2 (7) NOT NULL,
    [HasBeenPaid]       BIT           NOT NULL,
    [BeachClubMemberID] INT           NOT NULL,
    [BoatHouseID]       INT           NOT NULL,
    CONSTRAINT [PK_BoatHouseRentals] PRIMARY KEY CLUSTERED ([BoatHouseRentalID] ASC),
    CONSTRAINT [FK_BoatHouseRentals_BeachClubMembers_BeachClubMemberID] FOREIGN KEY ([BeachClubMemberID]) REFERENCES [dbo].[BeachClubMembers] ([BeachClubMemberID]) ON DELETE CASCADE,
    CONSTRAINT [FK_BoatHouseRentals_BoatHouses_BoatHouseID] FOREIGN KEY ([BoatHouseID]) REFERENCES [dbo].[BoatHouses] ([BoatHouseID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BoatHouseRentals_BoatHouseID]
    ON [dbo].[BoatHouseRentals]([BoatHouseID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BoatHouseRentals_BeachClubMemberID]
    ON [dbo].[BoatHouseRentals]([BeachClubMemberID] ASC);

