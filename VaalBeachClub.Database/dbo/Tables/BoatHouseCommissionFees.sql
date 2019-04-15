CREATE TABLE [dbo].[BoatHouseCommissionFees] (
    [CommissionFeeID]     INT             IDENTITY (1, 1) NOT NULL,
    [CommisionPercentage] DECIMAL (18, 2) NOT NULL,
    [IsCurrentRate]       BIT             NOT NULL,
    [DateLastUpdated]     DATETIME2 (7)   NOT NULL,
    [BoatHouseSizeID]     INT             NOT NULL,
    CONSTRAINT [PK_BoatHouseCommissionFees] PRIMARY KEY CLUSTERED ([CommissionFeeID] ASC),
    CONSTRAINT [FK_BoatHouseCommissionFees_BoatHouseSizes_BoatHouseSizeID] FOREIGN KEY ([BoatHouseSizeID]) REFERENCES [dbo].[BoatHouseSizes] ([BoatHouseSizeID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BoatHouseCommissionFees_BoatHouseSizeID]
    ON [dbo].[BoatHouseCommissionFees]([BoatHouseSizeID] ASC);

