using System;
using api.Models.Base;

namespace api.Models
{
    public class Vote : BaseEntity
    {
        public int Id { get; set; }

        public int CandidateLegend { get; set; }

        public static Vote Create(int candidateLegend)
        {
            return new()
            {
                CandidateLegend = candidateLegend,
                CreationDate = DateTime.Now
            };
        }
    }
}