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
    public class MenuSoortsController : Controller
    {
        private readonly DataDbContext _context;

        public MenuSoortsController(DataDbContext context)
        {
            _context = context;
        }

        // GET: MenuSoorts
        public async Task<IActionResult> Index()
        {
            return View(await _context.MenuSoort.ToListAsync());
        }

        // GET: MenuSoorts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuSoort = await _context.MenuSoort
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuSoort == null)
            {
                return NotFound();
            }

            return View(menuSoort);
        }

        // GET: MenuSoorts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MenuSoorts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam")] MenuSoort menuSoort)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuSoort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menuSoort);
        }

        // GET: MenuSoorts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuSoort = await _context.MenuSoort.FindAsync(id);
            if (menuSoort == null)
            {
                return NotFound();
            }
            return View(menuSoort);
        }

        // POST: MenuSoorts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam")] MenuSoort menuSoort)
        {
            if (id != menuSoort.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuSoort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuSoortExists(menuSoort.Id))
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
            return View(menuSoort);
        }

        // GET: MenuSoorts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuSoort = await _context.MenuSoort
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuSoort == null)
            {
                return NotFound();
            }

            return View(menuSoort);
        }

        // POST: MenuSoorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuSoort = await _context.MenuSoort.FindAsync(id);
            _context.MenuSoort.Remove(menuSoort);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuSoortExists(int id)
        {
            return _context.MenuSoort.Any(e => e.Id == id);
        }
    }
}
