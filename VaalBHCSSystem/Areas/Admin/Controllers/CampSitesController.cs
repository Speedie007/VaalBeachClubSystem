using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaalBeachClub.Data;
using VaalBeachClub.Models.Domain.CampSites;
using VaalBeachClub.Models.ViewModels.CampStites;
using VaalBeachClub.Services.CampSites;
using VaalBeachClub.Services.Interfaces.CampSites;
using VaalBeachClub.ViewFactory.CampSites;

namespace VaalBreachClub.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CampSitesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICampSiteModelFactory _campSiteModelFactory;
        private readonly ICampSitesService _campSiteService;

        public CampSitesController(ApplicationDbContext context,
            ICampSiteModelFactory campSiteModelFactory,
             ICampSitesService campSitesService
            )
        {
            _context = context;
            this._campSiteService = campSitesService;
            this._campSiteModelFactory = campSiteModelFactory;
        }

        // GET: Admin/CampSites
        public async Task<IActionResult> Index()
        {
            return View(await _campSiteModelFactory.PrepareCampSiteListViewModel());
        }

        // GET: Admin/CampSites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = new CampSiteViewModel();
            //var campSite = await _context.CampSites
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (campSite == null)
            //{
            //    return NotFound();
            //}

            return View(model);
        }

        // GET: Admin/CampSites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CampSites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CampSiteNumber,hasElectricity,Id")] CampSite campSite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campSite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campSite);
        }

        // GET: Admin/CampSites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = new CampSiteViewModel();
            //var campSite = await _context.CampSites.FindAsync(id);
            //if (campSite == null)
            //{
            //    return NotFound();
            //}
            return View(model);
        }

        // POST: Admin/CampSites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CampSiteNumber,hasElectricity,Id")] CampSite campSite)
        {
            if (id != campSite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campSite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampSiteExists(campSite.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(campSite);
        }

        // GET: Admin/CampSites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var model = new CampSiteViewModel();
            var campSite = await _campSiteModelFactory.PrepareCampSiteViewModel(id);
            //    .FirstOrDefaultAsync(m => m.Id == id);
            if (campSite.Id == 0)
            {
                return NotFound();
            }

            return View(campSite);
        }

        // POST: Admin/CampSites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _campSiteService.GetCampSite(id);

            _campSiteService.DeleteCampSite(entity);
            //var campSite = await _context.CampSites.FindAsync(id);
            //_context.CampSites.Remove(campSite);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampSiteExists(int id)
        {
            Boolean Exists = true;

            var item = _campSiteService.GetCampSite(id);
            if (item == null)
                Exists = false;
            return Exists;
        }
    }
}
