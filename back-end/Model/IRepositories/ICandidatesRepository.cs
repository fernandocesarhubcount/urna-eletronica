using Model.Entities;

namespace Model.IRepositories
{
    public interface ICandidatesRepository
    {
        Task<Candidate> CreateOneAsync(Candidate candidate);
        Task<IEnumerable<Candidate>> GetAllAsync();
        Task<Candidate> GetCandidateById(int guid);
        Task DeleteOneAsync(Candidate candidate);
    }
}
