using Application.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Endpoints.Votes;

public class VoteGet
{
    public static string Template => "/votes/{id}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handler => Action;

    public static IResult Action(Guid id, DataContext context)
    {
        var vote = context.Votes.Include(v => v.Candidates).FirstOrDefault(v => v.Id == id);

        var electorate = context.Electorates.Find(vote.SingleVoterTitle);

        var candidatesResponse = vote.Candidates.Select(c => new VoteCandidate(
            c.Id,
            c.Name,
            c.CandidateLegend
            ));

        var voteResponse = new VoteResponse(
            vote.Id,
            electorate.SingleVoterTitle,
            candidatesResponse,
            // vote.TotalCandidateVote,
            vote.StatusVote);

        return Results.Ok(voteResponse);
    }
}

