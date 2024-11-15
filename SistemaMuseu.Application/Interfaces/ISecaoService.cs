using SistemaMuseu.Application.DTOs;

namespace SistemaMuseu.Application.Interfaces;

public interface ISecaoService
{
    Task<SecaoDTO> AdicionarAsync(SecaoDTO secaoDto);
    Task<SecaoDTO> EditarAsync(SecaoDTO secaoDto);
    Task<SecaoDTO> DeletarAsync(int id);
    Task<SecaoDTO> ObterPorIdAsync(int id);
    Task<IEnumerable<SecaoDTO>> ObterTodosAsync();
}
