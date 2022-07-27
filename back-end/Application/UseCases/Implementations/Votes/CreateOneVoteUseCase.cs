using Application.Data.Converters.Interfaces;
using Application.Data.DataTransferObjects.Votes;
using Application.DataTransferObjects.Votes;
using Application.UseCases.Interfaces;
using Model.Entities;
using Model.IRepositories;

namespace Application.UseCases.Implementations
{
    public class CreateOneVoteUseCase : ICreateOneVoteUseCase
    {
        private readonly IConverter<Vote, VoteRequestDto, CandidatesVoteResponseDto> _converter;
        private readonly IVotesRepository _votesRepository;
        private readonly ICandidatesRepository _candidateRepository;

        public CreateOneVoteUseCase(IConverter<Vote, VoteRequestDto, CandidatesVoteResponseDto> converter, IVotesRepository votesRepository,
            ICandidatesRepository candidatesRepository)
        {
            _converter = converter;
            _votesRepository = votesRepository;
            _candidateRepository = candidatesRepository;
        }
        public async Task CreateOneAsync(VoteRequestDto voteRequest)
        {
            var candidate = await _candidateRepository.GetCandidateById(voteRequest.CandidateId);
            var newVote = _converter.RequestToModel(voteRequest);
            newVote.Candidate = candidate;
            var vote = await _votesRepository.CreateOneAsync(newVote);
        }
    }
}
