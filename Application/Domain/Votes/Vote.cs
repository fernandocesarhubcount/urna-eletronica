using Application.Domain.Candidates;

namespace Application.Domain.Votes;

public class Vote : Entity
{
    public Vote(string singleVoterTitle, List<Candidate> candidates)
    {

        SingleVoterTitle = singleVoterTitle; //ID
        Candidates = candidates;
        RegisterVote = DateTime.UtcNow;
        StatusVote = "CONFIRMADO";

        TotalCandidateVote = 0;
        foreach (var vote in Candidates)
        {
            TotalCandidateVote += vote.AmountVote;
        }
    }


    private Vote() { }

    public string SingleVoterTitle { get; set; }
    public List<Candidate> Candidates { get; set; }
    public int TotalCandidateVote { get; set; }
    public string StatusVote { get; set; }
    public DateTime RegisterVote { get; set; }
}

