using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;
using SistemaMuseu.Infrastructure.Context;


public class EventoRepository : IEventoRepository
{
    private readonly MuseuContext _context;

    // Construtor que recebe o DbContext
    public EventoRepository(MuseuContext context)
    {
        _context = context;
    }

    // Adicionar um novo evento
    public async Task<Evento> Adicionar(Evento evento)
    {
        _context.Evento.Add(evento); // Adiciona o evento à tabela
        await _context.SaveChangesAsync(); // Salva as alterações no banco
        return evento; // Retorna o evento adicionado
    }

    // Editar um evento existente
    public async Task<Evento> Editar(Evento evento)
    {
        // Verifica se a entidade Evento já está sendo rastreada
        var existingEntity = _context.Evento.Local.FirstOrDefault(e => e.Id == evento.Id);

        if (existingEntity == null)
        {
            // Se a entidade não estiver rastreada, atualiza o evento
            _context.Evento.Update(evento);
        }
        else
        {
            // Se a entidade já estiver sendo rastreada, apenas atualiza os valores
            _context.Entry(existingEntity).CurrentValues.SetValues(evento);
        }

        // Salva as alterações no banco de dados
        await _context.SaveChangesAsync();
        return evento; // Retorna o evento editado
    }

    // Deletar um evento pelo ID
    public async Task<Evento> Deletar(int id)
    {
        var evento = await _context.Evento.FindAsync(id); // Encontra o evento pelo ID
        if (evento == null)
        {
            return null; // Retorna null caso o evento não seja encontrado
        }
        _context.Evento.Remove(evento); // Remove o evento da tabela
        await _context.SaveChangesAsync(); // Salva as alterações no banco
        return evento; // Retorna o evento deletado
    }

    // Obter um evento pelo ID
    public async Task<Evento> Obter(int id)
    {
        return await _context.Evento.FindAsync(id); // Encontra e retorna o evento pelo ID
    }

    // Obter todos os eventos
    public async Task<IEnumerable<Evento>> ObterTodos()
    {
        return await _context.Evento.ToListAsync(); // Retorna todos os eventos da tabela
    }
}
