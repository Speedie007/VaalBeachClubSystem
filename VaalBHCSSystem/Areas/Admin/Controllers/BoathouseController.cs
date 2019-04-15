using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VaalBeachClub.Models.Common;
using VaalBeachClub.Models.Domain.BoatHouses;
using VaalBeachClub.Models.ViewModels.BoatHouses;
using VaalBeachClub.Services.BoatHouses;
using VaalBeachClub.ViewFactory.BoatHouses;
using Microsoft.AspNetCore.Http;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace VaalBreachClub.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BoathouseController : Controller
    {

        #region Fields
        private readonly IBoatHouseModelFactory _boatHouseModelFactory;
        private IEntityCRUDResponse _entityCRUDResponse;
        private IBoatHouseService _boatHouseService;

        #endregion

        #region Cstor
        public BoathouseController(
            IBoatHouseModelFactory boatHouseModelFactory,
            IEntityCRUDResponse entityCRUDResponse,
            IBoatHouseService boatHouseService
            )
        {
            this._boatHouseModelFactory = boatHouseModelFactory;
            this._entityCRUDResponse = entityCRUDResponse;
            this._boatHouseService = boatHouseService;
        }
        #endregion

        #region BoatHouses
        [HttpGet]
        public IActionResult BoatHouses()
        {

            return View(_boatHouseModelFactory.PrepareBoatHouseListModel());
        }
        public IActionResult AddBoatHouses()
        {
            return View(_boatHouseModelFactory.PrepareAddBoatHouseModel());
        }
        [HttpPost]
        public IActionResult AddBoatHouses(BoatHouseInfoViewModel request)
        {
            BoatHouse Entity = new BoatHouse()
            {
                BoatHouseNumber = request.BoatHouseNumber,
                BoatHouseSizeID = request.BoatHouseSizeID
            };
            _boatHouseService.AddBoatHouse(Entity);
            return RedirectToAction("BoatHouses");
        }

        [HttpGet]
        public IActionResult EditBoatHouses(int BoatHouseID)
        {
            return View(_boatHouseModelFactory.PrepareEditBoatHouseModel(BoatHouseID));
        }
        [HttpPost]
        public IActionResult EditBoatHouses(BoatHouseInfoViewModel Entity)
        {


            return RedirectToAction("EditBoatHouses", new { BoatHouseID = Entity.Id });
        }
        #endregion
        #region Boat House Sizes

        [HttpGet]
        public IActionResult BoatHousesSizes()
        {
            return View(_boatHouseModelFactory.PrepareBostHouseSizeViewModel());
        }
        public IActionResult AddBoatHouseSize([FromBody] BoatHouseSizeViewModel request)
        {
            _entityCRUDResponse = _boatHouseService.AddBoatHouseSize(new BoatHouseSize()
            {
                Id = request.Id,
                Description = request.Description,
                Cost = Convert.ToDecimal(request.aCost),
                Hieght = Convert.ToDecimal(request.aHieght),
                Length = Convert.ToDecimal(request.aLength),
                Width = Convert.ToDecimal(request.aWidth)
            });

            return new JsonResult(_entityCRUDResponse);

        }

        [HttpGet]
        public IActionResult EditBoatHouseSize(int BoatHouseID)
        {
            var model = _boatHouseModelFactory.PrepareEditBoatHouseSizeViewModel(BoatHouseID);
            return View(model);
        }

        [HttpPost]

        public IActionResult EditBoatHouseSize(BoatHouseSizeViewModel request)
        {

            var cxxx = request.aCost;

            _boatHouseService.UpdateBoatHouseSize(new BoatHouseSize()
            {
                Id = request.Id,
                Description = request.Description,
                Cost = Convert.ToDecimal(request.aCost.Replace(".", ",")),
                Hieght = Convert.ToDecimal(request.aHieght.Replace(".", ",")),
                Length = Convert.ToDecimal(request.aLength.Replace(".", ",")),
                Width = Convert.ToDecimal(request.aWidth.Replace(".", ","))
            });
            return RedirectToAction("EditBoatHouseSize", new { BoatHouseID = request.Id });
        }

        #endregion

    }
}