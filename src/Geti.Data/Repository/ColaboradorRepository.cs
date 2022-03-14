using Geti.Business.Interfaces;
using Geti.Business.Models;
using Geti.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Geti.Data.Repository
{
    public class ColaboradorRepository : Repository<Colaborador>, IColaboradorRepository
    {

        public ColaboradorRepository(GetiDbContext context) : base(context) { }

        public async Task<Colaborador> ObterColaboradorEquipamentos(Guid id)
        {
            return await Db.Colaboradores.AsNoTracking()
                .Include(c => c.Equipamentos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }       
    }
}
