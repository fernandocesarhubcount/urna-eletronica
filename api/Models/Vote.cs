using System;
using api.Models.Base;

namespace api.Models
{
    public class Vote : BaseEntity
    {
        public int Id { get; set; }

        public int CandidateSubTitle { get; set; }

        public static Vote Create(int candidateSubTitle)
        {
            return new()
            {
                CandidateSubTitle = candidateSubTitle,
                CreationDate = DateTime.Now
            };
        }
    }
}