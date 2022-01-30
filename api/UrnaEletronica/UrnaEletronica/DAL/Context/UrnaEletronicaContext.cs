using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.Model;

namespace UrnaEletronica.DAL
{
    public class UrnaEletronicaContext : DbContext
    {
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Voto> Votos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=urna123;Persist Security Info=True;User ID=urna;Initial Catalog=UrnaEletronica;Data Source=DESKTOP-02VFPS9");
        }
    }
}
