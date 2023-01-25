using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelListMVC.Data;
using HotelListMVC.Models;

namespace HotelListMVC.Controllers
{
    public class GuestsController : Controller
    {
        private readonly HotelListMVCContext _context;

        public GuestsController(HotelListMVCContext context)
        {
            _context = context;
        }

        // GET: Guests
        public async Task<IActionResult> Index(string searchString, string searchLast)
        {
            var guests = from g in _context.Guest
                         select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                guests = guests.Where(s => s.FirstName!.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(searchLast))
            {
                guests = guests.Where(x => x.LastName!.Contains(searchLast));
            }

            
            return View(await guests.ToListAsync());
        }

        public async Task<ActionResult<IEnumerable<GuestsDTO>>> GetGuest()
        {
            return await _context.Guest
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        // GET: Guests/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {

            

            if (id == null || _context.Guest == null)
            {
                return NotFound();
            }

            var guest = await _context.Guest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // GET: Guests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PhoneNum,CheckInDate,CheckOutDate,CreditCardId")] Guest guest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guest);
        }

        // GET: Guests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Guest == null)
            {
                return NotFound();
            }

            var guest = await _context.Guest.FindAsync(id);
            if (guest == null)
            {
                return NotFound();
            }
            return View(guest);
        }

        // POST: Guests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNum,CheckInDate,CheckOutDate,CreditCardId")] Guest guest)
        {
            if (id != guest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestExists(guest.Id))
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
            return View(guest);
        }

        // GET: Guests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Guest == null)
            {
                return NotFound();
            }

            var guest = await _context.Guest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }

        // POST: Guests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Guest == null)
            {
                return Problem("Entity set 'HotelListMVCContext.Guest'  is null.");
            }
            var guest = await _context.Guest.FindAsync(id);
            if (guest != null)
            {
                _context.Guest.Remove(guest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestExists(int id)
        {
          return _context.Guest.Any(e => e.Id == id);
        }

        private static GuestsDTO ItemToDTO(Guest guest) =>
            new GuestsDTO
            {
                Id= guest.Id,
                FirstName= guest.FirstName,
                LastName= guest.LastName,
                PhoneNum= guest.PhoneNum,
                CheckInDate= guest.CheckInDate,
                CheckOutDate= guest.CheckOutDate,
            };
    }
}
