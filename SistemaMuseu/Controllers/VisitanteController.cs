using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitanteController : Controller
{
    private readonly IVisitanteService _visitanteService;

    public VisitanteController(IVisitanteService visitanteService)
    {
        _visitanteService = visitanteService;
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar(VisitanteDTO visitanteDTO)
    {
        var visitanteAdicionado = await _visitanteService.AdicionarAsync(visitanteDTO);
        if (visitanteAdicionado == null)
        {
            return BadRequest("Ocorreu um erro ao adicionar o visitante");
        }

        return Ok(visitanteAdicionado);
    }

    [HttpPut]
    public async Task<ActionResult> Editar(VisitanteDTO visitanteDTO)
    {
        var visitanteAlterado = await _visitanteService.EditarAsync(visitanteDTO);
        if (visitanteAlterado == null)
        {
            return BadRequest("Ocorreu um erro ao editar o visitante");
        }

        return Ok(visitanteAlterado);
    }

    [HttpDelete]
    public async Task<ActionResult> Deletar(int id)
    {
        var visitanteDeletado = await _visitanteService.DeletarAsync(id);
        if (visitanteDeletado == null)
        {
            return BadRequest("Ocorreu um erro ao deletar o visitante");
        }

        return Ok(visitanteDeletado);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Obter(int id)
    {
        var visitanteObtido = await _visitanteService.ObterPorIdAsync(id);
        if (visitanteObtido == null)
        {
            return NotFound("Visitante não encontrado");
        }

        return Ok(visitanteObtido);
    }

    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var visitantesObtidos = await _visitanteService.ObterTodosAsync();
        if (visitantesObtidos == null)
        {
            return NotFound("Não há visitantes disponíveis");
        }

        return Ok(visitantesObtidos);
    }
}
