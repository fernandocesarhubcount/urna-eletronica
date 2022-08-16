using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteHubCount.Data;
using TesteHubCount.Models;

namespace TesteHubCount.Controllers
{
  [ApiController]
  public class VoteController : ControllerBase
  {

    [HttpPost]
    [Route("/vote")]
    public IActionResult PostVote([FromBody] VoteModel vote, [FromServices] AppDbContext context)
    {
      var candidate = context.Candidates.FirstOrDefault(c => c.Legenda == vote.CandidatoId);
      if (candidate == null || vote.CandidatoId == -2)
        vote.CandidatoId = -1;
      


      context.Votes.Add(vote);
      context.SaveChanges();

      return Created($"/vote.Id", vote);
    }

    [HttpGet]
    [Route("/votes")]
    public IActionResult GetTotalVotes([FromServices] AppDbContext context)
    {
      var candidates = context.Candidates.AsNoTracking().ToList();
      var votes = context.Votes.AsNoTracking().ToList();
      var dashboardVotes = new List<TotalVotesModel>();

      foreach (var candidate in candidates)
      {
        var totalVotes = votes.Where(x => x.CandidatoId == candidate.Legenda).Count();

        dashboardVotes.Add(new TotalVotesModel(candidate, totalVotes));
      }

      var nullVotes = votes.Where(x => x.CandidatoId == -1).Count();
      dashboardVotes.Add(new TotalVotesModel(null, nullVotes));

      return Ok(dashboardVotes.OrderByDescending(x => x.TotalVotes).ToList());
    }
  }
}