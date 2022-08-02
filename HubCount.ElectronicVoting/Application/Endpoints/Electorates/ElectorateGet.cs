using Application.Infrastructure.Data;

namespace Application.Endpoints.Electorates
{
    public class ElectorateGet
    {
        public static string Template => "/electorate";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handler => Action;

        public static IResult Action(DataContext context)
        {
            var electorates = context.Electorates.ToList();
            var results = electorates.Select(e => new ElectorateResponse(e.SingleVoterTitle));

            return Results.Ok(results);
        }
    }
}
