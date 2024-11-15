using SistemaMuseu.Application.DTOs;

namespace SistemaMuseu.Application.Interfaces;

public interface IArtefatoService
{
    Task<ArtefatoDTO> Adicionar(ArtefatoDTO artefato);

    Task<ArtefatoDTO> Editar(ArtefatoDTO artefato);

    Task<ArtefatoDTO> Deletar(int id);

    Task<ArtefatoDTO> Obter(int id);

    Task<IEnumerable<ArtefatoDTO>> ObterTodos();
}
