
using API_VOTOS.Context;
using API_VOTOS.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API_VOTOS.Repository
{
    public class CandidatosRepository
    {
        IServiceScopeFactory _serviceScopeFactory;


        public CandidatosRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task CadastrarCandidato(CandidatosModel candidato)
        {
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<UrnaContext>();
                    await context.candidatos.AddAsync(candidato);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task ExcluirCandiato(CandidatosModel candidato)
        {
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<UrnaContext>();
                    context.candidatos.Remove(candidato);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<CandidatosModel>> BuscarCandidato(int? Legenda = null, int? ID_Candidato = null)
        {
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<UrnaContext>();
                    if (Legenda != null && ID_Candidato == null)
                    {
                        List<CandidatosModel> candidato = await context.candidatos.Where(x => x.Legenda == Legenda).ToListAsync(); ;
                        return candidato;

                    }
                    else if (Legenda == null && ID_Candidato != null)
                    {
                        List<CandidatosModel> candidato = await context.candidatos.Where(x => x.ID_Candidato == ID_Candidato).ToListAsync();
                        return candidato;
                    }
                    else
                    {
                        List<CandidatosModel> candidato = await context.candidatos.ToListAsync();
                        return candidato;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<CandidatosModel>> ListaCandidatos()
        {
            try
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<UrnaContext>();
                    var candidatos = await context.candidatos.ToListAsync();

                    return candidatos.ToList();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
