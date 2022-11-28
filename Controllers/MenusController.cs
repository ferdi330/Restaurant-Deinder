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
    
    public class MenusController : Controller
    {
        private readonly DataDbContext _context;

        public MenusController(DataDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        // GET: Menus
        public async Task<IActionResult> Index()
        {
            var dataDbContext = _context.Menu.Include(m => m.MenuSoort);
            return View(await dataDbContext.ToListAsync());
        }

        // GET: Menus
        public async Task<IActionResult> Index2()
        {
            var dataDbContext = _context.Menu.Include(m => m.MenuSoort);
            return View(await dataDbContext.ToListAsync());
        }

        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        // GET: Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu
                .Include(m => m.MenuSoort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        // GET: Menus/Create
        public IActionResult Create()
        {
            ViewData["MenuSoortId"] = new SelectList(_context.MenuSoort, "Id", "Naam");
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Prijs,MenuSoortId")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuSoortId"] = new SelectList(_context.MenuSoort, "Id", "Naam", menu.MenuSoortId);
            return View(menu);
        }

        // GET: Menus/Edit/5
        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            ViewData["MenuSoortId"] = new SelectList(_context.MenuSoort, "Id", "Id", menu.MenuSoortId);
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Prijs,MenuSoortId")] Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.Id))
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
            ViewData["MenuSoortId"] = new SelectList(_context.MenuSoort, "Id", "Id", menu.MenuSoortId);
            return View(menu);
        }

        // GET: Menus/Delete/5
        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu
                .Include(m => m.MenuSoort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _context.Menu.FindAsync(id);
            _context.Menu.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
            return _context.Menu.Any(e => e.Id == id);
        }
    }
}
