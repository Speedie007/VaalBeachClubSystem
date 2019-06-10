using System;
using System.Collections.Generic;

namespace DatabaseDevelopment
{
    public partial class ItemTypeHierarchy
    {
        public int ItemTypeHierarchyId { get; set; }
        public int ParentId { get; set; }
        public int ChildId { get; set; }

        public virtual ItemTypes Parent { get; set; }
    }
}