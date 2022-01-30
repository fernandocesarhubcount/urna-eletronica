using System.Collections.Generic;
using System.Linq;
using api.Data;
using api.Models;
using api.Repositories.Interface;

namespace api.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private readonly DataContext _context;

        public VoteRepository(DataContext context)
        {
            _context = context;
        }

        public void Save(Vote vote)
        {
            _context.Add(vote);
            _context.SaveChanges();
        }

        public List<Vote> Get()
        {
            List<Vote> voteList = _context.Votes.ToList();

            return voteList;
        }
    }
}