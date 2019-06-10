CREATE TABLE [dbo].[Countries] (
    [CountryID]   INT          IDENTITY (1, 1) NOT NULL,
    [CountryCode] VARCHAR (2)  NOT NULL,
    [CountryName] VARCHAR (75) NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([CountryID] ASC)
);

