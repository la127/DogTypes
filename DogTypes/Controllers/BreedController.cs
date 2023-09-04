using DogTypes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreeds.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        private readonly DogDbContext _context;

        public BreedController(DogDbContext context)
        {
            _context = context;
        }

        // GET: api/Breeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Breed>>> GetBreeds()
        {
            var breeds = await _context.Breeds.ToListAsync();
            return Ok(breeds);
        }

        // GET: api/Breeds/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Breed>> GetBreed(int id)
        {
            var breed = await _context.Breeds.FindAsync(id);

            if (breed == null)
            {
                return NotFound();
            }

            return Ok(breed);
        }

        // POST: api/Breeds
        [HttpPost]
        public async Task<ActionResult<Breed>> CreateBreed(Breed breed)
        {
            _context.Breeds.Add(breed);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBreed), new { id = breed.Id }, breed);
        }

        // PUT: api/Breeds/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBreed(int id, Breed breed)
        {
            if (id != breed.Id)
            {
                return BadRequest();
            }

            _context.Entry(breed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreedExists(id))
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

        // DELETE: api/Breeds/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed(int id)
        {
            var breed = await _context.Breeds.FindAsync(id);
            if (breed == null)
            {
                return NotFound();
            }

            _context.Breeds.Remove(breed);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BreedExists(int id)
        {
            return _context.Breeds.Any(e => e.Id == id);
        }
    }
}
