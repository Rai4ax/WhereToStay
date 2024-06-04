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
    public class HotelImagesController : Controller
    {
        private readonly wtsDbContext _context;

        public HotelImagesController(wtsDbContext context)
        {
            _context = context;
        }

        // GET: HotelImages
        public async Task<IActionResult> Index()
        {
            var wtsDbContext = _context.HotelImage.Include(h => h.Hotel).Include(h => h.Image);
            return View(await wtsDbContext.ToListAsync());
        }

        // GET: HotelImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HotelImage == null)
            {
                return NotFound();
            }

            var hotelImage = await _context.HotelImage
                .Include(h => h.Hotel)
                .Include(h => h.Image)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelImage == null)
            {
                return NotFound();
            }

            return View(hotelImage);
        }

        // GET: HotelImages/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_context.Hotels, "hotel_id", "hotel_id");
            ViewData["ImageId"] = new SelectList(_context.Images, "image_id", "image_id");
            return View();
        }

        // POST: HotelImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HotelId,ImageId")] HotelImage hotelImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "hotel_id", "hotel_id", hotelImage.HotelId);
            ViewData["ImageId"] = new SelectList(_context.Images, "image_id", "image_id", hotelImage.ImageId);
            return View(hotelImage);
        }

        // GET: HotelImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HotelImage == null)
            {
                return NotFound();
            }

            var hotelImage = await _context.HotelImage.FindAsync(id);
            if (hotelImage == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_context.Hotels, "hotel_id", "name", hotelImage.HotelId);
            ViewData["ImageId"] = new SelectList(_context.Images, "image_id", "description", hotelImage.ImageId);
            return View(hotelImage);
        }

        // POST: HotelImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HotelId,ImageId")] HotelImage hotelImage)
        {
            if (id != hotelImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelImageExists(hotelImage.Id))
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
            ViewData["HotelId"] = new SelectList(_context.Hotels, "hotel_id", "name", hotelImage.HotelId);
            ViewData["ImageId"] = new SelectList(_context.Images, "image_id", "description", hotelImage.ImageId);
            return View(hotelImage);
        }

        // GET: HotelImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HotelImage == null)
            {
                return NotFound();
            }

            var hotelImage = await _context.HotelImage
                .Include(h => h.Hotel)
                .Include(h => h.Image)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelImage == null)
            {
                return NotFound();
            }

            return View(hotelImage);
        }

        // POST: HotelImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HotelImage == null)
            {
                return Problem("Entity set 'wtsDbContext.HotelImage'  is null.");
            }
            var hotelImage = await _context.HotelImage.FindAsync(id);
            if (hotelImage != null)
            {
                _context.HotelImage.Remove(hotelImage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelImageExists(int id)
        {
          return _context.HotelImage.Any(e => e.Id == id);
        }
    }
}
