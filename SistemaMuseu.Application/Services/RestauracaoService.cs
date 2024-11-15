using AutoMapper;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;

namespace SistemaMuseu.Application.Services;

public class RestauracaoService : IRestauracaoService
{
    private readonly IRestauracaoRepository _repository;
    private readonly IMapper _mapper;

    public RestauracaoService(IRestauracaoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RestauracaoDTO> AdicionarAsync(RestauracaoDTO restauracaoDTO)
    {
        var restauracao = _mapper.Map<Restauracao>(restauracaoDTO);
        var restauracaoAdicionada = await _repository.Adicionar(restauracao);
        return _mapper.Map<RestauracaoDTO>(restauracaoAdicionada);
    }

    public async Task<RestauracaoDTO> DeletarAsync(int id)
    {
        var restauracaoExcluida = await _repository.Deletar(id);
        return _mapper.Map<RestauracaoDTO>(restauracaoExcluida);
    }

    public async Task<RestauracaoDTO> EditarAsync(RestauracaoDTO restauracaoDTO)
    {
        var restauracao = _mapper.Map<Restauracao>(restauracaoDTO);
        var restauracaoEditada = await _repository.Editar(restauracao);
        return _mapper.Map<RestauracaoDTO>(restauracaoEditada);
    }

    public async Task<RestauracaoDTO> ObterPorIdAsync(int id)
    {
        var restauracao = await _repository.Obter(id);
        return _mapper.Map<RestauracaoDTO>(restauracao);
    }

    public async Task<IEnumerable<RestauracaoDTO>> ObterTodosAsync()
    {
        var restauracoes = await _repository.ObterTodos();
        return _mapper.Map<IEnumerable<RestauracaoDTO>>(restauracoes);
    }
}
