using Microsoft.EntityFrameworkCore;
using UrnaEletronica.Models;

namespace UrnaEletronica.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Candidate> Canditatos { get; set; }
        public DbSet<Vote> Votos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
            modelBuilder.ApplyConfiguration(new VoteConfiguration());
            modelBuilder.Entity<Candidate>()
                    .HasMany(v => v.Vote)
                    .WithOne(e => e.Candidate)
                    .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=db\\db_urna.db;Cache=Shared");
        }
    }
}
