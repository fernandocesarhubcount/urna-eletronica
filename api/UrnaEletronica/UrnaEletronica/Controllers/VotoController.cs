using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UrnaEletronica.Controllers.Commands;
using UrnaEletronica.Controllers.Commands.Outputs;
using UrnaEletronica.Controllers.Service;
using UrnaEletronica.Controllers.Service.interfaces;
using UrnaEletronica.DAL.Repositories.Interfaces;
using UrnaEletronica.Model;
using UrnaEletronica.Model.Inputs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrnaEletronica.Controllers
{
    [EnableCors("urna")]
    public class VotoController : ControllerBase
    {
        private readonly IVotoRepositorio _repositorio;

        private readonly IVotoServico _servico;

        public VotoController(IVotoRepositorio repositorio)
        {
            _repositorio = repositorio;
            _servico = new VotoServico(repositorio);
        }

        [Route("votes")]
        [HttpGet]
        public IComandoResultado Get()
        {
            return _servico.ObterTodosOsVotos();
        }

        [Route("vote")]
        [HttpPost]
        public IComandoResultado Post([FromBody] FormVoto voto)
        {
            return _servico.SalvarVoto(voto);
        }
    }
}
