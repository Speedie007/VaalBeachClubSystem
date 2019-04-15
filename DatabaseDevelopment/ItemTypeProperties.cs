using System;
using System.Collections.Generic;

namespace DatabaseDevelopment
{
    public partial class ItemTypeProperties
    {
        public int ItemTypePropertyId { get; set; }
        public int ItemId { get; set; }
        public int ItemPropertyId { get; set; }

        public virtual ItemTypes Item { get; set; }
        public virtual ItemProperties ItemProperty { get; set; }
    }
}