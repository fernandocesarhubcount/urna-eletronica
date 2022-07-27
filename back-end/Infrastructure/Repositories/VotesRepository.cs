using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.IRepositories;

namespace Infrastructure.Repositories
{
    public class VotesRepository : IVotesRepository
    {
        private readonly DataContext _context;

        public VotesRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Vote> CreateOneAsync(Vote vote)
        {
            await _context.Votes.AddAsync(vote);
            await _context.SaveChangesAsync();
            return vote;
        }

        public async Task<IEnumerable<Vote>> GetAllVotes()
        {
            return await _context.Votes.Include(vote => vote.Candidate).ToListAsync();
        }
    }
}
