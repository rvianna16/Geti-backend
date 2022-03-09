using Geti.Business.Interfaces;
using Geti.Business.Models;
using Geti.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Data.Repository
{
    public class EquipamentoLicencaRepository : Repository<EquipamentoLicenca>, IEquipamentoLicencaRepository
    {
        public EquipamentoLicencaRepository(GetiDbContext context) : base(context) { }

        public async Task<EquipamentoLicenca> ObterLicencaVinculada(Guid id)
        {
            return await Db.EquipamentoLicenca.AsNoTracking()
               .FirstOrDefaultAsync(l => l.Id == id);


        }
    }
}
