CREATE TABLE [dbo].[ItemTypeHierarchy] (
    [ItemTypeHierarchyID] INT IDENTITY (1, 1) NOT NULL,
    [ParentID]            INT NOT NULL,
    [ChildID]             INT NOT NULL,
    CONSTRAINT [PK_ItemTypeHierarchy] PRIMARY KEY CLUSTERED ([ItemTypeHierarchyID] ASC),
    CONSTRAINT [FK_ItemTypeHierarchy_ItemTypes] FOREIGN KEY ([ParentID]) REFERENCES [dbo].[ItemTypes] ([ItemTypeID])
);

