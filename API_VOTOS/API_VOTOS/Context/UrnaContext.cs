using API_VOTOS.Models;
using Microsoft.EntityFrameworkCore;

namespace API_VOTOS.Context
{
    public class UrnaContext : DbContext
    {
        public UrnaContext(DbContextOptions<UrnaContext> options) : base(options) { }

        public DbSet<CandidatosModel> candidatos { get; set; }
        public DbSet<VotosModel> votos { get; set; }
    }
}
