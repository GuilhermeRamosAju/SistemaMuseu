using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArtefatoController : Controller
{
    private readonly IArtefatoService _artefatoService;

    public ArtefatoController(IArtefatoService artefatoService)
    {
        _artefatoService = artefatoService;
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar (ArtefatoDTO artefatoDTO)
    {
       var artefatoAdicionado =  await _artefatoService.Adicionar (artefatoDTO);
        if(artefatoAdicionado == null)
        {
            return BadRequest("Ocorreu um erro ao adicionar o artefato");
        }

        return Ok(artefatoAdicionado);
        
    }

    [HttpPut]
    public async Task<ActionResult> Editar(ArtefatoDTO artefatoDTO)
    {
        var artefatoAlterado = await _artefatoService.Editar(artefatoDTO);
        if (artefatoAlterado == null)
        {
            return BadRequest("Ocorreu um erro ao editar o artefato");
        }

        return Ok(artefatoAlterado);

    }


    [HttpDelete]
    public async Task<ActionResult> Alterar(int id)
    {
        var artefatoAlterado = await _artefatoService.Deletar(id);
        if (artefatoAlterado == null)
        {
            return BadRequest("Ocorreu um erro ao deletar o artefato");
        }

        return Ok(artefatoAlterado);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Obter(int id)
    {
        var artefatoObtido = await _artefatoService.Obter(id);
        if (artefatoObtido == null)
        {
            return NotFound("Ocorreu um erro ao obter o artefato");
        }

        return Ok(artefatoObtido);
    }

    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var artefatosObtidos = await _artefatoService.ObterTodos();
        if (artefatosObtidos == null)
        {
            return NotFound("Ocorreu um erro ao obter os artefatos");
        }

        return Ok(artefatosObtidos);
    }

}
