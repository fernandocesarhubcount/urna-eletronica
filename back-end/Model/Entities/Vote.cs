namespace Model.Entities
{
    public class Vote
    {
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
