using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.Controllers.Commands;
using UrnaEletronica.Controllers.Commands.Outputs;
using UrnaEletronica.DAL.Repositories.Interfaces;
using UrnaEletronica.Model;
using UrnaEletronica.Model.Inputs;

namespace UrnaEletronica.Controllers.Service.interfaces
{
    public class VotoServico : IVotoServico
    {
        private readonly IVotoRepositorio _repositorio;
        public VotoServico(IVotoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public IComandoResultado ObterTodosOsVotos()
        {
            try
            {
                IEnumerable<VotosResultado> votosResultado = new List<VotosResultado>();
                var votos = _repositorio.ObterVotosPorCandidatos();
                return new ComandoResultado(true, "", votos);
            }
            catch (Exception ex)
            {
                return new ComandoResultado(false, "Não foi possivel obter todos os votos", ex);
            }
        }

        public IComandoResultado ObterTodosOsVotosCandidato(int legenda)
        {

            IEnumerable<Voto> votos = _repositorio.ObterTodosPorCandidato(legenda);
            if(votos != null)
               return new ComandoResultado(true, "", votos);

            return new ComandoResultado(false, "Não foi possivel obter todos os votos do candidato", null);
        }

        public IComandoResultado SalvarVoto(FormVoto form)
        {
            if(form.Valid()) // verifica se o formulário é válido
            {
                Voto voto = new Voto(form);
                _repositorio.Salvar(voto);
                return new ComandoResultado(true, "Voto salvo com sucesso", voto);
            } else
            {
                return new ComandoResultado(false, "Não foi possível gravar o voto", form.Notifications);
            }
        }
    }
}
