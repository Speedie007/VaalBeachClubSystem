﻿using System;
using System.Collections.Generic;

namespace BeachClubDBReverseEng
{
    public partial class BeachClubRoleClaims
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual BeachClubRoles Role { get; set; }
    }
}
