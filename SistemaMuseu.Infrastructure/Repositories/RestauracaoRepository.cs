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
    public async Task<Restauracao> Adicionar(Restauracao restauração)
    {
        _context.Restauracao.Add(restauração);
        await _context.SaveChangesAsync();
        return restauração;
    }

    // Editar uma restauração existente
    public async Task<Restauracao> Editar(Restauracao restauração)
    {
        _context.Restauracao.Update(restauração);
        await _context.SaveChangesAsync();
        return restauração;
    }

    // Deletar uma restauração pelo ID
    public async Task<Restauracao> Deletar(int id)
    {
        var restauração = await _context.Restauracao.FindAsync(id);
        if (restauração == null)
        {
            return null;
        }
        _context.Restauracao.Remove(restauração);
        await _context.SaveChangesAsync();
        return restauração;
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
