using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Rentals;

namespace VaalBeachClub.Models.Domain.BoatHouses
{
    public partial class BoatHouse : BaseEntity
    {
        public BoatHouse()
        {
            BoatHouseRentals = new List<BoatHouseRental>();
        }

        public virtual string BoatHouseNumber { get; set; }
        public virtual int BoatHouseSizeID { get; set; }
        public virtual BoatHouseSize BoatHouseSize { get; set; }

        public virtual ICollection<BoatHouseRental> BoatHouseRentals { get; set; }

    }
}
