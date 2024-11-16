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

    public async Task<RestauracaoDTO> AdicionarAsync(Restauracao restauracao)
    {
        var restauracaoAdicionada = await _repository.Adicionar(restauracao);
        return _mapper.Map<RestauracaoDTO>(restauracaoAdicionada);
    }

    public async Task<RestauracaoDTO> DeletarAsync(int id)
    {
        var restauracaoExcluida = await _repository.Deletar(id);
        return _mapper.Map<RestauracaoDTO>(restauracaoExcluida);
    }

    public async Task<RestauracaoDTO> EditarAsync(Restauracao restauracao)
    {
        var restauracaoEditada = await _repository.Editar(restauracao);
        return _mapper.Map<RestauracaoDTO>(restauracaoEditada);
    }

    public async Task<Restauracao> ObterPorIdAsync(int id)
    {
        var restauracao = await _repository.Obter(id);
        return restauracao;
    }

    public async Task<IEnumerable<Restauracao>> ObterTodosAsync()
    {
        var restauracoes = await _repository.ObterTodos();
        return restauracoes;
    }
}
