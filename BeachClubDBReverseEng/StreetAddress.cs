using System;
using System.Collections.Generic;

namespace BeachClubDBReverseEng
{
    public partial class StreetAddress
    {
        public int Id { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }

        public virtual Addresses IdNavigation { get; set; }
    }
}
