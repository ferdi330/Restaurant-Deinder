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
    public class TafelsController : Controller
    {
        private readonly DataDbContext _context;

        public TafelsController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Tafels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tafel.ToListAsync());
        }

        // GET: Tafels
        public async Task<IActionResult> IndexTafels()
        {
            return View(await _context.Reserveringen.ToListAsync());
        }

        // GET: Tafels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tafel = await _context.Tafel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tafel == null)
            {
                return NotFound();
            }

            return View(tafel);
        }

        // GET: Tafels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tafels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam")] Tafel tafel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tafel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tafel);
        }

        // GET: Tafels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tafel = await _context.Tafel.FindAsync(id);
            if (tafel == null)
            {
                return NotFound();
            }
            return View(tafel);
        }

        // POST: Tafels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam")] Tafel tafel)
        {
            if (id != tafel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tafel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TafelExists(tafel.Id))
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
            return View(tafel);
        }

        // GET: Tafels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tafel = await _context.Tafel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tafel == null)
            {
                return NotFound();
            }

            return View(tafel);
        }

        // POST: Tafels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tafel = await _context.Tafel.FindAsync(id);
            _context.Tafel.Remove(tafel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TafelExists(int id)
        {
            return _context.Tafel.Any(e => e.Id == id);
        }
    }
}
