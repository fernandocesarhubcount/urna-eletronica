using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.Controllers.Commands.Outputs;
using UrnaEletronica.DAL.Repositories.Interfaces;
using UrnaEletronica.Model;

namespace UrnaEletronica.DAL.Repositories
{
    public class CandidatoRepositorio : ICandidatoRepositorio
    {
        private readonly UrnaEletronicaContext _context;

        public CandidatoRepositorio(UrnaEletronicaContext context)
        {
            _context = context;
        }
        public void Alterar(Candidato obj)
        {
            _context.Set<Candidato>().UpdateRange(obj);
            _context.SaveChanges();
        }

        public void Excluir(Candidato obj)
        {
            _context.Set<Candidato>().RemoveRange(obj);
            _context.SaveChanges();
        }

        public Candidato ObterPorId(int Id)
        {
            return _context.Find<Candidato>(Id);
        }

        public Candidato ObterPorLegenda(int legenda)
        {
            return _context.Candidatos.Where(b => b.Legenda == legenda).FirstOrDefault();
        }

        public IEnumerable<Candidato> ObterTodos()
        {
            return _context.Candidatos.ToList<Candidato>();
        }

        public void Salvar(Candidato obj)
        {
            _context.Set<Candidato>().AddRange(obj);
            _context.SaveChanges();
        }
    }
}
