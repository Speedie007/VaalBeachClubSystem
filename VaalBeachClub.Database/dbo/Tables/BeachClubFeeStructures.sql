CREATE TABLE [dbo].[BeachClubFeeStructures] (
    [BeachClubFeeStructureID]        INT   IDENTITY (1, 1) NOT NULL,
    [MemberEntranceFee]              MONEY NOT NULL,
    [NonMemberEntranceFee]           MONEY NOT NULL,
    [NonMemberVehicleEntranceFee]    MONEY NOT NULL,
    [NonMemberBoatEntranceFee]       MONEY NOT NULL,
    [NonMemberJetSkiEntranceFee]     MONEY NOT NULL,
    [CampSitePerNight]               MONEY NOT NULL,
    [CampSitePerPersonForMembers]    MONEY NOT NULL,
    [CampSitePerPersonForNonMembers] MONEY NOT NULL,
    CONSTRAINT [PK_BeachClubFeeStructures] PRIMARY KEY CLUSTERED ([BeachClubFeeStructureID] ASC)
);

