using Geti.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface IEquipamentoRepository : IRepository<Equipamento>
    {
        Task<Equipamento> ObterEquipamento(Guid id);

        Task<IEnumerable<Equipamento>> ObterEquipamentos();

        Task<Equipamento> ObterEquipamentoLicencas();
    }
}
