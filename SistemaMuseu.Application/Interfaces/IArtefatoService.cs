using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Application.Interfaces;

public interface IArtefatoService
{
    Task<ArtefatoDTO> AdicionarAsync(ArtefatoDTO artefato);
    Task<ArtefatoDTO> EditarAsync(Artefato artefato);
    Task<ArtefatoDTO> DeletarAsync(int id);
    Task<Artefato> ObterPorIdAsync(int id);
    Task<IEnumerable<Artefato>> ObterTodosAsync();
}
