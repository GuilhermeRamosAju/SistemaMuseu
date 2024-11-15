using SistemaMuseu.Application.DTOs;

namespace SistemaMuseu.Application.Interfaces;

public interface IRestauracaoService
{
    Task<RestauracaoDTO> AdicionarAsync(RestauracaoDTO restauracaoDto);
    Task<RestauracaoDTO> EditarAsync(RestauracaoDTO restauracaoDto);
    Task<RestauracaoDTO> DeletarAsync(int id);
    Task<RestauracaoDTO> ObterPorIdAsync(int id);
    Task<IEnumerable<RestauracaoDTO>> ObterTodosAsync();
}
