using Geti.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface IEquipamentoLicencaRepository : IRepository<EquipamentoLicenca>
    {
        Task<EquipamentoLicenca> ObterLicencaVinculada(Guid id);
    }
}
