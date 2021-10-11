using API_VOTOS.Context;
using API_VOTOS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_VOTOS.Repository
{
    public class VotosRepository
    {

        IServiceScopeFactory _serviceScopeFactory;

        public VotosRepository(IServiceScopeFactory serviceScopeFactory)
        {
                _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task CadastrarVoto(VotosModel voto)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<UrnaContext>();

                try
                {
                    await context.votos.AddAsync(voto);
                    context.SaveChanges();

                }
                catch (Exception e)
                {
                    context.Dispose();
                    throw new Exception(e.Message);
                }
            }
        }
        public async Task<List<VotosModel>> ListarVotos()
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<UrnaContext>();

                try
                {


                    var votos = await context.votos.ToListAsync();

                    //var query = from vt in   c.votos.ToListAsync().Result
                    //            select vt;
                    //var votos = query.ToList<VotosModel>();
                    return votos.ToList();

                }
                catch (Exception e)
                {
                    context.Dispose();
                    throw new Exception(e.Message);
                }
            }
        }
    }
}
