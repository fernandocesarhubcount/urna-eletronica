using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrnaEletronica.Model
{
    public class Candidato
    {
        [Key]
        public int IdCandidato { get; set; }
        [Required]
        public Int32 Legenda { get; set; }
        [Required]
        public string NomeCompleto { get; set; }
        [Required]
        public string NomeVice { get; set; }
        [Required]
        public DateTime DataDeRegistro { get; set; }

        public Candidato(string nomeCompleto, string nomeVice, DateTime? dataRegistro, int legenda)
        {
            NomeCompleto = nomeCompleto;
            NomeVice = nomeVice;
            DataDeRegistro = (DateTime)(dataRegistro == null ? DateTime.Now : dataRegistro);       
            Legenda = legenda;
        }

        public Candidato()
        {

        }
    }
}
