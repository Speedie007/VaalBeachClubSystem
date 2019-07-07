using System;
using System.Collections.Generic;
using System.Text;

namespace VaalBeachClub.Models.Domain.Rentals
{
    public partial class BoatHouseRentalStatus : BaseEntity
    {

        public BoatHouseRentalStatus()
        {
            BoatHouseRentals = new List<BoatHouseRental>();
        }

        public string RentalStatus { get; set; }

        public virtual ICollection<BoatHouseRental> BoatHouseRentals { get; set; }
        

    }
}
