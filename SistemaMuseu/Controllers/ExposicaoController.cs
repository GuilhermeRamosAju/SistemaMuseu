using Microsoft.AspNetCore.Mvc;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;

namespace SistemaMuseu.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExposicaoController : Controller
    {
        private readonly IExposicaoService _exposicaoService;

        public ExposicaoController(IExposicaoService exposicaoService)
        {
            _exposicaoService = exposicaoService;
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

        [HttpPut]
        public async Task<ActionResult> Editar(ExposicaoDTO exposicaoDTO)
        {
            var exposicaoAlterada = await _exposicaoService.EditarAsync(exposicaoDTO);
            if (exposicaoAlterada == null)
            {
                return BadRequest("Ocorreu um erro ao editar a exposição");
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
