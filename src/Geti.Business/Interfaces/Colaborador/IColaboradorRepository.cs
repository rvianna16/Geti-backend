using Geti.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface IColaboradorRepository : IRepository<Colaborador>   
    {
        Task<IEnumerable<Colaborador>> ObterTodosColaboradores(string filtro);
        Task<Colaborador> ObterColaboradorEquipamentos(Guid id);
    }   
}
