using Application.Data.DataTransferObjects.Candidates;
using Application.Data.DataTransferObjects.Votes;
using Application.DataTransferObjects.Votes;
using Application.UseCases.Interfaces;
using Application.UseCases.Interfaces.Votes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly ICreateOneVoteUseCase _createOneVoteUseCase;
        private readonly IGetAllVotesUseCase _getAllVotesUseCase;

        public VotesController(ICreateOneVoteUseCase createOneVoteUseCase, IGetAllVotesUseCase getAllVotesUseCase)
        {
            _createOneVoteUseCase = createOneVoteUseCase;
            _getAllVotesUseCase = getAllVotesUseCase;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(typeof(CandidatesVoteResponseDto),200)]
        [Route("api/votes")]
        public async Task<ActionResult<IEnumerable<CandidatesVoteResponseDto>>> GetAll()
        {
            var candidatesVotes = await _getAllVotesUseCase.GetVotes();
            return StatusCode(200, candidatesVotes);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Route("api/vote")]
        public async Task<ActionResult<CandidateResponseDto>> Post([FromBody] VoteRequestDto voteDto)
        {
            await _createOneVoteUseCase.CreateOneAsync(voteDto);
            return StatusCode(201, "FIM");
        }
    }
}
