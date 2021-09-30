using HubCountApi.Data;
using HubCountApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HubCountApi.Controllers
{
     
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("[controller]")]
    public class VoteController : ControllerBase
    {
        private HubCountContext db = new HubCountContext();
         
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                CandidateModel candidatoNullo = new CandidateModel();

                var votoNullo = db.Votes.Where(c => c.CandidateId == null);
                candidatoNullo.NomeCompleto = "Voto nullo";
                candidatoNullo.NomeVice = "Voto nullo";
                candidatoNullo.TotalVotos = votoNullo.Count(); 
                candidatoNullo.Votes = null;

                List<CandidateModel> result = db.Candidates.Include(C=> C.Votes).ToList();
               
                foreach (CandidateModel item in result)
                {

                    item.TotalVotos += item.Votes.Count();
                }

                result.Add(candidatoNullo);

                result.Sort((x, y) => y.TotalVotos.CompareTo(x.TotalVotos));
                result.OrderBy(order => order.TotalVotos).ThenBy(order => order.TotalVotos).ToList();

                //
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromForm] VoteModel voteJson)
        {
            if (!ModelState.IsValid)
            {
                string messagesError = string.Join(", ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));

                return BadRequest("O voto não pode ter dados nulos, verifique novamente os dados\n\n" + messagesError);
            }

            try
            {

                if(voteJson.CodigoCandidato != null)
                {
                    var candidato = db.Candidates.Where(C => C.CodigoCandidato == voteJson.CodigoCandidato);

                    if (candidato.Count() == 0)
                        return BadRequest("Candidato inválido");

                    foreach (CandidateModel item in candidato)
                    {
                        voteJson.CandidateId = Convert.ToInt32(item.Id);
                    }
                }
                
               
                db.Votes.Add(voteJson);
                db.SaveChanges();
                return Ok("Registro cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
