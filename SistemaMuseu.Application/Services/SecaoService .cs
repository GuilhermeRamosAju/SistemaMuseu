using AutoMapper;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;

namespace SistemaMuseu.Application.Services;

public class SecaoService : ISecaoService
{
    private readonly ISecaoRepository _repository;
    private readonly IMapper _mapper;

    public SecaoService(ISecaoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SecaoDTO> AdicionarAsync(SecaoDTO secaoDTO)
    {
        var secao = _mapper.Map<Secao>(secaoDTO);
        var secaoAdicionada = await _repository.Adicionar(secao);
        return _mapper.Map<SecaoDTO>(secaoAdicionada);
    }

    public async Task<SecaoDTO> DeletarAsync(int id)
    {
        var secaoExcluida = await _repository.Deletar(id);
        return _mapper.Map<SecaoDTO>(secaoExcluida);
    }

    public async Task<SecaoDTO> EditarAsync(Secao secao)
    {
        var secaoEditada = await _repository.Editar(secao);
        return _mapper.Map<SecaoDTO>(secaoEditada);
    }

    public async Task<Secao> ObterPorIdAsync(int id)
    {
        var secao = await _repository.Obter(id);
        return secao;
    }

    public async Task<IEnumerable<Secao>> ObterTodosAsync()
    {
        var secoes = await _repository.ObterTodos();
        return secoes;
    }
}
