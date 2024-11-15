using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Infrastructure.EntitiesConfiguration;

internal class SecaoConfiguration : IEntityTypeConfiguration<Secao>
{
    public void Configure(EntityTypeBuilder<Secao> builder)
    {
        builder.HasKey(x => x.Id);  // Define a chave primária

        builder.Property(x => x.Nome)
            .HasMaxLength(100)  // Define o tamanho máximo para o nome da seção
            .IsRequired(false);  // O nome pode ser nulo

        builder.Property(x => x.Tema)
            .HasMaxLength(100)  // Define o tamanho máximo para o tema da seção
            .IsRequired(false);  // O tema pode ser nulo

        builder.Property(x => x.Descricao)
            .HasColumnType("TEXT")  // Define o tipo de dado para a descrição da seção
            .IsRequired(false);  // A descrição pode ser nula

        builder.Property(x => x.Capacidade)
            .HasColumnType("INT")  // Define o tipo de dado para a capacidade
            .IsRequired(false);  // Capacidade pode ser nula

        builder.Property(x => x.Temperatura)
            .HasColumnType("DECIMAL(5, 2)")  // Define o tipo de dado para a temperatura
            .IsRequired(false);  // Temperatura pode ser nula

        builder.Property(x => x.Umidade)
            .HasColumnType("DECIMAL(5, 2)")  // Define o tipo de dado para a umidade
            .IsRequired(false);  // Umidade pode ser nula

        builder.Property(x => x.NivelSeguranca)
            .HasColumnType("INT")  // Define o tipo de dado para o nível de segurança
            .IsRequired(false);  // Nível de segurança pode ser nulo

        // Relacionamento com Funcionario
        builder.HasOne<Funcionario>()    // Relacionamento com o funcionário
            .WithMany()  // Um funcionário pode ser responsável por várias seções
            .HasForeignKey(x => x.Responsavel)  // Define a chave estrangeira
            .OnDelete(DeleteBehavior.SetNull);  // Se o funcionário for excluído, a referência será nula
    }
}
