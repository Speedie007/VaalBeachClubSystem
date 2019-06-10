using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Models.Domain.Items
{
    public partial class ItemProperty : BaseEntity
    {
        public ItemProperty()
        {
            ItemTypeProperties = new HashSet<ItemTypeProperty>();
            MemberAssetProperties = new HashSet<MemberItemProperty>();
        }

        public virtual int ItemPropertyDataTypeID { get; set; }
        public virtual string Property { get; set; }

        public virtual ItemPropertyDataType ItemPropertyDataType { get; set; }
        public virtual ICollection<ItemTypeProperty> ItemTypeProperties { get; set; }
        public virtual ICollection<MemberItemProperty> MemberAssetProperties { get; set; }
    }

    public class ItemPropertyComparer : IEqualityComparer<ItemProperty>
    {
        public bool Equals(ItemProperty x, ItemProperty y)
        {
            if (x.Id == y.Id && x.Property.ToLower() == y.Property.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(ItemProperty obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
