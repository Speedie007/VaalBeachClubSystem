using System;
using System.Collections.Generic;
using System.Text;

namespace VaalBeachClub.Models.Domain.Items
{
    public partial class ItemProperty : BaseEntity
    {
        public ItemProperty()
        {
            ItemTypeProperties = new HashSet<ItemTypeProperty>();
        }


        public string Property { get; set; }

        public virtual ICollection<ItemTypeProperty> ItemTypeProperties { get; set; }
    }
}
