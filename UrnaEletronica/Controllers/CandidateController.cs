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
    public class CandidateController : ControllerBase
    {   
        [HttpGet]
        [Route("/candidates/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context,[FromRoute] int id)
        {
            var candidato = await context.Canditatos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return candidato == null ? NotFound() : Ok(candidato);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] AppDbContext context,[FromBody] CreateCandidateViewModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var candidatos = await context.Canditatos.AsNoTracking().ToListAsync();

            var candidato = new Candidate
            {
                NomeCanditato = model.NomeCanditato,
                NomeVice = model.NomeVice,
                Legenda = model.Legenda,
                DataRegistro = DateTime.Now,
                QuantidadeVotos = 0
            };

            try
            {
                await context.Canditatos.AddAsync(candidato);
                await context.SaveChangesAsync();
                return Created(uri:$"{candidato.Id}", candidato);
            }
            catch (Exception)
            {
                if (candidatos.Any(x => x.Legenda == model.Legenda))
                {
                    return BadRequest(new {message = $"Legenda {model.Legenda} já está em uso."});
                }
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("/candidates/{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var candidato = await context.Canditatos.FirstOrDefaultAsync(x => x.Id == id);

            var candidatos = await context.Canditatos.AsNoTracking().ToListAsync();

            try
            {
                context.Canditatos.Remove(candidato);
                await context.SaveChangesAsync();
                
                return Ok(new {message = $"candidato id {id} excluído com sucesso."});
            }
            catch(Exception) 
            {
                if (candidatos.Any(x => x.Id != id))
                {
                    return NotFound(new { message = $"id {id} não encontrado" });
                }
                return StatusCode(500);
            }

        }
    }
}
