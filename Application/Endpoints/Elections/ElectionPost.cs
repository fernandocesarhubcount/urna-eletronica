using Application.Domain.Candidates;
using Application.Infrastructure.Data;

namespace Application.Endpoints.Elections;

public class ElectionPost //Cadastrar o tipo de eleição == Presidente, Deputados, Veriadores;
{
    public static string Template => "/elections"; //rota do template
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() }; //Metodo de acesso
    public static Delegate Handler => Action; //Digo ao manipulador a sua ação. 

    //Definição da ação via HTTP
    public static IResult Action(ElectionRequest electionRequest, DataContext context)
    {
        var election = new Election(electionRequest.Name);

        if (!election.IsValid)
        {
            return Results.ValidationProblem(election.Notifications.ConvertToProblemDetails());
        }

        context.Elections.Add(election);
        context.SaveChanges();

        //, election.id -- Mostrar apenas o Id 
        return Results.Created($"/elections/{election.Id}", election.Id);
    }
}

