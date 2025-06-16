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
    public class NnhPublishersController : Controller
    {
        private readonly NnhBookStoreContext _context;

        public NnhPublishersController(NnhBookStoreContext context)
        {
            _context = context;
        }

        // GET: NnhPublishers
        public async Task<IActionResult> NnhIndex()
        {
            return View(await _context.Publishers.ToListAsync());
        }

        // GET: NnhPublishers/Details/5
        public async Task<IActionResult> Details(int? NnhId)
        {
            if (NnhId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == NnhId);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: NnhPublishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NnhPublishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NnhIndex));
            }
            return View(publisher);
        }

        // GET: NnhPublishers/Edit/5
        public async Task<IActionResult> Edit(int? NnhId)
        {
            if (NnhId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers.FindAsync(NnhId);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: NnhPublishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int NnhId, [Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (NnhId != publisher.PublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.PublisherId))
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
            return View(publisher);
        }

        // GET: NnhPublishers/Delete/5
        public async Task<IActionResult> Delete(int? NnhId)
        {
            if (NnhId == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == NnhId);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: NnhPublishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int NnhId)
        {
            var publisher = await _context.Publishers.FindAsync(NnhId);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NnhIndex));
        }

        private bool PublisherExists(int NnhId)
        {
            return _context.Publishers.Any(e => e.PublisherId == NnhId);
        }
    }
}
