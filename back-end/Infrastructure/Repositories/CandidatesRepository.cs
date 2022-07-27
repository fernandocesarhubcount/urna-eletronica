using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.IRepositories;

namespace Infrastructure.Repositories
{
    public class CandidatesRepository : ICandidatesRepository
    {
        private readonly DataContext _context;

        public CandidatesRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Candidate> CreateOneAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
            return candidate;
        }

        public async Task DeleteOneAsync(Candidate candidate)
        {
            _context.Remove(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Candidate>> GetAllAsync()
        {
            return await _context.Candidates.ToListAsync();
        }

        public async Task<Candidate> GetCandidateById(int candidateId)
        {
            var candidate = await _context.Candidates
                .FirstOrDefaultAsync(c => c.Id.Equals(candidateId));
            if (candidate == default)
                throw new Exception();//Todo Create Exceptions
            return candidate;
        }
    }
}
