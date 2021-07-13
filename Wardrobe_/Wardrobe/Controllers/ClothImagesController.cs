using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wardrobe.Data;
using Wardrobe.Models;
using Wardrobe.ViewModel;

namespace Wardrobe.Controllers
{
    public class ClothImagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ClothImagesController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: ClothImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClothImages.ToListAsync());
        }

        // GET: ClothImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothImage = await _context.ClothImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothImage == null)
            {
                return NotFound();
            }

            return View(clothImage);
        }

        // GET: ClothImages/Create
        public IActionResult Create()
        {
            ProImages vm = new ProImages();
            ViewBag.images = new SelectList(_context.Cloths.ToList(), "Id", "Title");

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create (ProImages vm)
        {
            foreach (var item in vm.Images)
            {
                string stringFileName = UploadFile(item);
                var clothImage = new ClothImage
                {
                    ImageURL = stringFileName,
                    Cloth = vm.Cloth

                };
                _context.ClothImages.Add(clothImage);
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        private string UploadFile(IFormFile file)
        {
            string fileName = null;
            if (file != null)
            {
                string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return fileName;
        }
            


        // POST: ClothImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,ImageURL,Description,State,OutPut")] ClothImage clothImage)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(clothImage);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(clothImage);
        //}

        // GET: ClothImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothImage = await _context.ClothImages.FindAsync(id);
            if (clothImage == null)
            {
                return NotFound();
            }
            return View(clothImage);
        }

        // POST: ClothImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageURL,Description,State,OutPut")] ClothImage clothImage)
        {
            if (id != clothImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothImageExists(clothImage.Id))
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
            return View(clothImage);
        }

        // GET: ClothImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothImage = await _context.ClothImages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothImage == null)
            {
                return NotFound();
            }

            return View(clothImage);
        }

        // POST: ClothImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothImage = await _context.ClothImages.FindAsync(id);
            _context.ClothImages.Remove(clothImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothImageExists(int id)
        {
            return _context.ClothImages.Any(e => e.Id == id);
        }
    }
}
