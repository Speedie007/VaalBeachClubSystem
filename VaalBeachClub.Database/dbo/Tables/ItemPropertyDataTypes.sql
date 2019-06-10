CREATE TABLE [dbo].[ItemPropertyDataTypes] (
    [ItemPropertyDataTypeID]   INT           IDENTITY (1, 1) NOT NULL,
    [ItemPropertyDataTypeName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_ItemPropertyDataTypes] PRIMARY KEY CLUSTERED ([ItemPropertyDataTypeID] ASC)
);

