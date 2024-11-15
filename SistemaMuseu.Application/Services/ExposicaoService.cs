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

    public async Task<ExposicaoDTO> AdicionarAsync(ExposicaoDTO exposicaoDTO)
    {
        var exposicao = _mapper.Map<Exposicao>(exposicaoDTO);
        var exposicaoAdicionada = await _repository.Adicionar(exposicao);
        return _mapper.Map<ExposicaoDTO>(exposicaoAdicionada);
    }

    public async Task<ExposicaoDTO> DeletarAsync(int id)
    {
        var exposicaoExcluida = await _repository.Deletar(id);
        return _mapper.Map<ExposicaoDTO>(exposicaoExcluida);
    }

    public async Task<ExposicaoDTO> EditarAsync(ExposicaoDTO exposicaoDTO)
    {
        var exposicao = _mapper.Map<Exposicao>(exposicaoDTO);
        var exposicaoEditada = await _repository.Editar(exposicao);
        return _mapper.Map<ExposicaoDTO>(exposicaoEditada);
    }

    public async Task<ExposicaoDTO> ObterPorIdAsync(int id)
    {
        var exposicao = await _repository.Obter(id);
        return _mapper.Map<ExposicaoDTO>(exposicao);
    }

    public async Task<IEnumerable<ExposicaoDTO>> ObterTodosAsync()
    {
        var exposicoes = await _repository.ObterTodos();
        return _mapper.Map<IEnumerable<ExposicaoDTO>>(exposicoes);
    }
}
