using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Models.Domain.Items
{
    public partial class ItemType : BaseEntity
    {
        public ItemType()
        {
            ItemTypeProperties = new HashSet<ItemTypeProperty>();
            MemberItems = new HashSet<MemberItem>();
        }

        public string Item { get; set; }

        public virtual ICollection<ItemTypeProperty> ItemTypeProperties { get; set; }
        public virtual ICollection<MemberItem> MemberItems { get; set; }
    }
}
