using Application.Data.DataTransferObjects.Candidates;

namespace Application.UseCases.Interfaces
{
    public interface IGetOneCandidateUseCase
    {
        Task<CandidateResponseDto> GetOne(int candidateId);
    }
}
