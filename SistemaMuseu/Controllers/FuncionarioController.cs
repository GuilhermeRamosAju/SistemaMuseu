using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionarioController : Controller
{
    private readonly IFuncionarioService _funcionarioService;

    public FuncionarioController(IFuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar(FuncionarioDTO funcionarioDTO)
    {
        var funcionarioAdicionado = await _funcionarioService.AdicionarAsync(funcionarioDTO);
        if (funcionarioAdicionado == null)
        {
            return BadRequest("Ocorreu um erro ao adicionar o funcionário");
        }

        return Ok(funcionarioAdicionado);
    }

    [HttpPut]
    public async Task<ActionResult> Editar(FuncionarioDTO funcionarioDTO)
    {
        var funcionarioAlterado = await _funcionarioService.EditarAsync(funcionarioDTO);
        if (funcionarioAlterado == null)
        {
            return BadRequest("Ocorreu um erro ao editar o funcionário");
        }

        return Ok(funcionarioAlterado);
    }

    [HttpDelete]
    public async Task<ActionResult> Deletar(int id)
    {
        var funcionarioDeletado = await _funcionarioService.DeletarAsync(id);
        if (funcionarioDeletado == null)
        {
            return BadRequest("Ocorreu um erro ao deletar o funcionário");
        }

        return Ok(funcionarioDeletado);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Obter(int id)
    {
        var funcionarioObtido = await _funcionarioService.ObterPorIdAsync(id);
        if (funcionarioObtido == null)
        {
            return NotFound("Funcionário não encontrado");
        }

        return Ok(funcionarioObtido);
    }

    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var funcionariosObtidos = await _funcionarioService.ObterTodosAsync();
        if (funcionariosObtidos == null)
        {
            return NotFound("Não há funcionários disponíveis");
        }

        return Ok(funcionariosObtidos);
    }
}
