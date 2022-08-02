namespace Application.Endpoints.Candidates
{
    public record CandidateRequest(
       string Name,
       int CandidateLegend,
       string ViceName,
       Guid ElectionId,
       DateTime RegisterDate,
       int AmountVote = + 1);
    
}