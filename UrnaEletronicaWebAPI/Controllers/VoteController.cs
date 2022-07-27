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
    public class VoteController : Controller
    {
        private readonly IVoteRepository _voteRepository;
        private readonly ICandidateRepository _candidateRepository;


        public VoteController(IVoteRepository voteRepository,
                              ICandidateRepository candidateRepository)
        {
            _voteRepository = voteRepository;
            _candidateRepository = candidateRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Vote vote) 
        {
            if (vote.LegendaCandidato != null) 
            {
                var candidate = _candidateRepository.GetCandidateByLegenda(vote.LegendaCandidato);

                if (candidate == null) return NotFound();
            }

            var result = _voteRepository.AddVote(vote);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var result = _voteRepository.GetCandidatesWithVotes();

            return Ok(result);
        }

    }
}