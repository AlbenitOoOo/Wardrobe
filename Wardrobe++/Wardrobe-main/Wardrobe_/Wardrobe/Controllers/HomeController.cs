﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Wardrobe.Models;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Wardrobe.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcEvent.Models;

namespace Wardrobe.Controllers
{
    

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;


        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Cloths
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new ClothesSearchModel();
            model.Cloths = _context.Cloths.Include(c => c.Color).Include(c => c.Kind).Where(c => c.SelId.Equals(1)).ToList();
            model.ColorCheckboxes = new List<CheckBoxListItem>();

            model.KindCheckboxes = new List<CheckBoxListItem>();

            var colors = _context.Color.ToList();
            foreach (Color c in colors)
            {
                model.ColorCheckboxes.Add(new CheckBoxListItem() { Id = c.Id, Name = c.Name });
            }

            var kinds = _context.Kind.ToList();
            foreach (Kind c in kinds)
            {
                model.KindCheckboxes.Add(new CheckBoxListItem() { Id = c.Id, Name = c.Name });
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
        [Authorize]
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

            var model = new ClothDetailsModel();
            model.Cloth = cloths;
            model.Messages = _context.Messages.Where(m => m.ClothID == cloths.Id).Join(_context.Users, m => m.UserID, u => u.Id, (m,u) => new Messages() {
                Id = m.Id,
                UserID = m.UserID, 
                ClothID = m.ClothID, 
                Date = m.Date, 
                Text = m.Text, 
                UserName = u.UserName
            }).ToList();

            return View(model);
        }


        // GET: Cloths/Create
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_context.Color, "Id", "Name");
            ViewData["KindId"] = new SelectList(_context.Kind, "Id", "Name");
            ViewData["SelId"] = new SelectList(_context.Sel, "Id", "Name");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Calendar()
        {
            ViewData["events"] = new[]
            {
                new Event { Id = 1, Title = "Video for Marisa", StartDate = "2020-11-14"},
                new Event { Id = 2, Title = "Preparation", StartDate = "2020-11-12"},
            };

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage(ClothDetailsModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            Messages msg = new Messages()
            {
                Text = model.NewMessage,
                Date = DateTime.Now,
                UserID = user.Id,
                ClothID = model.Cloth.Id
            };

            _context.Messages.Add(msg);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = model.Cloth.Id });
        }

    }

}

