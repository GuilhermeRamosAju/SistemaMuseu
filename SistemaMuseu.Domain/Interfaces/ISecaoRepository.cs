using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Domain.Interfaces;

public interface ISecaoRepository
{
    Task<Secao> Adicionar(Secao secao);

    Task<Secao> Editar(Secao secao);

    Task<Secao> Deletar(int id);

    Task<Secao> Obter(int id);

    Task<IEnumerable<Secao>> ObterTodos();
}
