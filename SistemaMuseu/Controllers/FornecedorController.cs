using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Application.Services;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FornecedorController : Controller
{
    private readonly IFornecedorService _fornecedorService;
    private readonly IMapper _mapper;

    public FornecedorController(IFornecedorService fornecedorService, IMapper mapper)
    {
        _fornecedorService = fornecedorService;
        _mapper = mapper;
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

    [HttpPut("{id}")]
    public async Task<ActionResult> Editar(int id, [FromBody] FornecedorDTO fornecedorDTO)
    {
        if (fornecedorDTO == null)
        {
            return BadRequest("O corpo da requisição não pode ser nulo.");
        }
        var fornecedorObtido = await _fornecedorService.ObterPorIdAsync(id);
        if (fornecedorObtido == null)
        {
            return NotFound("O artefato com o ID fornecido não foi encontrado.");
        }

        var fornecedorParaEditar = _mapper.Map<Fornecedor>(fornecedorDTO);
        fornecedorParaEditar.Id = id;

        var fornecedorAlterado = await _fornecedorService.EditarAsync(fornecedorParaEditar);
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
