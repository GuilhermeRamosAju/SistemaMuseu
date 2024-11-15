using SistemaMuseu.Application.DTOs;

namespace SistemaMuseu.Application.Interfaces;

public interface IEventoService
{
    Task<EventoDTO> AdicionarAsync(EventoDTO eventoDto);
    Task<EventoDTO> EditarAsync(EventoDTO eventoDto);
    Task<EventoDTO> DeletarAsync(int id);
    Task<EventoDTO> ObterPorIdAsync(int id);
    Task<IEnumerable<EventoDTO>> ObterTodosAsync();
}
