using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrnaEletronica.Models;

namespace UrnaEletronica.Views.Adicionar
{
    public class AdicionarPageModel : PageModel
    {
        [BindProperty]
        public Candidato Candidato { get; set; }
    }
}