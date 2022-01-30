using api.Models;

namespace api.Repositories.Interface
{
    public interface ICandidateRepository
    {
        void Save(Candidate candidate);

        void Delete(Candidate candidate);

        Candidate GetCandidateByLegend(int candidateLegend);
    }
}