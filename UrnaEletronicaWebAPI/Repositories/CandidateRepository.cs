using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronicaWebAPI.Models;

namespace UrnaEletronicaWebAPI.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly AppDbContext _dbContext;

        public CandidateRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Candidate AddCandidate(Candidate candidate) 
        {
            _dbContext.Add(candidate);
            _dbContext.SaveChanges();

            return candidate;
        }

        public Candidate GetCandidateByLegenda(int? legenda) 
        {
            return _dbContext.Find<Candidate>(legenda);
        }

        public void DeleteCandidateByLegenda(int legenda) 
        {
            var candidate = _dbContext.Find<Candidate>(legenda);

            _dbContext.Remove(candidate);
            _dbContext.SaveChanges();
            
        }
    }
}