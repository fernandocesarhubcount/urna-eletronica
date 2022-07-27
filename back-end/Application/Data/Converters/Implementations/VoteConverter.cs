using Application.Data.Converters.Interfaces;
using Application.Data.DataTransferObjects.Votes;
using Application.DataTransferObjects.Votes;
using Model.Entities;

namespace Application.Data.Converters
{
    public class VoteConverter : IConverter<Vote, VoteRequestDto, CandidatesVoteResponseDto>
    {
        public Vote RequestToModel(VoteRequestDto dtoRequest)
        {
            return new()
            {
                RegisterDate = dtoRequest.VoteDate,
            };
            
        }

        public CandidatesVoteResponseDto ModelToResponse(Vote model)
        {
            return new()
            {};
        }
   
    }
}
