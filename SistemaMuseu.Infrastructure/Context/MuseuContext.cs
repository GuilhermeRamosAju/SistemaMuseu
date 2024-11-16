using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Infrastructure.Context;

public class MuseuContext : DbContext
{
    // Construtor do DbContext
    public MuseuContext(DbContextOptions<MuseuContext> options) : base(options) { }

    // Definindo os DbSets para cada entidade
    public DbSet<Artefato> Artefato { get; set; }
    public DbSet<Funcionario> Funcionario { get; set; }
    public DbSet<Exposicao> Exposicao { get; set; }
    public DbSet<Doacao> Doacao { get; set; }
    public DbSet<Visitante> Visitante { get; set; }
    public DbSet<Fornecedor> Fornecedor { get; set; }
    public DbSet<Compra> Compra { get; set; }
    public DbSet<Evento> Evento { get; set; }
    public DbSet<Secao> Secao { get; set; }
    public DbSet<Restauracao> Restauracao { get; set; }

    // Tabelas de relacionamento
    public DbSet<ExposicaoArtefato> ExposicaoArtefato { get; set; }
    public DbSet<EventoVisitante> EventoVisitante { get; set; }

    // Configurações adicionais do modelo (se necessário)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Definindo relacionamentos e regras de mapeamento
        modelBuilder.Entity<Compra>()
            .HasOne(c => c.Fornecedor)
            .WithMany()
            .HasForeignKey(c => c.FornecedorId);

        modelBuilder.Entity<ExposicaoArtefato>()
            .HasKey(ea => new { ea.ExposicaoId, ea.ArtefatoId });

        modelBuilder.Entity<ExposicaoArtefato>()
            .HasOne(ea => ea.Exposicao)
            .WithMany(e => e.ExposicoesArtefatos)
            .HasForeignKey(ea => ea.ExposicaoId);

        modelBuilder.Entity<ExposicaoArtefato>()
            .HasOne(ea => ea.Artefato)
            .WithMany(a => a.ExposicoesArtefatos)
            .HasForeignKey(ea => ea.ArtefatoId);

        modelBuilder.Entity<EventoVisitante>()
            .HasKey(ev => new { ev.EventoId, ev.VisitanteId });

        modelBuilder.Entity<EventoVisitante>()
            .HasOne(ev => ev.Evento)
            .WithMany(e => e.EventoVisitantes)
            .HasForeignKey(ev => ev.EventoId);

        modelBuilder.Entity<EventoVisitante>()
            .HasOne(ev => ev.Visitante)
            .WithMany(v => v.EventoVisitantes)
            .HasForeignKey(ev => ev.VisitanteId);
    }

}
