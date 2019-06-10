CREATE TABLE [dbo].[Addresses] (
    [AddressID]         INT            IDENTITY (1, 1) NOT NULL,
    [City]              NVARCHAR (MAX) NULL,
    [Suburb]            NVARCHAR (MAX) NULL,
    [AreaCode]          NVARCHAR (MAX) NULL,
    [IsPrimaryAddress]  BIT            NOT NULL,
    [BeachClubMemberID] INT            NOT NULL,
    [CountryID]         INT            NOT NULL,
    [AddressType]       INT            NOT NULL,
    [ComplexName]       NVARCHAR (MAX) NULL,
    [ComplexUnitNumber] NVARCHAR (MAX) NULL,
    [POBoxNumber]       NVARCHAR (MAX) NULL,
    [StreetNumber]      NVARCHAR (MAX) NULL,
    [StreetName]        VARCHAR (250)  NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([AddressID] ASC),
    CONSTRAINT [FK_Addresses_BeachClubMembers_BeachClubMemberID] FOREIGN KEY ([BeachClubMemberID]) REFERENCES [dbo].[BeachClubMembers] ([BeachClubMemberID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Addresses_Countries] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[Countries] ([CountryID])
);




GO
CREATE NONCLUSTERED INDEX [IX_Addresses_BeachClubMemberID]
    ON [dbo].[Addresses]([BeachClubMemberID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Addresses_CountryID]
    ON [dbo].[Addresses]([CountryID] ASC);

