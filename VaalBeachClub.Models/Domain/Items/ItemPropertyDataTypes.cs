using System;
using System.Collections.Generic;

namespace VaalBeachClub.Models.Domain.Items
{
    public partial class ItemPropertyDataType : BaseEntity
    {
        public ItemPropertyDataType()
        {
            ItemProperties = new HashSet<ItemProperty>();
        }

        
        public string ItemPropertyDataTypeName { get; set; }

        public virtual ICollection<ItemProperty> ItemProperties { get; set; }
    }
}