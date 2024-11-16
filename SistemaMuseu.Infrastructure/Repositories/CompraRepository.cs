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
        _context.Compra.Add(compra); // Adiciona a compra à tabela
        await _context.SaveChangesAsync(); // Salva as alterações no banco
        return compra; // Retorna a compra adicionada
    }

    // Editar uma compra existente
    public async Task<Compra> Editar(Compra compra)
    {
        // Verifica se a entidade Compra já está sendo rastreada
        var existingEntity = _context.Compra.Local.FirstOrDefault(c => c.Id == compra.Id);

        if (existingEntity == null)
        {
            // Se a entidade não estiver sendo rastreada, atualiza a compra
            _context.Compra.Update(compra);
        }
        else
        {
            // Se a entidade já estiver sendo rastreada, apenas atualiza os valores
            _context.Entry(existingEntity).CurrentValues.SetValues(compra);
        }

        // Salva as alterações no banco de dados
        await _context.SaveChangesAsync();
        return compra; // Retorna a compra editada
    }

    // Deletar uma compra pelo ID
    public async Task<Compra> Deletar(int id)
    {
        var compra = await _context.Compra.FindAsync(id); // Encontra a compra pelo ID
        if (compra == null)
        {
            return null; // Retorna null caso a compra não seja encontrada
        }
        _context.Compra.Remove(compra); // Remove a compra da tabela
        await _context.SaveChangesAsync(); // Salva as alterações no banco
        return compra; // Retorna a compra deletada
    }

    // Obter uma compra pelo ID
    public async Task<Compra> Obter(int id)
    {
        return await _context.Compra
        .Include(c => c.Fornecedor) // Carrega os dados do fornecedor
        .FirstAsync(c => c.Id == id); ; // Encontra e retorna a compra pelo ID
    }

    // Obter todas as compras
    public async Task<IEnumerable<Compra>> ObterTodos()
    {
        return await _context.Compra.Include(c => c.Fornecedor).ToListAsync(); // Retorna todas as compras da tabela
    }
}
