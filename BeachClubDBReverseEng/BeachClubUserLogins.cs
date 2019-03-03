using System;
using System.Collections.Generic;

namespace BeachClubDBReverseEng
{
    public partial class BeachClubUserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public int UserId { get; set; }

        public virtual BeachClubUsers User { get; set; }
    }
}
