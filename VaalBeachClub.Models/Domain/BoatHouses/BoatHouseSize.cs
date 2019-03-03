using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Fees;

namespace VaalBeachClub.Models.Domain.BoatHouses
{
    public partial class BoatHouseSize : BaseEntity
    {
        public virtual Int64 Size { get; set; }
        public virtual BoatHouse BoatHouse { get; set; }
        public virtual decimal Cost { get; set; }

        public virtual ICollection<BoatHouseCommissionFee> BoatHouseCommissionFees { get; set; }
    }
}
