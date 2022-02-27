using Geti.Business.Models;
using System;
using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface IComentarioService
    {
        Task Adicionar(Comentario comentario);
        Task Remover(Guid id);
    }
}
