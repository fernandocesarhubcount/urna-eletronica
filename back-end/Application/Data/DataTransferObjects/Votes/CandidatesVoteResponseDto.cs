using Application.Data.DataTransferObjects.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Votes
{
    public class CandidatesVoteResponseDto
    {
        public CandidateResponseDto CandidateResponse { get; set; }
        public int VotesCount { get; set; }
    }
}
