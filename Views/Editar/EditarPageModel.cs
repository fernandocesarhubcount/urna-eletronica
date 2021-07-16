using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using UrnaEletronica.Models;

namespace UrnaEletronica.Views.Editar
{
    public class EditarPageModel : PageModel
    {
        public EditarPageModel(MyDbContext contexto, int id)
        {
            this.Candidato = contexto.Candidatos.FirstOrDefault(c => c.Id == id);
        }

        [BindProperty]
        public Candidato Candidato { get; set; }
    }
}