using Geti.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface ILicencaRepository : IRepository<Licenca>
    {
        Task<IEnumerable<Licenca>> ObterLicencaSoftware(string filtro);
        Task<Licenca> ObterLicencaEquipamentos(Guid id);
    }   
}
