using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;
using SistemaMuseu.Infrastructure.Context;

public class DoacaoRepository : IDoacaoRepository
{
    private readonly MuseuContext _context;

    // Construtor que recebe o DbContext
    public DoacaoRepository(MuseuContext context)
    {
        _context = context;
    }

    // Adicionar uma nova doação
    public async Task<Doacao> Adicionar(Doacao doacao)
    {
        _context.Doacao.Add(doacao);
        await _context.SaveChangesAsync();
        return doacao;
    }

    // Editar uma doação existente
    public async Task<Doacao> Editar(Doacao doacao)
    {
        _context.Doacao.Update(doacao);
        await _context.SaveChangesAsync();
        return doacao;
    }

    // Deletar uma doação pelo ID
    public async Task<Doacao> Deletar(int id)
    {
        var doacao = await _context.Doacao.FindAsync(id);
        if (doacao == null)
        {
            return null;
        }
        _context.Doacao.Remove(doacao);
        await _context.SaveChangesAsync();
        return doacao;
    }

    // Obter uma doação pelo ID
    public async Task<Doacao> Obter(int id)
    {
        return await _context.Doacao.FindAsync(id);
    }

    // Obter todas as doações
    public async Task<IEnumerable<Doacao>> ObterTodos()
    {
        return await _context.Doacao.ToListAsync();
    }
}
