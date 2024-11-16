using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Application.Interfaces;

public interface IRestauracaoService
{
    Task<RestauracaoDTO> AdicionarAsync(RestauracaoDTO restauracaoDto);
    Task<RestauracaoDTO> EditarAsync(Restauracao restauracaoDto);
    Task<RestauracaoDTO> DeletarAsync(int id);
    Task<Restauracao> ObterPorIdAsync(int id);
    Task<IEnumerable<Restauracao>> ObterTodosAsync();
}
