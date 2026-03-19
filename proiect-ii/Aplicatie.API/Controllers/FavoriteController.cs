using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Aplicatie.API.Data;
using Aplicatie.API.Models;
using ReteteInternationale.API.Data;
using Aplicatie.API.DTOs;

namespace Aplicatie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly AplicatieDbContext _context;

        public FavoriteController(AplicatieDbContext context)
        {
            _context = context;
        }

        // GET: api/favorite
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var favorite = await _context.Favorite
                .Include(f => f.Utilizator)
                .Include(f => f.Reteta)
                .ToListAsync();

            return Ok(favorite);
        }

        // GET: api/favorite/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var favorit = await _context.Favorite
                .Include(f => f.Utilizator)
                .Include(f => f.Reteta)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (favorit == null)
                return NotFound();

            return Ok(favorit);
        }

        // POST: api/favorite
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Favorite favorit)
        {
            favorit.Id = Guid.NewGuid();
            _context.Favorite.Add(favorit);
            await _context.SaveChangesAsync();

            return Ok(favorit);
        }

        // DELETE: api/favorite/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var favorit = await _context.Favorite.FindAsync(id);
            if (favorit == null)
                return NotFound();

            _context.Favorite.Remove(favorit);
            await _context.SaveChangesAsync();

            return Ok(favorit);
        }
    [HttpGet("reteta")]
    public async Task<IActionResult> GetReteteFavorite()
    {
      var retetaIds = await _context.Favorite
                                    .Select(f => f.RetetaId)
                                    .ToListAsync();

      var reteteFavorite = await _context.Retete
                                         .Where(r => retetaIds.Contains(r.Id))
                                         .ToListAsync();

      return Ok(reteteFavorite);
    }
    [HttpPost("adaugare-favorite")]
    public async Task<IActionResult> AdaugaFavorite([FromBody] FavoriteDtos dto)
    {
      var favorite = new Favorite
      {

        UtilizatorId = dto.UtilizatorId,
        RetetaId = dto.RetetaId
      };

      _context.Favorite.Add(favorite);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(AdaugaFavorite), new { id = favorite.Id }, dto);
    }
    [HttpGet("retete-favorite/{utilizatorId}")]
    public async Task<IActionResult> GetReteteFavorite(Guid utilizatorId)
    {
      // Selectezi doar RetetaId-urile care apar în Favorite pentru utilizatorul dat
      var retetaIds = await _context.Favorite
                                    .Where(f => f.UtilizatorId == utilizatorId)
                                    .Select(f => f.RetetaId)
                                    .ToListAsync();

      // Găsești rețetele corespunzătoare acelor ID-uri
      var reteteFavorite = await _context.Retete
                                         .Where(r => retetaIds.Contains(r.Id))
                                         .ToListAsync();

      return Ok(reteteFavorite);


    }
    [HttpDelete("remove-retete-favorite/{utilizatorId:guid}/{retetaId:guid}")]
    public async Task<IActionResult> RemoveReteteFavorite(Guid utilizatorId, Guid retetaId)
    {

      var favorite = await _context.Favorite
                                   .FirstOrDefaultAsync(f => f.UtilizatorId == utilizatorId && f.RetetaId == retetaId);
      if (favorite == null)
        return NotFound();
      _context.Favorite.Remove(favorite);
      await _context.SaveChangesAsync();
      return Ok();
    }
  }
}
