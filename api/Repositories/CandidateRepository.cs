using System.Collections.Generic;
using System.Linq;
using api.Data;
using api.Models;
using api.Repositories.Interface;

namespace api.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly DataContext _context;

        public CandidateRepository(DataContext context)
        {
            _context = context;
        }

        public Candidate GetCandidateBySubTitle(int candidateSubTitle)
        {
            Candidate candidate = _context.Candidates.FirstOrDefault(candidate => candidate.SubTitle == candidateSubTitle);

            return candidate;
        }

        public void Save(Candidate candidate)
        {
            _context.Add(candidate);
            _context.SaveChanges();
        }

        public void Delete(Candidate candidate)
        {
            _context.Remove(candidate);
            _context.SaveChanges();
        }

        public List<Candidate> Get()
        {
            List<Candidate> candidates = _context.Candidates.ToList();

            return candidates;
        }
    }
}