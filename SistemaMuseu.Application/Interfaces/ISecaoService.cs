using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Application.Interfaces;

public interface ISecaoService
{
    Task<SecaoDTO> AdicionarAsync(Secao secaoDto);
    Task<SecaoDTO> EditarAsync(Secao secaoDto);
    Task<SecaoDTO> DeletarAsync(int id);
    Task<Secao> ObterPorIdAsync(int id);
    Task<IEnumerable<Secao>> ObterTodosAsync();
}
