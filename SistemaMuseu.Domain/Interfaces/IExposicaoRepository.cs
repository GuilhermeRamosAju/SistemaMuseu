using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Domain.Interfaces;

public interface IExposicaoRepository
{
    Task<Exposicao> Adicionar(Exposicao exposicao);

    Task<Exposicao> Editar(Exposicao exposicao);

    Task<Exposicao> Deletar(int id);

    Task<Exposicao> Obter(int id);

    Task<IEnumerable<Exposicao>> ObterTodos();
}
