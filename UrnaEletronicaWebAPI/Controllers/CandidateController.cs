using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrnaEletronicaWebAPI.Models;
using UrnaEletronicaWebAPI.Repositories;

namespace UrnaEletronicaWebAPI.Controllers
{
    [Route("[controller]")]
    public class CandidateController : Controller
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Candidate candidate) 
        {

            bool candidateExists = _candidateRepository.GetCandidateByLegenda(candidate.Legenda) != null; 

            if (candidateExists) return BadRequest();

            var result = _candidateRepository.AddCandidate(candidate);

            return Ok(result);
        }

        [HttpDelete("{candidateLegenda}")]
        public IActionResult Delete(int candidateLegenda) 
        {
            var candidate = _candidateRepository.GetCandidateByLegenda(candidateLegenda); 

            if (candidate == null) return NotFound();

            _candidateRepository.DeleteCandidateByLegenda(candidateLegenda);

            return Ok("Deleted");
        }
    }
}