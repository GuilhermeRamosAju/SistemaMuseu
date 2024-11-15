using SistemaMuseu.Application.DTOs;

namespace SistemaMuseu.Application.Interfaces;

public interface IVisitanteService
{
    Task<VisitanteDTO> AdicionarAsync(VisitanteDTO visitanteDto);
    Task<VisitanteDTO> EditarAsync(VisitanteDTO visitanteDto);
    Task<VisitanteDTO> DeletarAsync(int id);
    Task<VisitanteDTO> ObterPorIdAsync(int id);
    Task<IEnumerable<VisitanteDTO>> ObterTodosAsync();
}
