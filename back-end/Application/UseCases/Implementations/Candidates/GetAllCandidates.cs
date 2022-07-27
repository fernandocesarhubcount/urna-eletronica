using Application.Data.Converters.Interfaces;
using Application.Data.DataTransferObjects.Candidates;
using Application.UseCases.Interfaces;
using Model.Entities;
using Model.IRepositories;

namespace Application.UseCases.Implementations
{
    public class GetAllCandidatesUseCase : IGetAllCandidatesUseCase
    {
        private readonly ICandidatesRepository _candidatesRepository;
        private readonly IConverter<Candidate, CandidateRequestDto, CandidateResponseDto> _converter;

        public GetAllCandidatesUseCase(ICandidatesRepository candidatesRepository,
            IConverter<Candidate, CandidateRequestDto, CandidateResponseDto> converter)
        {
            _candidatesRepository = candidatesRepository;
            _converter = converter;
        }
        public async Task<IEnumerable<CandidateResponseDto>> GetAll()
        {
           List<CandidateResponseDto> candidatesResponse = new();
           var candidates = await _candidatesRepository.GetAllAsync();
           foreach(var candidate in candidates) 
           {
                candidatesResponse.Add(_converter.ModelToResponse(candidate));
           }
            return  candidatesResponse;
        }

    }
}
