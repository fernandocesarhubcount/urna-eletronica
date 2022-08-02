using Flunt.Validations;

namespace Application.Domain.Candidates;

public class Election : Entity//
{
    public Election(string name)
    {
        Name = name;
        Active = true;
        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Election>()
            .IsNotNullOrEmpty(Name, "Name", "Nome é obrigatorio.");
        AddNotifications(contract);
    }

    public string Name { get;  set; } // Presidente
    public bool Active { get; private set; } //Ativou ou não? 

    public void EditElection(string name, bool active)
    {
        Active = active;
        Name = name;

        Validate();
    }
}

