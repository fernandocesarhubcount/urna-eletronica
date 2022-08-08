using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubCount.ElectronicVoting.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Nome é requirido.")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ViceName { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Election { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string Status { get; set; } = "Active";
  
        public int Legend { get; set; }
    }
}
