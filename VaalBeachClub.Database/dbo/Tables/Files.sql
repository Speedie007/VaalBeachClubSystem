CREATE TABLE [dbo].[Files] (
    [FileID]        INT           IDENTITY (1, 1) NOT NULL,
    [ContentType]   VARCHAR (75)  NOT NULL,
    [FileName]      VARCHAR (150) NOT NULL,
    [FileExtension] VARCHAR (50)  NOT NULL,
    [Image]         IMAGE         NULL,
    CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED ([FileID] ASC)
);

