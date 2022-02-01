using System.Collections.Generic;
using api.Models;

namespace api.Repositories.Interface
{
    public interface ICandidateRepository
    {
        void Save(Candidate candidate);

        void Delete(Candidate candidate);

        Candidate GetCandidateBySubTitle(int candidateSubTitle);

        List<Candidate> Get();
    }
}