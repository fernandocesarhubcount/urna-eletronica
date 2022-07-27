using Application.DataTransferObjects.Votes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Interfaces.Votes
{
    public interface IGetAllVotesUseCase
    {
        Task<IEnumerable<CandidatesVoteResponseDto>> GetVotes();
    }
}
