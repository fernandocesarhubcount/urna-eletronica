using api.Controllers.DTOs.Request;
using api.Models;

namespace api.Controllers.Mapping
{
    public class CandidateMapper
    {
        public Candidate Map(CreateNewCandidateDTO createNewCandidateDTO)
        {
            return new()
            {
                FullName = createNewCandidateDTO.FullName,
                ViceFullName = createNewCandidateDTO.ViceFullName,
                SubTitle = createNewCandidateDTO.SubTitle
            };
        }
    }
}