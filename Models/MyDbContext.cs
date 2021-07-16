using Microsoft.EntityFrameworkCore;

namespace UrnaEletronica.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidato>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Candidato>()
                .HasIndex(c => c.Codigo)
                .IsUnique();

            modelBuilder.Entity<Voto>().HasKey(c => c.Id);
        }

        public DbSet<Candidato> Candidatos { get; set; }

        public DbSet<Voto> Votos { get; set; }
    }
}
