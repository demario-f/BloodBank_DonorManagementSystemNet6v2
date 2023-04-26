using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BloodBank_DonorManagementSystem.Web.Data;
using AutoMapper;
using BloodBank_DonorManagementSystem.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace BloodBank_DonorManagementSystem.Web.Controllers
{
    [Authorize]
    public class DonorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public DonorsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Donors
        public async Task<IActionResult> Index()
        {
            var Donors = mapper.Map<List<DonorsControllerVM>>(await _context.Donors.ToListAsync());
            return View(Donors);
        }

        // GET: Donors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Donors == null)
            {
                return NotFound();
            }

            var donor = await _context.Donors
                .Include(d => d.BloodType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donor == null)
            {
                return NotFound();
            }
            var DonorsControllerVM = mapper.Map<DonorsControllerVM>(donor);
            return View(DonorsControllerVM);
        }

        // GET: Donors/Create
        public IActionResult Create()
        {
            ViewData["BloodGroupNameId"] = new SelectList(_context.BloodTypes, "Id", "Id");
            return View();
        }

        // POST: Donors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DonorsControllerVM DonorsControllerVM)
        {
            if (ModelState.IsValid)
            {
                var Donor = mapper.Map<Donor>(DonorsControllerVM);
                _context.Add(Donor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BloodGroupNameId"] = new SelectList(_context.BloodTypes, "Id", "Id", DonorsControllerVM.BloodGroupNameId);
            return View(DonorsControllerVM);
        }

        // GET: Donors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Donors == null)
            {
                return NotFound();
            }

            var donor = await _context.Donors.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            ViewData["BloodGroupNameId"] = new SelectList(_context.BloodTypes, "Id", "Id", donor.BloodGroupNameId);
            var DonorsControllerVM = mapper.Map<DonorsControllerVM>(donor);
            return View(DonorsControllerVM);
        }

        // POST: Donors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DonorsControllerVM DonorsControllerVM)
        {
            if (id != DonorsControllerVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var Donor = mapper.Map<Donor>(DonorsControllerVM);
                    _context.Update(Donor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonorExists(DonorsControllerVM.Id))
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
            ViewData["BloodGroupNameId"] = new SelectList(_context.BloodTypes, "Id", "Id", DonorsControllerVM.BloodGroupNameId);
            return View(DonorsControllerVM);
        }

        // GET: Donors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Donors == null)
            {
                return NotFound();
            }

            var donor = await _context.Donors
                .Include(d => d.BloodType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donor == null)
            {
                return NotFound();
            }

            var DonorsControllerVM = mapper.Map<DonorsControllerVM>(donor);
            return View(DonorsControllerVM);
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Donors == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Donors'  is null.");
            }
            var donor = await _context.Donors.FindAsync(id);
            if (donor != null)
            {
                _context.Donors.Remove(donor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonorExists(int id)
        {
          return (_context.Donors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
