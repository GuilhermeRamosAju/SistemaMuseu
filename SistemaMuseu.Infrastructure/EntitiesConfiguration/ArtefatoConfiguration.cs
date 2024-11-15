using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Infrastructure.EntitiesConfiguration;

internal class ArtefatoConfiguration : IEntityTypeConfiguration<Artefato>
{
    public void Configure(EntityTypeBuilder<Artefato> builder)
    {
        // Chave primária
        builder.HasKey(x => x.Id);

        // Propriedades
        builder.Property(x => x.Nome)
            .IsRequired() // Campo obrigatório
            .HasMaxLength(100); // Definindo o tamanho máximo da string

        builder.Property(x => x.Origem)
            .IsRequired() // Campo obrigatório
            .HasMaxLength(100); // Definindo o tamanho máximo da string

        builder.Property(x => x.PeriodoHistorico)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Tipo)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Descricao)
            .HasColumnType("TEXT"); // Campo opcional

        builder.Property(x => x.DataAquisicao)
            .IsRequired()
            .HasColumnType("DATE");// Campo obrigatório, data da aquisição

        builder.Property(x => x.Estado)
            .IsRequired()
            .HasMaxLength(50); // Estado do artefato (ex: Bom, Ruim, etc.)

        builder.Property(x => x.Valor)
            .HasColumnType("decimal(18,2)"); // Tipo decimal para valor monetário

        builder.Property(x => x.LocalizacaoAtual)
            .HasMaxLength(100); // Localização do artefato no museu

        // Relacionamentos
        builder.HasMany(x => x.ExposicoesArtefatos)
            .WithOne(x => x.Artefato)
            .HasForeignKey(x => x.ArtefatoId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento com a entidade Doacao (um artefato pode ter várias doações)
        builder.HasMany(x => x.Doacoes)
            .WithOne(x => x.Artefato)
            .HasForeignKey(x => x.ArtefatoId)
            .OnDelete(DeleteBehavior.Cascade); // Quando um artefato for deletado, as doações associadas também serão deletadas

        // Relacionamento com a entidade Restauracao (um artefato pode ter várias restaurações)
        builder.HasMany(x => x.Restauracoes)
            .WithOne(x => x.Artefato)
            .HasForeignKey(x => x.ArtefatoId)
            .OnDelete(DeleteBehavior.SetNull); // Caso um artefato seja deletado, restaurações não serão deletadas, mas terão o ArtefatoId como null

        // Tabela
        builder.ToTable("Artefatos");
    }
}
