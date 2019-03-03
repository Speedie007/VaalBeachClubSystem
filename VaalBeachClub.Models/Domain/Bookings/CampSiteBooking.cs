using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.CampSites;
using VaalBeachClub.Web.Data.Identity;

namespace VaalBeachClub.Models.Domain.Bookings
{
    public partial class CampSiteBooking : BaseEntity
    {
        public CampSiteBooking()
        {

        }

        public virtual DateTime StartDateTime { get; set; }
        public virtual DateTime EndDateTime { get; set; }
        public virtual int BeachClubMemberID { get; set; }
        public virtual int CampSiteID { get; set; }

        public virtual BeachClubMember BeachClubMember { get; set; }
        public virtual CampSite CampSite { get; set; }
    }
}
