using Microsoft.EntityFrameworkCore;

namespace voto_API.Model
{
    public class VotoContext : DbContext
    {
        public VotoContext(DbContextOptions<VotoContext> options) : base(options)
        {
            Database.EnsureCreated(); // será criado a base de dados. 
        }

        public DbSet<Voto> Votos { get; set } // Mapeamento de cada entidade, podendo criar outras entidade case necessário.
    }
}
