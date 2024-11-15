using AutoMapper;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;

namespace SistemaMuseu.Application.Services;

public class EventoService : IEventoService
{
    private readonly IEventoRepository _repository;
    private readonly IMapper _mapper;

    public EventoService(IEventoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EventoDTO> AdicionarAsync(EventoDTO eventoDTO)
    {
        var evento = _mapper.Map<Evento>(eventoDTO);
        var eventoAdicionado = await _repository.Adicionar(evento);
        return _mapper.Map<EventoDTO>(eventoAdicionado);
    }

    public async Task<EventoDTO> DeletarAsync(int id)
    {
        var eventoExcluido = await _repository.Deletar(id);
        return _mapper.Map<EventoDTO>(eventoExcluido);
    }

    public async Task<EventoDTO> EditarAsync(EventoDTO eventoDTO)
    {
        var evento = _mapper.Map<Evento>(eventoDTO);
        var eventoEditado = await _repository.Editar(evento);
        return _mapper.Map<EventoDTO>(eventoEditado);
    }

    public async Task<EventoDTO> ObterPorIdAsync(int id)
    {
        var evento = await _repository.Obter(id);
        return _mapper.Map<EventoDTO>(evento);
    }

    public async Task<IEnumerable<EventoDTO>> ObterTodosAsync()
    {
        var eventos = await _repository.ObterTodos();
        return _mapper.Map<IEnumerable<EventoDTO>>(eventos);
    }
}
