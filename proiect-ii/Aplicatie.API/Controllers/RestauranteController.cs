using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Aplicatie.API.Data;
using Aplicatie.API.Models;
using ReteteInternationale.API.Data;

namespace Aplicatie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestauranteController : ControllerBase
    {
        private readonly AplicatieDbContext _context;

        public RestauranteController(AplicatieDbContext context)
        {
            _context = context;
        }

        // GET: api/restaurante
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurante = await _context.Restaurante
                .Include(r => r.Tara)
                .Include(r => r.Retete)
                .ToListAsync();

            return Ok(restaurante);
        }

        // GET: api/restaurante/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var restaurant = await _context.Restaurante
                .Include(r => r.Tara)
                .Include(r => r.Retete)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (restaurant == null)
                return NotFound();

            return Ok(restaurant);
        }

        // POST: api/restaurante
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Restaurant restaurant)
        {
            restaurant.Id = Guid.NewGuid();
            _context.Restaurante.Add(restaurant);
            await _context.SaveChangesAsync();

            return Ok(restaurant);
        }

        // PUT: api/restaurante/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Restaurant updated)
        {
            var restaurant = await _context.Restaurante.FindAsync(id);
            if (restaurant == null)
                return NotFound();

            restaurant.Nume = updated.Nume;
            restaurant.Adresa = updated.Adresa;
            restaurant.Oras = updated.Oras;
            restaurant.Website = updated.Website;
            restaurant.TaraId = updated.TaraId;

            await _context.SaveChangesAsync();
            return Ok(restaurant);
        }

        // DELETE: api/restaurante/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var restaurant = await _context.Restaurante.FindAsync(id);
            if (restaurant == null)
                return NotFound();

            _context.Restaurante.Remove(restaurant);
            await _context.SaveChangesAsync();
            return Ok(restaurant);
        }
    }
}
