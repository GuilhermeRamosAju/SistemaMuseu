using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Application.Services;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : Controller
{
    private readonly IEventoService _eventoService;
    private readonly IMapper _mapper;

    public EventoController(IEventoService eventoService, IMapper mapper)
    {
        _eventoService = eventoService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar(EventoDTO eventoDTO)
    {
        var eventoAdicionado = await _eventoService.AdicionarAsync(eventoDTO);
        if (eventoAdicionado == null)
        {
            return BadRequest("Ocorreu um erro ao adicionar o evento");
        }

        return Ok(eventoAdicionado);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Editar(int id, [FromBody] EventoDTO eventoDTO)
    {
        if (eventoDTO == null)
        {
            return BadRequest("O corpo da requisição não pode ser nulo.");
        }

        // Verifica se o evento com o ID fornecido existe
        var eventoObtido = await _eventoService.ObterPorIdAsync(id);
        if (eventoObtido == null)
        {
            return NotFound("O evento com o ID fornecido não foi encontrado.");
        }

        // Mapeia o DTO para a entidade Evento e atualiza o ID
        var eventoParaEditar = _mapper.Map<Evento>(eventoDTO);
        eventoParaEditar.Id = id;

        // Chama o serviço para editar o evento
        var eventoAlterado = await _eventoService.EditarAsync(eventoParaEditar);
        if (eventoAlterado == null)
        {
            return BadRequest("Ocorreu um erro ao editar o evento.");
        }

        return Ok(eventoAlterado);
    }

    [HttpDelete]
    public async Task<ActionResult> Deletar(int id)
    {
        var eventoDeletado = await _eventoService.DeletarAsync(id);
        if (eventoDeletado == null)
        {
            return BadRequest("Ocorreu um erro ao deletar o evento");
        }

        return Ok(eventoDeletado);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Obter(int id)
    {
        var eventoObtido = await _eventoService.ObterPorIdAsync(id);
        if (eventoObtido == null)
        {
            return NotFound("Evento não encontrado");
        }

        return Ok(eventoObtido);
    }

    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var eventosObtidos = await _eventoService.ObterTodosAsync();
        if (eventosObtidos == null)
        {
            return NotFound("Não há eventos disponíveis");
        }

        return Ok(eventosObtidos);
    }
}
