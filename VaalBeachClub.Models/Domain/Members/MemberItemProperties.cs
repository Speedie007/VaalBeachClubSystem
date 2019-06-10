using System;
using System.Collections.Generic;
using VaalBeachClub.Models.Domain;
using VaalBeachClub.Models.Domain.Items;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Models.Domain.Members
{
    public partial class MemberItemProperty : BaseEntity
    {
        
        public int MemberItemID { get; set; }
        public int ItemPropertyID { get; set; }
        public string Value { get; set; }

        public virtual ItemProperty ItemProperty { get; set; }
        public virtual MemberItem MemberItem { get; set; }
    }
}