using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;
using SistemaMuseu.Infrastructure.Context;

public class DoacaoRepository : IDoacaoRepository
{
    private readonly MuseuContext _context;

    public DoacaoRepository(MuseuContext context)
    {
        _context = context;
    }

    public async Task<Doacao> Adicionar(Doacao doacao)
    {
        _context.Doacao.Add(doacao);
        await _context.SaveChangesAsync();
        return doacao;
    }

    public async Task<Doacao> Editar(Doacao doacao)
    {
        var existingEntity = _context.Doacao.Local.FirstOrDefault(d => d.Id == doacao.Id);

        if (existingEntity == null)
        {
            _context.Doacao.Update(doacao);
        }
        else
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(doacao);
        }

        await _context.SaveChangesAsync();
        return doacao;
    }

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

    public async Task<Doacao> Obter(int id)
    {
        return await _context.Doacao
            .Include(c => c.Artefato)
            .FirstAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Doacao>> ObterTodos()
    {
        return await _context.Doacao
            .Include(c => c.Artefato)
            .ToListAsync();
    }
}
