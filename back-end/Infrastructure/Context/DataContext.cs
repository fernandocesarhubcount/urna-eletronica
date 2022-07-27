using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasIndex(e => e.Legend).IsUnique();
            });
        }

        
    }
}
