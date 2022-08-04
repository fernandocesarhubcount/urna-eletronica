
using System;

namespace voto_API.Model
{
    public class Voto
    {
        public string Id { get; set; }

        public string NomeDoCandidato { get; set; }

        public string NomeVice { get; set; }

        public  DateTime DataRegistro { get; set; }

        public int Legenda { get; set; }


    }
}
