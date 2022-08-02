namespace Application.Endpoints.Votes
{
    public record VoteRequest(string SingleVoterTitle, List<int> CandidateLegend, int TotalCandidateVote = + 1);
}