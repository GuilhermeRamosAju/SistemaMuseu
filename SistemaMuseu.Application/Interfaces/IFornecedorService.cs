using SistemaMuseu.Application.DTOs;

namespace SistemaMuseu.Application.Interfaces;

public interface IFornecedorService
{
    Task<FornecedorDTO> AdicionarAsync(FornecedorDTO fornecedorDto);
    Task<FornecedorDTO> EditarAsync(FornecedorDTO fornecedorDto);
    Task<FornecedorDTO> DeletarAsync(int id);
    Task<FornecedorDTO> ObterPorIdAsync(int id);
    Task<IEnumerable<FornecedorDTO>> ObterTodosAsync();
}
