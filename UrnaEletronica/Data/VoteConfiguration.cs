using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrnaEletronica.Models;

namespace UrnaEletronica.Data
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable("vote");

            builder.HasKey(x => x.Id).HasName("pk_vote");

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CandidateId). HasColumnName("candidate_id").IsRequired();
            builder.Property(x => x.DataVoto).HasColumnName("data_voto").IsRequired();
            builder.Property(x => x.Legenda).HasColumnName("legenda_codigo").IsRequired();
        }
    }
}
