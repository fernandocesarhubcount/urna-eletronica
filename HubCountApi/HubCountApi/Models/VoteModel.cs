using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HubCountApi.Models
{
    public partial class VoteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Datavoto")]
        public DateTime Datavoto { get; set; } 
        public int? CandidateId { get; set; }

        public int? CodigoCandidato { get; set; }


        public virtual CandidateModel Candidate { get; set; }
    }
}
