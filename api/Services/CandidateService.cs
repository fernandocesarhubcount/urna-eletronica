using System;
using System.Collections.Generic;
using api.Models;
using api.Repositories.Interface;
using api.Services.Interface;
using api.Services.Validator;

namespace api.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IVoteRepository _voteRepository;
        private readonly CandidateValidator _validator;
        public CandidateService(ICandidateRepository candidateRepository, IVoteRepository voteRepository)
        {
            _candidateRepository = candidateRepository;
            _voteRepository = voteRepository;
            _validator = new CandidateValidator();
        }

        public void Save(Candidate candidate)
        {
            try
            {
                if (Convert.ToBoolean(_candidateRepository.GetCandidateBySubTitle(candidate.SubTitle)))
                    throw new Exception("Já existe um candidato com essa legenda.");

                _validator.Validate(candidate);

                candidate = Candidate.Create(
                                             candidate.FullName,
                                             candidate.ViceFullName,
                                             candidate.SubTitle
                                             );

                _candidateRepository.Save(candidate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int candidateSubTitle)
        {
            try
            {
                Candidate candidate = _candidateRepository.GetCandidateBySubTitle(candidateSubTitle);

                if (candidate == null)
                    throw new Exception("Candidato inexistente");

                _candidateRepository.Delete(candidate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Candidate> Get()
        {
            List<Candidate> candidates = _candidateRepository.Get();

            foreach (Candidate candidate in candidates)
                candidate.Votes = _voteRepository.GetVotesByCandidate(candidate.SubTitle);


            return candidates;
        }
    }
}