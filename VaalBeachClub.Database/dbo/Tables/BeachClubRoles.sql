CREATE TABLE [dbo].[BeachClubRoles] (
    [BeachClubRoleID]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (256) NULL,
    [NormalizedName]   NVARCHAR (256) NULL,
    [ConcurrencyStamp] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BeachClubRoles] PRIMARY KEY CLUSTERED ([BeachClubRoleID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[BeachClubRoles]([NormalizedName] ASC) WHERE ([NormalizedName] IS NOT NULL);

