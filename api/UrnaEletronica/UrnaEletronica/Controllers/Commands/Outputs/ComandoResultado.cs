using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrnaEletronica.Controllers.Commands.Outputs
{
    public class ComandoResultado : IComandoResultado
    {
        public bool Sucesso { get ; set ; }
        public string Mensagem { get ; set ; }
        public object Dados { get ; set ; }

        public ComandoResultado(bool sucesso, string mensagem, object dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }
    }
}
