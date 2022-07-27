using Application.DataTransferObjects.Votes;
using Application.UseCases.Interfaces.Votes;
using Model.IRepositories;

namespace Application.UseCases.Implementations.Votes
{
    public class GetAllVotesUseCase : IGetAllVotesUseCase
    {
        private readonly IVotesRepository _votesRepository;

        public GetAllVotesUseCase(IVotesRepository votesRepository)
        {
            _votesRepository = votesRepository;
        }
        public async Task<IEnumerable<CandidatesVoteResponseDto>> GetVotes()
        {
            var votes = await _votesRepository.GetAllVotes();
            var candidates = votes.Select(vo => vo.Candidate).Distinct().ToList();
            List<CandidatesVoteResponseDto> result = new List<CandidatesVoteResponseDto>();
            foreach (var candidate in candidates)
            {
                var candidateVotesReponse = new CandidatesVoteResponseDto()
                {
                    CandidateResponse = new()
                    {
                        CandidateId = candidate.Id,
                        FullName = candidate.FullName,
                        ViceName = candidate.ViceName,
                        Legend = candidate.Legend,
                        RegisterDate = candidate.RegisterDate,
                    },
                    VotesCount = votes.Where(vote => vote.Candidate.Id.Equals(candidate.Id)).Count()
                };
                result.Add(candidateVotesReponse);
            }
            
            return result.OrderByDescending(r => r.VotesCount);
        }
    }
}
