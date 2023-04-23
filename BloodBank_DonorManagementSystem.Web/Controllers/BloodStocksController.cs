using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BloodBank_DonorManagementSystem.Web.Data;

namespace BloodBank_DonorManagementSystem.Web.Controllers
{
    public class BloodStocksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BloodStocksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BloodStocks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BloodStocks.Include(b => b.BloodType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BloodStocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BloodStocks == null)
            {
                return NotFound();
            }

            var bloodStock = await _context.BloodStocks
                .Include(b => b.BloodType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodStock == null)
            {
                return NotFound();
            }

            return View(bloodStock);
        }

        // GET: BloodStocks/Create
        public IActionResult Create()
        {
            ViewData["BloodTypeId"] = new SelectList(_context.BloodTypes, "Id", "Id");
            return View();
        }

        // POST: BloodStocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BloodTypeId,Quantity,Id")] BloodStock bloodStock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bloodStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BloodTypeId"] = new SelectList(_context.BloodTypes, "Id", "Id", bloodStock.BloodTypeId);
            return View(bloodStock);
        }

        // GET: BloodStocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BloodStocks == null)
            {
                return NotFound();
            }

            var bloodStock = await _context.BloodStocks.FindAsync(id);
            if (bloodStock == null)
            {
                return NotFound();
            }
            ViewData["BloodTypeId"] = new SelectList(_context.BloodTypes, "Id", "Id", bloodStock.BloodTypeId);
            return View(bloodStock);
        }

        // POST: BloodStocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BloodTypeId,Quantity,Id")] BloodStock bloodStock)
        {
            if (id != bloodStock.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodStockExists(bloodStock.Id))
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
            ViewData["BloodTypeId"] = new SelectList(_context.BloodTypes, "Id", "Id", bloodStock.BloodTypeId);
            return View(bloodStock);
        }

        // GET: BloodStocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BloodStocks == null)
            {
                return NotFound();
            }

            var bloodStock = await _context.BloodStocks
                .Include(b => b.BloodType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodStock == null)
            {
                return NotFound();
            }

            return View(bloodStock);
        }

        // POST: BloodStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BloodStocks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BloodStocks'  is null.");
            }
            var bloodStock = await _context.BloodStocks.FindAsync(id);
            if (bloodStock != null)
            {
                _context.BloodStocks.Remove(bloodStock);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloodStockExists(int id)
        {
          return (_context.BloodStocks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
