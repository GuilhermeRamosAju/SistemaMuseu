using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitanteController : Controller
{
    private readonly IVisitanteService _visitanteService;
    private readonly IMapper _mapper;

    public VisitanteController(IVisitanteService visitanteService, IMapper mapper)
    {
        _visitanteService = visitanteService;
        _mapper = mapper;
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

    [HttpPut("{id}")]
    public async Task<ActionResult> Editar(int id, [FromBody] VisitanteDTO visitanteDTO)
    {
        if (visitanteDTO == null)
        {
            return BadRequest("O corpo da requisição não pode ser nulo.");
        }

        // Verifica se o visitante com o ID fornecido existe
        var visitanteObtido = await _visitanteService.ObterPorIdAsync(id);
        if (visitanteObtido == null)
        {
            return NotFound("O visitante com o ID fornecido não foi encontrado.");
        }

        // Mapeia o DTO para a entidade Visitante e atualiza o ID
        var visitanteParaEditar = _mapper.Map<Visitante>(visitanteDTO);
        visitanteParaEditar.Id = id;

        // Chama o serviço para editar o visitante
        var visitanteAlterado = await _visitanteService.EditarAsync(visitanteParaEditar);
        if (visitanteAlterado == null)
        {
            return BadRequest("Ocorreu um erro ao editar o visitante.");
        }

        return Ok(visitanteAlterado);
    }

    [HttpDelete("{id}")]
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
            return NotFound("Ocorreu um erro ao obter o visitante");
        }

        return Ok(visitanteObtido);
    }

    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var visitantesObtidos = await _visitanteService.ObterTodosAsync();
        if (visitantesObtidos == null)
        {
            return NotFound("Ocorreu um erro ao obter os visitantes");
        }

        return Ok(visitantesObtidos);
    }
}
