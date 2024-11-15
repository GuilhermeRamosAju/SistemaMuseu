using SistemaMuseu.Domain.Entities;
using System.Collections.Generic;

namespace SistemaMuseu.Domain.Interfaces
{
    public interface IArtefatoRepository
    {
        Task<Artefato> Adicionar(Artefato artefato);

        Task<Artefato> Editar(Artefato artefato);

        Task<Artefato> Deletar(int id);

        Task<Artefato> Obter(int id);

        Task<IEnumerable<Artefato>> ObterTodos();
    }
}
