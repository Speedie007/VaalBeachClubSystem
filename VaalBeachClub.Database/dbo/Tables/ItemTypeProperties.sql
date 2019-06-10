CREATE TABLE [dbo].[ItemTypeProperties] (
    [ItemTypePropertyID]   INT IDENTITY (1, 1) NOT NULL,
    [ItemID]               INT NOT NULL,
    [ItemPropertyID]       INT NOT NULL,
    [ItemPropertyRequired] BIT NOT NULL,
    CONSTRAINT [PK_ItemTypeProperties] PRIMARY KEY CLUSTERED ([ItemTypePropertyID] ASC),
    CONSTRAINT [FK_ItemTypeProperties_ItemProperties] FOREIGN KEY ([ItemPropertyID]) REFERENCES [dbo].[ItemProperties] ([ItemPropertyID]),
    CONSTRAINT [FK_ItemTypeProperties_ItemTypes] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[ItemTypes] ([ItemTypeID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ItemTypeProperties_ItemPropertyID]
    ON [dbo].[ItemTypeProperties]([ItemPropertyID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ItemTypeProperties_ItemID]
    ON [dbo].[ItemTypeProperties]([ItemID] ASC);

