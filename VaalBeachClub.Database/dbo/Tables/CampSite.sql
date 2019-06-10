CREATE TABLE [dbo].[CampSite] (
    [CampSiteID]     INT            IDENTITY (1, 1) NOT NULL,
    [CampSiteNumber] NVARCHAR (MAX) NULL,
    [hasElectricity] BIT            NOT NULL,
    CONSTRAINT [PK_CampSite] PRIMARY KEY CLUSTERED ([CampSiteID] ASC)
);

