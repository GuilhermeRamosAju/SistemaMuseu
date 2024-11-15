using AutoMapper;
using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Application.Interfaces;
using SistemaMuseu.Domain.Entities;
using SistemaMuseu.Domain.Interfaces;

namespace SistemaMuseu.Application.Services;

public class FuncionarioService : IFuncionarioService
{
    private readonly IFuncionarioRepository _repository;
    private readonly IMapper _mapper;

    public FuncionarioService(IFuncionarioRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<FuncionarioDTO> AdicionarAsync(FuncionarioDTO funcionarioDTO)
    {
        var funcionario = _mapper.Map<Funcionario>(funcionarioDTO);
        var funcionarioAdicionado = await _repository.Adicionar(funcionario);
        return _mapper.Map<FuncionarioDTO>(funcionarioAdicionado);
    }

    public async Task<FuncionarioDTO> DeletarAsync(int id)
    {
        var funcionarioExcluido = await _repository.Deletar(id);
        return _mapper.Map<FuncionarioDTO>(funcionarioExcluido);
    }

    public async Task<FuncionarioDTO> EditarAsync(FuncionarioDTO funcionarioDTO)
    {
        var funcionario = _mapper.Map<Funcionario>(funcionarioDTO);
        var funcionarioEditado = await _repository.Editar(funcionario);
        return _mapper.Map<FuncionarioDTO>(funcionarioEditado);
    }

    public async Task<FuncionarioDTO> ObterPorIdAsync(int id)
    {
        var funcionario = await _repository.Obter(id);
        return _mapper.Map<FuncionarioDTO>(funcionario);
    }

    public async Task<IEnumerable<FuncionarioDTO>> ObterTodosAsync()
    {
        var funcionarios = await _repository.ObterTodos();
        return _mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarios);
    }
}
