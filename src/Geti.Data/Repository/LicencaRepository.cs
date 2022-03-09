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

        public async Task<Licenca> InserirLicencaEquipamento(Licenca licenca)
        {
            foreach (var equipamento in licenca.Equipamentos)
            {
                var equipamentoConsultado = await Db.Equipamentos.AsNoTracking().FirstAsync(p => p.Id == equipamento.Id);
                Db.Entry(equipamento).CurrentValues.SetValues(equipamentoConsultado);
            }

            return licenca;
        }

        public async Task<Licenca> ObterLicencaEquipamentos(Guid id)
        {
            return await Db.Licencas.AsNoTracking()
                .Include(e => e.Equipamentos)
                .ThenInclude(e => e.Equipamento)
                .FirstOrDefaultAsync(e => e.Id.Equals(id));
        }
    }
}
