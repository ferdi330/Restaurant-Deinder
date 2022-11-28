using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using D_Einder_MVC.Data;
using D_Einder_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace D_Einder_MVC.Controllers
{
    [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
    public class GerechtensController : Controller
    {
        private readonly DataDbContext _context;

        public GerechtensController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Gerechtens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gerechten.ToListAsync());
        }

        public async Task<IActionResult> Index2()
        {
            return View(await _context.Gerechten.ToListAsync());
        }

        // GET: Gerechtens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechten = await _context.Gerechten
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerechten == null)
            {
                return NotFound();
            }

            return View(gerechten);
        }

        // GET: Gerechtens/Create
        public IActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Voorgerecht", Value = "Voorgerecht" });

            items.Add(new SelectListItem { Text = "Hoofdgerecht", Value = "Hoofdgerecht" });

            items.Add(new SelectListItem { Text = "Nagerecht", Value = "Nagerecht" });

            
            ViewBag.GerechtSoort = items;
            
            return View();
        }

        // POST: Gerechtens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,GerechtSoort")] Gerechten gerechten)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gerechten);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gerechten);
        }

        // GET: Gerechtens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechten = await _context.Gerechten.FindAsync(id);
            if (gerechten == null)
            {
                return NotFound();
            }

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Voorgerecht", Value = "Voorgerecht" });

            items.Add(new SelectListItem { Text = "Hoofdgerecht", Value = "Hoofdgerecht" });

            items.Add(new SelectListItem { Text = "Nagerecht", Value = "Nagerecht" });


            ViewBag.GerechtSoort = items;

            return View(gerechten);
        }

        // POST: Gerechtens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,GerechtSoort")] Gerechten gerechten)
        {
            if (id != gerechten.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerechten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerechtenExists(gerechten.Id))
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

            return View(gerechten);
        }

        // GET: Gerechtens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechten = await _context.Gerechten
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerechten == null)
            {
                return NotFound();
            }

            return View(gerechten);
        }

        // POST: Gerechtens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gerechten = await _context.Gerechten.FindAsync(id);
            _context.Gerechten.Remove(gerechten);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerechtenExists(int id)
        {
            return _context.Gerechten.Any(e => e.Id == id);
        }
    }
}
