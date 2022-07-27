using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronicaWebAPI.Models;

namespace UrnaEletronicaWebAPI.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private readonly AppDbContext _dbContext;

        public VoteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Vote AddVote(Vote vote) 
        {
            _dbContext.Add(vote);
            _dbContext.SaveChanges();

            return vote;
        }

        public List<CandidateVotes> GetCandidatesWithVotes() 
        {
            var candidates = _dbContext.Candidates.ToList();
            var votes = _dbContext.Votes.ToList();
            var candidatesVotes = new List<CandidateVotes>();

            foreach(var candidate in candidates) 
            {
                var votesQuantity = votes.Where(x => x.LegendaCandidato == candidate.Legenda).Count();

                candidatesVotes.Add(new CandidateVotes(candidate, votesQuantity));
            }

            var nullVotes = votes.Where(x => x.LegendaCandidato == null).Count();

            candidatesVotes.Add(new CandidateVotes(null, nullVotes));

            return candidatesVotes.OrderByDescending(x => x.VotesQuantity).ToList();
        }
    }
}