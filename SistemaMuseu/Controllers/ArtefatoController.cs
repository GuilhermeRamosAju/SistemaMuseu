using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArtefatoController : Controller
{
    private readonly IArtefatoService _artefatoService;
    private readonly IMapper _mapper;

    public ArtefatoController(IArtefatoService artefatoService, IMapper mapper)
    {
        _artefatoService = artefatoService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar (ArtefatoDTO artefatoDTO)
    {
       var artefatoAdicionado =  await _artefatoService.AdicionarAsync(artefatoDTO);
        if(artefatoAdicionado == null)
        {
            return BadRequest("Ocorreu um erro ao adicionar o artefato");
        }

        return Ok(artefatoAdicionado);
        
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Editar(int id, [FromBody] ArtefatoDTO artefatoDTO)
    {
        if (artefatoDTO == null)
        {
            return BadRequest("O corpo da requisição não pode ser nulo.");
        }
        // Verifica se o artefato com o ID fornecido existe
        var artefatoObtido = await _artefatoService.ObterPorIdAsync(id);
        if (artefatoObtido == null)
        {
            return NotFound("O artefato com o ID fornecido não foi encontrado.");
        }

        // Mapeia o DTO para a entidade Artefato e atualiza o ID
        var artefatoParaEditar = _mapper.Map<Artefato>(artefatoDTO);
        artefatoParaEditar.Id = id;

        // Chama o serviço para editar o artefato
        var artefatoAlterado = await _artefatoService.EditarAsync(artefatoParaEditar);
        if (artefatoAlterado == null)
        {
            return BadRequest("Ocorreu um erro ao editar o artefato.");
        }

        return Ok(artefatoAlterado);
    }



    [HttpDelete]
    public async Task<ActionResult> Alterar(int id)
    {
        var artefatoAlterado = await _artefatoService.DeletarAsync(id);
        if (artefatoAlterado == null)
        {
            return BadRequest("Ocorreu um erro ao deletar o artefato");
        }

        return Ok(artefatoAlterado);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Obter(int id)
    {
        var artefatoObtido = await _artefatoService.ObterPorIdAsync(id);
        if (artefatoObtido == null)
        {
            return NotFound("Ocorreu um erro ao obter o artefato");
        }

        return Ok(artefatoObtido);
    }

    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var artefatosObtidos = await _artefatoService.ObterTodosAsync();
        if (artefatosObtidos == null)
        {
            return NotFound("Ocorreu um erro ao obter os artefatos");
        }

        return Ok(artefatosObtidos);
    }

}
