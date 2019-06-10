CREATE TABLE [dbo].[BoatHouseSizes] (
    [BoatHouseSizeID] INT             IDENTITY (1, 1) NOT NULL,
    [Description]     NVARCHAR (MAX)  NULL,
    [Cost]            MONEY           NOT NULL,
    [Length]          NUMERIC (18, 1) NOT NULL,
    [Width]           NUMERIC (18, 1) NOT NULL,
    [Hieght]          NUMERIC (18, 1) NOT NULL,
    CONSTRAINT [PK_BoatHouseSizes] PRIMARY KEY CLUSTERED ([BoatHouseSizeID] ASC)
);



