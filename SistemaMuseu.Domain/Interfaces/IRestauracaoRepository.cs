using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Domain.Interfaces;

public interface IRestauracaoRepository
{
    Task<Restauracao> Adicionar(Restauracao restauração);

    Task<Restauracao> Editar(Restauracao restauração);

    Task<Restauracao> Deletar(int id);

    Task<Restauracao> Obter(int id);

    Task<IEnumerable<Restauracao>> ObterTodos();
}
