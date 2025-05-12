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
    public class FeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fees.ToListAsync());
        }

        // GET: Fees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fee = await _context.Fees
                .FirstOrDefaultAsync(m => m.FeeId == id);
            if (fee == null)
            {
                return NotFound();
            }
            // Get all clients assigned a fee
            ViewBag.Clients = from c in _context.Clients
                              join i in _context.Itinerarys on c.ClientId equals i.ClientId
                              join f in _context.Fees on i.FeeId equals f.FeeId
                              where f.FeeId == id
                              select c;

            return View(fee);
        }

        // GET: Fees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeeId,TotalDue,PaymentReason,DateIssued,PremiumMembership")] Fee fee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fee);
        }

        // GET: Fees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fee = await _context.Fees.FindAsync(id);
            if (fee == null)
            {
                return NotFound();
            }
            return View(fee);
        }

        // POST: Fees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeeId,TotalDue,PaymentReason,DateIssued,PremiumMembership")] Fee fee)
        {
            if (id != fee.FeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeeExists(fee.FeeId))
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
            return View(fee);
        }

        // GET: Fees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fee = await _context.Fees
                .FirstOrDefaultAsync(m => m.FeeId == id);
            if (fee == null)
            {
                return NotFound();
            }

            return View(fee);
        }

        // POST: Fees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fee = await _context.Fees.FindAsync(id);
            if (fee != null)
            {
                _context.Fees.Remove(fee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeeExists(int id)
        {
            return _context.Fees.Any(e => e.FeeId == id);
        }
    }
}
