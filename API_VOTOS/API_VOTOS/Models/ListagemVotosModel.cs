using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_VOTOS.Models
{
    public class ListagemVotosModel
    {
        public int? Legenda { get; set; }
        public string Nome_Prefeito { get; set; }
        public string Nome_VicePrefeito { get; set; }
        public int Qtde_Votos { get; set; }
    }
}
