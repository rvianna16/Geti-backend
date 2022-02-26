using Geti.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface IColaboradorRepository : IRepository<Colaborador>
    {
        Task<Colaborador> ObterColaborador(Guid id);

        Task<IEnumerable<Colaborador>> ObterColaboradores();
        
        Task<Colaborador> ObterColaboradorEquipamentos(Guid id);
    }
}
