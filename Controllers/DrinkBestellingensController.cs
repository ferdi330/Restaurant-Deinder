using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using D_Einder_MVC.Data;
using D_Einder_MVC.Models;

namespace D_Einder_MVC.Controllers
{
    public class DrinkBestellingensController : Controller
    {
        private readonly DataDbContext _context;

        public DrinkBestellingensController(DataDbContext context)
        {
            _context = context;
        }

        // GET: DrinkBestellingens
        public async Task<IActionResult> Index()
        {
            var dataDbContext = _context.DrinkBestelling.Include(d => d.Drink).Include(d => d.Tafel);
            return View(await dataDbContext.ToListAsync());
        }

        // GET: DrinkBestellingens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drinkBestellingen = await _context.DrinkBestelling
                .Include(d => d.Drink)
                .Include(d => d.Tafel)
                .FirstOrDefaultAsync(m => m.TafelId == id);
            if (drinkBestellingen == null)
            {
                return NotFound();
            }

            return View(drinkBestellingen);
        }

        // GET: DrinkBestellingens/Create
        public IActionResult Create()
        {
            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "Name");
            ViewData["TafelId"] = new SelectList(_context.Tafel, "Id", "Naam");
            return View();
        }

        // POST: DrinkBestellingens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TafelId,DrinkId,Aantal")] DrinkBestellingen drinkBestellingen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drinkBestellingen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "Name", drinkBestellingen.DrinkId);
            ViewData["TafelId"] = new SelectList(_context.Tafel, "Id", "Naam", drinkBestellingen.TafelId);
            return View(drinkBestellingen);
        }

        // GET: DrinkBestellingens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drinkBestellingen = await _context.DrinkBestelling.FindAsync(id);
            if (drinkBestellingen == null)
            {
                return NotFound();
            }
            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "Name", drinkBestellingen.DrinkId);
            ViewData["TafelId"] = new SelectList(_context.Tafel, "Id", "Naam", drinkBestellingen.TafelId);
            return View(drinkBestellingen);
        }

        // POST: DrinkBestellingens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TafelId,DrinkId,Aantal")] DrinkBestellingen drinkBestellingen)
        {
            if (id != drinkBestellingen.TafelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drinkBestellingen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrinkBestellingenExists(drinkBestellingen.TafelId))
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
            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "Name", drinkBestellingen.DrinkId);
            ViewData["TafelId"] = new SelectList(_context.Tafel, "Id", "Naam", drinkBestellingen.TafelId);
            return View(drinkBestellingen);
        }

        // GET: DrinkBestellingens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drinkBestellingen = await _context.DrinkBestelling
                .Include(d => d.Drink)
                .Include(d => d.Tafel)
                .FirstOrDefaultAsync(m => m.TafelId == id);
            if (drinkBestellingen == null)
            {
                return NotFound();
            }

            return View(drinkBestellingen);
        }

        // POST: DrinkBestellingens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drinkBestellingen = await _context.DrinkBestelling.FindAsync(id);
            _context.DrinkBestelling.Remove(drinkBestellingen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrinkBestellingenExists(int id)
        {
            return _context.DrinkBestelling.Any(e => e.TafelId == id);
        }
    }
}
