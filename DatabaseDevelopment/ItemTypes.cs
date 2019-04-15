using System;
using System.Collections.Generic;

namespace DatabaseDevelopment
{
    public partial class ItemTypes
    {
        public ItemTypes()
        {
            ItemTypeProperties = new HashSet<ItemTypeProperties>();
            MemberItems = new HashSet<MemberItems>();
        }

        public int ItemId { get; set; }
        public string Item { get; set; }

        public virtual ICollection<ItemTypeProperties> ItemTypeProperties { get; set; }
        public virtual ICollection<MemberItems> MemberItems { get; set; }
    }
}