using HubCountApi.Data;
using HubCountApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace HubCountApi.Controllers
{
     
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("[controller]")]
    public class CandidatoController : ControllerBase
    {
        private HubCountContext db = new HubCountContext();

        [HttpPost]
        public IActionResult Post([FromForm] CandidateModel CandidateJson)
        {
            if (!ModelState.IsValid)
            {
                string messagesError = string.Join(", ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

                return BadRequest("O Candidatos não pode ter dados nulos, verifique novamente os dados\n\n" + messagesError);
            }

            try
            {
                var candidato = db.Candidates.Where(C => C.CodigoCandidato == CandidateJson.CodigoCandidato);

                if (candidato.Count() > 0)
                    return BadRequest("Candidato com o código: "+ CandidateJson.CodigoCandidato + " já existe!");

                db.Candidates.Add(CandidateJson);
                db.SaveChanges();
                return Ok("Registro cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idCandidato}")]
        public IActionResult Delete(int idCandidato)
        {
            try
            {
                var candidato = db.Candidates.Include(v => v.Votes).Single(C => C.Id == idCandidato);

                db.Votes.RemoveRange(candidato.Votes);
                db.Candidates.Remove(candidato);
                db.SaveChanges();

                return Ok("Registro apagado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{idCandidato}")]
        public IActionResult Get(int idCandidato)
        {
            try
            {
                var candidato = db.Candidates.Where(C => C.CodigoCandidato == idCandidato);

                if (candidato.Count()  == 0)
                    return BadRequest("Candidato não existe na base de dados");

                 
                return Ok(candidato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
