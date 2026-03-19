using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Aplicatie.API.Data;
using Aplicatie.API.Models;
using ReteteInternationale.API.Data;

namespace Aplicatie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReteteController : ControllerBase
    {
        private readonly AplicatieDbContext _context;

        public ReteteController(AplicatieDbContext context)
        {
            _context = context;
        }

        // GET: api/retete
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var retete = await _context.Retete
                .Include(r => r.Tara)
                .ToListAsync();

            return Ok(retete);
        }

        // GET: api/retete/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var reteta = await _context.Retete
                .Include(r => r.Tara)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reteta == null)
                return NotFound();

            return Ok(reteta);
        }

    [HttpGet("random")]
    public IActionResult GetRandomRetete()
    {
      var reteteRandom = _context.Retete
          .OrderBy(r => Guid.NewGuid())
          .Take(3)
          .ToList();

      return Ok(reteteRandom);
    }


    //GET /api/retete/tara/{id}
    [HttpGet("tara/{taraId}")]
    public async Task<ActionResult<IEnumerable<Reteta>>> GetReteteByTara(Guid taraId)
    {
      var retete = await _context.Retete
          .Where(r => r.TaraId == taraId)
          .ToListAsync();

      if (retete == null || !retete.Any())
      {
        return NotFound();
      }

      return Ok(retete);
    }

    // POST: api/retete
    [HttpPost]
        public async Task<IActionResult> Create([FromBody] Reteta reteta)
        {
            reteta.Id = Guid.NewGuid();
            _context.Retete.Add(reteta);
            await _context.SaveChangesAsync();

            return Ok(reteta);
        }

        // PUT: api/retete/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Reteta updated)
        {
            var reteta = await _context.Retete.FindAsync(id);
            if (reteta == null)
                return NotFound();

            reteta.Titlu = updated.Titlu;
            reteta.Descriere = updated.Descriere;
            reteta.ImagineUrl = updated.ImagineUrl;
            reteta.Ingrediente = updated.Ingrediente;
            reteta.TaraId = updated.TaraId;

            await _context.SaveChangesAsync();
            return Ok(reteta);
        }

        // DELETE: api/retete/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var reteta = await _context.Retete.FindAsync(id);
            if (reteta == null)
                return NotFound();

            _context.Retete.Remove(reteta);
            await _context.SaveChangesAsync();
            return Ok(reteta);
        }
    }
}
