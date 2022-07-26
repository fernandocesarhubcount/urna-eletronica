using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UrnaEletronica.Models
{
    [Index (nameof(Legenda), IsUnique = true)]
    public class Candidate
    {
        public int Id { get; set; }
        public string NomeCanditato { get; set; }
        public string NomeVice { get; set; }
        public int Legenda { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.Now;
        public int QuantidadeVotos { get; set; } = 0;

        [JsonIgnore]
        public ICollection<Vote> Vote { get; set; }
    }
}
