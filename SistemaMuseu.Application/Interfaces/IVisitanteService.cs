using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Application.Interfaces;

public interface IVisitanteService
{
    Task<VisitanteDTO> AdicionarAsync(VisitanteDTO visitanteDto);
    Task<VisitanteDTO> EditarAsync(Visitante visitanteDto);
    Task<VisitanteDTO> DeletarAsync(int id);
    Task<Visitante> ObterPorIdAsync(int id);
    Task<IEnumerable<Visitante>> ObterTodosAsync();
}
