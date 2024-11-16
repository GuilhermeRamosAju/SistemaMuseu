using SistemaMuseu.Application.DTOs;
using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Application.Interfaces;

public interface ICompraService
{
    Task<CompraDTO> AdicionarAsync(Compra compraDto);
    Task<CompraDTO> EditarAsync(Compra compraDto);
    Task<CompraDTO> DeletarAsync(int id);
    Task<Compra> ObterPorIdAsync(int id);
    Task<IEnumerable<Compra>> ObterTodosAsync();
}
