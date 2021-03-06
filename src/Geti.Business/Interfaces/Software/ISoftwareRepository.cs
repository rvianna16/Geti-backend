using Geti.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface ISoftwareRepository : IRepository<Software>
    {
        Task<IEnumerable<Software>> ObterSoftwares(string filtro);
        Task<Software> ObterSoftwareLicencas(Guid id);
    }
}
