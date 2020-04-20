using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffet.Data;
using Morgenmadsbuffet.Models;

namespace Morgenmadsbuffet.Controllers
{
    public class BuffetsController : Controller
    {
        private readonly MorgenmadContext _context;

        public BuffetsController(MorgenmadContext context)
        {
            _context = context;
        }

        // GET: Buffets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Buffets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffet = await _context.Orders
                .FirstOrDefaultAsync(m => m.orderId == id);
            if (buffet == null)
            {
                return NotFound();
            }

            return View(buffet);
        }

        // GET: Buffets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buffets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("orderId,roomNum,adults,children,day,CheckedInAdult,CheckedInChildren")] Buffet buffet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buffet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buffet);
        }

        // GET: Buffets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffet = await _context.Orders.FindAsync(id);
            if (buffet == null)
            {
                return NotFound();
            }
            return View(buffet);
        }

        // POST: Buffets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("orderId,roomNum,adults,children,day,CheckedInAdult,CheckedInChildren")] Buffet buffet)
        {
            if (id != buffet.orderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buffet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuffetExists(buffet.orderId))
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
            return View(buffet);
        }

        // GET: Buffets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffet = await _context.Orders
                .FirstOrDefaultAsync(m => m.orderId == id);
            if (buffet == null)
            {
                return NotFound();
            }

            return View(buffet);
        }

        // POST: Buffets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buffet = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(buffet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuffetExists(int id)
        {
            return _context.Orders.Any(e => e.orderId == id);
        }
    }
}
