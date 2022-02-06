using System;
using System.Collections.Generic;
using System.Text;
using Urna.Core;

namespace Urna.Data
{
    public interface IUrnaData
    {
        // Candidates
        Candidate AddCandidate(Candidate newCandidate);
        Candidate GetCandidateById(int? id);
        Candidate GetCandidateByLegenda(int? legenda);
        Candidate DeleteCandidate(Candidate Candidate);
        IEnumerable<Candidate> GetCandidatesByVote();

        // Votes
        Vote AddVote(Vote newVote);

        int Commit();
    }
}
