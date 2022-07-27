using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrnaEletronicaWebAPI.Models
{
    public class Candidate
    {
        public Candidate(int legenda, string nome, string nomeVice, DateTime dataRegistro) 
        {
            Legenda = legenda;
            Nome = nome;
            NomeVice = nomeVice;
            DataRegistro = dataRegistro;
        }
        public int Legenda { get; set; }
        public string Nome { get; set; }
        public string NomeVice { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}