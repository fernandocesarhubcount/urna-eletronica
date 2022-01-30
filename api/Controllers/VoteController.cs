using System.Collections.Generic;
using api.Controllers.DTOs.Request;
using api.Controllers.Mapping;
using api.Models;
using api.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;
        private readonly VoteMapper _mapper;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
            _mapper = new VoteMapper();
        }

        /// <summary>
        /// Register new vote
        /// </summary>
        /// <param name="newVoteDTO"></param>
        /// <returns>
        /// New vote saved
        /// </returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [Route("[action]")]
        public ActionResult Register(NewVoteDTO newVoteDTO)
        {
            Vote vote = _mapper.Map(newVoteDTO);

            _voteService.Save(vote);

            return StatusCode(200);
        }

        /// <summary>
        /// Get all votes
        /// </summary>
        /// <returns>
        /// votes
        /// </returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        [Route("[action]")]
        public ActionResult Get()
        {
            List<Vote> votes = _voteService.Get();

            return StatusCode(200, votes);
        }
    }
}