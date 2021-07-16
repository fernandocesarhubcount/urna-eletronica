using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UrnaEletronica.Models;

namespace UrnaEletronica.Views.Cadastro
{
    public class CadastroPageModel : PageModel
    {
        private readonly MyDbContext contexto;

        public CadastroPageModel(MyDbContext contexto)
        {
            this.contexto = contexto;
            this.Candidatos = this.contexto.Candidatos.AsNoTracking().ToList();
        }

        public IList<Candidato> Candidatos { get; private set; }
    }
}
