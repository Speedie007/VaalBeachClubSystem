using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Common.Enum;
using VaalBeachClub.Models.ViewModels.ViewModelComponents;

namespace VaalBeachClub.Models.ViewModels.Common
{
    public partial class AssetPropertyViewModel : BaseBeachClubEntityViewModel
    {
        public string AssestPropertyName { get; set; }
        public EnumAssetPropertyDataTypes DataType { get; set; }
        public string DataTypeName { get; set; }
        

        public bool IsAssetPropertRequired { get; set; }
    }

    public class AssetPropertyViewModelComparer : IEqualityComparer<AssetPropertyViewModel>
    {
        public bool Equals(AssetPropertyViewModel x, AssetPropertyViewModel y)
        {
            if (x.Id == y.Id && x.AssestPropertyName.ToLower() == y.AssestPropertyName.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(AssetPropertyViewModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
