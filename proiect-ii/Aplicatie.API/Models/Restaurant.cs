using System.ComponentModel.DataAnnotations;

namespace Aplicatie.API.Models
{
    public class Restaurant
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public required string Nume { get; set; }

        public required string Adresa { get; set; }

        public required string Oras { get; set; }

        public required string Website { get; set; }

        // Relație cu Tara
        public Guid TaraId { get; set; }
        public Tara? Tara { get; set; }

        public ICollection<Reteta>? Retete { get; set; }
    }
}
