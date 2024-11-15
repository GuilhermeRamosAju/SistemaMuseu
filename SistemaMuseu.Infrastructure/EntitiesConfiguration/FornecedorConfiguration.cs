using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Infrastructure.EntitiesConfiguration;

internal class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
{
    public void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Contato)
            .HasMaxLength(100);

        builder.Property(x => x.Endereco)
            .HasMaxLength(100);

        builder.Property(x => x.TipoMaterial)
            .HasMaxLength(100);

        builder.Property(x => x.CNPJ)
            .HasMaxLength(20);

        builder.Property(x => x.Avaliacao)
            .HasColumnType("DECIMAL(3,2)");

        builder.Property(x => x.ContratoAtivo)
            .HasColumnType("BOOLEAN");
    }
}
