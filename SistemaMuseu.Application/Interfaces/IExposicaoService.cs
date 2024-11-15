using SistemaMuseu.Application.DTOs;

namespace SistemaMuseu.Application.Interfaces;

public interface IExposicaoService
{
    Task<ExposicaoDTO> AdicionarAsync(ExposicaoDTO exposicaoDto);
    Task<ExposicaoDTO> EditarAsync(ExposicaoDTO exposicaoDto);
    Task<ExposicaoDTO> DeletarAsync(int id);
    Task<ExposicaoDTO> ObterPorIdAsync(int id);
    Task<IEnumerable<ExposicaoDTO>> ObterTodosAsync();
}
