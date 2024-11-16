using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;
using SistemaMuseu.Infrastructure.Context;

public class RestauracaoRepository : IRestauracaoRepository
{
    private readonly MuseuContext _context;

    // Construtor que recebe o DbContext
    public RestauracaoRepository(MuseuContext context)
    {
        _context = context;
    }

    // Adicionar uma nova restauração
    public async Task<Restauracao> Adicionar(Restauracao restauracao)
    {
        _context.Restauracao.Add(restauracao);
        await _context.SaveChangesAsync();
        return restauracao;
    }

    // Editar uma restauração existente
    public async Task<Restauracao> Editar(Restauracao restauracao)
    {
        var existingEntity = _context.Restauracao.Local.FirstOrDefault(e => e.Id == restauracao.Id);

        if (existingEntity == null)
        {
            _context.Restauracao.Update(restauracao);
        }
        else
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(restauracao);
        }

        await _context.SaveChangesAsync();
        return restauracao;
    }

    // Deletar uma restauração pelo ID
    public async Task<Restauracao> Deletar(int id)
    {
        var restauracao = await _context.Restauracao.FindAsync(id);
        if (restauracao == null)
        {
            return null;
        }
        _context.Restauracao.Remove(restauracao);
        await _context.SaveChangesAsync();
        return restauracao;
    }

    // Obter uma restauração pelo ID
    public async Task<Restauracao> Obter(int id)
    {
        return await _context.Restauracao.FindAsync(id);
    }

    // Obter todas as restaurações
    public async Task<IEnumerable<Restauracao>> ObterTodos()
    {
        return await _context.Restauracao.ToListAsync();
    }
}
