using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UrnaEletronica.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public DateTime DataVoto { get; set; } = DateTime.Now;
        public int Legenda { get; set; }

        [JsonIgnore]
        public Candidate Candidate { get; set; }
    }
}
