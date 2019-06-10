using System;
using System.Collections.Generic;
using System.Text;
using VaalBeachClub.Models.Domain.Items;
using VaalBeachClub.Models.ViewModels.Common;
using VaalBeachClub.Services.Assests;
using VaalBeachClub.Services.Common;
using VaalBreachClub.Web.Data.Intefaces;

namespace VaalBeachClub.ViewFactory.Common
{
    public interface IAssetViewFactory
    {

        /// <summary>
        /// Creates a AssetTypeViewModel Model and populates the model with linked and unlinked Properties
        /// </summary>
        /// <returns>AssetTypeViewModel populated with the linked and unlinked Asset Properties </returns>
        AssetTypeViewModel prepareAssetTypeViewModel(int AssetTypeID);
    }
    public class AssetViewFactory : IAssetViewFactory
    {

        #region Fields
        
        private readonly IAssetService _assetService;
        #endregion

        #region Cstor
        public AssetViewFactory(IAssetService assetService)
        {
            this._assetService = assetService;
        }
        #endregion
        public AssetTypeViewModel prepareAssetTypeViewModel(int AssetTypeID)
        {
            AssetTypeViewModel model = new AssetTypeViewModel();
            var _assetType = _assetService.GetAssestType(AssetTypeID);
            model.Id = _assetType.Id;
            model.AssestType = _assetType.Item;
            model.IsOnSiteStorageItem = _assetType.IsOnSiteStorageItem;
            model.ListOfLinkedAssetProperties = _assetService.ListLinkedAssetProperties(AssetTypeID);
            model.ListOfAvailableAssetProperties = _assetService.ListAvailableAssetProperties(AssetTypeID);
            model.ListOfAvailableAssestRequirements = _assetService.ListAvailableAssetRequirements(AssetTypeID);
            model.ListOfLinkedAssestRequirements = _assetService.ListLinkedAssetRequirements(AssetTypeID);
            return model;
        }
    }
}
