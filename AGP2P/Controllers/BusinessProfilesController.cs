using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AGP2P.Data;
using AGP2P.Models;

namespace AGP2P.Controllers
{
    public class BusinessProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusinessProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BusinessProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.BusinessProfiles.ToListAsync());
        }

        // GET: BusinessProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessProfile = await _context.BusinessProfiles
                .FirstOrDefaultAsync(m => m.BusinessProfileId == id);
            if (businessProfile == null)
            {
                return NotFound();
            }

            return View(businessProfile);
        }

        // GET: BusinessProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessProfileId,BusinessName,Country,Town,Address,PhoneNumber")] BusinessProfile businessProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessProfile);
        }

        // GET: BusinessProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessProfile = await _context.BusinessProfiles.FindAsync(id);
            if (businessProfile == null)
            {
                return NotFound();
            }
            return View(businessProfile);
        }

        // POST: BusinessProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusinessProfileId,BusinessName,Country,Town,Address,PhoneNumber")] BusinessProfile businessProfile)
        {
            if (id != businessProfile.BusinessProfileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessProfileExists(businessProfile.BusinessProfileId))
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
            return View(businessProfile);
        }

        // GET: BusinessProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessProfile = await _context.BusinessProfiles
                .FirstOrDefaultAsync(m => m.BusinessProfileId == id);
            if (businessProfile == null)
            {
                return NotFound();
            }

            return View(businessProfile);
        }

        // POST: BusinessProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var businessProfile = await _context.BusinessProfiles.FindAsync(id);
            _context.BusinessProfiles.Remove(businessProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessProfileExists(int id)
        {
            return _context.BusinessProfiles.Any(e => e.BusinessProfileId == id);
        }
    }
}
