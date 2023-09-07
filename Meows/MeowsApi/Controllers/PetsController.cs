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
    public class PetsController : ControllerBase
    {
        private static IDictionary<string, Pet> _pets = new Dictionary<string, Pet>()
        {
            { "1", new Pet { Id = "1", Name = "Garfield", Kind = PetKind.Cat, OwnerEmail = "jon.arbuckle@example.com" } },
            { "2", new Pet { Id = "2", Name = "Maru", Kind = PetKind.Cat, OwnerEmail = "mugumogu@example.co.jp" } },
            { "3", new Pet { Id = "3", Name = "Mr. Pickles", Kind = PetKind.Dog } }
        };

        // GET: api/Pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return Ok(_pets.Values);
        }

        // GET: api/Pets/5
        [HttpGet("{id}", Name = "GetPet")]
        public ActionResult<Pet> Get(string id)
        {
            if (!_pets.ContainsKey(id))
            {
                return NotFound();
            }
            return Ok(_pets[id]);
        }

        // POST: api/Pets
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] PetRequest value)
        {
            var id = Guid.NewGuid().ToString();
            var pet = new Pet
            {
                Id = id,
                Name = value.Name,
                Kind = value.Kind,
                OwnerEmail = value.OwnerEmail!
            };

            _pets.Add(id, pet);

            return new CreatedAtActionResult(nameof(Get),
                "Pets",
                new { id },
                pet);
        }

        // PUT: api/Pets/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(string id, [FromBody] Pet value)
        {
            if (!_pets.ContainsKey(id))
            {
                return NotFound();
            }
            _pets[id] = value;
            return new OkObjectResult(_pets[id]);

        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if (!_pets.ContainsKey(id))
            {
                return NotFound();
            }
            _pets.Remove(id);
            return Ok();
        }
    }
}