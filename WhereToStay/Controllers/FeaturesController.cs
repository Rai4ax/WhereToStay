using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhereToStay.Models;

namespace WhereToStay.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly wtsDbContext _context;

        public FeaturesController(wtsDbContext context)
        {
            _context = context;
        }

        // GET: Features
        public async Task<IActionResult> Index()
        {
              return View(await _context.Features.ToListAsync());
        }

        // GET: Features/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Features == null)
            {
                return NotFound();
            }

            var features = await _context.Features
                .FirstOrDefaultAsync(m => m.features_id == id);
            if (features == null)
            {
                return NotFound();
            }

            return View(features);
        }

        // GET: Features/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Features/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("features_id,has_parking,has_spa,has_wifi,has_bar,has_animals,has_gym")] Features features)
        {
            if (ModelState.IsValid)
            {
                _context.Add(features);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(features);
        }

        // GET: Features/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Features == null)
            {
                return NotFound();
            }

            var features = await _context.Features.FindAsync(id);
            if (features == null)
            {
                return NotFound();
            }
            return View(features);
        }

        // POST: Features/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("features_id,has_parking,has_spa,has_wifi,has_bar,has_animals,has_gym")] Features features)
        {
            if (id != features.features_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(features);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeaturesExists(features.features_id))
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
            return View(features);
        }

        // GET: Features/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Features == null)
            {
                return NotFound();
            }

            var features = await _context.Features
                .FirstOrDefaultAsync(m => m.features_id == id);
            if (features == null)
            {
                return NotFound();
            }

            return View(features);
        }

        // POST: Features/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Features == null)
            {
                return Problem("Entity set 'wtsDbContext.Features'  is null.");
            }
            var features = await _context.Features.FindAsync(id);
            if (features != null)
            {
                _context.Features.Remove(features);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeaturesExists(int id)
        {
          return _context.Features.Any(e => e.features_id == id);
        }
    }
}
