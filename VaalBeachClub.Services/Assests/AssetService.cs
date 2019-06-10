using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VaalBeachClub.Models.Common.Enum;
using VaalBeachClub.Models.Domain.Interfaces;
using VaalBeachClub.Models.Domain.Items;
using VaalBeachClub.Models.ViewModels.Assets;
using VaalBeachClub.Models.ViewModels.Common;

namespace VaalBeachClub.Services.Assests
{
    public interface IAssetService
    {
        List<ItemType> ListAssestTypes();
        ItemType GetAssestType(int AssetTypeID);
        void UpdateAssetType(ItemType Entity);
        List<AssetPropertyViewModel> ListAvailableAssetProperties(int AssetTypeID);
        List<AssetPropertyViewModel> ListLinkedAssetProperties(int AssetTypeID);

        void LinkRequiredAsset(ItemTypeHierarchy Entity);
        void UnLinkRequiredAsset(ItemTypeHierarchy Entity);
        void LinkAssetTypeProperty(ItemTypeProperty Entity);

        void UnlinkAssetTypeProperty(ItemTypeProperty Entity);

        void UnlinkAssetTypeProperty(int ItemID, int ItemPropertyID);

        void AddAssetProperty(ItemProperty Entity);

        List<AssetTypeRequirementViewModel> ListAvailableAssetRequirements(int AssetTypeID);

        List<AssetTypeRequirementViewModel> ListLinkedAssetRequirements(int AssetTypeID);
    }
    public partial class AssetService : IAssetService
    {

        #region Fields

        private readonly IRepository<ItemType> _itemTypeRepository;
        private readonly IRepository<ItemTypeProperty> _itemTypePropertyRepository;
        private readonly IRepository<ItemProperty> _itemPropertyRepository;
        private readonly IRepository<ItemTypeHierarchy> _itemTypeHierarchyRepository;
        #endregion

        public AssetService(
                IRepository<ItemType> itemTypeRepository,
                IRepository<ItemTypeProperty> itemTypePropertyRepository,
                IRepository<ItemProperty> itemPropertyRepository,
                IRepository<ItemTypeHierarchy> itemTypeHierarchyRepository)
        {
            this._itemTypeRepository = itemTypeRepository;
            this._itemTypePropertyRepository = itemTypePropertyRepository;
            this._itemPropertyRepository = itemPropertyRepository;
            this._itemTypeHierarchyRepository = itemTypeHierarchyRepository;
        }

        public List<ItemType> ListAssestTypes()
        {
            var query = _itemTypeRepository.Table;

            return query.ToList();
        }

        public List<AssetPropertyViewModel> ListLinkedAssetProperties(int AssetTypeID)
        {
            var query = (from a in _itemTypePropertyRepository.Table
                        .Include(x => x.ItemProperty)
                        .Include(x => x.ItemProperty.ItemPropertyDataType)
                         where a.ItemID == AssetTypeID
                         orderby a.ItemProperty.Property
                         select new AssetPropertyViewModel()
                         {
                             Id = a.ItemProperty.Id,
                             AssestPropertyName = a.ItemProperty.Property,
                             IsAssetPropertRequired = a.ItemPropertyRequired,
                             DataTypeName = a.ItemProperty.ItemPropertyDataType.ItemPropertyDataTypeName,
                             DataType = (EnumAssetPropertyDataTypes)a.ItemProperty.ItemPropertyDataTypeID
                         }).ToList();

            return query.ToList<AssetPropertyViewModel>();
        }
        public List<AssetPropertyViewModel> ListAvailableAssetProperties(int AssetTypeID)
        {
            List<AssetPropertyViewModel> ListOfAvailableProperties = (from a in _itemPropertyRepository.Table
                                                                      .Include(x => x.ItemPropertyDataType)
                                                                      orderby a.Property
                                                                      select new AssetPropertyViewModel()
                                                                      {
                                                                          Id = a.Id,
                                                                          AssestPropertyName = a.Property,
                                                                          DataType = (EnumAssetPropertyDataTypes)a.ItemPropertyDataTypeID,
                                                                          DataTypeName = a.ItemPropertyDataType.ItemPropertyDataTypeName,
                                                                          IsAssetPropertRequired = false
                                                                      }).ToList<AssetPropertyViewModel>();

            return ListOfAvailableProperties.Except(
                ListLinkedAssetProperties(AssetTypeID), new AssetPropertyViewModelComparer())
                .ToList<AssetPropertyViewModel>();

        }

        public List<AssetTypeRequirementViewModel> ListAvailableAssetRequirements(int AssetTypeID)
        {
            List<AssetTypeRequirementViewModel> ListOfAssets = (from a in _itemTypeRepository.Table
                                                                select new AssetTypeRequirementViewModel
                                                                {
                                                                    Id = a.Id,
                                                                    AssestType = a.Item,
                                                                    OccupiesSameSpaceAsParent = false
                                                                }).ToList<AssetTypeRequirementViewModel>();

            return ListOfAssets.Except(
               ListLinkedAssetRequirements(AssetTypeID), new AssetTypeRequirementViewModelComparer())
               .ToList<AssetTypeRequirementViewModel>();
        }

        public List<AssetTypeRequirementViewModel> ListLinkedAssetRequirements(int AssetTypeID)
        {

            List<ItemType> ListOfAssets = (from a in _itemTypeRepository.Table
                                           select a).ToList();

            List<ItemTypeHierarchy> ListOfAssetRequirements = (from a in _itemTypeHierarchyRepository.Table
                                                               where a.ParentID == AssetTypeID
                                                               select a).ToList();

            var ListRtn = ListOfAssets.Join(
                ListOfAssetRequirements,
                Assets => Assets.Id,
                Requirements => Requirements.ChildID,
                (Assets, Requirements) => new AssetTypeRequirementViewModel
                {
                    Id = Assets.Id,
                    AssestType = Assets.Item,
                    OccupiesSameSpaceAsParent = Requirements.OccupiesSameSpaceAsParent
                }).ToList();

            return ListRtn;

        }

        public ItemType GetAssestType(int AssetTypeID)
        {
            var query = _itemTypeRepository.Table.Where(x => x.Id == AssetTypeID);
            return query.FirstOrDefault<ItemType>();
        }

        public void UpdateAssetType(ItemType Entity)
        {
            _itemTypeRepository.Update(Entity);
        }

        public void LinkAssetTypeProperty(ItemTypeProperty Entity)
        {
            _itemTypePropertyRepository.Insert(Entity);
        }

        public void UnlinkAssetTypeProperty(ItemTypeProperty Entity)
        {
            _itemTypePropertyRepository.Delete(Entity);
        }
        public void UnlinkAssetTypeProperty(int ItemID, int ItemPropertyID)
        {
            var _ItemTypeProperty = _itemTypePropertyRepository.Table
                 .Where(x => x.ItemID == ItemID && x.ItemPropertyID == ItemPropertyID);

            //var xx = _itemTypeRepository.Table.FromSql("Exec GetAllItemTypes").ToList();
            _itemTypePropertyRepository.Delete(_ItemTypeProperty);
        }


        public void AddAssetProperty(ItemProperty Entity)
        {
            _itemPropertyRepository.Insert(Entity);
        }

        public void LinkRequiredAsset(ItemTypeHierarchy Entity)
        {
            _itemTypeHierarchyRepository.Insert(Entity);
        }

        public void UnLinkRequiredAsset(ItemTypeHierarchy Entity)
        {
            _itemTypeHierarchyRepository.Delete(Entity);
        }
    }
}
