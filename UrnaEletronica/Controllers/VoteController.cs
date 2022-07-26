using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.Data;
using UrnaEletronica.Models;
using UrnaEletronica.ViewModels;

namespace UrnaEletronica.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] AppDbContext context, [FromBody] VoteCandidateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var candidatos = await context.Canditatos.AsNoTracking().ToListAsync();

            if (!candidatos.Any(x => x.Legenda == model.Legenda))
            {
                return NotFound(new { message = $"Candidato com legenda {model.Legenda} não encontrado" });
            }

            var query = context.Canditatos
                               .Where(x => x.Legenda == model.Legenda)
                               .FirstOrDefault<Candidate>();

            var voto = new Vote
            {
                CandidateId = query.Id,
                Legenda = model.Legenda,
                DataVoto = DateTime.Now
            };

            try
            {
                await context.Votos.AddAsync(voto);
                await context.SaveChangesAsync();
                ComputarVoto(context, query.Id);
                return Created(uri: $"{voto.Id}", voto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("/votes")]
        public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
        {
            var candidatos = await context.Canditatos.AsNoTracking().ToListAsync();

            return Ok(candidatos);
        }

        public async void ComputarVoto([FromServices] AppDbContext context, int id)
        {
            try
            {
                context.Database.ExecuteSqlRaw($"UPDATE candidate SET quantidade_votos = quantidade_votos + 1 Where id = {id}");

                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                StatusCode(500, new { message = ex + $"ocorreu um erro" });
            }
        }
    }
}
