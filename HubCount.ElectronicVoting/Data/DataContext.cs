using HubCount.ElectronicVoting.Models;
using Microsoft.EntityFrameworkCore;

namespace HubCount.ElectronicVoting.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Vote> Votes { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
    }
}
