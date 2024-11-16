using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Application.Services;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestauracaoController : Controller
{
    private readonly IRestauracaoService _restauracaoService;
    private readonly IArtefatoService _artefatoService;
    private readonly IMapper _mapper;

    public RestauracaoController(IRestauracaoService restauracaoService, IArtefatoService artefatoService, IMapper mapper)
    {
        _restauracaoService = restauracaoService;
        _artefatoService = artefatoService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar(RestauracaoDTO restauracaoDTO)
    {
        // Verifique se o artefato existe
        var artefatoExiste = await _artefatoService.ObterPorIdAsync(restauracaoDTO.ArtefatoId);

        if (artefatoExiste == null)
        {
            return BadRequest("O artefato informado não existe na base de dados");
        }

        var restauracao = _mapper.Map<Restauracao>(restauracaoDTO);

        // Associe o artefato à restauração
        restauracao.Artefato = artefatoExiste;

        var restauracaoAdicionada = await _restauracaoService.AdicionarAsync(restauracao);
        if (restauracaoAdicionada == null)
        {
            return BadRequest("Ocorreu um erro ao adicionar a restauração");
        }

        return Ok(restauracaoAdicionada);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Editar(int id, [FromBody] RestauracaoDTO restauracaoDTO)
    {
        if (restauracaoDTO == null)
        {
            return BadRequest("O corpo da requisição não pode ser nulo.");
        }

        // Verifica se a restauração com o ID fornecido existe
        var restauracaoObtida = await _restauracaoService.ObterPorIdAsync(id);
        if (restauracaoObtida == null)
        {
            return NotFound("A restauração com o ID fornecido não foi encontrada.");
        }

        // Mapeia o DTO para a entidade Restauracao e atualiza o ID
        var restauracaoParaEditar = _mapper.Map<Restauracao>(restauracaoDTO);
        restauracaoParaEditar.Id = id;

        // Chama o serviço para editar a restauração
        var restauracaoAlterada = await _restauracaoService.EditarAsync(restauracaoParaEditar);
        if (restauracaoAlterada == null)
        {
            return BadRequest("Ocorreu um erro ao editar a restauração.");
        }

        return Ok(restauracaoAlterada);
    }

    [HttpDelete("{id}")]
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
            return NotFound("Ocorreu um erro ao obter a restauração");
        }

        return Ok(restauracaoObtida);
    }

    [HttpGet]
    public async Task<ActionResult> ObterTodos()
    {
        var restauracoesObtidas = await _restauracaoService.ObterTodosAsync();
        if (restauracoesObtidas == null)
        {
            return NotFound("Ocorreu um erro ao obter as restaurações");
        }

        return Ok(restauracoesObtidas);
    }
}
