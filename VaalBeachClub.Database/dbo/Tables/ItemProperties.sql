CREATE TABLE [dbo].[ItemProperties] (
    [ItemPropertyID]         INT           IDENTITY (1, 1) NOT NULL,
    [ItemPropertyDataTypeID] INT           NOT NULL,
    [Property]               VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_ItemProperties] PRIMARY KEY CLUSTERED ([ItemPropertyID] ASC),
    CONSTRAINT [FK_ItemProperties_ItemPropertyDataTypes] FOREIGN KEY ([ItemPropertyDataTypeID]) REFERENCES [dbo].[ItemPropertyDataTypes] ([ItemPropertyDataTypeID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ItemProperties_ItemPropertyDataTypeID]
    ON [dbo].[ItemProperties]([ItemPropertyDataTypeID] ASC);

