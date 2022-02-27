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
        Task<IEnumerable<Equipamento>> ObterEquipamentosColaboradores();
        Task<Equipamento> ObterEquipamentoColaborador(Guid id);

        Task<Equipamento> ObterEquipamentoComentarios(Guid id);
        Task<Equipamento> ObterEquipamentoLicencas(Guid id);
    }
}
