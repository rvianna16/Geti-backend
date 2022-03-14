using Geti.Business.Interfaces;
using Geti.Business.Models;
using Geti.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Geti.Data.Repository
{
    public class SoftwareRepository : Repository<Software>, ISoftwareRepository
    {
        public SoftwareRepository(GetiDbContext context) : base(context) { }
        
        public async Task<Software> ObterSoftwareLicencas(Guid id)
        {
            return await Db.Softwares.AsNoTracking()
                .Include(s => s.Licencas)
                .FirstOrDefaultAsync(s => s.Id.Equals(id));
               
        }
    }
}
