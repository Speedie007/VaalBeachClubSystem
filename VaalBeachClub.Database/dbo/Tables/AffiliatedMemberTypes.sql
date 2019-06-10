CREATE TABLE [dbo].[AffiliatedMemberTypes] (
    [AffiliatedMemberTypeID]   INT           IDENTITY (1, 1) NOT NULL,
    [AffiliatedMemberTypeName] VARCHAR (250) NOT NULL,
    CONSTRAINT [PK_AffiliatedMemberTypes] PRIMARY KEY CLUSTERED ([AffiliatedMemberTypeID] ASC)
);

