using System;
using System.Collections.Generic;

namespace BeachClubDBReverseEng
{
    public partial class PoboxAddress
    {
        public int Id { get; set; }
        public string PoboxNumber { get; set; }

        public virtual Addresses IdNavigation { get; set; }
    }
}
