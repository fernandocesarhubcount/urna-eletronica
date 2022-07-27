using Model.Entities;

namespace Model.IRepositories
{
    public interface IVotesRepository
    {
        Task<Vote> CreateOneAsync(Vote vote);
        Task<IEnumerable<Vote>> GetAllVotes();
    }
}
