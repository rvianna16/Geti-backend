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

        public async Task<Licenca> ObterLicencaEquipamentos(Guid id)
        {
            return await Db.Licencas.AsNoTracking()
                .Include(e => e.Software)
                .Include(e => e.Equipamentos)
                .ThenInclude(e => e.Equipamento)
                .FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<IEnumerable<Licenca>> ObterLicencaSoftware()
        {
            return await Db.Licencas.AsNoTracking()
                .Include(c => c.Software)
                .OrderBy(e => e.Nome).ToListAsync();
        }
    }
}
