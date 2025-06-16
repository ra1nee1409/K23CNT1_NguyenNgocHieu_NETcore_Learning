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
    public class NnhCategoriesController : Controller
    {
        private readonly NnhBookStoreContext _context;

        public NnhCategoriesController(NnhBookStoreContext context)
        {
            _context = context;
        }

        // GET: NnhCategories
        public async Task<IActionResult> NnhIndex()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: NnhCategories/Details/5
        public async Task<IActionResult> Details(int? NnhId)
        {
            if (NnhId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == NnhId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: NnhCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NnhCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NnhIndex));
            }
            return View(category);
        }

        // GET: NnhCategories/Edit/5
        public async Task<IActionResult> Edit(int? NnhId)
        {
            if (NnhId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(NnhId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: NnhCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int NnhId, [Bind("CategoryId,CategoryName")] Category category)
        {
            if (NnhId != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
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
            return View(category);
        }

        // GET: NnhCategories/Delete/5
        public async Task<IActionResult> Delete(int? NnhId)
        {
            if (NnhId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == NnhId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: NnhCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int NnhId)
        {
            var category = await _context.Categories.FindAsync(NnhId);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NnhIndex));
        }

        private bool CategoryExists(int NnhId)
        {
            return _context.Categories.Any(e => e.CategoryId == NnhId);
        }
    }
}