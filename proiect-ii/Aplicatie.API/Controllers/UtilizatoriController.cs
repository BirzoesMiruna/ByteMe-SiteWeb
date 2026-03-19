using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Aplicatie.API.Data;
using Aplicatie.API.Models;
using ReteteInternationale.API.Data;

namespace Aplicatie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtilizatoriController : ControllerBase
    {
        private readonly AplicatieDbContext _context;

        public UtilizatoriController(AplicatieDbContext context)
        {
            _context = context;
        }

        // GET: api/utilizatori
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var utilizatori = await _context.Utilizatori
                .Include(u => u.Favorite)
                .Include(u => u.Comentarii)
                .ToListAsync();

            return Ok(utilizatori);
        }

        // GET: api/utilizatori/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var utilizator = await _context.Utilizatori
                .Include(u => u.Favorite)
                .Include(u => u.Comentarii)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (utilizator == null)
                return NotFound();

            return Ok(utilizator);
        }

        // POST: api/utilizatori
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Utilizator utilizator)
        {
            utilizator.Id = Guid.NewGuid();
            _context.Utilizatori.Add(utilizator);
            await _context.SaveChangesAsync();

            return Ok(utilizator);
        }

        // PUT: api/utilizatori/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Utilizator updated)
        {
            var utilizator = await _context.Utilizatori.FindAsync(id);
            if (utilizator == null)
                return NotFound();

            utilizator.Nume = updated.Nume;
            utilizator.Email = updated.Email;
            utilizator.ParolaHash = updated.ParolaHash;

            await _context.SaveChangesAsync();
            return Ok(utilizator);
        }

        // DELETE: api/utilizatori/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var utilizator = await _context.Utilizatori.FindAsync(id);
            if (utilizator == null)
                return NotFound();

            _context.Utilizatori.Remove(utilizator);
            await _context.SaveChangesAsync();
            return Ok(utilizator);
        }
    }
}
