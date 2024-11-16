using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Application.Interfaces;

public interface IEventoService
{
    Task<EventoDTO> AdicionarAsync(EventoDTO eventoDto);
    Task<EventoDTO> EditarAsync(Evento eventoDto);
    Task<EventoDTO> DeletarAsync(int id);
    Task<Evento> ObterPorIdAsync(int id);
    Task<IEnumerable<Evento>> ObterTodosAsync();
}
