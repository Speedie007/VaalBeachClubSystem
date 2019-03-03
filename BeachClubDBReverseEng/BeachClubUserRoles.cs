using System;
using System.Collections.Generic;

namespace BeachClubDBReverseEng
{
    public partial class BeachClubUserRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual BeachClubRoles Role { get; set; }
        public virtual BeachClubUsers User { get; set; }
    }
}
