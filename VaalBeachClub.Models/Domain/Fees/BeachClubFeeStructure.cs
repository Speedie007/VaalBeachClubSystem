using System;
using System.Collections.Generic;
using System.Text;

namespace VaalBeachClub.Models.Domain.Fees
{
    public partial class BeachClubFeeStructure : BaseEntity
    {
        public virtual decimal MemberEntranceFee { get; set; }
        public virtual decimal NonMemberEntranceFee { get; set; }
        public virtual decimal NonMemberVehicleEntranceFee { get; set; }
        public virtual decimal NonMemberBoatEntranceFee { get; set; }
        public virtual decimal NonMemberJetSkiEntranceFee { get; set; }
        public virtual decimal CampSitePerNight { get; set; }
        public virtual decimal CampSitePerPersonForMembers { get; set; }
        public virtual decimal CampSitePerPersonForNonMembers { get; set; }

        public virtual ICollection<EntranceCommissionFee> EntranceCommissionFees { get; set; }

        //public virtual int Entrance { get; set; }
    }
}
