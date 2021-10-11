using API_VOTOS.Models;
using API_VOTOS.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_VOTOS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrnaController : ControllerBase
    {
        private readonly CandidatosRepository _candidatosRepository;
        private readonly VotosRepository _votosRepository;


        public UrnaController(CandidatosRepository candidatosRepository, VotosRepository votosRepository)
        {
            _candidatosRepository = candidatosRepository;
            _votosRepository = votosRepository;
        }

        [HttpPost]
        [Route("candidate")]
        public async Task<RetornoModel> CadastroCandidato([FromBody] CandidatosModel candidato)
        {
            if (candidato == null)
            {
                return new RetornoModel { ITEM = new Object(), MSG = "Não é possivel cadastrar um candidato vázio (????????) ", ERRO = true };
            }

            if (candidato.Legenda < 1 || candidato.Legenda > 99)
            {
                return new RetornoModel { ITEM = new Object(), MSG = "Número de LEGENDA fora do intervalo permitido (1-99)", ERRO = true };
            }

            try
            {
                CandidatosModel candidatoExiste = _candidatosRepository.BuscarCandidato(candidato.Legenda).Result.FirstOrDefault<CandidatosModel>();

                if (candidatoExiste == null)
                {
                    await _candidatosRepository.CadastrarCandidato(candidato);

                    return new RetornoModel { ITEM = new Object(), MSG = "CADASTRADO COM SUCESSO", ERRO = false };
                }
                else
                {
                    return new RetornoModel { ITEM = new Object(), MSG = "NÂO É POSSIVEL CADASTRAR POIS O NÚMERO DE LEGENDA JÁ ESTÁ SENDO UTILIZADO!", ERRO = true };
                }

            }
            catch (Exception e)
            {
                return new RetornoModel { ITEM = new Object(), MSG = e.Message, ERRO = true };
            }
        }

        [HttpGet]
        [Route("candidate")]
        public RetornoModel BuscarCandidato([FromQuery] int? Legenda)
        {
            if (Legenda != null)
            {
                CandidatosModel candidato = _candidatosRepository.BuscarCandidato(Legenda.Value).Result.FirstOrDefault();

                if (candidato == null)
                {
                    return new RetornoModel { ITEM = null, MSG = "VOTO NULO", ERRO = false };
                }

                return new RetornoModel { ITEM = candidato, MSG = "Candidato Encontrado", ERRO = false };
            }
            else
            {
                List<CandidatosModel> listacandidato =  _candidatosRepository.BuscarCandidato().Result;

                if (listacandidato == null)
                {
                    return new RetornoModel { ITEM = null, MSG = "Nenhum Candidato cadastrado", ERRO = false };
                }

                return new RetornoModel { ITEM = listacandidato, MSG = "Candidato Encontrado", ERRO = false };
            }
        }

        [HttpDelete]
        [Route("candidate")]
        public async Task<RetornoModel> ExclusaoCandidato([FromQuery] int ID_Candidato)
        {
            try
            {
                CandidatosModel candidato =  _candidatosRepository.BuscarCandidato(null,ID_Candidato).Result.FirstOrDefault();

                if (candidato == null)
                {
                    return new RetornoModel { ITEM = new Object(), MSG = "Candidato não foi cadastrado na urna", ERRO = true };
                }
                await _candidatosRepository.ExcluirCandiato(candidato);
                return new RetornoModel { ITEM = new Object(), MSG = "Candidato Excluido com sucesso", ERRO = false };
            }
            catch (Exception e)
            {
                return new RetornoModel { ITEM = new Object(), MSG = e.Message, ERRO = true };
            }
        }

        [HttpPost]
        [Route("vote")]
        public async Task<RetornoModel> Voto([FromBody] VotosModel voto)
        {
            try
            {
                await _votosRepository.CadastrarVoto(voto);
                return new RetornoModel { ITEM = voto, MSG = "Voto cadastrado com sucesso", ERRO = false };
            }
            catch (Exception e)
            {
                return new RetornoModel { ITEM = voto, MSG = e.Message, ERRO = true };
            }
        }

        [HttpGet]
        [Route("vote")]
        public async Task<RetornoModel> ListagemVotos()
        {
            try
            {
                List<VotosModel> ListaVotos = await _votosRepository.ListarVotos();
                List<CandidatosModel> ListaCandidatos = await _candidatosRepository.ListaCandidatos();

                var qtde = ListaVotos.GroupBy(n => n.ID_Candidato).Select(n => new {
                                                                                        ID_Candidato = n.Key,
                                                                                        Qtde = n.Count()
                                                                                   }).OrderBy(n => n.ID_Candidato);
                var query = from cd in ListaCandidatos
                            join qt in qtde on cd.ID_Candidato equals qt.ID_Candidato
                            select new ListagemVotosModel
                            {
                                Legenda = cd.Legenda,
                                Nome_Prefeito = cd.Nome_Completo,
                                Nome_VicePrefeito = cd.Nome_Vice,
                                Qtde_Votos = qt.Qtde
                            };

                List<ListagemVotosModel> listagemVotos = query.ToList();
                listagemVotos.Add(
                    new ListagemVotosModel
                    {
                        Legenda = null,
                        Nome_Prefeito = "NULO",
                        Nome_VicePrefeito = "NULO",
                        Qtde_Votos = ListaVotos.Count(x => x.ID_Candidato == null)
                    }
                );
                listagemVotos = listagemVotos.OrderByDescending(x => x.Qtde_Votos).ToList();

                return new RetornoModel { ITEM = listagemVotos, MSG = "Lista votos carregada com sucesso", ERRO = false };

            }
            catch (Exception e)
            {
                return new RetornoModel { ITEM = new Object(), MSG = e.Message, ERRO = true };
            }
        }
    }
}
