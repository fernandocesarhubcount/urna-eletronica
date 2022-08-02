using Application.Infrastructure.Data;

namespace Application.Endpoints.Elections;

public class ElectionGetAll
{
    public static string Template => "/elections";

    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handler => Action;

    //Definição da ação via HTTP
    public static IResult Action(DataContext context)
    {
        var elections = context.Elections.ToList();

        var response = elections.Select(e => new ElectionResponse(e.Id, e.Name, e.Active));

        return Results.Ok(elections);
    }
}


