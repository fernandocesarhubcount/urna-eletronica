using System.ComponentModel.DataAnnotations;

namespace Application.Data.DataTransferObjects.Votes
{
    public class VoteRequestDto
    {
        public DateTime VoteDate { get; set; }
        [Required]
        public int CandidateId { get; set; }
    }
}
