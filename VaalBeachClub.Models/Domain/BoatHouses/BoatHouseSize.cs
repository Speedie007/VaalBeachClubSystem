using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaalBeachClub.Models.Domain.Fees;

namespace VaalBeachClub.Models.Domain.BoatHouses
{
    public partial class BoatHouseSize : BaseEntity
    {
        public BoatHouseSize()
        {
            BoatHouses = new HashSet<BoatHouse>();
            BoatHouseCommissionFees = new HashSet<BoatHouseCommissionFee>();
        }

        public string Description { get; set; }
        public decimal Cost { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Hieght { get; set; }

        
        public string Dimensions => $"({Description}) - {Width}M x {Length}M x {Hieght}H";

        public virtual ICollection<BoatHouseCommissionFee> BoatHouseCommissionFees { get; set; }
        public virtual ICollection<BoatHouse> BoatHouses { get; set; }
    }
}
