using System;
using System.Collections.Generic;
using VaalBeachClub.Web.Data.Identity;

namespace VaalBeachClub.Models.Domain.Common
{
    public partial class ContactDetail: BaseEntity
    {
        public int BeachClubMemberID { get; set; }
        public int ContactDetailTypeID { get; set; }
        public string ContactDetailValue { get; set; }

        public virtual BeachClubMember BeachClubMember { get; set; }
        public virtual ContactDetailType ContactDetailType { get; set; }
    }
}