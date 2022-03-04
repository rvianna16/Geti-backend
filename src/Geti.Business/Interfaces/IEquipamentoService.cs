using Geti.Business.Models;
using System;
using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface IEquipamentoService
    {
        Task Adicionar(Equipamento equipamento);

        Task Atualizar(Equipamento equipamento);

        Task Remover(Guid id);

        Task AtualizarLicenca(Licenca licenca);
    }
}
