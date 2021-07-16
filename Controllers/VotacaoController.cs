using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Linq;
using System.Text.Json;
using UrnaEletronica.Models;
using UrnaEletronica.Util;

namespace UrnaEletronica.Controllers
{
    [Route("[controller]")]
    public class VotacaoController : Controller
    {
        private readonly MyDbContext contexto;

        public VotacaoController(MyDbContext contexto)
        {
            this.contexto = contexto;
        }

        public IActionResult Votacao()
        {
            return View();
        }

        [HttpPost("atualizar-tela")]
        public JsonResult AtualizarTela(int codigo)
        {
            Candidato candidato = this.contexto.Candidatos.FirstOrDefault(c => c.Codigo.Equals(codigo));
            if (candidato == null)
            {
                candidato = new Candidato
                {
                    Codigo = Constantes.CodigosVotos.Nulo.GetHashCode(),
                    Nome = Constantes.Nulo,
                    Partido = Constantes.Nulo,
                    Vice = Constantes.Nulo
                };
            }
            return Json(candidato);
        }

        [HttpPost("vote")]
        public JsonResult Confirmar([FromBody] JsonElement retorno)
        {
            int? codigo;
            Candidato candidato = JsonConvert.DeserializeObject<Candidato>(retorno.GetRawText(), new IsoDateTimeConverter { DateTimeFormat = Constantes.FormatoData });
            if (candidato.Nome.Equals(Constantes.VotoEmBranco) && candidato.Codigo == Constantes.CodigosVotos.Branco.GetHashCode())
            {
                codigo = this.contexto.Candidatos.FirstOrDefault(c => c.Nome.Equals(Constantes.Branco))?.Codigo;
                if (!codigo.HasValue)
                {
                    codigo = Constantes.CodigosVotos.Branco.GetHashCode();
                    Candidato branco = new Candidato
                    {
                        Codigo = codigo.Value,
                        Nome = Constantes.Branco,
                        Partido = Constantes.Branco,
                        Vice = Constantes.Branco,
                        DataRegistro = DateTime.Now.Date
                    };
                    this.contexto.Candidatos.Add(branco);
                    this.contexto.SaveChanges();
                }
            }
            else if (candidato == null || this.contexto.Candidatos.FirstOrDefault(c => c.Codigo.Equals(candidato.Codigo) && c.Nome.Equals(candidato.Nome) &&
                c.Partido.Equals(candidato.Partido) && c.Vice.Equals(candidato.Vice)) == null)
            {
                candidato = this.contexto.Candidatos.FirstOrDefault(c => c.Codigo == Constantes.CodigosVotos.Nulo.GetHashCode());
                if (candidato == null)
                {
                    candidato = new Candidato
                    {
                        Codigo = Constantes.CodigosVotos.Nulo.GetHashCode(),
                        Nome = Constantes.Nulo,
                        Partido = Constantes.Nulo,
                        Vice = Constantes.Nulo,
                        DataRegistro = DateTime.Now.Date
                    };
                    this.contexto.Candidatos.Add(candidato);
                    this.contexto.SaveChanges();
                }
                
            }

            Voto voto = new Voto
            {
                CandidatoId = candidato.Codigo,
                Data = DateTime.Now.Date
            };
            this.contexto.Votos.Add(voto);
            this.contexto.SaveChanges();

            return Json(voto);
        }
    }
}