using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronicaWebAPI.Models;

namespace UrnaEletronicaWebAPI.Repositories
{
    public interface IVoteRepository
    {
        Vote AddVote(Vote vote);

        List<CandidateVotes> GetCandidatesWithVotes();
    }
}