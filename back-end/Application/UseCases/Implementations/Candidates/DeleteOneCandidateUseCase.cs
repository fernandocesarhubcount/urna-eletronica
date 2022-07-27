using Application.UseCases.Interfaces;
using Model.IRepositories;

namespace Application.UseCases.Implementations
{
    public class DeleteOneCandidateUseCase : IDeleteOneCandidateUseCase
    {
        private readonly ICandidatesRepository _candidatesRepository;

        public DeleteOneCandidateUseCase(ICandidatesRepository candidatesRepository)
        {
            _candidatesRepository = candidatesRepository;
        }

        public async Task DeleteOneAsync(int candidateId)
        {
            var candidateToBeDeleted = await _candidatesRepository.GetCandidateById(candidateId);
            await _candidatesRepository.DeleteOneAsync(candidateToBeDeleted);
        }
    }
}
