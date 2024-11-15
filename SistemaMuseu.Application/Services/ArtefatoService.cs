using AutoMapper;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;

namespace SistemaMuseu.Application.Services;

public class ArtefatoService : IArtefatoService
{
    private readonly IArtefatoRepository _repository;
    private readonly IMapper _mapper;

    public ArtefatoService(IArtefatoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ArtefatoDTO> AdicionarAsync(ArtefatoDTO artefatoDTO)
    {
        var artefato = _mapper.Map<Artefato>(artefatoDTO);
        var artefatoAdicionado = await _repository.Adicionar(artefato);
        return _mapper.Map<ArtefatoDTO>(artefatoAdicionado);
    }

    public async Task<ArtefatoDTO> DeletarAsync(int id)
    {
        var artefatoExcluido = await _repository.Deletar(id);
        return _mapper.Map<ArtefatoDTO>(artefatoExcluido);
    }

    public async Task<ArtefatoDTO> EditarAsync(ArtefatoDTO artefatoDTO)
    {
        var artefato = _mapper.Map<Artefato>(artefatoDTO);
        var artefatoEditado = await _repository.Editar(artefato);
        return _mapper.Map<ArtefatoDTO>(artefatoEditado);
    }

    public async Task<ArtefatoDTO> ObterPorIdAsync(int id)
    {
        var artefato = await _repository.Obter(id);
        return _mapper.Map<ArtefatoDTO>(artefato);
    }

    public async Task<IEnumerable<ArtefatoDTO>> ObterTodosAsync()
    {
        var artefato = await _repository.ObterTodos();
        return _mapper.Map<IEnumerable<ArtefatoDTO>>(artefato);
    }
}
