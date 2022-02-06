using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urna.Core;
using Urna.Data;

namespace Urna.Controllers
{

    [ApiController]
    [Route("api/[controller]")] // Simplifica a necessidade de adicionar a rota base para cada método / endpoint.
    public class VoteController : ControllerBase
    {

        private readonly IUrnaData urnaData;

        public VoteController(IUrnaData urnaData)
        {
            this.urnaData = urnaData;
        }


        // Criar Voto (Votar)
        [HttpPost]
        public IActionResult Create([FromBody] Vote voto)
        {
            var Candidato = urnaData.GetCandidateById(voto.CandidateId);

            // Se não for encontrado um candidato, ou o id for 0, então votar nulo.
            if (Candidato == null || voto.CandidateId == 0)
            {
                voto.CandidateId = -1;
            }

            voto.DataVoto = DateTime.Now;
            
            urnaData.AddVote(voto);
            urnaData.Commit();

            voto.Candidato = null; // Evita referência circular no retorno do JSON
            return Ok(voto);
        }


        // Receber todos os candidatos e a quantidade de votos correspondente
        [HttpGet]
        [Route("/api/votes")] // Sobrescreve a rota padrão.
        public IActionResult GetCandidatesVotes()
        {
            var Candidatos = urnaData.GetCandidatesByVote(); 
            return Ok(Candidatos);
        }
    }
}
