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
        private IDictionary<string, Pet> _pets = new Dictionary<string, Pet>()
        {
            { "1", new Pet { Id = "1", Name = "Garfield", Kind = PetKind.Cat } },
            { "2", new Pet { Id = "2", Name = "Maru", Kind = PetKind.Cat } },
            { "3", new Pet { Id = "3", Name = "Mr. Pickles", Kind = PetKind.Dog } }
        };

        // GET: api/Pets
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return _pets.Values;
        }

        // GET: api/Pets/5
        [HttpGet("{id}", Name = "GetPets")]
        public Pet Get(string id)
        {
            return _pets[id];
        }

        // POST: api/Pets
        [HttpPost]
        public void Post([FromBody] Pet value)
        {
            var id = Guid.NewGuid().ToString();
            _pets.Add(id,
                new Pet
                {
                    Id = id,
                    Name = value.Name,
                    Kind = value.Kind,
                });
        }

        // PUT: api/Pets/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Pet value)
        {
            _pets[id] = value;
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _pets.Remove(id);
        }
    }
}