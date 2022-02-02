using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wardrobe.Data;

namespace Wardrobe.Controllers
{
    [Authorize]
    public class ClothGalleriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClothGalleriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClothGalleries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClothGallery.Include(c => c.Cloth);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClothGalleries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothGallery = await _context.ClothGallery
                .Include(c => c.Cloth)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothGallery == null)
            {
                return NotFound();
            }

            return View(clothGallery);
        }

        // GET: ClothGalleries/Create
        public IActionResult Create()
        {
            ViewData["ClothId"] = new SelectList(_context.Cloths, "Id", "Id");
            return View();
        }

        // POST: ClothGalleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClothId,Name,URL")] ClothGallery clothGallery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clothGallery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClothId"] = new SelectList(_context.Cloths, "Id", "Id", clothGallery.ClothId);
            return View(clothGallery);
        }

        // GET: ClothGalleries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothGallery = await _context.ClothGallery.FindAsync(id);
            if (clothGallery == null)
            {
                return NotFound();
            }
            ViewData["ClothId"] = new SelectList(_context.Cloths, "Id", "Id", clothGallery.ClothId);
            return View(clothGallery);
        }

        // POST: ClothGalleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClothId,Name,URL")] ClothGallery clothGallery)
        {
            if (id != clothGallery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothGallery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothGalleryExists(clothGallery.Id))
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
            ViewData["ClothId"] = new SelectList(_context.Cloths, "Id", "Id", clothGallery.ClothId);
            return View(clothGallery);
        }

        // GET: ClothGalleries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothGallery = await _context.ClothGallery
                .Include(c => c.Cloth)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothGallery == null)
            {
                return NotFound();
            }

            return View(clothGallery);
        }

        // POST: ClothGalleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothGallery = await _context.ClothGallery.FindAsync(id);
            _context.ClothGallery.Remove(clothGallery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothGalleryExists(int id)
        {
            return _context.ClothGallery.Any(e => e.Id == id);
        }
    }
}
