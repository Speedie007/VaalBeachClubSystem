using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaalBeachClub.Models.ViewModels.BoatHouses;
using VaalBeachClub.Services.Interfaces.BoatHouses;
using VaalBeachClub.ViewFactory.BoatHouses;

namespace VaalBreachClub.Web.Areas.Admin.Controllers.BoatHouses
{
    [Area("Admin")]
    public class BoatHouseAdminController : Controller
    {
        
        private readonly IBoatHouseModelFactory _boatHouseModelFactory;

        public BoatHouseAdminController(IBoatHouseModelFactory boatHouseModelFactory)
        {
            this._boatHouseModelFactory = boatHouseModelFactory;

        }
        // GET: BoatHouseAdmin
        public ActionResult Index()
        {
            BoatHouseInfoViewModel model = _boatHouseModelFactory.PrepareBoatHouseListModel();
            return View(model);
        }

        // GET: BoatHouseAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BoatHouseAdmin/Create
        public ActionResult Create()
        {
            //var model = _customerModelFactory.PrepareLoginModel(checkoutAsGuest);
            return View();
        }

        // POST: BoatHouseAdmin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BoatHouseAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BoatHouseAdmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BoatHouseAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BoatHouseAdmin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}