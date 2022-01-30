using api.Controllers.DTOs.Request;
using api.Controllers.Mapping;
using api.Models;
using api.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly CandidateMapper _mapper;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
            _mapper = new CandidateMapper();
        }

        /// <summary>
        /// Create new candidate
        /// </summary>
        /// <param name="createNewCandidateDTO"></param>
        /// <returns>
        /// New client saved
        /// </returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [Route("[action]")]
        public ActionResult Register(CreateNewCandidateDTO createNewCandidateDTO)
        {
            Candidate candidate = _mapper.Map(createNewCandidateDTO);

            _candidateService.Save(candidate);

            return StatusCode(200);
        }

        /// <summary>
        /// Delete an existing candidate
        /// </summary>
        /// <param name="candidateLegend"></param>
        /// <returns>
        /// Deleted candidate
        /// </returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        [HttpDelete]
        [Route("[action]")]
        public ActionResult Delete([FromQuery] int candidateLegend)
        {
            _candidateService.Delete(candidateLegend);

            return StatusCode(200);
        }
    }
}