using System;
using System.Collections.Generic;

namespace VaalBeachClub.Models.Domain.Items
{
    public partial class ItemTypeHierarchy : BaseEntity
    {

        public int ParentID { get; set; }
        public int ChildID { get; set; }
        public bool OccupiesSameSpaceAsParent { get; set; }
        public bool IsOptional { get; set; }
        public virtual ItemType Parent { get; set; }
    }
}