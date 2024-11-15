using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;
using SistemaMuseu.Infrastructure.Context;

public class FornecedorRepository : IFornecedorRepository
{
    private readonly MuseuContext _context;

    // Construtor que recebe o DbContext
    public FornecedorRepository(MuseuContext context)
    {
        _context = context;
    }

    // Adicionar um novo fornecedor
    public async Task<Fornecedor> Adicionar(Fornecedor fornecedor)
    {
        _context.Fornecedor.Add(fornecedor);
        await _context.SaveChangesAsync();
        return fornecedor;
    }

    // Editar um fornecedor existente
    public async Task<Fornecedor> Editar(Fornecedor fornecedor)
    {
        _context.Fornecedor.Update(fornecedor);
        await _context.SaveChangesAsync();
        return fornecedor;
    }

    // Deletar um fornecedor pelo ID
    public async Task<Fornecedor> Deletar(int id)
    {
        var fornecedor = await _context.Fornecedor.FindAsync(id);
        if (fornecedor == null)
        {
            return null;
        }
        _context.Fornecedor.Remove(fornecedor);
        await _context.SaveChangesAsync();
        return fornecedor;
    }

    // Obter um fornecedor pelo ID
    public async Task<Fornecedor> Obter(int id)
    {
        return await _context.Fornecedor.FindAsync(id);
    }

    // Obter todos os fornecedores
    public async Task<IEnumerable<Fornecedor>> ObterTodos()
    {
        return await _context.Fornecedor.ToListAsync();
    }
}
