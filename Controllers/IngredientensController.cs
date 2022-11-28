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
    public class IngredientensController : Controller
    {
        private readonly DataDbContext _context;

        public IngredientensController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Ingredientens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ingredienten.ToListAsync());
        }

        // GET: Ingredientens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredienten = await _context.Ingredienten
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingredienten == null)
            {
                return NotFound();
            }

            return View(ingredienten);
        }

        // GET: Ingredientens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredientens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Eenheid")] Ingredienten ingredienten)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredienten);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingredienten);
        }

        // GET: Ingredientens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredienten = await _context.Ingredienten.FindAsync(id);
            if (ingredienten == null)
            {
                return NotFound();
            }
            return View(ingredienten);
        }

        // POST: Ingredientens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Eenheid")] Ingredienten ingredienten)
        {
            if (id != ingredienten.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredienten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientenExists(ingredienten.Id))
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
            return View(ingredienten);
        }

        // GET: Ingredientens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredienten = await _context.Ingredienten
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingredienten == null)
            {
                return NotFound();
            }

            return View(ingredienten);
        }

        // POST: Ingredientens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredienten = await _context.Ingredienten.FindAsync(id);
            _context.Ingredienten.Remove(ingredienten);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientenExists(int id)
        {
            return _context.Ingredienten.Any(e => e.Id == id);
        }
    }
}
