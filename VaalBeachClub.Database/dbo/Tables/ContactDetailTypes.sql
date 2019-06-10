CREATE TABLE [dbo].[ContactDetailTypes] (
    [ContactDetailTypeID]    INT           IDENTITY (1, 1) NOT NULL,
    [ContactDetailTypeValue] VARCHAR (150) NOT NULL,
    CONSTRAINT [PK_ContactDetailTypes] PRIMARY KEY CLUSTERED ([ContactDetailTypeID] ASC)
);

