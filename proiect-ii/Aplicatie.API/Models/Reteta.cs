using System.ComponentModel.DataAnnotations;

namespace Aplicatie.API.Models
{
    public class Reteta
    {
            
            public Guid Id { get; set; }

            [Required]
            public required string Titlu { get; set; }

            public required string Descriere { get; set; }

            public required string Ingrediente { get; set; }

            public required string ImagineUrl { get; set; }

            // Relații
            public Guid TaraId { get; set; }
            public required Tara Tara { get; set; }

            public ICollection<Comentariu>? Comentarii { get; set; }
            public ICollection<Favorite>? Favorite { get; set; }
        
    }
}
