using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeowsApi.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeowsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private static IDictionary<string, Reservation> _reservations = new Dictionary<string, Reservation>()
        {
            { "1", new Reservation { Id = "1", StartAt = DateTime.Parse("2023-09-11T09:00Z"), EndAt = DateTime.Parse("2023-09-12T19:00Z"), GuestsIds = new[] {"1"}} },
            { "2", new Reservation { Id = "2", StartAt = DateTime.Parse("2023-09-12T09:00Z"), EndAt = DateTime.Parse("2023-09-13T19:00Z"), GuestsIds = new[] {"2"}} },
            { "3", new Reservation { Id = "3", StartAt = DateTime.Parse("2023-09-13T06:06:06Z"), EndAt = DateTime.Parse("2023-09-16T16:06:06Z"), GuestsIds = new[] {"3"} } }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> Get()
        {
            return Ok(_reservations.Values);
        }

        [HttpGet("{id}", Name = "GetReservation")]
        public ActionResult<Reservation> Get(string id)
        {
            if (!_reservations.ContainsKey(id))
            {
                return NotFound();
            }
            return Ok(_reservations[id]);
        }

        [HttpPost]
        public ActionResult<Reservation> Post([FromBody] ReservationRequest value)
        {
            var id = Guid.NewGuid().ToString();
            var reservation = new Reservation
            {
                Id = id,
                StartAt = value.StartAt,
                EndAt = value.EndAt,
                GuestsIds = value.GuestsIds
            };

            _reservations.Add(id, reservation);

            return new CreatedAtActionResult(nameof(Get),
                "Reservations",
                new { id },
                reservation);
        }

        [HttpPut("{id}")]
        public ActionResult<Reservation> Put(string id, [FromBody] Reservation value)
        {
            if (!_reservations.ContainsKey(id))
            {
                return NotFound();
            }
            _reservations[id] = value;
            return new OkObjectResult(_reservations[id]);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (!_reservations.ContainsKey(id))
            {
                return NotFound();
            }
            _reservations.Remove(id);
            return Ok();
        }
    }
}
