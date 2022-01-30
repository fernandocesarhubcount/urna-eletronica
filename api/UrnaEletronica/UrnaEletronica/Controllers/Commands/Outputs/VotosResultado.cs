using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrnaEletronica.Controllers.Commands.Outputs
{
    public class VotosResultado
    {
        public int? Legenda { get; set; }
        public String NomeCandidato { get; set; }
        public int QtdVotos { get; set; }
    }
}
