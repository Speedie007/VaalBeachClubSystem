CREATE TABLE [dbo].[ActivityLogTypes] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [SystemKeyword] NVARCHAR (MAX) NULL,
    [Name]          NVARCHAR (MAX) NULL,
    [Enabled]       BIT            NOT NULL,
    CONSTRAINT [PK_ActivityLogTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

