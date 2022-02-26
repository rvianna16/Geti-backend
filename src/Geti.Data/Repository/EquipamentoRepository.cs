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
    public class EquipamentoRepository : Repository<Equipamento>, IEquipamentoRepository
    {
        public EquipamentoRepository(GetiDbContext context) : base(context) { }

        public async Task<Equipamento> ObterEquipamento(Guid id)
        {
            return await Db.Equipamentos.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Equipamento> ObterEquipamentoLicencas()
        {
            return await Db.Equipamentos.AsNoTracking()
                .Include(e => e.Licencas)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Equipamento>> ObterEquipamentos()
        {
            return await Db.Equipamentos
                .OrderBy(e => e.Patrimonio)
                .ToListAsync();
        }
    }
}
