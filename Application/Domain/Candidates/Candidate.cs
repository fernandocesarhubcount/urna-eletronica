using Application.Domain.Votes;
using Flunt.Validations;

namespace Application.Domain.Candidates;

public class Candidate : Entity
{
    public Candidate(string name, Election election, int candidateLegend, string viceName, int amountVote)
    {
        Name = name;
        Election = election;
        CandidateLegend = candidateLegend;
        ViceName = viceName;
        RegisterDate = DateTime.Now;
        AmountVote = amountVote;


        Validate();
    }

    public string Name { get; private set; }
    public int CandidateLegend { get; private set; } //ID
    public string ViceName { get; private set; }
    public int AmountVote { get; set; }

    public DateTime RegisterDate { get; private set; }
    public Election Election { get; private set; }
    public Guid ElectionId { get; private set; }
    public ICollection<Vote> Votes { get; set; }

    private Candidate() { }

    private void Validate()
    {
        var contract = new Contract<Candidate>()
            .IsNotNullOrEmpty(Name, "Name", "Está campo não pode ser vazio")
            .IsGreaterOrEqualsThan(Name, 3, "Name")
            .IsNotNull(Election, "Election")
            .IsNotNullOrEmpty(ViceName, "ViceName");
        AddNotifications(contract);
    }
}

