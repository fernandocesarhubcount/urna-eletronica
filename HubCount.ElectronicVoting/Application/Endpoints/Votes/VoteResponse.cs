namespace Application.Endpoints.Votes;

public record VoteResponse(
    Guid Id,
    string SingleVoterTitle,
    IEnumerable<VoteCandidate> Candidates,

    string StatusVote = "CONFIRMADO!");

public record VoteCandidate(Guid Id, string Name, int CandidateLegend);
