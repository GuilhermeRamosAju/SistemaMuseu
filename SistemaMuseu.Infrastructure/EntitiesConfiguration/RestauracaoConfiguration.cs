using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Infrastructure.EntitiesConfiguration;

internal class RestauracaoConfiguration : IEntityTypeConfiguration<Restauracao>
{
    public void Configure(EntityTypeBuilder<Restauracao> builder)
    {
        // Define a chave primária
        builder.HasKey(r => r.Id);

        // Configura as propriedades
        builder.Property(r => r.DataInicio)
            .HasColumnType("DATE")
            .IsRequired();

        builder.Property(r => r.DataFim)
            .HasColumnType("DATE");

        builder.Property(r => r.Descricao)
            .HasColumnType("TEXT");

        builder.Property(r => r.Custo)
            .HasColumnType("DECIMAL(10, 2)");

        builder.Property(r => r.TecnicasUtilizadas)
            .HasColumnType("TEXT");

        builder.Property(r => r.MateriaisUsados)
            .HasColumnType("TEXT");

        builder.Property(r => r.Status)
            .HasMaxLength(50);

        // Relacionamento com a tabela Artefato
        builder.HasOne(r => r.Artefato)  // Cada restauracao tem um Artefato
            .WithMany()  // Não é necessário ter uma coleção de Restauracoes no Artefato
            .HasForeignKey(r => r.ArtefatoId)  // A chave estrangeira será ArtefatoId na tabela Restauracao
            .OnDelete(DeleteBehavior.Cascade);  // Quando um Artefato for deletado, as Restauracoes associadas também serão
    }
}
