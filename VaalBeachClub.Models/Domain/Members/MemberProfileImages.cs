using System;
using System.Collections.Generic;
using VaalBeachClub.Models.Domain.Files;
using VaalBeachClub.Web.Data.Identity;

namespace VaalBeachClub.Models.Domain.Members
{
    public partial class MemberProfileImage :BaseEntity
    {
       
        public int FileID { get; set; }
        public int BeachClubMemberID { get; set; }
        public DateTime DateLastUpdated { get; set; }

        public virtual BeachClubMember BeachClubMember { get; set; }
        public virtual File File { get; set; }
    }
}