using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;
using SistemaMuseu.Infrastructure.Context;

public class CompraRepository : ICompraRepository
{
    private readonly MuseuContext _context;

    // Construtor que recebe o DbContext
    public CompraRepository(MuseuContext context)
    {
        _context = context;
    }

    // Adicionar uma nova compra
    public async Task<Compra> Adicionar(Compra compra)
    {
        _context.Compra.Add(compra);
        await _context.SaveChangesAsync();
        return compra;
    }

    // Editar uma compra existente
    public async Task<Compra> Editar(Compra compra)
    {
        _context.Compra.Update(compra);
        await _context.SaveChangesAsync();
        return compra;
    }

    // Deletar uma compra pelo ID
    public async Task<Compra> Deletar(int id)
    {
        var compra = await _context.Compra.FindAsync(id);
        if (compra == null)
        {
            return null;
        }
        _context.Compra.Remove(compra);
        await _context.SaveChangesAsync();
        return compra;
    }

    // Obter uma compra pelo ID
    public async Task<Compra> Obter(int id)
    {
        return await _context.Compra.FindAsync(id);
    }

    // Obter todas as compras
    public async Task<IEnumerable<Compra>> ObterTodos()
    {
        return await _context.Compra.ToListAsync();
    }
}
