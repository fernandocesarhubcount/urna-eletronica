using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrnaAPI.Models
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateId { get; set; }

        [Required]
        public string CandidateName { get; set; }

        [Required]
        public string ViceName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RegistryDate { get; set; }

        [Required]
        public int Ticket { get; set; }

        [ForeignKey("CandidateId")]
        public virtual ICollection<Vote> Votes { get; set; }
    }
}