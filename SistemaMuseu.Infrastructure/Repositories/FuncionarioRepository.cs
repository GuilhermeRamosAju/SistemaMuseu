using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;
using SistemaMuseu.Infrastructure.Context;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly MuseuContext _context;

    // Construtor que recebe o DbContext
    public FuncionarioRepository(MuseuContext context)
    {
        _context = context;
    }

    // Adicionar um novo funcionário
    public async Task<Funcionario> Adicionar(Funcionario funcionario)
    {
        _context.Funcionario.Add(funcionario);
        await _context.SaveChangesAsync();
        return funcionario;
    }

    // Editar um funcionário existente
    public async Task<Funcionario> Editar(Funcionario funcionario)
    {
        _context.Funcionario.Update(funcionario);
        await _context.SaveChangesAsync();
        return funcionario;
    }

    // Deletar um funcionário pelo ID
    public async Task<Funcionario> Deletar(int id)
    {
        var funcionario = await _context.Funcionario.FindAsync(id);
        if (funcionario == null)
        {
            return null;
        }
        _context.Funcionario.Remove(funcionario);
        await _context.SaveChangesAsync();
        return funcionario;
    }

    // Obter um funcionário pelo ID
    public async Task<Funcionario> Obter(int id)
    {
        return await _context.Funcionario.FindAsync(id);
    }

    // Obter todos os funcionários
    public async Task<IEnumerable<Funcionario>> ObterTodos()
    {
        return await _context.Funcionario.ToListAsync();
    }
}
