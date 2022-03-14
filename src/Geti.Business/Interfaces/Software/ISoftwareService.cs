using Geti.Business.Models;
using System;
using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface ISoftwareService
    {
        Task Adicionar(Software software);

        Task Atualizar(Software software);

        Task Remover(Guid id);
    }
}
