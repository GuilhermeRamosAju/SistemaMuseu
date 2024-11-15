using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Domain.Interfaces;

public interface IDoacaoRepository
{
    Task<Doacao> Adicionar(Doacao doacao);

    Task<Doacao> Editar(Doacao doacao);

    Task<Doacao> Deletar(int id);

    Task<Doacao> Obter(int id);

    Task<IEnumerable<Doacao>> ObterTodos();
}
