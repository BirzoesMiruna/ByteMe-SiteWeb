using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Aplicatie.API.Data;
using Aplicatie.API.Models;
using ReteteInternationale.API.Data;

namespace Aplicatie.API.Controllers
{
    [ApiController]
    [Route("api/tari")]
    public class TariController : ControllerBase
    {
        private readonly AplicatieDbContext _context;

        public TariController(AplicatieDbContext context)
        {
            _context = context;
        }

        // GET: api/tari
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tari = await _context.Tari.ToListAsync();
            return Ok(tari);
        }

        // GET: api/tari/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tara = await _context.Tari.FindAsync(id);
            if (tara == null)
                return NotFound();

            return Ok(tara);
        }

        // POST: api/tari
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tara tara)
        {
            tara.Id = Guid.NewGuid();
            _context.Tari.Add(tara);
            await _context.SaveChangesAsync();
            return Ok(tara);
        }

        // PUT: api/tari/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Tara updated)
        {
            var tara = await _context.Tari.FindAsync(id);
            if (tara == null)
                return NotFound();

            tara.Nume = updated.Nume;
            await _context.SaveChangesAsync();
            return Ok(tara);
        }

        // DELETE: api/tari/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var tara = await _context.Tari.FindAsync(id);
            if (tara == null)
                return NotFound();

            _context.Tari.Remove(tara);
            await _context.SaveChangesAsync();
            return Ok(tara);
        }
    }
}
