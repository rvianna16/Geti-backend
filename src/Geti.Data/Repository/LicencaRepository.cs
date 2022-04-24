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
                .Include(l => l.Software)
                .Include(l => l.Equipamentos)
                .ThenInclude(e => e.Equipamento)
                .FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<IEnumerable<Licenca>> ObterLicencaSoftware(string filtro)
        {
            IQueryable<Licenca> query = Db.Licencas;

            if (filtro != null)
            {
                query = query.Where(c => c.Nome.ToLower().Contains(filtro.Trim().ToLower()) || c.Software.Nome.ToLower().Contains(filtro.Trim().ToLower()));
            }

            return await query
                .AsNoTracking()
                .Include(l => l.Software)
                .Include(l => l.Equipamentos)
                .ToListAsync();            
        }
    }
}
