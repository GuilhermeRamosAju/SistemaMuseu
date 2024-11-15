using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Domain.Interfaces;

public interface IVisitanteRepository
{
    Task<Visitante> Adicionar(Visitante visitante);

    Task<Visitante> Editar(Visitante visitante);

    Task<Visitante> Deletar(int id);

    Task<Visitante> Obter(int id);

    Task<IEnumerable<Visitante>> ObterTodos();
}
