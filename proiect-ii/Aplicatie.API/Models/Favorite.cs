using System.ComponentModel.DataAnnotations;

namespace Aplicatie.API.Models
{
    public class Favorite
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UtilizatorId { get; set; }
        public  Utilizator? Utilizator { get; set; }

        public Guid RetetaId { get; set; }
        public  Reteta? Reteta { get; set; }
    }
}
