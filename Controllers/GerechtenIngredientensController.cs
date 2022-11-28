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
    public class GerechtenIngredientensController : Controller
    {
        private readonly DataDbContext _context;

        public GerechtenIngredientensController(DataDbContext context)
        {
            _context = context;
        }

        // GET: GerechtenIngredientens
        public async Task<IActionResult> Index()
        {
            var dataDbContext = _context.GerechtenIngredienten.Include(g => g.Gerechten).Include(g => g.Ingredienten);
            return View(await dataDbContext.ToListAsync());
        }

        // GET: GerechtenIngredientens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechtenIngredienten = await _context.GerechtenIngredienten
                .Include(g => g.Gerechten)
                .Include(g => g.Ingredienten)
                .FirstOrDefaultAsync(m => m.GerechtenId == id);
            if (gerechtenIngredienten == null)
            {
                return NotFound();
            }

            return View(gerechtenIngredienten);
        }

        // GET: GerechtenIngredientens/Create
        public IActionResult Create()
        {
            ViewData["GerechtenId"] = new SelectList(_context.Gerechten, "Id", "Naam");
            ViewData["IngredientenId"] = new SelectList(_context.Ingredienten, "Id", "Naam");
            return View();
        }

        // POST: GerechtenIngredientens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GerechtenId,IngredientenId,Hoeveelheid")] GerechtenIngredienten gerechtenIngredienten)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gerechtenIngredienten);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GerechtenId"] = new SelectList(_context.Gerechten, "Id", "Naam", gerechtenIngredienten.GerechtenId);
            ViewData["IngredientenId"] = new SelectList(_context.Ingredienten, "Id", "Naam", gerechtenIngredienten.IngredientenId);
            return View(gerechtenIngredienten);
        }

        // GET: GerechtenIngredientens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechtenIngredienten = await _context.GerechtenIngredienten.FindAsync(id);
            if (gerechtenIngredienten == null)
            {
                return NotFound();
            }
            ViewData["GerechtenId"] = new SelectList(_context.Gerechten, "Id", "Id", gerechtenIngredienten.GerechtenId);
            ViewData["IngredientenId"] = new SelectList(_context.Ingredienten, "Id", "Id", gerechtenIngredienten.IngredientenId);
            return View(gerechtenIngredienten);
        }

        // POST: GerechtenIngredientens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GerechtenId,IngredientenId,Hoeveelheid")] GerechtenIngredienten gerechtenIngredienten)
        {
            if (id != gerechtenIngredienten.GerechtenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerechtenIngredienten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerechtenIngredientenExists(gerechtenIngredienten.GerechtenId))
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
            ViewData["GerechtenId"] = new SelectList(_context.Gerechten, "Id", "Id", gerechtenIngredienten.GerechtenId);
            ViewData["IngredientenId"] = new SelectList(_context.Ingredienten, "Id", "Id", gerechtenIngredienten.IngredientenId);
            return View(gerechtenIngredienten);
        }

        // GET: GerechtenIngredientens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerechtenIngredienten = await _context.GerechtenIngredienten
                .Include(g => g.Gerechten)
                .Include(g => g.Ingredienten)
                .FirstOrDefaultAsync(m => m.GerechtenId == id);
            if (gerechtenIngredienten == null)
            {
                return NotFound();
            }

            return View(gerechtenIngredienten);
        }

        // POST: GerechtenIngredientens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gerechtenIngredienten = await _context.GerechtenIngredienten.FindAsync(id);
            _context.GerechtenIngredienten.Remove(gerechtenIngredienten);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerechtenIngredientenExists(int id)
        {
            return _context.GerechtenIngredienten.Any(e => e.GerechtenId == id);
        }
    }
}
