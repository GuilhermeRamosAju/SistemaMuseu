using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionarioController : Controller
{
    private readonly IFuncionarioService _funcionarioService;
    private readonly IMapper _mapper;

    public FuncionarioController(IFuncionarioService funcionarioService, IMapper mapper)
    {
        _funcionarioService = funcionarioService;
        _mapper = mapper;
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

    [HttpPut("{id}")]
    public async Task<ActionResult> Editar(int id, [FromBody] FuncionarioDTO funcionarioDTO)
    {
        if (funcionarioDTO == null)
        {
            return BadRequest("O corpo da requisição não pode ser nulo.");
        }
        // Verifica se o funcionário com o ID fornecido existe
        var funcionarioObtido = await _funcionarioService.ObterPorIdAsync(id);
        if (funcionarioObtido == null)
        {
            return NotFound("O artefato com o ID fornecido não foi encontrado.");
        }

        // Mapeia o DTO para a entidade funcionário e atualiza o ID
        var funcionarioParaEditar = _mapper.Map<Funcionario>(funcionarioDTO);
        funcionarioParaEditar.Id = id;

        // Chama o serviço para editar o funcionário
        var funcionarioAlterado = await _funcionarioService.EditarAsync(funcionarioParaEditar);
        if (funcionarioAlterado == null)
        {
            return BadRequest("Ocorreu um erro ao editar o funcionário.");
        }

        return Ok(funcionarioAlterado);
    }

    [HttpDelete("{id}")]
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
