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
    public class NnhAccountsController : Controller
    {
        private readonly NnhBookStoreContext _context;

        public NnhAccountsController(NnhBookStoreContext context)
        {
            _context = context;
        }

        // GET: NnhAccounts
        public async Task<IActionResult> NnhIndex()
        {
            return View(await _context.Accounts.ToListAsync());
        }

        // GET: NnhAccounts/Details/5
        public async Task<IActionResult> Details(string NnhId)
        {
            if (NnhId == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.AccountId == NnhId);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: NnhAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NnhAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,Username,Password,FullName,Picture,Email,Address,Phone,IsAdmin,Active")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NnhIndex));
            }
            return View(account);
        }

        // GET: NnhAccounts/Edit/5
        public async Task<IActionResult> Edit(string NnhId)
        {
            if (NnhId == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(NnhId);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: NnhAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string NnhId, [Bind("AccountId,Username,Password,FullName,Picture,Email,Address,Phone,IsAdmin,Active")] Account account)
        {
            if (NnhId != account.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountId))
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
            return View(account);
        }

        // GET: NnhAccounts/Delete/5
        public async Task<IActionResult> Delete(string NnhId)
        {
            if (NnhId == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.AccountId == NnhId);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: NnhAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string NnhId)
        {
            var account = await _context.Accounts.FindAsync(NnhId);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NnhIndex));
        }

        private bool AccountExists(string NnhId)
        {
            return _context.Accounts.Any(e => e.AccountId == NnhId);
        }
    }
}
