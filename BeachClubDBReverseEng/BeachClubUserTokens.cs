using System;
using System.Collections.Generic;

namespace BeachClubDBReverseEng
{
    public partial class BeachClubUserTokens
    {
        public int UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual BeachClubUsers User { get; set; }
    }
}
