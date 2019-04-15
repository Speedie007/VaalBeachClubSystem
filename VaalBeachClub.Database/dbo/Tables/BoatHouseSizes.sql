CREATE TABLE [dbo].[BoatHouseSizes] (
    [BoatHouseSizeID] INT    IDENTITY (1, 1) NOT NULL,
    [Size]            BIGINT NOT NULL,
    [Cost]            MONEY  NOT NULL,
    CONSTRAINT [PK_BoatHouseSizes] PRIMARY KEY CLUSTERED ([BoatHouseSizeID] ASC)
);

