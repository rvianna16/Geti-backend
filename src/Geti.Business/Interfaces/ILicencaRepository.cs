using Geti.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface ILicencaRepository : IRepository<Licenca>
    {
        Task<Licenca> ObterLicenca(Guid id);

        Task<IEnumerable<Licenca>> ObterLicencas();

        Task<Licenca> ObterLicencaEquipamentos(Guid id);
    }
}
