using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using voto_API.Model;

namespace voto_API.Repositories
{
    public class votoRepository : IvotoRepository
    {
        public readonly VotoContext _Context;
        public votoRepository(votoRepository Context, VotoContext context)
        {
            _Context = context;
        }
        public async Task<Voto> Create(Voto voto)
        {
            _Context.Votos.Add(voto);
            await _Context.SaveChangesAsync();

            return voto;
        }

        public async Task Delete(int Id)
        {
            var votoToDelete = await _Context.Votos.FindAsync(Id);
            _Context.Votos.Remove(votoToDelete);
            await _Context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Voto>> Get()
        {
           return await _Context.Votos.ToListAsync();
        }

        public async Task<Voto> Get(int Id)
        {
            return await _Context.Votos.FindAsync(Id);
        }

        public async Task Upadate(Voto voto)
        {
            _Context.Entry(voto).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
        }
    }
}