using System;
using System.Collections.Generic;
using System.Text;

namespace VaalBeachClub.Models.Domain.Fees
{
    public abstract partial class CommssionFee : BaseEntity
    {

        public virtual decimal CommisionPercentage { get; set; }
        public virtual Boolean IsCurrentRate { get; set; }
    }

    public partial class EntranceCommissionFee : CommssionFee
    {
        public DateTime DateLastUpdated { get; set; }
        public int BeachClubFeeStructureID { get; set; }
    }

    public partial class BoatHouseCommissionFee : CommssionFee
    {
        public DateTime DateLastUpdated { get; set; }
        public virtual int BoatHouseSizeID { get; set; }
    }

}
