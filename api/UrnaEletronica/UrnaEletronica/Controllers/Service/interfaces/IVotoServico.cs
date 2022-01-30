using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.Controllers.Commands;
using UrnaEletronica.Model;
using UrnaEletronica.Model.Inputs;

namespace UrnaEletronica.Controllers.Service
{
    public interface IVotoServico
    {
        IComandoResultado ObterTodosOsVotos();
        IComandoResultado ObterTodosOsVotosCandidato(int legenda);
        IComandoResultado SalvarVoto(FormVoto voto);
    }
}
