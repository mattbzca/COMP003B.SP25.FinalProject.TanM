using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.SP25.FinalProject.TanM.Data;
using COMP003B.SP25.FinalProject.TanM.Models;

namespace COMP003B.SP25.FinalProject.TanM.Controllers
{
    public class ItinerariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItinerariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Itineraries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Itinerarys.Include(i => i.Booking).Include(i => i.Client).Include(i => i.Fee).Include(i => i.Place);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Itineraries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itinerary = await _context.Itinerarys
                .Include(i => i.Booking)
                .Include(i => i.Client)
                .Include(i => i.Fee)
                .Include(i => i.Place)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itinerary == null)
            {
                return NotFound();
            }

            return View(itinerary);
        }

        // GET: Itineraries/Create
        public IActionResult Create()
        {
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookStatus");
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email");
            ViewData["FeeId"] = new SelectList(_context.Fees, "FeeId", "PaymentReason");
            ViewData["PlaceId"] = new SelectList(_context.Places, "PlaceId", "Description");
            return View();
        }

        // POST: Itineraries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,PlaceId,FeeId,BookingId")] Itinerary itinerary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itinerary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookStatus", itinerary.BookingId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email", itinerary.ClientId);
            ViewData["FeeId"] = new SelectList(_context.Fees, "FeeId", "PaymentReason", itinerary.FeeId);
            ViewData["PlaceId"] = new SelectList(_context.Places, "PlaceId", "Description", itinerary.PlaceId);
            return View(itinerary);
        }

        // GET: Itineraries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itinerary = await _context.Itinerarys.FindAsync(id);
            if (itinerary == null)
            {
                return NotFound();
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookStatus", itinerary.BookingId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email", itinerary.ClientId);
            ViewData["FeeId"] = new SelectList(_context.Fees, "FeeId", "PaymentReason", itinerary.FeeId);
            ViewData["PlaceId"] = new SelectList(_context.Places, "PlaceId", "Description", itinerary.PlaceId);
            return View(itinerary);
        }

        // POST: Itineraries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,PlaceId,FeeId,BookingId")] Itinerary itinerary)
        {
            if (id != itinerary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itinerary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItineraryExists(itinerary.Id))
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
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookStatus", itinerary.BookingId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email", itinerary.ClientId);
            ViewData["FeeId"] = new SelectList(_context.Fees, "FeeId", "PaymentReason", itinerary.FeeId);
            ViewData["PlaceId"] = new SelectList(_context.Places, "PlaceId", "Description", itinerary.PlaceId);
            return View(itinerary);
        }

        // GET: Itineraries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itinerary = await _context.Itinerarys
                .Include(i => i.Booking)
                .Include(i => i.Client)
                .Include(i => i.Fee)
                .Include(i => i.Place)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itinerary == null)
            {
                return NotFound();
            }

            return View(itinerary);
        }

        // POST: Itineraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itinerary = await _context.Itinerarys.FindAsync(id);
            if (itinerary != null)
            {
                _context.Itinerarys.Remove(itinerary);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItineraryExists(int id)
        {
            return _context.Itinerarys.Any(e => e.Id == id);
        }
    }
}
