CREATE TABLE [dbo].[ItemTypes] (
    [ItemTypeID] INT           IDENTITY (1, 1) NOT NULL,
    [Item]       VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_ItemTypes] PRIMARY KEY CLUSTERED ([ItemTypeID] ASC)
);

