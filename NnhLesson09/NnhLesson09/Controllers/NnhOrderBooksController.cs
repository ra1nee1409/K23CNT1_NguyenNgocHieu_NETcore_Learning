using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NnhLesson09.Models;

namespace NnhLesson09.Controllers
{
    public class NnhOrderBooksController : Controller
    {
        private readonly NnhBookStoreContext _context;

        public NnhOrderBooksController(NnhBookStoreContext context)
        {
            _context = context;
        }

        // GET: NnhOrderBooks
        public async Task<IActionResult> NnhIndex()
        {
            var nnhBookStoreContext = _context.OrderBooks.Include(o => o.Account);
            return View(await nnhBookStoreContext.ToListAsync());
        }

        // GET: NnhOrderBooks/Details/5
        public async Task<IActionResult> Details(string NnhId)
        {
            if (NnhId == null)
            {
                return NotFound();
            }

            var orderBook = await _context.OrderBooks
                .Include(o => o.Account)
                .FirstOrDefaultAsync(m => m.OrderId == NnhId);
            if (orderBook == null)
            {
                return NotFound();
            }

            return View(orderBook);
        }

        // GET: NnhOrderBooks/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId");
            return View();
        }

        // POST: NnhOrderBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderDate,AccountId,ReceiveAddress,ReceivePhone,OrderReceive,Note,Status")] OrderBook orderBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NnhIndex));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", orderBook.AccountId);
            return View(orderBook);
        }

        // GET: NnhOrderBooks/Edit/5
        public async Task<IActionResult> Edit(string NnhId)
        {
            if (NnhId == null)
            {
                return NotFound();
            }

            var orderBook = await _context.OrderBooks.FindAsync(NnhId);
            if (orderBook == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", orderBook.AccountId);
            return View(orderBook);
        }

        // POST: NnhOrderBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string NnhId, [Bind("OrderId,OrderDate,AccountId,ReceiveAddress,ReceivePhone,OrderReceive,Note,Status")] OrderBook orderBook)
        {
            if (NnhId != orderBook.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderBookExists(orderBook.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(NnhIndex));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", orderBook.AccountId);
            return View(orderBook);
        }

        // GET: NnhOrderBooks/Delete/5
        public async Task<IActionResult> Delete(string NnhId)
        {
            if (NnhId == null)
            {
                return NotFound();
            }

            var orderBook = await _context.OrderBooks
                .Include(o => o.Account)
                .FirstOrDefaultAsync(m => m.OrderId == NnhId);
            if (orderBook == null)
            {
                return NotFound();
            }

            return View(orderBook);
        }

        // POST: NnhOrderBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string NnhId)
        {
            var orderBook = await _context.OrderBooks.FindAsync(NnhId);
            if (orderBook != null)
            {
                _context.OrderBooks.Remove(orderBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NnhIndex));
        }

        private bool OrderBookExists(string NnhId)
        {
            return _context.OrderBooks.Any(e => e.OrderId == NnhId);
        }
    }
}
