using System;
using System.Collections.Generic;

namespace DatabaseDevelopment
{
    public partial class ItemTypes
    {
        public ItemTypes()
        {
            ItemTypeHierarchy = new HashSet<ItemTypeHierarchy>();
        }

        public int ItemId { get; set; }
        public string Item { get; set; }
        public bool IsOnSiteStorageItem { get; set; }

        public virtual ICollection<ItemTypeHierarchy> ItemTypeHierarchy { get; set; }
    }
}