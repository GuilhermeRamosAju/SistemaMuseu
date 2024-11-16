using AutoMapper;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;

namespace SistemaMuseu.Application.Services;

public class ExposicaoService : IExposicaoService
{
    private readonly IExposicaoRepository _repository;
    private readonly IMapper _mapper;

    public ExposicaoService(IExposicaoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ExposicaoDTO> AdicionarAsync(Exposicao exposicao)
    {
        var exposicaoAdicionada = await _repository.Adicionar(exposicao);
        return _mapper.Map<ExposicaoDTO>(exposicaoAdicionada);
    }

    public async Task<ExposicaoDTO> DeletarAsync(int id)
    {
        var exposicaoExcluida = await _repository.Deletar(id);
        return _mapper.Map<ExposicaoDTO>(exposicaoExcluida);
    }

    public async Task<ExposicaoDTO> EditarAsync(Exposicao exposicao)
    {
        var exposicaoEditada = await _repository.Editar(exposicao);
        return _mapper.Map<ExposicaoDTO>(exposicaoEditada);
    }

    public async Task<Exposicao> ObterPorIdAsync(int id)
    {
        var exposicao = await _repository.Obter(id);
        return exposicao;
    }

    public async Task<IEnumerable<Exposicao>> ObterTodosAsync()
    {
        var exposicoes = await _repository.ObterTodos();
        return exposicoes;
    }
}
