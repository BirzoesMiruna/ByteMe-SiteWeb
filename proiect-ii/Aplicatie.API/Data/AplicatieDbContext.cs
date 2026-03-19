using Microsoft.EntityFrameworkCore;
using Aplicatie.API.Models;

namespace ReteteInternationale.API.Data
{
    public class AplicatieDbContext : DbContext
    {
        public AplicatieDbContext(DbContextOptions<AplicatieDbContext> options) : base(options)
        {
        }

        // DbSet-uri pentru fiecare tabel
        public DbSet<Reteta> Retete { get; set; }
        public DbSet<Tara> Tari { get; set; }
        public DbSet<Utilizator> Utilizatori { get;set; }
        public DbSet<Restaurant> Restaurante { get; set; }
        public DbSet<Comentariu> Comentarii { get; set; }
        public DbSet<Favorite> Favorite { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chei compuse (dacă e nevoie)
            base.OnModelCreating(modelBuilder);
        }
    }
}
