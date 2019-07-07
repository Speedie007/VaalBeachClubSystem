using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain;

namespace VaalBeachClub.Models.ViewModels.Assets
{
    public class AssetTypeRequirementViewModel : BaseEntity
    {
        public virtual string AssestType { get; set; }
        public virtual bool OccupiesSameSpaceAsParent { get; set; }
        public virtual bool IsOptional { get; set; }
    }

    public class AssetTypeRequirementViewModelComparer : IEqualityComparer<AssetTypeRequirementViewModel>
    {
        public bool Equals(AssetTypeRequirementViewModel x, AssetTypeRequirementViewModel y)
        {
            if (x.Id == y.Id && x.AssestType.ToLower() == y.AssestType.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(AssetTypeRequirementViewModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
