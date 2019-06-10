CREATE TABLE [dbo].[EntranceCommissionFee] (
    [CommissionFeeID]         INT             IDENTITY (1, 1) NOT NULL,
    [CommisionPercentage]     DECIMAL (18, 2) NOT NULL,
    [IsCurrentRate]           BIT             NOT NULL,
    [DateLastUpdated]         DATETIME2 (7)   NOT NULL,
    [BeachClubFeeStructureID] INT             NOT NULL,
    CONSTRAINT [PK_EntranceCommissionFee] PRIMARY KEY CLUSTERED ([CommissionFeeID] ASC),
    CONSTRAINT [FK_EntranceCommissionFee_BeachClubFeeStructures_BeachClubFeeStructureID] FOREIGN KEY ([BeachClubFeeStructureID]) REFERENCES [dbo].[BeachClubFeeStructures] ([BeachClubFeeStructureID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_EntranceCommissionFee_BeachClubFeeStructureID]
    ON [dbo].[EntranceCommissionFee]([BeachClubFeeStructureID] ASC);

