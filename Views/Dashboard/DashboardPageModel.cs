using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UrnaEletronica.Models;

namespace UrnaEletronica.Views.Dashboard
{
    public class DashboardPageModel : PageModel
    {
        private readonly MyDbContext contexto;
        private readonly IEnumerable<DadosDashboard> dados;

        public DashboardPageModel(MyDbContext contexto)
        {
            this.contexto = contexto;
            this.Dados = this.ListarDados();
        }

        public IEnumerable<DadosDashboard> Dados { get; private set; }

        private IEnumerable<DadosDashboard> ListarDados()
        {
            IList<Candidato> candidatos = this.contexto.Candidatos.AsNoTracking().ToList();
            IList<DadosDashboard> lista = new List<DadosDashboard>();
            foreach (Candidato candidato in candidatos)
            {
                DadosDashboard dado = new DadosDashboard
                {
                    Votos = this.contexto.Votos.Where(v => v.CandidatoId == candidato.Codigo).Count(),
                    Candidato = candidato

                };
                lista.Add(dado);
            }

            return lista.OrderByDescending(t => t.Votos);
        }
    }
}
