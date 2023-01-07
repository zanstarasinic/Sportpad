using Microsoft.AspNetCore.Mvc;
using Sportpad.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sportpad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventApiController : ControllerBase
    {
        // GET: api/<EventApiController>
        [HttpGet]
        public Event[] Get()
        {
            return new Event[2];
        }

        // GET api/<EventApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EventApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
