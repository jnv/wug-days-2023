using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeowsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        // GET: api/Reservations
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Reservations/5
        [HttpGet("{id}", Name = "GetReservations")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reservations
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Reservations/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
