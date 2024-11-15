using SistemaMuseu.Domain.Entities;

namespace SistemaMuseu.Domain.Interfaces;

public interface IFuncionarioRepository
{
    Task<Funcionario> Adicionar(Funcionario funcionario);

    Task<Funcionario> Editar(Funcionario funcionario);

    Task<Funcionario> Deletar(int id);

    Task<Funcionario> Obter(int id);

    Task<IEnumerable<Funcionario>> ObterTodos();
}
