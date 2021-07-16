using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wardrobe.Data;

namespace Wardrobe.Controllers
{
    public class ClothsController : Controller
    {
        private readonly ApplicationDbContext _context ;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ClothsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Cloths
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cloths.Include(c => c.Color).Include(c => c.Kind);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cloths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloths = await _context.Cloths
                .Include(c => c.Color)
                .Include(c => c.Kind)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cloths == null)
            {
                return NotFound();
            }

            return View(cloths);
        }

        // GET: Cloths/Create
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_context.Color, "Id", "Id");
            ViewData["KindId"] = new SelectList(_context.Kind, "Id", "Id");
            return View();
        }

        // POST: Cloths/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Category,KindId,ColorId,ImageFile,CreatedOn")] Cloths cloths)
        //CoverImageUrl = ImageName
        //cloths = imageModel
        //cloths.CoverImageUrl = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //cloths.CoverImageUrl = Guid.NewGuid().ToString() + "-";
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                
                string extension = Path.GetExtension(cloths.ImageFile.FileName);
                string fileName = Path.GetFileNameWithoutExtension(cloths.ImageFile.FileName);
                cloths.CoverImageUrl = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName + DateTime.Now.ToString("yymmssfff") + extension);
                using (var fileStream = new FileStream(path,FileMode.Create))
                {
                    await cloths.ImageFile.CopyToAsync(fileStream);
                }



                _context.Add(cloths);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_context.Color, "Id", "Id", cloths.ColorId);
            ViewData["KindId"] = new SelectList(_context.Kind, "Id", "Id", cloths.KindId);
            return View(cloths);
        }

        // GET: Cloths/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloths = await _context.Cloths.FindAsync(id);
            if (cloths == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_context.Color, "Id", "Name", cloths.ColorId);
            ViewData["KindId"] = new SelectList(_context.Kind, "Id", "Name", cloths.KindId);
            return View(cloths);
        }

        // POST: Cloths/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Category,KindId,ColorId,CoverImageUrl,CreatedOn")] Cloths cloths)
        {
            if (id != cloths.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cloths);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothsExists(cloths.Id))
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
            ViewData["ColorId"] = new SelectList(_context.Color, "Id", "Id", cloths.ColorId);
            ViewData["KindId"] = new SelectList(_context.Kind, "Id", "Id", cloths.KindId);
            return View(cloths);
        }

        // GET: Cloths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloths = await _context.Cloths
                .Include(c => c.Color)
                .Include(c => c.Kind)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cloths == null)
            {
                return NotFound();
            }

            return View(cloths);
        }

        // POST: Cloths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cloths = await _context.Cloths.FindAsync(id);

            //delete image from Image
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", cloths.CoverImageUrl);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            _context.Cloths.Remove(cloths);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothsExists(int id)
        {
            return _context.Cloths.Any(e => e.Id == id);
        }
    }
}
