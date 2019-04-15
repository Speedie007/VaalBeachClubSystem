using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaalBeachClub.Models.Domain.Rentals;

namespace VaalBeachClub.Models.Domain.Members
{
    public partial class MemberItemInStorage : BaseEntity
    {
        public MemberItemInStorage()
        {

        }


        public virtual int BoatHouseRentalID { get; set; }
        public virtual int MemberItemID { get; set; }

        public virtual MemberItem MemberItemBeingStored { get; set; }

        
        public virtual BoatHouseRental BoatHouseUseToStoreMemberItem { get; set; }


    }
}
