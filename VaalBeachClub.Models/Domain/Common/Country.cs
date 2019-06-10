using System;
using System.Collections.Generic;
using VaalBeachClub.Models.Domain.Addresses;

namespace VaalBeachClub.Models.Domain.Common
{
    public partial class Country : BaseEntity
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
        }

        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}