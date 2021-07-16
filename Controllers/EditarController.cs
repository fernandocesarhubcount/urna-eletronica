using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using UrnaEletronica.Models;
using UrnaEletronica.Util;
using UrnaEletronica.Views.Editar;

namespace UrnaEletronica.Controllers
{
    [Route("[controller]")]
    public class EditarController : Controller
    {
        private readonly MyDbContext contexto;

        public EditarController(MyDbContext contexto)
        {
            this.contexto = contexto;
        }

        public IActionResult Editar([FromQuery(Name = "id")] int id)
        {
            EditarPageModel model = new EditarPageModel(this.contexto, id);
            return View(model);
        }

        [HttpPost]
        public JsonResult Editar([FromBody] JsonElement retorno)
        {
            Candidato editado = JsonConvert.DeserializeObject<Candidato>(retorno.GetRawText(), new IsoDateTimeConverter { DateTimeFormat = Constantes.FormatoData });
            Candidato candidato = this.contexto.Candidatos.FirstOrDefault(c => c.Id == editado.Id);
            if (editado == null || candidato == null)
            {
                return null;
            }

            candidato.Codigo = editado.Codigo;
            candidato.Nome = editado.Nome;
            candidato.Partido = editado.Partido;
            candidato.Vice = editado.Vice;
            candidato.DataRegistro = DateTime.Now.Date;

            try
            {
                this.contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                Response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                return Json(new { Mensagem = ex.Message });
            }
            return Json(editado);
        }
    }
}
