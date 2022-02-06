using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Urna.Core
{

    public class Vote
    {
        public int VoteId { get; set; } // Necessário? Poderia talvez ser uma entidade fraca.

        [Required]
        public int? CandidateId { get; set; } // Será traduzido para foreign key.

        public DateTime DataVoto { get; set; }
        public Candidate Candidato { get; set; } 
}
}
