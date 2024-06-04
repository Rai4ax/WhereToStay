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
    public class contactMessagesController : Controller
    {
        private readonly wtsDbContext _context;

        public contactMessagesController(wtsDbContext context)
        {
            _context = context;
        }

        // GET: contactMessages
        public async Task<IActionResult> Index()
        {
              return View(await _context.contactMessages.ToListAsync());
        }

        // GET: contactMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.contactMessages == null)
            {
                return NotFound();
            }

            var contactMessages = await _context.contactMessages
                .FirstOrDefaultAsync(m => m.messageID == id);
            if (contactMessages == null)
            {
                return NotFound();
            }

            return View(contactMessages);
        }

        // GET: contactMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: contactMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("messageID,username,email,subject,message")] contactMessages contactMessages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactMessages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactMessages);
        }

        // GET: contactMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.contactMessages == null)
            {
                return NotFound();
            }

            var contactMessages = await _context.contactMessages.FindAsync(id);
            if (contactMessages == null)
            {
                return NotFound();
            }
            return View(contactMessages);
        }

        // POST: contactMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("messageID,username,email,subject,message")] contactMessages contactMessages)
        {
            if (id != contactMessages.messageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactMessages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!contactMessagesExists(contactMessages.messageID))
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
            return View(contactMessages);
        }

        // GET: contactMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.contactMessages == null)
            {
                return NotFound();
            }

            var contactMessages = await _context.contactMessages
                .FirstOrDefaultAsync(m => m.messageID == id);
            if (contactMessages == null)
            {
                return NotFound();
            }

            return View(contactMessages);
        }

        // POST: contactMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.contactMessages == null)
            {
                return Problem("Entity set 'wtsDbContext.contactMessages'  is null.");
            }
            var contactMessages = await _context.contactMessages.FindAsync(id);
            if (contactMessages != null)
            {
                _context.contactMessages.Remove(contactMessages);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool contactMessagesExists(int? id)
        {
          return _context.contactMessages.Any(e => e.messageID == id);
        }
    }
}
