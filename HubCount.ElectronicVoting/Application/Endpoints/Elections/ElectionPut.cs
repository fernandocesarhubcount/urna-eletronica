using Application.Domain.Candidates;
using Application.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Application.Endpoints.Elections;

public class ElectionPut
{
    public static string Template => "/elections/{id:guid}"; 
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() }; 
    public static Delegate Handler => Action; 

    public static IResult Action([FromRoute] Guid id, ElectionRequest electionRequest, DataContext context)
    {
        var election = context.Elections.Where(e => e.Id == id).FirstOrDefault();

        if (election == null)
            return Results.NotFound();

        election.EditElection(electionRequest.Name, electionRequest.Active);

        if (!election.IsValid)
            return Results.ValidationProblem(election.Notifications.ConvertToProblemDetails());

        context.SaveChanges();

        return Results.Ok();
    }
}

