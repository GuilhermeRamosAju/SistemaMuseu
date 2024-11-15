using SistemaMuseu.Application.DTOs;

namespace SistemaMuseu.Application.Interfaces;

public interface IFuncionarioService
{
    Task<FuncionarioDTO> AdicionarAsync(FuncionarioDTO funcionarioDto);
    Task<FuncionarioDTO> EditarAsync(FuncionarioDTO funcionarioDto);
    Task<FuncionarioDTO> DeletarAsync(int id);
    Task<FuncionarioDTO> ObterPorIdAsync(int id);
    Task<IEnumerable<FuncionarioDTO>> ObterTodosAsync();
}
