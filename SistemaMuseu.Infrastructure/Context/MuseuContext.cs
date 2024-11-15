using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Infrastructure.Context;

internal class MuseuContext : DbContext
{
    // Construtor do DbContext
    protected MuseuContext(DbContextOptions<MuseuContext> options) : base(options) { }

    // Definindo os DbSets para cada entidade
    public DbSet<Artefato> Artefatos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Exposicao> Exposicoes { get; set; }
    public DbSet<Doacao> Doacoes { get; set; }
    public DbSet<Visitante> Visitantes { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Compra> Compras { get; set; }
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Secao> Secoes { get; set; }
    public DbSet<Restauracao> Restauracoes { get; set; }

    // Tabelas de relacionamento
    public DbSet<ExposicaoArtefato> ExposicaoArtefatos { get; set; }
    public DbSet<EventoVisitante> EventoVisitantes { get; set; }

    // Configurações adicionais do modelo (se necessário)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Definindo relacionamentos e regras de mapeamento
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
