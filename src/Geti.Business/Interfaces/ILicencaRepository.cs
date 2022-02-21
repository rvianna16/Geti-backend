using Geti.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface ILicencaRepository : IRepository<Licenca>
    {
        Task<Licenca> ObterLicenca(Guid id);
        Task<IEnumerable<Licenca>> ObterLicencas();
        Task<IEnumerable<Licenca>> ObterLicencaEquipamentos(Guid id);
    }
}
