using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.BoatHouses;

namespace VaalBeachClub.Models.Domain.Fees
{
    public abstract partial class CommssionFee : BaseEntity
    {

        public virtual decimal CommisionPercentage { get; set; }
        public virtual Boolean IsCurrentRate { get; set; }
        public DateTime DateLastUpdated { get; set; }
    }

    public partial class EntranceCommissionFee : CommssionFee
    {
        
        public int BeachClubFeeStructureID { get; set; }
    }

    public partial class BoatHouseCommissionFee : CommssionFee
    {
        
        public virtual int BoatHouseSizeID { get; set; }
        public virtual BoatHouseSize BoatHouseSize { get; set; }
    }

}
