using Microsoft.AspNetCore.Mvc;
using TesteHubCount.Data;
using TesteHubCount.Models;

namespace TesteHubCounts.Controllers
{

  [ApiController]
  public class CandidateController : ControllerBase
  {
    [HttpGet]
    [Route("/candidate")]
    public IActionResult GetCandidates([FromServices] AppDbContext context)
    {
      return Ok(context.Candidates.ToList());
    }

    [HttpGet]
    [Route("/candidate/{legenda:int}")]
    public IActionResult GetCandidateByLegenda([FromRoute] int legenda, [FromServices] AppDbContext context)
    {
      var model = context.Candidates.FirstOrDefault(c => c.Legenda == legenda);
      if (model == null)
        return NotFound("Candidato não encontrado!");

      return Ok(model);
    }

    [HttpPost]
    [Route("/candidate")]
    public IActionResult PostCandidate([FromBody] CandidateModel candidate, [FromServices] AppDbContext context)
    {
      context.Candidates.Add(candidate);
      context.SaveChanges();

      return Created($"/candidate.Id", candidate);
    }

    [HttpPut]
    [Route("/candidate/{id:int}")]
    public IActionResult PutCandidate([FromRoute] int id, [FromBody] CandidateModel candidate, [FromServices] AppDbContext context)
    {

      var model = context.Candidates.FirstOrDefault(c => c.Id == id);
      if (model == null)
        return NotFound();


      model.Nome = candidate.Nome;
      model.Vice = candidate.Vice;
      model.Legenda = candidate.Legenda;

      context.Candidates.Update(model);
      context.SaveChanges();

      return Ok(model);
    }

    [HttpDelete]
    [Route("/candidate/{id:int}")]
    public IActionResult DeleteCandidate([FromRoute] int id, [FromServices] AppDbContext context)
    {

      var model = context.Candidates.FirstOrDefault(c => c.Id == id);
      if (model == null)
        return NotFound("Candidato não encontrado!");

      context.Candidates.Remove(model);
      context.SaveChanges();

      return Ok(model);
    }
  }
}