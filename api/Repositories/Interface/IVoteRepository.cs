using System.Collections.Generic;
using api.Models;

namespace api.Repositories.Interface
{
    public interface IVoteRepository
    {
        void Save(Vote vote);

        List<Vote> Get();
    }
}