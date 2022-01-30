using api.Models;

namespace api.Services.Interface
{
    public interface ICandidateService
    {
        void Save(Candidate candidate);

        void Delete(int candidateLegend);
    }
}