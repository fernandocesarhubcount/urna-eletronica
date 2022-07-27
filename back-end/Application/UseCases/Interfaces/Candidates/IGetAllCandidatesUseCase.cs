using Application.Data.DataTransferObjects.Candidates;

namespace Application.UseCases.Interfaces
{
    public interface IGetAllCandidatesUseCase
    {
        Task<IEnumerable<CandidateResponseDto>> GetAll();
    }
}
