using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;
using SistemaMuseu.Infrastructure.Context;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly MuseuContext _context;

    public FuncionarioRepository(MuseuContext context)
    {
        _context = context;
    }

    public async Task<Funcionario> Adicionar(Funcionario funcionario)
    {
        _context.Funcionario.Add(funcionario);
        await _context.SaveChangesAsync();
        return funcionario;
    }

    public async Task<Funcionario> Editar(Funcionario funcionario)
    {
        var existingEntity = _context.Funcionario.Local.FirstOrDefault(e => e.Id == funcionario.Id);

        if (existingEntity == null)
        {
            _context.Funcionario.Update(funcionario);
        }
        else
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(funcionario);
        }

        await _context.SaveChangesAsync();
        return funcionario;
    }

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

    public async Task<Funcionario> Obter(int id)
    {
        return await _context.Funcionario.FindAsync(id);
    }

    public async Task<IEnumerable<Funcionario>> ObterTodos()
    {
        return await _context.Funcionario.ToListAsync();
    }
}
