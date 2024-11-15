using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Domain.Interfaces;

public interface IFornecedorRepository
{
    Task<Fornecedor> Adicionar(Fornecedor fornecedor);

    Task<Fornecedor> Editar(Fornecedor fornecedor);

    Task<Fornecedor> Deletar(int id);

    Task<Fornecedor> Obter(int id);

    Task<IEnumerable<Fornecedor>> ObterTodos();
}
