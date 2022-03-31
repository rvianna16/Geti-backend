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
    public class SoftwareRepository : Repository<Software>, ISoftwareRepository
    {
        public SoftwareRepository(GetiDbContext context) : base(context) { }

        public async Task<IEnumerable<Software>> ObterSoftwares(string filtro)
        {
            IQueryable<Software> query = Db.Softwares;

            if (filtro != null)
            {
                query = query.Where(c => c.Nome.ToLower().Contains(filtro.Trim().ToLower()));

            }

            return await query
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Software> ObterSoftwareLicencas(Guid id)
        {
            return await Db.Softwares.AsNoTracking()
                .Include(s => s.Licencas)
                .FirstOrDefaultAsync(s => s.Id.Equals(id));
               
        }

        
    }
}
