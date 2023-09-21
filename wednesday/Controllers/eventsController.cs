using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace wednesday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class eventsController : ControllerBase
    {
        static List<Event> events = new List<Event> { new Event { Id = 1, Title = "default event1", Start = DateTime.Now }, new Event { Id = 2, Title = "default event2", Start = DateTime.Now }, new Event { Id = 3, Title = "default event3", Start = DateTime.Now } };
        static int count = 3;
        // GET: api/<eventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

        // GET api/<eventsController>/5
        //[HttpGet]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<eventsController>
        [HttpPost]
        public void Post([FromBody] Event eve)
        {
            events.Add(new Event { Id = count++, Title = eve.Title, Start = eve.Start });

        }

        // PUT api/<eventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event eve)
        {
            var ev = events.Find(e => e.Id == id);
            ev.Title = eve.Title;
            ev.Start = eve.Start;
        }

        // DELETE api/<eventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = events.Find(e => e.Id == id);
            events.Remove(eve);
        }
    }
}
