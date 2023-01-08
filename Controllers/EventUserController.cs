using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sportpad.Data;
using Sportpad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportpad.Controllers
{
    public class EventUserController : Controller
    {
        private readonly SportpadContext _context;
        public EventUserController(SportpadContext context) {
            _context = context;
        }
        // GET: EventUserController
        public async Task<IActionResult> Index()
        {

            return View(await _context.EventUsers.ToListAsync());
        }

        // GET: EventUserController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            
            return View();
        }

        // GET: EventUserController/Create
        public async Task<IActionResult> Create(Guid Id, Guid Name)
        {
            EventUser eventUser = new EventUser();
            if (ModelState.IsValid)
            {
                eventUser.Id = Guid.NewGuid();
                eventUser.UserId = Name;
                eventUser.EventId = Id;
                //eventUser.Username = 
                _context.Add(eventUser);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Event");
            }
            return Ok();
        }

        // POST: EventUserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return View();
            }
        }

        // GET: EventUserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventUserController/Delete/5
        //Name = user Id = EVENT
        public async Task<IActionResult> Delete(Guid Id, Guid Name)
        {
            var EventUser = _context.EventUsers.ToArray();
           // bool uid = EventUser[0].UserId == Name;
           // bool eid = EventUser[0].EventId == Id;
            var match = EventUser.Where(x => x.UserId == Name && x.EventId == Id).FirstOrDefault();


            //var @event = await _context.Events
            //  .FirstOrDefaultAsync(m => m.Id == id);



            if (match == null)
            {
                return RedirectToAction("Index", "Event");
            }
            if (match != null)
            {
                _context.EventUsers.Remove((EventUser)match);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Event");
        }

        // POST: EventUserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Index", "Event");
            }
            catch
            {
                return View();
            }
        }
    }
}
