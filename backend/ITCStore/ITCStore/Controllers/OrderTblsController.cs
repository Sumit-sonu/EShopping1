using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITCStore.Models;

namespace ITCStore.Controllers
{
    public class OrderTblsController : Controller
    {
        private readonly ITCSTOREContext _context;

        public OrderTblsController(ITCSTOREContext context)
        {
            _context = context;
        }

        // GET: OrderTbls
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderTbls.ToListAsync());
        }

        // GET: OrderTbls/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderTbl = await _context.OrderTbls
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderTbl == null)
            {
                return NotFound();
            }

            return View(orderTbl);
        }

        // GET: OrderTbls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderNo,OrderDate,OrderTotal,CustomerId,ShippingDate,IsDelivered")] OrderTbl orderTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderTbl);
        }

        // GET: OrderTbls/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderTbl = await _context.OrderTbls.FindAsync(id);
            if (orderTbl == null)
            {
                return NotFound();
            }
            return View(orderTbl);
        }

        // POST: OrderTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OrderId,OrderNo,OrderDate,OrderTotal,CustomerId,ShippingDate,IsDelivered")] OrderTbl orderTbl)
        {
            if (id != orderTbl.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderTblExists(orderTbl.OrderId))
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
            return View(orderTbl);
        }

        // GET: OrderTbls/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderTbl = await _context.OrderTbls
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderTbl == null)
            {
                return NotFound();
            }

            return View(orderTbl);
        }

        // POST: OrderTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var orderTbl = await _context.OrderTbls.FindAsync(id);
            _context.OrderTbls.Remove(orderTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderTblExists(string id)
        {
            return _context.OrderTbls.Any(e => e.OrderId == id);
        }
    }
}
