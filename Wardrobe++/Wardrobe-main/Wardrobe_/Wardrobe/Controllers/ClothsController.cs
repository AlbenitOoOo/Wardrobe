using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wardrobe.Data;
using Wardrobe.Models;

namespace Wardrobe.Controllers
{
    [Authorize]
    public class ClothsController : Controller
    {
        private readonly ApplicationDbContext _context ;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;

        
        public ClothsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            this._hostEnvironment = hostEnvironment;
        }
        
        // GET: Cloths
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var applicationDbContext = _context.Cloths.Include(c => c.Color).Include(c => c.Kind).Where(c => c.Category.Equals(User.Identity.Name));

            var model = new ClothesSearchModel();
            model.Cloths = await applicationDbContext.ToListAsync();
            model.ColorCheckboxes = new List<CheckBoxListItem>();

            model.KindCheckboxes = new List<CheckBoxListItem>();

            var colors = _context.Color.ToList();
            foreach (Color c in colors) 
            {
                if (c.Description == user.UserName)
                {
                    model.ColorCheckboxes.Add(new CheckBoxListItem() { Id = c.Id, Name = c.Name });
            }
                }

            var kinds = _context.Kind.ToList();
            foreach (Kind c in kinds)
            {
                if (c.Description==user.UserName) { 
                model.KindCheckboxes.Add(new CheckBoxListItem() { Id = c.Id, Name = c.Name });
            }
            }


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ClothesSearchModel model)
        {
            //var applicationDbContext = _context.Cloths.Include(c => c.Color).Include(c => c.Kind).Join(model.ColorCheckboxes.Where(c => c.IsChecked), c => c.ColorId, cb => cb.Id, (c, cb) => new { Cloth = c }).Select(i => i.Cloth).Where(c => c.Category.Equals(User.Identity.Name));
            
            var Colors = model.ColorCheckboxes.Where(cb => cb.IsChecked).Select(c => c.Id).ToList();
            var Kinds = model.KindCheckboxes.Where(cb => cb.IsChecked).Select(c => c.Id).ToList();

            var applicationDbContext = _context.Cloths.Include(c => c.Color).Include(c => c.Kind)
                .Where(c => c.Category.Equals(User.Identity.Name)
                        && (string.IsNullOrEmpty(model.SearchName) || c.Title.Equals(model.SearchName))
                        && (Colors.Count == 0 || Colors.Contains(c.ColorId))
                        && (Kinds.Count == 0 || Kinds.Contains(c.KindId)));

            model.Cloths = await applicationDbContext.ToListAsync();

            return View(model);
        }
        
        // GET: Cloths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId<long>());
            

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



            ViewData["ColorId"] = new SelectList(_context.Color, "Id", "Name", "Description");
            ViewData["KindId"] = new SelectList(_context.Kind, "Id", "Name");
            ViewData["SelId"] = new SelectList(_context.Sel, "Id", "Name");
            return View();
        }
        

        // POST: Cloths/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Category,KindId,ColorId,SelId,ImageFile,CreatedOn")] Cloths cloths)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                
                string extension = Path.GetExtension(cloths.ImageFile.FileName);
                string fileName = Path.GetFileNameWithoutExtension(cloths.ImageFile.FileName);
                cloths.CoverImageUrl = fileName + DateTime.Now.ToString("yymm") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName + DateTime.Now.ToString("yymm") + extension);
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
            ViewData["SelId"] = new SelectList(_context.Sel, "Id", "Id", cloths.SelId);
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
            ViewData["SelId"] = new SelectList(_context.Sel, "Id", "Id", cloths.SelId);
            return View(cloths);
        }

        // POST: Cloths/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Category,KindId,ColorId,SelId,CoverImageUrl,CreatedOn")] Cloths cloths)
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
            ViewData["SelId"] = new SelectList(_context.Sel, "Id", "Id", cloths.SelId);
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
