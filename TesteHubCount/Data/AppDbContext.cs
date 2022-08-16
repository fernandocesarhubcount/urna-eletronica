using Microsoft.EntityFrameworkCore;
using TesteHubCount.Models;

namespace TesteHubCount.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<CandidateModel> Candidates { get; set; }
    public DbSet<VoteModel> Votes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=app.db;Cache=Shared");
  }

}