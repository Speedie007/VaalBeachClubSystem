CREATE TABLE [dbo].[MemberItemInStorage] (
    [MemberItemInStorageID] INT            IDENTITY (1, 1) NOT NULL,
    [item]                  NVARCHAR (MAX) NULL,
    [BoatHouseRentalID]     INT            NULL,
    [MemberItemID]          INT            NULL,
    CONSTRAINT [PK_MemberItemInStorage] PRIMARY KEY CLUSTERED ([MemberItemInStorageID] ASC),
    CONSTRAINT [FK_MemberItemInStorage_BoatHouseRentals_BoatHouseRentalID] FOREIGN KEY ([BoatHouseRentalID]) REFERENCES [dbo].[BoatHouseRentals] ([BoatHouseRentalID]),
    CONSTRAINT [FK_MemberItemInStorage_MemberItems_MemberItemID] FOREIGN KEY ([MemberItemID]) REFERENCES [dbo].[MemberItems] ([MemberItemID])
);


GO
CREATE NONCLUSTERED INDEX [IX_MemberItemInStorage_MemberItemID]
    ON [dbo].[MemberItemInStorage]([MemberItemID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_MemberItemInStorage_BoatHouseRentalID]
    ON [dbo].[MemberItemInStorage]([BoatHouseRentalID] ASC);

