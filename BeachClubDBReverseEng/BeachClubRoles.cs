using System;
using System.Collections.Generic;

namespace BeachClubDBReverseEng
{
    public partial class BeachClubRoles
    {
        public BeachClubRoles()
        {
            BeachClubRoleClaims = new HashSet<BeachClubRoleClaims>();
            BeachClubUserRoles = new HashSet<BeachClubUserRoles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<BeachClubRoleClaims> BeachClubRoleClaims { get; set; }
        public virtual ICollection<BeachClubUserRoles> BeachClubUserRoles { get; set; }
    }
}
