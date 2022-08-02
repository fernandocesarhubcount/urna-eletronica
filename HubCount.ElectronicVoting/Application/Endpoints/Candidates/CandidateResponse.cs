namespace Application.Endpoints.Candidates;

public record CandidateResponse(
    string Name,
    int CandidateLegend,
    string ElectionName,
    DateTime RegisterDate,
    Guid Id);
