using System;
using System.Collections.Generic;
using VaalBeachClub.Models.Domain;


namespace VaalBeachClub.Models.Domain.Members
{
    public partial class MemberRegistration :BaseEntity
    {
        
        public DateTime DateRegistrationCreated { get; set; }
        public int BeachClubMemberID { get; set; }
        public bool HasReadTermsAndConditions { get; set; }
        public bool HasBeenProcessed { get; set; }
        public bool HasBeenApproved { get; set; }
        public bool HasBeenPaid { get; set; }

        public virtual BeachClubMember BeachClubMember { get; set; }
    }
}