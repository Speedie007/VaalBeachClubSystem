using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaalBeachClub.Data;
using VaalBeachClub.Models.Domain.BoatHouses;

namespace VaalBreachClub.Web.Controllers.BoatHouses
{
    public class BoatHousesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoatHousesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BoatHouses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BoatHouses.Include(b => b.BoatHouseSize);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BoatHouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boatHouse = await _context.BoatHouses
                .Include(b => b.BoatHouseSize)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boatHouse == null)
            {
                return NotFound();
            }

            return View(boatHouse);
        }

        // GET: BoatHouses/Create
        public IActionResult Create()
        {
            ViewData["BoatHouseSizeID"] = new SelectList(_context.BoatHouseSizes, "Id", "Id");
            return View();
        }

        // POST: BoatHouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BoatHouseNumber,BoatHouseSizeID,Id")] BoatHouse boatHouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boatHouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoatHouseSizeID"] = new SelectList(_context.BoatHouseSizes, "Id", "Id", boatHouse.BoatHouseSizeID);
            return View(boatHouse);
        }

        // GET: BoatHouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boatHouse = await _context.BoatHouses.FindAsync(id);
            if (boatHouse == null)
            {
                return NotFound();
            }
            ViewData["BoatHouseSizeID"] = new SelectList(_context.BoatHouseSizes, "Id", "Id", boatHouse.BoatHouseSizeID);
            return View(boatHouse);
        }

        // POST: BoatHouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BoatHouseNumber,BoatHouseSizeID,Id")] BoatHouse boatHouse)
        {
            if (id != boatHouse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boatHouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoatHouseExists(boatHouse.Id))
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
            ViewData["BoatHouseSizeID"] = new SelectList(_context.BoatHouseSizes, "Id", "Id", boatHouse.BoatHouseSizeID);
            return View(boatHouse);
        }

        // GET: BoatHouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boatHouse = await _context.BoatHouses
                .Include(b => b.BoatHouseSize)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boatHouse == null)
            {
                return NotFound();
            }

            return View(boatHouse);
        }

        // POST: BoatHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boatHouse = await _context.BoatHouses.FindAsync(id);
            _context.BoatHouses.Remove(boatHouse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoatHouseExists(int id)
        {
            return _context.BoatHouses.Any(e => e.Id == id);
        }
    }
}
