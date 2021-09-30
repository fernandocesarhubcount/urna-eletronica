using System;
using HubCountApi.Models;
using Microsoft.EntityFrameworkCore; 

#nullable disable

namespace HubCountApi.Data
{
    public partial class HubCountContext : DbContext
    {
        public HubCountContext()
        {
        }

        public HubCountContext(DbContextOptions<HubCountContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CandidateModel> Candidates { get; set; }
        public virtual DbSet<VoteModel> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HubCount;Data Source=DESKTOP-M87Q6VL");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<VoteModel>(entity =>
            {
                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Votes)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
