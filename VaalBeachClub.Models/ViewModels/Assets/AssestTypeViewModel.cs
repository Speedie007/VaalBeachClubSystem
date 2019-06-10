using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.ViewModels.Assets;
using VaalBeachClub.Models.ViewModels.ViewModelComponents;

namespace VaalBeachClub.Models.ViewModels.Common
{
    public partial class AssetTypeViewModel : BaseBeachClubEntityViewModel
    {
        public AssetTypeViewModel()
        {
            ListOfLinkedAssetProperties = new List<AssetPropertyViewModel>();
            ListOfAvailableAssetProperties = new List<AssetPropertyViewModel>();
            ListOfAvailableAssestRequirements = new List<AssetTypeRequirementViewModel>();
            ListOfLinkedAssestRequirements = new List<AssetTypeRequirementViewModel>();
        }

        public virtual string AssestType { get; set; }
        public virtual bool IsOnSiteStorageItem { get; set; }

        public virtual List<AssetTypeRequirementViewModel> ListOfLinkedAssestRequirements { get; set; }
        public virtual List<AssetTypeRequirementViewModel> ListOfAvailableAssestRequirements { get; set; }
        public virtual List<AssetPropertyViewModel> ListOfLinkedAssetProperties { get; set; }
        public virtual List<AssetPropertyViewModel> ListOfAvailableAssetProperties { get; set; }
    }

    public class AssetTypeViewModelComparer : IEqualityComparer<AssetTypeViewModel>
    {
        public bool Equals(AssetTypeViewModel x, AssetTypeViewModel y)
        {
            if (x.Id == y.Id && x.AssestType.ToLower() == y.AssestType.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(AssetTypeViewModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
