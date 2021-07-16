using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Net;
using System.Text.Json;
using UrnaEletronica.Models;
using UrnaEletronica.Util;
using UrnaEletronica.Views.Adicionar;

namespace UrnaEletronica.Controllers
{
    [Route("[controller]")]
    public class AdicionarController : Controller
    {
        private readonly MyDbContext contexto;

        public AdicionarController(MyDbContext contexto)
        {
            this.contexto = contexto;
        }

        public IActionResult Adicionar()
        {
            AdicionarPageModel model = new AdicionarPageModel();
            return View(model);
        }

        [HttpPost("/Cadastro/Adicionar/candidate")]
        public JsonResult Salvar([FromBody] JsonElement retorno)
        {
            Candidato candidato = JsonConvert.DeserializeObject<Candidato>(retorno.GetRawText(), new IsoDateTimeConverter { DateTimeFormat = Constantes.FormatoData });
            if (candidato == null)
            {
                return null;
            }
            candidato.DataRegistro = DateTime.Now.Date;
            this.contexto.Candidatos.Add(candidato);
            try
            {
                this.contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                string mensagem = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                return Json(new { Mensagem = mensagem });
            }
            return Json(candidato);
        }
    }
}
