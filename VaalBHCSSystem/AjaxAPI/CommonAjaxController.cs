using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VaalBeachClub.Common;
using VaalBeachClub.Models.Domain.Common;
using VaalBeachClub.Models.Domain.Items;
using VaalBeachClub.Models.ViewModels.Common;
using VaalBeachClub.Services.Assests;
using VaalBeachClub.Services.Common;
using VaalBeachClub.ViewFactory.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VaalBeachClub.Web.AjaxAPI
{
    [Route("api/[controller]")]
    public class CommonAjaxController : Controller
    {
        #region Fields
        private readonly IAssetViewFactory _assetViewFactory;
        private readonly ICommonService _commonService;
        private readonly IAssetService _AssetService;
        #endregion

        #region Cstor
        public CommonAjaxController(
            IAssetViewFactory assetViewFactory,
            ICommonService commonService,
            IAssetService assetService
            )
        {
            this._commonService = commonService;
            this._assetViewFactory = assetViewFactory;
            this._AssetService = assetService;
        }
        #endregion
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return _commonService.ListCountries();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<controller>/5
        [HttpPost("ListRequiredAssetThatAreLinked")]
        [AutoValidateAntiforgeryToken]
        public AssetTypeViewModel ListLinkedRequiredAssest([FromBody]AssetTypeViewModel model)
        {
            return _assetViewFactory.prepareAssetTypeViewModel(model.Id);
        }

        // GET api/<controller>/5
        [HttpPost("ListRequiredAssetThatAreNotLinked")]
        [AutoValidateAntiforgeryToken]
        public AssetTypeViewModel ListUnLinkedRequiredAssest([FromBody]AssetTypeViewModel model)
        {

            return _assetViewFactory.prepareAssetTypeViewModel(model.Id);

        }

        [HttpPost("LinkAssetThatAreRequired")]
        [AutoValidateAntiforgeryToken]
        public JsonResult LinkRequiredAssest([FromBody]ItemTypeHierarchy model)
        {
            bool IsSuccesful = false;
            try
            {
                _AssetService.LinkRequiredAsset(model);
                IsSuccesful = true;
            }
            catch (VaalBeachClubException ex)
            {
            }
            return new JsonResult($"{{IsSuccesful:{IsSuccesful}}}");

        }
        [HttpPost("UnLinkAssetThatAreRequired")]
        [AutoValidateAntiforgeryToken]
        public JsonResult UnLinkAssetRequirement([FromBody]ItemTypeHierarchy model)
        {
            bool IsSuccesful = false;
            try
            {
                _AssetService.UnLinkRequiredAsset(model);
                IsSuccesful = true;
            }
            catch (VaalBeachClubException ex)
            {
            }
            return new JsonResult($"{{IsSuccesful:{IsSuccesful}}}");

        }
        // GET api/<controller>/5
        [HttpPost("ListAvailableAssetProperties")]
        [AutoValidateAntiforgeryToken]
        public AssetTypeViewModel AssestProperties([FromBody]AssetTypeViewModel model)
        {

            return _assetViewFactory.prepareAssetTypeViewModel(model.Id);

        }

        [HttpPost("LinkAvailableAssetProperties")]
        [AutoValidateAntiforgeryToken]
        public JsonResult LinkAssestProperties([FromBody]Rtn_AssetTypeProperty model)
        {
            bool IsSuccesful = false;
            try
            {

                _AssetService.LinkAssetTypeProperty(new ItemTypeProperty()
                {
                    ItemID = model.AssestID,
                    ItemPropertyID = model.AssetPropertyID,
                    ItemPropertyRequired = model.IsPropertryRequired
                });
                IsSuccesful = true;
            }
            catch (VaalBeachClubException ex)
            {
            }
            return new JsonResult($"{{IsSuccesful:{IsSuccesful}}}");

        }

        [HttpPost("UnLinkAssignedAssetProperties")]
        [AutoValidateAntiforgeryToken]
        public JsonResult UnLinkAssetProperties([FromBody]Rtn_AssetTypeProperty model)
        {
            bool IsSuccesful = false;
            try
            {
                _AssetService.UnlinkAssetTypeProperty(model.AssestID, model.AssetPropertyID);
                IsSuccesful = true;
            }
            catch (VaalBeachClubException ex)
            {
            }
            return new JsonResult($"{{IsSuccesful:{IsSuccesful}}}");

        }

        [HttpPost("GetAssetItem")]
        [AutoValidateAntiforgeryToken]
        public JsonResult GetAsset([FromBody]Rtn_AssetTypeProperty model)
        {
            ItemType AsssetRtn = new ItemType();
            try
            {
                AsssetRtn = _AssetService.GetAssestType(model.AssestID);
            }
            catch (VaalBeachClubException ex)
            {
            }
            return new JsonResult(AsssetRtn);

        }

       

        [HttpPost("UpdateAssetStorageStatus")]
        [AutoValidateAntiforgeryToken]
        public JsonResult UpdateAssetOnSiteStorageStatus([FromBody]ItemType model)
        {
            bool IsSuccesful = false;
            try
            {
                ItemType _ItemTypeToUpdate = _AssetService.GetAssestType(model.Id);
                _ItemTypeToUpdate.IsOnSiteStorageItem = model.IsOnSiteStorageItem;
                _AssetService.UpdateAssetType(_ItemTypeToUpdate);
                IsSuccesful = true;
            }
            catch (VaalBeachClubException ex)
            {
            }
            return new JsonResult(IsSuccesful);

        }
      

      
    }

    #region Internal Models
    public class Rtn_AssetTypeProperty
    {
        public int AssestID { get; set; }
        public int AssetPropertyID { get; set; }
        public bool IsPropertryRequired { get; set; }
    }
    #endregion
}
