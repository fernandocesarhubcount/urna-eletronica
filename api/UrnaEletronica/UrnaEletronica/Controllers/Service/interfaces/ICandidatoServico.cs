using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.Controllers.Commands;
using UrnaEletronica.DAL.Repositories.Interfaces;
using UrnaEletronica.Model;
using UrnaEletronica.Model.Inputs;

namespace UrnaEletronica.Controllers.Service
{
    public interface ICandidatoServico
    {
        IComandoResultado SalvarCandidato(FormularioCandidato form);
        IComandoResultado AlterarCandidato(int id, FormularioCandidato form);
        bool LegendaJaRegistrada(int legenda);
        Candidato ConverterFormParaCandidato(FormularioCandidato form);
        IComandoResultado ApagarCandidato(int idCandidato);
        IComandoResultado ApagarTodosCandidatos();
    }
}
