using SistemaMuseu.Application.DTOs;

namespace SistemaMuseu.Application.Interfaces;

public interface IDoacaoService
{
    Task<DoacaoDTO> AdicionarAsync(DoacaoDTO doacaoDto);
    Task<DoacaoDTO> EditarAsync(DoacaoDTO doacaoDto);
    Task<DoacaoDTO> DeletarAsync(int id);
    Task<DoacaoDTO> ObterPorIdAsync(int id);
    Task<IEnumerable<DoacaoDTO>> ObterTodosAsync();
}
