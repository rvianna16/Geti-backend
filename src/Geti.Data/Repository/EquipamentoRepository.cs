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

        public async Task<Equipamento> ObterEquipamentoLicencas(Guid id)
        {
            return await Db.Equipamentos.AsNoTracking()
                .Include(e => e.Licencas)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
              
    }
}
