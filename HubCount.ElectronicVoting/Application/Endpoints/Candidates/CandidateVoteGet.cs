using Application.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;

namespace Application.Endpoints.Candidates
{
    public class CandidateVoteGet
    {
        public static string Template => "/candidates/relatory";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handler => Action;

        [AllowAnonymous]
        public static async Task<IResult> Action(QueryAllVotesCandidates query)
        {
            var result = await query.Execute();

            return Results.Ok(result);
        }
    }
}
