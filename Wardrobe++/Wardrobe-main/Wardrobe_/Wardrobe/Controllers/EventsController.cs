using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcEvent.Models;
using Wardrobe.Data;

namespace Wardrobe.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(_context.Cloths.ToList());
        }

        //// GET: Events/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var events = await _context.Events
        //        .FirstOrDefaultAsync(m => m.EventID == id);
        //    if (events == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(events);
        //}

        //// GET: Events/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Events/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("EventID,Subject,Description,Start,End,ThemeColor,IsFullDay")] Events events)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(events);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(events);
        //}

        //// GET: Events/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var events = await _context.Events.FindAsync(id);
        //    if (events == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(events);
        //}

        //// POST: Events/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("EventID,Subject,Description,Start,End,ThemeColor,IsFullDay")] Events events)
        //{
        //    if (id != events.EventID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(events);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EventsExists(events.EventID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(events);
        //}

        //// GET: Events/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var events = await _context.Events
        //        .FirstOrDefaultAsync(m => m.EventID == id);
        //    if (events == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(events);
        //}

        //// POST: Events/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var events = await _context.Events.FindAsync(id);
        //    _context.Events.Remove(events);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool EventsExists(int id)
        //{
        //    return _context.Events.Any(e => e.EventID == id);
        //}

        [HttpGet]
        public JsonResult GetEvents()
        {
            var events = _context.Events.ToList();
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

            return new JsonResult(new { status = status  });
        }
    }
}
