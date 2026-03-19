using System.ComponentModel.DataAnnotations;

namespace Aplicatie.API.Models
{
    public class Tara
    {
            [Key]
            public Guid Id { get; set; }

            [Required]
            public required string Nume { get; set; }

            public ICollection<Reteta>? Retete { get; set; }
        
    }
}
