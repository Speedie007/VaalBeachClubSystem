CREATE TABLE [dbo].[MemberRegistrations] (
    [MemberRegistrationID]      INT      IDENTITY (1, 1) NOT NULL,
    [DateRegistrationCreated]   DATETIME DEFAULT (getdate()) NOT NULL,
    [BeachClubMemberID]         INT      NOT NULL,
    [HasReadTermsAndConditions] BIT      NOT NULL,
    [HasBeenProcessed]          BIT      NOT NULL,
    [HasBeenApproved]           BIT      NOT NULL,
    [HasBeenPaid]               BIT      NOT NULL,
    CONSTRAINT [PK_MemberRegistrations] PRIMARY KEY CLUSTERED ([MemberRegistrationID] ASC),
    CONSTRAINT [FK_MemberRegistrations_BeachClubMembers] FOREIGN KEY ([BeachClubMemberID]) REFERENCES [dbo].[BeachClubMembers] ([BeachClubMemberID])
);


GO
CREATE NONCLUSTERED INDEX [IX_MemberRegistrations_BeachClubMemberID]
    ON [dbo].[MemberRegistrations]([BeachClubMemberID] ASC);

