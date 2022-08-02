using Application.Domain.Candidates;
using Application.Infrastructure.Data;

namespace Application.Endpoints.Candidates;

public class CandidatePost
{
    public static string Template => "/candidates";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handler => Action;

    public static IResult Action(CandidateRequest candidateRequest, DataContext context)
    {

        var election = context.Elections.FirstOrDefault(e => e.Id == candidateRequest.ElectionId);

        var candidate = new Candidate(
            candidateRequest.Name,
            election,
            candidateRequest.CandidateLegend,
            candidateRequest.ViceName,
            candidateRequest.AmountVote);

        if (!candidate.IsValid)
        {
            return Results.ValidationProblem(candidate.Notifications.ConvertToProblemDetails());
        }

        context.Candidates.Add(candidate);
        context.SaveChanges();

        return Results.Created($"/candidates/{candidate.Id}", candidate.Id);
    }
}

