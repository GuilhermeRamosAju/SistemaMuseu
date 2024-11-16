using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Application.Services;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompraController : Controller
{
    private readonly ICompraService _compraService;
    private readonly IFornecedorService _fornecedorService;
    private readonly IMapper _mapper;

    public CompraController(ICompraService compraService, IMapper mapper,IFornecedorService fornecedorService)
    {
        _compraService = compraService;
        _fornecedorService = fornecedorService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> Adicionar(CompraDTO compraDTO)
    {
        // Verifique se o fornecedor existe
        var fornecedorExiste = await _fornecedorService.ObterPorIdAsync(compraDTO.FornecedorId);

        if (fornecedorExiste == null)
        {
            return BadRequest("O fornecedor informado não existe na base de dados");
        }

        // Mapeie o DTO para a entidade Compra
        var compra = _mapper.Map<Compra>(compraDTO);

        // Associe o fornecedor à compra
        compra.Fornecedor = fornecedorExiste;  // Atribuindo o fornecedor já existente à compra

        // Adicione a compra
        var compraAdicionada = await _compraService.AdicionarAsync(compra);
        if (compraAdicionada == null)
        {
            return BadRequest("Ocorreu um erro ao adicionar a compra");
        }

        return Ok(compraAdicionada);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult> Editar(int id, [FromBody] CompraDTO compraDTO)
    {
        if (compraDTO == null)
        {
            return BadRequest("O corpo da requisição não pode ser nulo.");
        }

        // Verifica se o compra com o ID fornecido existe
        var compraObtido = await _compraService.ObterPorIdAsync(id);
        if (compraObtido == null)
        {
            return NotFound("A compra com o ID fornecido não foi encontrado.");
        }

        // Mapeia o DTO para a entidade compra e atualiza o ID
        var compraParaEditar = _mapper.Map<Compra>(compraDTO);
        compraParaEditar.Id = id;

        // Chama o serviço para editar a compra
        var compraAlterado = await _compraService.EditarAsync(compraParaEditar);
        if (compraAlterado == null)
        {
            return BadRequest("Ocorreu um erro ao editar a compra.");
        }

        return Ok(compraAlterado);
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
