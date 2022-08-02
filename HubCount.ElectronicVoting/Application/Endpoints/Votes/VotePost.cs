using Application.Domain.Candidates;
using Application.Domain.Votes;
using Application.Infrastructure.Data;
using System.Linq;

namespace Application.Endpoints.Votes;

public class VotePost
{
    public static string Template => "/votes";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handler => Action;

    public static IResult Action(VoteRequest voteRequest, HttpContext http, DataContext context)
    {

        var candidates = new List<Candidate>();

        List<Candidate> candidatesFound = null;
        if (voteRequest.CandidateLegend != null && voteRequest.CandidateLegend.Any())
            candidatesFound = context.Candidates.Where(p => voteRequest.CandidateLegend.Contains(p.CandidateLegend)).ToList();


        var voting = new Vote(voteRequest.SingleVoterTitle, candidatesFound);
        context.Add(voting);
        context.SaveChanges();

        return Results.Created($"/votes/{voting.Id}", voting.Id);
    }
}

