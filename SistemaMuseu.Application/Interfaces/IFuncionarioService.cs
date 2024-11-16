using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Application.Interfaces;

public interface IFuncionarioService
{
    Task<FuncionarioDTO> AdicionarAsync(FuncionarioDTO funcionarioDto);
    Task<FuncionarioDTO> EditarAsync(Funcionario funcionarioDto);
    Task<FuncionarioDTO> DeletarAsync(int id);
    Task<Funcionario> ObterPorIdAsync(int id);
    Task<IEnumerable<Funcionario>> ObterTodosAsync();
}
