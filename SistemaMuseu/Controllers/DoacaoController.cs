using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoacaoController : Controller
{
    private readonly IDoacaoService _doacaoService;

    public DoacaoController(IDoacaoService doacaoService)
    {
        _doacaoService = doacaoService;
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar(DoacaoDTO doacaoDTO)
    {
        var doacaoAdicionada = await _doacaoService.AdicionarAsync(doacaoDTO);
        if (doacaoAdicionada == null)
        {
            return BadRequest("Ocorreu um erro ao adicionar a doação");
        }

        return Ok(doacaoAdicionada);
    }

    [HttpPut]
    public async Task<ActionResult> Editar(DoacaoDTO doacaoDTO)
    {
        var doacaoAlterada = await _doacaoService.EditarAsync(doacaoDTO);
        if (doacaoAlterada == null)
        {
            return BadRequest("Ocorreu um erro ao editar a doação");
        }

        return Ok(doacaoAlterada);
    }

    [HttpDelete]
    public async Task<ActionResult> Deletar(int id)
    {
        var doacaoDeletada = await _doacaoService.DeletarAsync(id);
        if (doacaoDeletada == null)
        {
            return BadRequest("Ocorreu um erro ao deletar a doação");
        }

        return Ok(doacaoDeletada);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Obter(int id)
    {
        var doacaoObtida = await _doacaoService.ObterPorIdAsync(id);
        if (doacaoObtida == null)
        {
            return NotFound("Doação não encontrada");
        }

        return Ok(doacaoObtida);
    }

    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var doacoesObtidas = await _doacaoService.ObterTodosAsync();
        if (doacoesObtidas == null)
        {
            return NotFound("Não há doações disponíveis");
        }

        return Ok(doacoesObtidas);
    }
}
