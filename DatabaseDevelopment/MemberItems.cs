using System;
using System.Collections.Generic;

namespace DatabaseDevelopment
{
    public partial class MemberItems
    {
        public MemberItems()
        {
            MemberItemInStorage = new HashSet<MemberItemInStorage>();
        }

        public int MemberItemId { get; set; }
        public int BeachClubMemberId { get; set; }
        public int ItemId { get; set; }

        public virtual BeachClubMembers BeachClubMember { get; set; }
        public virtual ItemTypes Item { get; set; }
        public virtual ICollection<MemberItemInStorage> MemberItemInStorage { get; set; }
    }
}