using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Application.Interfaces;

public interface IDoacaoService
{
    Task<DoacaoDTO> AdicionarAsync(Doacao doacaoDto);
    Task<DoacaoDTO> EditarAsync(Doacao doacaoDto);
    Task<DoacaoDTO> DeletarAsync(int id);
    Task<Doacao> ObterPorIdAsync(int id);
    Task<IEnumerable<Doacao>> ObterTodosAsync();
}
