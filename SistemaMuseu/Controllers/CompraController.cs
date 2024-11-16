using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompraController : Controller
{
    private readonly ICompraService _compraService;

    public CompraController(ICompraService compraService)
    {
        _compraService = compraService;
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar(CompraDTO compraDTO)
    {
        var compraAdicionada = await _compraService.AdicionarAsync(compraDTO);
        if (compraAdicionada == null)
        {
            return BadRequest("Ocorreu um erro ao adicionar a compra");
        }

        return Ok(compraAdicionada);
    }

    [HttpPut]
    public async Task<ActionResult> Editar(CompraDTO compraDTO)
    {
        var compraAlterada = await _compraService.EditarAsync(compraDTO);
        if (compraAlterada == null)
        {
            return BadRequest("Ocorreu um erro ao editar a compra");
        }

        return Ok(compraAlterada);
    }

    [HttpDelete]
    public async Task<ActionResult> Deletar(int id)
    {
        var compraDeletada = await _compraService.DeletarAsync(id);
        if (compraDeletada == null)
        {
            return BadRequest("Ocorreu um erro ao deletar a compra");
        }

        return Ok(compraDeletada);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Obter(int id)
    {
        var compraObtida = await _compraService.ObterPorIdAsync(id);
        if (compraObtida == null)
        {
            return NotFound("Compra não encontrada");
        }

        return Ok(compraObtida);
    }

    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var comprasObtidas = await _compraService.ObterTodosAsync();
        if (comprasObtidas == null)
        {
            return NotFound("Não há compras disponíveis");
        }

        return Ok(comprasObtidas);
    }
}
