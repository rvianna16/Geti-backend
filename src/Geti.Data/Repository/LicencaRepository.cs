using Geti.Business.Interfaces;
using Geti.Business.Models;
using Geti.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geti.Data.Repository
{
    public class LicencaRepository : Repository<Licenca>, ILicencaRepository
    {

        public LicencaRepository(GetiDbContext context) : base(context) { }
        
        public async Task<Licenca> ObterLicenca(Guid id)
        {
            return await Db.Licencas.AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Licenca>> ObterLicencas()
        {
            return await Db.Licencas
                .OrderBy(l => l.Nome)
                .ToListAsync();
        }

        public async Task<IEnumerable<Licenca>> ObterLicencaEquipamentos(Guid id)
        {
            return await Db.Licencas.AsNoTracking().Include(e => e.Equipamentos)
               .OrderBy(l => l.Nome).ToListAsync();
        }
    }
}
