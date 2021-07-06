using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrnaAPI.Models
{
    public class Vote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoteId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RegistryDate { get; set; }

        [Required]
        public int CandidateId { get; set; }

        public Candidate Candidate { get; set; }
    }
}