using System.Collections.Generic;
using api.Models;

namespace api.Services.Interface
{
    public interface IVoteService
    {
        void Save(Vote voteRequest);

        List<Vote> Get();
    }
}