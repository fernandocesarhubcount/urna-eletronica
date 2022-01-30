using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.Controllers.Commands.Outputs;
using UrnaEletronica.DAL.Repositories.Interfaces;
using UrnaEletronica.Model;

namespace UrnaEletronica.DAL.Repositories
{
    public class VotoRepositorio : IVotoRepositorio
    {
        private readonly UrnaEletronicaContext _context;

        public VotoRepositorio(UrnaEletronicaContext context)
        {
            _context = context;
        }

        public void Excluir(Voto obj) // Apaga o voto, caso seja necessário
        {
            _context.Set<Voto>().RemoveRange(obj);
            _context.SaveChanges();
        }

        public Voto ObterPorId(int Id) // Retorna o voto atavés de seu Id, caso precise.
        {
            return _context.Votos.Where<Voto>(v => v.Id == Id).FirstOrDefault();
        }

        
        public  IEnumerable<VotosResultado> ObterVotosPorCandidatos()
        {
            try
            {
                List<VotosResultado> votos = new List<VotosResultado>();
                // Aqui é realizado um Left Join de Candidatos com Votos, agrupando os dados e ordenando pela quantidade de votos.
                var query = (from c in _context.Candidatos
                             join vt in _context.Votos on c.IdCandidato equals vt.IdCandidato into Details
                             from m in Details.DefaultIfEmpty()
                             group c by new
                             {
                                 c.IdCandidato,
                                 c.NomeCompleto,
                                 c.Legenda
                             } into cand
                             select new VotosResultado
                             {
                                 NomeCandidato = cand.Key.NomeCompleto,
                                 Legenda = cand.Key.Legenda,
                                 QtdVotos = _context.Votos.Where(v => cand.Key.IdCandidato == v.IdCandidato).Count()

                             }).OrderByDescending(v => v.QtdVotos);

                if(query.Count() >= 1)
                {
                    votos = query.ToList();
                }

                var vtBrancos = ObterVotosEmBranco(); // Pega os votos em Branco
                var vtNulos = ObterVotosNulos(); // Pega os votos nulos

                if (vtBrancos != null)
                {
                    votos.Add(vtBrancos);
                }

                if (vtNulos != null)
                {
                    votos.Add(vtNulos);
                }

                return votos; // Retorna um lista com os votos (Candidatos, em Branco e nulos)
            }
            catch (Exception ex)
            {
                throw new Exception("ObterVotosPorCandidatos : " + ex.Message);
            }            
        }

        public VotosResultado ObterVotosEmBranco()
        {
            try
            {
                IEnumerable<VotosResultado> votos = new List<VotosResultado>();

                IQueryable<VotosResultado> query = _context.Votos.Where(vt => vt.VotoEmBranco == true && vt.IdCandidato == null)
                                                                 .GroupBy(vto => vto.VotoEmBranco)
                                                                 .Select(grupo => new VotosResultado
                                                                 {
                                                                     Legenda = null,
                                                                     NomeCandidato = "EM BRANCO",
                                                                     QtdVotos = grupo.Count()
                                                                 });
                if(query.Count() >= 1)
                {
                    votos = query;
                    return votos.First();
                } else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ObterVotosPorCandidatos : " + ex.Message);
            }
        }

        public VotosResultado ObterVotosNulos()
        {
            var qtdvotos = ObterTodosPorCandidato(null).Count();
            if(qtdvotos >= 1)
            {
                VotosResultado vtNulos = new VotosResultado
                {
                    Legenda = null,
                    NomeCandidato = "Votos Nulos",
                    QtdVotos = qtdvotos
                };
                return vtNulos;
            } else
            {
                return null;
            }
        }

        public IEnumerable<Voto> ObterTodosPorCandidato(int? legenda) // Busca todos os botos apartir da legenda do candidato
        {
            return _context.Votos.Where(c=> c.IdCandidato == legenda);
        }

        public void Salvar(Voto obj)
        {
            _context.Set<Voto>().AddRange(obj);
            _context.SaveChanges();
        }

        public void ApagarTodosVotosCandidato(int idCandidato) // Busca e apaga todos os votos de um candidato
        {
            var votos = (from v in _context.Votos
                         where v.IdCandidato == idCandidato
                         select v).ToList();
            if(votos != null)
            {
                _context.Votos.RemoveRange(votos);
                _context.SaveChanges();
            }
        }

        // Métodos não implementado, foram herdados da interface IRepositorioEF.
        public IEnumerable<Voto> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Alterar(Voto obj) // 
        {
            throw new NotImplementedException();
        }
    }
}
