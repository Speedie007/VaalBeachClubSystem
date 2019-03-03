using System;
using System.Collections.Generic;

namespace BeachClubDBReverseEng
{
    public partial class Addresses
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string Country { get; set; }
        public string AreaCode { get; set; }

        public virtual ComplexAddress ComplexAddress { get; set; }
        public virtual PoboxAddress PoboxAddress { get; set; }
        public virtual StreetAddress StreetAddress { get; set; }
    }
}
