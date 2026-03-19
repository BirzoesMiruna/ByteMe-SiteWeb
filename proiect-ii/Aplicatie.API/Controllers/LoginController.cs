using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ReteteInternationale.API.Data;
using System;
using System.Linq;
using ApiModels = Aplicatie.API.Models;
using IdentityModels = Microsoft.AspNetCore.Identity.Data;

namespace Aplicatie.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LoginController : ControllerBase
  {
    private readonly AplicatieDbContext _context;

    public LoginController(AplicatieDbContext context)
    {
      _context = context;
    }

    // LOGIN
    [HttpPost]
    public IActionResult Login([FromBody] ApiModels.LoginRequest request)
    {
      var utilizator = _context.Utilizatori
          .FirstOrDefault(u => u.Email == request.Email && u.ParolaHash == request.Parola);

      if (utilizator == null)
      {
        return Unauthorized("Email sau parolă greșită.");
      }

      return Ok(new
      {
        utilizator.Id,
        utilizator.Nume,
        utilizator.Email
      });
    }

    // PASUL 1 - Cerere resetare parola (forgot-password)
    [HttpPost("forgot-password")]
    public IActionResult ForgotPassword([FromBody] ApiModels.ForgotPasswordRequest request)
    {
      var utilizator = _context.Utilizatori.FirstOrDefault(u => u.Email == request.Email);
      if (utilizator == null)
      {
        // Pentru securitate, răspundem generic indiferent dacă emailul există sau nu
        return Ok(new { message = "Dacă emailul este valid, vei primi instrucțiuni pentru resetare." });
      }

      // Generează token de resetare
      var token = Guid.NewGuid().ToString();

      // Salvează token și expirare în baza de date
      utilizator.PasswordResetToken = token;
      utilizator.PasswordResetTokenExpiration = DateTime.UtcNow.AddHours(1);
      _context.SaveChanges();

      // Construiește linkul de resetare (modifică URL cu front-end-ul tău real)
      var resetLink = $"https://frontend-ul-tau/reset-password?token={token}&email={utilizator.Email}";

      // TODO: Trimite email cu link-ul resetLink
      // Ex: _emailService.SendResetPasswordEmail(utilizator.Email, resetLink);

      return Ok(new { message = "Dacă emailul este valid, vei primi instrucțiuni pentru resetare." });
    }

    // PASUL 2 - Resetarea efectiva a parolei
    [HttpPost("reset-password")]
    public IActionResult ResetPassword([FromBody] ApiModels.ResetPasswordRequest request)
    {
      var utilizator = _context.Utilizatori.FirstOrDefault(u => u.Email == request.Email);
      if (utilizator == null)
      {
        return BadRequest("Utilizatorul nu a fost găsit.");
      }

      if (utilizator.PasswordResetToken != request.Token || utilizator.PasswordResetTokenExpiration < DateTime.UtcNow)
      {
        return BadRequest("Token invalid sau expirat.");
      }

      // TODO: Hash parola înainte să o salvezi
      utilizator.ParolaHash = request.NewPassword;

      // Șterge token-ul după resetare
      utilizator.PasswordResetToken = null;
      utilizator.PasswordResetTokenExpiration = null;

      _context.SaveChanges();

      return Ok(new { message = "Parola a fost resetată cu succes." });
    }
  }
}
