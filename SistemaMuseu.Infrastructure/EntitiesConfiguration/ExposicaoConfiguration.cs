using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMuseu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMuseu.Infrastructure.EntitiesConfiguration;

internal class ExposicaoConfiguration : IEntityTypeConfiguration<Exposicao>
{
    public void Configure(EntityTypeBuilder<Exposicao> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.DataInicio)
            .HasColumnType("DATE");

        builder.Property(x => x.DataFim)
            .HasColumnType("DATE");

        builder.Property(x => x.Local)
            .HasMaxLength(100);

        builder.Property(x => x.Descricao)
            .HasColumnType("TEXT");

        builder.Property(x => x.CapacidadeMaxima)
            .HasColumnType("INT");

        builder.Property(x => x.TipoDoacao)
            .HasMaxLength(50);

        builder.Property(x => x.CustoTotal)
            .HasColumnType("DECIMAL(10,2)");

        builder.HasOne(x => x.Responsavel)
            .WithMany()
            .HasForeignKey(x => x.ResponsavelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
