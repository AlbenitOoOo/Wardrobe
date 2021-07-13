using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wardrobe.Data;
using Wardrobe.Models;

namespace Wardrobe.Controllers
{
    public class ClothsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClothsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cloths
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cloths.ToListAsync());
        }

        // GET: Cloths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloth = await _context.Cloths
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cloth == null)
            {
                return NotFound();
            }

            return View(cloth);
        }

        // GET: Cloths/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cloths/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] Cloth cloth)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cloth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cloth);
        }

        // GET: Cloths/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloth = await _context.Cloths.FindAsync(id);
            if (cloth == null)
            {
                return NotFound();
            }
            return View(cloth);
        }

        // POST: Cloths/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Cloth cloth)
        {
            if (id != cloth.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cloth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothExists(cloth.Id))
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
            return View(cloth);
        }

        // GET: Cloths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloth = await _context.Cloths
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cloth == null)
            {
                return NotFound();
            }

            return View(cloth);
        }

        // POST: Cloths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cloth = await _context.Cloths.FindAsync(id);
            _context.Cloths.Remove(cloth);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothExists(int id)
        {
            return _context.Cloths.Any(e => e.Id == id);
        }
    }
}
