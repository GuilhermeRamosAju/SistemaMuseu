using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;
using SistemaMuseu.Infrastructure.Context;

public class ExposicaoRepository : IExposicaoRepository
{
    private readonly MuseuContext _context;

    // Construtor que recebe o DbContext
    public ExposicaoRepository(MuseuContext context)
    {
        _context = context;
    }

    // Adicionar uma nova exposição
    public async Task<Exposicao> Adicionar(Exposicao exposicao)
    {
        _context.Exposicao.Add(exposicao);
        await _context.SaveChangesAsync();
        return exposicao;
    }

    // Editar uma exposição existente
    public async Task<Exposicao> Editar(Exposicao exposicao)
    {
        _context.Exposicao.Update(exposicao);
        await _context.SaveChangesAsync();
        return exposicao;
    }

    // Deletar uma exposição pelo ID
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

    // Obter uma exposição pelo ID
    public async Task<Exposicao> Obter(int id)
    {
        return await _context.Exposicao.FindAsync(id);
    }

    // Obter todas as exposições
    public async Task<IEnumerable<Exposicao>> ObterTodos()
    {
        return await _context.Exposicao.ToListAsync();
    }
}
