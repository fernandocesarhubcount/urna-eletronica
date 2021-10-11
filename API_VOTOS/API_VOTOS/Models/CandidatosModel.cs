using System;
using System.ComponentModel.DataAnnotations;

namespace API_VOTOS.Models
{

    public class CandidatosModel
    {
        [Key]
        public int ID_Candidato {get; set;}
        public string Nome_Completo { get; set; }
        public string Nome_Vice { get; set; }
        public DateTime Data_Registro { get; set; }
        public int Legenda { get; set; }
    }

}
