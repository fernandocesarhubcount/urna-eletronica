using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UrnaEletronica.Controllers.Commands;
using UrnaEletronica.Controllers.Commands.Outputs;
using UrnaEletronica.Controllers.Service;
using UrnaEletronica.DAL.Repositories.Interfaces;
using UrnaEletronica.Model;
using UrnaEletronica.Model.Inputs;


namespace UrnaEletronica.Controllers
{
    [EnableCors("urna")]
    [Route("candidate")]
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidatoRepositorio _repositorio;

        private readonly IVotoRepositorio _votoRepositorio;

        private readonly ICandidatoServico _servico;

        public CandidatoController(ICandidatoRepositorio repositorio, IVotoRepositorio votoRepositorio)
        {
            _repositorio = repositorio;
            _votoRepositorio = votoRepositorio;
            _servico = new CandidatoServico(repositorio, _votoRepositorio);
        }

        [HttpGet]
        public IEnumerable<Candidato> Get()
        {
            return _repositorio.ObterTodos();
        }

        // Obtem o candidato através da sua legenda
        [HttpGet("{legenda}")]
        public IComandoResultado Get(int legenda)
        {
            return new ComandoResultado(true, "", _repositorio.ObterPorLegenda(legenda));
        }

        // Salva o candidato, caso o formulário seja valido
        [HttpPost]
        public IComandoResultado Post([FromBody] FormularioCandidato form)
        {
            return _servico.SalvarCandidato(form);
        }

        // Apaga o candidato através do IdCandidato
        [HttpDelete("{id}")]
        public IComandoResultado Delete(int id)
        {
            return _servico.ApagarCandidato(id);            
        }
        // Apaga todos os candidatos
        [HttpDelete()]
        public IComandoResultado DeleteTodosCandidatos()
        {
            return _servico.ApagarTodosCandidatos();
        }
    }
}
