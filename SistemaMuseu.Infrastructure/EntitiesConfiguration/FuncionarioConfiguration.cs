using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Infrastructure.EntitiesConfiguration;

internal class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Cargo)
            .HasMaxLength(50);

        builder.Property(x => x.DataContratacao)
            .HasColumnType("DATE");

        builder.Property(x => x.Salario)
            .HasColumnType("DECIMAL(10,2)");

        builder.Property(x => x.Departamento)
            .HasMaxLength(100);

        builder.Property(x => x.NivelAcesso)
            .HasColumnType("INT");

        builder.Property(x => x.Especialidade)
            .HasMaxLength(100);

    }
}
