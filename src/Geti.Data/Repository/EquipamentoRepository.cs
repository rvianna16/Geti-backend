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
            return await Db.Equipamentos.AsNoTracking()
                .Include(e => e.Colaborador)
                .OrderBy(c => c.Patrimonio).ToListAsync();
        }

        public async Task<Equipamento> ObterEquipamentoColaborador(Guid id)
        {
            return await Db.Equipamentos.AsNoTracking()
                .Include(e => e.Colaborador)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Equipamento> ObterEquipamentoDetalhes(Guid id)
        {
            return await Db.Equipamentos.AsNoTracking()
                .Include(e => e.Colaborador)
                .Include(e => e.Comentarios)
                .Include(e => e.Licencas)
                .ThenInclude(l => l.Licenca)
                .ThenInclude(l => l.Software)
                .FirstOrDefaultAsync(e => e.Id == id);
        }       

    }
}
