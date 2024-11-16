using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;
using SistemaMuseu.Infrastructure.Context;

public class ExposicaoRepository : IExposicaoRepository
{
    private readonly MuseuContext _context;

    public ExposicaoRepository(MuseuContext context)
    {
        _context = context;
    }

    public async Task<Exposicao> Adicionar(Exposicao exposicao)
    {
        _context.Exposicao.Add(exposicao);
        await _context.SaveChangesAsync();
        return exposicao;
    }

    public async Task<Exposicao> Editar(Exposicao exposicao)
    {
        var existingEntity = _context.Exposicao.Local.FirstOrDefault(e => e.Id == exposicao.Id);

        if (existingEntity == null)
        {
            _context.Exposicao.Update(exposicao);
        }
        else
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(exposicao);
        }

        await _context.SaveChangesAsync();
        return exposicao;
    }

    public async Task<Exposicao> Deletar(int id)
    {
        var exposicao = await _context.Exposicao.FindAsync(id);
        if (exposicao == null)
        {
            return null;
        }
        _context.Exposicao.Remove(exposicao);
        await _context.SaveChangesAsync();
        return exposicao;
    }

    public async Task<Exposicao> Obter(int id)
    {
        return await _context.Exposicao.FindAsync(id);
    }

    public async Task<IEnumerable<Exposicao>> ObterTodos()
    {
        return await _context.Exposicao.ToListAsync();
    }
}
