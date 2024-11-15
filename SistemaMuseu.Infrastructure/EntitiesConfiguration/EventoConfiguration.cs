using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Infrastructure.EntitiesConfiguration;

internal class EventoConfiguration : IEntityTypeConfiguration<Evento>
{
    public void Configure(EntityTypeBuilder<Evento> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Data)
            .HasColumnType("DATE");

        builder.Property(x => x.Local)
            .HasMaxLength(100);

        builder.Property(x => x.Descricao)
            .HasColumnType("TEXT");

        builder.Property(x => x.CapacidadeMaxima)
            .HasColumnType("INT");

        builder.Property(x => x.CustoIngresso)
            .HasColumnType("DECIMAL(10,2)");

        builder.Property(x => x.TipoEvento)
            .HasMaxLength(50);
    }
}
