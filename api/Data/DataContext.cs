using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                        .HasKey(candidate => candidate.Legend);

            modelBuilder.Entity<Candidate>()
                        .Property(candidate => candidate.FullName)
                        .IsRequired();

            modelBuilder.Entity<Candidate>()
                        .Property(candidate => candidate.ViceFullName)
                        .IsRequired();

            modelBuilder.Entity<Candidate>()
                        .Property(candidate => candidate.Legend)
                        .IsRequired();

            modelBuilder.Entity<Vote>()
                        .Property(vote => vote.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Candidate>()
                        .HasMany(candidate => candidate.Votes)
                        .WithOne();
        }
    }
}