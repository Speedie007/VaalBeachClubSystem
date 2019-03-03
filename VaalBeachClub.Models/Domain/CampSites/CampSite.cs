using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Bookings;

namespace VaalBeachClub.Models.Domain.CampSites
{
    public partial class CampSite : BaseEntity
    {
        public CampSite()
        {
            CampSiteBookings = new List<CampSiteBooking>();
        }

        public virtual string CampSiteNumber { get; set; }
        public virtual Boolean hasElectricity { get; set; }
        

        public virtual ICollection<CampSiteBooking> CampSiteBookings { get; set; }
    }
}
