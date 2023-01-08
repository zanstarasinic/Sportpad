using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sportpad.Data;
using Sportpad.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sportpad.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventApiController : ControllerBase
    {
        private SportpadContext _context;
        public EventApiController(SportpadContext context)
        {
            _context = context;
        }
        // GET: api/<EventApiController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        // GET api/<EventApiController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var Event = await _context.Events.FindAsync(id);

            if (Event == null)
            {
                return NotFound();
            }
            return Event;
        }

        // POST api/<EventApiController>
        [HttpPost]
        public async Task<ActionResult<Event>> Post([FromBody] Event e)
        {
            _context.Events.Add(e);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<EventApiController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> Put(Guid id, [FromBody] Event e)
        {
            if (id != e.Id)
            {
                return BadRequest();
            }
            _context.Entry(e).State= EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var Event = _context.Events.FindAsync(id);
                if (Event == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

            
        }

        // DELETE api/<EventApiController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> Delete(int id)
        {
            var Event = await _context.Events.FindAsync(id);
            if (Event == null)
            {
                return NotFound();
            }
            _context.Events.Remove(Event);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
