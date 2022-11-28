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
    public class OrdersController : Controller
    {
        private readonly DataDbContext _context;

        public OrdersController(DataDbContext context)
        {
            _context = context;
        }

        

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var dataDbContext = _context.Order.Include(o => o.Reserveringen);
            return View(await dataDbContext.ToListAsync());
        }

        public async Task<IActionResult> FinancieelOverzicht()
        {
            var dataDbContext = _context.Order.Include(o => o.Reserveringen);

            ViewData["Prijs"] = _context.Menu.Where(o => o.Prijs == o.Prijs).ToList();

            ViewData["DrinkBestellingen"] = _context.DrinkBestelling.ToArray();

            ViewData["Drink"] = _context.Drinks.ToArray();

            return View(await dataDbContext.ToListAsync());
        }

        public ActionResult TafelOverzicht()
        {
            var viewModel = new OmzetViewModel
            {
                Tafels = _context.Tafel.ToList(),
                Menuprijs = _context.Menu.ToList(),
                Drinkprijs = _context.Drinks.ToList(),
                Reservaties = _context.Reserveringen.ToList(),
                BesteldeDrinken = _context.DrinkBestelling.ToList(),
                BesteldeMenu = _context.Order.ToList()
                
            };

            ViewData["Prijs"] = _context.Menu.Where(o => o.Prijs == o.Prijs).ToList();

            ViewData["DrinkBestellingen"] = _context.DrinkBestelling.ToArray();

            ViewData["Drink"] = _context.Drinks.ToArray();

            return View("TafelOverzicht", viewModel);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Reserveringen)
                .FirstOrDefaultAsync(m => m.ReserveringenId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["ReserveringenId"] = new SelectList(_context.Reserveringen, "Id", "Id");
            ViewData["MenuNaam"] = new SelectList(_context.Menu, "Naam", "Naam");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MenuNaam,ReserveringenId,Hoeveelheid")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReserveringenId"] = new SelectList(_context.Reserveringen, "Id", "Id", order.ReserveringenId);
            ViewData["MenuNaam"] = new SelectList(_context.Menu, "Naam", "Naam");
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ReserveringenId"] = new SelectList(_context.Reserveringen, "Id", "Id", order.ReserveringenId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MenuNaam,ReserveringenId,Hoeveelheid")] Order order)
        {
            if (id != order.ReserveringenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.ReserveringenId))
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
            ViewData["ReserveringenId"] = new SelectList(_context.Reserveringen, "Id", "Id", order.ReserveringenId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Reserveringen)
                .FirstOrDefaultAsync(m => m.ReserveringenId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.ReserveringenId == id);
        }
    }
}
