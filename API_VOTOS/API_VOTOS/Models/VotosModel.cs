using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_VOTOS.Models
{
    public class VotosModel
    {
        [Key]
        public int ID_Voto { get; set; }
        public int? ID_Candidato { get; set; }
        public DateTime Data_do_Voto { get; set; }
    }
}
