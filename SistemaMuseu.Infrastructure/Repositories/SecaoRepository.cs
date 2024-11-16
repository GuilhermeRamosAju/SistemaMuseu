using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;
using SistemaMuseu.Infrastructure.Context;

public class SecaoRepository : ISecaoRepository
{
    private readonly MuseuContext _context;

    // Construtor que recebe o DbContext
    public SecaoRepository(MuseuContext context)
    {
        _context = context;
    }

    // Adicionar uma nova seção
    public async Task<Secao> Adicionar(Secao secao)
    {
        _context.Secao.Add(secao);
        await _context.SaveChangesAsync();
        return secao;
    }

    // Editar uma seção existente
    public async Task<Secao> Editar(Secao secao)
    {
        var existingEntity = _context.Secao.Local.FirstOrDefault(e => e.Id == secao.Id);

        if (existingEntity == null)
        {
            _context.Secao.Update(secao);
        }
        else
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(secao);
        }

        await _context.SaveChangesAsync();
        return secao;
    }

    // Deletar uma seção pelo ID
    public async Task<Secao> Deletar(int id)
    {
        var secao = await _context.Secao.FindAsync(id);
        if (secao == null)
        {
            return null;
        }
        _context.Secao.Remove(secao);
        await _context.SaveChangesAsync();
        return secao;
    }

    // Obter uma seção pelo ID
    public async Task<Secao> Obter(int id)
    {
        return await _context.Secao.FindAsync(id);
    }

    // Obter todas as seções
    public async Task<IEnumerable<Secao>> ObterTodos()
    {
        return await _context.Secao.ToListAsync();
    }
}
