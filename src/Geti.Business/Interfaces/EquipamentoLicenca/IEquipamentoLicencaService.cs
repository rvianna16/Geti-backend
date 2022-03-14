using Geti.Business.Models;
using System;
using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface IEquipamentoLicencaService
    {
        Task Adicionar(EquipamentoLicenca equipamentoLicenca);

        Task Remover(Guid id);
    }
}
