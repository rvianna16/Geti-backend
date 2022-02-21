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
    public class ColaboradorRepository : Repository<Colaborador>, IColaboradorRepository
    {

        public ColaboradorRepository(GetiDbContext context) : base(context) { }

        public async Task<Colaborador> ObterColaborador(Guid id)
        {
            return await Db.Colaboradores.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);            
        }       

        public async Task<IEnumerable<Colaborador>> ObterColaboradores()
        {
            return await Db.Colaboradores.
                OrderBy(c => c.Nome).ToListAsync();
        }
        public async Task<IEnumerable<Colaborador>> ObterColaboradorEquipamentos(Guid id)
        {
            return await Db.Colaboradores.AsNoTracking().Include(e => e.Equipamentos)
                .OrderBy(c => c.Nome).ToListAsync();
        }
    }
}
