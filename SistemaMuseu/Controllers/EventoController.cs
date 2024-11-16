using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : Controller
{
    private readonly IEventoService _eventoService;

    public EventoController(IEventoService eventoService)
    {
        _eventoService = eventoService;
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

    [HttpPut]
    public async Task<ActionResult> Editar(EventoDTO eventoDTO)
    {
        var eventoAlterado = await _eventoService.EditarAsync(eventoDTO);
        if (eventoAlterado == null)
        {
            return BadRequest("Ocorreu um erro ao editar o evento");
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
