using Microsoft.AspNetCore.Mvc;
using UrnaEletronica.Models;
using UrnaEletronica.Views.Dashboard;

namespace UrnaEletronica.Controllers
{
    public class DashboardController : Controller
    {
        private readonly MyDbContext contexto;
        private readonly DashboardPageModel modelo;

        public DashboardController(MyDbContext contexto)
        {
            this.contexto = contexto;
            this.modelo = new DashboardPageModel(this.contexto);
        }

        public IActionResult Dashboard()
        {
            return View(this.modelo);
        }

        [HttpGet("/Dashboard/votes")]
        public JsonResult Votos()
        {
            return new JsonResult(this.modelo.Dados);
        }
    }
}
