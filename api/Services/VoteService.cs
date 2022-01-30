using System;
using System.Collections.Generic;
using api.Models;
using api.Repositories.Interface;
using api.Services.Interface;

namespace api.Services
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;
        private readonly ICandidateRepository _candidateRepository;

        public VoteService(IVoteRepository voteRepository, ICandidateRepository candidateRepository)
        {
            _voteRepository = voteRepository;
            _candidateRepository = candidateRepository;
        }

        public void Save(Vote vote)
        {
            try
            {
                Candidate candidate = _candidateRepository.GetCandidateByLegend(vote.CandidateLegend);

                if (candidate == null)
                    throw new Exception("Candidato inválido");

                vote = Vote.Create(
                            vote.CandidateLegend
                            );

                _voteRepository.Save(vote);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Vote> Get()
        {
            return _voteRepository.Get();
        }
    }
}