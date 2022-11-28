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
    
    public class MenuGerechtensController : Controller
    {
        private readonly DataDbContext _context;

        public MenuGerechtensController(DataDbContext context)
        {
            _context = context;
        }

        // GET: MenuGerechtens

        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        public async Task<IActionResult> Index()
        {
            var dataDbContext = _context.MenuGerechten.Include(m => m.Gerechten).Include(m => m.Menus);
            return View(await dataDbContext.ToListAsync());
        }

        public async Task<IActionResult> Index2()
        {
            var dataDbContext = _context.MenuGerechten.Include(m => m.Gerechten).Include(m => m.Menus);
            return View(await dataDbContext.ToListAsync());
        }

        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        public async Task<IActionResult> KokOverzicht()
        {
            var dataDbContext = _context.MenuGerechten.Include(o => o.Menus).Include(o => o.Gerechten);

            ViewData["Ingredienten"] = _context.GerechtenIngredienten.Where(o => o.IngredientenId == o.IngredientenId).ToList();

            ViewData["Ingrediententype"] = _context.Ingredienten.ToArray();

            

            return View(await dataDbContext.ToListAsync());
        }

        // GET: MenuGerechtens/Details/5
        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuGerechten = await _context.MenuGerechten
                .Include(m => m.Gerechten)
                .Include(m => m.Menus)
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (menuGerechten == null)
            {
                return NotFound();
            }

            return View(menuGerechten);
        }

        // GET: MenuGerechtens/Create
        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        public IActionResult Create()
        {
            ViewData["GerechtenId"] = new SelectList(_context.Gerechten, "Id", "Naam");
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Naam");
            return View();
        }

        // POST: MenuGerechtens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GerechtenId,MenuId")] MenuGerechten menuGerechten)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuGerechten);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GerechtenId"] = new SelectList(_context.Gerechten, "Id", "Naam", menuGerechten.GerechtenId);
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Naam", menuGerechten.MenuId);
            return View(menuGerechten);
        }

        // GET: MenuGerechtens/Edit/5
        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuGerechten = await _context.MenuGerechten.FindAsync(id);
            if (menuGerechten == null)
            {
                return NotFound();
            }
            ViewData["GerechtenId"] = new SelectList(_context.Gerechten, "Id", "Naam", menuGerechten.GerechtenId);
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Naam", menuGerechten.MenuId);
            return View(menuGerechten);
        }

        // POST: MenuGerechtens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GerechtenId,MenuId")] MenuGerechten menuGerechten)
        {
            if (id != menuGerechten.MenuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuGerechten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuGerechtenExists(menuGerechten.MenuId))
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
            ViewData["GerechtenId"] = new SelectList(_context.Gerechten, "Id", "Naam", menuGerechten.GerechtenId);
            ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Naam", menuGerechten.MenuId);
            return View(menuGerechten);
        }

        // GET: MenuGerechtens/Delete/5
        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuGerechten = await _context.MenuGerechten
                .Include(m => m.Gerechten)
                .Include(m => m.Menus)
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (menuGerechten == null)
            {
                return NotFound();
            }

            return View(menuGerechten);
        }

        // POST: MenuGerechtens/Delete/5
        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuGerechten = await _context.MenuGerechten.FindAsync(id);
            _context.MenuGerechten.Remove(menuGerechten);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuGerechtenExists(int id)
        {
            return _context.MenuGerechten.Any(e => e.MenuId == id);
        }
    }
}
