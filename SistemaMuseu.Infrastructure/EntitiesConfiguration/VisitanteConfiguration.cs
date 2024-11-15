using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Infrastructure.EntitiesConfiguration
{
    internal class VisitanteConfiguration : IEntityTypeConfiguration<Visitante>
    {
        public void Configure(EntityTypeBuilder<Visitante> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Idade)
                .HasColumnType("INT");

            builder.Property(x => x.Email)
                .HasMaxLength(100);

            builder.Property(x => x.Telefone)
                .HasMaxLength(20);

            builder.Property(x => x.DataVisita)
                .HasColumnType("DATE");

            builder.Property(x => x.TipoIngresso)
                .HasMaxLength(50);

            builder.Property(x => x.Nacionalidade)
                .HasMaxLength(50);
        }
    }
}
