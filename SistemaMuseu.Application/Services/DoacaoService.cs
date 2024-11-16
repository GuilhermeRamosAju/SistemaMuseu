using AutoMapper;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;

namespace SistemaMuseu.Application.Services;

public class DoacaoService : IDoacaoService
{
    private readonly IDoacaoRepository _repository;
    private readonly IMapper _mapper;

    public DoacaoService(IDoacaoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DoacaoDTO> AdicionarAsync(Doacao doacao)
    {
        var doacaoAdicionada = await _repository.Adicionar(doacao);
        return _mapper.Map<DoacaoDTO>(doacaoAdicionada);
    }

    public async Task<DoacaoDTO> DeletarAsync(int id)
    {
        var doacaoExcluida = await _repository.Deletar(id);
        return _mapper.Map<DoacaoDTO>(doacaoExcluida);
    }

    public async Task<DoacaoDTO> EditarAsync(Doacao doacao)
    {
        var doacaoEditada = await _repository.Editar(doacao);
        return _mapper.Map<DoacaoDTO>(doacaoEditada);
    }

    public async Task<Doacao> ObterPorIdAsync(int id)
    {
        var doacao = await _repository.Obter(id);
        return doacao;
    }

    public async Task<IEnumerable<Doacao>> ObterTodosAsync()
    {
        var doacoes = await _repository.ObterTodos();
        return doacoes;
    }
}
