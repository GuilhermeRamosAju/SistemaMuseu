using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Application.Interfaces;

public interface IFornecedorService
{
    Task<FornecedorDTO> AdicionarAsync(FornecedorDTO fornecedorDto);
    Task<FornecedorDTO> EditarAsync(Fornecedor fornecedorDto);
    Task<FornecedorDTO> DeletarAsync(int id);
    Task<Fornecedor> ObterPorIdAsync(int id);
    Task<IEnumerable<Fornecedor>> ObterTodosAsync();
}
