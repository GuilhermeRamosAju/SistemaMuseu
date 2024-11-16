using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExposicaoController : Controller
    {
        private readonly IExposicaoService _exposicaoService;
        private readonly IMapper _mapper;

        public ExposicaoController(IExposicaoService exposicaoService, IMapper mapper)
        {
            _exposicaoService = exposicaoService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(ExposicaoDTO exposicaoDTO)
        {
            var exposicaoAdicionada = await _exposicaoService.AdicionarAsync(exposicaoDTO);
            if (exposicaoAdicionada == null)
            {
                return BadRequest("Ocorreu um erro ao adicionar a exposição");
            }

            return Ok(exposicaoAdicionada);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Editar(int id, [FromBody] ExposicaoDTO exposicaoDTO)
        {
            if (exposicaoDTO == null)
            {
                return BadRequest("O corpo da requisição não pode ser nulo.");
            }

            // Verifica se o artefato com o ID fornecido existe
            var exposicaoObtida = await _exposicaoService.ObterPorIdAsync(id);
            if (exposicaoObtida == null)
            {
                return NotFound("A exposição com o ID fornecido não foi encontrado.");
            }

            // Mapeia o DTO para a entidade Artefato e atualiza o ID
            var exposicaoParaEditar = _mapper.Map<Exposicao>(exposicaoDTO);
            exposicaoParaEditar.Id = id;

            // Chama o serviço para editar o artefato
            var exposicaoAlterada = await _exposicaoService.EditarAsync(exposicaoParaEditar);
            if (exposicaoAlterada == null)
            {
                return BadRequest("Ocorreu um erro ao editar a exposição.");
            }

            return Ok(exposicaoAlterada);
        }

        [HttpDelete]
        public async Task<ActionResult> Deletar(int id)
        {
            var exposicaoDeletada = await _exposicaoService.DeletarAsync(id);
            if (exposicaoDeletada == null)
            {
                return BadRequest("Ocorreu um erro ao deletar a exposição");
            }

            return Ok(exposicaoDeletada);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Obter(int id)
        {
            var exposicaoObtida = await _exposicaoService.ObterPorIdAsync(id);
            if (exposicaoObtida == null)
            {
                return NotFound("A exposição não foi encontrada");
            }

            return Ok(exposicaoObtida);
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodos()
        {
            var exposicoesObtidas = await _exposicaoService.ObterTodosAsync();
            if (exposicoesObtidas == null)
            {
                return NotFound("Não há exposições disponíveis");
            }

            return Ok(exposicoesObtidas);
        }
    }
}
