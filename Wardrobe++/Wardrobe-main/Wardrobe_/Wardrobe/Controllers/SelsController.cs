using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wardrobe.Data;

namespace Wardrobe.Controllers
{
    public class SelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sel.ToListAsync());
        }

        // GET: Sels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sel = await _context.Sel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sel == null)
            {
                return NotFound();
            }

            return View(sel);
        }

        // GET: Sels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Sel sel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sel);
        }

        // GET: Sels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sel = await _context.Sel.FindAsync(id);
            if (sel == null)
            {
                return NotFound();
            }
            return View(sel);
        }

        // POST: Sels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Sel sel)
        {
            if (id != sel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SelExists(sel.Id))
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
            return View(sel);
        }

        // GET: Sels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sel = await _context.Sel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sel == null)
            {
                return NotFound();
            }

            return View(sel);
        }

        // POST: Sels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sel = await _context.Sel.FindAsync(id);
            _context.Sel.Remove(sel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SelExists(int id)
        {
            return _context.Sel.Any(e => e.Id == id);
        }
    }
}
