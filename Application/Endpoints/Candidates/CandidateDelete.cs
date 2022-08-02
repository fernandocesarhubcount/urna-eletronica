using Application.Domain.Candidates;
using Application.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Application.Endpoints.Candidates;

public class CandidateDelete
{
    public static string Template => "/candidates/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handler => Action;

    //Definição da ação via HTTP
    public static IResult Action(Guid id, DataContext context)
    {
        var candidate = context.Candidates.Where(e => e.Id == id).FirstOrDefault();

        if (candidate == null)
            return Results.NotFound();

        if (!candidate.IsValid)
            return Results.ValidationProblem(candidate.Notifications.ConvertToProblemDetails());

        context.Remove(candidate);
        context.SaveChanges();

        return Results.Ok();
    }
}

