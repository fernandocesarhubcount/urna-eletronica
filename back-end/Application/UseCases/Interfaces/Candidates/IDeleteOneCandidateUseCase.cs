namespace Application.UseCases.Interfaces
{
    public interface IDeleteOneCandidateUseCase
    {
        Task DeleteOneAsync(int candidateId);
    }
}
