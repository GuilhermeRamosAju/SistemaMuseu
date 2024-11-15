using AutoMapper;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;

namespace SistemaMuseu.Application.Services;

public class VisitanteService : IVisitanteService
{
    private readonly IVisitanteRepository _repository;
    private readonly IMapper _mapper;

    public VisitanteService(IVisitanteRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<VisitanteDTO> AdicionarAsync(VisitanteDTO visitanteDTO)
    {
        var visitante = _mapper.Map<Visitante>(visitanteDTO);
        var visitanteAdicionado = await _repository.Adicionar(visitante);
        return _mapper.Map<VisitanteDTO>(visitanteAdicionado);
    }

    public async Task<VisitanteDTO> DeletarAsync(int id)
    {
        var visitanteExcluido = await _repository.Deletar(id);
        return _mapper.Map<VisitanteDTO>(visitanteExcluido);
    }

    public async Task<VisitanteDTO> EditarAsync(VisitanteDTO visitanteDTO)
    {
        var visitante = _mapper.Map<Visitante>(visitanteDTO);
        var visitanteEditado = await _repository.Editar(visitante);
        return _mapper.Map<VisitanteDTO>(visitanteEditado);
    }

    public async Task<VisitanteDTO> ObterPorIdAsync(int id)
    {
        var visitante = await _repository.Obter(id);
        return _mapper.Map<VisitanteDTO>(visitante);
    }

    public async Task<IEnumerable<VisitanteDTO>> ObterTodosAsync()
    {
        var visitantes = await _repository.ObterTodos();
        return _mapper.Map<IEnumerable<VisitanteDTO>>(visitantes);
    }
}
