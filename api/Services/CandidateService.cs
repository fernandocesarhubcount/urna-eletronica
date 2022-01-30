using System;
using api.Models;
using api.Repositories.Interface;
using api.Services.Interface;
using api.Services.Validator;

namespace api.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly CandidateValidator _validator;
        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
            _validator = new CandidateValidator();
        }

        public void Save(Candidate candidate)
        {
            try
            {
                if (Convert.ToBoolean(_candidateRepository.GetCandidateByLegend(candidate.Legend)))
                    throw new Exception("Já existe um candidato com essa legenda.");

                _validator.Validate(candidate);

                candidate = Candidate.Create(
                                             candidate.FullName,
                                             candidate.ViceFullName,
                                             candidate.Legend
                                             );

                _candidateRepository.Save(candidate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int candidateLegend)
        {
            try
            {
                Candidate candidate = _candidateRepository.GetCandidateByLegend(candidateLegend);

                if (candidate == null)
                    throw new Exception("Candidato inexistente");

                _candidateRepository.Delete(candidate);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}