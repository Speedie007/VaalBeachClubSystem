CREATE TABLE [dbo].[BeachClubRoleClaims] (
    [BeachClubRoleClaimID] INT            IDENTITY (1, 1) NOT NULL,
    [BeachClubRoleID]      INT            NOT NULL,
    [ClaimType]            NVARCHAR (MAX) NULL,
    [ClaimValue]           NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_BeachClubRoleClaims] PRIMARY KEY CLUSTERED ([BeachClubRoleClaimID] ASC),
    CONSTRAINT [FK_BeachClubRoleClaims_BeachClubRoles_BeachClubRoleID] FOREIGN KEY ([BeachClubRoleID]) REFERENCES [dbo].[BeachClubRoles] ([BeachClubRoleID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BeachClubRoleClaims_BeachClubRoleID]
    ON [dbo].[BeachClubRoleClaims]([BeachClubRoleID] ASC);

