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
    public class ColaboradorRepository : Repository<Colaborador>, IColaboradorRepository
    {

        public ColaboradorRepository(GetiDbContext context) : base(context) { }

        public async Task<IEnumerable<Colaborador>> ObterTodosColaboradores(string filtro)
        {
            IQueryable<Colaborador> query = Db.Colaboradores;

            if (filtro != null)
            {
                query = query.Where(c => c.Nome.ToLower().Contains(filtro.Trim().ToLower()) || c.Email.ToLower().Contains(filtro.Trim().ToLower()));
            }

            return await query
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Colaborador> ObterColaboradorEquipamentos(Guid id)
        {
            return await Db.Colaboradores.AsNoTracking()
                .Include(c => c.Equipamentos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }       
    }
}
