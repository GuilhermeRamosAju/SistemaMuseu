using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Domain.Interfaces;

public interface ICompraRepository
{
    Task<Compra> Adicionar(Compra compra);

    Task<Compra> Editar(Compra compra);

    Task<Compra> Deletar(int id);

    Task<Compra> Obter(int id);

    Task<IEnumerable<Compra>> ObterTodos();
}
