using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Urna.Core;

namespace Urna.Data
{
    public class UrnaDbContext : DbContext
    {

        public UrnaDbContext (DbContextOptions options) : base(options)
        {

        }

        // Cada DbSet corresponde a uma tabela no banco
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento das tabelas, e mapeamento de foreign key
            modelBuilder.Entity<Candidate>()
                .HasMany(c => c.Votos)
                .WithOne(v => v.Candidato)
                .HasForeignKey(v => v.CandidateId); 

            // Candidato especial que armazena votos brancos deve ser acrescentado manualmente
            modelBuilder.Entity<Candidate>().HasData(
                    new Candidate { CandidateId = -1, Nome = "Branco", NomeVice = "", Legenda = 0, DataRegistro = DateTime.Now }
                );
        }
    }
}
