using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Application.Interfaces;

public interface IExposicaoService
{
    Task<ExposicaoDTO> AdicionarAsync(ExposicaoDTO exposicaoDto);
    Task<ExposicaoDTO> EditarAsync(Exposicao exposicaoDto);
    Task<ExposicaoDTO> DeletarAsync(int id);
    Task<Exposicao> ObterPorIdAsync(int id);
    Task<IEnumerable<Exposicao>> ObterTodosAsync();
}
