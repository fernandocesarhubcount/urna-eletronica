using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class CandidateController : ControllerBase
    {
        // Chama o acesso a dados em outro lugar do código, com o intuito de que cada parte do código tenha uma responsabilidade única. 
        private readonly IUrnaData urnaData;

        public CandidateController(IUrnaData urnaData)
        {
            this.urnaData = urnaData;
        }
    
        // Criar candidato
        [HttpPost]
        public IActionResult Create([FromBody] Candidate Candidato)
        {
            // Se já houver um candidato com a legenda informada.
            if (urnaData.GetCandidateByLegenda(Candidato.Legenda) != null)
                return BadRequest();

            Candidato.DataRegistro = DateTime.Now;
            urnaData.AddCandidate(Candidato); 
            urnaData.Commit();
            return Ok(Candidato); 
            // (?) Tipicamente retornaria um CreatedAtAction com uma action / local onde o recurso recém criado pode ser obtido (GetById por exemplo)
            // Como não existe um GetById na API especificada no projeto, retornamos um Ok.
        }

        // Remover candidato
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Candidato não encontrado
            var Candidato = urnaData.GetCandidateById(id);
            if (Candidato == null)
                return NotFound();

            // Candidato especial "Branco" não pode ser removido
            if (Candidato.CandidateId == -1)
                return BadRequest();

            urnaData.DeleteCandidate(Candidato);
            urnaData.Commit();
            return Ok(Candidato); 
        }
    }
}
