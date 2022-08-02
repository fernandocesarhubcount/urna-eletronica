using Application.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Endpoints.Candidates;

public class CandidateGetAll
{
    public static string Template => "/candidates";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handler => Action;

    public static IResult Action(DataContext context)
    {
        var candidates = context.Candidates.Include(c => c.Election).OrderBy(p => p.Name).ToList();
        var results = candidates.Select(c => new CandidateResponse(c.Name, c.CandidateLegend, c.Election.Name, c.RegisterDate, c.Id));
        return Results.Ok(results);
    }
}

