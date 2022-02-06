using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Urna.Core
{
    public class Candidate
    {
        public int CandidateId { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 4)]
        public string Nome { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 4)]
        public string NomeVice { get; set; }

        public DateTime DataRegistro { get; set; }

        [Required]
        [Range(1,99)]
        public int? Legenda { get; set; }

        public List<Vote> Votos { get; set; }

        // Permite que a propriedade de QtdVotos seja adicionada a essa classe, mas não seja mapeada ao banco de dados.
        [NotMapped] 
        public int QtdVotos { get; set; } 
    }
}
