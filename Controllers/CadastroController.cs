using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UrnaEletronica.Models;
using UrnaEletronica.Views.Cadastro;

namespace UrnaEletronica.Controllers
{
    [Route("[controller]")]
    public class CadastroController : Controller
    {
        private readonly MyDbContext contexto;

        public CadastroController(MyDbContext contexto)
        {
            this.contexto = contexto;
        }

        public IActionResult Cadastro()
        {
            CadastroPageModel model = new CadastroPageModel(this.contexto);
            return View(model);
        }

        [HttpDelete]
        public JsonResult Deletar([FromQuery(Name = "remover")] int id)
        {
            Candidato candidato = this.contexto.Candidatos.Find(id);
            if (candidato == null)
            {
                Response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
                return Json(new { Mensagem = "Candidato não encontrado" });
            }
            this.contexto.Candidatos.Remove(candidato);

            List<Voto> votos = this.contexto.Votos.Where(v => v.CandidatoId.Equals(candidato.Codigo)).ToList();
            this.contexto.Votos.RemoveRange(votos);

            try
            {
                this.contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                Response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                return Json(new { Mensagem = ex.Message });
            }
            return Json(candidato);
        }
    }
}
