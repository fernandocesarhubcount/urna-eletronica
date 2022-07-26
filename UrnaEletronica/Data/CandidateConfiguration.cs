using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrnaEletronica.Models;

namespace UrnaEletronica.Data
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("candidate");

            builder.HasKey(x => x.Id).HasName("pk_candidate");

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.NomeCanditato).HasColumnName("nome_canditato").IsRequired();
            builder.Property(x => x.NomeVice).HasColumnName("nome_vice").IsRequired();
            builder.Property(x => x.Legenda).HasColumnName("legenda").IsRequired();
            builder.Property(x => x.DataRegistro).HasColumnName("data_registro").IsRequired();
            builder.Property(x => x.QuantidadeVotos).HasColumnName("quantidade_votos").IsRequired();

        }
    }
}
