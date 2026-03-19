using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Aplicatie.API.Data;
using Aplicatie.API.Models;
using ReteteInternationale.API.Data;

namespace Aplicatie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentariiController : ControllerBase
    {
        private readonly AplicatieDbContext _context;

        public ComentariiController(AplicatieDbContext context)
        {
            _context = context;
        }

        // GET: api/comentarii
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comentarii = await _context.Comentarii
                .Include(c => c.Utilizator)
                .Include(c => c.Reteta)
                .ToListAsync();

            return Ok(comentarii);
        }

        // GET: api/comentarii/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var comentariu = await _context.Comentarii
                .Include(c => c.Utilizator)
                .Include(c => c.Reteta)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (comentariu == null)
                return NotFound();

            return Ok(comentariu);
        }

        // POST: api/comentarii
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Comentariu comentariu)
        {
            comentariu.Id = Guid.NewGuid();
            _context.Comentarii.Add(comentariu);
            await _context.SaveChangesAsync();

            return Ok(comentariu);
        }

        // PUT: api/comentarii/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Comentariu updated)
        {
            var comentariu = await _context.Comentarii.FindAsync(id);
            if (comentariu == null)
                return NotFound();

            comentariu.Continut = updated.Continut;
            comentariu.RetetaId = updated.RetetaId;
            comentariu.UtilizatorId = updated.UtilizatorId;

            await _context.SaveChangesAsync();
            return Ok(comentariu);
        }

        // DELETE: api/comentarii/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var comentariu = await _context.Comentarii.FindAsync(id);
            if (comentariu == null)
                return NotFound();

            _context.Comentarii.Remove(comentariu);
            await _context.SaveChangesAsync();
            return Ok(comentariu);
        }
    }
}
