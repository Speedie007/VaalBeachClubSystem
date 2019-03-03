using System;
using System.Collections.Generic;

namespace BeachClubDBReverseEng
{
    public partial class BeachClubUsers
    {
        public BeachClubUsers()
        {
            BeachClubUserClaims = new HashSet<BeachClubUserClaims>();
            BeachClubUserLogins = new HashSet<BeachClubUserLogins>();
            BeachClubUserRoles = new HashSet<BeachClubUserRoles>();
            BeachClubUserTokens = new HashSet<BeachClubUserTokens>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<BeachClubUserClaims> BeachClubUserClaims { get; set; }
        public virtual ICollection<BeachClubUserLogins> BeachClubUserLogins { get; set; }
        public virtual ICollection<BeachClubUserRoles> BeachClubUserRoles { get; set; }
        public virtual ICollection<BeachClubUserTokens> BeachClubUserTokens { get; set; }
    }
}
