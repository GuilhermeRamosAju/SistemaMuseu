using SistemaMuseu.Application.DTOs;

namespace SistemaMuseu.Application.Interfaces;

public interface IArtefatoService
{
    Task<ArtefatoDTO> AdicionarAsync(ArtefatoDTO artefato);
    Task<ArtefatoDTO> EditarAsync(ArtefatoDTO artefato);
    Task<ArtefatoDTO> DeletarAsync(int id);
    Task<ArtefatoDTO> ObterPorIdAsync(int id);
    Task<IEnumerable<ArtefatoDTO>> ObterTodosAsync();
}
