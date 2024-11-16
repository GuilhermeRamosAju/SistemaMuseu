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

    public async Task<EventoDTO> EditarAsync(Evento evento)
    {
        var eventoEditado = await _repository.Editar(evento);
        return _mapper.Map<EventoDTO>(eventoEditado);
    }

    public async Task<Evento> ObterPorIdAsync(int id)
    {
        var evento = await _repository.Obter(id);
        return evento;
    }

    public async Task<IEnumerable<Evento>> ObterTodosAsync()
    {
        var eventos = await _repository.ObterTodos();
        return eventos;
    }
}
