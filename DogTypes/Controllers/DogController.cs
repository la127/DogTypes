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
    public class DogController : ControllerBase
    {
        private readonly DogDbContext _context;

        public DogController(DogDbContext context)
        {
            _context = context;
        }

        // GET: api/Dogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dog>>> GetDogs()
        {
            var dogs = await _context.Dogs.ToListAsync();
            return Ok(dogs);
        }

        // GET: api/Dogs/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Dog>> GetDog(int id)
        {
            var dog = await _context.Dogs.FindAsync(id);

            if (dog == null)
            {
                return NotFound();
            }

            return Ok(dog);
        }

        // POST: api/Dogs
        [HttpPost]
        public async Task<ActionResult<Dog>> CreateDog(Dog dog)
        {
            _context.Dogs.Add(dog);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDog), new { id = dog.Id }, dog);
        }

        // PUT: api/Dogs/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDog(int id, Dog dog)
        {
            if (id != dog.Id)
            {
                return BadRequest();
            }

            _context.Entry(dog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(id))
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

        // DELETE: api/Dogs/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDog(int id)
        {
            var dog = await _context.Dogs.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }

            _context.Dogs.Remove(dog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogExists(int id)
        {
            return _context.Dogs.Any(e => e.Id == id);
        }
    }
}
