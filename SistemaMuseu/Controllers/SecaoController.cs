using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecaoController : Controller
{
    private readonly ISecaoService _secaoService;

    public SecaoController(ISecaoService secaoService)
    {
        _secaoService = secaoService;
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar(SecaoDTO secaoDTO)
    {
        var secaoAdicionada = await _secaoService.AdicionarAsync(secaoDTO);
        if (secaoAdicionada == null)
        {
            return BadRequest("Ocorreu um erro ao adicionar a secao");
        }

        return Ok(secaoAdicionada);
    }

    [HttpPut]
    public async Task<ActionResult> Editar(SecaoDTO secaoDTO)
    {
        var secaoAlterada = await _secaoService.EditarAsync(secaoDTO);
        if (secaoAlterada == null)
        {
            return BadRequest("Ocorreu um erro ao editar a secao");
        }

        return Ok(secaoAlterada);
    }

    [HttpDelete]
    public async Task<ActionResult> Deletar(int id)
    {
        var secaoDeletada = await _secaoService.DeletarAsync(id);
        if (secaoDeletada == null)
        {
            return BadRequest("Ocorreu um erro ao deletar a secao");
        }

        return Ok(secaoDeletada);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Obter(int id)
    {
        var secaoObtida = await _secaoService.ObterPorIdAsync(id);
        if (secaoObtida == null)
        {
            return NotFound("Secao nao encontrada");
        }

        return Ok(secaoObtida);
    }

    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var secoesObtidas = await _secaoService.ObterTodosAsync();
        if (secoesObtidas == null)
        {
            return NotFound("Nao ha secoes disponiveis");
        }

        return Ok(secoesObtidas);
    }
}
