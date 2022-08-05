using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using voto_API.Model;
using voto_API.Repositories;

namespace voto_API.Controllers // Chamada para os endpoints, sendo utilizado pelos controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class VotoController : ControllerBase
    {

        private readonly IvotoRepository _votorepository;
        private readonly string id;

        public VotoController(IvotoRepository votorepository) // Gerando o construtor
        {
            _votorepository = votorepository;
        }

        [HttpGet]

        public async Task<IEnumerable<Voto>> GetVotos()
        {
            return await _votorepository.Get();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Voto>> GetVotos(int Id)
        {
            return await _votorepository.Get(Id);
        }

        [HttpPost]
        public async Task<ActionResult<Voto>> PostVotos([FromBody] Voto voto)
        {
            var newVoto = await _votorepository.Create(voto);
            return CreatedAtAction(nameof(GetVotos), new {id = newVoto.Id }, newVoto);
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id) // incluido uma condição para que  detete algo que não exista.
        {
            var votoToDelete = await _votorepository.Get(Id);

            if (votoToDelete == null)
                return NotFound();

            await _votorepository.Delete(votoToDelete.Id); // caso exista o null será deletado do banco

            return NoContent();

        }

        [HttpPut]
        public async Task<ActionResult> PutVotos(int Id,[FromBody] Voto voto)
        {
            if (id != voto.Id)
                return BadRequest();

                await _votorepository.Upadate(voto);

            return NoContent();

        }
}
