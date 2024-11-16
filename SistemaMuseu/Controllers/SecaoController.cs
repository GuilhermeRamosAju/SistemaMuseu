using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Application.Services;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecaoController : Controller
{
    private readonly ISecaoService _secaoService;
    private readonly IFuncionarioService _funcionarioService;
    private readonly IMapper _mapper;

    public SecaoController(ISecaoService secaoService, IFuncionarioService funcionarioService, IMapper mapper)
    {
        _secaoService = secaoService;
        _funcionarioService = funcionarioService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar(SecaoDTO secaoDTO)
    {
        // Verifique se o funcionário existe
        var funcionarioExiste = await _funcionarioService.ObterPorIdAsync(secaoDTO.ResponsavelId);

        if (funcionarioExiste == null)
        {
            return BadRequest("O funcionário informado não existe na base de dados");
        }

        // Mapeie o DTO para a entidade Exposicao
        var exposicao = _mapper.Map<Secao>(secaoDTO);

        // Associe o artefato à exposição
        exposicao.Responsavel = funcionarioExiste;

        var secaoAdicionada = await _secaoService.AdicionarAsync(exposicao);
        if (secaoAdicionada == null)
        {
            return BadRequest("Ocorreu um erro ao adicionar a seção");
        }

        return Ok(secaoAdicionada);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Editar(int id, [FromBody] SecaoDTO secaoDTO)
    {
        if (secaoDTO == null)
        {
            return BadRequest("O corpo da requisição não pode ser nulo.");
        }

        // Verifica se a seção com o ID fornecido existe
        var secaoObtida = await _secaoService.ObterPorIdAsync(id);
        if (secaoObtida == null)
        {
            return NotFound("A seção com o ID fornecido não foi encontrada.");
        }

        // Mapeia o DTO para a entidade Secao e atualiza o ID
        var secaoParaEditar = _mapper.Map<Secao>(secaoDTO);
        secaoParaEditar.Id = id;

        // Chama o serviço para editar a seção
        var secaoAlterada = await _secaoService.EditarAsync(secaoParaEditar);
        if (secaoAlterada == null)
        {
            return BadRequest("Ocorreu um erro ao editar a seção.");
        }

        return Ok(secaoAlterada);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Deletar(int id)
    {
        var secaoDeletada = await _secaoService.DeletarAsync(id);
        if (secaoDeletada == null)
        {
            return BadRequest("Ocorreu um erro ao deletar a seção");
        }

        return Ok(secaoDeletada);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Obter(int id)
    {
        var secaoObtida = await _secaoService.ObterPorIdAsync(id);
        if (secaoObtida == null)
        {
            return NotFound("Ocorreu um erro ao obter a seção");
        }

        return Ok(secaoObtida);
    }

    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var secoesObtidas = await _secaoService.ObterTodosAsync();
        if (secoesObtidas == null)
        {
            return NotFound("Ocorreu um erro ao obter as seções");
        }

        return Ok(secoesObtidas);
    }
}
