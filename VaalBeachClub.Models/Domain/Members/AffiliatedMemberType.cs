using System;
using System.Collections.Generic;

namespace VaalBeachClub.Models.Domain.Members
{
    public partial class AffiliatedMemberType : BaseEntity
    {
        public AffiliatedMemberType()
        {
            AffiliatedMembers = new HashSet<AffiliatedMember>();
        }

        
        public string AffiliatedMemberTypeName { get; set; }

        public virtual ICollection<AffiliatedMember> AffiliatedMembers { get; set; }
    }
}