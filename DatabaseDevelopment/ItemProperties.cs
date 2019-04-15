using System;
using System.Collections.Generic;

namespace DatabaseDevelopment
{
    public partial class ItemProperties
    {
        public ItemProperties()
        {
            ItemTypeProperties = new HashSet<ItemTypeProperties>();
        }

        public int ItemPropertyId { get; set; }
        public string Property { get; set; }

        public virtual ICollection<ItemTypeProperties> ItemTypeProperties { get; set; }
    }
}