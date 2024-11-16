using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Application.Services;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoacaoController : Controller
{
    private readonly IDoacaoService _doacaoService;
    private readonly IArtefatoService _artefatoService;
    private readonly IMapper _mapper;

    public DoacaoController(IDoacaoService doacaoService, IArtefatoService artefatoService, IMapper mapper)
    {
        _doacaoService = doacaoService;
        _artefatoService = artefatoService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar(DoacaoDTO doacaoDTO)
    {
        // Verifique se o artefato existe
        var artefatoExiste = await _artefatoService.ObterPorIdAsync(doacaoDTO.ArtefatoId);

        if (artefatoExiste == null)
        {
            return BadRequest("O artefato informado não existe na base de dados");
        }

        // Mapeie o DTO para a entidade Doacao
        var doacao = _mapper.Map<Doacao>(doacaoDTO);

        // Associe o artefato à doação
        doacao.Artefato = artefatoExiste;

        // Adiciona a doação
        var doacaoAdicionada = await _doacaoService.AdicionarAsync(doacao);
        if (doacaoAdicionada == null)
        {
            return BadRequest("Ocorreu um erro ao adicionar a doação");
        }

        return Ok(doacaoAdicionada);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Editar(int id, [FromBody] DoacaoDTO doacaoDTO)
    {
        if (doacaoDTO == null)
        {
            return BadRequest("O corpo da requisição não pode ser nulo.");
        }

        // Verifica se a doação com o ID fornecido existe
        var doacaoObtida = await _doacaoService.ObterPorIdAsync(id);
        if (doacaoObtida == null)
        {
            return NotFound("O artefato com o ID fornecido não foi encontrado.");
        }

        // Mapeia o DTO para a entidade doação e atualiza o ID
        var doacaoParaEditar = _mapper.Map<Doacao>(doacaoDTO);
        doacaoParaEditar.Id = id;

        // Chama o serviço para editar a doação
        var doacaoAlterada = await _doacaoService.EditarAsync(doacaoParaEditar);
        if (doacaoAlterada == null)
        {
            return BadRequest("Ocorreu um erro ao editar a doação.");
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
