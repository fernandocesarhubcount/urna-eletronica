using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HubCountApi.Models
{
    public partial class CandidateModel 
    {
        public CandidateModel()
        {
            Votes = new HashSet<VoteModel>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Informe código do candidato ")]
        public int CodigoCandidato { get; set; }

        [Required(ErrorMessage = "Informe o Nome Completo")]

        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Informe o nome do vice Presidente")]
        public string NomeVice { get; set; }

        [Required(ErrorMessage = "Informe a data do cadastro")]
        public DateTime DataRegistro { get; set; }

        [Required(ErrorMessage = "Informe a legenda")]
        public int Legenda { get; set; }
        public int TotalVotos { get; set; }

        public virtual ICollection<VoteModel> Votes { get; set; }
    }
}
