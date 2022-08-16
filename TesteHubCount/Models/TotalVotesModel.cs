namespace TesteHubCount.Models
{
  public class TotalVotesModel
  {
    public TotalVotesModel()
    {

    }
    public TotalVotesModel(CandidateModel candidate, int totalVotes)
    {
      CandidateModel = candidate;
      TotalVotes = totalVotes;
    }
    public CandidateModel CandidateModel { get; set; }
    public int TotalVotes { get; set; }
  }
}