using System.ComponentModel.DataAnnotations;

namespace Aplicatie.API.Models
{
    public class Comentariu
    {
        [Key]
        public Guid Id { get; set; }

        public required string Continut { get; set; }

        public Guid UtilizatorId { get; set; }
        public required Utilizator Utilizator { get; set; }

        public Guid RetetaId { get; set; }
        public required Reteta Reteta { get; set; }
    }
}
