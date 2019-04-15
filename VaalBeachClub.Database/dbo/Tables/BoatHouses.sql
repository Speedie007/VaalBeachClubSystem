CREATE TABLE [dbo].[BoatHouses] (
    [BoatHouseID]     INT            IDENTITY (1, 1) NOT NULL,
    [BoatHouseNumber] NVARCHAR (250) NULL,
    [BoatHouseSizeID] INT            NOT NULL,
    CONSTRAINT [PK_BoatHouses] PRIMARY KEY CLUSTERED ([BoatHouseID] ASC),
    CONSTRAINT [FK_BoatHouses_BoatHouseSizes_BoatHouseSizeID] FOREIGN KEY ([BoatHouseSizeID]) REFERENCES [dbo].[BoatHouseSizes] ([BoatHouseSizeID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_BoatHouses_BoatHouseSizeID]
    ON [dbo].[BoatHouses]([BoatHouseSizeID] ASC);

