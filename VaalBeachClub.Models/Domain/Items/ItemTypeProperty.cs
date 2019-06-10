using System;
using System.Collections.Generic;
using System.Text;

namespace VaalBeachClub.Models.Domain.Items
{
    public partial class ItemTypeProperty : BaseEntity
    {
        public ItemTypeProperty()
        {
            
            
        }
        public int ItemID { get; set; }
        public int ItemPropertyID { get; set; }
        public bool ItemPropertyRequired { get; set; }

        public virtual ItemType Item { get; set; }
        public virtual ItemProperty ItemProperty { get; set; }
        //public virtual ItemProperty ItemPropertyValue { get; set; }


    }
}
