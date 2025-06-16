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
    public class NnhBooksController : Controller
    {
        private readonly NnhBookStoreContext _context;

        public NnhBooksController(NnhBookStoreContext context)
        {
            _context = context;
        }

        // GET: NnhBooks
        public async Task<IActionResult> NnhIndex()
        {
            var nnhBookStoreContext = _context.Books.Include(b => b.Category).Include(b => b.Publisher);
            return View(await nnhBookStoreContext.ToListAsync());
        }

        // GET: NnhBooks/Details/5
        public async Task<IActionResult> Details(string NnhId)
        {
            if (NnhId == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.BookId == NnhId);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: NnhBooks/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherId");
            return View();
        }

        // POST: NnhBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,Author,Release,Price,Description,Picture,PublisherId,CategoryId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NnhIndex));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", book.CategoryId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherId", book.PublisherId);
            return View(book);
        }

        // GET: NnhBooks/Edit/5
        public async Task<IActionResult> Edit(string NnhId)
        {
            if (NnhId == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(NnhId);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", book.CategoryId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherId", book.PublisherId);
            return View(book);
        }

        // POST: NnhBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string NnhId, [Bind("BookId,Title,Author,Release,Price,Description,Picture,PublisherId,CategoryId")] Book book)
        {
            if (NnhId != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", book.CategoryId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherId", book.PublisherId);
            return View(book);
        }

        // GET: NnhBooks/Delete/5
        public async Task<IActionResult> Delete(string NnhId)
        {
            if (NnhId == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.BookId == NnhId);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: NnhBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string NnhId)
        {
            var book = await _context.Books.FindAsync(NnhId);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NnhIndex));
        }

        private bool BookExists(string NnhId)
        {
            return _context.Books.Any(e => e.BookId == NnhId);
        }
    }
}
