using api.Controllers.DTOs.Request;
using api.Models;

namespace api.Controllers.Mapping
{
    public class VoteMapper
    {
        public Vote Map(NewVoteDTO NewVoteDTO)
        {
            return new()
            {
                CandidateSubTitle = NewVoteDTO.CandidateSubTitle
            };
        }
    }
}