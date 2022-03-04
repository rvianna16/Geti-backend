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

        public async Task<IEnumerable<Equipamento>> ObterEquipamentosColaboradores()
        {
            return await Db.Equipamentos.AsNoTracking().Include(c => c.Colaborador)
                .OrderBy(e => e.Patrimonio).ToListAsync();
        }

        public async Task<Equipamento> ObterEquipamentoColaborador(Guid id)
        {
            return await Db.Equipamentos.AsNoTracking().Include(c => c.Colaborador)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Equipamento> ObterEquipamentoDetalhes(Guid id)
        {
            return await Db.Equipamentos.AsNoTracking()
                .Include(c => c.Colaborador)
                .Include(c => c.Comentarios)
                .Include(l => l.Licencas)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Equipamento> ObterEquipamentoLicencas(Guid id)
        {
            return await Db.Equipamentos.AsNoTracking()
                .Include(e => e.Licencas)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

    }
}
