using SistemaMuseu.Domain.Entities;
using System.Collections.Generic;

namespace SistemaMuseu.Domain.Interfaces
{
    public interface IEventoRepository
    {
        Task<Evento> Adicionar(Evento evento);

        Task<Evento> Editar(Evento evento);

        Task<Evento> Deletar(int id);

        Task<Evento> Obter(int id);

        Task<IEnumerable<Evento>> ObterTodos();
    }
}
