using Application.Data.Converters.Interfaces;
using Application.Data.DataTransferObjects.Candidates;
using Application.UseCases.Interfaces;
using Model.Entities;
using Model.IRepositories;

namespace Application.UseCases.Implementations
{
    public class CreateOneCandidateUseCase : ICreateOneCandidateUseCase
    {
        private readonly ICandidatesRepository _candidatesRepository;
        private readonly IConverter<Candidate, CandidateRequestDto, CandidateResponseDto> _converter;

        public CreateOneCandidateUseCase(ICandidatesRepository candidatesRepository,
            IConverter<Candidate, CandidateRequestDto, CandidateResponseDto> converter)
        {
            _candidatesRepository = candidatesRepository;
            _converter = converter;
        }
        public async Task<CandidateResponseDto> CreateOneAsync(CandidateRequestDto newCandidate)
        {
            var candidate = await _candidatesRepository
            .CreateOneAsync(_converter.RequestToModel(newCandidate));

            return _converter.ModelToResponse(candidate);
        }

    }
}
