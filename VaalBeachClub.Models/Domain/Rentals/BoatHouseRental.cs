using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.BoatHouses;
using VaalBeachClub.Models.Domain.Members;
using VaalBeachClub.Web.Data.Identity;

namespace VaalBeachClub.Models.Domain.Rentals
{
    public partial class BoatHouseRental : BaseEntity
    {
        public BoatHouseRental()
        {
           //MemberItemsInStorage = new List<MemberItemInStorage>();
        }

        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual Boolean HasBeenPaid { get; set; }
        public virtual int BeachClubMemberID { get; set; }
        public virtual int BoatHouseID { get; set; }

        public virtual BeachClubMember BeachClubMember { get; set; }
        public virtual BoatHouse BoatHouse { get; set; }
       
        public virtual ICollection<MemberItemInStorage> MemberItemsInStorage { get; set; }


    }
}
