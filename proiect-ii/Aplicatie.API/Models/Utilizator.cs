using System.ComponentModel.DataAnnotations;

namespace Aplicatie.API.Models
{
    public class Utilizator
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public required string Nume { get; set; }

        [Required]
        public required string Email { get; set; }
        public required string ParolaHash { get; set; }

    public required string PasswordResetToken { get; set; }
    public DateTime? PasswordResetTokenExpiration { get; set; }

    public ICollection<Favorite>? Favorite { get; set; }
        public ICollection<Comentariu>? Comentarii { get; set; }
    }
}
