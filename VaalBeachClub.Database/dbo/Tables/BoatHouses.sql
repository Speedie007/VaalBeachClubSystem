CREATE TABLE [dbo].[BoatHouses] (
    [BoatHouseID]     INT            IDENTITY (1, 1) NOT NULL,
    [BoatHouseNumber] NVARCHAR (250) NULL,
    [BoatHouseSizeID] INT            NOT NULL,
    CONSTRAINT [PK_BoatHouses] PRIMARY KEY CLUSTERED ([BoatHouseID] ASC),
    CONSTRAINT [FK_BoatHouses_BoatHouseSizes] FOREIGN KEY ([BoatHouseSizeID]) REFERENCES [dbo].[BoatHouseSizes] ([BoatHouseSizeID])
);




GO
CREATE NONCLUSTERED INDEX [IX_BoatHouses_BoatHouseSizeID]
    ON [dbo].[BoatHouses]([BoatHouseSizeID] ASC);



