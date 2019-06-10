CREATE TABLE [dbo].[MemberItemProperties] (
    [MemberItemPropertyID] INT           IDENTITY (1, 1) NOT NULL,
    [MemberItemID]         INT           NOT NULL,
    [ItemPropertyID]       INT           NOT NULL,
    [Value]                VARCHAR (150) NOT NULL,
    CONSTRAINT [PK_MemberItemProperties] PRIMARY KEY CLUSTERED ([MemberItemPropertyID] ASC),
    CONSTRAINT [FK_MemberItemProperties_ItemProperties_1] FOREIGN KEY ([ItemPropertyID]) REFERENCES [dbo].[ItemProperties] ([ItemPropertyID]),
    CONSTRAINT [FK_MemberItemProperties_MemberItems_1] FOREIGN KEY ([MemberItemID]) REFERENCES [dbo].[MemberItems] ([MemberItemID])
);


GO
CREATE NONCLUSTERED INDEX [IX_MemberItemProperties_MemberItemID]
    ON [dbo].[MemberItemProperties]([MemberItemID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MemberItemProperties_ItemPropertyID]
    ON [dbo].[MemberItemProperties]([ItemPropertyID] ASC);

