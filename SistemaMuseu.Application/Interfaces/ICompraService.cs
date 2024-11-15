using SistemaMuseu.Application.DTOs;

namespace SistemaMuseu.Application.Interfaces;

public interface ICompraService
{
    Task<CompraDTO> AdicionarAsync(CompraDTO compraDto);
    Task<CompraDTO> EditarAsync(CompraDTO compraDto);
    Task<CompraDTO> DeletarAsync(int id);
    Task<CompraDTO> ObterPorIdAsync(int id);
    Task<IEnumerable<CompraDTO>> ObterTodosAsync();
}
