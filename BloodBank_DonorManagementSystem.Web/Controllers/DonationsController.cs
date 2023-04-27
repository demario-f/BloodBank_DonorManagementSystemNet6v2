using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BloodBank_DonorManagementSystem.Web.Data;
using Microsoft.AspNetCore.Authorization;
using BloodBank_DonorManagementSystem.Web.Constants;

namespace BloodBank_DonorManagementSystem.Web.Controllers
{
    [Authorize]
    public class DonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Donations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Donations.Include(d => d.BloodType).Include(d => d.Donor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Donations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Donations == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations
                .Include(d => d.BloodType)
                .Include(d => d.Donor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }

        [Authorize(Roles = Roles.Administrator)]
        // GET: Donations/Create
        public IActionResult Create()
        {
            ViewData["BloodTypeId"] = new SelectList(_context.BloodTypes, "Id", "Id");
            ViewData["DonorId"] = new SelectList(_context.Donors, "Id", "Id");
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonorId,DonationDate,BloodTypeId,Quantity,ExpirationDate,Id")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BloodTypeId"] = new SelectList(_context.BloodTypes, "Id", "Id", donation.BloodTypeId);
            ViewData["DonorId"] = new SelectList(_context.Donors, "Id", "Id", donation.DonorId);
            return View(donation);
        }

        [Authorize(Roles = Roles.Administrator)]
        // GET: Donations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Donations == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations.FindAsync(id);
            if (donation == null)
            {
                return NotFound();
            }
            ViewData["BloodTypeId"] = new SelectList(_context.BloodTypes, "Id", "Id", donation.BloodTypeId);
            ViewData["DonorId"] = new SelectList(_context.Donors, "Id", "Id", donation.DonorId);
            return View(donation);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Edit(int id, [Bind("DonorId,DonationDate,BloodTypeId,Quantity,ExpirationDate,Id")] Donation donation)
        {
            if (id != donation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonationExists(donation.Id))
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
            ViewData["BloodTypeId"] = new SelectList(_context.BloodTypes, "Id", "Id", donation.BloodTypeId);
            ViewData["DonorId"] = new SelectList(_context.Donors, "Id", "Id", donation.DonorId);
            return View(donation);
        }

        [Authorize(Roles = Roles.Administrator)]
        // GET: Donations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Donations == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations
                .Include(d => d.BloodType)
                .Include(d => d.Donor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Donations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Donations'  is null.");
            }
            var donation = await _context.Donations.FindAsync(id);
            if (donation != null)
            {
                _context.Donations.Remove(donation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonationExists(int id)
        {
          return (_context.Donations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
