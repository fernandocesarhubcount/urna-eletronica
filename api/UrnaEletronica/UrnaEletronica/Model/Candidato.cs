using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrnaEletronica.Model
{
    public class Candidato
    {
        public string NomeCompleto { get; set; }
        public string NomeVice { get; set; }
        public DateTime DataDeRegistro { get; set; }
        public int Legenda { get; set; }
    }
}
