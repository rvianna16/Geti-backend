using Geti.Business.Models;
using System;

using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface IColaboradorService : IDisposable
    {
        Task<bool> Adicionar(Colaborador colaborador);

        Task Atualizar(Colaborador colaborador);

        Task Remover(Guid id);

        Task AtualizarEquipamento(Equipamento equipamento);
    }
}
