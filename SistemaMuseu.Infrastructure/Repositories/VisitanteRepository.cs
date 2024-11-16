using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;
using SistemaMuseu.Infrastructure.Context;

public class VisitanteRepository : IVisitanteRepository
{
    private readonly MuseuContext _context;

    // Construtor que recebe o DbContext
    public VisitanteRepository(MuseuContext context)
    {
        _context = context;
    }

    // Adicionar um novo visitante
    public async Task<Visitante> Adicionar(Visitante visitante)
    {
        _context.Visitante.Add(visitante);
        await _context.SaveChangesAsync();
        return visitante;
    }

    // Editar um visitante existente
    public async Task<Visitante> Editar(Visitante visitante)
    {
        var existingEntity = _context.Visitante.Local.FirstOrDefault(e => e.Id == visitante.Id);

        if (existingEntity == null)
        {
            _context.Visitante.Update(visitante);
        }
        else
        {
            _context.Entry(existingEntity).CurrentValues.SetValues(visitante);
        }

        await _context.SaveChangesAsync();
        return visitante;
    }

    // Deletar um visitante pelo ID
    public async Task<Visitante> Deletar(int id)
    {
        var visitante = await _context.Visitante.FindAsync(id);
        if (visitante == null)
        {
            return null;
        }
        _context.Visitante.Remove(visitante);
        await _context.SaveChangesAsync();
        return visitante;
    }

    // Obter um visitante pelo ID
    public async Task<Visitante> Obter(int id)
    {
        return await _context.Visitante.FindAsync(id);
    }

    // Obter todos os visitantes
    public async Task<IEnumerable<Visitante>> ObterTodos()
    {
        return await _context.Visitante.ToListAsync();
    }
}
