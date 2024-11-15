using SistemaMuseu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaMuseu.Infrastructure.EntitiesConfiguration;

internal class DoacaoConfiguration : IEntityTypeConfiguration<Doacao>
{
    public void Configure(EntityTypeBuilder<Doacao> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Doador)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Data)
            .HasColumnType("DATE");

        builder.Property(x => x.Valor)
            .HasColumnType("DECIMAL(10,2)");

        builder.Property(x => x.Descricao)
            .HasColumnType("TEXT");

        builder.Property(x => x.TipoDoacao)
            .HasMaxLength(50);

        builder.Property(x => x.Certificado)
            .HasMaxLength(100);

        builder.HasOne(x => x.Artefato)
            .WithMany()
            .HasForeignKey(x => x.ArtefatoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
