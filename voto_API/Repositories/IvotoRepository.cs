using System.Collections.Generic;
using voto_API.Model;
using System.Threading.Tasks;

namespace voto_API.Repositores
{
    public interface IvotoRepository
    {
        Task<IEnumerable<Voto>> Get();

        Task<Voto> Get(int Id);

        Task<Voto> Create (Voto voto);

        Task Upadate(Voto voto);

        Task Delete(int Id);

    }
}
