using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrnaEletronicaWebAPI.Models
{
    public class Vote
    {
        public Vote(int? legendaCandidato, DateTime dataVoto)
        {
            LegendaCandidato = legendaCandidato;
            DataVoto = dataVoto;
        }

        public int Id { get; set; }
        public int? LegendaCandidato { get; set; }
        public DateTime DataVoto { get; set; }
    }
}