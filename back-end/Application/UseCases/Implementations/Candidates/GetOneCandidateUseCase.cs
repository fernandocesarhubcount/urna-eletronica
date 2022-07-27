using Application.Data.Converters.Interfaces;
using Application.Data.DataTransferObjects.Candidates;
using Application.UseCases.Interfaces;
using Model.Entities;
using Model.IRepositories;

namespace Application.UseCases.Implementations
{
    public class GetOneCandidateUseCase : IGetOneCandidateUseCase
    {
        private readonly ICandidatesRepository _candidatesRepository;
        private readonly IConverter<Candidate, CandidateRequestDto, CandidateResponseDto> _converter;

        public GetOneCandidateUseCase(ICandidatesRepository candidatesRepository,
            IConverter<Candidate, CandidateRequestDto, CandidateResponseDto> converter)
        {
            _candidatesRepository = candidatesRepository;
            _converter = converter;
        }

        public async Task<CandidateResponseDto> GetOne(int candidateId)
        {
            var candidate = await _candidatesRepository.GetCandidateById(candidateId);
            return (_converter.ModelToResponse(candidate));
        }
    }
}
