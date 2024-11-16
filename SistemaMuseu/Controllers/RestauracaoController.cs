using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestauracaoController : Controller
{
    private readonly IRestauracaoService _restauracaoService;

    public RestauracaoController(IRestauracaoService restauracaoService)
    {
        _restauracaoService = restauracaoService;
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar(RestauracaoDTO restauracaoDTO)
    {
        var restauracaoAdicionada = await _restauracaoService.AdicionarAsync(restauracaoDTO);
        if (restauracaoAdicionada == null)
        {
            return BadRequest("Ocorreu um erro ao adicionar a restauração");
        }

        return Ok(restauracaoAdicionada);
    }

    [HttpPut]
    public async Task<ActionResult> Editar(RestauracaoDTO restauracaoDTO)
    {
        var restauracaoAlterada = await _restauracaoService.EditarAsync(restauracaoDTO);
        if (restauracaoAlterada == null)
        {
            return BadRequest("Ocorreu um erro ao editar a restauração");
        }

        return Ok(restauracaoAlterada);
    }

    [HttpDelete]
    public async Task<ActionResult> Deletar(int id)
    {
        var restauracaoDeletada = await _restauracaoService.DeletarAsync(id);
        if (restauracaoDeletada == null)
        {
            return BadRequest("Ocorreu um erro ao deletar a restauração");
        }

        return Ok(restauracaoDeletada);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Obter(int id)
    {
        var restauracaoObtida = await _restauracaoService.ObterPorIdAsync(id);
        if (restauracaoObtida == null)
        {
            return NotFound("Restauração não encontrada");
        }

        return Ok(restauracaoObtida);
    }

    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var restauracoesObtidas = await _restauracaoService.ObterTodosAsync();
        if (restauracoesObtidas == null)
        {
            return NotFound("Não há restaurações disponíveis");
        }

        return Ok(restauracoesObtidas);
    }
}
