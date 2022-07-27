using Application.Data.DataTransferObjects.Candidates;
using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/candidate")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICreateOneCandidateUseCase _createOneCandidateUseCase;
        private readonly IDeleteOneCandidateUseCase _deleteOneCandidateUseCase;
        private readonly IGetAllCandidatesUseCase _getAllCandidatesUseCase;
        private readonly IGetOneCandidateUseCase _getOneCandidateUseCase;

        public CandidatesController(ICreateOneCandidateUseCase createOneCandidateUseCase, IDeleteOneCandidateUseCase deleteOneCandidateUseCase
            , IGetAllCandidatesUseCase getAllCandidatesUseCase, IGetOneCandidateUseCase getOneCandidateUseCase)
        {
            _createOneCandidateUseCase = createOneCandidateUseCase;
            _deleteOneCandidateUseCase = deleteOneCandidateUseCase;
            _getAllCandidatesUseCase = getAllCandidatesUseCase;
            _getOneCandidateUseCase = getOneCandidateUseCase;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateResponseDto>>> GetAll()
        {
            var candidates = await _getAllCandidatesUseCase.GetAll();
            return StatusCode(200, candidates);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateResponseDto>> GetOne(int candidateId)
        {
            var candidate = await _getOneCandidateUseCase.GetOne(candidateId);
            return StatusCode(200, candidate);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<CandidateResponseDto>> Post([FromBody] CandidateRequestDto candidateDto)
        {
            var newCandidate = await _createOneCandidateUseCase.CreateOneAsync(candidateDto);
            return StatusCode(201, newCandidate);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{candidateId}")]
        public async Task<ActionResult> Delete(int candidateId)
        {
            await _deleteOneCandidateUseCase.DeleteOneAsync(candidateId);
            return StatusCode(200);
        }
    }
}
