using Application.Domain.Candidates;
using Application.Domain.Votes;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Data;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Ignore<Notification>();

        builder.Entity<Candidate>()
             .Property(c => c.Name).HasMaxLength(120).IsRequired();

        builder.Entity<Candidate>()
             .Property(c => c.ViceName).HasMaxLength(120).IsRequired();

        builder.Entity<Candidate>()
             .Property(c => c.CandidateLegend).IsRequired();

        builder.Entity<Vote>()
             .HasMany(v => v.Candidates)
             .WithMany(c => c.Votes)
             .UsingEntity(x => x.ToTable("VoteCandidates")); //Criando tabela que armazena voto total dos candidatos

        builder.Entity<Electorate>().HasData(
            new Electorate
            {
                SingleVoterTitle = "007321"
            });
    }

    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Election> Elections { get; set; }
    public DbSet<Electorate> Electorates { get; set; }
    public DbSet<Vote> Votes { get; set; }


    //Criar converção

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(200); //100 caracteres
    }
}

