using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Infrastructure.EntitiesConfiguration;

internal class CompraConfiguration : IEntityTypeConfiguration<Compra>
{
    public void Configure(EntityTypeBuilder<Compra> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Data)
            .HasColumnType("DATE");

        builder.Property(x => x.ValorTotal)
            .HasColumnType("DECIMAL(10,2)");

        builder.Property(x => x.Descricao)
            .HasColumnType("TEXT");

        builder.Property(x => x.Status)
            .HasMaxLength(50);

        builder.Property(x => x.FormaPagamento)
            .HasMaxLength(50);

        builder.Property(x => x.NumeroNF)
            .HasMaxLength(20);

        builder.HasOne(x => x.Fornecedor)
            .WithMany()
            .HasForeignKey(x => x.FornecedorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
