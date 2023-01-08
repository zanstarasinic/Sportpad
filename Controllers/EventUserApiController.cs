using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sportpad.Data;
using Sportpad.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sportpad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventUserApiController : ControllerBase
    {
        private SportpadContext _context;
        public EventUserApiController(SportpadContext context) {
            _context = context; 
        }
        // GET: api/<EventUserApiController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventUser>>> GetEventUsers()
        {
            return await _context.EventUsers.ToListAsync();
        }

        // GET api/<EventUserApiController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventUser>> GetEventUser(int id)
        {
            var eventUser = await _context.EventUsers.FindAsync(id);  

            if (eventUser == null) {
                return NotFound();
            }
            return eventUser;
        }

        // POST api/<EventUserApiController>
        [HttpPost]
        public async Task<ActionResult<EventUser>> Post([FromBody] EventUser eventUser)
        {
            _context.EventUsers.Add(eventUser);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT api/<EventUserApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventUserApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
