using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrnaEletronicaWebAPI.Models
{
    public class CandidateVotes
    {
        public CandidateVotes(Candidate? candidate, int votesQuantity)
        {
            Candidate = candidate;
            VotesQuantity = votesQuantity;
        }
        
        public Candidate Candidate { get; set; }
        public int VotesQuantity { get; set; }
        
    }
}