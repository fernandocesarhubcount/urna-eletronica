using Application.Data.DataTransferObjects.Candidates;

namespace Application.UseCases.Interfaces
{
    public interface ICreateOneCandidateUseCase
    {
        Task<CandidateResponseDto> CreateOneAsync(CandidateRequestDto newCandidate);
    }
}
