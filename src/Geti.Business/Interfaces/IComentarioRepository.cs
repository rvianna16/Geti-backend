using Geti.Business.Models;
using System;
using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface IComentarioRepository : IRepository<Comentario>
    {
        Task<Comentario> ObterComentario(Guid id);
    }
}
