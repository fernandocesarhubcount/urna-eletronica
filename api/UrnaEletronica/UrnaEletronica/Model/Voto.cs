using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.DAL;
using UrnaEletronica.DAL.Repositories;
using UrnaEletronica.DAL.Repositories.Interfaces;
using UrnaEletronica.Model.Inputs;

namespace UrnaEletronica.Model
{
    public class Voto
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Candidato")]
        public int? IdCandidato { get; set; }
        public virtual Candidato  Candidato{ get; set; }
        [Required]
        public DateTime DataDoVoto { get; set; }
        [Required]
        public bool VotoEmBranco { get; set; }

        public Voto(FormVoto form)
        {
            IdCandidato = form.IdCandidato;
            VotoEmBranco = form.VotoEmBranco;
            DataDoVoto = DateTime.Now;
        }

        public Voto()
        {

        }
    }
}
