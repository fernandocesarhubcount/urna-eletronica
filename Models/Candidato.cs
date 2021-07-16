using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrnaEletronica.Models
{
    public class Candidato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Codigo { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }

        [Required, StringLength(100)]
        public string Partido { get; set; }

        [Required, StringLength(100)]
        public string Vice { get; set; }

        [Required]
        public DateTime DataRegistro { get; set; }
    }
}
