using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FornecedorController : Controller
{
    private readonly IFornecedorService _fornecedorService;

    public FornecedorController(IFornecedorService fornecedorService)
    {
        _fornecedorService = fornecedorService;
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar(FornecedorDTO fornecedorDTO)
    {
        var fornecedorAdicionado = await _fornecedorService.AdicionarAsync(fornecedorDTO);
        if (fornecedorAdicionado == null)
        {
            return BadRequest("Ocorreu um erro ao adicionar o fornecedor");
        }

        return Ok(fornecedorAdicionado);
    }

    [HttpPut]
    public async Task<ActionResult> Editar(FornecedorDTO fornecedorDTO)
    {
        var fornecedorAlterado = await _fornecedorService.EditarAsync(fornecedorDTO);
        if (fornecedorAlterado == null)
        {
            return BadRequest("Ocorreu um erro ao editar o fornecedor");
        }

        return Ok(fornecedorAlterado);
    }

    [HttpDelete]
    public async Task<ActionResult> Deletar(int id)
    {
        var fornecedorDeletado = await _fornecedorService.DeletarAsync(id);
        if (fornecedorDeletado == null)
        {
            return BadRequest("Ocorreu um erro ao deletar o fornecedor");
        }

        return Ok(fornecedorDeletado);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Obter(int id)
    {
        var fornecedorObtido = await _fornecedorService.ObterPorIdAsync(id);
        if (fornecedorObtido == null)
        {
            return NotFound("Fornecedor não encontrado");
        }

        return Ok(fornecedorObtido);
    }

    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var fornecedoresObtidos = await _fornecedorService.ObterTodosAsync();
        if (fornecedoresObtidos == null)
        {
            return NotFound("Não há fornecedores disponíveis");
        }

        return Ok(fornecedoresObtidos);
    }
}
