CREATE TABLE [dbo].[CampSites] (
    [CampSiteID]     INT            IDENTITY (1, 1) NOT NULL,
    [CampSiteNumber] NVARCHAR (MAX) NULL,
    [hasElectricity] BIT            NOT NULL,
    CONSTRAINT [PK_CampSites] PRIMARY KEY CLUSTERED ([CampSiteID] ASC)
);

