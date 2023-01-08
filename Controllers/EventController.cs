using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sportpad.Data;
using Sportpad.Models;

namespace Sportpad.Controllers
{
    public class EventController : Controller
    {
        private readonly SportpadContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private Location[] locations;
        private Sport[] sports;
        public EventController(SportpadContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
            
            
        }

        // GET: Event
        public async Task<IActionResult> Index()
        {
            
            var eventUser =  _context.EventUsers.ToArray();
            ViewBag.EventUser = eventUser;
            return View(_context.Events.ToList());
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            locations = _context.Locations.ToArray();
            sports = _context.Sports.ToArray();
            List<SelectListItem> allLocations = new List<SelectListItem>();
            List<SelectListItem> allSports = new List<SelectListItem>();
            foreach (var location in locations)
            {
                allLocations.Add(new SelectListItem { Value = location.Id.ToString(), Text = location.Name });
            }
            foreach (var sport in sports)
            {
                allSports.Add(new SelectListItem { Value = sport.Id.ToString(), Text = sport.Name });
            }

            ViewBag.sports = allSports;
            ViewBag.locations = allLocations;
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,MaximumNumber,LocationId,SportId")] Event @event)
        {
            var user = _userManager.GetUserName(User);
            if (ModelState.IsValid)
            {
                @event.Id = Guid.NewGuid();
                @event.Username = user;
                //@event.Username = 
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,MaximumNumber")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            return View(@event);
        }

        // GET: Event/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(Guid id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
