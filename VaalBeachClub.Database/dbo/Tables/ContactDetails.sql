CREATE TABLE [dbo].[ContactDetails] (
    [ContactDetailID]     INT           IDENTITY (1, 1) NOT NULL,
    [BeachClubMemberID]   INT           NOT NULL,
    [ContactDetailTypeID] INT           NOT NULL,
    [ContactDetailValue]  VARCHAR (150) NOT NULL,
    CONSTRAINT [PK_ContactDetails] PRIMARY KEY CLUSTERED ([ContactDetailID] ASC),
    CONSTRAINT [FK_ContactDetails_BeachClubMembers] FOREIGN KEY ([BeachClubMemberID]) REFERENCES [dbo].[BeachClubMembers] ([BeachClubMemberID]),
    CONSTRAINT [FK_ContactDetails_ContactDetailTypes] FOREIGN KEY ([ContactDetailTypeID]) REFERENCES [dbo].[ContactDetailTypes] ([ContactDetailTypeID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ContactDetails_ContactDetailTypeID]
    ON [dbo].[ContactDetails]([ContactDetailTypeID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ContactDetails_BeachClubMemberID]
    ON [dbo].[ContactDetails]([BeachClubMemberID] ASC);

