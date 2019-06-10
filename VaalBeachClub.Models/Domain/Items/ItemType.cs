using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Members;

namespace VaalBeachClub.Models.Domain.Items
{
    public partial class ItemType : BaseEntity
    {
        public ItemType()
        {
            ItemTypeProperties = new HashSet<ItemTypeProperty>();
            MemberItems = new HashSet<MemberItem>();
            ItemTypeHierarchy = new HashSet<ItemTypeHierarchy>();
        }

        public string Item { get; set; }

        public bool IsOnSiteStorageItem { get; set; }

        public virtual ICollection<ItemTypeProperty> ItemTypeProperties { get; set; }
        public virtual ICollection<MemberItem> MemberItems { get; set; }
        public virtual ICollection<ItemTypeHierarchy> ItemTypeHierarchy { get; set; }
    }

    public class AssetTypeComparer : IEqualityComparer<ItemType>
    {
        public bool Equals(ItemType x, ItemType y)
        {
            if (x.Id == y.Id && x.Item.ToLower() == y.Item.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(ItemType obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
