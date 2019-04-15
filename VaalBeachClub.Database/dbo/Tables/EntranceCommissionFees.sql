CREATE TABLE [dbo].[EntranceCommissionFees] (
    [CommissionFeeID]         INT             IDENTITY (1, 1) NOT NULL,
    [CommisionPercentage]     DECIMAL (18, 2) NOT NULL,
    [IsCurrentRate]           BIT             NOT NULL,
    [DateLastUpdated]         DATETIME2 (7)   NOT NULL,
    [BeachClubFeeStructureId] INT             NULL,
    CONSTRAINT [PK_EntranceCommissionFees] PRIMARY KEY CLUSTERED ([CommissionFeeID] ASC),
    CONSTRAINT [FK_EntranceCommissionFees_BeachClubFeeStructures_BeachClubFeeStructureId] FOREIGN KEY ([BeachClubFeeStructureId]) REFERENCES [dbo].[BeachClubFeeStructures] ([BeachClubFeeStructureID])
);


GO
CREATE NONCLUSTERED INDEX [IX_EntranceCommissionFees_BeachClubFeeStructureId]
    ON [dbo].[EntranceCommissionFees]([BeachClubFeeStructureId] ASC);

