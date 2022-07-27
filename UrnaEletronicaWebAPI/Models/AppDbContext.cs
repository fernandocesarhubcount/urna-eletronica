using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UrnaEletronicaWebAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().HasKey("Legenda");
            modelBuilder.Entity<Candidate>().HasData(new List<Candidate>
            {
                new Candidate(10, "Leonardo Macedo", "Felipe Cardoso", DateTime.Now),
                new Candidate(15, "Paula Machado", "Maria Souza", DateTime.Now),
                new Candidate(19, "Diego Oliveira", "Arnildo Silva", DateTime.Now),
                new Candidate(18, "Marcia Fernandes", "Camila Ferreira", DateTime.Now),
                new Candidate(32, "João Campos", "César Oliveira", DateTime.Now),
                new Candidate(45, "Fernanda Pinheiro", "Maurício Mendes", DateTime.Now),
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}