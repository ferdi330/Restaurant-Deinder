using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using D_Einder_MVC.Data;
using D_Einder_MVC.Models;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace D_Einder_MVC.Controllers
{
    public class ReserveringensController : Controller
    {
        private readonly DataDbContext _context;

        public ReserveringensController(DataDbContext context)
        {
            _context = context;
        }


        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        // GET: Reserveringens
        public async Task<IActionResult> Index()
        {
            var dataDbContext = _context.Reserveringen.Include(r => r.Tafel);
            return View(await dataDbContext.ToListAsync());
        }

        public async Task<IActionResult> Index2()
        {
            var dataDbContext = _context.Reserveringen.Include(r => r.Tafel);
            return View(await dataDbContext.ToListAsync());
        }

        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        public ActionResult IndexReserveringen()
        {
            var viewModel = new IndicatorViewModel
            {
                Reservaties = _context.Reserveringen.ToList(),
                Tafels = _context.Tafel.ToList()
            };
            return View("IndexReserveringen", viewModel);
        }


        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        // GET: Reserveringens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserveringen = await _context.Reserveringen
                .Include(r => r.Tafel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserveringen == null)
            {
                return NotFound();
            }

            ViewData["Orders"] = _context.Order.Where(o => o.ReserveringenId == id).ToList();
            return View(reserveringen);
        }


        // GET: Reserveringens/Create
        public IActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "8:30 - 9:00", Value = "8:30 - 9:00" });

            items.Add(new SelectListItem { Text = "9:00 - 9:30", Value = "9:00 - 9:30" });

            items.Add(new SelectListItem { Text = "9:30 - 10:00", Value = "9:30 - 10:00" });

            items.Add(new SelectListItem { Text = "10:00 - 10:30", Value = "10:00 - 10:30" });

            items.Add(new SelectListItem { Text = "10:30 - 11:00", Value = "10:30 - 11:00" });

            items.Add(new SelectListItem { Text = "11:00 - 11:30", Value = "11:00 - 11:30" });

            items.Add(new SelectListItem { Text = "11:30 - 12:00", Value = "11:30 - 12:00" });

            items.Add(new SelectListItem { Text = "12:00 - 12:30", Value = "12:00 - 12:30" });

            items.Add(new SelectListItem { Text = "12:30 - 1:00", Value = "12:30 - 1:00" });

            items.Add(new SelectListItem { Text = "1:00 - 1:30", Value = "1:00 - 1:30" });

            items.Add(new SelectListItem { Text = "1:30 - 2:00", Value = "1:30 - 2:00" });

            items.Add(new SelectListItem { Text = "2:00 - 2:30", Value = "2:00 - 2:30" });

            items.Add(new SelectListItem { Text = "2:30 - 3:00", Value = "2:30 - 3:00" });

            items.Add(new SelectListItem { Text = "3:00 - 3:30", Value = "3:00 - 3:30" });

            items.Add(new SelectListItem { Text = "3:30 - 4:00", Value = "3:30 - 4:00" });

            items.Add(new SelectListItem { Text = "4:00 - 4:30", Value = "4:00 - 4:30" });

            items.Add(new SelectListItem { Text = "4:30 - 5:00", Value = "4:30 - 5:00" });

            items.Add(new SelectListItem { Text = "5:00 - 5:30", Value = "5:00 - 5:30" });

            items.Add(new SelectListItem { Text = "5:30 - 6:00", Value = "5:30 - 6:00" });


            ViewBag.Tijd = items;


            ViewData["TafelId"] = new SelectList(_context.Tafel, "Id", "Naam");
            ViewData["Menus"] = _context.Menu.ToArray();
            return View();
        }

        // POST: Reserveringens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Tijd,Naam,Adress,Woonplaats,TafelId")] Reserveringen reserveringen)
        {
            ViewBag.ErrorMessage = "";
            if (ModelState.IsValid)
            {
                var tafeltijd = _context.Reserveringen.FirstOrDefault(x => x.TafelId == reserveringen.TafelId);

                if (tafeltijd == null)
                _context.Add(reserveringen);
                await _context.SaveChangesAsync();

                foreach (Menu menu in _context.Menu.ToArray())
                {
                    if (Request.Form.TryGetValue($"menu[{menu.Id}]", out StringValues menuAmount))
                    {
                        if (menuAmount.Any() && int.TryParse(menuAmount, out int amount))
                        {
                            if (amount == 0)
                                continue;

                            Order order = new()
                            {
                                //Id = (_context.Order.Last().Id + 1),
                                ReserveringenId = reserveringen.Id,
                                MenuNaam = menu.Naam,
                                Menu = menu,
                                Hoeveelheid = amount
                            };

                            _context.Order.Add(order);
                            await _context.SaveChangesAsync();
                        }
                    }
                }

                return RedirectToAction(nameof(Index2));
            }
            


            ViewData["TafelId"] = new SelectList(_context.Tafel, "Id", "Naam", reserveringen.TafelId);
            return View(reserveringen);
        }

        
        // GET: Reserveringens/Edit/5
        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserveringen = await _context.Reserveringen.FindAsync(id);
            if (reserveringen == null)
            {
                return NotFound();
            }

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "8:30 - 9:00", Value = "8:30 - 9:00" });

            items.Add(new SelectListItem { Text = "9:00 - 9:30", Value = "9:00 - 9:30" });

            items.Add(new SelectListItem { Text = "9:30 - 10:00", Value = "9:30 - 10:00" });

            items.Add(new SelectListItem { Text = "10:00 - 10:30", Value = "10:00 - 10:30" });

            items.Add(new SelectListItem { Text = "10:30 - 11:00", Value = "10:30 - 11:00" });

            items.Add(new SelectListItem { Text = "11:00 - 11:30", Value = "11:00 - 11:30" });

            items.Add(new SelectListItem { Text = "11:30 - 12:00", Value = "11:30 - 12:00" });

            items.Add(new SelectListItem { Text = "12:00 - 12:30", Value = "12:00 - 12:30" });

            items.Add(new SelectListItem { Text = "12:30 - 1:00", Value = "12:30 - 1:00" });

            items.Add(new SelectListItem { Text = "1:00 - 1:30", Value = "1:00 - 1:30" });

            items.Add(new SelectListItem { Text = "1:30 - 2:00", Value = "1:30 - 2:00" });

            items.Add(new SelectListItem { Text = "2:00 - 2:30", Value = "2:00 - 2:30" });

            items.Add(new SelectListItem { Text = "2:30 - 3:00", Value = "2:30 - 3:00" });

            items.Add(new SelectListItem { Text = "3:00 - 3:30", Value = "3:00 - 3:30" });

            items.Add(new SelectListItem { Text = "3:30 - 4:00", Value = "3:30 - 4:00" });

            items.Add(new SelectListItem { Text = "4:00 - 4:30", Value = "4:00 - 4:30" });

            items.Add(new SelectListItem { Text = "4:30 - 5:00", Value = "4:30 - 5:00" });

            items.Add(new SelectListItem { Text = "5:00 - 5:30", Value = "5:00 - 5:30" });

            items.Add(new SelectListItem { Text = "5:30 - 6:00", Value = "5:30 - 6:00" });


            ViewBag.Tijd = items;



            ViewData["TafelId"] = new SelectList(_context.Tafel, "Id", "Naam", reserveringen.TafelId);
            ViewData["Menus"] = _context.Menu.ToArray();
            return View(reserveringen);
        }



        // POST: Reserveringens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Tijd,Naam,Adress,Woonplaats,TafelId")] Reserveringen reserveringen)
        {
            if (id != reserveringen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var tafeltijd = _context.Reserveringen.FirstOrDefault(x => x.TafelId == reserveringen.TafelId);

                if (tafeltijd == null)
                    _context.Update(reserveringen);
                await _context.SaveChangesAsync();

                foreach (Menu menu in _context.Menu.ToArray())
                {
                    if (Request.Form.TryGetValue($"menu[{menu.Id}]", out StringValues menuAmount))
                    {
                        if (menuAmount.Any() && int.TryParse(menuAmount, out int amount))
                        {
                            if (amount == 0)
                                continue;

                            Order order = new()
                            {
                                //Id = (_context.Order.Last().Id + 1),
                                ReserveringenId = reserveringen.Id,
                                MenuNaam = menu.Naam,
                                Menu = menu,
                                Hoeveelheid = amount
                            };

                            _context.Order.Update(order);
                            await _context.SaveChangesAsync();
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["TafelId"] = new SelectList(_context.Tafel, "Id", "Naam", reserveringen.TafelId);
            return View(reserveringen);
        }

        // GET: Reserveringens/Delete/5
        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserveringen = await _context.Reserveringen
                .Include(r => r.Tafel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserveringen == null)
            {
                return NotFound();
            }

            return View(reserveringen);
        }

        // POST: Reserveringens/Delete/5
        [Authorize(Roles = "Personeel,Manager,SUPERADMIN")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserveringen = await _context.Reserveringen.FindAsync(id);
            _context.Reserveringen.Remove(reserveringen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReserveringenExists(int id)
        {
            return _context.Reserveringen.Any(e => e.Id == id);
        }
    }
}
