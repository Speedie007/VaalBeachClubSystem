using System;
using System.Collections.Generic;

namespace BeachClubDBReverseEng
{
    public partial class ComplexAddress
    {
        public int Id { get; set; }
        public string ComplexName { get; set; }
        public string ComplexNumber { get; set; }

        public virtual Addresses IdNavigation { get; set; }
    }
}
