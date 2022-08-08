using System.ComponentModel.DataAnnotations;

namespace HubCount.ElectronicVoting.Models
{
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidates { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
