using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcEvent.Models;
using Wardrobe.Data;

namespace Wardrobe.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EventsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            return View(_context.Cloths.Where(c => c.Category.Equals(user.Id)).ToList());
        }

       

        [HttpGet]
        public JsonResult GetEvents()
        {
            var events = _context.Events.Where(c => c.Sorto.Equals(User.Identity.Name)).ToList();
            //var events = _context.Events.ToList();
            return new JsonResult(events);
        }

        [HttpPost]
        public JsonResult SaveEvent(Events e)
        {
            var status = false;

            if (e.EventID > 0)
            {
                //Update the event
                var v = _context.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                if (v != null)
                {
                    v.Subject = e.Subject;
                    v.Start = e.Start;
                    v.End = e.End;
                    v.Description = e.Description;
                    v.IsFullDay = e.IsFullDay;
                    v.ThemeColor = e.ThemeColor;
                    
                }
            }
            else
            {
                _context.Events.Add(e);
            }

            _context.SaveChanges();
            status = true;

            return new JsonResult(new { status = status });
        }



        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;

            {
                var v = _context.Events.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    _context.Events.Remove(v);
                    _context.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult(new { status = status });
        }
    }
}

