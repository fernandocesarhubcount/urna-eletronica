using Application.Data.DataTransferObjects.Votes;

namespace Application.UseCases.Interfaces
{
    public interface ICreateOneVoteUseCase
    {
        Task CreateOneAsync(VoteRequestDto voteRequest);
    }
}
